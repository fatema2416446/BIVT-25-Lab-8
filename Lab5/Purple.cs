using System.Linq;
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

            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                int res = 0;
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    if (matrix[j, i] < 0)
                    {
                        res += 1;
                    }
                }
                answer[i] = res;
            }
            // end

            return answer;
        }
        public void Task2(int[,] matrix)
        {

            // code here
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int min = matrix[i, 0];
                int ind = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < min)
                    {
                        min = matrix[i, j];
                        ind = j;
                    }
                }
                int t = matrix[i, 0];
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (j < ind)
                    {
                        int r = matrix[i, j + 1];
                        matrix[i, j + 1] = t;
                        t = r;
                    }
                }
                matrix[i, 0] = min;
            }
            //for (int i = 0; i < matrix.GetLength(0); i++)
            //{
            //    for (int j = 0; j < matrix.GetLength(1); j++)
            //    {
            //        Console.Write(matrix[i, j] + " ");
            //    }
            //    Console.WriteLine();
            //}
            // end

        }
        public int[,] Task3(int[,] matrix)
        {
            int[,] answer = null;

            // code here
            int[,] ma = new int[matrix.GetLength(0), matrix.GetLength(1) + 1];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int ind = 0;
                int max = matrix[i, 0];
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > max)
                    {
                        ind = j;
                        max = matrix[i, j];
                    }
                }
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (j <= ind)
                    {
                        ma[i, j] = matrix[i, j];

                    }
                    else
                    {
                        ma[i, j + 1] = matrix[i, j];
                    }
                    ma[i, ind + 1] = matrix[i, ind];
                }
            }
            answer = ma;
            // end

            return answer;
        }
        public void Task4(int[,] matrix)
        {

            // code here
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int ind = 0;
                int max = matrix[i, 0];
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > max)
                    {
                        ind = j;
                        max = matrix[i, j];
                    }
                }
                int sr = 0;
                int s = 0;
                int k = 0;
                for (int j = ind; j < matrix.GetLength(1); j++)
                {
                    if (j > ind && matrix[i, j] > 0)
                    {
                        s += matrix[i, j];
                        k++;
                    }
                }
                if (k != 0)
                {
                    sr = s / k;

                    for (int j = 0; j < ind; j++)
                    {
                        if (matrix[i, j] < 0)
                        {
                            matrix[i, j] = sr;
                        }
                    }
                }
            }
            // end

        }
        public void Task5(int[,] matrix, int k)
        {

            // code here
            if (k < matrix.GetLength(1))
            {
                int[] a = new int[matrix.GetLength(0)];
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
                    a[i] = max;
                }
                int[] b = new int[matrix.GetLength(0)];
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    b[i] = a[matrix.GetLength(0) - i - 1];
                }
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    matrix[i, k] = b[i];
                }
            }

            // end

        }
        public void Task6(int[,] matrix, int[] array)
        {

            // code here
            if (matrix.GetLength(1) == array.Length)
            {
                int[] a = new int[matrix.GetLength(1)];
                int[] b = new int[matrix.GetLength(1)];

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    int max = matrix[0, j];
                    int ind = 0;
                    for (int i = 0; i < matrix.GetLength(0); i++)
                    {
                        if (matrix[i, j] > max)
                        {
                            max = matrix[i, j];
                            ind = i;
                        }
                    }
                    a[j] = max;
                    b[j] = ind;
                }
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    for (int i = 0; i < matrix.GetLength(0); i++)
                    {
                        if (array[j] > a[j])
                        {
                            matrix[b[j], j] = array[j];
                        }
                    }
                }
            }
            // end

        }
        public void Task7(int[,] matrix)
        {

            // code here
            //int[,] ma = new int[matrix.GetLength(0), matrix.GetLength(1)];
            //int[] a = new int[matrix.GetLength(0)];
            //int[] b = new int[matrix.GetLength(0)];
            //for (int i = 0; i < matrix.GetLength(0); i++)
            //{
            //    b[i] = i;
            //}

            //for (int i = 0; i < matrix.GetLength(0); i++)
            //{
            //    int min = matrix[i, 0];
            //    for (int j = 0; j < matrix.GetLength(1); j++)
            //    {
            //        if (matrix[i, j] < min)
            //        {
            //            min = matrix[i, j];
            //        }
            //    }
            //    a[i] = min;
            //}

            //for (int i = 0; i < a.Length - 1; i++)
            //{
            //    for (int j = 0; j < a.Length - 1; j++)
            //    {
            //        if (a[j] < a[j + 1])
            //        {
            //            (a[j], a[j + 1]) = (a[j + 1], a[j]);
            //            (b[j], b[j + 1]) = (b[j + 1], b[j]);
            //        }
            //    }
            //}

            //for (int i = 0; i < b.Length; i++)
            //{
            //    for (int k = 0; k < matrix.GetLength(1); k++)
            //    {
            //        ma[i, k] = matrix[b[i], k];
            //    }
            //}

            //matrix = ma;


            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            int[] minValues = new int[rows];
            for (int i = 0; i < rows; i++)
            {
                int min = matrix[i, 0];
                for (int j = 1; j < cols; j++)
                {
                    if (matrix[i, j] < min)
                        min = matrix[i, j];
                }
                minValues[i] = min;
            }
            for (int i = 0; i < rows - 1; i++)
            {
                for (int j = 0; j < rows - 1 - i; j++)
                {
                    if (minValues[j] < minValues[j + 1])
                    {
                        int tempMin = minValues[j];
                        minValues[j] = minValues[j + 1];
                        minValues[j + 1] = tempMin;

                        for (int k = 0; k < cols; k++)
                        {
                            int temp = matrix[j, k];
                            matrix[j, k] = matrix[j + 1, k];
                            matrix[j + 1, k] = temp;
                        }
                    }
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

                for (int d = 0; d < answer.Length; d++)
                {
                    int sum = 0;
                    int row = n - 1 - d;
                    int col = 0;

                    if (d >= n)
                    {
                        row = 0;
                        col = d - n + 1;
                    }

                    while (row < n && col < n)
                    {
                        sum += matrix[row, col];
                        row++;
                        col++;
                    }

                    answer[d] = sum;
                }
            }

            // end

            return answer;
        }
        public void Task9(int[,] matrix, int k)
        {


            // code here
            int mx_i = 0, mx_j = 0, n = matrix.GetLength(0), m = matrix.GetLength(1);
            if (n == m)
            {
                int[,] dop_matrix = new int[n, m];
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        if (Math.Abs(matrix[i, j]) > Math.Abs(matrix[mx_i, mx_j]))
                        {
                            mx_i = i;
                            mx_j = j;
                        }
                    }
                }
                if (mx_i > k)
                {
                    for (int i = mx_i; i > k; i--)
                    {
                        for (int j = 0; j < n; j++)
                        {
                            (matrix[i, j], matrix[i - 1, j]) = (matrix[i - 1, j], matrix[i, j]);
                        }
                    }
                }
                else
                {
                    for (int i = mx_i; i < k; i++)
                    {
                        for (int j = 0; j < n; j++)
                        {
                            (matrix[i, j], matrix[i + 1, j]) = (matrix[i + 1, j], matrix[i, j]);
                        }
                    }
                }
                if (mx_j > k)
                {
                    for (int j = mx_j; j > k; j--)
                    {
                        for (int i = 0; i < n; i++)
                        {
                            (matrix[i, j], matrix[i, j - 1]) = (matrix[i, j - 1], matrix[i, j]);
                        }
                    }
                }
                else
                {
                    for (int j = mx_j; j < k; j++)
                    {
                        (matrix[mx_i, j], matrix[mx_i, mx_j + 1]) = (matrix[mx_i, mx_j + 1], matrix[mx_i, mx_j]);
                    }
                }


            }
            // end

        }
        public int[,] Task10(int[,] A, int[,] B)
        {
            int[,] answer = null;

            // code here
            int A0 = A.GetLength(0);
            int A1 = A.GetLength(1);
            int B0 = B.GetLength(0);
            int B1 = B.GetLength(1);

            if (A0 == 0 || A1 == 0)
            {
                return null;
            }

            if (B0 == 0 || B1 == 0)
            {
                return null;
            }

            if (A1 != B0)
            {
                return null;
            }

            answer = new int[A0, B1];

            for (int i = 0; i < A0; i++)
            {
                for (int j = 0; j < B1; j++)
                {
                    int sum = 0;
                    for (int k = 0; k < A1; k++)
                    {
                        sum += A[i, k] * B[k, j];
                    }
                    answer[i, j] = sum;
                }
            }

            // end

            return answer;
        }
        public int[][] Task11(int[,] matrix)
        {
            int[][] answer = null;

            // code here
            int n = matrix.GetLength(0), m = matrix.GetLength(1);
            answer = new int[n][];
            for (int i = 0; i < n; i++)
            {
                int len = 0;
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        len += 1;
                    }

                }
                answer[i] = new int[len];
                int u = 0;
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        answer[i][u] = matrix[i, j];
                        u++;
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
            //int len = array.Length;
            //int d = 0;
            //for (int i = 0; i < len; i++)
            //{
            //    if (array[i].Length > d)
            //    {
            //        d = array[i].Length;
            //    }
            //}
            //if (len >= d)
            //{
            //    answer = new int[len, len];
            //    for (int i = 0; i < len; i++)
            //    {
            //        int count = 0;
            //        for (int j = 0; j < array[i].Length; j++)
            //        {
            //            answer[i, count] = array[i][j];
            //            count++;
            //        }
            //        while (count < len)
            //        {
            //            answer[i, count] = 0;
            //            count++;
            //        }
            //    }
            //}
            //else
            //{
            //    answer = new int[d, d];
            //    for (int i = 0; i < len; i++)
            //    {
            //        int count = 0;
            //        for (int j = 0; j < array[i].Length; j++)
            //        {
            //            answer[i, count] = array[i][j];
            //            count++;
            //        }
            //        while (count < d)
            //        {
            //            answer[i, count] = 0;
            //            count++;
            //        }
            //    }
            //}
            //len++;
            //while (len <  d)
            //{
            //    for (int i = 0; i < d; i++)
            //    {
            //        answer[len, i] = 0;
            //    }
            //    len++;
            //}


            if (array == null)
                return new int[0, 0];

            int kolvo = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] != null)
                {
                    kolvo += array[i].Length;
                }
            }

            int size = (int)Math.Ceiling(Math.Sqrt(kolvo));
            if (size == 0) return new int[0, 0];

            answer = new int[size, size];
            int currentRow = 0;
            int currentCol = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == null) continue;

                for (int j = 0; j < array[i].Length; j++)
                {
                    answer[currentRow, currentCol] = array[i][j];
                    currentCol++;
                    if (currentCol >= size)
                    {
                        currentCol = 0;
                        currentRow++;
                        if (currentRow >= size) break;
                    }
                }
                if (currentRow >= size) break;
            }


            // end

            return answer;
        }
    }
}
