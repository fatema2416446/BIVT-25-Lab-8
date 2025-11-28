using System.Linq;
using System.Runtime.InteropServices;

namespace Lab5
{
    public class White
    {
        public double Task1(int[,] matrix)
        {
            double average = 0;

            // code here
            double sum = 0;
            int count = 0;
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        sum += matrix[i, j];
                        count++;
                    }
                }
            }
            average = sum / count;
            // end

            return average;
        }
        public (int row, int col) Task2(int[,] matrix)
        {
            int row = 0, col = 0;

            // code here
            int mins = matrix[0, 0];
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                    if (matrix[i, j] < mins)
                    {
                        mins = matrix[i, j];
                        row = i;
                        col = j;
                    }
            }
            // end

            return (row, col);
        }
        public void Task3(int[,] matrix, int k)
        {

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            if (k < 0 || k >= m)
            {
                return;
            }
            int targetRow = 0;
            int maxValue = matrix[0, k];
            for (int i = 1; i < n; i++)
            {
                if (matrix[i, k] > maxValue)
                {
                    maxValue = matrix[i, k];
                    targetRow = i;
                }
            }
            if (targetRow == 0)
            {
                return;
            }
            for (int j = 0; j < m; j++)
            {
                int temp = matrix[0, j];
                matrix[0, j] = matrix[targetRow, j];
                matrix[targetRow, j] = temp;
            }
            // end

        }
        public int[,] Task4(int[,] matrix)
        {
            int[,] answer = null;

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            int[,] result = new int[n - 1, m];
            int minRow = 0;
            int minValue = matrix[0, 0];
            for (int i = 0; i < n; i++)
            {
                if (matrix[i, 0] < minValue)
                {
                    minValue = matrix[i, 0];
                    minRow = i;
                }
            }
            for (int i = 0; i < n - 1; i++)
            {
                if (i < minRow)
                {
                    for (int j = 0; j < m; j++)
                    {
                        result[i, j] = matrix[i, j];
                    }
                }
                else
                {
                    for (int j = 0; j < m; j++)
                    {
                        result[i, j] = matrix[i + 1, j];
                    }
                }
            }
            // end

            return result;
        }
        public int Task5(int[,] matrix)
        {
            int sum = 0;

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            if (n != m)
            {
                return 0;
            }
            for (int i = 0; i < n; i++)
            {
                sum += matrix[i, i];
            }
            // end

            return sum;
        }
        public void Task6(int[,] matrix)
        {

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            for (int i = 0; i < n; i++)
            {
                int firstNegative = -1;
                int maxIndex = -1;
                int lastNegative = -1;
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] < 0)
                    {
                        firstNegative = j;
                        break;
                    }
                    if (maxIndex == -1 || matrix[i, j] > matrix[i, maxIndex])
                    {
                        maxIndex = j;
                    }
                }
                for (int j = m - 1; j >= 0; j--)
                {
                    if (matrix[i, j] < 0)
                    {
                        lastNegative = j;
                        break;
                    }
                }
                if (maxIndex != -1 && lastNegative != -1 && firstNegative != -1)
                {
                    int temp = matrix[i, maxIndex];
                    matrix[i, maxIndex] = matrix[i, lastNegative];
                    matrix[i, lastNegative] = temp;
                }
            }
            // end

        }
        public int[] Task7(int[,] matrix)
        {
            int[] negatives = null;

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            int count = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
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
            int index = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] < 0)
                    {
                        negatives[index] = matrix[i, j];
                        index++;
                    }
                }
            }
            // end

            return negatives;
        }
        public void Task8(int[,] matrix)
        {

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            for (int i = 0; i < n; i++)
            {
                if (m == 1)
                {
                    continue;
                }
                int maxCol = 0;
                for (int j = 1; j < m; j++)
                {
                    if (matrix[i, j] > matrix[i, maxCol])
                    {
                        maxCol = j;
                    }
                }
                if (maxCol == 0)
                {
                    matrix[i, 1] *= 2;
                }
                else if (maxCol == m - 1)
                {
                    matrix[i, m - 2] *= 2;
                }
                else
                {
                    if (matrix[i, maxCol - 1] <= matrix[i, maxCol + 1])
                    {
                        matrix[i, maxCol - 1] *= 2;
                    }
                    else
                    {
                        matrix[i, maxCol + 1] *= 2;
                    }
                }
            }
            // end

        }
        public void Task9(int[,] matrix)
        {

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m / 2; j++)
                {
                    int temp = matrix[i, j];
                    matrix[i, j] = matrix[i, m - 1 - j];
                    matrix[i, m - 1 - j] = temp;
                }
            }
            // end

        }
        public void Task10(int[,] matrix)
        {

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            if (n != m)
            {
                return;
            }
            for (int i = n / 2; i < n; i++)
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
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            bool[] hasNoZero = new bool[n];
            int count = 0;

            for (int i = 0; i < n; i++)
            {
                bool hasZero = false;
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        hasZero = true;
                        break;
                    }
                }
                if (!hasZero)
                {
                    hasNoZero[i] = true;
                    count++;
                }
            }
            int[,] result = new int[count, m];
            int rowIndex = 0;
            for (int i = 0; i < n; i++)
            {
                if (hasNoZero[i])
                {
                    for (int j = 0; j < m; j++)
                    {
                        result[rowIndex, j] = matrix[i, j];
                    }
                    rowIndex++;
                }
            }
            // end

            return result;
        }
        public void Task12(int[][] array)
        {

            // code here
            int sum = 0;
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    int sumI = 0;
                    int sumJ = 0;
                    for (int k = 0; k < array[i].Length; k++)
                    {
                        sumI += array[i][k];
                    }
                    for (int k = 0; k < array[j].Length; k++)
                    {
                        sumJ += array[j][k];
                    }
                    if (sumI > sumJ)
                    {
                        int[] temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
                }
            }
            // end

        }
    }
}