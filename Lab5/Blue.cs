using System.Linq;
using System.Runtime.InteropServices;

namespace Lab5
{
    public class Blue
    {
        public double[] Task1(int[,] matrix)
        {
            double[] answer = null;

            // code here
            int n = matrix.GetLength(0), m = matrix.GetLength(1);
            answer = new double[n];
            for (int i = 0; i < n; i++)
            {
                double S = 0;
                int ind = 0;
                for (int j = 0;  j < m; j++)
                {
                   if (matrix[i,j] > 0)
                   {
                        S += matrix[i, j];
                        ind++;
                   }
                }
                if (ind > 0)
                {
                    answer[i] = S / ind;
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
            int n = matrix.GetLength(0), m = matrix.GetLength(1);
            int mi = 0;
            int mj = 0;
            answer = new int[n - 1, m - 1];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] > matrix[mi,mj])
                    {
                        mi = i;
                        mj = j;
                    }
                }
            }
            int ind1 = 0;
            for (int i = 0; i < n; i++)
            {
                if (i == mi)
                    continue; 
                int ind2 = 0;
                for (int j = 0; j < m; j++)
                {
                    if (j == mj) 
                        continue; 
                    answer[ind1, ind2] = matrix[i, j];
                    ind2++;
                }
                ind1++;
            }

            // end

            return answer;
        }
        public void Task3(int[,] matrix)
        {

            // code here
            int n = matrix.GetLength(0), m = matrix.GetLength(1);
            for (int i = 0; i < n; i++)
            {
                int max = 0;
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] > matrix[i, max])
                        max = j;
                }
                for (int j = max; j < m - 1; j++)
                    (matrix[i, j], matrix[i, j + 1]) = (matrix[i, j + 1], matrix[i, j]);
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
                int max = 0;
                for (int j = 0; j < m; j++)
                    if (matrix[i, j] > matrix[i, max])
                        max = j;
                for (int j = 0; j < m + 1; j++)
                {
                    if (j < m - 1)
                        answer[i, j] = matrix[i, j];
                    else if (j == m - 1)
                        answer[i, j] = matrix[i, max];
                    else
                        answer[i, j] = matrix[i, j - 1];
                }
            }
            // end

            return answer;
        }
        public int[] Task5(int[,] matrix)
        {
            int[] answer = null;

            // code here
            int n = matrix.GetLength(0), m = matrix.GetLength(1);
            int q = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if ((i + j) % 2 != 0)
                    {
                        q++;
                    }
                }
            }
            answer = new int[q];
            int w = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if ((i + j) % 2 != 0)
                    {
                        answer[w++] = matrix[i, j];
                    }
                }
            }
            // end

            return answer;
        }
        public void Task6(int[,] matrix, int k)
        {

            // code here
            int n = matrix.GetLength(0), m = matrix.GetLength(1);
            if ((n != m) || (k >= n))
                return;
            int max = 0;
            for (int i = 0; i < n; i++)
                if (matrix[i, i] > matrix[max, max])
                    max = i;
            bool f = false;
            int w = 0;
            for (int i = 0; i < n; i++)
            {
                if ((!f) && (matrix[i, k] < 0))
                {
                    w = i;
                    f = true;
                }
            }
            if ((!f) || (max == w))
                return;
            for (int j = 0; j < m; j++)
                (matrix[max, j], matrix[w, j]) = (matrix[w, j], matrix[max, j]);
            // end

        }
        public void Task7(int[,] matrix, int[] array)
        {

            // code here
            int n = matrix.GetLength(0), m = matrix.GetLength(1);
            if (m < 2)
                return;
            if (m != array.Length)
                return;
            int max = 0;
            for (int i = 0; i < n; i++)
                if (matrix[i, m - 2] > matrix[max, m - 2])
                    max = i;
            for (int j = 0; j < m; j++)         
                matrix[max, j] = array[j];        
            //end

        }
        public void Task8(int[,] matrix)
        {

            // code here
            int n = matrix.GetLength(0), m = matrix.GetLength(1);
            for (int j = 0; j < m; j++)
            {
                int max = 0;
                for (int i = 0; i < n; i++)
                    if (matrix[i, j] > matrix[max, j])
                        max = i;
                if (max >= (n / 2))
                    continue;
                int s = 0;
                for (int i = max + 1; i < n; i++)
                    s += matrix[i, j];
                matrix[0, j] = s;
            }
            // end

        }
        public void Task9(int[,] matrix)
        {

            // code here
            int n = matrix.GetLength(0), m = matrix.GetLength(1);
            for (int i = 0; i < n - 1; i += 2)
            {
                int max1 = 0, max2 = 0;
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] > matrix[i, max1])
                        max1 = j;
                    if (matrix[i + 1, j] > matrix[i + 1, max2])
                        max2 = j;
                }
                (matrix[i, max1], matrix[i + 1, max2]) = (matrix[i + 1, max2], matrix[i, max1]);
            }
            // end

        }
        public void Task10(int[,] matrix)
        {

            // code here
            int n = matrix.GetLength(0), m = matrix.GetLength(1);
            if (n != m)
                return;
            int max = 0;
            for (int i = 0; i < n; i++)
                if (matrix[i, i] > matrix[max, max])
                    max = i;
            for (int i = 0; i < max; i++)
                for (int j = 0; j < m; j++)
                    if (i < j)
                        matrix[i, j] = 0;

            // end

        }

        public void Task11(int[,] matrix)
        {

            // code here
            int n = matrix.GetLength(0), m = matrix.GetLength(1);
            int[] pol = new int[n];
            for (int i = 0; i < n; i++)
            {
                int k = 0;
                for (int j = 0; j < m; j++) 
                    if (matrix[i, j] > 0) 
                        k++;
                pol[i] = k;
            }
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - 1 - i; j++)
                {
                    if (pol[j] < pol[j + 1])
                    {
                        (pol[j], pol[j + 1]) = (pol[j + 1], pol[j]);
                        for (int q = 0; q < m; q++) 
                            (matrix[j, q], matrix[j + 1, q]) = (matrix[j + 1, q], matrix[j, q]);
                    }
                }
            }
            // end

        }
        public int[][] Task12(int[][] array)
        {
            int[][] answer = null;

            // code here
            double s = 0;
            int k = 0;
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    s += array[i][j];
                    k++;
                }
            }
            double sr = s / k;
            int kk = 0;
            for (int i = 0; i < array.Length; i++)
            {
                double ss = 0;
                for (int j = 0; j < array[i].Length; j++) 
                    ss += array[i][j];
                double srst = ss / array[i].Length;
                if (srst >= sr) 
                    kk++;
            }
            answer = new int[kk][];
            int q = 0;
            for (int i = 0; i < array.Length; i++)
            {
                double ss = 0;
                for (int j = 0; j < array[i].Length; j++)
                    ss += array[i][j];
                double srst = ss / array[i].Length;
                if (srst >= sr) 
                    answer[q++] = array[i];
            }
            // end

            return answer;
        }
    }
}
