using System;
class Game2048
{
    static void Main()
    {
        int[,] arr = new int[4,4];
        Title();
        Restart();
        while (Console.ReadKey().Key != ConsoleKey.E)
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    arr[i, j] = 0;
                }
            }
            GenerateNewElement(arr);
            GenerateNewElement(arr);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Счет: 0");
            Console.WriteLine();
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Console.Write("{0,5}", arr[i, j]);
                }
                Console.WriteLine();
                Console.WriteLine();
            }
            while (IsZeroExhist(arr)||(!IsItEnd(arr)&&!IsItWin(arr)))
            {
                int[,] tmparr = new int[4,4];
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        tmparr[i,j]=arr[i,j];
                    }
                }
                Move(arr);
                if (IsZeroExhist(arr)&&Changes(arr, tmparr))
                    GenerateNewElement(arr);
                Console.WriteLine("Счет: " + Score(arr));
                Console.WriteLine();
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        Console.Write("{0,5}", arr[i, j]);
                    }
                    Console.WriteLine();
                    Console.WriteLine();
                }
            }
            if (IsItWin(arr) == true)
                Console.WriteLine("Вы победили, набрав клетку 2048!");
            if (IsItEnd(arr) == true)
                Console.WriteLine("Игра окончена. Не осталось возможных вариантов для хода");
        }

    }

    public static void Title()
    {
        Console.WriteLine("00000000000000000000000000000");
        Console.WriteLine("0                           0");
        Console.WriteLine("0   000   000  0   0  000   0");
        Console.WriteLine("0  0   0 0   0 0   0 0   0  0");
        Console.WriteLine("0      0 0   0 0   0 0   0  0");
        Console.WriteLine("0     0  0   0 00000  000   0");
        Console.WriteLine("0    0   0   0     0 0   0  0");
        Console.WriteLine("0   0    0   0     0 0   0  0");
        Console.WriteLine("0  00000  000      0  000   0");
        Console.WriteLine("0                           0");
        Console.WriteLine("00000000000000000000000000000 ");
        Console.WriteLine("                              Created by PhenomenalMoss");
        Console.WriteLine();
        Console.WriteLine("Управление:");
        Console.WriteLine("W - сдвинуть все наверх");
        Console.WriteLine("A - сдвинуть все влево");
        Console.WriteLine("S - сдвинуть все вниз");
        Console.WriteLine("D - сдвинуть все вправо");
        Console.WriteLine();
    }

    public static void Restart()
    {
        Console.WriteLine("Для начала нажмите любую клавишу");
        Console.WriteLine("Для выхода нажмите - E");
        Console.WriteLine();
    }

    public static int[,] GenerateNewElement(int[,] array)
    {
        Random rnd = new Random();
        int xx = rnd.Next(0, 3);
        int yy = rnd.Next(0, 3);
        while(array[xx, yy] != 0)
        {
            xx = rnd.Next(0, 4);
            yy = rnd.Next(0, 4);
        }
        array[xx, yy] = 2;
        return array;
    }

    public static bool IsZeroExhist(int[,] array)
    {
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                if(array[i, j] == 0)
                    return true;
            }
        }
        return false;
    }

    public static bool Changes(int[,] array, int[,] newarray)
    {
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                if (array[i, j] != newarray[i,j])
                    return true;
            }
        }
        return false;
    }

    public static bool IsItEnd(int[,] array)
    {
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (array[i, j] == array[i, j+1])
                    return false;
            }
        }
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (array[j, i] == array[j+1, i])
                    return false;
            }
        }
        return true;
    }

    public static bool IsItWin(int[,] array)
    {
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                if (array[i, j] == 2048)
                    return true;
            }
        }
        return false;
    }
    public static int[,] MoveUp(int[,] array)
    {
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (array[j, i] == 0)
                {
                    array[j, i] = array[j + 1, i];
                    array[j + 1, i] = 0;
                }
            }
        }
        return array;
    }

    public static int[,] MoveUpPlus(int[,] array)
    {
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (array[j, i] == array[j + 1, i])
                {
                    array[j, i] *= 2;
                    array[j + 1, i] = 0;
                }
            }
        }
        return array;
    }
    public static int[,] MoveLeft(int[,] array)
    {
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (array[i, j] == 0)
                {
                    array[i, j] = array[i, j + 1];
                    array[i, j + 1] = 0;
                }
            }
        }
        return array;
    }
    public static int[,] MoveLeftPlus(int[,] array)
    {
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (array[i, j] == array[i, j + 1])
                {
                    array[i, j] *= 2;
                    array[i, j + 1] = 0;
                }
            }
        }
        return array;
    }
    public static int[,] MoveDown(int[,] array)
    {
        for (int i = 3; i >= 0; i--)
        {
            for (int j = 3; j > 0; j--)
            {
                if (array[j, i] == 0)
                {
                    array[j, i] = array[j - 1, i];
                    array[j - 1, i] = 0;
                }
            }
        }
        return array;
    }
    public static int[,] MoveDownPlus(int[,] array)
    {
        for (int i = 3; i >= 0; i--)
        {
            for (int j = 3; j > 0; j--)
            {
                if (array[j, i] == array[j - 1, i])
                {
                    array[j, i] *= 2;
                    array[j - 1, i] = 0;
                }
            }
        }
        return array;
    }
    public static int[,] MoveRight(int[,] array)
    {
        for (int i = 3; i >= 0; i--)
        {
            for (int j = 3; j > 0; j--)
            {
                if (array[i, j] == 0)
                {
                    array[i, j] = array[i, j - 1];
                    array[i, j - 1] = 0;
                }
            }
        }
        return array;
    }
    public static int[,] MoveRightPlus(int[,] array)
    {
        for (int i = 3; i >= 0; i--)
        {
            for (int j = 3; j > 0; j--)
            {
                if (array[i, j] == array[i, j - 1])
                {
                    array[i, j] *= 2;
                    array[i, j - 1] = 0;
                }
            }
        }
        return array;
    }

    public static int Score(int[,] array)
    {
        int score = 0;
        for(int i = 0; i < 4; i++)
        {
            for(int j = 0; j < 4; j++)
            {
                if(array[i, j] != 0)
                    score+=array[i, j];
            }
        }
        return score;
    }

    public static int[,] Move(int[,] arr)
    {
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("Текущая команда: ");
        switch (Console.ReadKey().Key)
        {
            case ConsoleKey.W:
                MoveUp(arr);
                MoveUp(arr);
                MoveUp(arr);
                MoveUpPlus(arr);
                break;
            case ConsoleKey.A:
                MoveLeft(arr);
                MoveLeft(arr);
                MoveLeft(arr);
                MoveLeftPlus(arr);
                break;
            case ConsoleKey.S:
                MoveDown(arr);
                MoveDown(arr);
                MoveDown(arr);
                MoveDownPlus(arr);
                break;
            case ConsoleKey.D:
                MoveRight(arr);
                MoveRight(arr);
                MoveRight(arr);
                MoveRightPlus(arr);
                break;
            default:
                Console.WriteLine("Неверная команда!");
                break;
        }
        Console.WriteLine();
        Console.WriteLine();
        return arr;
    }

}