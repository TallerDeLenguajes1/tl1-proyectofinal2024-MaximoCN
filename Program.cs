using jsonp;
using Personajes;


string nombreArchivo = @"c:\Users\ROG BY NG\Desktop\TP09\tl1-proyectofinal2024-MaximoCN\json\personajes.json";
PersonajesJson personajesjson= new PersonajesJson();

FabricaDePersonajes fabricaDePersonajes= new FabricaDePersonajes();
List<Personaje> personajes = fabricaDePersonajes.crearAvengers();
 
personajesjson.GuardarPersonajes(personajes,nombreArchivo);
 // Verificar si el archivo existe y tiene datos
            if (personajesjson.Existe(nombreArchivo))
            {
                // Leer los personajes desde el archivo JSON
                List<Personaje> personajesLeidos = personajesjson.LeerPersonajes(nombreArchivo);

                // Mostrar los personajes leídos
                foreach (var personaje in personajesLeidos)
                {
                    Console.WriteLine($"Nombre: {personaje.Datos.Nombre1}, Alias: {personaje.Datos.Apodo}, Edad: {personaje.Datos.Edad1}, Tipo: {personaje.Datos.FechadeNacimiento}");
                }
            }
            else
            {
                Console.WriteLine("El archivo no existe o está vacío.");
            }

                
            