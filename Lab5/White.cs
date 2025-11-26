using System.Linq;
using System.Runtime.InteropServices;

namespace Lab5
{
    public class White
    {
        public double Task1(int[,] matrix)
        {
            double average = 0;

            // code here

            if (matrix == null)
                return 0;
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            long sum = 0;
            int count = 0;

            for (int i = 0; i < n; i ++) 
             for (int j = 0; j < m; j ++)
                    if (matrix[i, j] > 0)
                    {
                        sum += matrix[i, j];
                        count++;
                    }
            if (count > 0)
                average = (double)sum / count;

            // end

            return average;
        }
        public (int row, int col) Task2(int[,] matrix)
        {
            int row = 0, col = 0;

            // code here
            if ( matrix == null )
                return (0, 0);

            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            int minVal = matrix[0, 0];
            int minRow = 0, minCol = 0;

            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    if (matrix[i, j] < minVal)
                    {
                        minVal = matrix[i, j];
                        minRow = i;
                        minCol = j;
                    }
            // end

            return (minRow, minCol);
        }
        public void Task3(int[,] matrix, int k)
        {

            // code here
            if (matrix == null)
                return;

            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            if (k < 0 || k >= m)
                return;

            int maxRow = 0;
            int maxVal = matrix[0, k];

            for (int i = 1; i < n; i++)
                if (matrix[i, k] > maxVal)
                {
                    maxVal = matrix[i, k];
                    maxRow = i;
                }

            if (maxRow == 0)
                return;

            for (int j = 0; j < m; j++)
            {
                int tmp = matrix[0, j];
                matrix[0, j] = matrix[maxRow, j];
                matrix[maxRow, j] = tmp;
            }

            // end

        }
        public int[,] Task4(int[,] matrix)
        {
            int[,] answer = null;

            // code here
            if (matrix == null)
                return null;

            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            int minRow = 0;
            int minVal = matrix[0, 0];

            for (int i = 1; i < n; i++)
            {
                if (matrix[i, 0] < minVal)
                {
                    minVal = matrix[i, 0];
                    minRow = i;
                }
            }

            if ( n == 1)
            {
                answer = new int [0, m];
                return answer;
            }

            answer = new int[n - 1, m];

            int newRow = 0;
            for (int i = 0; i < n; i ++)
                {
                    if (i == minRow) continue;

                    for (int j = 0; j < m; j++)
                    {
                        answer[newRow, j] = matrix[i, j];
                    }

                    newRow++;
                }
            // end

            return answer;
        }
        public int Task5(int[,] matrix)
        {
            int sum = 0;

            // code here
            if (matrix == null)
                return 0;

            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            if (n != m)
                return 0;

            for (int i = 0; i < n; i++)
            {
                sum += matrix[i, i];
            }
            // end

            return sum;
        }
        public void Task6(int[,] matrix)
        {

            // code here
            if (matrix == null)
                return;

            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            for (int i = 0; i < n; i++)
            {
                int firstNeg = -1;
                int lastNeg = -1;

                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] < 0)
                    {
                        if (firstNeg == -1)
                            firstNeg = j;
                        lastNeg = j;
                    }
                }

                if (firstNeg == -1)
                    continue;

                if (firstNeg == 0)
                    continue;

                int maxVal = matrix[i, 0];
                int maxCol = 0;
                for (int j = 1; j < firstNeg; j++)
                {
                    if (matrix[i, j] > maxVal)
                    {
                        maxVal = matrix[i, j];
                        maxCol = j;
                    }
                }
                int tmp = matrix[i, maxCol];
                matrix[i, maxCol] = matrix[i, lastNeg];
                matrix[i, lastNeg] = tmp;
            }
            // end
        }
        public int[] Task7(int[,] matrix)
        {
            int[] negatives = null;

            // code here
            if (matrix == null)
                return new int[0];

            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            int count = 0;

            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    if (matrix[i, j] < 0)
                        count++;

            if (count > 0)
            {
                negatives = new int[count];
                int index = 0;
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        if (matrix[i, j] < 0)
                        {
                            negatives[index++] = matrix[i, j];
                        }
                    }
                }
            }
            else negatives = null;

                // end

                return negatives;
        }
        public void Task8(int[,] matrix)
        {

            // code here

            if (matrix == null)
                return;

            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            for (int i = 0; i < n; i++)
            {
                if (m == 1)
                    continue; 

                int maxVal = matrix[i, 0];
                int maxCol = 0;

                for (int j = 1; j < m; j++)
                {
                    if (matrix[i, j] > maxVal)
                    {
                        maxVal = matrix[i, j];
                        maxCol = j;
                    }
                }

                int indexToDouble;

                bool hasLeft = maxCol - 1 >= 0;
                bool hasRight = maxCol + 1 < m;

                if (hasLeft && hasRight)
                {
                    int leftVal = matrix[i, maxCol - 1];
                    int rightVal = matrix[i, maxCol + 1];

                    if (leftVal <= rightVal)
                        indexToDouble = maxCol - 1; 
                    else
                        indexToDouble = maxCol + 1;
                }
                else if (hasLeft)
                {
                    indexToDouble = maxCol - 1;
                }
                else
                {
                    indexToDouble = maxCol + 1;
                }

                matrix[i, indexToDouble] *= 2;
            }

            // end

        }
        public void Task9(int[,] matrix)
        {

            // code here

            if (matrix == null)
                return;

            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m / 2; j++)
                {
                    int k = m - 1 - j;
                    int tmp = matrix[i, j];
                    matrix[i, j] = matrix[i, k];
                    matrix[i, k] = tmp;
                }
            }

            // end

        }
        public void Task10(int[,] matrix)
        {

            // code here
            if (matrix == null)
                return;

            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            if (n != m)
                return;

            int mid = n / 2; 

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i >= mid && j <= i)
                    {
                        matrix[i, j] = 1;
                    }
                }
            }
            // end

        }
        public int[,] Task11(int[,] matrix)
        {
            int[,] answer = null;

            // code here

            if (matrix == null)
                return null;

            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            bool[] hasZero = new bool[n];
            int rowsWithoutZero = 0;

            for (int i = 0; i < n; i++)
            {
                bool zeroFound = false;
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        zeroFound = true;
                        break;
                    }
                }
                hasZero[i] = zeroFound;
                if (!zeroFound)
                    rowsWithoutZero++;
            }

            if (rowsWithoutZero == 0)
            {
                answer = new int[0, m];
                return answer;
            }

            if (rowsWithoutZero == n)
            {
                answer = new int[n, m];
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        answer[i, j] = matrix[i, j];
                    }
                }
                return answer;
            }

            answer = new int[rowsWithoutZero, m];
            int newRow = 0;

            for (int i = 0; i < n; i++)
            {
                if (hasZero[i]) continue;

                for (int j = 0; j < m; j++)
                {
                    answer[newRow, j] = matrix[i, j];
                }
                newRow++;
            }

            // end

            return answer;
        }
        public void Task12(int[][] array)
        {

            // code here

            if (array == null || array.Length == 0)
                return;

            System.Array.Sort(array, (row1, row2) =>
            {
                int sum1 = 0;
                int sum2 = 0;

                if (row1 != null)
                {
                    for (int i = 0; i < row1.Length; i++)
                        sum1 += row1[i];
                }

                if (row2 != null)
                {
                    for (int i = 0; i < row2.Length; i++)
                        sum2 += row2[i];
                }

                return sum1.CompareTo(sum2); 
            });

            // end

        }
    }
}