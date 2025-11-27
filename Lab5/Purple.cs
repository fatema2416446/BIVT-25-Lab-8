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
            answer = new int[matrix.GetLength(1)];
            
            int ind = 0;
           
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                int c = 0;
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    if (matrix[j, i] < 0)
                    {
                        c++;
                    }
                }
                answer[ind] = c;
                ind++;
            }
            // end

            return answer;
        }
        public void Task2(int[,] matrix)
        {

            // code here
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int ind = 0;
                int minr = int.MaxValue;
                int minin = 0;
                int[] st = new int[matrix.GetLength(1)];
                
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    st[ind] = matrix[i, j];
                    ind++;
                    if (minr> matrix[i, j])
                    {
                        minr = matrix[i, j];
                        minin = j;
                    }
                }
                if (minin == 0)
                {
                    continue;
                }
                else if (minin == matrix.GetLength(1) - 1)
                {
                    matrix[i, 0] = st[minin];
                    for (int k = 0; k < matrix.GetLength(1) - 1; k++)
                    {
                        matrix[i, k + 1] = st[k];
                    }
                }
                else
                {
                    matrix[i, 0] = st[minin];
                    for (int k = 0; k < matrix.GetLength(1) - 1; k++)
                        if (k < minin)
                        {
                            matrix[i, k + 1] = st[k];
                        }
                        else
                        {
                            matrix[i, k + 1] = st[k + 1];
                        }
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
            int max = int.MinValue;
            int jmax = -1;
            answer = new int[n, m + 1];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (max < matrix[i, j])
                    {
                        max = matrix[i, j];
                        jmax = j;
                    }
                }
                for (int j = 0; j < m; j++)
                {
                    if (j < jmax)
                    {
                        answer[i, j] = matrix[i, j];
                    }
                    else if (j == jmax)
                    {
                        answer[i, j] = matrix[i, j];
                        answer[i, j + 1] = matrix[i, j];
                    }
                    else
                    {
                        answer[i, j + 1] = matrix[i, j];
                    }
                }
                max = int.MinValue;
                jmax = -1;
            }
            // end

            return answer;
        }
        public void Task4(int[,] matrix)
        {

            // code here
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int imax = 0;

                for (int j = 1; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > matrix[i, imax])
                    {
                        imax = j;
                    }
                }

                if (imax != matrix.GetLength(1) - 1)
                {
                    int sum = 0, count = 0;

                    for (int j = imax + 1; j < matrix.GetLength(1); j++)
                    {
                        if (matrix[i, j] > 0)
                        {
                            sum += matrix[i, j];
                            count++;
                        }
                    }

                    if (count != 0)
                    {
                        for (int j = 0; j < imax; j++)
                        {
                            if (matrix[i, j] < 0)
                            {
                                matrix[i, j] = sum / count;
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

            if (k <= matrix.GetLength(1) - 1 && k >= 0)
            {
                int n = 0;
                int[] maxValues = new int[matrix.GetLength(0)];
                for (int i = matrix.GetLength(0) - 1; i >= 0; i--)
                {
                    int maxValue = matrix[i, 0];
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        if (matrix[i, j] > maxValue)
                            maxValue = matrix[i, j];
                    }

                    maxValues[n] = maxValue;
                    n++;
                }

                n = 0;
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    matrix[i, k] = maxValues[n];
                    n++;
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
                int max = -1000000, indi = -1, indj = -1;
                for (int i = 0; i < n; i++)
                {
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                        indi = i;
                        indj = j;
                    }
                }

                if (array.Length == m && array[indj] > max) matrix[indi, j] = array[indj];
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write($"{matrix[i, j],5}");
                }
                Console.WriteLine();
            }
            // end

        }
        public void Task7(int[,] matrix)
        {

            // code here
  
            int[] minValue = new int[matrix.GetLength(0)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int min = Int32.MaxValue;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (min > matrix[i, j])
                        min = matrix[i, j];
                }
                minValue[i] = min;
            }

            int[] index = new int[minValue.Length];
            for (int i = 0; i < minValue.Length; i++)
            {
                index[i] = i;
            }

            for (int i = 0; i < minValue.Length; i++)
            {
                for (int j = 1; j < minValue.Length - i; j++)
                {
                    if (minValue[j - 1] < minValue[j])
                    {
                        (minValue[j], minValue[j - 1]) = (minValue[j - 1], minValue[j]);
                        (index[j], index[j - 1]) = (index[j - 1], index[j]);
                    }
                }
            }

            int[,] clone = new int[matrix.GetLength(0), matrix.GetLength(1)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    clone[i, j] = matrix[i, j];
                }
            }
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = clone[index[i], j];
                }
            }
        }
            // end

        
        public int[] Task8(int[,] matrix)
        {
            int[] answer = null;

            // code here
            if (matrix.GetLength(0) != matrix.GetLength(1))
                return answer;

            int size = matrix.GetLength(0);
            answer = new int[2 * size - 1];

            int count = 1;
            for (int step = 0; step < answer.Length; step++)
            {
                if (step < size - 1)
                {
                    int length = size - 1, row = step;
                    for (int i = 0; i < step + 1; i++)
                    {
                        answer[step] += matrix[length, row];
                        length--;
                        row--;
                    }

                    continue;
                }


                if (step == size - 1)
                {
                    int length = 0, row = 0;
                    for (int i = 0; i < size; i++)
                    {
                        answer[step] += matrix[length, row];
                        length++;
                        row++;
                    }

                    continue;
                }

                if (step > size - 1)
                {
                    int length = size - 1 - count, row = size - 1;
                    for (int i = 0; i < size - count; i++)
                    {
                        answer[step] += matrix[length, row];
                        length--;
                        row--;
                    }

                    count++;
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
            if (n != m)
                return;
            int max = 0;
            int imax = 0;
            int jmax = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (Math.Abs(matrix[i, j]) > Math.Abs(max))
                    {
                        max = matrix[i, j];
                        imax = i;
                        jmax = j;
                    }
                }
            }

            int shifti = k - imax;
            int shiftj = k - jmax;
            if (shifti < 0)
            {
                for (int i = imax; i > k; i--)
                {
                    for (int j = 0; j < m; j++)
                    {
                        (matrix[i, j], matrix[i - 1, j]) = (matrix[i - 1, j], matrix[i, j]);
                    }
                }
            }
            else
            {
                for (int i = imax; i < k; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        (matrix[i, j], matrix[i + 1, j]) = (matrix[i + 1, j], matrix[i, j]);
                    }
                }
            }

            if (shiftj < 0)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = jmax; j > k; j--)
                    {
                        (matrix[i, j], matrix[i, j - 1]) = (matrix[i, j - 1], matrix[i, j]);
                    }
                }
            }
            else
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = jmax; j < k; j++)
                    {
                        (matrix[i, j], matrix[i, j + 1]) = (matrix[i, j + 1], matrix[i, j]);
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

                for (int i = 0; i < A.GetLength(0); i++)
                {
                    for (int j = 0; j < B.GetLength(1); j++)
                    {
                        int sum = 0;

                        for (int k = 0; k < A.GetLength(1); k++)
                        {
                            sum += A[i, k] * B[k, j];
                        }

                        answer[i, j] = sum;
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

            int n = matrix.GetLength(0), m = matrix.GetLength(1);
            int[][] answer2 = new int[n][];
            for (int i = 0; i < n; ++i)
            {
                int k = 0;
                for (int j = 0; j < m; ++j)
                {
                    k += (matrix[i, j] > 0) ? 1 : 0;
                }
                answer2[i] = new int[k];
                for (int j = 0, h = 0; j < m; ++j)
                {
                    if (matrix[i, j] > 0)
                    {
                        answer2[i][h++] = matrix[i, j];
                    }
                }
            }
            answer = answer2;
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
                for (int j = 0; j < array[i].Length; j++)
                {
                    count++;
                }
            }

            int n = (int)Math.Sqrt(count);
            if (n * n != count)
                n += 1;
            answer = new int[n, n];
            int[] flatArray = new int[count];
            int index = 0;
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    flatArray[index++] = array[i][j];
                }
            }

            index = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (index < count)
                        answer[i, j] = flatArray[index++];
                    else break;
                }
            }
            // end

            return answer;
        }
    }
}
