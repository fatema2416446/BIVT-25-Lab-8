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
            int s = 0;
            if (matrix == null || matrix.Length==0) return 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        average += matrix[i, j];
                        s++;
                    }
                }
            }
            if (s > 0)
            {
                average = average / s;
            }
            // end

            return average;
        }
        public (int row, int col) Task2(int[,] matrix)
        {
            int row = 0, col = 0;

            // code here
            if (matrix == null || matrix.Length == 0)
                return (-1, -1);


            int minValue = matrix[0, 0];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < minValue)
                    {
                        minValue = matrix[i, j];
                        row = i;
                        col = j;
                    }
                }
            }
            // end

            return (row, col);
        }
        public void Task3(int[,] matrix, int k)
        {

            // code here
            if (matrix == null || k < 0 || k >= matrix.GetLength(1))
                return;

            int maxR = 0;
            int maxV = matrix[0, k];


            for (int i = 1; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, k] > maxV)
                {
                    maxV = matrix[i, k];
                    maxR = i;
                }
            }


            if (maxR == 0) return;

            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                int t = matrix[0, j];
                matrix[0, j] = matrix[maxR, j];
                matrix[maxR, j] = t;
            }
        
            // end

        }
        public int[,] Task4(int[,] matrix)
        {
            int[,] answer = null;

            // code here
            if (matrix == null || matrix.Length == 0)
                return new int[0, 0];

            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            
            if (rows == 1)
                return new int[0, cols];

            
            int minRow = 0;
            int minValue = matrix[0, 0];

            for (int i = 1; i < rows; i++)
            {
                if (matrix[i, 0] < minValue)
                {
                    minValue = matrix[i, 0];
                    minRow = i;
                }
            }

            
            answer = new int[rows - 1, cols];

            for (int i = 0, newRow = 0; i < rows; i++)
            {
                if (i == minRow) continue;

                for (int j = 0; j < cols; j++)
                {
                    answer[newRow, j] = matrix[i, j];
                }
                newRow++;
            }
            // end

            return answer;
        }
        public int Task5(int[,] matrix)
        {
            int sum = 0;

            // code here
            if (matrix == null || matrix.GetLength(0) != matrix.GetLength(1))
                return 0;

            int n = matrix.GetLength(0);

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
            if (matrix == null) return;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {

                int f = -1;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < 0)
                    {
                        f = j;
                        break;
                    }
                }

                if (f == -1 || f == 0)
                    continue;


                int maxI = 0;
                int maxV = matrix[i, 0];

                for (int j = 0; j < f; j++)
                {
                    if (matrix[i, j] > maxV)
                    {
                        maxV = matrix[i, j];
                        maxI = j;
                    }
                }


                int l = -1;
                for (int j = matrix.GetLength(1) - 1; j >= 0; j--)
                {
                    if (matrix[i, j] < 0)
                    {
                        l = j;
                        break;
                    }
                }

                if (l != -1)
                {                    
                    int t = matrix[i, maxI];
                    matrix[i, maxI] = matrix[i, l];
                    matrix[i, l] = t;
                }
            }
            // end

        }
        public int[] Task7(int[,] matrix)
        {
            int[] negatives = null;

            // code here
   
            int r = 0;
            int c = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < 0)
                    {
                        c++;
                    }
                }
            }
            if (c > 0) { 
                negatives=new int[c];
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        if (matrix[i, j] < 0)
                        {
                            negatives[r] = matrix[i, j];
                            r++;
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
            if (matrix == null || matrix.Length == 0) return;

            int r = matrix.GetLength(0);
            int c = matrix.GetLength(1);

            for (int i = 0; i < r; i++)
            {
                if (c == 1) continue;

                int maxI = 0;
                int maxV = matrix[i, 0];

                for (int j = 1; j < c; j++)
                {
                    if (matrix[i, j] > maxV)
                    {
                        maxV = matrix[i, j];
                        maxI = j;
                    }
                }

                if (maxI == 0)
                {
                    matrix[i, 1] *= 2;
                }
                else if (maxI == c - 1)
                {
                    matrix[i, maxI - 1] *= 2;
                }
                else
                {
                    int left = matrix[i, maxI - 1];
                    int right = matrix[i, maxI + 1];

                    if (left <= right)
                    {
                        matrix[i, maxI - 1] *= 2;
                    }
                    else
                    {
                        matrix[i,   maxI + 1] *= 2;
                    }
                }
            }
            // end

        }
        public void Task9(int[,] matrix)
        {

            // code here
            if (matrix == null) return;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1) / 2; j++)
                {
                    int opp = matrix.GetLength(1) - 1 - j;
                    int t = matrix[i, j];
                    matrix[i, j] = matrix[i, opp];
                    matrix[i, opp] = t;
                }
            }
            // end

        }
        public void Task10(int[,] matrix)
        {

            // code here
            if (matrix == null || matrix.Length == 0 || matrix.GetLength(0) != matrix.GetLength(1))
                return;

            int n = matrix.GetLength(0);
            int Row;

            if (n % 2 == 0)
            {
                Row = n / 2;        
            }
            else
            {
                Row = n / 2;        
            }

            for (int i = Row; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                   
                    if (j <= i)
                    {
                        matrix[i, j] = 1;
                    }
                }
            }
            // end

        }
        public int[,] Task11(int[,] matrix)
        {
            int[,] answer = null;

            // code here
            if (matrix == null || matrix.Length == 0) return new int[0, 0];

            int r = matrix.GetLength(0);
            int c = matrix.GetLength(1);


            int e = 0;
            for (int i = 0; i < r; i++)
            {
                bool zero = false;
                for (int j = 0; j < c; j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        zero = true;
                        break;
                    }
                }

                if (!zero)
                {
                    e++;
                }
            }


            if (e == 0) return new int[0, c];


            answer = new int[e, c];
            int newr = 0;

            for (int i = 0; i < r; i++)
            {
                bool zero = false;
                for (int j = 0; j < c; j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        zero = true;
                        break;
                    }
                }

                if (!zero)
                {
                    for (int j = 0; j < c; j++)
                    {
                        answer[newr, j] = matrix[i, j];
                    }
                    newr++;
                }
            }

            // end

            return answer;
        }
        public void Task12(int[][] array)
        {

            // code here


            if (array == null) return;

            int n = array.Length;
            if (n == 0) return;


            int[] sums = new int[n];
            for (int i = 0; i < n; i++)
            {
                if (array[i] != null)
                {
                    int sum = 0;
                    for (int j = 0; j < array[i].Length; j++)
                    {
                        sum += array[i][j];
                    }
                    sums[i] = sum;
                }
                else
                {
                    sums[i] = 0;
                }
            }

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (sums[j] > sums[j + 1])
                    {
                        int t = sums[j];
                        sums[j] = sums[j + 1];
                        sums[j + 1] = t;

                        int[] row = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = row;
                    }
                }
            }

            // end

        }
    }
}
