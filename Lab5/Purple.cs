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
            // end

            return answer;
        }

        public void Task2(int[,] matrix)
        {

            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            if (cols == 0)
            {
                return;
            }

            for (int i = 0; i < rows; i++)
            {
                int minIndex = 0;
                int minValue = matrix[i, 0];

                for (int j = 1; j < cols; j++)
                {
                    if (matrix[i, j] < minValue)
                    {
                        minValue = matrix[i, j];
                        minIndex = j;
                    }
                }

                int temp = matrix[i, minIndex];

                for (int j = minIndex; j > 0; j--)
                {
                    matrix[i, j] = matrix[i, j - 1];
                }

                matrix[i, 0] = temp;
            }
            // end

        }

        public int[,] Task3(int[,] matrix)
        {
            int[,] answer = null;

            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            if (cols == 0)
            {
                answer = new int[rows, 0];
                return answer;
            }

            answer = new int[rows, cols + 1];

            for (int i = 0; i < rows; i++)
            {
                int maxIndex = 0;
                int maxValue = matrix[i, 0];

                for (int j = 1; j < cols; j++)
                {
                    if (matrix[i, j] > maxValue)
                    {
                        maxValue = matrix[i, j];
                        maxIndex = j;
                    }
                }

                int newColumnIndex = 0;

                for (int j = 0; j < cols; j++)
                {
                    answer[i, newColumnIndex] = matrix[i, j];

                    if (j == maxIndex)
                    {
                        newColumnIndex++;
                        answer[i, newColumnIndex] = matrix[i, j];
                    }

                    newColumnIndex++;
                }
            }
            // end

            return answer;
        }

        public void Task4(int[,] matrix)
        {

            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            if (cols == 0)
            {
                return;
            }

            for (int i = 0; i < rows; i++)
            {
                int maxValue = matrix[i, 0];
                int maxIndex = 0;

                for (int j = 1; j < cols; j++)
                {
                    if (matrix[i, j] > maxValue)
                    {
                        maxValue = matrix[i, j];
                        maxIndex = j;
                    }
                }

                int sumPos = 0;
                int countPos = 0;

                for (int j = maxIndex + 1; j < cols; j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        sumPos += matrix[i, j];
                        countPos++;
                    }
                }

                if (countPos == 0)
                {
                    continue;
                }

                int avg = sumPos / countPos;

                for (int j = 0; j < maxIndex; j++)
                {
                    if (matrix[i, j] < 0)
                    {
                        matrix[i, j] = avg;
                    }
                }
            }
            // end

        }

        public void Task5(int[,] matrix, int k)
        {

            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            if (rows == 0 || cols == 0)
            {
                return;
            }

            if (k < 0 || k >= cols)
            {
                return;
            }

            int[] rowMax = new int[rows];

            for (int i = 0; i < rows; i++)
            {
                int maxValue = matrix[i, 0];

                for (int j = 1; j < cols; j++)
                {
                    if (matrix[i, j] > maxValue)
                    {
                        maxValue = matrix[i, j];
                    }
                }

                rowMax[i] = maxValue;
            }

            for (int i = 0; i < rows; i++)
            {
                matrix[i, k] = rowMax[rows - 1 - i];
            }
            // end

        }

        public void Task6(int[,] matrix, int[] array)
        {

            // code here
            if (array.Length != matrix.GetLength(1))
                return;

            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                int max = Int32.MinValue, indexMax = 0;
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    if (max < matrix[i, j])
                    {
                        max = matrix[i, j];
                        indexMax = i;
                    }
                }

                if (array[j] > max)
                    matrix[indexMax, j] = array[j];
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

            // index of strings in matrix
            int[] index = new int[minValue.Length];
            for (int i = 0; i < minValue.Length; i++)
            {
                index[i] = i;
            }

            // Bubble Sort
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

            // copy of initial array
            int[,] clone = new int[matrix.GetLength(0), matrix.GetLength(1)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    clone[i, j] = matrix[i, j];
                }
            }

            // replace with correct value
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = clone[index[i], j];
                }
            }
            // end

        }

        public int[] Task8(int[,] matrix)
        {
            int[] answer = null;

            // code here
            
            if (matrix.GetLength(0) != matrix.GetLength(1))
                return answer;

            int size = matrix.GetLength(0); // size of matrix n * n
            answer = new int[2 * size - 1];

            int count = 1;
            for (int step = 0; step < answer.Length; step++)
            {
                // value below the main diagonal
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

                // the main diagonal
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

                // above the main diagonal
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

            return answer;
        
        }

        public void Task9(int[,] matrix, int k)
        {

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            if (n == 0 || m == 0 || n != m)
            {
                return;
            }

            if (k < 0 || k >= n)
            {
                return;
            }

            int maxRow = 0;
            int maxCol = 0;
            int maxAbs = Math.Abs(matrix[0, 0]);

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    int valueAbs = Math.Abs(matrix[i, j]);
                    if (valueAbs > maxAbs)
                    {
                        maxAbs = valueAbs;
                        maxRow = i;
                        maxCol = j;
                    }
                }
            }

            // Move row with max element to row k
            if (maxRow != k)
            {
                int[] tempRow = new int[n];

                for (int j = 0; j < n; j++)
                {
                    tempRow[j] = matrix[maxRow, j];
                }

                if (maxRow < k)
                {
                    for (int i = maxRow; i < k; i++)
                    {
                        for (int j = 0; j < n; j++)
                        {
                            matrix[i, j] = matrix[i + 1, j];
                        }
                    }
                }
                else
                {
                    for (int i = maxRow; i > k; i--)
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

                maxRow = k;
            }

            // Move column with max element to column k
            if (maxCol != k)
            {
                int[] tempCol = new int[n];

                for (int i = 0; i < n; i++)
                {
                    tempCol[i] = matrix[i, maxCol];
                }

                if (maxCol < k)
                {
                    for (int j = maxCol; j < k; j++)
                    {
                        for (int i = 0; i < n; i++)
                        {
                            matrix[i, j] = matrix[i, j + 1];
                        }
                    }
                }
                else
                {
                    for (int j = maxCol; j > k; j--)
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
            // end

        }

        public int[,] Task10(int[,] A, int[,] B)
        {
            int[,] answer = null;

            // code here
            int rowsA = A.GetLength(0);
            int colsA = A.GetLength(1);
            int rowsB = B.GetLength(0);
            int colsB = B.GetLength(1);

            if (colsA != rowsB)
            {
                return null;
            }

            answer = new int[rowsA, colsB];

            int totalCells = rowsA * colsB;

            for (int index = 0; index < totalCells; index++)
            {
                int i = index / colsB;
                int j = index % colsB;

                int sum = 0;

                for (int k = 0; k < colsA; k++)
                {
                    sum += A[i, k] * B[k, j];
                }

                answer[i, j] = sum;
            }
            // end

            return answer;
        }

        public int[][] Task11(int[,] matrix)
        {
            int[][] answer = null;

            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            answer = new int[rows][];

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

                int[] row = new int[count];
                int index = 0;

                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        row[index] = matrix[i, j];
                        index++;
                    }
                }

                answer[i] = row;
            }
            // end

            return answer;
        }

        public int[,] Task12(int[][] array)
        {
            int[,] answer = null;

            // code here
            if (array == null)
            {
                return null;
            }

            int total = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] != null)
                {
                    total += array[i].Length;
                }
            }

            int size = 0;

            if (total > 0)
            {
                size = (int)Math.Sqrt(total);
                if (size * size < total)
                {
                    size++;
                }
            }

            answer = new int[size, size];

            if (size == 0)
            {
                return answer;
            }

            int index = 0;

            for (int i = 0; i < array.Length; i++)
            {
                int[] row = array[i];

                if (row == null)
                {
                    continue;
                }

                for (int j = 0; j < row.Length; j++)
                {
                    if (index >= size * size)
                    {
                        break;
                    }

                    int rowIndex = index / size;
                    int colIndex = index % size;

                    answer[rowIndex, colIndex] = row[j];
                    index++;
                }
            }
            // end

            return answer;
        }
    }
}
