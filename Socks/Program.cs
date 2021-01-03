using System;
using System.Linq;

namespace Socks
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] left = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] right= Console.ReadLine().Split().Select(int.Parse).ToArray();

            int lcsLength = GetLcsLength(left, right);

            Console.WriteLine(lcsLength);
        }

        private static int GetLcsLength(int[] left, int[] right)
        {
            int rows = left.Length + 1;
            int cols = right.Length + 1;
            int[,] matrix = new int[rows, cols];

            for (int row = 1; row < rows; row++)
            {
                for (int col = 1; col < cols; col++)
                {
                    if (left[row - 1] == right[col - 1])
                    {
                        matrix[row, col] = 1 + matrix[row - 1, col - 1];
                    }
                    else
                    {
                        matrix[row, col] = Math.Max(matrix[row - 1, col], matrix[row, col - 1]);
                    }
                }
            }

            return matrix[rows - 1, cols - 1];
        }
    }
}
