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
            int n = matrix.GetLength(0);
            int k = matrix.GetLength(1);

            answer = new int[k];
            if (k < 2)
            {
                ;
            }
            for (int i = 0; i < k; i++)
            {
                int count = 0;
                for (int j = 0; j < n; j++)
                {
                    if (matrix[j, i] < 0)
                    {
                        count++;
                    }
                }
                answer[i] = count;
            }
            // end

            return answer;
        }
        public void Task2(int[,] matrix)
        {

            // code here
            int n = matrix.GetLength(0);
            int k = matrix.GetLength(1);
            for (int i = 0; i < n; i++)
            {
                int mn = 10000000;
                for (int j = 0; j < k; j++)
                {
                    if (matrix[i, j] < mn)
                    {
                        mn = matrix[i, j];
                    }
                }
                int index = -1;
                for (int j = 0; j < k; j++)
                {
                    if (matrix[i, j] == mn)
                    {
                        index = j;
                        break;
                    }
                }
                for (int j = index; j > 0; j--)
                {
                    matrix[i, j] = matrix[i, j - 1];
                }
                matrix[i, 0] = mn;
            }
            // end

        }
        public int[,] Task3(int[,] matrix)
        {
            int[,] answer = null;

            // code here
            int n = matrix.GetLength(0);
            int k = matrix.GetLength(1);
            answer = new int[n, k + 1];

            for (int i = 0; i < n; i++)
            {
                int mx = -100000000;
                for (int j = 0; j < k; j++)
                {
                    if (matrix[i, j] > mx)
                    {
                        mx = matrix[i, j];
                    }
                }
                int index = -1;
                for (int j = 0; j < k; j++)
                {
                    if (matrix[i, j] == mx)
                    {
                        index = j;
                        break;
                    }
                }
                for (int j = k; j >= 0; j--)
                {
                    if (j <= index)
                    {
                        answer[i, j] = matrix[i, j];
                    }
                    else if (j == index + 1)
                    {
                        answer[i, j] = mx;
                    }
                    else
                    {
                        answer[i, j] = matrix[i, j - 1];
                    }
                }

            }
            // end

            return answer;
        }
        public void Task4(int[,] matrix)
        {

            // code here
            int n = matrix.GetLength(0);
            int k = matrix.GetLength(1);


            for (int i = 0; i < n; i++)
            {
                int mx = -100000000;
                for (int j = 0; j < k; j++)
                {
                    if (matrix[i, j] > mx)
                    {
                        mx = matrix[i, j];
                    }
                }
                int index = -1;
                for (int j = 0; j < k; j++)
                {
                    if (matrix[i, j] == mx)
                    {
                        index = j;
                        break;
                    }
                }
                int sum = 0;
                int count = 0;
                for (int j = index + 1; j < k; j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        sum += matrix[i, j];
                        count++;
                    }
                }
                if (count > 0)
                {
                    int srzn = sum / count;
                    for (int j = 0; j < index; j++)
                    {
                        if (matrix[i, j] < 0)
                        {
                            matrix[i, j] = srzn;
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
            int[] mxarr = new int[n];
            int l = n - 1;
            if (k < m)
            {
                for (int i = 0; i < n; i++)
                {
                    int mx = -100000000;
                    for (int j = 0; j < m; j++)
                    {
                        if (matrix[i, j] > mx)
                        {
                            mx = matrix[i, j];
                        }
                    }
                    mxarr[l] = mx;
                    l--;
                }
                for (int i = 0; i < n; i++)
                {
                    matrix[i, k] = mxarr[i];
                }
            }
            // end

        }
        public void Task6(int[,] matrix, int[] array)
        {

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            if (array.GetLength(0) == m)
            {
                for (int j = 0; j < m; j++)
                {
                    int mx = -100000000;
                    for (int i = 0; i < n; i++)
                    {
                        if (matrix[i, j] > mx)
                        {
                            mx = matrix[i, j];
                        }
                    }
                    int index = -1;
                    for (int i = 0; i < n; i++)
                    {
                        if (matrix[i, j] == mx)
                        {
                            if (matrix[i, j] < array[j])
                            {
                                matrix[i, j] = array[j];
                            }
                            break;
                        }
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
            int[] array = new int[n];
            for (int i = 0; i < n; i++)
            {
                int mn = 1000000000;
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] < mn)
                    {
                        mn = matrix[i, j];
                    }
                }
                array[i] = mn;
            }
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (array[j] < array[j + 1])
                    {
                        (array[j], array[j + 1]) = (array[j + 1], array[j]);
                        for (int k = 0; k < m; k++)
                        {

                            int p = matrix[j, k];
                            matrix[j, k] = matrix[j + 1, k];
                            matrix[j + 1, k] = p;
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
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            if (n == m)
            {


                answer = new int[2 * n - 1];
                int k = 0;
                for (int rowStart = n - 1; rowStart >= 0; rowStart--)
                {
                    int sum = 0;
                    int i = rowStart;
                    int j = 0;

                    while (i < n && j < n)
                    {
                        sum += matrix[i, j];
                        i++;
                        j++;
                    }
                    answer[k++] = sum;
                }
                for (int colStart = 1; colStart < n; colStart++)
                {
                    int sum = 0;
                    int i = 0;
                    int j = colStart;

                    while (i < n && j < n)
                    {
                        sum += matrix[i, j];
                        i++;
                        j++;
                    }
                    answer[k++] = sum;
                }
            }

            // end

            return answer;
        }
        public void Task9(int[,] matrix, int k)
        {

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            if (n == m)
            {

                int mx = -10000000;
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        if (Math.Abs(matrix[i, j]) > mx)
                        {
                            mx = Math.Abs(matrix[i, j]);
                        }
                    }
                }
                int ti = -1;
                int tj = -1;
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        if (Math.Abs(matrix[i, j]) == mx)
                        {
                            ti = i;
                            tj = j;
                            break;
                        }
                    }
                    if (ti != -1) break;
                }
                if (ti != k)
                {

                    if (ti < k)
                    {
                        for (int i = ti; i < k; i++)
                        {
                            for (int j = 0; j < m; j++)
                            {
                                (matrix[i, j], matrix[i + 1, j]) = (matrix[i + 1, j], matrix[i, j]);
                            }
                        }
                    }
                    else
                    {
                        for (int i = ti; i > k; i--)
                        {
                            for (int j = 0; j < m; j++)
                            {
                                (matrix[i, j], matrix[i - 1, j]) = (matrix[i - 1, j], matrix[i, j]);
                            }
                        }

                    }
                }
                if (tj != k)
                {
                    if (tj < k)
                    {

                        for (int j = tj; j < k; j++)
                        {
                            for (int i = 0; i < n; i++)
                            {
                                (matrix[i, j], matrix[i, j + 1]) = (matrix[i, j + 1], matrix[i, j]);
                            }
                        }
                    }
                    else
                    {
                        for (int j = tj; j > k; j--)
                        {
                            for (int i = 0; i < n; i++)
                            {
                                (matrix[i, j], matrix[i, j - 1]) = (matrix[i, j - 1], matrix[i, j]);
                            }
                        }
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
            int m1 = A.GetLength(1);
            int n2 = B.GetLength(0);
            int m2 = B.GetLength(1);

            if (m1 == n2)
            {
                answer = new int[n1, m2];
                for (int i = 0; i < n1; i++)
                {
                    for (int j = 0; j < m2; j++)
                    {
                        for (int k = 0; k < n2; k++)
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

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            answer = new int[n][];
            for (int i = 0; i < n; i++)
            {
                int count = 0;
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] <= 0)
                    {
                        count++;
                    }
                }
                answer[i] = new int[m - count];
                int l = 0;
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        answer[i][l++] = matrix[i, j];
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
            int count = 0;
            for (int i = 0; i < array.Length; i++)
            {
                count += array[i].Length;
            }
            int[] vr = new int[count];
            int u = 0;
            foreach (int[] to in array)
            {
                foreach (int t in to)
                {
                    vr[u++] = t;
                }
            }
            int n = (int)Math.Ceiling(Math.Sqrt(count));
            answer = new int[n, n];
            int l = 0;
            for (int i = 0; i < n && l < count; i++)
            {
                for (int j = 0; j < n && l < count; j++)
                {
                    answer[i, j] = vr[l];
                    l++;
                }
            }
            // end

            return answer;
        }
    }
}