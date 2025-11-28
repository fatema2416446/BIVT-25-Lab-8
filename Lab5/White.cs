using System.Linq;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Security;

namespace Lab5
{
    public class White
    {
        public double Task1(int[,] matrix)
        {
            double average = 0;

            // code here
            int k = 0;
            double sum = 0;
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            if (matrix == null)
            {
                return 0;
            }
                
            for(int i =0;i < n;i++)
            {
                for(int j =0;j < m;j++)
                {
                    int v = matrix[i, j];
                    if (v > 0)
                    {
                        sum += v;
                        k++;
                    }
                   


                }
            }
            if (k > 0)
            {
                average = sum / k;
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
            int minrow = 0;
            int mincol = 0;
            int minv = matrix[0, 0];
            for(int i =0;i < n;i++)
            {
                for(int j =0;j < m;j++)
                {
                    if(matrix[i, j] < minv)
                    {
                        minv = matrix[i, j];
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
            if (matrix ==null)
            {
                return;
            }
            
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            if (k < 0 || k >= m)
            {
                return;
            }
            int imax = 0;
            int vmax = matrix[0,k];
            for (int i = 1;i < n;i++)
            {
                if (matrix[i,k] > vmax )
                {
                    vmax = matrix[i,k];
                    imax = i;
                }
            }
            if (imax == 0)
            {
                return;
            }
            for(int j = 0;j < m;j++)
            {
                int r = matrix[0, j];
                matrix[0,j] = matrix[imax,j];
                matrix[imax, j] = r;
            }
            
            // end

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
            int minvalue = matrix[0, 0];
            int minrow = 0;
            for (int i = 1; i < n; i++)
            {
                if (matrix[i, 0] < minvalue)
                {
                    minvalue = matrix[i, 0];
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
                if (i == minrow) continue;
                for (int j = 0; j < m; j++)
                {
                    result[newrow,j] = matrix[i, j];
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
            if (n != matrix.GetLength(1)) return 0;
            for (int i =0;i <n;i++)
            {
                sum += matrix[i, i];
            }
            // end

            return sum;
        }
        public void Task6(int[,] matrix)
        {

            // code here
            if (matrix == null) return;
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            for(int i = 0;i < n;i++)
            {
                int first = -1;
                for (int j = 0;j < m;j++)
                {
                    if (matrix[i, j] < 0)
                    {
                        first = j;
                        break;
                    }
                }
                if (first <=0) continue;
                int maxindex = 0;
                int maxvalue = matrix[i,0];

                for (int j = 0; j < first;j++)
                {
                    if (matrix[i,j] > maxvalue)
                    {
                        maxvalue = matrix[i,j];
                        maxindex = j;

                    }
                }
                int last = -1;
                for (int j = m -1; j >=0; j--)
                {
                    if (matrix[i,j] < 0)
                    {
                        last = j;
                        break;
                    }
                }
                if (last == -1) continue;
                int t = matrix[i, maxindex];
                matrix[i, maxindex] = matrix[i, last];
                matrix[i,last] = t;
            }
         
            // end

        }
        public int[] Task7(int[,] matrix)
        {
            int[] negatives = null;

            // code here
            if (matrix == null) return null;
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

       
            int count = 0;
            for (int i = 0; i < n; i++)
            {

                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] < 0) count++;
                }
            }
            if (count == 0) return null;

            int[] result = new int[count];
            int index = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {


                    if (matrix[i, j] < 0)
                        result[index++] = matrix[i, j];
                }
            }
            // end

            return result;
        }
        public void Task8(int[,] matrix)
        {

            // code here
            if (matrix == null) return;
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            for (int i = 0; i < n; i++)
            {
                if (m == 1) continue;
                int maxIdx = 0;
                int mv = matrix[i, 0];
                for (int j = 1; j < m; j++)
                {
                    if (matrix[i, j] > mv)
                    {
                        mv = matrix[i, j];
                        maxIdx = j;
                    }
                }
                int l = maxIdx - 1, rgt = maxIdx + 1;
                if (l >= 0 && rgt < m)
                {
                    if (matrix[i, l] <= matrix[i, rgt])
                    {
                        matrix[i, l] *= 2;
                    }
                    else
                    {
                        matrix[i, rgt] *= 2;
                    }
                }
                else if (l >= 0)
                {
                    matrix[i, l] *= 2;
                }
                else if (rgt < m)
                {
                    matrix[i, rgt] *= 2;
                }
            }
            // end

        }
        public void Task9(int[,] matrix)
        {

            // code here
            if (matrix == null) return;
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m / 2; j++)
                {
                    int o = m - 1 - j;
                    int t = matrix[i, j];
                    matrix[i, j] = matrix[i, o];
                    matrix[i, o] = t;
                }
            }
            // end

        }
        public void Task10(int[,] matrix)
        {

            // code here
            if (matrix == null) return;
            int n = matrix.GetLength(0);
            if (n != matrix.GetLength(1)) return;
            int s = n / 2; for (int i = s; i < n; i++)
                for (int j = 0; j <= i; j++) matrix[i, j] = 1;
            // end

        }
        public int[,] Task11(int[,] matrix)
        {
            if (matrix == null) return null;
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            
            bool[] keepRow = new bool[n];
            int keepCount = 0;

            for (int i = 0; i < n; i++)
            {
                bool hasZero = false;
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        hasZero = true;
                        break;
                    }
                }
                if (!hasZero)
                {
                    keepRow[i] = true;
                    keepCount++;
                }
            }

            if (keepCount == 0) return new int[0, m];

           
            int[,] outM = new int[keepCount, m];
            int rowIndex = 0;

            for (int i = 0; i < n; i++)
            {
                if (keepRow[i])
                {
                    for (int j = 0; j < m; j++)
                    {
                        outM[rowIndex, j] = matrix[i, j];
                    }
                    rowIndex++;
                }
            }
            // end

            return outM;
        }
        public void Task12(int[][] array)
        {

            // code here
            if (array == null) return;
            int n = array.Length;
            int[] sums = new int[n];
            for (int i = 0; i < n; i++)
            {
                if (array[i] != null)
                {
                    int s = 0;
                    for (int x = 0; x < array[i].Length; x++)
                    {
                        s += array[i][x]; sums[i] = s;
                    }
                }
                else sums[i] = 0;
            }
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    if (sums[i] > sums[j])
                    {
                        int[] tmp = array[i];
                        array[i] = array[j];
                        array[j] = tmp;
                        int t = sums[i];
                        sums[i] = sums[j];
                        sums[j] = t;
                    }
                }
            }
            // end

        }
    }
}