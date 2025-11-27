using System.Globalization;

namespace Lab5
{
    public class Program
    {
        public static void Main()
        {
            int[,] input1 = {
                { 1, 2, 3, 4, -5, -6, -7 },
                { 5, 11, -17, 11, -10, 6, 5 },
                { -9, -10, -11, -14, -15, -16, 1 },
                { -9, -10, -11, -14, 15, -6, -2 },
                { -9, -10, -11, -14, -15, 6, 4 },
                { 5, 11, -17, 11, -10, 6, -5 },
                { 1, 1, -2, 3, -4, 0, 0 },
                { 0, -2, -3, -4, -5, 0, 5 }
            };


            MatrixShow MS = new MatrixShow();
            Purple purp = new Purple();
            purp.Task4(input1);
            
        }
    }
    public class MatrixShow()
    {

        public void ShowMatrix(int[,] matrix) 
        {
            for(int y = 0; y < matrix.GetLength(0); y++)
            {
                for(int x = 0; x < matrix.GetLength(1); x++)
                {
                    Console.Write($"{matrix[y, x]} ");
                }
                Console.WriteLine();
            }
        }
        public void ShowArrayMatrix(int[][] matrix)
        {
            for(int y = 0; y < matrix.Length; y++)
            {
                Console.WriteLine(string.Join(' ', matrix[y]));
            }
        }
    }
}
