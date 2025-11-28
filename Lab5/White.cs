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
            int colvo = 0;
            int sum = 0;
            
            
            for(int i=0; i < matrix.GetLength(0); i++)
            {
                for(int j=0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        sum += matrix[i, j];
                        colvo += 1;
                    }
                }
            }
            if (colvo > 0)
            {
                average=(double)sum/ colvo;
            }
            Console.WriteLine(average);
                // end

                return average;
        }
        public (int row, int col) Task2(int[,] matrix)
        {
            int row = 0, col = 0;

            // code here
            int MinValue = matrix[0, 0];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if(matrix[i, j] < MinValue)
                    {
                        MinValue = matrix[i, j];
                        row = i;
                        col = j;
                    }
                }
            }
            
            // end

            return (row, col);
        }
        public void Task3(int[,] matrix, int k)
        {
            if (matrix == null || matrix.GetLength(0) == 0 || matrix.GetLength(1) == 0)
                return;

            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            if (k < 0 || k >= cols)
                return;

            int maxRowIndex = 0;
            int maxValue = matrix[0, k];

            for (int i = 1; i < rows; i++)
            {
                if (matrix[i, k] > maxValue)
                {
                    maxValue = matrix[i, k];
                    maxRowIndex = i;
                }
            }

            if (maxRowIndex == 0)
                return;

            for (int j = 0; j < cols; j++)
            {
                int temp = matrix[0, j];
                matrix[0, j] = matrix[maxRowIndex, j];
                matrix[maxRowIndex, j] = temp;
            }

            // end
        }
        public int[,] Task4(int[,] matrix)
        {
            int[,] answer = null;

            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            
            if (rows == 1)
            {
                answer = new int[0, cols];
                return answer;
            }

            int targetColumn = 0; 
            int minRow = 0;
            int minValue = matrix[0, targetColumn];

            
            for (int i = 1; i < rows; i++)
            {
                if (matrix[i, targetColumn] < minValue)
                {
                    minValue = matrix[i, targetColumn];
                    minRow = i;
                }
            }
            answer = new int[rows - 1, cols];
            int newRow = 0;
            for (int i = 0; i < rows; i++)
            {
                if (i != minRow)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        answer[newRow, j] = matrix[i, j];
                    }
                    newRow++;
                }
            }
            // end

            return answer;
        }
        public int Task5(int[,] matrix)
        {
            int sum = 0;

            // code here
            if (matrix.GetLength(0) != matrix.GetLength(1))
            {
                return 0;
            }
            for(int i = 0; i < matrix.GetLength(0); i++)
            {
                sum += matrix[i, i];
            }
            // end

            return sum;
        }
        public void Task6(int[,] matrix)
        {
            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                int maxIndex = -1;
                int maxValue = int.MinValue;
                int lastnegativeindex = -1;
                
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] < 0)
                    {
                        break;
                    }

                    if (matrix[i, j] > maxValue)
                    {
                        maxValue = matrix[i, j];
                        maxIndex = j;
                    }
                }

                for (int j = cols - 1; j >= 0; j--)
                {
                    if (matrix[i, j] < 0)
                    {
                        lastnegativeindex = j;
                        break;
                    }
                }

                if (maxIndex != -1 && lastnegativeindex != -1)
                {
                    int temp = matrix[i, maxIndex];
                    matrix[i, maxIndex] = matrix[i, lastnegativeindex];
                    matrix[i, lastnegativeindex] = temp;
                }
            }
            // end
        }
        public int[] Task7(int[,] matrix)
        {
            int[] negatives = null;

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            int count = 0;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] < 0)
                    {
                        count++;
                    }
                }
            }
            if (count == 0)
            {
                return null;
            }

            negatives = new int[count];

            int indeks = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] < 0)
                    {
                        negatives[indeks] = matrix[i, j];
                        indeks++;
                    }
                }
            }
            // end

            return negatives;
        }
        public void Task8(int[,] matrix)
        {

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            for(int i = 0; i < n; i++)
            {
                if (m == 1)
                {
                    continue;
                }

                int maxindeks = 0;
                int MaxValue = matrix[i, 0];
                for(int j = 0;j < m; j++)
                {
                    if (matrix[i, j] > MaxValue)
                    {
                        MaxValue = matrix[i, j];
                        maxindeks = j;
                    }

                }

                if (maxindeks == 0)
                {
                    matrix[i, maxindeks + 1] *= 2;
                }
                else if (maxindeks == m - 1)
                {
                    matrix[i, maxindeks - 1] *= 2;
                }
                else
                {
                    int left = matrix[i, maxindeks - 1];
                    int right= matrix[i, maxindeks+1];
                    if (left <= right)
                    {
                        matrix[i, maxindeks - 1] *= 2;

                    }
                    else
                    {
                        matrix[i, maxindeks + 1] *= 2;
                    }
                }
            }
            // end

        }
        public void Task9(int[,] matrix)
        {

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j < m / 2; j++)
                {
                    int temp = matrix[i, j];
                    matrix[i, j] = matrix[i, m - 1 - j];
                    matrix[i, m - 1 - j] = temp;
                }
            }
            // end

        }
        public void Task10(int[,] matrix)
        {

            // code here
            int n = matrix.GetLength(0);
            if (n != matrix.GetLength(1))
            {
                return;
            }
            int start = n / 2;
            for(int i = start; i < n; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    matrix[i, j] = 1;
                }
            }
            // end

        }
        public int[,] Task11(int[,] matrix)
        {
            int[,] answer = null;

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            int count = 0;
            for (int i = 0; i < n; i++)
            {
                bool nozero = true;
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        nozero = false;
                        break;
                    }
                }
                if (nozero) count++;
            }

            answer = new int[count, m];

            int index = 0;
            for (int i = 0; i < n; i++)
            {
                bool nozero = true;
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        nozero = false;
                        break;
                    }
                }

                if (nozero)
                {
                    for (int j = 0; j < m; j++)
                    {
                        answer[index, j] = matrix[i, j];
                    }
                    index++;
                }
            }
            // end

            return answer;
        }
        public void Task12(int[][] array)
        {
            // code here
            for (int i = 1; i < array.Length; i++)
            {
                int[] row = array[i];

                int sum = 0;
                for (int k = 0; k < row.Length; k++)
                {
                    sum += row[k];
                }

                int j = i - 1;

                while (j >= 0)
                {
                    int jsum = 0;
                    for (int k = 0; k < array[j].Length; k++)
                    {
                        jsum += array[j][k];
                    }

                    if (jsum > sum)
                    {
                        array[j + 1] = array[j];
                        j--;
                    }
                    else
                    {
                        break;
                    }
                }
                array[j + 1] = row;
            }
            // end
        }
    }
}
