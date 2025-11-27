using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;

namespace Lab5
{
    public class Purple
    {
        public int[] Task1(int[,] matrix)
        {

            // code here
            int[] answer = new int[matrix.GetLength(1)];
            for (int i = 0; i < matrix.GetLength(1); ++i)
            {
                int k = 0;
                for (int j = 0; j < matrix.GetLength(0); ++j)
                {
                    k += (matrix[j, i] < 0) ? 1 : 0;
                }
                answer[i] = k;
                k = 0;
            }
            // end

            return answer;
        }
        public void Task2(int[,] matrix)
        {

            // code here
            for (int i = 0; i < matrix.GetLength(0); ++i)
            {
                int mini = 1000000000, mini_i = -1;
                for (int j = 0; j < matrix.GetLength(1); ++j)
                {
                    if (matrix[i, j] < mini)
                    {
                        mini = matrix[i, j];
                        mini_i = j;
                    }
                }
                if (mini_i != 0)
                {
                    int h = mini_i;
                    while (h > 0)
                    {
                        matrix[i, h] = matrix[i, h - 1];
                        --h;
                    }
                    matrix[i, 0] = mini;
                }
            }
            // end

        }
        public int[,] Task3(int[,] matrix)
        {

            // code here
            int n = matrix.GetLength(0), m = matrix.GetLength(1);
            int[,] answer = new int[n, m + 1];
            for (int i = 0; i < n; ++i)
            {
                int maxi = matrix[i, 0], maxi_i = 0;
                for (int j = 1; j < m; ++j)
                {
                    if (maxi < matrix[i, j])
                    {
                        maxi = matrix[i, j];
                        maxi_i = j;
                    }
                }
                for (int j = 0; j <= maxi_i; ++j)
                {
                    answer[i, j] = matrix[i, j];
                }
                answer[i, maxi_i + 1] = maxi;
                for (int j = maxi_i + 2; j <= m; ++j)
                {
                    answer[i, j] = matrix[i, j - 1];
                }
            }
            // end

            return answer;
        }
        public void Task4(int[,] matrix)
        {

            // code here
            int n = matrix.GetLength(0), m = matrix.GetLength(1);
            for (int i = 0; i < n; ++i)
            {
                int maxi = matrix[i, 0], maxi_i = 0;
                for (int j = 0; j < m; ++j)
                {
                    if (maxi < matrix[i, j])
                    {
                        maxi = matrix[i, j];
                        maxi_i = j;
                    }
                }
                int k = 0, sum = 0;
                for (int j = maxi_i + 1; j < m; ++j)
                {
                    if (matrix[i, j] > 0)
                    {
                        ++k;
                        sum += matrix[i, j];
                    }
                }
                if (k == 0)
                {
                    continue;
                }
                double arifmm = (double)sum / k;
                int arifm = (int)arifmm;
                for (int j = 0; j < maxi_i; ++j)
                {
                    matrix[i, j] = (matrix[i, j] < 0) ? arifm : matrix[i, j];
                }
            }
            // end
        }
        public void Task5(int[,] matrix, int k)
        {

            // code here
            int n = matrix.GetLength(0), m = matrix.GetLength(1);
            int[] b = new int[n];
            if (k >= 0 && k < m)
            {
                for (int i = 0; i < n; ++i)
                {
                    int maxi = matrix[i, 0];
                    for (int j = 1; j < m; ++j)
                    {
                        maxi = Math.Max(maxi, matrix[i, j]);
                    }
                    b[i] = maxi;
                }
                for (int i = 0; i < n; ++i)
                {
                    matrix[i, k] = b[n - i - 1];
                }
            }
            // end

        }
        public void Task6(int[,] matrix, int[] array)
        {

            // code here
            int n = matrix.GetLength(0), m = matrix.GetLength(1), na = array.Length;
            if (m == na)
            {
                for (int j = 0; j < m; ++j)
                {
                    int maxi = matrix[0, j], maxi_i = 0;
                    for (int i = 1; i < n; ++i)
                    {
                        if (maxi < matrix[i, j])
                        {
                            maxi = matrix[i, j];
                            maxi_i = i;
                        }
                    }
                    if (array[j] > maxi)
                    {
                        matrix[maxi_i, j] = array[j];
                    }
                }

            }
            // end

        }
        public void Task7(int[,] matrix)
        {

            // code here
            int n = matrix.GetLength(0), m = matrix.GetLength(1);
            int[] a = new int[n];
            int[] b = new int[n];
            for (int i = 0; i < n; ++i)
            {
                int mini = matrix[i, 0];
                for (int j = 0; j < m; ++j)
                {
                    mini = Math.Min(mini, matrix[i, j]);
                }
                a[i] = mini;
                b[i] = i;
            }
            for (int i = 0; i < n - 1; ++i)
            {
                for (int j = 0; j < n - 1; ++j)
                {
                    if (a[j] < a[j + 1])
                    {
                        (a[j], a[j + 1]) = (a[j + 1], a[j]);
                        (b[j], b[j + 1]) = (b[j + 1], b[j]);
                    }
                }
            }
            int[,] m_new = new int[n, m];
            for (int i = 0; i < n; ++i)
            {
                int x = b[i];
                for (int j = 0; j < m; ++j)
                {
                    m_new[i, j] = matrix[x, j];
                }
            }
            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < m; ++j)
                {
                    matrix[i, j] = m_new[i, j];
                }
            }
            // end

        }
        public int[] Task8(int[,] matrix)
        {

            // code here
            int n = matrix.GetLength(0);
            if (n == 0 || n != matrix.GetLength(1))
            {
                return null;
            }
            if (n == 1)
            {
                int[] ans = new int[1];
                ans[0] = matrix[0, 0];
                return ans;
            }
            int[] answer = new int[2 * n - 1];
            int h = 0;
            for (int k = n - 1; k >= 0; --k)
            {
                int sum = 0;
                for (int i = k; i < n; ++i)
                {
                    sum += matrix[i, i - k];
                }
                answer[h++] = sum;
            }
            for (int k = 1; k < n; ++k)
            {
                int sum = 0;
                for (int i = 0; i < n - k; ++i)
                {
                    sum += matrix[i, i + k];
                }
                answer[h++] = sum;
            }
            // end

            return answer;
        }
        public void Task9(int[,] matrix, int k)
        {

            // code here
            if (matrix.GetLength(0) != matrix.GetLength(1) || (k >= matrix.GetLength(0)))
            {
                return;
            }
            int n = matrix.GetLength(0), maxi = matrix[0, 0], m_i = 0, m_j = 0;
            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    if (Math.Abs(maxi) <  Math.Abs(matrix[i, j]))
                    {
                        maxi = matrix[i, j];
                        m_i = i;
                        m_j = j;
                    }
                }
            }
            if (m_i < k)
            {
                for (int i = k; i > m_i; --i)
                {
                    for (int j = 0; j < n; ++j)
                    {
                        (matrix[i, j], matrix[i - 1, j]) = (matrix[i - 1, j], matrix[i, j]);
                    }
                }
            }
            else if (m_i > k)
            {
                for (int i = m_i; i > k; --i)
                {
                    for (int j = 0; j < n; ++j)
                    {
                        (matrix[i, j], matrix[i - 1, j]) = (matrix[i - 1, j], matrix[i, j]);
                    }
                }
            }
            if (m_j < k)
            {
                for (int j = k; j > m_j; --j)
                {
                    for (int i = 0; i < n; ++i)
                    {
                        (matrix[i, j], matrix[i, j - 1]) = (matrix[i, j - 1], matrix[i, j]);
                    }
                }
            }
            else if (m_j > k)
            {
                for (int j = m_j; j > k; --j)
                {
                    for (int i = 0; i < n; ++i)
                    {
                        (matrix[i, j], matrix[i, j - 1]) = (matrix[i, j - 1], matrix[i, j]);
                    }
                }
            }
            // end

        }
        public int[,] Task10(int[,] A, int[,] B)
        {

            // code here
            if (A.GetLength(1) != B.GetLength(0))
            {
                return null;
            }
            int[,] answer = new int[A.GetLength(0), B.GetLength(1)];
            for (int i = 0; i < A.GetLength(0); ++i)
            {
                for (int j = 0; j < B.GetLength(1); ++j)
                {
                    int sum = 0;
                    for (int x = 0; x < A.GetLength(1); ++x)
                    {
                        sum += A[i, x] * B[x, j];
                    }
                    answer[i, j] = sum;
                }
            }
            // end

            return answer;
        }
        public int[][] Task11(int[,] matrix)
        {

            // code here
            int n = matrix.GetLength(0), m = matrix.GetLength(1);
            int[][] answer = new int[n][];
            for (int i = 0; i < n; ++i)
            {
                int k = 0;
                for (int j = 0; j < m; ++j)
                {
                    k += (matrix[i, j] > 0) ? 1 : 0;
                }
                answer[i] = new int[k];
                for (int j = 0, h = 0; j < m; ++j)
                {
                    if (matrix[i, j] > 0)
                    {
                        answer[i][h++] = matrix[i, j];
                    }
                }
            }
            // end

            return answer;
        }
        public int[,] Task12(int[][] array)
        {

            // code here
            int n = array.Length, m = 0;
            for (int i = 0; i < n; ++i)
            {
                m += array[i].Length;
            }
            n = (int)Math.Ceiling(Math.Pow(m, 0.5));
            int[,] answer = new int[n, n];
            int h = 0;
            for (int i = 0; i < array.Length; ++i)
            {
                for (int j = 0; j < array[i].Length; ++j, ++h)
                {
                    answer[h / n, h % n] = array[i][j];
                }
            }
            // end

            return answer;
        }
    }
}