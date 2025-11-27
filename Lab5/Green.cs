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

            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            answer = new int[n];
            for (int i = 0; i < n; i++)
            {
                int mi = int.MaxValue;
                int mik = -1;
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] < mi)
                    {
                        mi = matrix[i, j];
                        mik = j;
                    }
                }
                answer[i] = mik;
            }
            // end

            return answer;
        }
        public void Task2(int[,] matrix)
        {

            // code here

            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            for (int i = 0;i<n;i++)
            {
                int ma = int.MinValue;
                int mak = -1;
                for (int j = 0;j<m;j++)
                {
                    if (matrix[i,j] > ma)
                    {
                        ma = matrix[i,j];
                        mak = j;
                    }
                }
                for (int j = 0; j < mak; j++)
                {
                    if (matrix[i, j] < 0 )
                    {
                        matrix[i, j] = (int)Math.Floor(matrix[i, j] / (double)ma);
                    }
                }
            }
            // end

        }
        public void Task3(int[,] matrix, int k)
        {

            // code here

            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            if (n==m && k>-1 && k<n)
            {
                int ma = int.MinValue, mak = -1;
                for (int i = 0; i < n; i++)
                {
                    if (matrix[i, i] > ma)
                    {
                        ma = matrix[i, i];
                        mak = i;
                    }
                    if (matrix[i, n - i - 1] > ma)
                    {
                        ma = matrix[i, i];
                        mak = i;
                    }
                }
                if (mak != k)
                {
                    for (int i = 0; i < n; i++)
                    {
                        (matrix[i, mak], matrix[i, k]) = (matrix[i, k], matrix[i, mak]);
                    }
                }
            }
            // end

        }
        public void Task4(int[,] matrix)
        {

            // code here

            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            if (n == m)
            {
                int ma = int.MinValue, mak = -1;
                for (int i = 0; i < n; i++)
                {
                    if (matrix[i, i] > ma)
                    {
                        ma = matrix[i, i];
                        mak = i;
                    }
                }
                for (int i = 0;i<n; i++)
                {
                    (matrix[i, mak], matrix[mak,i]) = (matrix[mak, i],matrix[i,mak]);
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
            answer = new int[n - 1, m];
            int s = 0, s1 = 0, sk = -1;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        s1 += matrix[i, j];
                    }
                }
                if (s1 > s)
                {
                    s = s1;
                    sk = i;
                }
                s1 = 0;
            }
            for (int i = 0; i < n-1; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (i < sk)
                    {
                        answer[i, j] = matrix[i, j];
                    }
                    else
                    {
                        answer[i, j] = matrix[i + 1, j];
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
            int k = 0;
            int min = int.MaxValue, mink = -1;
            int max = int.MinValue, maxk = -1;
            for (int i = 0; i < n; i++)
            {

                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] < 0)
                    {
                        k++;
                    }
                }
                if (k > max)
                {
                    max = k;
                    maxk = i;
                }
                if (k < min)
                {
                    min = k;
                    mink = i;
                }
                k = 0;
            }
            if (min != max)
            {
                for (int j = 0; j < m; j++)
                {
                    (matrix[mink, j], matrix[maxk, j]) = (matrix[maxk, j], matrix[mink, j]);
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
            int mi = int.MaxValue, mik = -1;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] < mi)
                    {
                        mi = matrix[i, j];
                        mik = j;
                    }
                }
            }
            if (array.Length == matrix.GetLength(0))
            {
                answer = new int[n, m + 1];
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        if (j <= mik)
                        {
                            answer[i, j] = matrix[i, j];
                        }
                        if (j == mik)
                        {
                            answer[i, j + 1] = array[i];
                        }
                        else
                        {
                            answer[i, j + 1] = matrix[i, j];
                        }
                    }
                }
            }
            else
            {
                answer = matrix;
            }
            // end

            return answer;
        }
        public void Task8(int[,] matrix)
        {

            // code here

            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            int k = 0, c = 0;
            int max = int.MinValue, maxk = -1;
            for (int i = 0; i < m; i++)
            {
                max = int.MinValue; maxk = 0; k = 0; c = 0;
                for (int j = 0; j < n; j++)
                {
                    if (matrix[j, i] > max)
                    {
                        max = matrix[j, i];
                        maxk = j;
                    }
                    if (matrix[j, i] < 0)
                    {
                        k++;
                    }
                    if (matrix[j, i] > 0)
                    {
                        c++;
                    }
                }
                if (k>c)
                {
                    matrix[maxk, i] = maxk;
                }
                if (k<c)
                {
                    matrix[maxk, i] = 0;
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
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        if (i == 0 || j == 0 || i == n - 1 || j == n-1)
                        {
                            matrix[i,j] = 0;
                        }
                    }
                }
            // end

        }
        public (int[] A, int[] B) Task10(int[,] matrix)
        {
            int[] A = null, B = null;

            // code here

            // 11 12 13 14
            // 21 22 23 24
            // 31 32 33 34
            // 41 42 43 44
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            int k = 0, c = 0, k1 = 0, c1 = 0;
            if (n == m)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        if (j - i > -1)
                        {
                            k++;
                        }
                        else
                        {
                            c++;
                        }
                    }
                }
                A = new int[k];
                B = new int[c];
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        if (j - i > -1)
                        {
                            A[k1] = matrix[i,j];
                            k1++;
                        }
                        else
                        {
                            B[c1] = matrix[i, j];
                            c1++;
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
            for (int j = 0; j < m; j++)
            {
                if (j % 2 == 0)
                {
                    for (int i = 0; i < n; i++)
                    {
                        for (int h = 0; h < n - i - 1; h++)
                        {
                            if (matrix[h, j] < matrix[h + 1, j])
                            {
                                (matrix[h, j], matrix[h + 1, j]) = (matrix[h + 1, j], matrix[h, j]);
                            }
                        }
                    }
                }
                if (j % 2 != 0)
                {
                    for (int i = 0; i < n; i++)
                    {
                        for (int h = 0; h < n - i - 1; h++)
                        {
                            if (matrix[h, j] > matrix[h + 1, j])
                            {
                                (matrix[h, j], matrix[h + 1, j]) = (matrix[h + 1, j], matrix[h, j]);
                            }
                        }
                    }
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
