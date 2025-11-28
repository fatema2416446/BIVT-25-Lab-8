using System.Collections.Immutable;
using System.Linq;
using System.Runtime.InteropServices;
using System.Xml;

namespace Lab5
{
    public class White
    {
        public double Task1(int[,] matrix)
        {
            double average = 0;

            // code here
            int count = 0;
            double sum = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        count++;
                        sum += matrix[i, j];
                    }
                    if (count != 0)
                    {
                        average = sum / count;
                    }
                }
            }
            // end

            return average;
        }
        public (int row, int col) Task2(int[,] matrix)
        {
            int row = 0, col = 0;

            // code here
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {

                    if (matrix[i, j] < matrix[0, 0])
                    {
                        matrix[0, 0] = matrix[i, j];
                        row = i;
                        col = j;
                    }
                }
            }
            // end

            return (row, col);
        }
        public void Task3(int[,] matrix, int k)
        {

            // code here
            int max = 0;
            if (k < 0 || k >= matrix.GetLength(1))
            {
                return;
            }
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, k] > matrix[max, k])
                {
                    max = i;
                }
            }
            if (max != 0)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    (matrix[0, j], matrix[max, j]) = (matrix[max, j], matrix[0, j]);
                }
            }

            // end

        }
        public int[,] Task4(int[,] matrix)
        {
            int[,] answer = new int[matrix.GetLength(0) - 1, matrix.GetLength(1)];

            // code here
            int min = 0;
            if (matrix.GetLength(0) == 0 || matrix.GetLength(0) == 1)
            {
                return new int[0, matrix.GetLength(1)];
            }
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, 0] < matrix[min, 0])
                {
                    min = i;
                }
            }
            for (int i = 0; i < matrix.GetLength(0) - 1; i++)
            {
                if (i < min)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        answer[i, j] = matrix[i, j];
                    }
                }
                else
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        answer[i, j] = matrix[i + 1, j];
                    }
                }
            }

            // end

            return answer;
        }
        public int Task5(int[,] matrix)
        {
            int sum = 0;

            // code here
            if (matrix.GetLength(0) != matrix.GetLength(1))
            {
                return 0;
            }
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                sum += matrix[i, i];
            }
            // end

            return sum;
        }
        public void Task6(int[,] matrix)
        {

            // code here
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int max = 0;
                int last = -1;
                int first = -1;
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] < 0)
                    {
                        last = col;
                    }

                }
                if (last == -1)
                {
                    continue;
                }
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] < 0)
                    {
                        first = col;
                        break;
                    }
                }
                for (int col = 0; col < first; col++)
                {
                    if (matrix[row, col] > matrix[row, max])
                    {
                        max = col;
                    }

                }
                if (first > 0)
                {
                    int Matrix = matrix[row, max];
                    matrix[row, max] = matrix[row, last];
                    matrix[row, last] = Matrix;
                }
            }

            // end

        }
        public int[] Task7(int[,] matrix)
        {
            int[] negatives = null;
            int index = 0;
            int count = 0;
            if (matrix.GetLength(0) == 0 || matrix.GetLength(1) == 0)
            {
                return null;
            }
            // code here
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < 0)
                    {
                        count++;
                    }
                }
            }
            if (count == 0)
            {
                return null;
            }
            negatives = new int[count];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < 0)
                    {
                        negatives[index++] = matrix[i, j];
                    }
                }
            }
            // end

            return negatives;
        }
        public void Task8(int[,] matrix)
        {

            // code here

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int max = 0;
                if (matrix.GetLength(1) > 1)
                {
                    for (int j = 1; j < matrix.GetLength(1); j++)
                    {

                        if (matrix[i, j] > matrix[i, max])
                        {
                            max = j;
                        }
                    }
                    if (max == 0)
                    {
                        matrix[i, 1] *= 2;
                    }
                    else if (max == matrix.GetLength(1) - 1)
                    {
                        matrix[i, matrix.GetLength(1) - 2] *= 2;
                    }
                    else
                    {
                        if (matrix[i, max - 1] > matrix[i, max + 1] || matrix[i, max - 1] == matrix[i, max + 1])
                        {
                            matrix[i, max + 1] *= 2;
                        }
                        else
                        {
                            matrix[i, max - 1] *= 2;
                        }
                    }
                }

            }
            // end

        }
        public void Task9(int[,] matrix)
        {

            // code here
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1) / 2; j++)
                {
                    int temp = matrix[i, j];
                    matrix[i, j] = matrix[i, matrix.GetLength(1) - j - 1];
                    matrix[i, matrix.GetLength(1) - j - 1] = temp;
                }
            }
            // end

        }
        public void Task10(int[,] matrix)
        {

            // code here
            if (matrix.GetLength(0) != matrix.GetLength(1))
            {
                return;
            }
            for (int i = matrix.GetLength(0) / 2; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    matrix[i, j] = 1;
                }
            }
            // end

        }
        public int[,] Task11(int[,] matrix)
        {
            int[,] answer = null;
            // code here
            if (matrix == null)
            {
                return null;
            }
            int count = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                bool nol = false;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        nol = true;
                        break;
                    }

                }
                if (!nol)
                {
                    count++;
                }
            }
            if (count == 0)
            {
                return new int[0, matrix.GetLength(1)];
            }
            if (count == matrix.GetLength(0))
            {
                int[,] copy = new int[matrix.GetLength(0), matrix.GetLength(1)];
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        copy[i, j] = matrix[i, j];
                    }
                }
                return copy;
            }
            answer = new int[count, matrix.GetLength(1)];
            int row = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                bool nol = false;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        nol = true;
                        break;
                    }
                }
                if (!nol)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        answer[row, j] = matrix[i, j];
                    }
                    row++;

                }
                //end
            }
            return answer;
        }
        public void Task12(int[][] array)
        {

            // code here
            int[] sums = new int[array.Length]; int k = 0;
            foreach (int[] a in array)
            {
                int s = 0;
                foreach (int el in a)
                {
                    s += el;
                }
                sums[k++] = s;
            }
            Array.Sort(sums);
            int[][] new_array = new int[array.Length][];
            for (int i = 0; i < array.Length; i++)
            {
                int s = 0;
                for (int j = 0; j < array[i].Length; j++)
                {
                    s += array[i][j];
                }
                int index = 0;
                for (int j = 0; j < array.Length; j++)
                {
                    if (s == sums[j]) index = j;
                }
                sums[index] = int.MinValue;
                new_array[index] = new int[array[i].Length];
                for (int j = 0; j < array[i].Length; j++)
                {
                    new_array[index][j] = array[i][j];
                }
            }
            for (int i = 0; i < array.Length; i++)
            {
               array[i] = new_array[i];
                // end

            }
        }
    }
}