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
            int m =  matrix.GetLength(1);
            answer = new int[m];
            for (int i = 0; i < m; i++)
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
            int m =  matrix.GetLength(1);
            for (int i = 0; i < n; i++)
            {
                int minn = Int32.MaxValue;
                int index = 0;
                int count = 0;
                int[] array = new int[m];
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] < minn)
                    {
                        minn = matrix[i, j];
                        index = j;
                    }
                }
                array[count++] = minn;
                for (int k = 0; k < m; k++)
                {
                    if (k != index) array[count++] = matrix[i, k];
                }

                for (int j = 0; j < m; j++)
                {
                    matrix[i, j] = array[j];
                }
            }
            // end

        }

        public int[,] Task3(int[,] matrix)
        {
            int[,] answer = null;

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            answer = new int[n, m + 1];
            for (int i = 0; i < n; i++)
            {
                int maxx = Int32.MinValue;
                int index = 0;
                int count = 0;
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] > maxx)
                    {
                        maxx = matrix[i, j];
                        index = j;
                    }
                }
                for (int k = 0; k < m; k++)
                {
                    answer[i, count++] = matrix[i, k];
                    if (k == index) answer[i, count++] = maxx;
                }
            }
            // end

            return answer;
        }
        public void Task4(int[,] matrix)
        {

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            for (int i = 0; i < n; i++)
            {
                int maxx = Int32.MinValue;
                int index = 0;
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] > maxx)
                    {
                        maxx = matrix[i, j];
                        index = j;
                    }
                }

                int count = 0;
                int sum = 0;
                if (index != m - 1)
                {
                    for (int k = index + 1; k < m; k++)
                    {
                        if (matrix[i, k] > 0)
                        {
                            sum += matrix[i, k];
                            count++;
                        }
                    }

                    if (count != 0)
                    {
                        int sr_z = sum / count;
                        for (int k = 0; k < index; k++)
                        {
                            if (matrix[i, k] < 0)
                            {
                                matrix[i, k] = sr_z;
                            }
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
            int[] array = new int[n];
            for (int i = 0; i < n; i++)
            {
                int maxx = Int32.MinValue;
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] > maxx) maxx = matrix[i, j];
                }

                array[i] = maxx;
            }

            if (k < m - 1)
            {
                for (int i = 0; i < n; i++)
                {
                    matrix[i, k] = array[n - 1 - i];
                } 
            }
            // end

        }
        public void Task6(int[,] matrix, int[] array)
        {

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            for (int j = 0; j < m; j++)
            {
                int maxx = Int32.MinValue;
                int ind = 0;
                for (int i = 0; i < n; i++)
                {
                    if (matrix[i, j] > maxx)
                    {
                        maxx = matrix[i, j];
                        ind = i;
                    }
                }

                if (j < array.Length && array.Length == m)
                {
                    if (array[j] > maxx) matrix[ind, j] = array[j];
                }
            }

            // end

        }
        public void Task7(int[,] matrix)
        {

            // code here
            int  n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            int[] min = new int[n];
            int[] index = new int[n];
            for (int i = 0; i < n; i++)
            {
                int minn =  Int32.MaxValue;
                int ind = 0;
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] < minn)
                    {
                        minn = matrix[i, j];
                    }
                }

                index[i] = i;
                min[i] = minn;
            }
            
            for (int i = 0; i < min.Length; i++)
            {
                bool f = false;
                for (int j = 1; j < min.Length - i; j++)
                {
                    if (min[j - 1] < min[j])
                    {
                        (min[j - 1], min[j]) = (min[j], min[j - 1]);
                        (index[j - 1], index[j]) = (index[j], index[j - 1]);
                        f = true;
                    }
                }
                if (!f) break;
            }
            
            int[,] matrix1 = new int[n, m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    matrix1[i, j] = matrix[index[i], j];
                }
            }
            
           for (int i = 0; i < n; i++)
           { 
               for (int j = 0; j < m; j++)
                 {
                     matrix[i, j] =  matrix1[i, j];
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
                int count = 0;
                for (int i = n - 1; i >= 0; i--)
                {
                    int sum = 0;
                    int k = i;
                    int j = 0;
        
                    while (k < n && j < n - i)
                    {
                        sum += matrix[k, j];
                        k++;
                        j++;
                    }
                    answer[count++] = sum;
                }

                for (int i = 1; i < n; i++)
                {
                    int sum = 0;
                    int k = i;
                    int j = 0;
                    while (k < n && j < n)
                    {
                        sum += matrix[j, k];
                        j++;
                        k++;
                    }
                    answer[count++] = sum;
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
            if (n == m && k <= n - 1)
            {
                int maxx = Int32.MinValue;
                int indexStr = 0;
                int indexS = 0;
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        if (Math.Abs(matrix[i, j]) > maxx)
                        {
                            maxx = Math.Abs(matrix[i, j]);
                            indexStr = i;
                            indexS = j;
                        }
                    }
                }

                if (indexStr > k)
                {
                    for (int j = 0; j < n; j++)
                    {
                        int elem = matrix[indexStr, j];
                        for (int i = k + 1; i <= indexStr; i++)
                        {
                            matrix[i, j] = matrix[i - 1, j];
                        }

                        matrix[k, j] = elem;
                    }
                }
                else if (indexStr < k)
                {
                    for (int j = 0; j < n; j++)
                    {
                        int elem = matrix[indexStr, j];
                        for (int i = indexStr; i < k; i++)
                        {
                            matrix[i, j] = matrix[i + 1, j];
                        }
                        matrix[k, j] = elem;
                    }
                }

                if (indexS > k)
                {
                    for (int i = 0; i < n; i++)
                    {
                        int elem = matrix[i, indexS];
                        for (int j = indexS; j > k; j--)
                        {
                            matrix[i, j] = matrix[i, j - 1];
                            ;
                        }

                        matrix[i, k] = elem;
                    }
                }
                else if (indexS < k)
                {
                    for (int i = 0; i < n; i++)
                    {
                        int elem = matrix[i, indexS];
                        for (int j = indexS; j > k; j++)
                        {
                            matrix[i, j] = matrix[i, j + 1];
                        }

                        matrix[i, k] = elem;
                    } 
                }
            }
            // end

        }
        public int[,] Task10(int[,] A, int[,] B)
        {
            int[,] answer = null;

            // code here
            int n = A.GetLength(0);
            int m = A.GetLength(1);
            int k = B.GetLength(0);
            int l = B.GetLength(1);
            if (m == k)
            {
                answer = new int[n, l];
                for (int i = 0; i < n; i++)
                {
                    for (int q = 0; q < l; q++)
                    {
                        for (int j = 0; j < m; j++)
                        {
                            answer[i, q] += A[i, j] * B[j, q];
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
                    if (matrix[i, j] <= 0) count++;
                }

                answer[i] = new int[m - count];
                count = 0;
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        answer[i][count++] = matrix[i, j];
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
            int n = array.Length;
            int sum = 0;
            for (int i = 0; i < n; i++)
            {
                sum += array[i].Length;
            }
            int m = (int) Math.Ceiling(Math.Sqrt(sum));
            answer = new int[m, m];
            int row = 0;
            int col = 0;
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (row < n)
                    {
                        answer[i, j] = array[row][col];
                        col++;
                        if (col >= array[row].Length)
                        {
                            row++;
                            col = 0;
                        }
                    }
                    else
                    {
                        answer[i, j] = 0;
                    }
                }
            }
            // end

            return answer;
        }
    }
}