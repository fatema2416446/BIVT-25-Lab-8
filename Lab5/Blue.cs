using System.Linq;
using System.Runtime.InteropServices;

namespace Lab5
{
    public class Blue
    {
        public double[] Task1(int[,] matrix)
        {
            double[] answer = new double[matrix.GetLength(0)];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int sum = 0;
                int countPositive = 0;

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        sum += matrix[i, j];
                        countPositive++;
                    }
                }

                if (countPositive > 0)
                    answer[i] = sum / (double)countPositive;
                else
                    answer[i] = 0;
            }

            return answer;
        }
        public int[,] Task2(int[,] matrix)
        {
            int[,] answer = null;

            int maxElement = matrix[0, 0];
            int imax = 0, jmax = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > maxElement)
                    {
                        maxElement = matrix[i, j];
                        imax = i;
                        jmax = j;
                    }
                }
            }
            
            answer = new int[matrix.GetLength(0) - 1, matrix.GetLength(1) - 1];

            int ri = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (i == imax)
                    continue;

                int rj = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (j == jmax)
                        continue;
                    
                    answer[ri, rj] = matrix[i, j];
                    rj++;
                }

                ri++;
            }
            
            return answer;
        }
        public void Task3(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int maxEl = matrix[i, 0];
                int jmax = 0;
                
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > maxEl)
                    {
                        maxEl = matrix[i, j];
                        jmax = j;
                    }    
                }

                for (int j = jmax; j < matrix.GetLength(1) - 1; j++)
                    matrix[i, j] = matrix[i, j + 1];

                matrix[i, matrix.GetLength(1) - 1] = maxEl;
            }
        }
        
        public int[,] Task4(int[,] matrix)
        {
            int[,] answer = new int[matrix.GetLength(0), matrix.GetLength(1) + 1];

            int[] maxElements = new int[matrix.GetLength(0)];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int maxElement = matrix[i, 0];
                
                for (int j = 1; j < matrix.GetLength(1); j++)
                    if (matrix[i, j] > maxElement)
                        maxElement = matrix[i, j];
                
                maxElements[i] = maxElement;
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1) + 1; j++)
                {
                    if (j < matrix.GetLength(1) - 1)
                        answer[i, j] = matrix[i, j];
                    
                    else if (j == matrix.GetLength(1) - 1)
                        answer[i, j] = maxElements[i];
                    
                    else
                        answer[i, j] = matrix[i, matrix.GetLength(1) - 1];
                }
            }

            return answer;
        }

        public int[] Task5(int[,] matrix)
        {
            int count = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if ((i + j) % 2 != 0)
                        count += 1;
                }
            }
            
            int[] answer = new int[count];
            int ansIndex = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if ((i + j) % 2 != 0)
                    {
                        answer[ansIndex] = matrix[i, j];
                        ansIndex++;
                    }
                }
            }
            
            return answer;
        }
        public void Task6(int[,] matrix, int k)
        {
            int n = matrix.GetLength(0);

            if (matrix.GetLength(0) != matrix.GetLength(1) || k < 0 || k >= n)
                return;

            int iMaxEl = 0;
            int maxDiag = matrix[0, 0];
            for (int i = 1; i < n; i++)
            {
                if (matrix[i, i] > maxDiag)
                {
                    maxDiag = matrix[i, i];
                    iMaxEl = i;
                }
            }

            int negIndex = -1;
            for (int i = 0; i < n; i++)
            {
                if (matrix[i, k] < 0)
                {
                    negIndex = i;
                    break;
                }
            }

            if (negIndex == -1 || negIndex == iMaxEl)
                return;

            for (int j = 0; j < n; j++)
            {
                (matrix[negIndex, j], matrix[iMaxEl, j]) = (matrix[iMaxEl, j], matrix[negIndex, j]);
            }
        }

        public void Task7(int[,] matrix, int[] array)
        {
            if (matrix.GetLength(1) < 2 || array.Length != matrix.GetLength(0))
                return;
            
            int maxElement = matrix[0, matrix.GetLength(1) - 2];
            int iMaxEl = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, matrix.GetLength(1) - 2] > maxElement)
                {
                    maxElement = matrix[i, matrix.GetLength(1) - 2];
                    iMaxEl = i;
                }
            }

            for (int i = 0; i < matrix.GetLength(1); i++)
                matrix[iMaxEl, i] = array[i];
            
        }
        public void Task8(int[,] matrix)
        {
            int half = matrix.GetLength(0) / 2;

            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                int maxElement = matrix[0, j];
                int iMax = 0;

                for (int i = 1; i < matrix.GetLength(0); i++)
                {
                    if (matrix[i, j] > maxElement)
                    {
                        maxElement = matrix[i, j];
                        iMax = i;
                    }
                }

                if (iMax < half)
                {
                    int sum = 0;

                    for (int i = iMax + 1; i < matrix.GetLength(0); i++)
                        sum += matrix[i, j];

                    matrix[0, j] = sum;
                }
            }
        }

        public void Task9(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (i % 2 == 0)
                {
                    if (i == matrix.GetLength(0) - 1)
                        continue;
                    
                    int maxEl = matrix[i, 0];
                    int maxElJ = 0;
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        if (matrix[i, j] > maxEl)
                        {
                            maxEl = matrix[i, j];
                            maxElJ = j;
                        }
                    }
                    
                    int maxElNext = matrix[i + 1, 0];
                    int maxElNextJ = 0;
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        if (matrix[i + 1, j] > maxElNext)
                        {
                            maxElNext = matrix[i + 1, j];
                            maxElNextJ = j;
                        }
                    }
                    
                    matrix[i + 1, maxElNextJ] = maxEl;
                    matrix[i, maxElJ] = maxElNext;
                }
            }
        }
        public void Task10(int[,] matrix)
        {
            if (matrix.GetLength(0) != matrix.GetLength(1))
                return;
            
            int maxDiagElement = matrix[0, 0];
            int iMaxEl = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, i] > maxDiagElement)
                {
                    maxDiagElement = matrix[i, i];
                    iMaxEl = i;
                }
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++)
                    if (i < j && i < iMaxEl)
                        matrix[i, j] = 0;
            
        }
        public void Task11(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            int[] counts = new int[rows];

            for (int i = 0; i < rows; i++)
            {
                int count = 0;
                for (int j = 0; j < cols; j++)
                    if (matrix[i, j] > 0)
                        count++;

                counts[i] = count;
            }

            for (int i = 0; i < rows - 1; i++)
            {
                int maxIndex = i;

                for (int k = i + 1; k < rows; k++)
                    if (counts[k] > counts[maxIndex])
                        maxIndex = k;

                if (maxIndex != i)
                {
                    int tempCount = counts[i];
                    counts[i] = counts[maxIndex];
                    counts[maxIndex] = tempCount;

                    for (int j = 0; j < cols; j++)
                    {
                        int temp = matrix[i, j];
                        matrix[i, j] = matrix[maxIndex, j];
                        matrix[maxIndex, j] = temp;
                    }
                }
            }
        }

        public int[][] Task12(int[][] array)
        {
            int totalSum = 0;
            int totalCount = 0;

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    totalSum += array[i][j];
                    totalCount++;
                }
            }

            if (totalCount == 0)
                return new int[0][];

            double globalAvg = (double)totalSum / totalCount;

            int keepCount = 0;

            for (int i = 0; i < array.Length; i++)
            {
                int sum = 0;
                for (int j = 0; j < array[i].Length; j++)
                    sum += array[i][j];

                double rowAvg = array[i].Length > 0 ? (double)sum / array[i].Length : double.NegativeInfinity;

                if (rowAvg >= globalAvg)
                    keepCount++;
            }

            int[][] answer = new int[keepCount][];
            int p = 0;

            for (int i = 0; i < array.Length; i++)
            {
                int sum = 0;
                for (int j = 0; j < array[i].Length; j++)
                    sum += array[i][j];

                double rowAvg = array[i].Length > 0 ? (double)sum / array[i].Length : double.NegativeInfinity;

                if (rowAvg >= globalAvg)
                {
                    answer[p] = array[i];
                    p++;
                }
            }

            return answer;
        }

    }
}