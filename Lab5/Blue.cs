using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;

namespace Lab5
{
    public class Blue
    {
        public double[] Task1(int[,] matrix)
        {
            double[] answer = null;

            // code here
            answer = new double[matrix.GetLength(0)];
            int c = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                double average = 0;
                int count = 0;

                for (int j = 0;  j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        average += matrix[i, j];
                        count++;
                    }
                }

                if (count != 0)
                {
                    average /= count;
                    answer[c++] = average;
                }
                else
                {
                    answer[c++] = 0;
                }
            }
            // end

            return answer;
        }
        public int[,] Task2(int[,] matrix)
        {
            int[,] answer = null;

            // code here
            int max = matrix[0, 0], maxRow = 0, maxCol = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                        maxRow = i;
                        maxCol = j;
                    }
                }
            }

            answer = new int[matrix.GetLength(0) - 1, matrix.GetLength(1) - 1];
            int newRow = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int newCol = 0;
                if (i == maxRow) continue;

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (j == maxCol) continue;
                    answer[newRow, newCol] = matrix[i, j];
                    newCol++;
                }

                newRow++;
            }

            // end

            return answer;
        }
        public void Task3(int[,] matrix)
        {

            // code here
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int max = matrix[i, 0];
                int jmax = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                        jmax = j;
                    }
                }

                for (int j = jmax; j < matrix.GetLength(1) - 1; j++)
                {
                    matrix[i, j] = matrix[i, j + 1];
                }

                matrix[i, matrix.GetLength(1) - 1] = max;
            }
            // end

        }
        public int[,] Task4(int[,] matrix)
        {
            int[,] answer = null;

            // code here
            answer = new int[matrix.GetLength(0), matrix.GetLength(1) + 1];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    answer[i, j] = matrix[i, j];
                }
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int max = matrix[i, 0];
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                    }
                }

                answer[i, answer.GetLength(1) - 2] = max;
                answer[i, answer.GetLength(1) - 1] = matrix[i, matrix.GetLength(1) - 1];
            }
            // end

            return answer;
        }
        public int[] Task5(int[,] matrix)
        {
            int[] answer = null;

            // code here
            int count = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if ((i + j) % 2 != 0)
                    {
                        count++;
                    }
                }
            }

            answer = new int[count];
            int k = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if ((i + j) % 2 != 0)
                    {
                        answer[k++] = matrix[i, j];
                    }
                }
            }
            // end

            return answer;
        }
        public void Task6(int[,] matrix, int k)
        {

            // code here
            if (k < 0 || k >= matrix.GetLength(1)) return;
            if (matrix.GetLength(0) != matrix.GetLength(1)) return;


            int rowMax = 0;
            int maxDiag = matrix[0, 0];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, i] > maxDiag)
                {
                    maxDiag = matrix[i, i];
                    rowMax = i;
                }
            }

            int rowNeg = -1;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, k] < 0)
                {
                    rowNeg = i;
                    break;
                }
            }

            if (rowNeg != -1 && rowNeg != rowMax)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    int temp = matrix[rowMax, j];
                    matrix[rowMax, j] = matrix[rowNeg, j];
                    matrix[rowNeg, j] = temp;
                }
            }
            // end

        }
        public void Task7(int[,] matrix, int[] array)
        {

            // code here
            if (matrix.GetLength(1) < 2 || matrix.GetLength(1) != array.Length) return;

            int max = matrix[0, matrix.GetLength(1) - 2];
            int imax = 0;

            for (int i = 1; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, matrix.GetLength(1) - 2] > max)
                {
                    max = matrix[i, matrix.GetLength(1) - 2];
                    imax = i;
                }
            }

            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                matrix[imax, j] = array[j];
            }
            // end

        }
        public void Task8(int[,] matrix)
        {

            // code here
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                int max = matrix[0, j];
                int imax = 0;
                for (int i = 1; i < matrix.GetLength(0); i++)
                {
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                        imax = i;
                    }
                }

                if (imax == matrix.GetLength(0)) break;

                int sum = 0;
                for (int i = imax + 1; i < matrix.GetLength(0); i++)
                {
                    sum += matrix[i, j];
                }

                if (imax < matrix.GetLength(0) / 2)
                {
                    matrix[0, j] = sum;
                }
            }
            // end

        }
        public void Task9(int[,] matrix)
        {

            // code here

            for (int i = 0; i < matrix.GetLength(0) - 1; i+=2)
            {
                int max1 = matrix[i, 0];
                int jmax1 = 0;

                int max2 = matrix[i + 1, 0];
                int jmax2 = 0;

                for (int j = 1; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > max1)
                    {
                        max1 = matrix[i, j];
                        jmax1 = j;
                    }
                }

                for (int j = 1; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i + 1, j] > max2)
                    {
                        max2 = matrix[i + 1, j];
                        jmax2 = j;
                    }
                }

                int temp = matrix[i, jmax1];
                matrix[i, jmax1] = matrix[i + 1, jmax2];
                matrix[i + 1, jmax2] = temp;
            }
            // end

        }
        public void Task10(int[,] matrix)
        {

            // code here
            if (matrix.GetLength(0) != matrix.GetLength(1)) return;

            int max = matrix[0, 0];
            int imax = 0;

            for (int i = 1; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, i] > max)
                {
                    max = matrix[i, i];
                    imax = i;
                }
            }

            for (int i = 0; i < imax; i++)
            {
                for (int j = i + 1; j < matrix.GetLength(0); j++)
                {
                    matrix[i, j] = 0;
                }
            }
            // end

        }
        public void Task11(int[,] matrix)
        {

            // code here
            int[] positives = new int[matrix.GetLength(0)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int count = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        count++;
                    }
                }
                positives[i] = count;
            }

            int ii = 1, n = matrix.GetLength(0);
            while (ii < n)
            {
                if (ii == 0 || positives[ii] <= positives[ii - 1])
                {
                    ii++;
                }
                else
                {
                    (positives[ii], positives[ii - 1]) = (positives[ii - 1], positives[ii]);
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        (matrix[ii, j], matrix[ii - 1, j]) = (matrix[ii - 1, j], matrix[ii, j]);
                    }
                    ii--;
                }
            }
            // end

        }
        public int[][] Task12(int[][] array)
        {
            int[][] answer = null;

            // code here
            double sum = 0;
            int count = 0;
            foreach (var row in array)
            {
                if (row != null)
                {
                    foreach (int elem in row)
                    {
                        sum += elem;
                        count++;
                    }
                }
            }

            double average = sum / count;

            count = 0;
            for (int i = 0; i < array.Length; i++)
            {
                sum = 0;
                for (int j = 0; j < array[i].Length; j++)
                {
                    sum += array[i][j];
                }
                double rowAvg = sum / array[i].Length;

                if (rowAvg >= average)
                    count++;
            }

            answer = new int[count][];
            int index = 0;

            for (int i = 0; i < array.Length; i++)
            {
                sum = 0;
                for (int j = 0; j < array[i].Length; j++)
                {
                    sum += array[i][j];
                }

                double rowAvg = sum / array[i].Length;

                if (rowAvg >= average)
                {
                    int[] newRow = new int[array[i].Length];
                    for (int j = 0; j < array[i].Length; j++)
                    {
                        newRow[j] = array[i][j];
                    }
                    answer[index++] = newRow;
                }
            }
            // end

            return answer;
        }
    }
}