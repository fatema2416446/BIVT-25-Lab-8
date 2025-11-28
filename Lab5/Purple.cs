using System.Linq;
using System.Runtime.InteropServices;

namespace Lab5
{
    public class Purple
    {
        public int[] Task1(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            
            int[] answer = new int[cols];

            for (int col = 0; col < cols; ++col)
            {
                int count = 0;
                for (int row = 0; row < rows; ++row)
                {
                    if (matrix[row, col] < 0)
                    {
                        ++count;
                    }
                }

                answer[col] = count;
            }

            return answer;
        }
        
        public void Task2(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int row = 0; row < rows; ++row)
            {
                int minElemIdx = 0;
                int minElem = matrix[row, minElemIdx];
                for (int col = 1; col < cols; ++col)
                {
                    if (matrix[row, col] < minElem)
                    {
                        minElemIdx = col;
                        minElem = matrix[row, minElemIdx];
                    }
                }

                for (int j = minElemIdx; j > 0; --j)
                {
                    matrix[row, j] = matrix[row, j - 1];
                }
                    
                matrix[row, 0]  = minElem;
            }

        }
        public int[,] Task3(int[,] matrix)
        {
            int rows  = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            int[,] answer = new int[rows, cols + 1];

            for (int i = 0; i < rows; ++i)
            {
                int maxElem = matrix[i, 0];
                int maxElemIdx = 0;
                for (int j = 1; j < cols; ++j)
                {
                    if (matrix[i, j] > maxElem)
                    {
                        maxElemIdx = j;
                        maxElem = matrix[i, j];
                    }
                }

                for (int j = 0; j <= maxElemIdx; ++j)
                {
                    answer[i, j] = matrix[i, j];
                }
                answer[i, maxElemIdx + 1] = maxElem;
                for (int j = maxElemIdx + 1; j < cols; ++j)
                {
                    answer[i, j + 1] = matrix[i, j];
                }
            }
            return answer;
        }
        public void Task4(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int i = 0; i < rows; ++i)
            {
                int maxElemIdx = 0;
                int maxElem = matrix[i, 0];

                for (int j = 1; j < cols; ++j)
                {
                    if (matrix[i, j] > maxElem)
                    {
                        maxElemIdx = j;
                        maxElem = matrix[i, j];
                    }
                }
                if (maxElemIdx == cols - 1)
                {
                    continue;
                }
                int positiveElemsCount = 0;
                int positiveElemsSum = 0;
                for (int j = maxElemIdx + 1; j < cols; ++j)
                {
                    if (matrix[i, j] > 0)
                    {
                        ++positiveElemsCount;
                        positiveElemsSum += matrix[i, j];
                    }
                }

                if (positiveElemsCount == 0)
                {
                    continue;
                }

                int avg = positiveElemsSum / positiveElemsCount;
                
                for (int j = 0; j < maxElemIdx; ++j)
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
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            if (k >= cols || k < 0)
            {
                return;
            }
            int[] maxElems = new int[rows];
            for (int row = 0; row < rows; ++row)
            {
                int maxElem = matrix[row, 0];
                for (int col = 1; col < cols; ++col) 
                {
                    if (matrix[row, col] > maxElem) 
                    {
                        maxElem = matrix[row, col];
                    }
                }
                maxElems[row] = maxElem;
            }
            
            for (int i = 0; i < rows; ++i)
            {
                matrix[i, k] = maxElems[rows - i - 1];
            }
        }
        public void Task6(int[,] matrix, int[] array)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            if (array.Length != cols)
            {
                return;
            }
            int[] maxElemsIds = new int[cols];
            for (int col = 0; col < cols; ++col)
            {
                int maxElemIdx = 0;
                for (int row = 1; row < rows; ++row)
                {
                    if (matrix[row, col] > matrix[maxElemIdx, col])
                    {
                        maxElemIdx = row;
                    }
                }
                maxElemsIds[col]  = maxElemIdx;
            }

            for (int i = 0; i < cols; ++i)
            {
                if (array[i] > matrix[maxElemsIds[i], i])
                {
                    matrix[maxElemsIds[i], i]  = array[i];
                }
            }
        }
        public void Task7(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            int[] minElems = new int[rows];
            for (int row = 0; row < rows; ++row)
            {
                int minElem =  matrix[row, 0];
                for (int j = 1; j < cols; ++j)
                {
                    if (matrix[row, j] < minElem)
                    {
                        minElem = matrix[row, j];
                    }
                }
                minElems[row] = minElem;
            }

            for (int i = 0; i < rows - 1; ++i)
            {
                for (int j = 0; j < rows - i - 1; ++j)
                {
                    if (minElems[j] < minElems[j + 1])
                    {
                        int tempMin = minElems[j];
                        minElems[j] = minElems[j + 1];
                        minElems[j + 1] = tempMin;
                        
                        for (int k = 0; k < cols; ++k)
                        {
                            int temp = matrix[j, k];
                            matrix[j, k] = matrix[j + 1, k];
                            matrix[j + 1, k] = temp;
                        }
                    }
                }
            }
        }
        public int[] Task8(int[,] matrix)
        {
            if (matrix.GetLength(0) != matrix.GetLength(1))
            {
                return null;
            }
            int n = matrix.GetLength(0);
            int[] answer = new int[2 * n - 1];
            int idx = 0;
            for (int start = n - 1; start >= 1; --start)
            {
                int sum = 0;
                int i = start;
                int j = 0;

                while (i < n && j < n)
                {
                    sum += matrix[i, j];
                    ++i;
                    ++j;
                }

                answer[idx++] = sum;
            }
            
            {
                int sum = 0;
                for (int k = 0; k < n; ++k)
                {
                    sum += matrix[k, k];
                }

                answer[idx++] = sum;
            }
            
            for (int start = 1; start <= n - 1; ++start)
            {
                int sum = 0;
                int i = 0;
                int j = start;

                while (i < n && j < n)
                {
                    sum += matrix[i, j];
                    ++i;
                    ++j;
                }

                answer[idx++] = sum;
            }

            return answer;
        }
        public void Task9(int[,] matrix, int k)
        {
            if (matrix.GetLength(0) != matrix.GetLength(1))
            {
                return;
            }
            int n = matrix.GetLength(0);
            int maxElem = Math.Abs(matrix[0, 0]);
            int maxRow = 0, maxCol = 0;
            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    if (Math.Abs(matrix[i, j]) > maxElem)
                    {
                        maxElem = Math.Abs(matrix[i, j]);
                        maxRow = i;
                        maxCol = j;
                    }
                }
            }

            if (maxRow < k)
            {
                for (int i = maxRow; i < k; ++i)
                {
                    for (int j = 0; j < n; ++j)
                    {
                        int tmp = matrix[i, j];
                        matrix[i, j] = matrix[i + 1, j];
                        matrix[i + 1, j] = tmp;
                    }
                }
            }
            else if (maxRow > k)
            {
                for (int i = maxRow; i > k; --i)
                {
                    for (int j = 0; j < n; ++j)
                    {
                        int tmp = matrix[i, j];
                        matrix[i, j] = matrix[i - 1, j];
                        matrix[i - 1, j] = tmp;
                    }   
                }
            }
            
            if (maxCol < k)
            {
                for (int j = maxCol; j < k; ++j)
                {
                    for (int i = 0; i < n; ++i)
                    {
                        int tmp = matrix[i, j];
                        matrix[i, j] = matrix[i, j + 1];
                        matrix[i, j + 1] = tmp;
                    }
                }
            }
            else if (maxCol > k)
            {
                for (int j = maxCol; j > k; --j)
                {
                    for (int i = 0; i < n; ++i)
                    {
                        int tmp = matrix[i, j];
                        matrix[i, j] = matrix[i, j - 1];
                        matrix[i, j - 1] = tmp;
                    }
                }
            }
            
        }
        public int[,] Task10(int[,] A, int[,] B)
        {
            if (A.GetLength(1) != B.GetLength(0))
            {
                return null;
            }
            int rows  = A.GetLength(0);
            int cols = B.GetLength(1);
            int[,] c = new int[rows, cols];

            for (int i = 0; i < rows; ++i)
            {
                for (int j = 0; j < cols; ++j)
                {
                    int sum = 0;
                    for (int k = 0; k < A.GetLength(1); ++k)
                    {
                        sum  += A[i, k] * B[k, j];
                    }
                    c[i, j] = sum;
                }
            }

            return c;
        }
        public int[][] Task11(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            int[][] answer = new int[rows][];

            for (int i = 0; i < rows; ++i)
            {
                int positiveCount = 0;
                for (int j = 0; j < cols; ++j)
                {
                    positiveCount += matrix[i, j] > 0 ? 1 : 0;
                }
                answer[i] = new int[positiveCount];

                int idx = 0;
                for (int j = 0; j < cols; ++j)
                {
                    if (matrix[i, j] > 0)
                    {
                        answer[i][idx++] = matrix[i, j];
                    }
                }
            }
            return answer;
        }
        public int[,] Task12(int[][] array)
        {
            int total = 0;
            for (int i = 0; i < array.Length; ++i)
            {
                total += array[i].Length;
            }

            int n = 1;
            while (n * n < total)
            {
                ++n;
            }

            int[,] answer = new int[n, n];
            int row = 0, col = 0;

            for (int i = 0; i < array.Length; ++i)
            {
                for (int j = 0; j < array[i].Length; ++j)
                {
                    answer[row, col] = array[i][j];
                    ++col;
                    if (col == n)
                    {
                        col = 0;
                        ++row;
                    }
                }
            }
            return answer;
        }
    }
}