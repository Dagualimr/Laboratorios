class Tablero
{
    public void MostrarTableros(string[,] propio, string[,] enemigo) // Esta clase muestra los tableros de ambos jugadores, el propio muestrta los barcos, mientras que el enemigo solo muestra los ataques que fueron realizados.
    {
        Console.WriteLine("Tablero Propio:");
        MostrarTableroPropio(propio);
        Console.WriteLine("\nTablero Enemigo:");
        MostrarTableroEnemigo(enemigo);
    }

    private void MostrarTableroPropio(string[,] tablero) // Mustra el tablero perteneciente al jugador actual, en este se podra ver la posicion de los barcos de ese jugador.
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("  1 2 3 4 5 6");
        for (int i = 0; i < tablero.GetLength(0); i++) // Si se encuntra el numero 2, 3 o 4 se colocara una B en la casilla.
        {
            Console.Write((char)('A' + i) + " ");
            for (int j = 0; j < tablero.GetLength(1); j++) 
            {
                if (tablero[i, j] == "2" || tablero[i, j] == "3" || tablero[i, j] == "4")
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("B ");
                }
                else if (tablero[i, j] == "X")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(tablero[i, j] + " ");
                }
                else if (tablero[i, j] == "O")
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(tablero[i, j] + " ");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write(tablero[i, j] + " ");
                }
            }
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine();
        }
    }

    private void MostrarTableroEnemigo(string[,] tablero) // Muestra el tablero enemigo, en el que se podra ver agua y los ataques previamente realizados.
    {
        Console.WriteLine("  1 2 3 4 5 6");
        for (int i = 0; i < tablero.GetLength(0); i++) // Evita que el jugador pueda ver los barcos del enemigo.
        {
            Console.Write((char)('A' + i) + " ");
            for (int j = 0; j < tablero.GetLength(1); j++)
            {
                if (tablero[i, j] == "X" || tablero[i, j] == "O")
                    Console.Write(tablero[i, j] + " ");
                else
                    Console.Write("~ ");
            }
            Console.WriteLine();
        }
    }
}