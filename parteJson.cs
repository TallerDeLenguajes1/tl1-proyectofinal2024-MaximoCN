namespace jsonp;
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
            Console.WriteLine("--Serializando--");
            string persoJson = JsonSerializer.Serialize(personaje);
            Console.WriteLine("Archivo Serializado : " + persoJson);
            Console.WriteLine("--Guardando--");
            miHelperdeArchivos.GuardarArchivoTexto(NombreArchivo, persoJson);

       }

      
      public List<Personajes> LeerPersonajes(string NombreArchivo)
       {
           Console.WriteLine("--Abriendo--");
            string jsonDocument = miHelperdeArchivos.AbrirArchivoTexto(NombreArchivo);
            Console.WriteLine("--Deserializando--");
            var listadopersonajes = JsonSerializer.Deserialize<List<Personajes>>(jsonDocument);
            Console.WriteLine("--Mostrando datos recuperardos--");
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
public class  HistorialJson{
    private HelperDeJson miHelperdeArchivos = new HelperDeJson();

   public void GuardarGanador (Personajes ganador, string informacion, string nombreArchivo)
        {
            List<Partida> historial = new List<Partida>();

            if (Existe(nombreArchivo))
            {
                historial = LeerGanadores(nombreArchivo);
            }

            historial.Add(new Partida { Ganador = ganador, Informacion = informacion });

            string historialJson = JsonSerializer.Serialize(historial);
            
            miHelperdeArchivos.GuardarArchivoTexto(nombreArchivo, historialJson);
        }
      public class Partida
          {
        public Personajes Ganador { get; set; }
        public string Informacion { get; set; }
    
         }
        public List<Partida> LeerGanadores(string nombreArchivo)
        {
            if (!Existe(nombreArchivo))
            {
                return new List<Partida>();
            }

            string jsonDocument = miHelperdeArchivos.AbrirArchivoTexto(nombreArchivo);
            var historial = JsonSerializer.Deserialize<List<Partida>>(jsonDocument);

            return historial;
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
        
}