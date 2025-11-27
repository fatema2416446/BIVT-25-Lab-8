using System.Linq;
using System.Runtime.InteropServices;

namespace Lab5
{
    public class Green
    {
        public int[] Task1(int[,] matrix)
        {
            int[] answer = null;
            // code here
            int mi = int.MaxValue;
            int k = 0;
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            answer = new int[n];
            for (int i = 0;i<n;i++)
            {
                mi = int.MaxValue;
                for (int j = 0;j<m;j++)
                {
                    if (matrix[i,j]< mi)
                    {
                        mi = matrix[i,j];
                        k = j;
                    }
                }
                answer[i] = k;
            }
            // end
            return answer;
        }
        public void Task2(int[,] matrix)
        {
            // code here
            int ma = int.MinValue;
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            int[] a = new int[n];
            for (int i = 0; i < n; i++)
            {
                ma = int.MinValue;
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] > ma)
                    {
                        ma = matrix[i, j];
                    }
                }
                a[i] = ma;
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if ((matrix[i, j] < a[i])&&(matrix[i, j] <0))
                    {
                        matrix[i, j] = (int)Math.Floor((double)matrix[i, j]/a[i]);
                    }
                    if (matrix[i, j] == a[i])
                    {
                        break;
                    }
                }
            }
            // end
        }
        public void Task3(int[,] matrix, int k)
        {
            // code here
            int ma = int.MinValue;
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            if (n == m)
            {
                int ind = 0;
                for (int i = 0; i < n; i++)
                {
                    if (matrix[i, i] > ma)
                    {
                        ma = matrix[i, i];
                        ind = i;
                    }
                }
                if ((k != ind) && (k >= 0) && (k < n))
                {
                    for (int j = 0; j < n; j++)
                    {
                        (matrix[j, ind], matrix[j, k]) = (matrix[j, k], matrix[j, ind]);
                    }
                }
            }
            // end
        }
        public void Task4(int[,] matrix)
        {
            // code here
            int ma = int.MinValue;
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            if (n == m)
            {
                int ind = 0;
                for (int i = 0; i < n; i++)
                {
                    if (matrix[i, i] > ma)
                    {
                        ma = matrix[i, i];
                        ind = i;
                    }
                }
                int[] a = new int[n];
                for (int i = 0;i<n;i++)
                {
                    a[i] = matrix[ind,i];
                }
                for (int i=0;i<m;i++)
                {
                    matrix[ind, i] = matrix[i, ind];
                }
                for (int i =0;i<n; i++)
                {
                    matrix[i, ind] = a[i];
                }
                
            }
            // end
        }
        public int[,] Task5(int[,] matrix)
        {
            int[,] answer = null;
            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            int ind = 0;
            int s = 0;
            int ma = 0;
            for (int i = 0; i<n;i++)
            {
                s = 0; 
                for (int j = 0; j < m;j++)
                {
                    if (matrix[i,j]>0)
                    {
                        s += matrix[i, j];
                    }
                }
                if (s > ma)
                {
                    ma = s;
                    ind = i;
                }
            }
            answer = new int[n - 1, m];
            for (int i = 0;i<n-1;i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (i<ind)
                    {
                        answer[i,j] = matrix[i,j];
                    }
                    if (i>=ind)
                    {
                        answer[i,j]= matrix[i+1,j];
                    }
                }
            }
            // end
            return answer;
        }
        public void Task6(int[,] matrix)
        {
            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            int ma = 0;
            int mak = 0;
            int mi = 100000;
            int mik = 0;
            int k = 0;
            for (int i = 0;i<n;i++)
            {
                k = 0; 
                for (int j = 0;j<m;j++)
                {
                    if (matrix[i, j] < 0)
                        k += 1;
                }
                if (k>ma)
                {
                    ma = k;
                    mak = i;
                }
                if (k<mi)
                {
                    mi = k; 
                    mik = i;
                }
            }
            if (ma != mi)
            {
                for (int i = 0; i < m; i++)
                {
                    (matrix[mak, i], matrix[mik, i]) = (matrix[mik, i], matrix[mak, i]);
                }
            }
                    // end
        }
        public int[,] Task7(int[,] matrix, int[] array)
        {
            int[,] answer = null;
            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            int mi = int.MaxValue;
            int ind = 0;
            for (int i =0; i<n;i++)
            {
                for(int j = 0; j<m;j++)
                {
                    if(matrix[i, j] < mi)
                    {
                        mi = matrix[i, j];
                        ind = j;
                    }
                }
            }
            
            if (array.Length == n)
            {
                answer = new int[n, m + 1];
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        if (j <= ind)
                        {
                            answer[i, j] = matrix[i, j];
                        }
                        if (j == ind)
                        {
                            answer[i, j + 1] = array[i];
                        }
                        if (j > ind)
                        {
                            answer[i, j + 1] = matrix[i, j];
                        }
                    }
                }
            }
            else
            {
                return matrix;
            }
                // end
                return answer;
        }
        public void Task8(int[,] matrix)
        {
            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            int ma = int.MinValue;
            int ko = 0;
            int kp = 0;
            int inds = 0;
            for(int j = 0; j<m;j++)
            {
                ma = int.MinValue;
                inds = 0;
                ko = 0;
                kp = 0;
                for (int i = 0;i<n;i++)
                {
                    if (matrix[i, j] < 0)
                        ko++;
                    if (matrix[i, j] > 0)
                        kp++;
                    if (matrix[i,j]>ma)
                    {
                        ma = matrix[i, j];
                        inds = i;
                    }
                }
                if (ko>kp)
                {
                    matrix[inds, j] = inds;
                }
                if (ko<kp)
                {
                    matrix[inds, j] = 0;
                }
            }
            // end
        }
        public void Task9(int[,] matrix)
        {
            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            if (n == m)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        if ((i == 0) || (j == 0) || (j == n - 1) || (i == n - 1))
                            matrix[i, j] = 0;
                    }
                }
            }
            // end
        }
        public (int[] A, int[] B) Task10(int[,] matrix)
        {
            int[] A = null, B = null;
            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            if (n == m)
            {
                A= new int[(int)(n * n - n) / 2 + n];
                B = new int[(int)(n * n - n) / 2];
                int k = 0;
                int d = 0;
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        if (j - i >= 0)
                        {
                            A[k] = matrix[i, j];
                            k++;
                        }
                        else
                        {
                            B[d] = matrix[i, j];
                            d++;
                        }
                    }
                }
            }
            // end
            return (A, B);
        }
        public void Task11(int[,] matrix)
        {
            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            int i = 1;
            for (int j = 0; j < m; j++)
            {
                if (j % 2 ==1)
                {
                    i = 1;
                    while (i < n)
                    {
                        if ((i == 0) || (matrix[i, j] >= matrix[i - 1, j]))
                            i++;
                        else
                        {
                            (matrix[i, j], matrix[i - 1, j]) = (matrix[i-1, j], matrix[i, j]);
                            i--;
                        }

                    }
                }
                if (j % 2 == 0)
                {
                    i = 1;
                    while (i < n)
                    {
                        if ((i == 0) || (matrix[i, j] <=matrix[i - 1, j]))
                            i++;
                        else
                        {
                            (matrix[i, j], matrix[i - 1, j]) = (matrix[i - 1, j], matrix[i, j]);
                            i--;
                        }

                    }
                }
            }
            // end
        }
        public void Task12(int[][] array)
        {
            // code here
            int n = array.Length;
            int i = 1;
            int s = 0;
            int sv = 0;
            int d = 0;
            int l = 0;
            while (i < n)
            {
                s = 0;
                if (i == 0)
                    i++;
                sv = 0;
                l = array[i].Length;
                d = array[i - 1].Length;
                if (l < d)
                {
                    i++;
                }
                else if (l == d)
                {
                    for (int j = 0; j < l; j++)
                    {
                        s += array[i][j];
                    }
                    for (int j = 0; j < d; j++)
                    {
                        sv += array[i - 1][j];
                    }
                    if (sv < s)
                    {
                        (array[i], array[i - 1]) = (array[i - 1], array[i]);
                        i--;
                    }
                    else
                    {
                        i++;
                    }
                }
                else
                {
                    (array[i], array[i - 1]) = (array[i - 1], array[i]);
                    i--;
                }
            }
            // end
        }
    }
}
