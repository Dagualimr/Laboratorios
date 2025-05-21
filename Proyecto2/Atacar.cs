class Atacar : Tablero // Clase que registra los ataques de los jugadores.
{
    public int puntosJugador1 = 0;
    public int puntosJugador2 = 0;

    public bool AtacarBarco(char[,] tableroEnemigo, char[,] tableroAtaque, string nombreJugador) // Esta funcion se encarga de registrar los ataques de los jugadores, si el ataque es exitoso se le suman puntos al jugador.
    {
        Console.WriteLine($"{nombreJugador}, ingrese la coordenada para atacar (ejemplo: A1):");
        string input = Console.ReadLine()!.Trim().ToUpper(); // Se ingresa la coordenada.

        if (input.Length < 2 || input.Length > 3)
        {
            Console.WriteLine("Entrada inválida. Intente de nuevo.");
            return false;
        }

        char letraFila = input[0];
        int fila = letraFila - 'A';
        int columna;

        if (!int.TryParse(input.Substring(1), out columna) || fila < 0 || fila > 5 || columna < 1 || columna > 6) // Se verifica que la coordenaa sea valida
        {
            Console.WriteLine("Entrada inválida. Intente de nuevo.");
            return false;
        }
        columna -= 1;

        char celda = tableroEnemigo[fila, columna];
        char celdaAtaque = tableroAtaque[fila, columna];

        if (celdaAtaque == 'X' || celdaAtaque == 'O') // Verifica que no se haya atacdo a la misma coordenada.
        {
            Console.WriteLine("Ya atacaste aquí. Intenta otra coordenada.");
            return false;
        }

        if (celda == '4' || celda == '3' || celda == '2') // Verifica si el ataque dio en a un barco enemigo.
        {
            char tipoBarco = celda;
            tableroEnemigo[fila, columna] = 'X';
            tableroAtaque[fila, columna] = 'X';
            Console.WriteLine("¡Impacto!");

            bool hundido = true;
            for (int i = 0; i < tableroEnemigo.GetLength(0); i++) // Revisa que el barco haya sido hundido.
            {
                for (int j = 0; j < tableroEnemigo.GetLength(1); j++)
                {
                    if (tableroEnemigo[i, j] == tipoBarco)
                    {
                        hundido = false;
                        break;
                    }
                }
                if (!hundido) break;
            }

            if (hundido) // Se le suman los puntos al jugador, si el barco ha sido hundido.
            {
                int puntos = tipoBarco - '0';
                Console.WriteLine($"¡Barco de tamaño {puntos} hundido! {nombreJugador} gana {puntos} puntos.");
                if (nombreJugador.Contains("1"))
                    puntosJugador1 += puntos;
                else
                    puntosJugador2 += puntos;
            }
            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
            return true;
        }
        else // Registra la coordenada como O si el ataque no dio en un barco enemigo.
        {
            tableroEnemigo[fila, columna] = 'O';
            tableroAtaque[fila, columna] = 'O';
            Console.WriteLine("Agua.");
            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
            return true;
        }
    }
}