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

    public void SeleccionarPersonaje(){
        string mensaje= "Seleccione uno de los personajes para pelear";
        Console.WriteLine(mensaje);

    }



    }

}