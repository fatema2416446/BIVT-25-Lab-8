using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;

namespace Lab5
{
    public class Purple
    {
        public int[] Task1(int[,] matrix)
        {
            int[] answer = null;
            answer = new int[matrix.GetLength(1)];
            // code here
            int count = 0;
            for (int i=0; i<matrix.GetLength(1); i++)
            {
                count = 0;
                for (int j=0; j<matrix.GetLength(0); j++)
                {
                    if (matrix[j,i] < 0)
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
            for (int i = 0; i < matrix.GetLength(0); i++) 
            {
                int minn = 100000000;
                int min_ind = 0;
                for (int j=0; j<matrix.GetLength(1); j++)
                {
                    if (matrix[i,j] < minn)
                    {
                        minn = matrix[i,j];
                        min_ind = j;
                    }
                }
                int last = matrix[i, 0];
                for (int j=0; j<min_ind+1; j++)
                {
                    if (j == 0)
                    {
                        matrix[i, j] = minn;
                    } else
                    {
                        int temp = last;
                        last = matrix[i, j];
                        matrix[i, j] = temp;
                    }
                }
            }
            // end

        }
        public int[,] Task3(int[,] matrix)
        {
            int[,] answer = null;

            answer = new int[matrix.GetLength(0), matrix.GetLength(1)+1];

            // code here
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int max_ind = 0;
                int maxx = -10000000;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i,j] > maxx)
                    {
                        maxx = matrix[i, j];
                        max_ind = j;
                    }
                }
                answer[i, 0] = matrix[i, 0];
                bool t = false;
                for (int j = 0; j < matrix.GetLength(1) + 1; j++)
                {
                    if (!t)
                    {
                        if (j == max_ind + 1)
                        {
                            t = true;
                            answer[i, j] = maxx;
                        } else
                        {
                            answer[i, j] = matrix[i, j];
                        }
                    } else
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
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int max_ind = 0;
                int maxx = -10000000;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > maxx)
                    {
                        maxx = matrix[i, j];
                        max_ind = j;
                    }
                }
                int summ = 0;
                int cnt = 0;
                for (int j = max_ind + 1; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        summ += matrix[i, j]; cnt++;
                    }
                }
                if (cnt > 0) {
                    int sr = summ / cnt;
                    for (int j = 0; j < max_ind; j++)
                    {
                        if (matrix[i,j] < 0)
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
            int[] array = new int[matrix.GetLength(0)];
            int c = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int maxx = -100000000;
                int max_ind = 0;
                for (int j=0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i,j] > maxx)
                    {
                        maxx = matrix[i, j];
                        max_ind = j;
                    }
                }
                array[c] = maxx;
                c++;
            }
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (i < array.Length && k >= 0 && k < matrix.GetLength(1))
                {
                    matrix[i, k] = array[array.Length - 1 - i];
                }
            }
            // end

        }
        public void Task6(int[,] matrix, int[] array)
        {

            // code here
            if (array.Length == matrix.GetLength(1))
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    int maxx = -100000000;
                    int max_ind = 0;
                    for (int i = 0; i < matrix.GetLength(0); i++)
                    {
                        if (matrix[i, j] > maxx)
                        {
                            maxx = matrix[i, j];
                            max_ind = i;
                        }
                    }
                    if (j < array.Length)
                    {
                        if (array[j] > maxx)
                        {
                            matrix[max_ind, j] = array[j];
                        }
                    }
                }
            }

            // end

        }
        public void Task7(int[,] matrix)
        {

            // code here
            int[] array = new int[matrix.GetLength(0)];
            for (int i=0; i < matrix.GetLength(0); i++)
            {
                int min = matrix[i, 0];
                for (int j = 1; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i,j] < min)
                    {
                        min = matrix[i, j];
                    }
                }
                array[i] = min;
            }
            for (int i = 0; i < matrix.GetLength(0) - 1; i++)
            {
                for (int j = 0; j < matrix.GetLength(0) - 1 - i; j++)
                {
                    if (array[j] < array[j + 1])
                    {
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                        for (int k = 0; k <  matrix.GetLength(1); k++)
                        {
                            int t = matrix[j, k];
                            matrix[j, k] = matrix[j + 1, k];
                            matrix[j + 1, k] = t;
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
                answer = new int[2 * (matrix.GetLength(0)-1) + 1];
                int c = 0;
                for (int i = matrix.GetLength(0) - 1; i >= 0-matrix.GetLength(0); i--)
                {
                    int summ = 0;
                    for (int j = 0; j < matrix.GetLength(0); j++)
                    {
                        if (i + j >= 0 &&  i + j < matrix.GetLength(0) && j >= 0 && j < matrix.GetLength(0))
                        {
                            summ += matrix[i + j, j];
                        }
                    }
                    if (c < answer.Length)
                    {
                        answer[c] = summ;
                        c++;
                    }
                }

            }
            // end

            return answer;
        }
        public void Task9(int[,] matrix, int k)
        {

            // code here

            int n = matrix.GetLength(0);
            int maxx = 0;
            int maxi = 0;
            int maxj = 0;
            if (matrix.GetLength(0) == matrix.GetLength(1))
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (Math.Abs(matrix[i,j]) > maxx)
                        {
                            maxx = Math.Abs(matrix[i, j]);
                            maxi = i;
                            maxj = j;
                        }
                    }
                }
                int[,] new_matrix = new int[n, n];
                int r = 0;
                for (int i=0; i<n; i++)
                {
                    if (i == maxi)
                    {
                        continue;
                    }
                    if (r == k)
                    {
                        r++;
                    }
                    for (int j = 0; j < n; j++)
                    {
                        new_matrix[r, j] = matrix[i, j];
                    }
                    r++;
                }
                for (int j=0; j<n; j++)
                {
                    new_matrix[k, j] = matrix[maxi, j];
                }
                int[,] new2_matrix = new int[n, n];
                r = 0;
                for (int j=0; j<n; j++)
                {
                    if (j == maxj)
                    {
                        continue;
                    }
                    if (r == k)
                    {
                        r++;
                    }
                    for (int i = 0; i < n; i++)
                    {
                        new2_matrix[i, r] = new_matrix[i, j];
                    }
                    r++;
                }
                for (int i=0; i < n; i++)
                {
                    new2_matrix[i, k] = new_matrix[i, maxj];
                }

                for (int i=0; i < n; i++)
                {
                    for (int j=0; j<n; j++)
                    {
                        matrix[i, j] = new2_matrix[i, j];
                    }
                }
            }
            // end

        }
        public int[,] Task10(int[,] A, int[,] B)
        {
            int[,] answer = null;

            // code here
            if (A.GetLength(1) == B.GetLength(0))
            {
                answer = new int[A.GetLength(0), B.GetLength(1)];
                for (int i=0; i < A.GetLength(0); i++)
                {
                    for (int j = 0; j < B.GetLength(1); j++)
                    {
                        int summ = 0;
                        for (int k = 0; k < A.GetLength(1); k++)
                        {
                            summ += A[i, k] * B[k, j];
                        }
                        answer[i, j] = summ;
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
            answer = new int[matrix.GetLength(0)][];
            for (int i =0; i < matrix.GetLength(0); i++)
            {
                int count = 0;
                for (int j=0; j< matrix.GetLength(1); j++)
                {
                    if (matrix[i,j] > 0)
                    {
                        count++;
                    }
                }
                answer[i] = new int[count];
                int ind = 0;
                for (int j=0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i,j] > 0)
                    {
                        answer[i][ind] = matrix[i,j];
                        ind++;
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
            int n = (int)Math.Ceiling(Math.Sqrt(count));
            answer = new int[n, n];
            int m_i = 0;
            int m_j = 0;
            for (int i = 0; i<array.Length; i++)
            {
                for (int j =0; j < array[i].Length; j++)
                {
                    answer[m_i, m_j] = array[i][j];
                    m_j++;
                    if (m_j >= n)
                    {
                        m_j = 0;
                        m_i++;
                    }
                }
            }
            // end

            return answer;
        }
    }
}