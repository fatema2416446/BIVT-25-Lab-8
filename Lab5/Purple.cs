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
                int cnt = 0;
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    if (matrix[j, i] < 0)
                    {
                        cnt++;
                    }
                }
                answer[ind] = cnt;
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
                int minRow = int.MaxValue;
                int minIndex = 0;
                int[] tempString = new int[matrix.GetLength(1)];
                int ind = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    tempString[ind] = matrix[i, j];
                    ind++;
                    if (minRow > matrix[i, j])
                    {
                        minRow = matrix[i, j];
                        minIndex = j;
                    }
                }
                if (minIndex == 0)
                {
                    continue;
                }
                else if (minIndex == matrix.GetLength(1) - 1)
                {
                    matrix[i, 0] =  tempString[minIndex];
                    for (int k = 0; k < matrix.GetLength(1)-1; k++)
                    {
                        matrix[i, k+1] =  tempString[k];
                    }
                }
                else
                {
                    matrix[i, 0] =  tempString[minIndex];
                    for (int k = 0; k < matrix.GetLength(1) - 1; k++)
                        if (k < minIndex)
                        {
                            matrix[i, k + 1] = tempString[k];
                        }
                        else
                        {
                            matrix[i, k + 1] = tempString[k + 1];
                        }
                }
            }
            // end

        }
        public int[,] Task3(int[,] matrix)
        {
            int[,] answer = null;
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            // code here
            answer = new int [n, m + 1];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int maxRow = int.MinValue;
                int maxIndex = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (maxRow < matrix[i, j])
                    {
                        maxRow = matrix[i, j];
                        maxIndex = j;
                    }
                }

                if (maxIndex == 0)
                {
                    answer[i, 0] = maxRow;
                    for (int k = 0; k < matrix.GetLength(1); k++)
                    {
                        answer[i, k+1] = matrix[i, k];
                    }
                }
                else if (maxIndex == matrix.GetLength(1) - 1)
                {
                    for (int k = 0; k < matrix.GetLength(1); k++)
                    {
                        answer[i, k] = matrix[i, k];
                    }
                    answer[i,m] =  maxRow;
                }
                else
                {
                    for (int k = 0; k < matrix.GetLength(1); k++)
                    {
                        if (k < maxIndex)
                        {
                            answer[i, k] = matrix[i, k];
                        }
                        else if (k == maxIndex)
                        {
                            answer[i, k] =  matrix[i, k];
                            answer[i, k+1] = matrix[i, k];
                        }
                        else
                        {
                            answer[i, k+1] =  matrix[i, k];
                        }
                    }
                }
                
            }
            // end

            return answer;
        }
        public void Task4(int[,] matrix)
        {

            // code here
            int n  = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            for (int i = 0; i < n; i++)
            {
                int  maxRow = int.MinValue;
                int maxIndex = 0;
                for (int j = 0; j < m; j++)
                {
                    if (maxRow < matrix[i, j])
                    {
                        maxRow = matrix[i, j];
                        maxIndex = j;
                    }
                }
                int posSumm = 0;
                int posCounter = 0;
                for (int k = maxIndex + 1; k < m; k++)
                {
                    if (matrix[i, k] > 0)
                    {
                        posSumm += matrix[i, k];
                        posCounter++;
                    }
                }

                if (posCounter != 0)
                {
                    int posAvg = posSumm / posCounter;
                    for (int k = 0; k < maxIndex; k++)
                    {
                        if (matrix[i, k] < 0)
                        {
                            matrix[i, k] = posAvg;
                        }
                    }
                }
                else continue;
            }
            // end

        }
        public void Task5(int[,] matrix, int k)
        {

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            int[] maxElements = new int[n];
            int ind = 0;
            for (int i = n - 1; i >= 0; i--)
            {
                int maxRow = int.MinValue;
                for (int j = m - 1; j >= 0; j--)
                {
                    if (maxRow < matrix[i, j])
                    {
                        maxRow = matrix[i, j];
                    }
                }
                maxElements[ind] = maxRow;
                ind++;
            }

            if (k < m)
            {
                for (int i = 0; i < n; i++)
                {
                    matrix[i, k] = maxElements[i];
                }
            }
            // end

        }
        public void Task6(int[,] matrix, int[] array)
        {

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            if (array.Length != m) return;
            for (int i = 0; i < m; i++)
            {
                int maxIndex = 0;
                for (int j = 0; j < n; j++)
                {
                    if (matrix[maxIndex, i] < matrix[j,i]) maxIndex = j;
                }
                if (matrix[maxIndex, i] < array[i]) matrix[maxIndex, i] = array[i];
            }
            // end

        }
        public void Task7(int[,] matrix)
        {

            // code here
            int n =  matrix.GetLength(0);
            int m = matrix.GetLength(1);
            int[] minElements = new int[n];
            for (int i = 0; i < n; i++)
            {
                int minRow = int.MaxValue;
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] < minRow)  minRow = matrix[i, j];
                }
                minElements[i] = minRow;
            }

            int k = 1;
            while (k < n)
            {
                if (k == 0 || minElements[k-1] >= minElements[k]) k++;
                else
                {
                    (minElements[k], minElements[k - 1]) = (minElements[k - 1], minElements[k]);
                    for (int j = 0; j < m; j++)
                    {
                        (matrix[k - 1, j], matrix[k, j]) = (matrix[k, j], matrix[k - 1, j]);
                    }
                    k--;
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
                int[] diagSumm = new int[2 * n - 1];

                int k = 0;
                for (int i = n - 1; i >= 0; i--)
                {
                    k = n - i - 1;
                    for (int j = 0; j < m; j++)
                    {
                        diagSumm[k] += matrix[i, j];
                        k++;
                    }
                }

                answer = diagSumm;
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

            int maxI = 0;
            int maxJ = 0;
            int max = 0;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (Math.Abs(matrix[i, j]) > Math.Abs(max))
                    {
                        max = matrix[i, j];
                        maxI = i;
                        maxJ = j;
                    }
                }
            }

            int rowShift = k - maxI;
            int colShift = k - maxJ;


            if (rowShift < 0)
            {
                for (int i = maxI; i > k; i--)
                {
                    for (int j = 0; j < m; j++)
                        (matrix[i, j], matrix[i - 1, j]) = (matrix[i - 1, j], matrix[i, j]);
                }
            }

            else
            {
                for (int i = maxI; i < k; i++)
                {
                    for (int j = 0; j < m; j++)
                        (matrix[i, j], matrix[i + 1, j]) = (matrix[i + 1, j], matrix[i, j]);
                }
            }

            if (colShift < 0)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = maxJ; j > k; j--)
                        (matrix[i, j], matrix[i, j - 1]) = (matrix[i, j - 1], matrix[i, j]);
                }
            }

            else
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = maxJ; j < k; j++)
                        (matrix[i, j], matrix[i, j + 1]) = (matrix[i, j + 1], matrix[i, j]);
                }
            }

            
            // end

        }
        public int[,] Task10(int[,] A, int[,] B)
        {
            int[,] answer = null;

            // code here
            int n = A.GetLength(0);
            int m = B.GetLength(1);

            if (A.GetLength(1) != B.GetLength(0)) return answer;
            
            answer = new int[n,m];
            
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    int newElem = 0;
                    for (int k = 0; k < n; k++)
                    {
                        newElem += A[i, k] * B[k, j];
                    }
                    answer[i, j] = newElem;
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
            answer = new int [matrix.GetLength(0)][];

            for (int i = 0; i < n; i++)
            {
                int posCounter = 0;
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i,j] > 0) 
                    {
                        posCounter++;
                    }
                }
                answer[i] = new int[posCounter];
                posCounter = 0;
                for (int k = 0; k < m; k++)
                {
                    if (matrix[i, k] > 0)
                    {
                        answer[i][posCounter] = matrix[i, k];
                        posCounter++;
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
            int total = 0;
            
            for (int i = 0; i < array.Length; i++)
            {
                total += array[i].Length;
            }
            
            int size = (int)Math.Ceiling(Math.Sqrt(total));
            
            answer = new int[size, size];
            
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    answer[i, j] = 0;
                }
            }
            
            int row = 0, col = 0;
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    answer[row, col] = array[i][j];
                    col++;
                    if (col >= size)
                    {
                        col = 0;
                        row++;
                    }
                }
            }
            // end

            return answer;
        }
    }
}
