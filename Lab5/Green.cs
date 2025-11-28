using System.Linq;
using System.Runtime.InteropServices;

namespace Lab5
{
    public class Green
    {
        public int[] Task1(int[,] matrix)
        {
            int[] answer = null;

            // code here
            for (int i = 0;  i < matrix.GetLength(0); i++)
            {
                for (int j = 0;  j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{matrix[i, j], 3}");
                }
                Console.WriteLine();
            }
            int n = matrix.GetLength(0);
            answer = new int[n];
            int ind = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int min = int.MaxValue, indmin = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < min)
                    {
                        min = matrix[i, j];
                        indmin = j;
                    }
                }
                answer[ind] = indmin;
                ind++;
            }
            for (int i = 0; i < answer.Length; i++)
            {
                Console.Write(answer[i]);
            }
            Console.WriteLine();
            // end

            return answer;
        }
        public void Task2(int[,] matrix)
        {

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            Console.WriteLine("Исходный массив");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write($"{matrix[i, j],3}");
                }
                Console.WriteLine();
            }
            int[] array = new int[n];
            int[] rarray = new int[n];
            //Обход по строчкам, ищем минимальное
            for (int i = 0; i < n; i++)
            {
                int max = int.MinValue, indmax = 0;
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                        indmax = j;
                    }
                }
                array[i] = max;
                rarray[i] = indmax;
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (j < rarray[i])
                    {
                        if (matrix[i, j] < 0)
                        {
                            matrix[i, j] = (int)Math.Floor((double)matrix[i, j] / (double)array[i]);
                        }
                    }
                }
            }
            Console.WriteLine("Новый массив");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write($"{matrix[i, j],3}");
                }
                Console.WriteLine();
            }
            // end

        }
        public void Task3(int[,] matrix, int k)
        {

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            Console.WriteLine("Исходный массив");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write($"{matrix[i, j],3}");
                }
                Console.WriteLine();
            }
            int max = int.MinValue, indmax = 0;
            if (n == m && k >= 0 && k < n)
            {
                for (int i = 0; i < n; i++)
                {
                    if (matrix[i, i] > max)
                    {
                        max = matrix[i, i];
                        indmax = i;
                    }
                }
                if (k != indmax)
                {
                    for (int i = 0; i < n; i++)
                    {
                        var temp = matrix[i, k];
                        matrix[i, k] = matrix[i, indmax];
                        matrix[i, indmax] = temp;
                    }
                }
            }
            Console.WriteLine("Новый массив");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write($"{matrix[i, j],3}");
                }
                Console.WriteLine();
            }
            // end

        }
        public void Task4(int[,] matrix)
        {

            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            if (rows != cols)
                return;
            int max = int.MinValue;
            int maxi = -1;
            for (int i = 0; i < rows; i++)
            {
                if (matrix[i, i] > max)
                {
                    max = matrix[i, i]; maxi = i;
                }
            }
            for (int i = 0; i < rows; i++)
            {
                (matrix[i, maxi], matrix[maxi, i]) = (matrix[maxi, i], matrix[i, maxi]);
            }
            // end

        }
        public int[,] Task5(int[,] matrix)
        {
            int[,] answer = null;

            // code here
            int[] array = new int[matrix.GetLength(0)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int sum = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        sum += matrix[i, j];
                    }
                }
                array[i] = sum;
            }
            // Нахождение максимальной суммы в строчках
            int max = int.MinValue, indmax = -1;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > max)
                {
                    max = array[i];
                    indmax = i;
                }
            }
            answer = new int [matrix.GetLength(0) - 1, matrix.GetLength(1)];
            int row = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (i == indmax)
                    continue;
                for (int j = 0;j < matrix.GetLength(1); j++)
                {
                    answer[row, j] = matrix[i, j];
                }
                row++;
            }
            // end

            return answer;
        }
        public void Task6(int[,] matrix)
        {

            // code here
            int[] array = new int [matrix.GetLength(0)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int count = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < 0)
                    {
                        count++;
                    }
                }
                array[i] = count;
            }
            int MinCount = int.MaxValue, MaxCount = int.MinValue, indmin = -1, indmax = -1;
            //Нахождение строки с минимальным кол-во отриц чисел
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] < MinCount)
                {
                    MinCount = array[i];
                    indmin = i;
                }
            }
            //Нахождение строки с максимальным кол-во отриц чисел
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > MaxCount)
                {
                    MaxCount = array[i];
                    indmax = i;
                }
            }
            if (MaxCount != MinCount)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    (matrix[indmin, j], matrix[indmax, j]) = (matrix[indmax, j], matrix[indmin, j]);
                }
            }
            else
                return;


            // end

        }
        public int[,] Task7(int[,] matrix, int[] array)
        {
            int[,] answer = null;

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            if (array.Length != n) return matrix;

            int min = int.MaxValue;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] < min)
                    {
                        min = matrix[i, j];
                    }
                }
            }
            int st = m;

            for (int j = 0; j < m; j++)
            {
                bool y = false;
                for (int i = 0; i < n; i++)
                {
                    if (matrix[i, j] == min)
                    {
                        st = j;
                        break;
                    }
                }
                if (st != m) break;
            }

            answer = new int[n, m + 1];

            for (int i = 0; i < n; i++)
            {
                int x = 0;
                for (int j = 0; j < m + 1; j++)
                {
                    if (j == st + 1)
                        answer[i, j] = array[i];
                    else
                        answer[i, j] = matrix[i, x++];
                }
            }
            // end

            return answer;
        }
        public void Task8(int[,] matrix)
        {

            // code here
            Console.WriteLine("Исходный матрица:");
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{matrix[i, j],3}");
                }
                Console.WriteLine();
            }

            int n = matrix.GetLength(0), m = matrix.GetLength(1);
            for (int j = 0; j < m; j++)
            {
                int max = int.MinValue, indmax = 0;
                int pos = 0, neg = 0;
                for (int i = 0; i < n; i++)
                {
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                        indmax = i;
                    }
                    if (matrix[i, j] < 0)
                        neg++;
                    else if (matrix[i, j] > 0)
                        pos++;
                }
                if (pos > neg)
                    matrix[indmax, j] = 0;
                else if (neg > pos)
                    matrix[indmax, j] = indmax;
            }
            Console.WriteLine("Новая матрица:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write($"{matrix[i, j],3}");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            // end

        }
        public void Task9(int[,] matrix)
        {

            // code here
            int N = matrix.GetLength(0);
            int M = matrix.GetLength(1);
            Console.WriteLine("Исходная матрица:");
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    Console.Write($"{matrix[i, j],3}");
                }
                Console.WriteLine();
            }
            if (N == M)
            {
                for (int i = 0; i < N * N; i++)
                {
                    int row = i / N;
                    int col = i % N;
                    if (row == 0)
                        matrix[row, col] = 0;
                    if (row == N - 1)
                        matrix[row, col] = 0;
                    if (col == 0)
                        matrix[row, col] = 0;
                    if (col == N - 1)
                        matrix[row, col] = 0;
                }
                Console.WriteLine("Новая матрица");
                for (int i = 0; i < N; i++)
                {
                    for (int j = 0; j < N; j++)
                    {
                        Console.Write($"{matrix[i, j],3}");
                    }
                    Console.WriteLine();
                }
            }
            // end

        }
        public (int[] A, int[] B) Task10(int[,] matrix)
        {
            int[] A = null, B = null;

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            Console.WriteLine("Исходная матрица:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write($"{matrix[i, j],3}");
                }
                Console.WriteLine();
            }
            if (n == m)
            {
                int num = 0, ind = 0;
                A = new int[n * (n + 1) / 2];
                B = new int[n * (n - 1) / 2];
                for (int i = 0; i < n; i++)
                {
                    for (int j = i; j < n; j++)
                    {
                        A[num] = matrix[i, j];
                        num++;
                    }
                }
                for (int i = 0; i < n ; i++)
                {
                    for (int j = 0; j < i; j++)
                    {
                        B[ind] = matrix[i, j];
                        ind++;
                    }
                }
            }
            if (A != null)
            {
                Console.WriteLine("Массив A:");
                for (int i = 0; i < A.Length; i++)
                {
                    Console.Write(A[i] + " ");
                }
            }
            if (B != null)
            {
                Console.WriteLine("Массив B:");
                for (int i = 0; i < B.Length; i++)
                {
                    Console.Write(B[i] + " ");
                }
            }
            // end

            return (A, B);
        }
        public void Task11(int[,] matrix)
        {

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            int i = 1;
            for (int j = 0; j < m; j++)
            {
                if (j % 2 == 1)
                {
                    i = 1;
                    while (i < n)
                    {
                        if ((i == 0) || (matrix[i, j] >= matrix[i - 1, j]))
                            i++;
                        else
                        {
                            (matrix[i, j], matrix[i - 1, j]) = (matrix[i - 1, j], matrix[i, j]);
                            i--;
                        }
                    }
                }
                if (j % 2 == 0)
                {
                    i = 1;
                    while (i < n)
                    {
                        if ((i == 0) || (matrix[i, j] <= matrix[i - 1, j]))
                            i++;
                        else
                        {
                            (matrix[i, j], matrix[i - 1, j]) = (matrix[i - 1, j], matrix[i, j]);
                            i--;
                        }
                    }
                }
            }
            // end
        }
        public void Task12(int[][] array)
        {
            // code here
            int n = array.Length;
            int i = 1;
            int s = 0;
            int sv = 0;
            int d = 0;
            int l = 0;
            while (i < n)
            {
                s = 0;
                if (i == 0)
                    i++;
                sv = 0;
                l = array[i].Length;
                d = array[i - 1].Length;
                if (l < d)
                {
                    i++;
                }
                else if (l == d)
                {
                    for (int j = 0; j < l; j++)
                    {
                        s += array[i][j];
                    }
                    for (int j = 0; j < d; j++)
                    {
                        sv += array[i - 1][j];
                    }
                    if (sv < s)
                    {
                        (array[i], array[i - 1]) = (array[i - 1], array[i]);
                        i--;
                    }
                    else
                    {
                        i++;
                    }
                }
                else
                {
                    (array[i], array[i - 1]) = (array[i - 1], array[i]);
                    i--;
                }
            }
            // end

        }
    }
}
