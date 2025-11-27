using System.Globalization;
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
            int k = 0;

            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                int counter = 0;
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    if (matrix[i, j] < 0)
                    {
                        counter++;
                    }
                }
                answer[k] = counter;
                k++;
            }

            // end

            return answer;
        }
        public void Task2(int[,] matrix)
        {

            // code here

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                {
                    int minimum = int.MaxValue;
                    int index = 0;
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        if (matrix[i, j] < minimum)
                        {
                            minimum = matrix[i, j];
                            index = j;
                        }
                    }
                    if (index > 0)
                    {
                        for (int j = index; j >= 1; j--)
                        {
                            matrix[i, j] = matrix[i, j - 1];
                        }
                        matrix[i, 0] = minimum;
                    }
                }
            }

            // end
        }
        public int[,] Task3(int[,] matrix)
        {
            int[,] answer = null;

            // code here

            answer = new int[matrix.GetLength(0), matrix.GetLength(1) + 1];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int maximum = int.MinValue;
                int index = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > maximum)
                    {
                        maximum = matrix[i, j];
                        index = j;
                    }
                }
                for (int element = 0; element < answer.GetLength(1); element++)
                {
                    if (element == index + 1)
                    {
                        answer[i, element] = maximum;
                    }
                    else if (element > index)
                    {
                        answer[i, element] = matrix[i, element - 1];
                    }
                    else
                    {
                        answer[i, element] = matrix[i, element];
                    }
                }
            }

            // end

            return answer;
        }
        public void Task4(int[,] matrix)
        {

            // code here

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int maximum = int.MinValue;
                int index = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > maximum)
                    {
                        maximum = matrix[i, j];
                        index = j;
                    }
                }
                double average = 0;
                double sum = 0;
                int count = 0;
                for (int j = index + 1; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        sum += matrix[i, j];
                        count++;
                    }
                }
                if (count > 0)
                {
                    average = sum / count;
                    for (int j = 0; j < index; j++)
                    {
                        if (matrix[i, j] < 0)
                        {
                            matrix[i, j] = (int)average;
                        }
                    }
                }
            }

            // end

        }
        public void Task5(int[,] matrix, int k)
        {

            // code here

            int[] max_array = new int[matrix.GetLength(0)];

            if (k < matrix.GetLength(1))
            {
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    int maximum = int.MinValue;
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        if (matrix[i, j] > maximum)
                        {
                            maximum = matrix[i, j];
                        }
                    }
                    max_array[i] = maximum;
                }
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    matrix[i, k] = max_array[max_array.Length - i - 1];
                }
            }

            // end

        }
        public void Task6(int[,] matrix, int[] array)
        {

            // code here

            if (matrix.GetLength(1) == array.Length)
            {
                int k = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    int maximum = int.MinValue;
                    int index = 0;
                    for (int i = 0; i < matrix.GetLength(0); i++)
                    {
                        if (matrix[i, j] > maximum)
                        {
                            maximum = matrix[i, j];
                            index = i;
                        }
                    }
                    if (array[k] > maximum)
                    {
                        matrix[index, j] = array[k];
                    }
                    k++;
                }
            }

            // end

        }
        public void Task7(int[,] matrix)
        {

            // code here

            int[,] matrix2 = new int[matrix.GetLength(0), 2];

            int k = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int minimum = int.MaxValue;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < minimum)
                    {
                        minimum = matrix[i, j];
                    }
                }
                matrix2[k, 0] = minimum;
                matrix2[k, 1] = i;
                k++;
            }

            for (int i = 0; i < matrix2.GetLength(0); i++)
            {
                bool reverse = false;
                for (int j = 0; j < matrix2.GetLength(0) - i - 1; j++)
                {
                    if (matrix2[j, 0] < matrix2[j + 1, 0])
                    {
                        (matrix2[j, 0], matrix2[j + 1, 0]) = (matrix2[j + 1, 0], matrix2[j, 0]);
                        (matrix2[j, 1], matrix2[j + 1, 1]) = (matrix2[j + 1, 1], matrix2[j, 1]);
                        reverse = true;
                    }
                }
                if (reverse == false)
                {
                    break;
                }
            }

            int[,] result_matrix = new int[matrix.GetLength(0), matrix.GetLength(1)];

            for (int i = 0; i < result_matrix.GetLength(0); i++)
            {
                for (int j = 0; j < result_matrix.GetLength(1); j++)
                {
                    result_matrix[i, j] = matrix[matrix2[i, 1], j];
                }
            }

            for (int i = 0; i < result_matrix.GetLength(0); i++)
            {
                for (int j = 0; j < result_matrix.GetLength(1); j++)
                {
                    matrix[i, j] = result_matrix[i, j];
                }
            }
            // end

        }
        public int[] Task8(int[,] matrix)
        {
            int[] answer = null;

            // code here

            if ((matrix != null) && (matrix.GetLength(0) == matrix.GetLength(1)))
            {
                answer = new int[matrix.GetLength(0) * 2 - 1];
                int c = 0;

                for (int count = 0; count < matrix.GetLength(0); count++)
                {
                    int sum1 = 0;
                    int i = matrix.GetLength(0) - 1 - count;
                    int j = 0;
                    while (i < matrix.GetLength(0) && j < matrix.GetLength(1))
                    {
                        sum1 += matrix[i, j];
                        i++;
                        j++;
                    }
                    answer[c] = sum1;
                    c++;
                }

                for (int count = matrix.GetLength(0) - 2; count >= 0; count--)
                {
                    int sum2 = 0;
                    int i = 0;
                    int j = matrix.GetLength(0) - 1 - count;
                    while (i < matrix.GetLength(0) && j < matrix.GetLength(1))
                    {
                        sum2 += matrix[i, j];
                        i++;
                        j++;
                    }
                    answer[c] = sum2;
                    c++;
                }
            }

            // end

            return answer;
        }
        public void Task9(int[,] matrix, int k)
        {

            // code here

            if (k >= matrix.GetLength(0) || matrix.GetLength(0) != matrix.GetLength(1) || k < 0)
            {
                return;
            }

            int maximum = int.MinValue;
            int max_row = 0;
            int max_col = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    if (Math.Abs(matrix[i, j]) > maximum)
                    {
                        maximum = Math.Abs(matrix[i, j]);
                        max_row = i;
                        max_col = j;
                    }
                }
            }

            int[] row = new int[matrix.GetLength(0)];
            int[] col = new int[matrix.GetLength(0)];

            for (int j = 0; j < matrix.GetLength(0); j++)
            {
                row[j] = matrix[max_row, j];
            }

            for (int i = max_row; i > k; i--)
            {
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    matrix[i, j] = matrix[i - 1, j];
                }
            }

            for (int i = max_row; i < k; i++)
            {
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    matrix[i, j] = matrix[i + 1, j];
                }
            }

            for (int j = 0; j < matrix.GetLength(0); j++)
            {
                matrix[k, j] = row[j];
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                col[i] = matrix[i, max_col];
            }

            for (int j = max_col; j > k; j--)
            {
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    matrix[i, j] = matrix[i, j - 1];
                }
            }

            for (int j = max_col; j < k; j++)
            {
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    matrix[i, j] = matrix[i, j + 1];
                }
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                matrix[i, k] = col[i];
            }

            // end

        }
        public int[,] Task10(int[,] A, int[,] B)
        {
            int[,] answer = null;

            // code here

            if (A.GetLength(1) == B.GetLength(0) && A != null && B != null)
            {
                int rows = A.GetLength(0);
                int cols = B.GetLength(1);
                answer = new int[rows, cols];

                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        int sum = 0;
                        for (int k = 0; k < A.GetLength(1); k++)
                        {
                            sum += A[i, k] * B[k, j];
                        }
                        answer[i, j] = sum;
                    }
                }
            }

            // end

            return answer;
        }
        public int[][] Task11(int[,] matrix)
        {
            int[][] answer = null;

            // code here

            answer = new int[matrix.GetLength(0)][];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int count_negatives = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        count_negatives++;
                    }
                }
                answer[i] = new int[count_negatives];
                int k = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        answer[i][k++] = matrix[i, j];
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

            int length = 0;
            for (int i = 0; i < array.Length; i++)
            {
                length += array[i].Length;
            }

            int new_length = (int)Math.Ceiling(Math.Sqrt(length));

            answer = new int[new_length, new_length];
            int k1 = 0;
            int k2 = 0;
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    if (k2 == new_length)
                    {
                        k1++;
                        k2 = 0;
                    }
                    answer[k1, k2] = array[i][j];
                    k2++;
                }
            }

            // end

            return answer;
        }
    }
}
