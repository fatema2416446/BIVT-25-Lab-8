using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;

namespace Lab5
{
    public class Green
    {
        public int[] Task1(int[,] matrix)
        {
            int[] answer = null;

            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            int[] result = new int[rows];

            for (int i = 0; i < rows; i++)
            {
                int imin = 0;
                int min = matrix[i, 0];

                for (int j = 1; j < cols; j++)
                {
                    if (matrix[i, j] < min)
                    {
                        min = matrix[i, j];
                        imin = j;
                    }
                }
                result[i] = imin;
            }

            return result;
            // end

            return answer;
        }
        public void Task2(int[,] matrix)
        {

            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                
                int imax = 0;
                int max = matrix[i, 0];

                for (int j = 1; j < cols; j++)
                {
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                        imax = j;
                    }
                }

                // Обрабатываем элементы до первого максимума
                for (int j = 0; j < imax; j++)
                {
                    if (matrix[i, j] < 0) // если элемент отрицательный
                    {
                        matrix[i, j] = (int)Math.Floor((double)matrix[i, j] / max);
                    }
                }
            }
            // end

        }
        public void Task3(int[,] matrix, int k)
        {

            // code here
            int n = matrix.GetLength(0); 
            int maxc = 0;
            int max = matrix[0, 0];
            if (n != matrix.GetLength(1))
                return;
            if (k < 0 || k >= n) 
                return;

                for (int i = 1; i < n; i++)
            {
                if (matrix[i, i] > max)
                {
                    max= matrix[i, i];
                    maxc = i;
                }
            }
            if (maxc == k)
                return;

            for (int i = 0; i < n; i++)
            {
                int temp = matrix[i, k];
                matrix[i, k] = matrix[i, maxc];
                matrix[i, maxc] = temp;
            }
            // end

        }
        public void Task4(int[,] matrix)
        {

            // code here
            if (matrix.GetLength(0) != matrix.GetLength(1))
                return;

            int max = int.MinValue, imax = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, i] > max)
                {
                    max = matrix[i, i];
                    imax = i;
                }
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
                (matrix[i, imax], matrix[imax, i]) = (matrix[imax, i], matrix[i, imax]);
            // end

        }
        public int[,] Task5(int[,] matrix)
        {
            int[,] answer = null;

            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            int maxr = 0;
            double maxs = 0;

            for (int i = 0; i < rows; i++)
            {
                double sum = 0;
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        sum += matrix[i, j];
                    }
                }

                if (sum > maxs)
                {
                    maxs = sum;
                    maxr = i;
                }
            }
            int[,] newMatrix = new int[rows - 1, cols];
            int newRow = 0;

            for (int i = 0; i < rows; i++)
            {
                if (i != maxr)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        newMatrix[newRow, j] = matrix[i, j];
                    }
                    newRow++;
                }
            }

            return newMatrix;
            // end

            return answer;
        }
        public void Task6(int[,] matrix)
        {

            // code here
            int maxIndex = 0, minIndex = 0, max = Int32.MinValue, min = Int32.MaxValue;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int cnt = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < 0)
                    {
                        cnt++;
                    }
                }

                if (cnt > max)
                {
                    max = cnt;
                    maxIndex = i;
                }

                if (cnt < min)
                {
                    min = cnt;
                    minIndex = i;
                }
            }

            for (int i = 0; i < matrix.GetLength(1); i++)
                (matrix[maxIndex, i], matrix[minIndex, i]) = (matrix[minIndex, i], matrix[maxIndex, i]);
            // end

        }
        public int[,] Task7(int[,] matrix, int[] array)
        {
            int[,] answer = null;

            // code here
            if (array.Length != matrix.GetLength(0))
                return matrix;

            int min = Int32.MaxValue, minIndex = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < min)
                    {
                        min = matrix[i, j];
                        minIndex = j;
                    }
                }
            }

            answer = new int[matrix.GetLength(0), matrix.GetLength(1) + 1];

            int matrixI = 0;
            for (int i = 0; i < answer.GetLength(0); i++)
            {
                int matrixJ = 0;
                for (int j = 0; j < answer.GetLength(1); j++)
                {
                    if (j == minIndex + 1)
                        answer[i, j] = array[i];
                    else
                        answer[i, j] = matrix[matrixI, matrixJ++];
                }
                matrixI++;
            }
            // end

            return answer;
        }
        public void Task8(int[,] matrix)
        {

            // code here
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                int pn = 0, mn = 0, max = Int32.MinValue, imax = 0;
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    if (matrix[j, i] > max)
                    {
                        max = matrix[j, i];
                        imax = j;
                    }
                    if (matrix[j, i] > 0)
                        pn++;
                    else if (matrix[j, i] < 0)
                        mn++;
                }

                if (pn > mn)
                    matrix[imax, i] = 0;
                else if (mn > pn)
                    matrix[imax, i] = imax;
            }
            // end

        }
        public void Task9(int[,] matrix)
        {

            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            if (rows != cols)
                return;
            for (int i = 0; i < rows * rows; i++)
            {
                int x = i / rows;
                int k = i % rows;
                if (x == 0 || x == rows - 1 || k == 0 || k == rows - 1)
                {
                    matrix[x, k] = 0;
                }
            }
            // end

        }
        public (int[] A, int[] B) Task10(int[,] matrix)
        {
            int[] A = null, B = null;

            // code here
            if (matrix.GetLength(0) != matrix.GetLength(1))
                return (A, B);

            int counterA = 0, counterB = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (i <= j)
                        counterA++;
                    else
                        counterB++;
                }
            }

            A = new int[counterA];
            B = new int[counterB];

            counterA = 0;
            counterB = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (i <= j)
                        A[counterA++] = matrix[i, j];
                    else
                        B[counterB++] = matrix[i, j];
                }
            }

            // end

            return (A, B);
        }
        public void Task11(int[,] matrix)
        {

            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            for (int j = 0; j < cols; j++)
            {
                int[] nov = new int[rows];
                for (int i = 0; i < rows; i++)
                {
                    nov[i] = matrix[i, j];
                }
                if (j % 2 == 0)
                {
                    for (int i = 0; i < rows - 1; i++)
                    {
                        for (int k = i + 1; k < rows; k++)
                        {
                            if (nov[i] < nov[k])
                            {
                                int ans = nov[i];
                                nov[i] = nov[k];
                                nov[k] = ans;
                            }
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < rows - 1; i++)
                    {
                        for (int k = i + 1; k < rows; k++)
                        {
                            if (nov[i] > nov[k])
                            {
                                int ans = nov[i];
                                nov[i] = nov[k];
                                nov[k] = ans;
                            }
                        }
                    }
                }
                for (int i = 0; i < rows; i++)
                {
                    matrix[i, j] = nov[i];
                }
            }
            // end

        }
        public void Task12(int[][] array)
        {

            // code here
            for (int i = 0; i < array.Length - 1; i++)
            {
                int max = i;
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j].Length > array[max].Length)
                    {
                        max = j;
                    }
                    else if (array[j].Length == array[max].Length)
                    {
                        int s = 0;
                        int sm = 0;
                        for (int k = 0; k < array[j].Length; k++)
                        {
                            s += array[j][k];
                        }
                        for (int k = 0; k < array[max].Length; k++)
                        {
                            sm += array[max][k];
                        }
                        if (s > sm)
                        {
                            max = j;
                        }
                    }
                }
                if (max != i)
                {
                    (array[i], array[max]) = (array[max], array[i]);
                }
            }
            // end

        }
    }
}