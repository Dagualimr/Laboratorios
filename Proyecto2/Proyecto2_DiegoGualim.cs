class CrearUsuario // Clase para asignar nombre al jugador
{
    public string Nombre { get; set; }
    public CrearUsuario(string nombre)
    {
        Nombre = nombre;
    }
}

class RandomizarPosicion // Elige aleatoriamente una de las opciones para tablero.
{
    public static char[][,] Distribuciones = new char[][,] // Se crean las distribuciones de barcos.
    {
        // Tablero 1
        new char[6,6]
        {
            {'4','4','4','4','~','~'},
            {'~','~','~','~','~','~'},
            {'2','2','~','~','~','~'},
            {'~','~','~','~','~','3'},
            {'~','~','~','~','~','3'},
            {'~','~','~','~','~','3'}
        },
        // Tablero 2
        new char[6,6]
        {
            {'~','~','~','~','~','3'},
            {'4','4','4','4','~','3'},
            {'~','~','~','~','~','3'},
            {'~','~','~','~','~','~'},
            {'~','~','~','~','~','~'},
            {'~','~','~','~','2','2'}
        },
        // Tablero 3
        new char[6,6]
        {
            {'4','~','2','2','~','~'},
            {'4','~','~','~','~','~'},
            {'4','~','~','~','~','~'},
            {'4','~','~','~','~','3'},
            {'~','~','~','~','~','3'},
            {'~','~','~','~','~','3'}
        },
        // Tablero 4
        new char[6,6]
        {
            {'~','2','2','~','~','~'},
            {'~','~','~','~','~','3'},
            {'~','~','~','~','~','3'},
            {'4','4','4','4','~','3'},
            {'~','~','~','~','~','~',},
            {'~','~','~','~','~','~'}
        },
        // Tablero 5
        new char[6,6]
        {
            {'4','~','~','3','~','~'},
            {'4','~','~','3','~','~'},
            {'4','~','~','3','~','~'},
            {'4','~','~','~','~','~'},
            {'~','~','~','~','~','~'},
            {'~','~','~','2','2','~'}
        },
        // Tablero 6
        new char[6,6]
        {
            {'~','~','4','4','4','4'},
            {'~','~','~','~','~','~'},
            {'~','~','~','~','~','~'},
            {'~','~','3','~','~','~'},
            {'~','~','3','~','~','~'},
            {'~','~','3','~','2','2'}
        },
        // Tablero 7
        new char[6,6]
        {
            {'~','~','~','~','~','3'},
            {'~','~','~','~','~','3'},
            {'~','~','~','~','~','3'},
            {'~','~','~','~','~','~'},
            {'~','4','4','4','4','~'},
            {'~','~','~','~','2','2'}
        },
        // Tablero 8
        new char[6,6]
        {
            {'2','2','~','4','~','~'},
            {'~','~','~','4','~','~'},
            {'~','~','~','4','~','~'},
            {'3','~','~','4','~','~'},
            {'3','~','~','~','~','~'},
            {'3','~','~','~','~','~'}
        },
        // Tablero 9
        new char[6,6]
        {
            {'~','~','3','~','~','~'},
            {'~','~','3','~','~','~'},
            {'~','~','3','~','~','~'},
            {'~','~','~','~','~','~'},
            {'~','~','~','~','2','2'},
            {'4','4','4','4','~','~'}
        },
        // Tablero 10
        new char[6,6]
        {
            {'~','~','~','~','~','2'},
            {'~','3','~','~','~','2'},
            {'~','3','~','~','~','~'},
            {'~','3','~','~','~','~'},
            {'~','~','~','~','~','~'},
            {'4','4','4','4','~','~'}
        }
    };

    public static char[,] RandomizarBarcos() // Randomiza la opcion de tablereo.
    {
        Random random = new Random();
        int index = random.Next(Distribuciones.Length);
        return Distribuciones[index];
    }
}

class Program : Atacar // Clase principal que contiene el juego
{
    public char[,] Barcos1;
    public char[,] Barcos2;

    public void InicializarBarcos() // Inicializa los barcos de ambos jugadores
    {
        Barcos1 = RandomizarPosicion.RandomizarBarcos();
        Barcos2 = RandomizarPosicion.RandomizarBarcos();
    }

    public static string[,] ConvertirTablero(char[,] tablero) // Convierte el tablero de char a string para mostrarlo.
    {
        int filas = tablero.GetLength(0);
        int columnas = tablero.GetLength(1);
        string[,] resultado = new string[filas, columnas];
        for (int i = 0; i < filas; i++)
            for (int j = 0; j < columnas; j++)
                resultado[i, j] = tablero[i, j].ToString();
        return resultado;
    }

    public static void Main()
    {
        Program juego = new Program();
        bool verificacion = true;
        do
        {
            Console.WriteLine("Ingresa el nombre del jugador 1:");
            CrearUsuario jugador1 = new CrearUsuario(Console.ReadLine()!);

            Console.WriteLine("Ingresa el nombre del jugador 2:");
            CrearUsuario jugador2 = new CrearUsuario(Console.ReadLine()!);

            juego.InicializarBarcos();
            char[,] tableroAtaque1 = new char[6, 6];
            char[,] tableroAtaque2 = new char[6, 6];
            for (int i = 0; i < 6; i++)
                for (int j = 0; j < 6; j++)
                {
                    tableroAtaque1[i, j] = '~';
                    tableroAtaque2[i, j] = '~';
                }

            Console.WriteLine("Batalla Naval-6x6");
            Console.WriteLine("Desea iniciar una nueva partida\n1. Jugar\n2. Salir");
            string opcion = Console.ReadLine()!;

            switch (opcion)
            {
                case "1":
                    Console.WriteLine("Iniciando partida...");

                    do
                    {
                        juego.Barcos1 = RandomizarPosicion.RandomizarBarcos();
                        Console.WriteLine("\nConfiguración de barcos para " + jugador1.Nombre + ":");
                        juego.MostrarTableros(ConvertirTablero(juego.Barcos1), new string[6, 6]);
                        Console.WriteLine("¿Te gusta esta configuración? (S/N):");
                    } while (Console.ReadLine()!.Trim().ToUpper() != "S");

                    do
                    {
                        juego.Barcos2 = RandomizarPosicion.RandomizarBarcos();
                        Console.WriteLine("\nConfiguración de barcos para " + jugador2.Nombre + ":");
                        juego.MostrarTableros(ConvertirTablero(juego.Barcos2), new string[6, 6]);
                        Console.WriteLine("¿Te gusta esta configuración? (S/N):");
                    } while (Console.ReadLine()!.Trim().ToUpper() != "S");

                    bool juegoTerminado = false;
                    for (int turno = 1; turno < 31 && !juegoTerminado;)
                    {
                        Console.WriteLine($"\nTurno {turno}");

                        if (turno % 2 == 1) // Turno impar: jugador 1
                        {
                            Console.WriteLine($"Turno de {jugador1.Nombre}");
                            juego.MostrarTableros(ConvertirTablero(juego.Barcos1), ConvertirTablero(tableroAtaque1));

                            if (juego.AtacarBarco(juego.Barcos2, tableroAtaque1, jugador1.Nombre))
                            {
                                turno++;
                            }

                            if (juego.puntosJugador1 >= 9)
                            {
                                Console.WriteLine($"\n¡{jugador1.Nombre} ha derribado todos los barcos y gana la partida!");
                                Console.WriteLine("Juego finalizado.");
                                Console.WriteLine($"Puntos de {jugador1.Nombre}: {juego.puntosJugador1}");
                                Console.WriteLine($"Puntos de {jugador2.Nombre}: {juego.puntosJugador2}");
                                Console.WriteLine($"¡{jugador1.Nombre} gana!");
                                juegoTerminado = true;
                                verificacion = false;
                            }
                        }
                        else // Turno par: jugador 2
                        {
                            Console.WriteLine($"Turno de {jugador2.Nombre}");
                            juego.MostrarTableros(ConvertirTablero(juego.Barcos2), ConvertirTablero(tableroAtaque2));

                            if (juego.AtacarBarco(juego.Barcos1, tableroAtaque2, jugador2.Nombre))
                                turno++;

                            if (juego.puntosJugador2 >= 9)
                            {
                                Console.WriteLine($"\n¡{jugador1.Nombre} ha derribado todos los barcos y gana la partida!");
                                Console.WriteLine("Juego finalizado.");
                                Console.WriteLine($"Puntos de {jugador1.Nombre}: {juego.puntosJugador2}");
                                Console.WriteLine($"Puntos de {jugador2.Nombre}: {juego.puntosJugador1}");
                                Console.WriteLine($"¡{jugador1.Nombre} gana!");
                                juegoTerminado = true;
                                verificacion = false;
                            }
                        }
                    }

                    // Si termina por límite de turnos:
                    if (!juegoTerminado)
                    {
                        Console.WriteLine("Juego finalizado por límite de turnos.");
                        Console.WriteLine($"Puntos de {jugador2.Nombre}: {juego.puntosJugador1}");
                        Console.WriteLine($"Puntos de {jugador1.Nombre}: {juego.puntosJugador2}");

                        if (juego.puntosJugador1 > juego.puntosJugador2)
                        {
                            Console.WriteLine($"¡{jugador2.Nombre} gana!");
                        }
                        else if (juego.puntosJugador2 > juego.puntosJugador1)
                        {
                            Console.WriteLine($"¡{jugador1.Nombre} gana!");
                        }
                        else
                        {
                            Console.WriteLine("¡Es un empate!");
                        }
                    }
                    break;

                case "2":
                    Console.WriteLine("Presione cualquier tecla para salir.");
                    Console.ReadKey();
                    verificacion = false;
                    break;

                default:
                    Console.WriteLine("Opción no válida. Por favor, elige 1 o 2.");
                    break;
            }

        } while (verificacion == true);
    }
}