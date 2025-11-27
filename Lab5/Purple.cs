using System.Globalization;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;

namespace Lab5
{
    public class Purple
    {
        public int[] Task1(int[,] matrix)
        {
            int[] answer = null;

            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            answer = new int[cols];

            for (int col = 0; col < cols; col++)
            {
                int count = 0;

                for (int row = 0; row < rows; row++)
                {
                    if (matrix[row, col] < 0)
                    {
                        count++;
                    }
                }

                answer[col] = count;
            }
            // end

            return answer;
        }
        public void Task2(int[,] matrix)
        {

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            for (int i = 0; i < n; i++)
            {
                int min = int.MaxValue;
                int minIndex = 0;

                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] < min)
                    {
                        min = matrix[i, j];
                        minIndex = j;
                    }
                }

                for (int j = minIndex; j > 0; j--)
                {
                    matrix[i, j] = matrix[i, j - 1];
                }

                matrix[i, 0] = min;
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
                int max = int.MinValue;
                int maxIndex = 0;

                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                        maxIndex = j;
                    }
                }

                for (int j = 0; j < m + 1; j++)
                {
                    if (j <= maxIndex)
                    {
                        answer[i, j] = matrix[i, j];
                    }
                    else if (j == maxIndex + 1)
                    {
                        answer[i, j] = max;
                    }
                    else
                    {
                        answer[i, j] = matrix[i, j - 1];
                    }
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
                int max = int.MinValue;
                int maxIndex = 0;

                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                        maxIndex = j;
                    }
                }

                int a = 0, s = 0, sc = 0;
                for (int j = maxIndex + 1; j < m; j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        s += matrix[i, j]; sc++;
                    }
                }

                if (sc != 0)
                { 
                    a = s / sc;               
                    for (int j = 0; j < maxIndex; j++)
                    {
                        if (matrix[i, j] < 0)
                        {
                            matrix[i, j] = a;
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

            if (k < 0 || k >= m)
            {
                return;
            }

            int[] array = new int[n];
            int arrIndex = 0;

            for (int i = 0; i < n; i++)
            {
                int max = int.MinValue;

                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                    }
                }
                array[arrIndex++] = max;
            }

            arrIndex = array.Length - 1;
            for (int i = 0; i < n; i++)
            {
                matrix[i, k] = array[arrIndex--];
            }
            // end

        }
        public void Task6(int[,] matrix, int[] array)
        {

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            if (array.Length != m)
            {
                return;
            }

            for (int j = 0; j < m; j++)
            {
                int max = int.MinValue;
                int maxIndex = 0;

                for (int i = 0; i < n; i++)
                {
                    if (max < matrix[i, j])
                    {
                        max = matrix[i, j];
                        maxIndex = i;
                    }
                }

                if (array[j] > matrix[maxIndex, j])
                {
                    matrix[maxIndex, j] = array[j];
                }
            }
            // end

        }
        public void Task7(int[,] matrix)
        {

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - 1 - i; j++)
                {
                    int min1 = matrix[j, 0]; int min2 = matrix[j + 1, 0];
                    for (int jj = 0; jj < m; jj++)
                    {
                        if (matrix[j, jj] < min1)
                        {
                            min1 = matrix[j, jj];
                        }
                        if (matrix[j + 1, jj] < min2)
                        {
                            min2 = matrix[j + 1, jj];
                        }
                    }

                    if (min1 < min2)
                    {
                        for (int jj = 0; jj < m; jj++)
                        {
                            (matrix[j, jj], matrix[j + 1, jj]) = (matrix[j + 1, jj], matrix[j, jj]);
                        }
                    }
                }
            }
            // end

        }
        public int[] Task8(int[,] matrix)
        {
            int[] answer = null;

            // code here
            if (matrix.GetLength(0) != matrix.GetLength(1))
            {
                return answer;
            }

            int n = matrix.GetLength(0);

            answer = new int[2 * n - 1];
            int ia = 0;

            for (int i = n - 1; i >= 0; i--)
            {
                int sum = 0;
                for (int j = 0; j < n - i; j++)
                {
                    sum += matrix[i + j, j]; 
                }
                answer[ia++] = sum;
            }

            for (int j = 1; j < n; j++)
            {
                int sum = 0;
                for (int i = 0; i < n - j; i++)
                {
                    sum += matrix[i, i + j];
                }
                answer[ia++] = sum;
            }
            // end

            return answer;
        }
        public void Task9(int[,] matrix, int k)
        {

            // code here
            if (matrix.GetLength(0 ) != matrix.GetLength(1))
            {
                return;
            }
            if (k >= matrix.GetLength(0))
            {
                return;
            }
            int n = matrix.GetLength(0);

            int maxRow = 0, maxCol = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (Math.Abs(matrix[i, j]) > Math.Abs(matrix[maxRow, maxCol]))
                    {
                        maxRow = i;
                        maxCol = j;
                    }
                }
            }

            if (maxRow < k)
            {
                for (int i = maxRow; i < k; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        (matrix[i, j], matrix[i + 1, j]) = (matrix[i + 1, j], matrix[i, j]);

                    }
                }
            }
            else if (maxRow > k)
            {
                for (int i = maxRow; i > k; i--)
                {
                    for (int j = 0; j < n; j++)
                    {
                        (matrix[i, j], matrix[i - 1, j]) = (matrix[i - 1, j], matrix[i, j]);
                    }
                }
            }

            if (maxCol < k)
            {
                for (int j = maxCol; j < k; j++)
                {
                    for (int i = 0; i < n; i++)
                    {
                        (matrix[i, j], matrix[i, j + 1]) = (matrix[i, j + 1], matrix[i, j]);
                    }
                }
            }
            else if (maxCol > k)
            {
                for (int j = maxCol; j > k; j--)
                {
                    for (int i = 0; i < n; i++)
                    {
                        (matrix[i, j], matrix[i, j - 1]) = (matrix[i, j - 1], matrix[i, j]);
                    }
                }
            }
            // end

        }
        public int[,] Task10(int[,] A, int[,] B)
        {
            int[,] answer = null;

            // code here
            int nA = A.GetLength(0); int mA = A.GetLength(1);
            int nB = B.GetLength(0); int mB = B.GetLength(1);

            if (nA != mB && mA != nB)
            {
                return answer;
            }

            answer = new int[nA, mB];

            for (int i = 0; i < nA; i++)
            {
                for (int j = 0; j < mB; j++)
                {
                    int sum = 0;
                    for (int k  = 0; k < mA; k++)
                    {
                        sum += A[i, k] * B[k, j];
                    }
                    answer[i, j] = sum;
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
                    if (matrix[i, j] > 0)
                    {
                        count++;
                    }
                }

                answer[i] = new int[count];
                int index = 0;

                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        answer[i][index++] = matrix[i, j];
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
            int count = 0;
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    count++;
                }
            }

            int[] newArray = new int[count];
            int index = 0;
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    newArray[index++] = array[i][j];
                }
            }

            int n = (int)Math.Ceiling(Math.Sqrt(count)); 

            answer = new int[n, n];
            index = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (index < count)
                    {
                        answer[i, j] = newArray[index++];
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
