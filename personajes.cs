
using System;
namespace Personajes; 
public class Personaje
{
     public Caracteristicas Caracteristicas { get; set; }

    private Datos datos;
    public Datos Datos { get => datos; set => datos = value; }

#pragma warning disable CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declararlo como que admite un valor NULL.
    public Personaje(int velocidad,int destreza,int fuerza,int armadura,int salud,string tipo,string nombre, string fechadeNacimiento,int edad, string apodo){
    
      Caracteristicas = new Caracteristicas(velocidad,destreza, fuerza, armadura, salud);
      Datos= new Datos(tipo,nombre,fechadeNacimiento,edad,apodo);
    }
#pragma warning restore CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declararlo como que admite un valor NULL.
}

public class Caracteristicas
{
        private int velocidad;   // 1 a 10
         private int destreza;  //1 a 5
        private int fuerza;     //1 a 10
        private int armadura;   //1 a 10
        private int salud; //100

    public Caracteristicas(int velocidad, int destreza, int fuerza, int armadura, int salud)
    {
        this.velocidad = velocidad;
        this.destreza = destreza;
        this.fuerza = fuerza;
        this.armadura = armadura;
        this.salud = salud;
    }
    public int Salud { get => salud; set => salud = value; }
    public int Fuerza { get => Fuerza1; set => Fuerza1 = value; }
    public int Armadura { get => armadura; set => armadura = value; }
    public int Fuerza1 { get => fuerza; set => fuerza = value; }
    public int Destreza { get => destreza; set => destreza = value; }
    public int Velocidad { get => velocidad; set => velocidad = value; }
}


public class Datos
{   
    private string Tipo;
    private string Nombre;
    private string fechadeNacimiento;
    private int Edad; //entre 0 a 300
    private string? apodo;

    public Datos(string tipo, string nombre, string fechadeNacimiento, int edad, string? apodo)
    {
        Tipo = tipo;
        Nombre = nombre;
        this.fechadeNacimiento = fechadeNacimiento;
        Edad = edad;
        this.apodo = apodo;
    }

    public string? Apodo { get => apodo; set => apodo = value; }
    public int Edad1 { get => Edad; set => Edad = value; }
    public string FechadeNacimiento { get => fechadeNacimiento; set => fechadeNacimiento = value; }
    public string Nombre1 { get => Nombre; set => Nombre = value; }
    public string Tipo1 { get => Tipo; set => Tipo = value; }
}



 public class FabricaDePersonajes
 {
   public List<Personaje> crearAvengers()
   {
       List<Personaje> avengers = new List<Personaje>();

        avengers.Add(new Personaje(10,7,4,4,100,"heroe", "Peter parker","10/08/2001",23,"Spiderman"));

        avengers.Add(new Personaje(10, 5, 6, 10, 100, "Héroe", "Iron Man", "03/05/1970", 54, "Tony Stark"));

        avengers.Add(new Personaje(8, 4, 8, 7, 100, "Héroe", "Capitán América", "04/07/1918", 106, "Cap"));

        avengers.Add(new Personaje(9, 6, 8, 8, 100, "Héroe", "Thor", "12/04/desc", 300, "Dios del Trueno"));

        avengers.Add(new Personaje(7, 3, 7, 6, 100, "Héroe", "Hulk", "30/12/1979", 43, "Bruce Banner"));

        avengers.Add(new Personaje(9, 9, 10, 8, 100, "Villano", "Thanos", "01/01/desc", 300, "Thanos"));

        avengers.Add(new Personaje(7, 8, 9, 7, 100, "Villano", "Loki", "01/01/desc", 300, "Loki"));

        avengers.Add(new Personaje(6, 5, 7, 6, 100, "Villano", "Ultron", "01/01/desc", 5, "Ultron"));
        
        return avengers;
   }
    

 }



  
  

