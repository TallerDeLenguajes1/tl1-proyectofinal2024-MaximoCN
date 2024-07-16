using jsonperso;
using PersonajeEspacio;
using mensajesJuego;
using PersonajeEspacio;
using CombatiendoEspacio;
string nombreArchivo = @"c:\Users\ROG BY NG\Desktop\TP09\tl1-proyectofinal2024-MaximoCN\json\personajes.json";

//instancias 
PersonajesJson personajesjson= new PersonajesJson();

FabricaDePersonajes fabricaDePersonajes= new FabricaDePersonajes();

List<Personajes> personajes = fabricaDePersonajes.crearAvengers();

 mensajeJuego mensaje = new mensajeJuego();

//llamo a el msj de bienvenida
 mensaje.MostrarMensajeBienvenida();
 mensaje.ReglasdeJuegos();
 mensaje.SeleccionarPersonaje();

personajesjson.GuardarPersonajes(personajes,nombreArchivo);
 // Verificar si el archivo existe y tiene datos
            if (personajesjson.Existe(nombreArchivo))
            {
                // Leer los personajes desde el archivo JSON
                List<Personajes> personajesLeidos = personajesjson.LeerPersonajes(nombreArchivo);
            }
            else
            {
                personajes = fabricaDePersonajes.crearAvengers();
                personajesjson.GuardarPersonajes(personajes, nombreArchivo);
                
            }
            //Mostrar  los datos guardados 
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
            Console.WriteLine($"  - Explosión: {personaje.Caracteristicas.Explocion}");
            Console.WriteLine($"  - Salud: {personaje.Caracteristicas.Salud}");
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine();
             contador++;
}  
      Console.WriteLine("Selecciona el primer personaje para el combate (0-9):");
        int seleccion1 = fabricaDePersonajes.SeleccionarPersonaje(10,-1);

        Console.WriteLine("Selecciona el segundo personaje para el combate (0-9):");
        int seleccion2 = fabricaDePersonajes.SeleccionarPersonaje(10,seleccion1);

        Personajes personaje1 = personajes[seleccion1];
        Personajes personaje2 = personajes[seleccion2];

         Combate combate = new Combate();
        combate.IniciarCombate(personaje1, personaje2);


                
            