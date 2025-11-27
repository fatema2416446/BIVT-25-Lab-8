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

            // code here
            for (int j = 0; j < cols; j++)
            {
                int negativeCount = 0;
                for (int i = 0; i < rows; i++)
                {
                    if (matrix[i, j] < 0)
                    {
                        negativeCount++;
                    }
                }
                answer[j] = negativeCount;
            }
            // end

            return answer;
        }
        public void Task2(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            
            // code here
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
                
                for (int j = minIndex; j > 0; j--)
                {
                    matrix[i, j] = matrix[i, j - 1];
                }
                
                matrix[i, 0] = minValue;
            }
            // end
        }
        public int[,] Task3(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            int[,] answer = new int[rows, cols + 1];

            // code here
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
                
                for (int j = 0; j <= maxIndex; j++)
                {
                    answer[i, j] = matrix[i, j];
                }
                
                answer[i, maxIndex + 1] = maxValue;
                
                for (int j = maxIndex + 1; j < cols; j++)
                {
                    answer[i, j + 1] = matrix[i, j];
                }
            }
            // end

            return answer;
        }
        public void Task4(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            
            // code here
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
                
                if (count > 0)
                {
                    int average = sum / count; 
                    
                    for (int j = 0; j < maxIndex; j++)
                    {
                        if (matrix[i, j] < 0)
                        {
                            matrix[i, j] = average;
                        }
                    }
                }
            }
            // end
        }
        public void Task5(int[,] matrix, int k)
        {
            bool flag = true;
            if (matrix == null)
                flag = false;
            
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            
            if (rows == 0 || cols == 0)
                flag = false;
            
            if (k < 0 || k >= cols)
                flag = false;
            
            if (!flag)
                return;

            int[] maxElements = new int[rows];
            
            for (int i = 0; i < rows; i++)
            {
                int maxInRow = matrix[i, 0];
                for (int j = 1; j < cols; j++)
                {
                    if (matrix[i, j] > maxInRow)
                        maxInRow = matrix[i, j];
                }
                maxElements[rows - 1 - i] = maxInRow; 
            }
            
            for (int i = 0; i < rows; i++)
            {
                matrix[i, k] = maxElements[i];
            }
        }
        public void Task6(int[,] matrix, int[] array)
        {
            
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            bool flag = true;
            
            if (rows == 0 || cols == 0)
                flag = false;
            
            if (array.Length == 0)
                flag = false;
            
            if (cols != array.Length)
                flag = false;
            
            if (!flag)
                return;
            
            for (int j = 0; j < cols; j++)
            {
                int maxRowIndex = 0;
                int maxValue = matrix[0, j];
                
                for (int i = 1; i < rows; i++)
                {
                    if (matrix[i, j] > maxValue)
                    {
                        maxValue = matrix[i, j];
                        maxRowIndex = i;
                    }
                }
                
                if (array[j] > maxValue)
                {
                    matrix[maxRowIndex, j] = array[j];
                }
            }
        }

        public void Task7(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            
            // code here
            int[] minValues = new int[rows];
            int[] rowIndices = new int[rows];
            
            for (int i = 0; i < rows; i++)
            {
                int min = matrix[i, 0];
                for (int j = 1; j < cols; j++)
                {
                    if (matrix[i, j] < min)
                        min = matrix[i, j];
                }
                minValues[i] = min;
                rowIndices[i] = i;
            }
            
            for (int i = 0; i < rows - 1; i++)
            {
                for (int j = i + 1; j < rows; j++)
                {
                    if (minValues[i] < minValues[j])
                    {
                        int tempMin = minValues[i];
                        minValues[i] = minValues[j];
                        minValues[j] = tempMin;
                        
                        int tempIdx = rowIndices[i];
                        rowIndices[i] = rowIndices[j];
                        rowIndices[j] = tempIdx;
                    }
                }
            }
            
            int[,] temp = new int[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    temp[i, j] = matrix[rowIndices[i], j];
                }
            }
            
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = temp[i, j];
                }
            }
            // end
        }

        public int[] Task8(int[,] matrix)
        {
            bool flag = true;
            int n = matrix.GetLength(0);
            
            if (matrix.GetLength(1) != n)
                flag = false;
            
            if (!flag)
                return null;

            int[] answer = new int[2 * n - 1];
            int index = 0;
            
            for (int d = n - 1; d >= 1 - n; d--)
            {
                int sum = 0;
                for (int i = 0; i < n; i++)
                {
                    int j = i - d;
                    if (j >= 0 && j < n)
                    {
                        sum += matrix[i, j];
                    }
                }
                answer[index++] = sum;
            }
            
            return answer;
        }

        public void Task9(int[,] matrix, int k)
        {
            int n = matrix.GetLength(0);

            if (matrix.GetLength(1) != n)
                return;

            if (k < 0 || k >= n)
                return;
            
            // code here
            int maxRow = 0, maxCol = 0;
            int maxAbs = Math.Abs(matrix[0, 0]);
            
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    int absValue = Math.Abs(matrix[i, j]);
                    if (absValue > maxAbs)
                    {
                        maxAbs = absValue;
                        maxRow = i;
                        maxCol = j;
                    }
                }
            }
            
            int[,] temp = new int[n, n];
            
            for (int i = 0; i < n; i++)
            {
                int sourceRow = i;
                if (i == k) sourceRow = maxRow;
                else if (i < k && i < maxRow) sourceRow = i;
                else if (i < k && i >= maxRow) sourceRow = i + 1;
                else if (i > k && i <= maxRow) sourceRow = i - 1;
                else if (i > k && i > maxRow) sourceRow = i;
                
                for (int j = 0; j < n; j++)
                {
                    int sourceCol = j;
                    if (j == k) sourceCol = maxCol;
                    else if (j < k && j < maxCol) sourceCol = j;
                    else if (j < k && j >= maxCol) sourceCol = j + 1;
                    else if (j > k && j <= maxCol) sourceCol = j - 1;
                    else if (j > k && j > maxCol) sourceCol = j;
                    
                    temp[i, j] = matrix[sourceRow, sourceCol];
                }
            }
            
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = temp[i, j];
                }
            }
            // end
        }

        public int[,] Task10(int[,] A, int[,] B)
        {
            int rowsA = A.GetLength(0);
            int colsA = A.GetLength(1);
            int rowsB = B.GetLength(0);
            int colsB = B.GetLength(1);
            
            if (colsA != rowsB)
                return null;
            
            int[,] answer = new int[rowsA, colsB];
            
            // code here
            for (int i = 0; i < rowsA; i++)
            {
                for (int j = 0; j < colsB; j++)
                {
                    int sum = 0;
                    for (int m = 0; m < colsA; m++)
                    {
                        sum += A[i, m] * B[m, j];
                    }
                    answer[i, j] = sum;
                }
            }
            // end
            
            return answer;
        }

        public int[][] Task11(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            
            // code here
            int[][] answer = new int[rows][];
            
            for (int i = 0; i < rows; i++)
            {
                int count = 0;
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] > 0)
                        count++;
                }
                
                answer[i] = new int[count];
                int index = 0;
                
                for (int j = 0; j < cols; j++)
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
            int totalElements = 0;
            foreach (var row in array)
            {
                totalElements += row.Length;
            }
            
            int n = (int)Math.Ceiling(Math.Sqrt(totalElements));
            int[,] answer = new int[n, n];
            
            // code here
            int currentRow = 0;
            int currentCol = 0;
            
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    answer[currentRow, currentCol] = array[i][j];
                    currentCol++;
                    if (currentCol >= n)
                    {
                        currentCol = 0;
                        currentRow++;
                    }
                }
            }
            
            // end
            
            return answer;
        }
    }
}