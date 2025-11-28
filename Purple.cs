using System.Diagnostics.CodeAnalysis;
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
            answer = new int[matrix.GetLength(1)];
            for (int i = 0; i<matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < 0)
                    {
                        answer[j] += 1;
                    }
                }
            }
            // end

            return answer;
        }
        public void Task2(int[,] matrix)
        {

            // code here
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int mn =  matrix[i, 0];
                int ind = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i,j] < mn)
                    {
                        mn = matrix[i, j];
                        ind = j;
                    }
                }
                for (int j = ind; j > 0; j--)
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
            answer = new int[matrix.GetLength(0), matrix.GetLength(1) + 1];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int mx = matrix[i, 0];
                int ind = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > mx)
                    {
                        mx = matrix[i, j];
                        ind = j;
                    }
                }
                for (int j = 0; j <=ind; j++)
                {
                    answer[i, j] = matrix[i, j];
                }
                answer[i, ind + 1] = mx;
                for (int j = ind+2; j < matrix.GetLength(1)+1; j++)
                {
                    answer[i, j] = matrix[i, j-1];
                }
                matrix[i, 0] = mx;
            }
            // end

            return answer;
        }
        public void Task4(int[,] matrix)
        {

            // code here
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int mx = matrix[i, 0];
                int ind = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > mx)
                    {
                        mx = matrix[i, j];
                        ind = j;
                    }
                }
                int sum = 0;
                int count = 0;
                for (int j = ind+1; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i,j] > 0)
                    {
                        sum += matrix[i, j];
                        count++;
                    }
                }
                int sr = -1;
                if (sum > 0)
                {
                    sr = sum / count;
                }


                for (int j = 0; j < ind; j++)
                    {
                        if (matrix[i, j] < 0)
                        {
                            if (sr != -1)
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
            if (k < 0 || k >= matrix.GetLength(1))
            {
                return;
            }

            
            int[] a = new int[matrix.GetLength(0)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int mx = matrix[i, 0];
                int ind = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > mx)
                    {
                        mx = matrix[i, j];
                        ind = j;
                    }
                }
                a[a.Length - i-1] = mx;
            }
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                matrix[i, k] = a[i];

            }
                // end

            }
        public void Task6(int[,] matrix, int[] array)
        {

            // code here
            if (array == null)
            {
                return;
            }
            if (array.Length != matrix.GetLength(1))
            {
                return;
            }
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                int mx = matrix[0, i];
                int ind = 0;
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    if (matrix[j, i] > mx)
                    {
                        mx = matrix[j, i];
                        ind = j;
                    }
                }
                if (mx < array[i]) {
                    matrix[ind, i] = array[i];
                }
            }
            // end

        }
        public void Task7(int[,] matrix)
        {

            // code here
            int[,] ans = new int[matrix.GetLength(0), matrix.GetLength(1)];
            int[] mins = new int[matrix.GetLength(0)];
            int[] inds = new int[matrix.GetLength(0)];
            for (int i = 0; i< matrix.GetLength(0); i++)
            {
                inds[i] = i;
            }
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int mn = matrix[i, 0];
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < mn)
                    {
                        mn = matrix[i, j];
                    }
                }
                mins[i] = mn;
            }
            for (int i = 0; i<matrix.GetLength(0); i++)
            {
                for (int j = 0; j< matrix.GetLength(0)-i-1; j++)
                {
                    if (mins[j] < mins[j + 1])
                    {
                        (mins[j], mins[j+1]) = (mins[j+1], mins[j]);
                        (inds[j], inds[j + 1]) = (inds[j + 1], inds[j]);
                    }
                }
            }
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j< matrix.GetLength(1); j++)
                {
                    ans[i, j] = matrix[inds[i], j];
                }
            }
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = ans[i, j];
                }
            }
                // end

            }
        public int[] Task8(int[,] matrix)
        {
            int[] answer = null;

            // code here
            if (matrix == null || matrix.GetLength(0)!=matrix.GetLength(1))
            {
                return null;
            }
            int n = matrix.GetLength(0);
            answer = new int[2 * n - 1];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0;j < n; j++)
                {
                    answer[j - i + n - 1] += matrix[i, j];
                }
            }
           // end

            return answer;
        }
        public void Task9(int[,] matrix, int k)
        {

            // code here
            if (matrix == null) return;

            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            if (n == 0 || m == 0) return;
            if (n != m) return;
            if (k < 0 || k >= n) return;


            int imax = 0, jmax = 0;
            int maxAbs = Math.Abs(matrix[0, 0]);

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    int a = Math.Abs(matrix[i, j]);
                    if (a > maxAbs)
                    {
                        maxAbs = a;
                        imax = i;
                        jmax = j;
                    }
                }
            }

            if (jmax != k)
            {
                if (jmax > k)
                {

                    for (int col = jmax; col > k; col--)
                    {
                        for (int row = 0; row < n; row++)
                        {
                            int temp = matrix[row, col];
                            matrix[row, col] = matrix[row, col - 1];
                            matrix[row, col - 1] = temp;
                        }
                    }
                }
                else
                {

                    for (int col = jmax; col < k; col++)
                    {
                        for (int row = 0; row < n; row++)
                        {
                            int temp = matrix[row, col];
                            matrix[row, col] = matrix[row, col + 1];
                            matrix[row, col + 1] = temp;
                        }
                    }
                }
            }


            jmax = k;


            if (imax != k)
            {
                if (imax > k)
                {

                    for (int row = imax; row > k; row--)
                    {
                        for (int col = 0; col < n; col++)
                        {
                            int temp = matrix[row, col];
                            matrix[row, col] = matrix[row - 1, col];
                            matrix[row - 1, col] = temp;
                        }
                    }
                }
                else
                {

                    for (int row = imax; row < k; row++)
                    {
                        for (int col = 0; col < n; col++)
                        {
                            int temp = matrix[row, col];
                            matrix[row, col] = matrix[row + 1, col];
                            matrix[row + 1, col] = temp;
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
            if (A == null || B == null)
                return null;
            int n1 = A.GetLength(0);
            int m1 = A.GetLength(1);
            int n2 = B.GetLength(0);
            int m2 = B.GetLength(1);
            answer = new int[n1, m2];
            if (m1 != n2)
            {
                return null;
            }
            for (int i = 0; i<  n1 ; i++)
            {
                for (int j = 0; j <m2 ; j++)
                {
                    for (int k = 0; k < m1; k++)
                    {
                        answer[i, j] += A[i, k] * B[k, j];
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
            for (int i = 0; i<matrix.GetLength(0); i++)
            {
                int count = 0;
                for (int j = 0; j<matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > 0) {  count++; }
                }
                answer[i] = new int[count];
                int ind = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > 0) { answer[i][ind++] = matrix[i, j]; }
                }
            }
            // end

            return answer;
        }
        public int[,] Task12(int[][] array)
        {
            int[,] answer = null;

            // code here
            if (array == null) { return null; }
            int count = 0;
            for (int i = 0; i<array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    count++;
                }
            }
            int[] pr = new int[count];
            int ind = 0;
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    pr[ind++] = array[i][j];
                }
            }
            int n = 1;
            while (count > n*n) n++;
            answer = new int[n, n];
            ind = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j<n; j++)
                {
                    if (ind < count)
                    {
                        answer[i, j] = pr[ind++];
                    }
                    
                }
            }
            // end

            return answer;
        }
    }
}