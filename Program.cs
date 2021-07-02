using System;

namespace Matrix_exponentiation
{
    class Program
    {
        static bool flag = true;
        static int cycles = 0;

        static void Main(string[] args)
        {
            int n = 3; 
            int power = 5;
            int[,] matrix = new int[n,n];
            int[,] keeper = new int[n,n];

            Initialization(matrix, n, false);
            Initialization(keeper, n, true);
            Console.WriteLine("Our Initialized matrix:\n");
            Display(matrix, n);

            int[,] result = Multiply(matrix, keeper, power, n);
            Console.WriteLine("Result of exponentiation:\n");
            Display(result, n);
        }

        static void Display(int[,] matrix, int n)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(matrix[i, j] + "\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine("\n\n\n");
        }

        static int[,] Multiply(int[,] matrix, int[,] keeper, int power, int n)
        {
            if (power <= 1 && cycles <= 0)
                return matrix;
            else if (power <= 1 && cycles >= 1)
                return keeper;

            if (flag)
            {
                flag = false;
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        for (int k = 0; k < n; k++)
                        {
                            keeper[i, j] += matrix[i, k] * matrix[k, j];
                        }
                    }
                }
                return Multiply(matrix, keeper, power - 1, n);
            }

            int[,] temp = new int[n, n];
            Initialization(temp, n, true);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    for (int k = 0; k < n; k++)
                    {
                        temp[i, j] += keeper[i, k] * matrix[k, j];
                    }
                }
            }
            keeper = temp;
            cycles++;
            return Multiply(matrix, keeper, power - 1, n);
        }

        static void Initialization(int[,] matrix,int n, bool isZeroMatrix)
        {
            if (isZeroMatrix)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        matrix[i, j] = 0;
                    }
                }
            }
            else
            {
                Random rnd = new Random();
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        matrix[i, j] = rnd.Next(0, 10);
                    }
                }
            }
        }
    }
}
