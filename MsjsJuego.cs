namespace mensajesJuego
{
    public class mensajeJuego
    {
        public void MostrarMensajeBienvenida()
        {
            string mensaje = "¡Bienvenido a Avengers Game!\n\n" +
                             "¿Estás listo para entrar en la arena y luchar por la victoria? En este épico juego de rol de ataque, tienes la oportunidad de elegir uno de los 10 poderosos personajes y enfrentarte a los demás en intensos combates. " +
                             "Demuestra tus habilidades, domina tus estrategias y vence a tus oponentes para convertirte en el campeón definitivo.\n\n" +
                             "¿Tienes lo que se necesita para ser el último en pie? ¡Elige tu personaje y comienza tu aventura ahora!\n\n" +
                             "¡Que comience la batalla en Avengers Game!";
            Console.WriteLine(mensaje);
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