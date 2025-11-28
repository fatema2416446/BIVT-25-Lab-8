using System.Diagnostics.CodeAnalysis;
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
            int n = matrix.GetLength(0), m = matrix.GetLength(1);
            int[] negative = new int[m];
            for (int j = 0; j < m; j++)
            {
                for (int i = 0; i < n; i++)
                {
                    if (matrix[i, j] < 0)
                    {
                        negative[j]++;
                    }
                }
            }
            answer = negative;
            // end

            return answer;
        }
        public void Task2(int[,] matrix)
        {

            // code here
            int n = matrix.GetLength(0), m = matrix.GetLength(1);
            int[] min = new int[n], index = new int[n];
            for (int i = 0; i < n; i++)
            {
                min[i] = matrix[i, 0];
                index[i] = 0;
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] < min[i])
                    {
                        index[i] = j;
                        min[i] = matrix[i, j];
                    }
                }
            }
            int penis;
            for (int i = 0; i < n; i++)
            {
                penis = index[i];
                while (penis > 0)
                {
                    matrix[i, penis] = matrix[i, penis - 1];
                    penis--;
                }
                matrix[i, 0] = min[i];
            }

            // end

        }
        public int[,] Task3(int[,] matrix)
        {
            int[,] answer = null;

            // code here
            int n = matrix.GetLength(0), m = matrix.GetLength(1);
            int[] k = new int[n];
            int[] max = new int[n];
            for (int i = 0; i < n; i++)
            {
                max[i] = int.MinValue;
            }
            answer = new int[n, m + 1];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; (j < m); j++)
                {
                    if (matrix [i, j] > max[i])
                    {
                        max [i] = matrix [i, j];
                        k[i] = j;
                    }
                }
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; (j < m + 1); j++)
                {
                    if (j < k[i])
                    {
                        answer[i, j] = matrix [i, j];
                    }
                    else if (j == k[i])
                    {
                        answer[i, j] = max[i];
                    }
                    else
                    {
                        answer[i, j] = matrix [i, j - 1];
                    }
                }
            }
            // end

            return answer;
        }
        public void Task4(int[,] matrix)
        {

            // code here
            int n = matrix.GetLength(0), m = matrix.GetLength(1);
            int[] k = new int[n];
            int[] max = new int[n];
            int[] sum = new int[n];
            int[] count = new int[n];
            for (int i = 0; i < n; i++)
            {
                max[i] = int.MinValue;
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; (j < m); j++)
                {
                    if (matrix[i, j] > max[i])
                    {
                        max[i] = matrix[i, j];
                        k[i] = j;
                        sum[i] = 0;
                        count[i] = 0;
                    }
                    else if (matrix[i, j] > 0)
                    {
                        count[i]++;
                        sum[i] += matrix[i, j];
                    }
                }
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; (j < m + 1); j++)
                {
                    if (!(sum[i] == 0))
                    {
                        if (j < k[i])
                        {
                            if (matrix[i, j] < 0)
                            {
                                matrix[i, j] = (sum[i] / count[i]);
                            }
                        }
                    }
                }
            }
            // end

        }
        public void Task5(int[,] matrix, int k)
        {

            // code here
            int n = matrix.GetLength(0), m = matrix.GetLength(1);
            int[] max = new int[n];
            for (int i = 0; i < n; i++)
            {
                max[i] = int.MinValue;
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; (j < m); j++)
                {
                    if (matrix[i, j] > max[i])
                    {
                        max[i] = matrix[i, j];
                    }
                }
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; (j < m); j++)
                {
                    if (j == k)
                    {
                        matrix[i, j] = max[n - i - 1];
                    }
                }
            }
            // end

        }
        public void Task6(int[,] matrix, int[] array)
        {

            // code here
            int n = matrix.GetLength(0), m = matrix.GetLength(1);
            int[] max = new int[m], max_index = new int[m];
            if (m == array.Length)
            {
                for (int i = 0; i < m; i++)
                {
                    max[i] = int.MinValue;
                }
                for (int j = 0; j < m; j++)
                {
                    for (int i = 0; i < n; i++)
                    {
                        if (matrix[i, j] > max[j])
                        {
                            max[j] = matrix[i, j];
                            max_index[j] = i;
                        }
                    }
                    if (array[j] > max[j])
                    {
                        matrix[max_index[j], j] = array[j];
                    }
                }
            }
            // end

        }
        public void Task7(int[,] matrix)
        {

            // code here
            int n = matrix.GetLength(0), m = matrix.GetLength(1);
            int[] min = new int[n];
            if (n > 1)
            {
                for (int i = 0; i < n; i++)
                {
                    min[i] = int.MaxValue;
                }
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        if (matrix[i, j] < min[i])
                        {
                            min[i] = matrix[i, j];
                        }
                    }
                }
                int c = 0;
                while (c < n)
                {
                    if ((c == 0) || (min[c] <= min[c - 1]))
                    {
                        c++;
                    }
                    else
                    {
                        (min[c], min[c - 1]) = (min[c - 1], min[c]);
                        for (int i = 0; i < m; i++)
                        {
                            (matrix[c, i], matrix[c - 1, i]) = (matrix[c - 1, i], matrix[c, i]);
                        }
                        c--;
                    }
                }
            }
            // end

        }
        public int[] Task8(int[,] matrix)
        {
            int[] answer = null;

            // code here
            int n = matrix.GetLength(0), m = matrix.GetLength(1);
            if (n == m)
            {
                int[] sums = new int[(2 * n) - 1];
                int s1 = n - 1, s2 = 0;
                int i1, i2;
                for (int i = 0; i < (2 * n) - 1; i++)
                {
                    i1 = s1;
                    i2 = s2;
                    while ((i1 < n) && (i2 < m))
                    {
                        sums[i] += matrix[i1, i2];
                        i1++;
                        i2++;
                    }
                    if (s1 > 0)
                    {
                        s1--;
                    }
                    else
                    {
                        s2++;
                    }
                }
                answer = sums;
            }
            // end

            return answer;
        }
        public void Task9(int[,] matrix, int k)
        {

            // code here
            int n = matrix.GetLength(0), m = matrix.GetLength(1);
            int MaxAbs = int.MinValue;
            int MaxAbs_i = 0, MaxAbs_j = 0;
            if ((n == m) && (k < n))
            {
                for (int j = 0; j < m; j++)
                {
                    for (int i = 0; i < n; i++)
                    {
                        if (Math.Abs(matrix[i, j]) > MaxAbs)
                        {
                            MaxAbs = Math.Abs(matrix[i, j]);
                            MaxAbs_i = i;
                            MaxAbs_j = j;
                        }
                    }
                }
                while ((MaxAbs_i != k) || (MaxAbs_j != k))
                {
                    if ((MaxAbs_i < k) || (MaxAbs_i > k))
                    {
                        if (MaxAbs_i < k)
                        {
                            for (int i = 0; i < m; i++)
                            {
                                (matrix[MaxAbs_i, i], matrix[MaxAbs_i + 1, i]) = (matrix[MaxAbs_i + 1, i], matrix[MaxAbs_i, i]);
                            }
                            MaxAbs_i++;
                        }
                        else
                        {
                            for (int i = 0; i < m; i++)
                            {
                                (matrix[MaxAbs_i, i], matrix[MaxAbs_i - 1, i]) = (matrix[MaxAbs_i - 1, i], matrix[MaxAbs_i, i]);
                            }
                            MaxAbs_i--;
                        }
                    }
                    else
                    {
                        if (MaxAbs_j < k)
                        {
                            for (int i = 0; i < n; i++)
                            {
                                (matrix[i, MaxAbs_j], matrix[i, MaxAbs_j + 1]) = (matrix[i, MaxAbs_j + 1], matrix[i, MaxAbs_j]);
                            }
                            MaxAbs_j++;
                        }
                        else
                        {
                            for (int i = 0; i < n; i++)
                            {
                                (matrix[i, MaxAbs_j], matrix[i, MaxAbs_j - 1]) = (matrix[i, MaxAbs_j - 1], matrix[i, MaxAbs_j]);
                            }
                            MaxAbs_j--;
                        }
                    }
                }
            }
            // end

        }
        public int[,] Task10(int[,] A, int[,] B)
        {
            int[,] answer = null;

            // code here
            int n = A.GetLength(0), m = B.GetLength(1);
            if (A.GetLength(1) == B.GetLength(0))
            {
                answer = new int[n, m];
                for (int i = 0; i < m; i++)
                {
                    for (int j = 0; j < A.GetLength(1); j++)
                    {
                        for (int k = 0; k < n; k++)
                        {
                            answer[k, i] += (A[k, j] * B[j, i]);
                        }
                    }
                }
            }
            else if (n == m)
            {
                answer = new int[B.GetLength(1), A.GetLength(1)];
                for (int i = 0; i < A.GetLength(1); i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        for (int k = 0; k < B.GetLength(1); k++)
                        {
                            answer[k, i] += (B[k, j] * A[j, i]);
                        }
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
            int n = matrix.GetLength(0), m = matrix.GetLength(1);
            answer = new int[n][];
            int[] flags = new int[n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        flags[i]++;
                    }
                }
            }
            for (int i = 0; i < n; i++)
            {
                if (flags[i] != 0)
                {
                    answer[i] = new int[flags[i]];
                }
                flags[i] = 0;
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        answer[i][flags[i]] = matrix[i, j];
                        flags[i]++;
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
            int n = array.Length;
            int AllLength = 0;
            for (int i = 0; i < n; i++)
            {
                AllLength += array[i].Length;
            }
            int square = (int)Math.Ceiling(Math.Sqrt(AllLength));
            int CurrentLength = 0;
            int c = 0;
            answer = new int[square, square];
            for (int i = 0; i < n; i++)
            {
                while (c < array[i].Length)
                {
                    answer[CurrentLength / square, CurrentLength % square] = array[i][c];
                    c++;
                    CurrentLength++;
                }
                c = 0;
            }
            // end

            return answer;
        }
    }
}