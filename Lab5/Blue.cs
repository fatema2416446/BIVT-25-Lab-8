using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;

namespace Lab5
{
    public class Blue
    {
        public double[] Task1(int[,] matrix)
        {
            double[] answer = null;
            // code here
            double sum = 0, count = 0;
            answer = new double[matrix.GetLength(0)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                sum = 0;
                count = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        sum += matrix[i, j];
                        count++;
                    }
                }
                if (count > 0)
                {
                    answer[i] = sum/count;
                }
                else
                {
                    answer[i] = 0;
                }
            }
            // end

            return answer;
        }
        public int[,] Task2(int[,] matrix)
        {
            int[,] answer = null;

            // code here
            answer = new int[matrix.GetLength(0) - 1, matrix.GetLength(1) - 1];
            int mx_i = 0, mx_j = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[mx_i, mx_j] < matrix[i, j])
                    {
                        mx_i = i;
                        mx_j = j;
                    }
                }
            }
            int dop_j = 0, dop_i = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (i == mx_i)
                {
                    dop_i++;
                    continue;
                }
                dop_j = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (j == mx_j)
                    {
                        dop_j++;
                    }
                    else
                    {
                        answer[i - dop_i, j - dop_j] = matrix[i, j];
                    }

                }
            }
            // end

            return answer;
        }
        public void Task3(int[,] matrix)
        {

            // code here
            int mx = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                mx = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, mx] < matrix[i, j])
                    {
                        mx = j;
                    }
                }
                for (int j = mx; j < matrix.GetLength(1)-1; j++)
                {
                    (matrix[i, j], matrix[i, j+1]) = (matrix[i, j+1], matrix[i, j]);
                }
            }
            // end

        }
        public int[,] Task4(int[,] matrix)
        {
            int[,] answer = null;

            // code here
            int n = matrix.GetLength(0), m = matrix.GetLength(1);
            answer = new int[n, m + 1];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (j + 1 == m)
                    {
                        answer[i, j + 1] = matrix[i, j];
                    }
                    answer[i, j] = matrix[i, j];
                }
            }
            for (int i = 0; i < n; i++)
            {
                int mx = matrix[i, 0];
                for (int j = 0; j < m; j++)
                {
                    if (mx < matrix[i, j])
                    {
                        mx = matrix[i, j];
                    }
                }
                answer[i, m - 1] = mx;
            }
            // end

            return answer;
        }
        public int[] Task5(int[,] matrix)
        {
            int[] answer = null;

            // code here
            int n = matrix.GetLength(0), m = matrix.GetLength(1);
            answer = new int[(int)((n * m) / 2.0)];
            int count = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if ((i + j) % 2 != 0)
                    {
                        answer[count] = matrix[i, j];
                        count++;
                    }
                }
            }
            // end


            return answer;
        }
        public void Task6(int[,] matrix, int k)
        {

            // code here
            if (matrix.GetLength(0) == matrix.GetLength(1))
            {
                int n = matrix.GetLength(0), mx = 0, ind = 0;

                for (int i = 0; i < n; i++)
                {
                    if (matrix[mx, mx] < matrix[i, i])
                    {
                        mx = i;
                    }

                    if (matrix[i, k] < 0 && matrix[ind, k] > 0)
                    {
                        ind = i;
                    }
                }
                if (matrix[ind, k] < 0 && ind != mx)
                {
                    for (int j = 0; j < n; j++)
                    {
                        (matrix[mx, j], matrix[ind, j]) = (matrix[ind, j], matrix[mx, j]);
                    }
                }
            }
            // end

        }
        public void Task7(int[,] matrix, int[] array)
        {

            // code here
            int n = matrix.GetLength(0), m = matrix.GetLength(1), mx = 0;
            if (m == array.Length)
            {
                for (int i = 0; i < n; i++)
                {
                    if (matrix[mx, m - 2] < matrix[i, m - 2])
                    {
                        mx = i;
                    }
                }
                for (int j = 0; j < m; j++)
                {
                    matrix[mx, j] = array[j];
                }
            }
            // end

        }
        public void Task8(int[,] matrix)
        {

            // code here
            int n = matrix.GetLength(0), m = matrix.GetLength(1);
            for (int j=0; j < m; j++)
            {
                int mx = 0, sm = 0;
                for (int i=0;  i < n; i++)
                {
                    if (matrix[mx, j] <  matrix[i, j])
                    {
                        mx = i;
                    }
                }

                if (mx < n / 2)
                {
                    for (int i=mx+1; i < n; i++)
                    {
                        sm += matrix[i, j];
                    }
                    matrix[0, j] = sm;
                }

            }
            // end

        }
        public void Task9(int[,] matrix)
        {

            // code here
                int n = matrix.GetLength(0), m = matrix.GetLength(1), i=0, mx1 = 0, mx2 = 0;
                while (i < n-1)
                {
                    mx1 = 0;
                    mx2 = 0;
                    for (int j = 0; j < m; j++)
                    {
                        if (matrix[i, mx1] < matrix[i, j])
                        {
                            mx1 = j;
                        }
                    }
                    i++;
                    for (int j = 0; j < m; j++)
                    {
                        if (matrix[i, mx2] < matrix[i, j])
                        {
                            mx2 = j;
                        }
                    }
                    (matrix[i-1, mx1], matrix[i, mx2]) = (matrix[i, mx2], matrix[i-1, mx1]);
                    i++;
                }
            // end

        }
        public void Task10(int[,] matrix)
        {

            // code here
            if (matrix.GetLength(0) == matrix.GetLength(1))
            {
                int n = matrix.GetLength(0), mx = 0;
                for (int i=0; i < n; i++)
                {
                    if (matrix[i, i] > matrix[mx, mx])
                    {
                        mx = i;
                    }
                }
                for (int i = 0; i < mx; i++)
                {
                    for (int j = i+1;  j < n; j++)
                    {
                        matrix[i, j] = 0;
                    }
                }
            }
            // end

        }
        public void Task11(int[,] matrix)
        {

            // code here
            int n = matrix.GetLength(0), m = matrix.GetLength(1), c = 0;
            int[] ind = new int[n], count = new int[n];
            for (int i = 0; i < n; i++)
            {
                ind[i] = i;
                c = 0;
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        c++;
                    }
                }
                count[i] = c;
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n - 1; j++)
                {
                    if (count[j] < count[j + 1])
                    {
                        (count[j], count[j + 1]) = (count[j + 1], count[j]);
                        (ind[j], ind[j + 1]) = (ind[j + 1], ind[j]);
                    }
                }
            }
            int[,] new_m = new int[n, m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    new_m[i, j] = matrix[ind[i], j];
                }
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    matrix[i, j] = new_m[i, j];
                }
            }
            // end

        }
        public int[][] Task12(int[][] array)
        {
            int[][] answer = null;

            // code here
            double sr = 0, count = 0, s = 0;
            int len = array.Length;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    sr += array[i][j];
                    count++;
                }
            }
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    sr += array[i][j];
                    count++;
                }
            }

            for (int i = 0; i < array.GetLength(0); i++)
            {
                s = 0;
                for (int j = 0; j < array[i].Length; j++)
                {
                    s += array[i][j];
                }
                if (s * count < sr * array[i].Length)
                {
                    len--;
                }
            }

            answer = new int[len][];
            int q = 0;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                s = 0;
                for (int j = 0; j < array[i].Length; j++)
                {
                    s += array[i][j];
                }
                if (s * count >= sr * array[i].Length)
                {
                    answer[q] = new int[array[i].Length];
                    for (int j = 0; j < array[i].Length; j++)
                    {
                        answer[q][j] = array[i][j];
                    }
                    q++;
                }
            }
            // end

            return answer;
        }
    }
}
