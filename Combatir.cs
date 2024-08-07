namespace CombatiendoEspacio;
using PersonajeEspacio;
using System;
using System.Threading;
using ApiC;
using System.Threading.Tasks;
 public class Combate
{
     private Random random = new Random();

   public async Task<Personaje> IniciarCombate(Personaje personajeSeleccionado, List<Personaje> personajes)
    {
        if (personajes == null || personajes.Count < 2)//Control solo por las dudas
        {
            Console.WriteLine("No hay suficientes personajes para iniciar el combate.");
            return null;
        }

        Root clima = await ClimaApi.ObtenerClima();
        string estadoClima = ClimaApi.ObtenerEstadoClima(clima);
        AjustarArmaduraPorClima(personajes, estadoClima);  //SEGUN EL CLIMA AJUSTA LA ARMADURA 2 PTS MAS

        Personaje personajeActual = personajeSeleccionado;
         bool personajeSeleccionadoGanoTodas = true;  //Para el msj del ganador
         bool mensajeMostrado = false;    //Para que no vuelva a mostrar el msj

        while (personajes.Count > 1)
        {
            Personaje oponente = SeleccionarOponenteAleatorio(personajes, personajeActual);

            Console.WriteLine($"{personajeActual.Datos.Nombre} vs {oponente.Datos.Nombre}");
             Console.WriteLine("========================================================================================================");

            Thread.Sleep(2000);

            Personaje ganador= CombateEntrePersonajes(personajeActual, oponente);
            
            if (ganador != null)     
                {
                   
                    MejorarHabilidades(ganador);//Mejoras las habilidades del ganador
                }

            if (personajeActual.Caracteristicas.Salud <= 0)
            {
                Console.WriteLine($"{personajeActual.Datos.Nombre} ha sido derrotado. {oponente.Datos.Nombre} sigue luchando.");
                personajes.Remove(personajeActual);
                personajeActual = oponente;
                if (!mensajeMostrado && !personajeSeleccionado.Equals(ganador)) // Se actualiza el marcador solo si el personaje actual no es el seleccionado
            {
                Console.WriteLine($"{personajeSeleccionado.Datos.Nombre} PERDISTE EL JUEGO.");
                personajeSeleccionadoGanoTodas = false;
                mensajeMostrado=true;
            }

            }
            else
            {
                Console.WriteLine($"{oponente.Datos.Nombre} ha sido derrotado. {personajeActual.Datos.Nombre} sigue luchando.");
                personajes.Remove(oponente);
            }
            Console.WriteLine("\n========================================================================================================");
             Thread.Sleep(2000);

        }
   if (personajes.Count == 1)
    {
        Personaje ganador = personajes[0];
        MejorarHabilidades(ganador);
        Console.WriteLine($"{ganador.Datos.Nombre} es el ganador final del combate.");

        if (personajeSeleccionado.Equals(ganador) && personajeSeleccionadoGanoTodas)
        {
            Console.WriteLine("MUY BIEN GANASTE EL JUEGO");
        }

        return ganador;
    }

    return null;
}
    public void AjustarArmaduraPorClima(List<Personaje> personajes, string estadoClima)
{
    if (estadoClima == "desconocido")
    {
        // Si el clima es desconocido, no se realiza ningún ajuste
        return;
    }

    foreach (var personaje in personajes)
    {
        if (personaje.Datos.Tipo == "Heroe") 
        {
            // Si el clima está bueno, aumenta la armadura de los héroes, sin pasar de 10 puntos
            if (estadoClima == "bueno")
            {
                // Verificar si la armadura actual es menor de 10 
                if (personaje.Caracteristicas.Armadura < 10)
                {
                    personaje.Caracteristicas.Armadura += 2;
                    // Asegurarse de que la armadura no exceda 10
                    if (personaje.Caracteristicas.Armadura > 10)
                    {
                        personaje.Caracteristicas.Armadura = 10;
                    }
                }
            }
        }
        else if (personaje.Datos.Tipo == "Villano")
        {
            // Si el clima está malo, aumenta la armadura de los villanos de la misma forma que el heroe 
            if (estadoClima == "malo")
            {
                personaje.Caracteristicas.Armadura += 2;
            }

            if (personaje.Caracteristicas.Armadura > 10)
               {
                    personaje.Caracteristicas.Armadura = 10;
                }

        }
    }
    }

private Personaje CombateEntrePersonajes(Personaje personaje1, Personaje personaje2)
    {
        while (personaje1.Caracteristicas.Salud > 0 && personaje2.Caracteristicas.Salud > 0)
        {
            Atacar(personaje1, personaje2);
            Thread.Sleep(2000);

            if (personaje2.Caracteristicas.Salud <= 0)
            {
                return personaje1; //Gano personaej1
            }

            Atacar(personaje2, personaje1);
            Thread.Sleep(2000);
            if (personaje1.Caracteristicas.Salud <= 0)
            {
                return personaje2; //Gano personaje2
               
            }
        }
       return null;
    }

    private void Atacar(Personaje atacante, Personaje defensor)
    {
        int ataque = atacante.Caracteristicas.Destreza * atacante.Caracteristicas.Fuerza;
        int defensa = defensor.Caracteristicas.Armadura * defensor.Caracteristicas.Velocidad;
        int efectividad = random.Next(1, 101);

        if (atacante.Caracteristicas.Explosion > defensor.Caracteristicas.Explosion)
        {
            ataque = (int)(ataque * 1.1); //MEJORA EL ATAQUE DEL PERSONAJE QUE TENGA MAS EXPLOSION
        }

        int constante = 100; //CAMBIO DE CONSTANTE PARA AUMENTAR DAÑO
        int danio = ((ataque * efectividad) - defensa) / constante;

        if (danio < 0)
        {
            danio = 0;
        }

        if (atacante.Caracteristicas.Explosion > defensor.Caracteristicas.Explosion)
        {
            danio += random.Next(1, 10); // Daño adicional aleatorio POR TENER MAYOR EXPLOSION
        }

        if (danio>100)
        {
            danio=99;
        }
        defensor.Caracteristicas.Salud -= danio;

        if (defensor.Caracteristicas.Salud < 0)
        {
            defensor.Caracteristicas.Salud = 0; // Asegura que la salud no sea negativa
        }
        if (defensor.Caracteristicas.Explosion + 1 > 10)  
        {
            defensor.Caracteristicas.Explosion = 10;
        }
        else
        {
            defensor.Caracteristicas.Explosion += 1;  //Sube la explosion tras ser atacado
        }

        Console.WriteLine($"{atacante.Datos.Nombre} golpea a {defensor.Datos.Nombre} con una efectividad de {efectividad}%, causando {danio} de daño. Salud restante de {defensor.Datos.Nombre}: {defensor.Caracteristicas.Salud}");
    }

private Personaje SeleccionarOponenteAleatorio(List<Personaje> personajes, Personaje actual)
    {
        int indiceActual = personajes.IndexOf(actual);

        if (personajes.Count <= 1) // Control por las dudas 
        {
            Console.WriteLine("No hay suficientes personajes para seleccionar un oponente.");
        }

        int indiceOponente;
        do
        {
            indiceOponente = random.Next(personajes.Count);
        } while (indiceOponente == indiceActual);

        return personajes[indiceOponente];
    }

    private void MejorarHabilidades(Personaje personaje) //MEJORA LAS HABILIDADES ALEATORIAMENTE TRAS EL COMBATE
    {
        int saludMejora = random.Next(0, 21); 
        int destrezaMejora = random.Next(1, 3);

        personaje.Caracteristicas.Salud = Math.Min(personaje.Caracteristicas.Salud + saludMejora, 100); 
        personaje.Caracteristicas.Destreza = Math.Min(personaje.Caracteristicas.Destreza + destrezaMejora, 10);

        Console.WriteLine($"{personaje.Datos.Nombre} ha mejorado sus habilidades:");
        Console.WriteLine($"  - Salud: +{saludMejora} (total: {personaje.Caracteristicas.Salud})");
        Console.WriteLine($"  - Destreza: +{destrezaMejora} (total: {personaje.Caracteristicas.Destreza})");
    }
}
