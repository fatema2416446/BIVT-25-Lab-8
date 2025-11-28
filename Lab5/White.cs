using System.Linq;
using System.Runtime.InteropServices;

namespace Lab5
{
    public class White
    {
        public double Task1(int[,] matrix)
        {
            double average = 0;

            // code here
            int count = 0;
            double sum = 0;
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            if (matrix == null)
            {
                return 0;
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        sum += matrix[i, j];
                        count++;
                    }
                }
            }

            if (count > 0)
            {
                average = sum / count;
            }
            // end

            return average;
        }
        public (int row, int col) Task2(int[,] matrix)
        {
            int row = 0, col = 0;

            // code here
            if (matrix == null)
            {
                return (0, 0);
            }

            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            int minrow = 0, mincol = 0;
            int min = matrix[0, 0];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] < min)
                    {
                        min = matrix[i, j];
                        minrow = i;
                        mincol = j;
                    }
                }
            }
            row = minrow; col = mincol;
            // end

            return (row, col);
        }
        public void Task3(int[,] matrix, int k)
        {

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            if (matrix == null)
            {  
                return; 
            }

            if (k < 0 || k >= m)
            {
                return;
            }

            int max = int.MinValue;
            int maxRow = 0;
            for (int i = 0; i < n; i++)
            {
                if (matrix[i, k] > max)
                {
                    max = matrix[i, k];
                    maxRow = i;
                }
            }

            if (maxRow != 0)
            {
                for (int i = 0; i < m; i++)
                {
                    (matrix[maxRow, i], matrix[0, i]) = (matrix[0, i], matrix[maxRow, i]);
                }
            }
        }

        public int[,] Task4(int[,] matrix)
        {
            int[,] answer = null;

            // code here
            if (matrix == null)
            {
                return null;
            }

            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            if (n == 0)
            {
                return new int[0, m];
            }

            int min = matrix[0, 0];
            int minrow = 0;
            for (int i = 1; i < n; i++)
            {
                if (matrix[i, 0] < min)
                {
                    min = matrix[i, 0];
                    minrow = i;
                }
            }

            if (n == 1)
            {
                return new int[0, m];

            }

            int[,] result = new int[n - 1, m];
            int newrow = 0;
            for (int i = 0; i < n; i++)
            {
                if (i == minrow)
                {
                    continue;
                }
                for (int j = 0; j < m; j++)
                {
                    result[newrow, j] = matrix[i, j];
                }
                newrow++;
            }
            answer = result;
            // end

            return answer;
        }
        public int Task5(int[,] matrix)
        {
            int sum = 0;

            // code here
            if (matrix == null)
            {
                return 0;
            }

            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            if (n != m)
            {
                return 0;
            }

            for (int i = 0; i < n; i++)
            {
                sum += matrix[i, i];
            }
            // end

            return sum;
        }
        public void Task6(int[,] matrix)
        {

            // code here
            if (matrix == null)
            {
                return;
            }

            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            for (int i = 0; i < n; i++)
            {
                int first = -1;
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] < 0)
                    {
                        first = j;
                        break;
                    }
                }

                if (first <= 0)
                {
                    continue;
                }

                int maxin = 0;
                int max = matrix[i, 0];
                for (int j = 0; j < first; j++)
                {
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                        maxin = j;

                    }
                }

                int last = -1;
                for (int j = m - 1; j >= 0; j--)
                {
                    if (matrix[i, j] < 0)
                    {
                        last = j;
                        break;
                    }
                }
                if (last == -1)
                {
                    continue;
                }
                (matrix[i, maxin], matrix[i, last]) = (matrix[i, last], matrix[i, maxin]);
            }
            // end

        }
        public int[] Task7(int[,] matrix)
        {
            int[] negatives = null;

            // code here
            int nCount = 0;
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] < 0)
                    {
                        nCount++;
                    }
                }
            }

            if (nCount > 0)
            {
                negatives = new int[nCount];
                int index = 0;
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        if (matrix[i, j] < 0)
                        {
                            negatives[index] = matrix[i, j];
                            index++;
                        }
                    }
                }
            }
            // end

            return negatives;
        }
        public void Task8(int[,] matrix)
        {

            // code here
            if (matrix == null) return;
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            for (int i = 0; i < n; i++)
            {
                if (m == 1)
                {
                    continue;
                }
                int maxrowi = 0;
                int maxi = matrix[i,0];
                for (int j = 1; j < m; j++)
                {
                    if (matrix[i, j] > maxi)
                    {
                        maxi = matrix[i, j];
                        maxrowi = j;
                    }
                }
                int l = maxrowi - 1, r = maxrowi + 1;
                if (l >= 0 && r < m)
                {
                    if (matrix[i, l] <= matrix[i, r])
                    {
                        matrix[i, l] *= 2;
                    }
                    else
                    {
                        matrix[i, r] *= 2;
                    }
                }
                else if (l >= 0)
                {
                    matrix[i, l] *= 2;
                }
                else if (r < m)
                {
                    matrix[i, r] *= 2;
                }
            }
            // end

        }
        public void Task9(int[,] matrix)
        {

            // code here
            if (matrix == null)
            {
                return;
            }

            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m / 2; j++)
                {
                    int newj = m - 1 - j;
                    int t = matrix[i, j];
                    matrix[i, j] = matrix[i, newj];
                    matrix[i, newj] = t;
                }
            }
            // end

        }
        public void Task10(int[,] matrix)
        {

            // code here
            
            if (matrix == null)
            {
                return;
            }

            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            if (n != m)
            { 
                return; 
            }

            int s = n / 2; 
            for (int i = s; i < n; i++)
                for (int j = 0; j <= i; j++)
                {
                    matrix[i, j] = 1;
                }
            // end

        }
        public int[,] Task11(int[,] matrix)
        {
            int[,] answer = null;

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            int zeroCount = 0,  newi = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        zeroCount++;
                        break;
                    }
                }
            }

            int[,] b = new int[n - zeroCount, m];

            for (int i = 0; i < n; i++)
            {
                bool Zero = false;
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        Zero = true;
                        break;
                    }
                }

                if (!Zero)
                {
                    for (int j = 0; j < m; j++)
                    {
                        b[newi, j] = matrix[i, j];
                    }
                    newi++;
                }
            }

            answer = b;
            // end

            return answer;
        }
        public void Task12(int[][] array)
        {

            // code here
            int[] sum = new int[array.Length];

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    sum[i] += array[i][j];
                }
            }

            for (int i = 0; i < sum.Length - 1; i++)
            {
                for (int j = 0; j < sum.Length - 1 - i; j++)
                {
                    if (sum[j] > sum[j + 1])
                    {
                        (array[j], array[j + 1]) = (array[j + 1], array[j]);
                        (sum[j], sum[j + 1]) = (sum[j + 1], sum[j]);
                    }
                }
            }
            // end

        }
    }
}