namespace mensajesJuego
{
    public class mensajeJuego
    {
        public void MostrarMensajeBienvenida()
        {
                string arteAscii = @"
██████╗░██╗███████╗███╗░░██╗██╗░░░██╗███████╗███╗░░██╗██╗██████╗░░█████╗░  ░█████╗░
██╔══██╗██║██╔════╝████╗░██║██║░░░██║██╔════╝████╗░██║██║██╔══██╗██╔══██╗  ██╔══██╗
██████╦╝██║█████╗░░██╔██╗██║╚██╗░██╔╝█████╗░░██╔██╗██║██║██║░░██║██║░░██║  ███████║
██╔══██╗██║██╔══╝░░██║╚████║░╚████╔╝░██╔══╝░░██║╚████║██║██║░░██║██║░░██║  ██╔══██║
██████╦╝██║███████╗██║░╚███║░░╚██╔╝░░███████╗██║░╚███║██║██████╔╝╚█████╔╝  ██║░░██║
╚═════╝░╚═╝╚══════╝╚═╝░░╚══╝░░░╚═╝░░░╚══════╝╚═╝░░╚══╝╚═╝╚═════╝░░╚════╝░  ╚═╝░░╚═╝

░█████╗░██╗░░░██╗███████╗███╗░░██╗░██████╗░███████╗██████╗░░██████╗  ░██████╗░░█████╗░███╗░░░██╗███████╗██╗
██╔══██╗██║░░░██║██╔════╝████╗░██║██╔════╝░██╔════╝██╔══██╗██╔════╝  ██╔════╝░██╔══██╗████╗░████║██╔════╝██║
███████║╚██╗░██╔╝█████╗░░██╔██╗██║██║░░██╗░█████╗░░██████╔╝╚█████╗░  ██║░░██╗░███████║██╔████╔██║█████╗░░██║
██╔══██║░╚████╔╝░██╔══╝░░██║╚████║██║░░╚██╗██╔══╝░░██╔══██╗░╚═══██╗  ██║░░╚██╗██╔══██║██║╚██╔╝██║██╔══╝░░╚═╝
██║░░██║░░╚██╔╝░░███████╗██║░╚███║╚██████╔╝███████╗██║░░██║██████╔╝  ╚██████╔╝██║░░██║██║░╚═╝░██║███████╗██╗
╚═╝░░╚═╝░░░╚═╝░░░╚══════╝╚═╝░░╚══╝░╚═════╝░╚══════╝╚═╝░░╚═╝╚═════╝░  ░╚═════╝░╚═╝░░╚═╝╚═╝░░░░░╚═╝╚══════╝╚═╝
";
            Console.WriteLine(arteAscii);
        }
        public void ReglasdeJuegos()
        {
            string mensaje="El juego se basa en elegir a tu Jugador y su Openente sin poder elegir el mismo Personaje para que compitan, iniciara la pelea el personaje que elijas y luego tu openente te atacara, y asi sucesivamente,cada vez que tu o tu oponente reciban un ataque su caracteristica Explocion aumentara un punto de manera progresiva hasta llegar a 10 esta caracteristica(Explocion), aumenta tu ataque un 10%,perdera la pelea el jugador que quede sin vida, mientras que el personaje Ganador tendra un aumento de sus habilidades(Caracteristicas) aleatoriamente. ";
            Console.WriteLine(mensaje);
        }

    public void SeleccionarPersonaje(){
        string mensaje= "Seleccione uno de los personajes para pelear";
        Console.WriteLine(mensaje);

    }



    }

}