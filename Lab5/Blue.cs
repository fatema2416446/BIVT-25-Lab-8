using System.Linq;
using System.Runtime.InteropServices;

namespace Lab5
{
    public class Blue
    {
        public double[] Task1(int[,] matrix)
        {
            double[] answer = null;

            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            
            answer =  new double[rows];

            for (int i = 0; i < rows; i++)
            {
                double sum = 0;
                int count = 0;
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        sum += matrix[i, j];
                        count++;
                    }
                }
                answer[i] = count > 0 ? sum / count : 0;
            }
            

            // end

            return answer;
        }
        public int[,] Task2(int[,] matrix)
        {
            int[,] answer = null;

            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            int max = matrix[0, 0];
            int maxrows = 0, maxcols = 0;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                        maxrows = i;
                        maxcols = j;
                    }
                }
            }
            answer = new int[rows - 1, cols - 1];
            int r = 0;
            for (int i = 0; i < rows; i++)
            {
                if (i == maxrows) continue;
                int c = 0;
                for (int j = 0; j < cols; j++)
                {
                    if (j == maxcols) continue;
                    answer[r, c] = matrix[i, j];
                    c++;
                }
                r++;
            }
            // end

            return answer;
        }
        public void Task3(int[,] matrix)
        {

            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                int max = matrix[i, 0];
                int maxIndex = 0;
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                        maxIndex = j;
                    }
                }

                for (int j = maxIndex; j < cols - 1; j++)
                {
                    matrix[i, j] = matrix[i, j + 1];
                }
                matrix[i, cols - 1] = max;
            }
            // end

        }
        public int[,] Task4(int[,] matrix)
        {
            int[,] answer = null;

            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            answer = new int[rows, cols + 1];
            for (int i = 0; i < rows; i++)
            {
                int max = matrix[i, 0];
                for (int j = 1; j < cols; j++)
                {
                    if (matrix[i, j] > max) max = matrix[i, j];
                }

                for (int j = 0; j < cols - 1; j++)
                {
                    answer[i, j] = matrix[i, j];
                }
                answer[i, cols - 1] = max;
                answer[i, cols] = matrix[i, cols - 1];
            }
            // end

            return answer;
        }
        public int[] Task5(int[,] matrix)
        {
            int[] answer = null;

            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            int count = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if ((i + j) % 2 == 1) count++;
                }
            }
            answer = new int[count];
            int k = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if ((i + j) % 2 == 1) answer[k++] = matrix[i, j];
                }
            }
            // end

            return answer;
        }
        public void Task6(int[,] matrix, int k)
        {
            
            // code here
            if (matrix.GetLength(0) != matrix.GetLength(1)) return;
            int rows = matrix.GetLength(0);
            int maxDiag = matrix[0, 0];
            int maxRow = 0;
            for (int i = 1; i < rows; i++)
            {
                if (matrix[i, i] > maxDiag && i < rows)
                {
                    maxDiag = matrix[i, i];
                    maxRow = i;
                }
            }

            int neg = -1;
            for (int i = 0; i < rows; i++)
            {
                if (matrix[i, k] < 0)
                {
                    neg = i;
                    break;
                }
            }
            if (neg == -1 || maxDiag == neg) return;
            for (int j = 0; j < rows; j++)
            {
                (matrix[maxRow, j], matrix[neg, j]) = (matrix[neg, j], matrix[maxRow, j]);
            }
            // end

        }
        public void Task7(int[,] matrix, int[] array)
        {

            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            if (cols < 2 || array.Length != cols) return;
            int preCol = cols - 2;
            int max = matrix[0, preCol];
            int maxRow = 0;
            for (int i = 1; i < rows; i++)
            {
                if (matrix[i, preCol] > max)
                {
                    max = matrix[i, preCol];
                    maxRow = i;
                }
            }
            for (int j = 0; j < cols; j++)
            {
                matrix[maxRow, j] = array[j];
            }
            // end

        }
        public void Task8(int[,] matrix)
        {

            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int col = 0; col < cols; col++)
            {
                int maxRow = 0;
                int maxValue = matrix[0, col];

                for (int row = 1; row < rows; row++)
                    if (matrix[row, col] > maxValue)
                    {
                        maxValue = matrix[row, col];
                        maxRow = row;
                    }

                int half = rows / 2;

                if (maxRow < half)
                {
                    int sum = 0;
                    for (int r = maxRow + 1; r < rows; r++)
                        sum += matrix[r, col];

                    matrix[0, col] = sum;
                }
            }
            // end

        }
        public void Task9(int[,] matrix)
        {

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            for (int i = 0; i + 1 < n; i += 2)
            {
                int idx1 = 0, idx2 = 0;

                for (int j = 1; j < m; j++)
                {
                    if (matrix[i,     j] > matrix[i,     idx1]) idx1 = j;
                    if (matrix[i + 1, j] > matrix[i + 1, idx2]) idx2 = j;
                }

                (matrix[i, idx1], matrix[i + 1, idx2]) = (matrix[i + 1, idx2], matrix[i, idx1]);
            }
            // end

        }
        public void Task10(int[,] matrix)
        {

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            if (n != m) return;

            int maxRow = 0;
            int maxValue = matrix[0, 0];

            for (int i = 1; i < n; i++)
                if (matrix[i, i] > maxValue)
                {
                    maxValue = matrix[i, i];
                    maxRow = i;
                }

            for (int i = 0; i < maxRow; i++)
            for (int j = i + 1; j < n; j++)
                matrix[i, j] = 0;
            // end

        }
        public void Task11(int[,] matrix)
        {

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            int[] posCount = new int[n];
            for (int i = 0; i < n; i++)
            {
                int cnt = 0;
                for (int j = 0; j < m; j++) if (matrix[i, j] > 0) cnt++;
                posCount[i] = cnt;
            }

            for (int i = 0; i < n - 1; i++)
            {
                int maxIdx = i;
                for (int k = i + 1; k < n; k++)
                    if (posCount[k] > posCount[maxIdx]) maxIdx = k;

                if (maxIdx != i)
                {
                    for (int j = 0; j < m; j++)
                        (matrix[i, j], matrix[maxIdx, j]) = (matrix[maxIdx, j], matrix[i, j]);
                    (posCount[i], posCount[maxIdx]) = (posCount[maxIdx], posCount[i]);
                }
            }
            // end

        }
        public int[][] Task12(int[][] array)
        {
            int[][] answer = null;

            // code here
            
            int n = array.Length;
            if (n == 0) return new int[0][];

            double sumAll = 0;
            int countAll = 0;
            for (int i = 0; i < n; i++)
            for (int j = 0; j < array[i].Length; j++)
            {
                sumAll += array[i][j];
                countAll++;
            }

            double avgAll = sumAll / countAll;

            int keep = 0;
            for (int i = 0; i < n; i++)
            {
                double sumRow = 0;
                for (int j = 0; j < array[i].Length; j++)
                    sumRow += array[i][j];
                if (sumRow / array[i].Length >= avgAll)
                    keep++;
            }

            answer = new int[keep][];
            int idx = 0;
            for (int i = 0; i < n; i++)
            {
                double sumRow = 0;
                for (int j = 0; j < array[i].Length; j++)
                    sumRow += array[i][j];

                if (sumRow / array[i].Length >= avgAll)
                {
                    answer[idx] = new int[array[i].Length];
                    for (int j = 0; j < array[i].Length; j++)
                        answer[idx][j] = array[i][j];
                    idx++;
                }
            }
            // end

            return answer;
        }
    }
}