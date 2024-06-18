namespace jsonp;
using System.Text.Json;
using Personajes;      
using System.IO;
using System;

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


      public bool Existe(string NombreArchivo)
    {
        string ruta = @"C:\Users\Alumno\Desktop\intento\tl1-proyectofinal2024-MaximoCN\"; // Ruta corregida
        string archivo = Path.Combine(ruta, NombreArchivo);

        if (File.Exists(archivo))
        {
            // Verificar si el archivo tiene datos
            string fileContent = File.ReadAllText(archivo);
            return !string.IsNullOrEmpty(fileContent);
        }

        return false; // El archivo no existe
    }

    internal void GuardarPersonajes(FabricaDePersonajes lista, string v)
    {
        throw new NotImplementedException();
    }
}


 
