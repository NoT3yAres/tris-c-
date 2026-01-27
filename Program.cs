public class Tris
{

    static void Main(string[] args)
    {
        Console.Clear();
        int[,] tab = new int[3, 3]{ {0,0,0},
                                    {0,0,0},
                                    {0,0,0}};
        int col = 0;
        int row = 0;
        int turn = 1;
        bool GameOver = false;
        while (!GameOver)
        {
            do
            {
                Console.WriteLine($"Turno del player {turn}");
                try
                {
                    Console.WriteLine("inserire riga: (1-3)");
                    row = Convert.ToInt32(Console.ReadLine()) - 1;
                    Console.WriteLine("inserire colonna: (1-3)");
                    col = Convert.ToInt32(Console.ReadLine()) - 1;

                }
                catch (System.IndexOutOfRangeException)
                {
                    Console.WriteLine("Premi il tasto giusto frocione");
                }
                catch (System.FormatException)
                {
                    Console.WriteLine("NUMERI NON ALTRO COGLIONE");
                }


            } while (!giaOccupato(col, row, tab));
            if (turn <= 2)
            {
                if (turn == 1)
                {
                    tab[row, col] = 1;
                    turn = 2;
                }
                else if (turn == 2)
                {
                    tab[row, col] = 2;
                    turn = 1;
                }
            }
            else
            {
                Console.WriteLine("ROTTO TUTTO, di chi era il turno? (1) (2)");
                turn = Convert.ToInt32(Console.ReadLine());
            }
            stampaArray(tab);
            Thread.Sleep(1500);
            Console.Clear();
            if (controlloWin(tab))
            {
                Console.WriteLine("Partita finita");
                GameOver = true;
                stampaArray(tab);
            }
        }
    }

    public static bool giaOccupato(int col, int row, int[,] tab)
    {
        if ((col <= 3 && col >= 0) && (row <= 3 && row >= 0) && (tab[row, col] == 0))
            return true;
        else
        {
            Console.WriteLine("sbagliato qualcosa mi sa brothero");
            return false;
        }


    }

    public static bool controlloWin(int[,] tab)
    {
        for (int i = 0; i < 3; i++)
        {
            if ((tab[0, i] == tab[1, i]) && (tab[1, i] == tab[2, i]) && ((tab[1, i] == 1) || (tab[1, i] == 2))) return true;
            if ((tab[i, 0] == tab[i, 1]) && (tab[i, 1] == tab[i, 2]) && ((tab[i, 1] == 1) || (tab[i, 1] == 2))) return true;
        }
        if ((tab[0, 0] == tab[1, 1]) && (tab[1, 1] == tab[2, 2]) && ((tab[1, 1] == 1) || (tab[1, 1] == 2))) return true;
        if ((tab[0, 2] == tab[1, 1]) && (tab[1, 1] == tab[2, 0]) && ((tab[1, 1] == 1) || (tab[1, 1] == 2))) return true;
        return false;
    }

    public static void stampaArray(int[,] tab)
    {
        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine("\n");
            for (int j = 0; j < 3; j++)
            {
                Console.Write($"{tab[i, j]}\t");
            }
        }
    }

}