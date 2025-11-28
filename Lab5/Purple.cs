using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;

namespace Lab5
{
    public class Purple
    {
        public int[] Task1(int[,] matrix)
        {
            int[] answer = null;

            // code here

            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            if (n == 0 || m == 0)
                return new int[0];

            answer = new int[m];
            for (int j=0; j<m; j++)
            {
                int count = 0;
                for (int i = 0; i < n; i++)
                {
                    if (matrix[i, j] < 0)
                    {
                        count++;
                    }
                }
                answer[j] = count;
            }
            
            // end
            return answer;
        }
        public void Task2(int[,] matrix)
        {

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            for (int i = 0; i < n; i++)
            {
                int min = int.MaxValue;
                int indMin = - 1;
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] < min)
                    {
                        min = matrix[i, j];
                        indMin = j;
                    }
                }
                for (int k = indMin; k>0; k--)
                {
                    matrix[i, k] = matrix[i, k - 1];
                }
                matrix[i, 0] = min;

            }
            // end

        }
        public int[,] Task3(int[,] matrix)
        {
            int[,] answer = null;

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            answer = new int[n, m + 1];
            for (int i = 0; i < n; i++)
            {
                int max = int.MinValue;
                int indMax = -1;
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                        indMax = j;
                    }

                }
                for (int j = 0; j < m; j++)
                {
                    answer[i, j] = matrix[i, j];
                }
                for (int k = m; k>indMax+1; k--)
                {
                    answer[i, k] = answer[i, k-1];
                }
                answer[i, indMax+1] = max;
                // end
            }
                return answer;
        }
        public void Task4(int[,] matrix)
        {
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            // code here
            for (int i = 0; i < n; i++)
            {
                int max = int.MinValue;
                int indMax = -1;
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                        indMax = j;
                    }
                }
                int sum = 0;
                int countPos = 0;
                int avg = 0;
                for (int j=indMax+1; j<m; j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        countPos++;
                        sum += matrix[i, j];
                    }
                }
                if (countPos > 0)
                {
                    avg = sum / countPos;
                
                    for (int j = 0; j < indMax; j++)
                    {
                        if (matrix[i, j] < 0)
                        {
                            matrix[i, j] = avg;
                        }

                    }
                }
            }
            // end

            }
        public void Task5(int[,] matrix, int k)
        {

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            int[] max = new int[n];
            if (k < m)
            {
                for (int i = 0; i<n; i++)
                {
                    int maxEl = int.MinValue;
                    for (int j = 0; j < m; j++)
                    {
                        if (matrix[i, j] > maxEl)
                        {
                            maxEl=matrix[i, j];
                        }
                    }
                    max[i] = maxEl;
                }
                int index = n - 1;
                for (int i = 0; i < n; i++)
                {
                    matrix[i, k] = max[index];
                    index--;
                }
            }
            // end

        }
        public void Task6(int[,] matrix, int[] array)
        {

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            int[] max = new int[m];
            for (int j=0; j<m; j++)
            {
                int maxEl = int.MinValue;
                int indMax = -1;
                for (int i=0; i<n; i++)
                {
                    if (matrix[i, j] > maxEl)
                    {
                        maxEl = matrix[i, j];
                        indMax = i;
                    }
                }
                max[j] = maxEl;
                if (array.Length == m)
                {
                    if (max[j] < array[j])
                    {
                        matrix[indMax, j] = array[j];
                    }
                }
            }
            // end

        }
        public void Task7(int[,] matrix)
        {

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            int[,] sorted = new int[n, 2];
            for (int i = 0; i < n; i++)
            {
                int minEl = int.MaxValue;
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] < minEl)
                    {
                        minEl = matrix[i, j];
                    }
                }
                sorted[i, 0] = minEl;
                sorted[i, 1] = i;
            }
            for (int i = 0; i < n; i++)
            {
                for (int l = 0; l < n - i - 1; l++)
                {
                    if (sorted[l, 0] < sorted[l + 1, 0])
                    {
                        (sorted[l, 0], sorted[l + 1, 0]) = (sorted[l + 1, 0], sorted[l, 0]);
                        (sorted[l, 1], sorted[l + 1, 1]) = (sorted[l + 1, 1], sorted[l, 1]);

                    }
                }
            }
            int[,] answer = new int[n, m];
            for (int i = 0; i < n; i++)
            {
                int index = sorted[i, 1];

                for (int j = 0; j < m; j++)
                {
                    answer[i, j] = matrix[index, j];
                }
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    matrix[i, j] = answer[i, j];
                }
            }
            // end

        }
        public int[] Task8(int[,] matrix)
        {
            int[] answer = null;

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            if (n != m)
            {
                return answer;
            }
            answer = new int[2 * n - 1];
            answer[0] = matrix[n - 1, 0];
            answer[2 * n - 2] = matrix[0, n - 1];
            int index = 1;
            for (int i = n - 2; i > 0; i--)
            {

                int sum = 0, stroka = i, stolbec = 0;
                while (stroka < n)
                {
                    sum += matrix[stroka, stolbec];
                    stroka++;
                    stolbec++;
                }
                answer[index] = sum;
                index++;
            }

            for (int i = 0; i < n; i++)
            {
                int sum = 0, stroka = 0, stolbec = i;

                while (stolbec < n)
                {
                    sum += matrix[stroka, stolbec];
                    stroka++;
                    stolbec++;
                }
                answer[index] = sum;
                index++;
            }
            // end

            return answer;
        }
        public void Task9(int[,] matrix, int k)
        {

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            int max = 0;
            int rowMax = -1;
            int colMax = -1;
            if (n == m)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        if (Math.Abs(matrix[i, j]) > Math.Abs(max))
                        {
                            max = matrix[i, j];
                            rowMax = i; colMax = j;
                        }
                    }
                }
                if (rowMax > k)
                {
                    int curr = 0;
                    for (int j = 0; j < m; j++)
                    {
                        curr = matrix[rowMax, j];
                        for (int i = rowMax; i > k; i--)
                        {
                            matrix[i, j] = matrix[i - 1, j];

                        }
                        matrix[k, j] = curr;
                    }
                }
                else if (rowMax < k)
                {
                    int curr = 0;
                    for (int j = 0; j < m; j++)
                    {
                        curr = matrix[k, j];
                        for (int i = k; i > rowMax; i--)
                        {
                            matrix[i, j] = matrix[i - 1, j];

                        }
                        matrix[rowMax, j] = curr;
                    }
                }

                if (colMax > k)
                {
                    int curr = 0;
                    for (int i = 0; i < n; i++)
                    {
                        curr = matrix[i, colMax];
                        for (int j = colMax; j > k; j--)
                        {
                            matrix[i, j] = matrix[i, j - 1];

                        }
                        matrix[i, k] = curr;
                    }
                }
                else if (colMax < k)
                {
                    int curr = 0;
                    for (int i = 0; i < n; i++)
                    {
                        curr = matrix[i, k];
                        for (int j = k; j > colMax; j--)
                        {
                            matrix[i, j] = matrix[i, j - 1];

                        }
                        matrix[i, colMax] = curr;
                    }
                }
            }
            // end

        }
        public int[,] Task10(int[,] A, int[,] B)
        {
            int[,] answer = null;

            // code here
            int n1 = A.GetLength(0);
            int n2 = B.GetLength(0);
            int m1 = A.GetLength(1);
            int m2 = B.GetLength(1);
            if (m1 == n2)
            {
                answer = new int[n1, m2];
                for (int i = 0; i < n1; i++)
                {
                    for (int j = 0; j < m2; j++)
                    {
                        for (int k = 0; k < m1; k++)
                        {
                            answer[i, j] += A[i, k] * B[k, j];
                        }
                    }
                }
            }
            // end

            return answer;
        }
        public int[][] Task11(int[,] matrix)
        {
            int[][] answer = null;
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            answer = new int[n][];
            // code here
            for (int i=0; i<n; i++)
            {
                int count = 0;
                for (int j=0; j<m; j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        count++;
                    }
                }
                answer[i] = new int[count];
                int index = 0;
                for (int j = 0; j < m; j++)
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
            int n = array.GetLength(0);
            int count = 0;
            // code here
            for (int i = 0; i < n; i++)
            {
                count += array[i].Length;
            }
            double sqrt = Math.Sqrt(count);
            int size = (int)Math.Ceiling(sqrt);

            answer = new int[size, size];
            int row = 0;
            int col = 0;
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    answer[row, col] = array[i][j];

                    col++;

                    if (col >= size)
                    {
                        col = 0;
                        row++;
                    }
                }
            }
            // end

            return answer;
        }
    }
}