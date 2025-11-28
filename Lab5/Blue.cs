using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Lab5
{
    public class Blue
    {

        public double[] Task1(int[,] matrix)
        {
            double[] answer = null;

            // code here
            answer = new double[matrix.GetLength(0)];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                double avg_per_string = 0;
                int counter = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        avg_per_string += matrix[i, j];
                        counter++;
                    }

                }
                if (counter == 0)
                {
                    answer[i] = 0;
                }
                else
                {
                    answer[i] = avg_per_string / counter;
                }
            }
            // end

            return answer;
        }
        public int[,] Task2(int[,] matrix)
        {
            int[,] answer = null;

            // code here

            int maxValue = matrix[0, 0];
            int max_col = 0;
            int max_row = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] > maxValue)
                    {
                        maxValue = matrix[row, col];
                        max_col = col;
                        max_row = row;
                    }
                }
            }

            answer = new int[matrix.GetLength(0) - 1, matrix.GetLength(1) - 1];

            int newRow = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                if (row == max_row) continue;

                int newCol = 0;
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (col == max_col) continue;

                    answer[newRow, newCol] = matrix[row, col];
                    newCol++;
                }
                newRow++;
            }

            // end

            return answer;
        }
        public void Task3(int[,] matrix)
        {

            // code here

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int maxValue = -99999;
                int m_col = 0;
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] > maxValue)
                    {
                        maxValue = matrix[row, col];
                        m_col = col;
                    }
                }

                if (m_col == matrix.GetLength(1) - 1)
                {
                    continue;
                }

                int temp = matrix[row, m_col];

                for (int col = m_col; col < matrix.GetLength(1) - 1; col++)
                {
                    matrix[row, col] = matrix[row, col + 1];
                }

                matrix[row, matrix.GetLength(1) - 1] = temp;
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
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                    }
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

            if (matrix == null)
                return new int[0];

            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            if (rows == 0 || cols == 0)
                return new int[0];

            int count = 0;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if ((i + j) % 2 == 1)
                        count++;
                }
            }

            answer = new int[count];

            int index = 0;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if ((i + j) % 2 == 1)
                        answer[index++] = matrix[i, j];
                }
            }

            // end

            return answer;
        }



        public void Task6(int[,] matrix, int k)
        {
            // code here

            if (matrix == null)
                return;

            int n = matrix.GetLength(0);

            if (n == 0 || n != matrix.GetLength(1))
                return;

            if (k < 0 || k >= n)
                return;

            int maxDiagIndex = 0;
            int maxDiagValue = matrix[0, 0];

            for (int i = 1; i < n; i++)
            {
                if (matrix[i, i] > maxDiagValue)
                {
                    maxDiagValue = matrix[i, i];
                    maxDiagIndex = i;
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

            if (negIndex == -1 || negIndex == maxDiagIndex)
                return;

            for (int j = 0; j < n; j++)
            {
                int temp = matrix[maxDiagIndex, j];
                matrix[maxDiagIndex, j] = matrix[negIndex, j];
                matrix[negIndex, j] = temp;
            }

            // end
        }
        public void Task7(int[,] matrix, int[] array)
        {

            var s2 = new StringBuilder();

            for (var k = 0; k < matrix.GetLength(0); k++)
            {
                for (var j = 0; j < matrix.GetLength(1); j++)
                {
                    s2.Append(matrix[k, j]).Append("\t");
                }

                s2.AppendLine();
            }

            Console.WriteLine("matrix_begin: \n {0} \n input: {1}", s2.ToString(), string.Join(" ", array));


            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);


            if (cols < 2 || cols != array.Length)
            {
                Console.WriteLine("skip \n");
                return;
            }

            int max_elem = -999;


            for (int i = 0; i < rows; i++)
            {
                if (matrix[i, cols -2] > max_elem)
                {
                    max_elem = matrix[i, cols - 2];
                }
            }

            Console.WriteLine("max: {0}", max_elem);


            var s = new StringBuilder();

            for (var k = 0; k < matrix.GetLength(0); k++)
            {
                for (var j = 0; j < matrix.GetLength(1); j++)
                {
                    s.Append(matrix[k, j]).Append("\t");
                }

                s.AppendLine();
            }

            Console.WriteLine("matrix_mid: \n {0}", s.ToString());


            for (int i = 0;i < rows; i++)
            {
                if (matrix[i, cols - 2] == max_elem)
                {

                    for (int j = 0; j < cols; j++)
                    {
                        matrix[i, j] = array[j];
                    }

                    break;

                }
            }

            var s1 = new StringBuilder();

            for (var k = 0; k < matrix.GetLength(0); k++)
            {
                for (var j = 0; j < matrix.GetLength(1); j++)
                {
                    s1.Append(matrix[k, j]).Append("\t");
                }

                s1.AppendLine();
            }

            Console.WriteLine("changed_matrix: \n {0}", s1.ToString());
            return;
            // end

        }
        public void Task8(int[,] matrix)
        {

            // code here



            // end

        }
        public void Task9(int[,] matrix)
        {

            // code here

            // end

        }
        public void Task10(int[,] matrix)
        {

            // code here

            // end

        }
        public void Task11(int[,] matrix)
        {

            // code here

            // end

        }
        public int[][] Task12(int[][] array)
        {
            int[][] answer = null;

            // code here

            // end

            return answer;
        }

        public override bool Equals(object? obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string? ToString()
        {
            return base.ToString();
        }
    }
}