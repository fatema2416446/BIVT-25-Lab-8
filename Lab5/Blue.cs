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
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            answer = new double[rows];

            for (int i = 0; i < rows; i++)
            {
                double sum = 0;
                int count = 0;

                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        sum += matrix[i, j];
                        count++;
                    }
                }

                if (count > 0)
                {
                    answer[i] = sum / count;  
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
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            
            int maxValue = matrix[0, 0];
            int maxrow = 0;
            int maxcol = 0;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] > maxValue)
                    {
                        maxValue = matrix[i, j];
                        maxrow = i;
                        maxcol = j;
                    }
                }
            }

            answer = new int[rows - 1, cols - 1];

            
            int newrow = 0;
            for (int i = 0; i < rows; i++)
            {
                if (i != maxrow) 
                {
                    int newcol = 0;
                    for (int j = 0; j < cols; j++)
                    {
                        if (j != maxcol) 
                        {
                            answer[newrow, newcol] = matrix[i, j];
                            newcol++;
                        }
                    }
                    newrow++;
                }
            }

            // end

            return answer;
        }
        public void Task3(int[,] matrix)
        {

            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int i = 0; i < rows; i++)
            {

                int mxidx = 0;
                int mxv = matrix[i, 0];

                for (int j = 1; j < cols; j++)
                {
                    if (matrix[i, j] > mxv)
                    {
                        mxv = matrix[i, j];
                        mxidx = j;
                    }
                }

                int temp = matrix[i, mxidx];

                for (int j = mxidx; j < cols - 1; j++)
                {
                    matrix[i, j] = matrix[i, j + 1];
                }

                matrix[i, cols - 1] = temp;
            }
            // end
        }
        public int[,] Task4(int[,] matrix)
        {
            int[,] answer = null;

            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            answer = new int[rows, cols + 1];

            for (int i = 0; i < rows; i++)
            {
                int max = matrix[i, 0];
                for (int j = 1; j < cols; j++)
                {
                    if (matrix[i, j] > max)
                        max = matrix[i, j];
                }

                for (int j = 0; j < cols - 1; j++)
                {
                    answer[i, j] = matrix[i, j];
                }

                answer[i, cols - 1] = max;

                answer[i, cols] = matrix[i, cols - 1];
            }
            // end

            return answer;
        }
        public int[] Task5(int[,] matrix)
        {
            int[] answer = null;

            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            int count = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if ((i + j) % 2 != 0) 
                    {
                        count++;
                    }
                }
            }

            answer = new int[count];
            int index = 0;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if ((i + j) % 2 != 0)
                    {
                        answer[index] = matrix[i, j];
                        index++;
                    }
                }
            }
            // end

            return answer;
        }
        public void Task6(int[,] matrix, int k)
        {

            // code here
            int n = matrix.GetLength(0);
            if (n != matrix.GetLength(1) || k < 0 || k >= n)
                return;

            int maxrow = 0;
            for (int i = 1; i < n; i++)
            {
                if (matrix[i, i] > matrix[maxrow, maxrow])
                    maxrow = i;
            }

            int negrow = -1;
            for (int i = 0; i < n; i++)
            {
                if (matrix[i, k] < 0)
                {
                    negrow = i;
                    break;
                }
            }

            if (negrow != -1 && maxrow != negrow)
            {
                for (int j = 0; j < n; j++)
                {
                    int temp = matrix[maxrow, j];
                    matrix[maxrow, j] = matrix[negrow, j];
                    matrix[negrow, j] = temp;
                }
            }
            // end

        }
        public void Task7(int[,] matrix, int[] array)
        {

            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            if (cols < 2 || array.Length != cols)
                return;

            int maxrow = 0;
            int plc = cols - 2; 

            for (int i = 1; i < rows; i++)
            {
                if (matrix[i, plc] > matrix[maxrow, plc])
                {
                    maxrow = i;
                }
            }

            for (int j = 0; j < cols; j++)
            {
                matrix[maxrow, j] = array[j];
            }
            // end

        }
        public void Task8(int[,] matrix)
        {

            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int j = 0; j < cols; j++)
            {
                int maxidx = 0;
                int mxv = matrix[0, j];

                for (int i = 1; i < rows; i++)
                {
                    if (matrix[i, j] > mxv)
                    {
                        mxv = matrix[i, j];
                        maxidx = i;
                    }
                }

                int half = rows / 2;
                if (maxidx < half)
                {
                    int sum = 0;
                    for (int i = maxidx + 1; i < rows; i++)
                    {
                        sum += matrix[i, j];
                    }
                    matrix[0, j] = sum;
                }
            }
            // end

        }
        public void Task9(int[,] matrix)
        {

            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int i = 0; i < rows - 1; i += 2)
            {
                int mxnchi = 0;
                for (int j = 1; j < cols; j++)
                {
                    if (matrix[i, j] > matrix[i, mxnchi])
                        mxnchi = j;
                }

                int mxchi = 0;
                for (int j = 1; j < cols; j++)
                {
                    if (matrix[i + 1, j] > matrix[i + 1, mxchi])
                        mxchi = j;
                }

                // Меняем местами
                int temp = matrix[i, mxnchi];
                matrix[i, mxnchi] = matrix[i + 1, mxchi];
                matrix[i + 1, mxchi] = temp;
            }
            // end

        }
        public void Task10(int[,] matrix)
        {

            // code here
            int n = matrix.GetLength(0);

            if (n == 0 || matrix.GetLength(1) != n)
                return;

            int maxrow = 0;
            for (int i = 1; i < n; i++)
            {
                if (matrix[i, i] > matrix[maxrow, maxrow])
                    maxrow = i;
            }

            for (int i = 0; i < maxrow; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    matrix[i, j] = 0;
                }
            }
            // end

        }
        public void Task11(int[,] matrix)
        {

            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            int[] counts = new int[rows];
            for (int i = 0; i < rows; i++)
            {
                int count = 0;
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] > 0) count++;
                }
                counts[i] = count;
            }

            for (int i = 0; i < rows - 1; i++)
            {
                for (int j = 0; j < rows - i - 1; j++)
                {
                    if (counts[j] < counts[j + 1])
                    {
                        int tempc = counts[j];
                        counts[j] = counts[j + 1];
                        counts[j + 1] = tempc;

                        for (int k = 0; k < cols; k++)
                        {
                            int temp = matrix[j, k];
                            matrix[j, k] = matrix[j + 1, k];
                            matrix[j + 1, k] = temp;
                        }
                    }
                }
            }
            // end

        }
        public int[][] Task12(int[][] array)
        {
            int[][] answer = null;

            // code here
            if (array == null || array.Length == 0)
                return new int[0][];

            double tsum = 0;
            int tcount = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] != null)
                {
                    for (int j = 0; j < array[i].Length; j++)
                    {
                        tsum += array[i][j];
                        tcount++;
                    }
                }
            }

            if (tcount == 0)
                return new int[0][];

            double tavg = tsum / tcount;

            int count1 = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] != null && array[i].Length > 0)
                {
                    double rowsum = 0;
                    for (int j = 0; j < array[i].Length; j++)
                    {
                        rowsum += array[i][j];
                    }
                    double rowavg = rowsum / array[i].Length;

                    if (rowavg >= tavg)
                    {
                        count1++;
                    }
                }
            }

            answer = new int[count1][];
            int index = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] != null && array[i].Length > 0)
                {
                    double rowsum = 0;
                    for (int j = 0; j < array[i].Length; j++)
                    {
                        rowsum += array[i][j];
                    }
                    double rowavg = rowsum / array[i].Length;

                    if (rowavg >= tavg)
                    {
                        answer[index] = array[i];
                        index++;
                    }
                }
            }
            // end

            return answer;
        }
    }
}