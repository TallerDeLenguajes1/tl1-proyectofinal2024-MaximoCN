namespace jsonp;
using System.Text.Json;
using Personajes;      
using System.IO;
using System;
using TrabajandoJson;

public class PersonajesJson{
    const string NombreArchivo = "personajes.json";
     private HelperDeJson miHelperdeArchivos = new HelperDeJson();


       public void GuardarPersonajes(List<Personaje> personaje,string NombreArchivo )
       {
            Console.WriteLine("--Serializando--");
            string persoJson = JsonSerializer.Serialize(personaje);
            Console.WriteLine("Archivo Serializado : " + persoJson);
            Console.WriteLine("--Guardando--");
            miHelperdeArchivos.GuardarArchivoTexto(NombreArchivo, persoJson);

       }

      
      public List<Personaje> LeerPersonajes(string NombreArchivo)
       {
           Console.WriteLine("--Abriendo--");
            string jsonDocument = miHelperdeArchivos.AbrirArchivoTexto(NombreArchivo);
            Console.WriteLine("--Deserializando--");
            var listadopersonaje = JsonSerializer.Deserialize<List<Personaje>>(jsonDocument);
            Console.WriteLine("--Mostrando datos recuperardos--");
            return listadopersonaje;
       }


      public bool Existe(string nombreArchivo)
        {
            if (File.Exists(nombreArchivo))
            {
                // Verificar si el archivo tiene datos
                string fileContent = File.ReadAllText(nombreArchivo);
                return !string.IsNullOrEmpty(fileContent);
            }
            return false; // El archivo no existe o está vacío
        }

   
}

public class  HistorialJson{
    
}


 
