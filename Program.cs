using jsonperso;
using PersonajeEspacio;
using mensajesJuego;
using PersonajeEspacio;
using CombatiendoEspacio;
using ApiC;
using System.ComponentModel.Design.Serialization;


string nombreArchivo = @"json\personajes.json";

//instancias 
PersonajesJson personajesjson= new PersonajesJson();

FabricaDePersonajes fabricaDePersonajes= new FabricaDePersonajes();

List<Personajes> personajes = fabricaDePersonajes.crearAvengers();


 mensajeJuego mensaje = new mensajeJuego();

//llamo a el msj de bienvenida
 mensaje.MostrarMensajeBienvenida();
 Console.WriteLine("PRESIONE CUALQUIER TECLA PARA AVANZAR");
 Console.ReadKey();
 mensaje.ReglasdeJuegos();
 mensaje.SeleccionarPersonaje();
personajesjson.GuardarPersonajes(personajes,nombreArchivo);
Root clima= await ClimaApi.ObtenerClima();
Console.WriteLine($"clima{clima.current.condition.text}");

  while (true)
  {
 // Verificar si el archivo existe y tiene datos
      if (personajesjson.Existe(nombreArchivo))
          {
               // Leer los personajes desde el archivo JSON
               personajes = personajesjson.LeerPersonajes(nombreArchivo);
          }
            else //si no,tiene guardo los psj y muestro personajes del Json
            {
                 personajes = fabricaDePersonajes.crearAvengers();
                 personajesjson.GuardarPersonajes(personajes, nombreArchivo);
                
            }
   //Mostrar  los datos guardados 
  Console.ReadKey();
  Console.Clear();
  Console.WriteLine("LOS PERSONAJES SON:");
  
  int contador = 1;
    
  foreach (var personaje in personajes)
        {
            Console.WriteLine($"Personaje {contador}:");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine($"Nombre: {personaje.Datos.Nombre}");
            Console.WriteLine($"Alias: {personaje.Datos.Apodo}");
            Console.WriteLine($"Edad: {personaje.Datos.Edad}");
            Console.WriteLine($"Fecha de Nacimiento: {personaje.Datos.FechadeNacimiento}");
            Console.WriteLine($"Tipo: {personaje.Datos.Tipo}");
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine($"Características:");
            Console.WriteLine($"  - Velocidad: {personaje.Caracteristicas.Velocidad}");
            Console.WriteLine($"  - Destreza: {personaje.Caracteristicas.Destreza}");
            Console.WriteLine($"  - Fuerza: {personaje.Caracteristicas.Fuerza}");
            Console.WriteLine($"  - Armadura: {personaje.Caracteristicas.Armadura}");
            Console.WriteLine($"  - Explosión: {personaje.Caracteristicas.Explosion}");
            Console.WriteLine($"  - Salud: {personaje.Caracteristicas.Salud}");
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine();
             contador++;
             Console.ReadKey();

        }
        // Inicio de combate
 Console.WriteLine("Selecciona el primer personaje para el combate (1-10):");

 int seleccion1 = fabricaDePersonajes.SeleccionarPersonaje(10, -1);

Personajes personajeSeleccionado = personajes[seleccion1];

Console.WriteLine($"Seleccionaste a {personajeSeleccionado.Datos.Nombre}");

//instancia Combate
Combate combate = new Combate();

HistorialJson historialJson = new HistorialJson();

string nombreAHistorial = @"json\historial.json";

// Inicia el combate
Personajes ganador = combate.IniciarCombate(personajeSeleccionado, personajes);

if (ganador != null)
{
    string informacionFinal = $"{ganador.Datos.Nombre} ES EL GANADOR DE TODOS LOS COMBATE Y OBTUVO EL TRONO.";
    historialJson.GuardarGanador(ganador, informacionFinal, nombreAHistorial);
}
else
{
    Console.WriteLine("No hay un ganador claro en el combate.");

} 



// Preguntar si se quiere volver a jugar
    Console.WriteLine("¿Quieres volver a jugar? (1 para sí, 0 para salir):");
    string entrada = Console.ReadLine();

    if (int.TryParse(entrada, out int decision))
    {
        if (decision == 0)
        {
            break; // Salir del bucle y finalizar el programa
        }
        else if (decision == 1)
        {
            // Volver a jugar, el bucle continuará y recargará los personajes
            continue;
        }
        else
        {
            Console.WriteLine("Entrada inválida. Por favor, ingresa 1 para sí o 0 para salir.");
        }
    }
    else
    {
        Console.WriteLine("Entrada no válida. Por favor, ingresa un número válido.");
    }

 }


            
