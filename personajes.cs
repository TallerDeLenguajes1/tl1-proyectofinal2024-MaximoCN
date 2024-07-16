
using System;
using System.Text.Json.Serialization;
namespace PersonajeEspacio; 
using Newtonsoft.Json;


public class Personajes
{
     public Caracteristicas Caracteristicas { get; set; }
    private Datos datos;
    public Datos Datos { get => datos; set => datos = value; }

    public Personajes(int velocidad,int destreza,int fuerza,int armadura,int explocion,int salud,string tipo,string nombre, string fechadeNacimiento,int edad, string apodo){
    
      Caracteristicas = new Caracteristicas(velocidad,destreza, fuerza, armadura, salud,explocion);
      Datos= new Datos(tipo,nombre,fechadeNacimiento,edad,apodo);
    }
    public Personajes()
    {
    }

}

public class Caracteristicas
{
     
      [JsonPropertyName("Destreza")]   private int destreza;  //1 a 5
      [JsonPropertyName("Fuerza")]  private int fuerza;     //1 a 10
      [JsonPropertyName("Armadura")]  private int armadura;   //1 a 10
      [JsonPropertyName("Salud")]  private int salud; //100
      [JsonPropertyName("Explocion")]  private int explocion; //1 a 10
      [JsonPropertyName("Velocidad")]  private int velocidad;   // 1 a 10

       
    public Caracteristicas(int velocidad, int destreza, int fuerza, int armadura,int explocion, int salud)
    {
        Velocidad = velocidad;
        Destreza = destreza;
        Fuerza = fuerza;
        Armadura = armadura;
        Salud = salud;
        Explocion= explocion;
        
    }
    public int Salud { get => salud; set => salud = value; }
    public int Fuerza { get => fuerza; set => fuerza = value; }
    public int Armadura { get => armadura; set => armadura = value; }
    public int Destreza { get => destreza; set => destreza = value; }
    public int Velocidad { get => velocidad; set => velocidad = value; }
    public int Explocion { get => explocion; set => explocion = value; }
}
  

public class Datos
{   
  [JsonPropertyName("Tipo")]  private string tipo;
   [JsonPropertyName("Nombre")] private string nombre;
   [JsonPropertyName("FechadeNacimiento")] private string fechadeNacimiento;
   [JsonPropertyName("Edad")] private int edad; //entre 0 a 300
  [JsonPropertyName("Apodo")]  private string? apodo;

    public Datos(string tipo, string nombre, string fechadeNacimiento, int edad, string? apodo)
    {
        this.Tipo = tipo;
        this.Nombre = nombre;
        this.fechadeNacimiento = fechadeNacimiento;
        this.Edad = edad;
        this.Apodo = apodo;
    }

    public string? Apodo { get => apodo; set => apodo = value; }
    public int Edad { get => edad; set => edad = value; }
    public string FechadeNacimiento { get => fechadeNacimiento; set => fechadeNacimiento = value; }
    public string Nombre { get => nombre; set => nombre = value; }
    public string Tipo { get => tipo; set => tipo = value; }
}



 public class FabricaDePersonajes
 {
     private List<Personajes> avengers;
    public FabricaDePersonajes()
    {
        avengers = crearAvengers();
    }
   public List<Personajes> crearAvengers()
   {
       Random CaracteristicasRamdom=new Random();

       List<Personajes> avengers = new List<Personajes>();

        avengers.Add(new Personajes(CaracteristicasRamdom.Next(1,10),CaracteristicasRamdom.Next(1,10),CaracteristicasRamdom.Next(1,10),CaracteristicasRamdom.Next(1,10),100,CaracteristicasRamdom.Next(1,10),"heroe", "Peter parker","10/08/2001",23,"Spiderman"));

        avengers.Add(new Personajes(CaracteristicasRamdom.Next(1,10),CaracteristicasRamdom.Next(1,10),CaracteristicasRamdom.Next(1,10),CaracteristicasRamdom.Next(1,10),100,CaracteristicasRamdom.Next(1,10), "Héroe", "Iron Man", "03/05/1970", 54, "Tony Stark"));

        avengers.Add(new Personajes(CaracteristicasRamdom.Next(1,10),CaracteristicasRamdom.Next(1,10),CaracteristicasRamdom.Next(1,10),CaracteristicasRamdom.Next(1,10),100,CaracteristicasRamdom.Next(1,10),"Héroe", "Capitan America", "04/07/1918", 106, "Cap"));

        avengers.Add(new Personajes(CaracteristicasRamdom.Next(1,10),CaracteristicasRamdom.Next(1,10),CaracteristicasRamdom.Next(1,10),CaracteristicasRamdom.Next(1,10),100,CaracteristicasRamdom.Next(1,10), "Heroe", "Thor", "12/04/desc", 300, "Dios del Trueno"));

        avengers.Add(new Personajes(CaracteristicasRamdom.Next(1,10),CaracteristicasRamdom.Next(1,10),CaracteristicasRamdom.Next(1,10),CaracteristicasRamdom.Next(1,10),100,CaracteristicasRamdom.Next(1,10), "Heroe", "Hulk", "30/12/1979", 43, "Bruce Banner"));

        avengers.Add(new Personajes(CaracteristicasRamdom.Next(1,10),CaracteristicasRamdom.Next(1,10),CaracteristicasRamdom.Next(1,10),CaracteristicasRamdom.Next(1,10),100,CaracteristicasRamdom.Next(1,10), "Villano", "Thanos", "01/01/desc", 300, "Thanos"));

        avengers.Add(new Personajes(CaracteristicasRamdom.Next(1,10),CaracteristicasRamdom.Next(1,10),CaracteristicasRamdom.Next(1,10),CaracteristicasRamdom.Next(1,10),100,CaracteristicasRamdom.Next(1,10),"Villano", "Loki", "01/01/desc", 300, "Loki"));

        avengers.Add(new Personajes(CaracteristicasRamdom.Next(1,10),CaracteristicasRamdom.Next(1,10),CaracteristicasRamdom.Next(1,10),CaracteristicasRamdom.Next(1,10),100,CaracteristicasRamdom.Next(1,10),"Villano", "Ultron", "01/01/desc", 5, "Ultron"));

        avengers.Add(new Personajes( CaracteristicasRamdom.Next(1,10),CaracteristicasRamdom.Next(1,10),CaracteristicasRamdom.Next(1,10),CaracteristicasRamdom.Next(1,10),100,CaracteristicasRamdom.Next(1,10),"heroe","Hawkeye","09/02/1969",45,"ojo de halcon"));

        avengers.Add(new Personajes(CaracteristicasRamdom.Next(1,10),CaracteristicasRamdom.Next(1,10),CaracteristicasRamdom.Next(1,10),CaracteristicasRamdom.Next(1,10),100,CaracteristicasRamdom.Next(1,10),"Villano","Hela","09/12/desc",5,"Hela"));
        return avengers;
   }
    public int SeleccionarPersonaje(int cantidadPersonajes, int Anterior = -1)
    {
        int seleccion;
        bool esValido;
        
        do
        {
            string elecc = Console.ReadLine();
            esValido = int.TryParse(elecc, out seleccion) && seleccion >= 0 && seleccion < cantidadPersonajes && seleccion != Anterior;

            if (!esValido)
            {
                Console.WriteLine("Entrada inválida. Por favor, ingresa un número entre 0 y {0} que no sea el mismo que el anterior.", cantidadPersonajes - 1);
            }

        } while (!esValido);

        return seleccion;
    }
 }



  
  

