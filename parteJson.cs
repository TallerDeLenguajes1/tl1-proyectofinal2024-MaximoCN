namespace jsonperso;
using System.Text.Json;
using PersonajeEspacio;      
using System.IO;
using System;
using TrabajandoJson;

public class PersonajesJson{
    const string NombreArchivo = "personajes.json";
     private HelperDeJson miHelperdeArchivos = new HelperDeJson();

       public void GuardarPersonajes(List<Personaje> personaje,string NombreArchivo )
       {
           // Console.WriteLine("--Serializando--");
            string persoJson = JsonSerializer.Serialize(personaje);
           // Console.WriteLine("Archivo Serializado : " + persoJson);
            //Console.WriteLine("--Guardando--");
            miHelperdeArchivos.GuardarArchivoTexto(NombreArchivo, persoJson);

       }

      
      public List<Personaje> LeerPersonajes(string NombreArchivo)
       {
          // Console.WriteLine("--Abriendo--");
            string jsonDocument = miHelperdeArchivos.AbrirArchivoTexto(NombreArchivo);
            //Console.WriteLine("--Deserializando--");
            var listadopersonajes = JsonSerializer.Deserialize<List<Personaje>>(jsonDocument);
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
            return false; // El archivo no existe o esta vacio
        }

   
}

public class HistorialJson  // HistorialJson maneja la serialización y deserialización de partidas JSON.
{
    private HelperDeJson miHelperdeArchivos = new HelperDeJson();

    public void GuardarGanador(Personaje ganador, string informacion, string nombreArchivo) // Guarda la info de una partida ganada en el archivo JSON .
{
    List<Partida> historial = LeerGanadores(nombreArchivo); // Lee el historial de partidas del archivo JSON.

    var nuevaPartida = new Partida  // Crea un nuevo registro de partida con el ganador y la información.
    {
        Ganador = ganador,
        Informacion = informacion
    };

    historial.Add(nuevaPartida); // Agrega la nueva partida al historial.

    string jsonString = JsonSerializer.Serialize(historial, new JsonSerializerOptions { WriteIndented = true });
    miHelperdeArchivos.GuardarArchivoTexto(nombreArchivo, jsonString); // Serializa la lista actualizada de partidas en una cadena JSON y guarda el archivo.
}

    public List<Partida> LeerGanadores(string nombreArchivo) // Lee el historial de partidas desde el archivo JSON y lo deserializa en una lista de objetos Partida.
    {
        if (!Existe(nombreArchivo))
        {
            return new List<Partida>(); // Devuelve una lista vacía si el archivo no existe.
        }

        string jsonDocument = miHelperdeArchivos.AbrirArchivoTexto(nombreArchivo); // Lee el contenido del archivo JSON.

        try
        {
            // Intenta deserializar el  en una lista de Partida
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

    public bool Existe(string nombreArchivo) // Verifica si el archivo especificado existe y tiene contenido.
    {
        if (File.Exists(nombreArchivo))
        {
            string ContenidoArchivo = File.ReadAllText(nombreArchivo);
            return !string.IsNullOrEmpty(ContenidoArchivo);
        }

        return false;
    }

    public class Partida    //representa una partida, con información del ganador.
    {
        public Personaje Ganador { get; set; }
        public string Informacion { get; set; }
    }
}


