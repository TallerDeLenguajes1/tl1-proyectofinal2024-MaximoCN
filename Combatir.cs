namespace CombatiendoEspacio;
using PersonajeEspacio;


public class Combate
{
    private Random random = new Random();

    public void IniciarCombate(Personajes personaje1, Personajes personaje2)
    {
        //supuesta presentacion
        Console.WriteLine($"{personaje1.Datos.Nombre} vs {personaje2.Datos.Nombre}");

        while (personaje1.Caracteristicas.Salud > 0 && personaje2.Caracteristicas.Salud > 0)
        {
            // ataca pj1
            Atacar(personaje1, personaje2);

            if (personaje2.Caracteristicas.Salud <= 0)
            {
                Console.WriteLine($"{personaje2.Datos.Nombre} ha sido derrotado.");
                MejorarHabilidades(personaje1);
                break;
            }
            // ataque pj2
            Atacar(personaje2, personaje1);

            if (personaje1.Caracteristicas.Salud <= 0)
            {
                Console.WriteLine($"{personaje1.Datos.Nombre} ha sido derrotado.");
                MejorarHabilidades(personaje2);
                break;
            }
        }
    }

    private void Atacar(Personajes atacante, Personajes defensor)
    {
        int ataque = atacante.Caracteristicas.Destreza * atacante.Caracteristicas.Fuerza;

        int defensa = defensor.Caracteristicas.Armadura* defensor.Caracteristicas.Velocidad;

        int efectividad = random.Next(1, 101);

        int constante=100;    //cambio de constante para dar mas daño y ser una batalla mas dinamica

        int daño = ((ataque * efectividad)- defensa)/constante; 

        if (daño < 0) daño = 0;

        defensor.Caracteristicas.Salud = defensor.Caracteristicas.Salud-daño;

        Console.WriteLine($"{atacante.Datos.Nombre} ataca a {defensor.Datos.Nombre} con una efectividad de {efectividad}%, causando {daño} de daño. Salud restante de {defensor.Datos.Nombre}: {defensor.Caracteristicas.Salud}");
    }

    
       private void MejorarHabilidades(Personajes ganador)
    {
        int incrementoSalud = random.Next(1, 41); // Aleatorio entre 1 y 40

        int incrementoArmadura = random.Next(1, 4); // Aleatorio entre 1 y 3

        // salud no mas de 100
        ganador.Caracteristicas.Salud += incrementoSalud;
        if (ganador.Caracteristicas.Salud > 100)
        {
            ganador.Caracteristicas.Salud = 100;
        }
        // no pase de diez el incremento 
        ganador.Caracteristicas.Armadura += incrementoArmadura;

        if (ganador.Caracteristicas.Armadura > 10)
        {
            ganador.Caracteristicas.Armadura = 10;
        }

        Console.WriteLine($"{ganador.Datos.Nombre} ha ganado el combate y mejora sus habilidades: +{incrementoSalud} Salud (máximo 100), +{incrementoArmadura} Armadura (máximo 10).");
    }
    }
