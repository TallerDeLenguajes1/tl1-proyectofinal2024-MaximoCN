namespace jsonperso;
using System.Text.Json;
using PersonajeEspacio;      
using System.IO;
using System;
using TrabajandoJson;

public class PersonajesJson{
    const string NombreArchivo = "personajes.json";
     private HelperDeJson miHelperdeArchivos = new HelperDeJson();


       public void GuardarPersonajes(List<Personajes> personaje,string NombreArchivo )
       {
           // Console.WriteLine("--Serializando--");
            string persoJson = JsonSerializer.Serialize(personaje);
           // Console.WriteLine("Archivo Serializado : " + persoJson);
            //Console.WriteLine("--Guardando--");
            miHelperdeArchivos.GuardarArchivoTexto(NombreArchivo, persoJson);

       }

      
      public List<Personajes> LeerPersonajes(string NombreArchivo)
       {
          // Console.WriteLine("--Abriendo--");
            string jsonDocument = miHelperdeArchivos.AbrirArchivoTexto(NombreArchivo);
            //Console.WriteLine("--Deserializando--");
            var listadopersonajes = JsonSerializer.Deserialize<List<Personajes>>(jsonDocument);
            //Console.WriteLine("--Mostrando datos recuperardos--");
            return listadopersonajes;
       }


      public bool Existe(string nombreArchivo)
        {
            if (File.Exists(nombreArchivo))
            {
                // Verificar si el archivo tiene datos
                string ContenidoArchivo = File.ReadAllText(nombreArchivo);
                return !string.IsNullOrEmpty(ContenidoArchivo);
            }
            return false; // El archivo no existe o está vacío
        }

   
}
public class HistorialJson
{
    private HelperDeJson miHelperdeArchivos = new HelperDeJson();

    public void GuardarGanador(Personajes ganador, string informacion, string nombreArchivo)
{
    List<Partida> historial = LeerGanadores(nombreArchivo);

    var nuevaPartida = new Partida
    {
        Ganador = ganador,
        Informacion = informacion
    };

    historial.Add(nuevaPartida);

    string jsonString = JsonSerializer.Serialize(historial, new JsonSerializerOptions { WriteIndented = true });
    miHelperdeArchivos.GuardarArchivoTexto(nombreArchivo, jsonString);
}

    public List<Partida> LeerGanadores(string nombreArchivo)
    {
        if (!Existe(nombreArchivo))
        {
            return new List<Partida>();
        }

        string jsonDocument = miHelperdeArchivos.AbrirArchivoTexto(nombreArchivo);

        try
        {
            // Intenta deserializar el json en una lista de Partida
            var historial = JsonSerializer.Deserialize<List<Partida>>(jsonDocument);
            return historial ?? new List<Partida>();
        }
        catch (JsonException ex)
        {
            // Manejar errores de deserialización y devolver una lista vacía
            Console.WriteLine($"Error al deserializar el archivo JSON: {ex.Message}");
            return new List<Partida>();
        }
    }

    public bool Existe(string nombreArchivo)
    {
        if (File.Exists(nombreArchivo))
        {
            string ContenidoArchivo = File.ReadAllText(nombreArchivo);
            return !string.IsNullOrEmpty(ContenidoArchivo);
        }

        return false;
    }

    public class Partida
    {
        public Personajes Ganador { get; set; }
        public string Informacion { get; set; }
    }
}


