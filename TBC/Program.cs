using System;

namespace TBC
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());
            char[,] matrix = ReadMatrix(rows, cols);
            int tunnels = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 't')
                    {
                        FindTunnels(matrix, row, col);
                        tunnels++;
                    }
                }
            }

            Console.WriteLine(tunnels);
        }

        private static void FindTunnels(char[,] matrix, int row, int col)
        {
            if (!CanMove(matrix, row, col))
            {
                return;
            }

            matrix[row, col] = 'v';

            FindTunnels(matrix, row - 1, col);//up
            FindTunnels(matrix, row + 1, col);//down
            FindTunnels(matrix, row, col - 1);//left
            FindTunnels(matrix, row, col + 1);//right
            FindTunnels(matrix, row - 1, col - 1);//up-left
            FindTunnels(matrix, row - 1, col + 1);//up-right
            FindTunnels(matrix, row + 1, col - 1);//down-left
            FindTunnels(matrix, row + 1, col + 1);//down-right

           
        }

        private static bool CanMove(char[,] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) &&
                   col >= 0 && col < matrix.GetLength(1) &&
                   matrix[row, col] == 't';
        }

        private static char[,] ReadMatrix(int rows, int cols)
        {
            char[,] matrix = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                char[] line = Console.ReadLine().ToCharArray();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = line[col];
                }
            }

            return matrix;
        }
    }
}
