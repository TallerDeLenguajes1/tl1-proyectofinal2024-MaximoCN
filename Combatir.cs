namespace CombatiendoEspacio;
using PersonajeEspacio;
using System;
 public class Combate
{
     private Random random = new Random();

    public void IniciarCombate(Personajes personajeSeleccionado, List<Personajes> personajes)
      {
          if (personajes == null || personajes.Count < 2)
       {
          Console.WriteLine("No hay suficientes personajes para iniciar el combate.");
          return;
       }

    Personajes personajeActual = personajeSeleccionado;

    while (personajes.Count > 1)
     {
        Personajes oponente = SeleccionarOponenteAleatorio(personajes, personajeActual);

        Console.WriteLine($"{personajeActual.Datos.Nombre} vs {oponente.Datos.Nombre}");
         CombateEntrePersonajes(personajeActual, oponente);

        if (personajeActual.Caracteristicas.Salud <= 0)
           {
            if (personajeActual == personajeSeleccionado)
                {
                  Console.WriteLine("Tu personaje ha sido derrotado. Has perdido.");
                  break;
                }

                   Console.WriteLine($"{personajeActual.Datos.Nombre} ha sido derrotado. {oponente.Datos.Nombre} sigue luchando.");
                   personajes.Remove(personajeActual);
                    personajeActual = oponente;
           }
            else
               {
                 Console.WriteLine($"{oponente.Datos.Nombre} ha sido derrotado. {personajeActual.Datos.Nombre} sigue luchando.");
                personajes.Remove(oponente);
               }
        }

            if (personajeSeleccionado.Caracteristicas.Salud > 0)
            {
                MejorarHabilidades(personajeSeleccionado);
                Console.WriteLine($"{personajeSeleccionado.Datos.Nombre} es el ganador final del combate.");
            }
      }

 private void CombateEntrePersonajes(Personajes personaje1, Personajes personaje2)
     {
         while (personaje1.Caracteristicas.Salud > 0 && personaje2.Caracteristicas.Salud > 0)
         {
              Atacar(personaje1, personaje2);

            if (personaje2.Caracteristicas.Salud <= 0)
            {
                 break;
            }

            Atacar(personaje2, personaje1);

            if (personaje1.Caracteristicas.Salud <= 0)
            {
                break;
            }
            
            }
        }

 private void Atacar(Personajes atacante, Personajes defensor)
        {
            int ataque = atacante.Caracteristicas.Destreza * atacante.Caracteristicas.Fuerza;
            int defensa = defensor.Caracteristicas.Armadura * defensor.Caracteristicas.Velocidad;
            int efectividad = random.Next(1, 101);

            if (atacante.Caracteristicas.Explocion > defensor.Caracteristicas.Explocion)
            {
                ataque = (int)(ataque * 1.1); //MEJORA EL ATAQUE DEL PERSONAJE QUE TENGA MAS EXPLOCION
            }

            int constante = 20; //CAMBIO DE CONSTANTE PARA AUMENTAR DAÑO
            int daño = ((ataque * efectividad) - defensa) / constante;

            if (daño < 0)
            {
                daño = 0;
            }

            if (atacante.Caracteristicas.Explocion > defensor.Caracteristicas.Explocion)
            {
                daño += random.Next(1, 10); // Daño adicional aleatorio POR TENER MAYOR EXPLOCION
            }

            defensor.Caracteristicas.Salud -= daño;
            if (defensor.Caracteristicas.Explocion + 1 > 10)
            {
              defensor.Caracteristicas.Explocion = 10;
            }
            else
            {
               defensor.Caracteristicas.Explocion += 1;
}

            Console.WriteLine($"{atacante.Datos.Nombre} golpea a {defensor.Datos.Nombre} con una efectividad de {efectividad}%, causando {daño} de daño. Salud restante de {defensor.Datos.Nombre}: {defensor.Caracteristicas.Salud}");
        }

 private Personajes SeleccionarOponenteAleatorio(List<Personajes> personajes, Personajes actual)
    {
        int indiceActual = personajes.IndexOf(actual);

         if (personajes.Count <= 1)
        {
         throw new InvalidOperationException("No hay suficientes personajes para seleccionar un oponente.");
         }

        int indiceOponente;
          do
           {
              indiceOponente = random.Next(personajes.Count);
         } while (indiceOponente == indiceActual);

         return personajes[indiceOponente];
     }

  private void MejorarHabilidades(Personajes personaje)
        {
            int saludMejora = random.Next(0, 41);
            int destrezaMejora = random.Next(1, 4);

            personaje.Caracteristicas.Salud = Math.Min(personaje.Caracteristicas.Salud + saludMejora, 100);
            personaje.Caracteristicas.Destreza = Math.Min(personaje.Caracteristicas.Destreza + destrezaMejora, 10);

            Console.WriteLine($"{personaje.Datos.Nombre} ha mejorado sus habilidades:");
            Console.WriteLine($"  - Salud: +{saludMejora} (total: {personaje.Caracteristicas.Salud})");
            Console.WriteLine($"  - Destreza: +{destrezaMejora} (total: {personaje.Caracteristicas.Destreza})");
        }
    }
