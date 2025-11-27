using System.Linq;
using System.Runtime.InteropServices;

namespace Lab5
{
    public class Purple
    {
        public int[] Task1(int[,] matrix)
        {
            if (matrix.Length == 0)
                return null;
            int a = matrix.GetLength(0);
            int b = matrix.GetLength(1);
            int ind = 0;
            int[] answer = new int[b];
            for (int i = 0; i < b; i++)
            {
                int cnt = 0;
                for (int j = 0; j < a; j++)
                {
                    if (matrix[j, i] < 0)
                    {
                        cnt++;
                    }
                }
                answer[ind++] = cnt;
            }
            // code here

            // end
            return answer;

        }
        public void Task2(int[,] matrix)
        {
            int a = matrix.GetLength(0);
            int b = matrix.GetLength(1);
            for (int i = 0; i < a; i++)
            {
                int min = matrix[i, 0];
                int ind = 0;
                for (int j = 0; j < b; j++)
                {
                    if (matrix[i, j] < min)
                    {
                        min = matrix[i, j];
                        ind = j;
                    }
                }
                if (ind == 0)
                    continue;

                int temp = matrix[i, ind];
                for (int k = ind; k > 0; k--)
                {
                    matrix[i, k] = matrix[i, k - 1];
                }
                matrix[i, 0] = temp;

            }
            // code here

            // end



        }
        public int[,] Task3(int[,] matrix)
        {
            int a = matrix.GetLength(0);
            int b = matrix.GetLength(1);
            int[,] answer = new int[a, b + 1];
            for (int i = 0; i < a; i++)
            {
                int ind_ans = 0;
                int max_elem = int.MinValue;
                int ind = 0;
                for (int j = 0; j < b; j++)
                {
                    if (matrix[i, j] > max_elem)
                    {
                        max_elem = matrix[i, j];
                        ind = j;
                    }
                }
                for (int j = 0; j < b; j++)
                {
                    if (j == ind)
                    {
                        answer[i, ind_ans++] = matrix[i, j];
                        answer[i, ind_ans++] = matrix[i, j];
                        continue;
                    }
                    answer[i, ind_ans++] = matrix[i, j];
                }
            }


            return answer;

        }
        public void Task4(int[,] matrix)
        {
            int a = matrix.GetLength(0);
            int b = matrix.GetLength(1);
            for (int i = 0; i < a; i++)
            {
                bool flag = false;
                int max_elem = int.MinValue;
                int ind = 0;
                for (int j = 0; j < b; j++)
                {
                    if (matrix[i, j] > max_elem)
                    {
                        max_elem = matrix[i, j];
                        ind = j;
                    }
                }
                int cnt = 0, sum = 0;
                for (int j = ind + 1; j < b; j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        cnt++;
                        sum += matrix[i, j];
                        flag = true;
                    }
                }
                if (flag)
                {
                    int sred = sum / cnt;
                    for (int j = 0; j < ind; j++)
                    {
                        if (matrix[i, j] < 0)
                        {
                            matrix[i, j] = sred;

                        }
                    }
                }
            }



        }
        public void Task5(int[,] matrix, int k)
        {
            int a = matrix.GetLength(0);
            int b = matrix.GetLength(1);
            if (k < 0 || k >= b)
                return;

            int[] array_max = new int[a];

            int ind = 0;
            for (int i = a - 1; i >= 0; i--)
            {
                int maxik = int.MinValue;
                for (int j = 0; j < b; j++)
                {
                    if ((matrix[i, j]) > maxik)
                        maxik = matrix[i, j];
                }
                array_max[ind++] = maxik;
            }
            int ind_2 = 0;
            for (int i = 0; i < a; i++)
            {
                matrix[i, k] = array_max[ind_2++];
            }


        }
        public void Task6(int[,] matrix, int[] array)
        {
            if (matrix == null || array == null)
                return;

            int a = matrix.GetLength(0);
            int b = matrix.GetLength(1);

            if (a == 0 || b == 0)
                return;

            if (array.Length != b)
                return;

            for (int j = 0; j < b; j++)
            {
                int maxik = int.MinValue;
                int ind_maxik = 0;

                for (int i = 0; i < a; i++)
                {
                    if (matrix[i, j] > maxik)
                    {
                        maxik = matrix[i, j];
                        ind_maxik = i;
                    }
                }

                if (matrix[ind_maxik, j] < array[j])
                    matrix[ind_maxik, j] = array[j];
            }


        }
        public void Task7(int[,] matrix)
        {
            int a = matrix.GetLength(0);
            int b = matrix.GetLength(1);

            for (int i = 0; i < a - 1; i++)
            {
                for (int j = 0; j < a - 1 - i; j++)
                {
                    int local_min1 = int.MaxValue;
                    int local_min2 = int.MaxValue;

                    for (int k = 0; k < b; k++)
                    {
                        if (matrix[j, k] < local_min1)
                        {
                            local_min1 = matrix[j, k];
                        }
                        if (matrix[j + 1, k] < local_min2)
                        {

                            local_min2 = matrix[j + 1, k];
                        }
                    }
                    if (local_min1 < local_min2)
                    {
                        for (int k = 0; k < b; k++)
                        {
                            int temp = matrix[j, k];
                            matrix[j, k] = matrix[j + 1, k];
                            matrix[j + 1, k] = temp;
                        }
                    }
                }
            }


        }
        public int[] Task8(int[,] matrix)
        {
            int a = matrix.GetLength(0);
            int b = matrix.GetLength(1);
            if (a == 0 || b == 0 || a != b)
                return null;
            int[] answer = new int[2 * a - 1];
            int cnt = 0;
            while (cnt < 2 * a - 1)
            {
                int sum = 0;
                if (cnt < a)
                {
                    int i = a - 1 - cnt;
                    int j = 0;
                    while (j < a && j <= cnt)

                        sum += matrix[i++, j++];

                }
                else
                {
                    int i = 0;
                    int j = cnt - a + 1;
                    while (j < a && i < 2 * a - 1 - cnt)
                    {
                        sum += matrix[i++, j++];
                    }
                }
                answer[cnt++] = sum;

            }

            // code here

            // end

            return answer;

        }
        public void Task9(int[,] matrix, int k)
        {
            int ind_i = 0, ind_j = 0;
            int a = matrix.GetLength(0);
            int b = matrix.GetLength(1);

            if (a != b || a == 0 || k < 0 || k >= a)
                return;

            int maxik = int.MinValue;

            for (int i = 0; i < a; i++)
            {
                for (int j = 0; j < b; j++)
                {
                    if (Math.Abs(matrix[i, j]) > maxik)
                    {
                        maxik = Math.Abs(matrix[i, j]);
                        ind_i = i;
                        ind_j = j;
                    }
                }
            }

            while (ind_i > k)
            {
                for (int j = 0; j < b; j++)
                {
                    int temp = matrix[ind_i, j];
                    matrix[ind_i, j] = matrix[ind_i - 1, j];
                    matrix[ind_i - 1, j] = temp;
                }
                ind_i--;
            }

            while (ind_i < k)
            {
                for (int j = 0; j < b; j++)
                {
                    int temp = matrix[ind_i, j];

                    matrix[ind_i, j] = matrix[ind_i + 1, j];
                    matrix[ind_i + 1, j] = temp;
                }
                ind_i++;
            }

            while (ind_j > k)
            {
                for (int i = 0; i < a; i++)
                {
                    int temp = matrix[i, ind_j];
                    matrix[i, ind_j] = matrix[i, ind_j - 1];
                    matrix[i, ind_j - 1] = temp;
                }
                ind_j--;
            }

            while (ind_j < k)
            {
                for (int i = 0; i < a; i++)
                {
                    int temp = matrix[i, ind_j];
                    matrix[i, ind_j] = matrix[i, ind_j + 1];
                    matrix[i, ind_j + 1] = temp;
                }
                ind_j++;
            }
        }
        public int[,] Task10(int[,] A, int[,] B)
        {
            int a = A.GetLength(0);
            int b = A.GetLength(1);
            int b1 = B.GetLength(0);
            int c = B.GetLength(1);
            if (b != b1)
                return null;
            int[,] answer = new int[a, c];
            for (int i = 0; i < a; i++)
            {
                for (int j = 0; j < c; j++)
                {
                    int sum = 0;
                    for (int k = 0; k < b; k++)
                    {
                        sum = sum + A[i, k] * B[k, j];
                    }
                    answer[i, j] = sum;
                }
            }

            // code here

            // end

            return answer;
        }
        public int[][] Task11(int[,] matrix)
        {
            if (matrix == null)
            {
                return null;
            }
            int a = matrix.GetLength(0);
            int b = matrix.GetLength(1);
            int[][] answer = new int[a][];
            for (int i = 0; i < a; i++)
            {
                int ind = 0;
                int cnt = 0;
                for (int j = 0; j < b; j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        cnt++;
                    }
                }
                answer[i] = new int[cnt];
                for (int j = 0; j < b; j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        answer[i][ind++] = matrix[i, j];
                    }
                }
            }

            // code here

            // end

            return answer;
        }
        public int[,] Task12(int[][] array)
        {
            int a = array.Length;
            int cnt = 0;
            for (int i = 0; i < a; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    cnt++;
                }
            }
            int n = (int)Math.Ceiling(Math.Pow(cnt, 0.5));
            int[,] answer = new int[n, n];
            int[] meow = new int[n * n];
            for (int i = 0; i < n * n; i++)
            {
                meow[i] = 0;
            }
            int ind = 0;
            for (int i = 0; i < a; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    meow[ind++] = array[i][j];
                }
            }
            ind = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    answer[i, j] = meow[ind++];
                }
            }
            
            return answer;


        }
    }
}