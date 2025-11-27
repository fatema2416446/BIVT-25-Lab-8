using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;

namespace Lab5
{
    public class Purple
    {
        public int[] Task1(int[,] matrix)
        {
            int[] answer = null;

            // code here
            answer = new int[matrix.GetLength(1)];
            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);
            for (int i = 0; i < columns; i++)
            {
                int kol = 0;
                for (int j = 0; j < rows; j++)
                {
                    if (matrix[j, i] < 0)
                    {
                        kol++;
                    }
                }
                answer[i] = kol;
            }
            // end

            return answer;
        }
        public void Task2(int[,] matrix)
        {

            // code here
            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);
            for (int i = 0; i < rows; i++)
            {
                int min = matrix[i, 0];
                int minIndex = 0;
                for (int j = 0; j < columns; j++)
                {
                    if (min > matrix[i, j])
                    {
                        min = matrix[i, j];
                        minIndex = j;
                    }
                }
                for (int j = minIndex; j >= 1; j--)
                {
                    matrix[i, j] = matrix[i, j - 1];
                }
                matrix[i, 0] = min;
            }
            // end

        }
        public int[,] Task3(int[,] matrix)
        {
            int[,] answer = null;

            // code here
            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);
            answer = new int[rows, columns + 1];
            for (int i = 0; i < rows; i++)
            {
                int max = matrix[i, 0];
                int maxIndex = 0;
                for (int j = 0; j < columns; j++)
                {
                    if (max < matrix[i, j])
                    {
                        max = matrix[i, j];
                        maxIndex = j;
                    }
                }
                for (int j = 0; j < columns; j++)
                {
                    answer[i, j] = matrix[i, j];
                }
                for (int j = answer.GetLength(1) - 1; j > maxIndex; j--)
                {
                    answer[i, j] = answer[i, j - 1];
                }
                answer[i, maxIndex] = max;
            }
            // end

            return answer;
        }
        public void Task4(int[,] matrix)
        {

            // code here
            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);
            for (int i = 0; i < rows; i++)
            {
                int max = matrix[i, 0];
                int maxIndex = 0;
                int sum = 0;
                int kol = 0;
                for (int j = 0; j < columns; j++)
                {
                    if (max < matrix[i, j])
                    {
                        max = matrix[i, j];
                        maxIndex = j;
                    }
                }
                for (int j = maxIndex + 1; j < columns; j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        sum += matrix[i, j];
                        kol++;
                    }
                }
                if (kol != 0)
                {
                    int srAr = sum / kol;
                    for (int j = 0; j < maxIndex; j++)
                    {
                        if (matrix[i, j] < 0)
                        {
                            matrix[i, j] = srAr;
                        }
                    }
                }
            }
            // end

        }
        public void Task5(int[,] matrix, int k)
        {

            // code here
            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);
            int[] maxValues = new int[rows];
            if (k < columns)
            {
                for (int i = 0; i < rows; i++)
                {
                    int max = matrix[i, 0];
                    for (int j = 0; j < columns; j++)
                    {
                        if (max < matrix[i, j])
                        {
                            max = matrix[i, j];
                        }
                    }
                    maxValues[i] = max;
                }
                int temp;
                for (int i = 0; i < maxValues.Length / 2; i++)
                {
                    temp = maxValues[i];
                    maxValues[i] = maxValues[maxValues.Length - 1 - i];
                    maxValues[maxValues.Length - 1 - i] = temp;
                }
                for (int i = 0; i < rows; i++)
                {
                    matrix[i, k] = maxValues[i];
                }
            }
            // end

        }
        public void Task6(int[,] matrix, int[] array)
        {

            // code here
            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);
            if (array.Length == columns)
            {
                for (int j = 0; j < columns; j++)
                {
                    int max = matrix[0, j];
                    int maxIndex = 0;
                    for (int i = 0; i < rows; i++)
                    {
                        if (max < matrix[i, j])
                        {
                            max = matrix[i, j];
                            maxIndex = i;
                        }
                    }
                    if (array[j] > matrix[maxIndex, j])
                        matrix[maxIndex, j] = array[j];
                }
            }
            // end

        }
        public void Task7(int[,] matrix)
        {

            // code here
            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);
            int[] minValues = new int[rows];
            int[] minIndex = new int[rows];
            int[,] matrixOth = new int[rows, columns];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    matrixOth[i, j] = matrix[i, j];
                }
            }
            for (int i = 0; i < rows; i++)
            {
                int min = matrix[i, 0];
                for (int j = 0; j < columns; j++)
                {
                    if (min > matrix[i, j])
                    {
                        min = matrix[i, j];
                    }
                }
                minValues[i] = min;
                minIndex[i] = i;
            }
            for (int i = 0; i < rows; i++)
            {
                for (int j = i; j < rows; j++)
                {
                    if (minValues[i] < minValues[j])
                    {
                        (minValues[i], minValues[j]) = (minValues[j], minValues[i]);
                        (minIndex[i], minIndex[j]) = (minIndex[j], minIndex[i]);
                    }
                }
            }
            for (int i = 0; i < minIndex.Length; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    matrix[i, j] = matrixOth[minIndex[i], j];
                }
            }
            // end

        }
        public int[] Task8(int[,] matrix)
        {
            int[] answer = null;

            // code here
            if (matrix.GetLength(0) == matrix.GetLength(1))
            {
                int n = matrix.GetLength(0);
                answer = new int[2 * n - 1];
                int index = 0;
                for (int i = n - 1; i >= 0; i--)
                {
                    int sum = 0;
                    for (int j = 0; j < n - i; j++)
                    {
                        sum += matrix[i + j, j];
                    }
                    answer[index] = sum;
                    index++;
                }
                for (int j = 1; j < n; j++)
                {
                    int sum = 0;
                    for (int i = 0; i < n - j; i++)
                    {
                        sum += matrix[i, i + j];
                    }
                    answer[index] = sum;
                    index++;
                }
            }
            // end

            return answer;
        }
        public void Task9(int[,] matrix, int k)
        {

            // code here
            if (matrix.GetLength(0) == matrix.GetLength(1))
            {
                int n = matrix.GetLength(0);

                int indexI = 0;
                int indexJ = 0;
                int max = Math.Abs(matrix[0, 0]);

                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        int currentAbs = Math.Abs(matrix[i, j]);
                        if (currentAbs > max)
                        {
                            max = currentAbs;
                            indexI = i;
                            indexJ = j;
                        }
                    }
                }

                if (indexI == k && indexJ == k)
                {
                    return;
                }

                int[] tempRow = new int[n];

                for (int j = 0; j < n; j++)
                {
                    tempRow[j] = matrix[indexI, j];
                }

                if (indexI < k)
                {
                    for (int i = indexI; i < k; i++)
                    {
                        for (int j = 0; j < n; j++)
                        {
                            matrix[i, j] = matrix[i + 1, j];
                        }
                    }
                }
                else if (indexI > k)
                {
                    for (int i = indexI; i > k; i--)
                    {
                        for (int j = 0; j < n; j++)
                        {
                            matrix[i, j] = matrix[i - 1, j];
                        }
                    }
                }

                for (int j = 0; j < n; j++)
                {
                    matrix[k, j] = tempRow[j];
                }

                int[] tempCol = new int[n];

                for (int i = 0; i < n; i++)
                {
                    tempCol[i] = matrix[i, indexJ];
                }

                if (indexJ < k)
                {
                    for (int j = indexJ; j < k; j++)
                    {
                        for (int i = 0; i < n; i++)
                        {
                            matrix[i, j] = matrix[i, j + 1];
                        }
                    }
                }
                else if (indexJ > k)
                {
                    for (int j = indexJ; j > k; j--)
                    {
                        for (int i = 0; i < n; i++)
                        {
                            matrix[i, j] = matrix[i, j - 1];
                        }
                    }
                }

                for (int i = 0; i < n; i++)
                {
                    matrix[i, k] = tempCol[i];
                }
            }
            // end

        }
        public int[,] Task10(int[,] A, int[,] B)
        {
            int[,] answer = null;

            // code here
            int rowsA = A.GetLength(0);
            int columnsA = A.GetLength(1);
            int rowsB = B.GetLength(0);
            int columnsB = B.GetLength(1);

            if (columnsA == rowsB)
            {
                answer = new int[rowsA, columnsB];
                int index = 0;
                for (int i = 0; i < rowsA; i++)
                {
                    for (int k = 0; k < columnsB; k++)
                    {
                        int sum = 0;
                        for (int j = 0; j < rowsB; j++)
                        {
                            sum += A[i, j] * B[j, k];
                        }
                        answer[i, k] = sum;
                    }
                }
            }
            // end

            return answer;
        }
        public int[][] Task11(int[,] matrix)
        {
            int[][] answer = null;

            // code here

            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);
            answer = new int[rows][];
            for (int i = 0; i < rows; i++)
            {
                int kol = 0;
                for (int j = 0; j < columns; j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        kol++;
                    }
                }
                answer[i] = new int[kol];
            }

            for (int i = 0; i < rows; i++)
            {
                int index = 0;
                answer[i][0] = matrix[i, 0];
                for (int j = 0; j < columns; j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        answer[i][index] = matrix[i, j];
                        index++;
                    }
                }
            }
            // end

            return answer;
        }
        public int[,] Task12(int[][] array)
        {
            int[,] answer = null;

            // code here
            double len = 0;
            for (int i = 0; i < array.Length; i++)
            {
                len += array[i].Length;
            }

            double nn = Math.Ceiling(Math.Sqrt(len));
            int n = (int)nn;
            answer = new int[n, n];
            int indexI = 0;
            int indexJ = 0;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (indexI >= array.Length)
                    {
                        answer[i, j] = 0;
                    }
                    else
                    {
                        answer[i, j] = array[indexI][indexJ];

                        if (indexJ == array[indexI].Length - 1)
                        {
                            indexI++;
                            indexJ = 0;
                        }
                        else
                        {
                            indexJ++;
                        }
                    }
                }

            }
            // end

            return answer;
            }
        }
    }
