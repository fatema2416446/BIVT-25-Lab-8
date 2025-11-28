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
            int k = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0;j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        sum += matrix[i, j];
                        k++;
                    }
                   
                }
            }
            average += (sum / k);

            // end

            return average;
        }
        public (int row, int col) Task2(int[,] matrix)
        {
            int row = 0, col = 0;

            // code here
            int min = int.MaxValue;
            
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
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
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            if (k < 0 || k >= m)
                return;
            int maxRow = 0;
            int maxValue = matrix[0, k];

            for (int i = 1; i < n; i++)
            {
                if (matrix[i, k] > maxValue)
                {
                    maxValue = matrix[i, k];
                    maxRow = i;
                }
            }
            if (maxRow == 0)
                return;
            for (int j = 0; j < m; j++)
            {
                int temp = matrix[0, j];
                matrix[0, j] = matrix[maxRow, j];
                matrix[maxRow, j] = temp;
            }
            // end

        }
        public int[,] Task4(int[,] matrix)
        {
            int[,] answer = null;

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            if (n == 1)
            {
                answer = new int[0, m];
                return answer;
            }
            int minRow = 0;
            int minValue = matrix[0, 0];

            for (int i = 1; i < n; i++)
            {
                if (matrix[i, 0] < minValue)
                {
                    minValue = matrix[i, 0];
                    minRow = i;
                }
            }
            answer = new int[n - 1, m];

            int newRow = 0;
            for (int i = 0; i < n; i++)
            {
                if (i == minRow)
                    continue;
                for (int j = 0; j < m; j++)
                {
                    answer[newRow, j] = matrix[i, j];
                }
                newRow++;
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
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            for (int i = 0; i < n; i++)
            {
                int maxIndex = -1;
                int maxValue = int.MinValue;
                int lastNegativeIndex = -1;
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] < 0)
                    {
                        lastNegativeIndex = j;
                    }
                }
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] < 0) break;
                    if (matrix[i, j] > maxValue)
                    {
                        maxValue = matrix[i, j];
                        maxIndex = j;
                    }
                }
                if (maxIndex != -1 && lastNegativeIndex != -1)
                {
                    int temp = matrix[i, maxIndex];
                    matrix[i, maxIndex] = matrix[i, lastNegativeIndex];
                    matrix[i, lastNegativeIndex] = temp;
                }
            }

            // end

        }
        public int[] Task7(int[,] matrix)
        {
            int[] negatives = null;

            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            int count = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if ((matrix[i, j]) < 0)
                        count++;

                }
            }
            if (count == 0)
                return null;
            negatives = new int[count];
            int c = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] < 0)
                    {
                        negatives[c] = matrix[i, j];
                        c++;
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
                    continue;

                
                int maxIndex = 0;
                int maxValue = matrix[i, 0];

                for (int j = 1; j < m; j++)
                {
                    if (matrix[i, j] > maxValue)
                    {
                        maxValue = matrix[i, j];
                        maxIndex = j;
                    }
                }

                
                if (maxIndex == 0)
                {
                    matrix[i, 1] *= 2;
                }
                else if (maxIndex == m - 1)
                {
                    
                    matrix[i, m - 2] *= 2;
                }
                else
                {
               
                    int leftNeighbor = matrix[i, maxIndex - 1];
                    int rightNeighbor = matrix[i, maxIndex + 1];

                    if (leftNeighbor <= rightNeighbor)
                    {
                        
                        matrix[i, maxIndex - 1] *= 2;
                    }
                    else
                    {
                        
                        matrix[i, maxIndex + 1] *= 2;
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
            if (matrix.GetLength(0) != matrix.GetLength(1)) return;
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
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            int count = 0;
            for (int i = 0; i < n; i++)
            {
                bool zero = false;
                for (int j = 0; j < m && !zero; j++)
                    if (matrix[i, j] == 0) zero = true;
                if (!zero) count++;
            }

            if (count == 0) return new int[0, m];
            if (count == n) return (int[,])matrix.Clone();

            answer = new int[count, m];
            int idx = 0;

            for (int i = 0; i < n; i++)
            {
                bool zero = false;
                for (int j = 0; j < m && !zero; j++)
                    if (matrix[i, j] == 0) zero = true;

                if (!zero)
                {
                    for (int j = 0; j < m; j++)
                        answer[idx, j] = matrix[i, j];
                    idx++;
                }
            }
            // end

            return answer;
        }
        public void Task12(int[][] array)
        {

            // code here
            int[] sums = new int[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                int sum = 0;
                for (int j = 0; j < array[i].Length; j++)
                    sum += array[i][j];
                sums[i] = sum;
            }

            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (sums[i] > sums[j])
                    {
                        int[] temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;

                        int tempSum = sums[i];
                        sums[i] = sums[j];
                        sums[j] = tempSum;
                    }
                }
            }
        }
        // end

    }
    }
