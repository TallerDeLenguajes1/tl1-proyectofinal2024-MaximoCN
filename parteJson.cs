
using System.Text.Json;
using Personajes;      
using System.IO;

public class PersonajesJson{
    
       public void GuardarPersonajes(List<Personaje> personaje,string NombreArchivo )
       {
             string PersonajeString = JsonSerializer.Serialize(personaje);
             string ruta = @"\\Users\Alumno\Desktop\intento}\tl1-proyectofinal2024-MaximoCN\";
             File.WriteAllText(Path.Combine(ruta, NombreArchivo), PersonajeString);


       }

      
      public List<Personaje> LeerPersonajes(string TextPer)
       {
          List<Personaje> personajes = new List<Personaje>();

           string mitexto = File.ReadAllText(TextPer);

           personajes = JsonSerializer.Deserialize<List<Personaje>>(mitexto);

           return personajes;
       }

}
 
