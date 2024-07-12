using jsonp;
using PersonajeEspacio;


string nombreArchivo = @"c:\Users\ROG BY NG\Desktop\TP09\tl1-proyectofinal2024-MaximoCN\json\personajes.json";
PersonajesJson personajesjson= new PersonajesJson();
FabricaDePersonajes fabricaDePersonajes= new FabricaDePersonajes();
List<Personajes> personajes = fabricaDePersonajes.crearAvengers();
personajesjson.GuardarPersonajes(personajes,nombreArchivo);
 // Verificar si el archivo existe y tiene datos
            if (personajesjson.Existe(nombreArchivo))
            {
                // Leer los personajes desde el archivo JSON
                List<Personajes> personajesLeidos = personajesjson.LeerPersonajes(nombreArchivo);

                // Mostrar los personajes leídos
                foreach (var personaje in personajesLeidos)
                {
                    Console.WriteLine($"Nombre: {personaje.Datos.Nombre1}, Alias: {personaje.Datos.Apodo}, Edad: {personaje.Datos.Edad1}, Fecha de Nacimiento: {personaje.Datos.FechadeNacimiento}, Tipo: {personaje.Datos.Tipo1}");
                    Console.WriteLine($"  Velocidad: {personaje.Caracteristicas.Velocidad}, Destreza: {personaje.Caracteristicas.Destreza}, Fuerza: {personaje.Caracteristicas.Fuerza}, Armadura: {personaje.Caracteristicas.Armadura}, Explocion: {personaje.Caracteristicas.Explocion}, Salud: {personaje.Caracteristicas.Salud}");
                }
            }
            else
            {
               personajes = fabricaDePersonajes.crearAvengers();
                personajesjson.GuardarPersonajes(personajes, nombreArchivo);
                
            }

            //Mostrar  los datos guardados 
            
             foreach (var personaje in personajes)
            {
                Console.WriteLine($"Nombre: {personaje.Datos.Nombre1}, Alias: {personaje.Datos.Apodo}, Edad: {personaje.Datos.Edad1}, Fecha de Nacimiento: {personaje.Datos.FechadeNacimiento}, Tipo: {personaje.Datos.Tipo1}");
                Console.WriteLine($"  Velocidad: {personaje.Caracteristicas.Velocidad}, Destreza: {personaje.Caracteristicas.Destreza}, Fuerza: {personaje.Caracteristicas.Fuerza}, Armadura: {personaje.Caracteristicas.Armadura}, Explocion: {personaje.Caracteristicas.Explocion}, Salud: {personaje.Caracteristicas.Salud}");
            }
            

                
            