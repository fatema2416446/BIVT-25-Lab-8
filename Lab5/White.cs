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
            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);
            int min = matrix[0, 0];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (matrix[i, j] < min)
                    {
                        min = matrix[i, j];
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
            int[,] answer = null;

            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            if (rows == 0)
            {
                return new int[0, cols];
            }

            int minRow = 0;
            int minValue = matrix[0, 0];
            for (int i = 1; i < rows; i++)
            {
                if (matrix[i, 0] < minValue)
                {
                    minValue = matrix[i, 0];
                    minRow = i;
                }
            }

            if (rows == 1)
            {
                return new int[0, cols];
            }

            answer = new int[rows - 1, cols];
            int targetRow = 0;
            for (int i = 0; i < rows; i++)
            {
                if (i == minRow)
                {
                    continue;
                }

                for (int j = 0; j < cols; j++)
                {
                    answer[targetRow, j] = matrix[i, j];
                }
                targetRow++;
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
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (i == j)
                    {
                        sum += matrix[i, j];
                    }
                }
            }

            // end

            return sum;
        }
        public void Task6(int[,] matrix)
        {

            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            for (int i = 0; i < rows; i++)
            {
                int firstNegativeIndex = -1;
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] < 0)
                    {
                        firstNegativeIndex = j;
                        break;
                    }
                }

                if (firstNegativeIndex <= 0)
                {
                    continue;
                }

                int maxIndex = 0;
                int maxValue = matrix[i, 0];
                for (int j = 1; j < firstNegativeIndex; j++)
                {
                    if (matrix[i, j] > maxValue)
                    {
                        maxValue = matrix[i, j];
                        maxIndex = j;
                    }
                }

                int lastNegativeIndex = -1;
                for (int j = cols - 1; j >= 0; j--)
                {
                    if (matrix[i, j] < 0)
                    {
                        lastNegativeIndex = j;
                        break;
                    }
                }

                if (lastNegativeIndex == -1)
                {
                    continue;
                }

                (matrix[i, maxIndex], matrix[i, lastNegativeIndex]) = (matrix[i, lastNegativeIndex], matrix[i, maxIndex]);
            }

            // end

        }
        public int[] Task7(int[,] matrix)
        {
            int[] negatives = null;

            // code here
            int ngtCounter = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < 0)
                    {
                        ngtCounter++;
                    }
                }
            }

            if (ngtCounter > 0)
            {
                negatives = new int[ngtCounter];
                int index = 0;

                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        if (matrix[i, j] < 0)
                        {
                            negatives[index] = matrix[i, j];
                            index++;
                        }
                    }
                }
            }

            // end

            return negatives;
        }
        public void Task8(int[,] matrix)
        {

            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            for (int i = 0; i < rows; i++)
            {
                if (cols == 0)
                {
                    continue;
                }

                int maxIndex = 0;
                int maxValue = matrix[i, 0];
                for (int j = 1; j < cols; j++)
                {
                    if (matrix[i, j] > maxValue)
                    {
                        maxValue = matrix[i, j];
                        maxIndex = j;
                    }
                }

                if (cols == 1)
                {
                    continue;
                }

                bool hasLeft = maxIndex - 1 >= 0;
                bool hasRight = maxIndex + 1 < cols;
                if (!hasLeft && !hasRight)
                {
                    continue;
                }

                if (hasLeft && hasRight)
                {
                    int left = matrix[i, maxIndex - 1];
                    int right = matrix[i, maxIndex + 1];
                    if (left <= right)
                    {
                        matrix[i, maxIndex - 1] = left * 2;
                    }
                    else
                    {
                        matrix[i, maxIndex + 1] = right * 2;
                    }
                }
                else if (hasLeft)
                {
                    matrix[i, maxIndex - 1] *= 2;
                }
                else if (hasRight)
                {
                    matrix[i, maxIndex + 1] *= 2;
                }
            }

            // end

        }
        public void Task9(int[,] matrix)
        {

            // code here

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1) / 2; col++)
                {
                    int newCol = matrix.GetLength(1) - 1 - col;
                    int temp =  matrix[row, col];
                    matrix[row, col] = matrix[row, newCol];
                    matrix[row, newCol] = temp;
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

            int startRow = n / 2;
            for (int i = startRow; i < n; i++)
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
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            bool[] hasZero = new bool[rows];
            int remaining = rows;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        hasZero[i] = true;
                        remaining--;
                        break;
                    }
                }
            }

            answer = new int[remaining, cols];
            int target = 0;
            for (int i = 0; i < rows; i++)
            {
                if (hasZero[i])
                {
                    continue;
                }

                for (int j = 0; j < cols; j++)
                {
                    answer[target, j] = matrix[i, j];
                }
                target++;
            }

            // end

            return answer;
        }
        public void Task12(int[][] array)
        {

            // code here
            int[] sum = new int[array.Length]; 

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    sum[i] += array[i][j]; 
                }
            }

            for (int i = 0; i < sum.Length - 1; i++)
            {
                for (int j = 0; j < sum.Length - 1 - i; j++)
                {
                    if (sum[j] > sum[j + 1])
                    {
                        (array[j],  array[j + 1]) = (array[j + 1], array[j]);
                        (sum[j], sum[j + 1]) = (sum[j + 1], sum[j]);
                    }
                }
            }

            // end

        }
    }

}

