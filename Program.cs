using jsonp;
using Personajes;

PersonajesJson personajesJson = new PersonajesJson();
FabricaDePersonajes lista= new FabricaDePersonajes();

personajesJson.GuardarPersonajes(lista, "Personajes.json");
List<Personaje> leidos = personajesJson.LeerPersonajes("Personaje.json");
 Console.WriteLine("Personajes leídos del archivo:");
            foreach (var personaje in leidos)
            {
                Console.WriteLine($"Nombre: {personaje.Datos.Nombre1}, Edad: {personaje.Datos.Edad1}");
            }


