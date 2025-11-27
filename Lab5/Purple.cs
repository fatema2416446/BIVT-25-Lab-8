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
            if (matrix.GetLength(0) == 0 || matrix.GetLength(1) == 0)
            {
                return null;
            }

            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            answer = new int[cols];

            for (int j = 0; j < cols; j++)
            {
                int count = 0;
                for (int i = 0; i < rows; i++)
                {
                    if (matrix[i, j] < 0)
                    {
                        count++;
                    }
                }
                answer[j] = count;
            }

            return answer;
        }
        public void Task2(int[,] matrix)
        {
            // code here
            if (matrix.GetLength(0) == 0 || matrix.GetLength(1) == 0) return;

            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                int minVal = matrix[i, 0];
                int minIndex = 0;

                for (int j = 1; j < cols; j++)
                {
                    if (matrix[i, j] < minVal)
                    {
                        minVal = matrix[i, j];
                        minIndex = j;
                    }
                }

                for (int k = minIndex; k > 0; k--)
                {
                    matrix[i, k] = matrix[i, k - 1];
                }

                matrix[i, 0] = minVal;
            }
            // end
        }
        public int[,] Task3(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            int[,] result = new int[rows, cols + 1];

            for (int i = 0; i < rows; i++)
            {
                int maxIndex = 0;
                for (int j = 1; j < cols; j++)
                {
                    if (matrix[i, j] > matrix[i, maxIndex])
                    {
                        maxIndex = j;
                    }
                }

                int p = 0;
                for (int k = 0; k < cols + 1; k++)
                {
                    if (k == maxIndex + 1)
                    {
                        result[i, k] = matrix[i, maxIndex];
                    }
                    else
                    {
                        result[i, k] = matrix[i, p];
                        p++;
                    }
                }
            }

            return result;
        }
        public void Task4(int[,] matrix)
        {
            if (matrix == null || matrix.Length == 0)
            {
                return;
            }

            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                int maxIndex = 0;
                for (int j = 1; j < cols; j++)
                {
                    if (matrix[i, j] > matrix[i, maxIndex])
                    {
                        maxIndex = j;
                    }
                }

                int sum = 0;
                int count = 0;

                for (int j = maxIndex + 1; j < cols; j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        sum += matrix[i, j];
                        count++;
                    }
                }

                if (count == 0)
                {
                    continue;
                }

                int avg = sum / count;

                for (int j = 0; j < maxIndex; j++)
                {
                    if (matrix[i, j] < 0)
                    {
                        matrix[i, j] = avg;
                    }
                }
            }
        }
        public void Task5(int[,] matrix, int k)
        {
            if (matrix.GetLength(0) == 0 || matrix.GetLength(1) == 0) return;

            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            if (k < 0 || k >= cols)
            {
                return;
            }

            int[] maxValues = new int[rows];

            for (int i = 0; i < rows; i++)
            {
                int max = matrix[i, 0];
                for (int j = 1; j < cols; j++)
                {
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                    }
                }
                maxValues[i] = max;
            }

            for (int i = 0; i < rows; i++)
            {
                matrix[i, k] = maxValues[rows - 1 - i];
            }

        }
        public void Task6(int[,] matrix, int[] array)
        {

            if (matrix.GetLength(0) == 0 || matrix.GetLength(1) == 0) return;

            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            if (array.Length != cols)
            {
                return;
            }

            for (int j = 0; j < cols; j++)
            {
                int maxVal = matrix[0, j];
                int maxRowIndex = 0;

                for (int i = 1; i < rows; i++)
                {
                    if (matrix[i, j] > maxVal)
                    {
                        maxVal = matrix[i, j];
                        maxRowIndex = i;
                    }
                }

                if (array[j] > maxVal)
                {
                    matrix[maxRowIndex, j] = array[j];
                }
            }

        }
        public void Task7(int[,] matrix)
        {
            if (matrix.GetLength(0) == 0 || matrix.GetLength(1) == 0) return;

            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            (int[] RowData, int MinVal)[] rowInfos = new (int[], int)[rows];

            for (int i = 0; i < rows; i++)
            {
                int min = matrix[i, 0];
                int[] tempRow = new int[cols];

                for (int j = 0; j < cols; j++)
                {
                    tempRow[j] = matrix[i, j];
                    if (matrix[i, j] < min)
                    {
                        min = matrix[i, j];
                    }
                }
                rowInfos[i] = (tempRow, min);
            }

            Array.Sort(rowInfos, (a, b) => b.MinVal.CompareTo(a.MinVal));

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = rowInfos[i].RowData[j];
                }
            }
        }
        public int[] Task8(int[,] matrix)
        {
            if (matrix.GetLength(0) != matrix.GetLength(1)) return null;

            int n = matrix.GetLength(0);
            int[] result = new int[2 * n - 1];

            int resultIndex = 0;

            for (int startRow = n - 1; startRow >= 0; startRow--)
            {
                int sum = 0;
                int r = startRow;
                int c = 0;

                while (r < n && c < n)
                {
                    sum += matrix[r, c];
                    r++;
                    c++;
                }
                result[resultIndex++] = sum;
            }

            for (int startCol = 1; startCol < n; startCol++)
            {
                int sum = 0;
                int r = 0;
                int c = startCol;

                while (r < n && c < n)
                {
                    sum += matrix[r, c];
                    r++;
                    c++;
                }
                result[resultIndex++] = sum;
            }

            return result;
        }
        public void Task9(int[,] matrix, int k)
        {
            int n = matrix.GetLength(0);

            if (n == 0 || n != matrix.GetLength(1) || k < 0 || k >= n) return;

            int mAbsValue = -1;
            int mRow = -1;
            int mCol = -1;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    int absValue = Math.Abs(matrix[i, j]);
                    if (absValue > mAbsValue)
                    {
                        mAbsValue = absValue;
                        mRow = i;
                        mCol = j;
                    }
                }
            }

            if (mRow == -1) return;

            if (mRow != k)
            {
                int[] tempRow = new int[n];
                for (int j = 0; j < n; j++)
                {
                    tempRow[j] = matrix[mRow, j];
                }

                if (mRow < k)
                {
                    for (int i = mRow; i < k; i++)
                    {
                        for (int j = 0; j < n; j++)
                        {
                            matrix[i, j] = matrix[i + 1, j];
                        }
                    }
                }
                else
                {
                    for (int i = mRow; i > k; i--)
                    {
                        for (int j = 0; j < n; j++)
                        {
                            matrix[i, j] = matrix[i - 1, j];
                        }
                    }
                }

                for (int j = 0; j < n; j++)
                {
                    matrix[k, j] = tempRow[j];
                }
            }

            if (mCol != k)
            {
                int[] tempCol = new int[n];
                for (int i = 0; i < n; i++)
                {
                    tempCol[i] = matrix[i, mCol];
                }
                if (mCol < k)
                {
                    for (int j = mCol; j < k; j++)
                    {
                        for (int i = 0; i < n; i++)
                        {
                            matrix[i, j] = matrix[i, j + 1];
                        }
                    }
                }
                else
                {
                    for (int j = mCol; j > k; j--)
                    {
                        for (int i = 0; i < n; i++)
                        {
                            matrix[i, j] = matrix[i, j - 1];
                        }
                    }
                }
                for (int i = 0; i < n; i++)
                {
                    matrix[i, k] = tempCol[i];
                }
            }
        }
        public int[,] Task10(int[,] matrixA, int[,] matrixB)
        {
            int m = matrixA.GetLength(0);
            int n = matrixA.GetLength(1);

            int n_prime = matrixB.GetLength(0);
            int p = matrixB.GetLength(1);

            if (n != n_prime)
            {
                return null;
            }

            int[,] matrixC = new int[m, p];

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < p; j++)
                {

                    int sum = 0;
                    for (int k = 0; k < n; k++)
                    {
                        sum += matrixA[i, k] * matrixB[k, j];
                    }
                    matrixC[i, j] = sum;
                }
            }

            return matrixC;
        }
        public int[][] Task11(int[,] matrix)
        {
            if (matrix.GetLength(0) == 0) return new int[0][];

            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            int[] counts = new int[rows];

            for (int i = 0; i < rows; i++)
            {
                int count = 0;
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        count++;
                    }
                }
                counts[i] = count;
            }

            int[][] res = new int[rows][];

            for (int i = 0; i < rows; i++)
            {
                int length = counts[i];

                res[i] = new int[length];

                int curr = 0;
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        res[i][curr] = matrix[i, j];
                        curr++;
                    }
                }
            }

            return res;
        }

        public int[,] Task12(int[][] array)
        {
            int total = 0;
            if (array != null)
            {
                foreach (var inner in array)
                {
                    if (inner != null)
                    {
                        total += inner.Length;
                    }
                }
            }

            int n = 0;
            if (total > 0)
            {
                n = (int)Math.Ceiling(Math.Sqrt(total));
            }

            int[,] result = new int[n, n];

            if (total == 0)
            {
                return result;
            }

            int ind = 0;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (ind < total)
                    {

                        int currRow = 0;
                        int currCol = 0;
                        int cumLength = 0;

                        for (int row = 0; row < array.Length; row++)
                        {
                            int rowLength = (array[row] != null) ? array[row].Length : 0;
                            if (ind < cumLength + rowLength)
                            {
                                currRow = row;
                                currCol = ind - cumLength;
                                break;
                            }
                            cumLength += rowLength;
                        }

                        result[i, j] = array[currRow][currCol];
                        ind++;
                    }
                    else { }
                }
            }

            return result;
        }
    }
}