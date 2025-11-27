namespace Lab5
{
    public class Purple
    {
        public int[] Task1(int[,] matrix)
        {
            int[] answer = null;

            // code here

            int n = matrix.GetLength(0), m = matrix.GetLength(1);
            answer = new int[m];
            for (int j = 0; j < m; j++)
            {
                for (int i = 0; i < n; i++)
                {
                    if (matrix[i, j] < 0)
                    {
                        answer[j]++;
                    }
                }
            }
            
            // end

            return answer;
        }
        public void Task2(int[,] matrix)
        {

            // code here

            int n = matrix.GetLength(0), m = matrix.GetLength(1);
            for (int i = 0; i < n; i++)
            {
                int j_min = 0;
                for (int j = 1; j < m; j++)
                {
                    if (matrix[i,j] < matrix[i, j_min])
                    {
                        j_min = j;
                    }
                }
                for (int j = j_min; j >= 1; --j)
                {
                    (matrix[i, j - 1], matrix[i, j]) = (matrix[i, j], matrix[i, j - 1]);
                }
            }

            // end

        }
        public int[,] Task3(int[,] matrix)
        {
            int[,] answer = null;

            // code here

            int n = matrix.GetLength(0), m = matrix.GetLength(1);
            answer = new int[n, m + 1];

            for (int i = 0; i < n; i++)
            {
                int j_max = 0;
                for (int j = 1; j < m; j++)
                {
                    if (matrix[i, j] > matrix[i, j_max])
                    {
                        j_max = j;
                    }
                }
                for (int j = 0; j <= j_max; j++)
                {
                    answer[i,j] = matrix[i, j];
                }
                answer[i, j_max + 1] = matrix[i, j_max];
                for (int j = j_max + 1; j < m; j++)
                {
                    answer[i, j + 1] = matrix[i, j];
                }
            }

            // end

            return answer;
        }
        public void Task4(int[,] matrix)
        {

            // code here

            int n = matrix.GetLength(0), m = matrix.GetLength(1);
            for (int i = 0; i < n; ++i)
            {
                int j_max = 0;
                for (int j = 1; j < m; ++j)
                {
                    if (matrix[i, j] > matrix[i, j_max])
                    {
                        j_max = j;
                    }
                }
                //Console.Write($"j_max: {j_max}    ");

                int pos_cnt = 0;
                int pos_sum = 0;
                for (int j = j_max + 1; j < m; j++)
                {
                    if (matrix[i,j] > 0)
                    {
                        pos_cnt++;
                        pos_sum += matrix[i, j];
                    }
                }
                if (pos_cnt == 0)
                {
                    //Console.WriteLine("no pos");
                    continue;
                }

                int mid = pos_sum / pos_cnt;
                //Console.WriteLine($"{pos_sum} / {pos_cnt} = {mid}");

                for (int j = 0; j < j_max; j++)
                {
                    if (matrix[i, j] < 0)
                    {
                        matrix[i, j] = mid;
                    }
                }
            }

            // end

        }
        public void Task5(int[,] matrix, int k)
        {

            // code here

            int n = matrix.GetLength(0), m = matrix.GetLength(1);

            if (0 <= k && k < m)
            {
                int[] maxes = new int[n];
                for (int i = 0; i < n; i++)
                {
                    int max_v = matrix[i, 0];
                    for (int j = 1; j < m; j++)
                    {
                        max_v = Math.Max(max_v, matrix[i, j]);
                    }
                    maxes[i] = max_v;
                }

                for (int i = 0; i < n; i++)
                {
                    matrix[i, k] = maxes[n - 1 - i];
                }
            }

            // end

        }
        public void Task6(int[,] matrix, int[] array)
        {

            // code here

            int n = matrix.GetLength(0), m = matrix.GetLength(1);
            if (m != array.Length)
            {
                return;
            }
            for (int j = 0; j < m; j++)
            {
                int i_max = 0;
                for (int i = 1; i < n; i++)
                {
                    if (matrix[i, j] > matrix[i_max, j])
                    {
                        i_max = i;
                    }
                }
                if (matrix[i_max, j] < array[j])
                {
                    matrix[i_max, j] = array[j];
                }
            }

            // end

        }
        public void Task7(int[,] matrix)
        {

            // code here

            int n = matrix.GetLength(0), m = matrix.GetLength(1);
            (int, int)[] minim_ind = new (int, int)[n];
            for (int i = 0; i < n; i++)
            {
                int j_min = 0;
                for (int j = 1; j < m; j++)
                {
                    if (matrix[i, j] < matrix[i, j_min])
                    {
                        j_min = j;
                    }
                }
                minim_ind[i] = (matrix[i, j_min], i);
            }

            /*
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"{minim_ind[i].Item1}  {minim_ind[i].Item2}");
            }
            Console.WriteLine();
            */

            for (int i = 0; i < n - 1; i++)
            {
                bool changed = false;
                for (int j = 0; j < n - 1 - i; j++)
                {
                    if (minim_ind[j].Item1 < minim_ind[j + 1].Item1)
                    {
                        (minim_ind[j], minim_ind[j + 1]) = (minim_ind[j + 1], minim_ind[j]);
                        changed = true;
                    }
                }
                if (!changed)
                {
                    break;
                }
            }

            /*
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"{minim_ind[i].Item1}  {minim_ind[i].Item2}");
            }
            Console.WriteLine();
            */

            int[,] ans = new int[n, m];
            for (int i = 0; i < n; i++)
            {
                int i_pr = minim_ind[i].Item2;
                for (int j = 0; j < m; j++)
                {
                    ans[i, j] = matrix[i_pr, j];
                }
            }

            Array.Copy(ans, matrix, ans.Length);

            // end

        }
        public int[] Task8(int[,] matrix)
        {
            int[] answer = null;

            // code here

            if (matrix.GetLength(0) != matrix.GetLength(1))
            {
                return null;
            }
            
            int n = matrix.GetLength(0);
            answer = new int[2 * n - 1];
            int i_ans = 0;

            for (int i_st = n - 1; i_st >= 0; --i_st)
            {
                for (int i = i_st, j = 0; i < n; i++, j++)
                {
                    answer[i_ans] += matrix[i, j];
                }
                i_ans++;
            }
            for (int j_st = 1; j_st < n; j_st++)
            {
                for (int i = 0, j = j_st; j < n; i++, j++)
                {
                    answer[i_ans] += matrix[i, j];
                }
                i_ans++;
            }

            // end

            return answer;
        }
        public void Task9(int[,] matrix, int k)
        {

            // code here

            if (matrix.GetLength(0) != matrix.GetLength(1))
            {
                return;
            }
            int n = matrix.GetLength(0);
            if (k < 0 || k >= n)
            { 
                return;
            }

            int i_max = 0, j_max = 0;
            int max_mod = Math.Abs(matrix[i_max, j_max]);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (Math.Abs(matrix[i,j]) > max_mod) {
                        i_max = i;
                        j_max = j;
                        max_mod = Math.Abs(matrix[i, j]);
                    }
                }
            }

            //Console.WriteLine($"i = {i_max} j = {j_max} mx = {max_mod}\n");
            //Console.WriteLine($"k = {k}\n");

            if (i_max < k)
            {
                for (int i = i_max; i < k; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        (matrix[i, j], matrix[i + 1, j]) = (matrix[i + 1, j], matrix[i, j]);
                    }
                }
            }
            else
            {
                for (int i = i_max - 1; i >= k; i--)
                {
                    for (int j = 0; j < n; j++)
                    {
                        (matrix[i, j], matrix[i + 1, j]) = (matrix[i + 1, j], matrix[i, j]);
                    }
                }
            }

            /*
            Console.WriteLine("Сдвинули по i:\n");

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write($"{matrix[i, j],4}");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            */

            if (j_max < k)
            {
                for (int j = j_max; j < k; j++)
                {
                    for (int i = 0; i < n; i++)
                    {
                        (matrix[i, j], matrix[i, j + 1]) = (matrix[i, j + 1], matrix[i, j]);
                    }
                }
            }
            else
            {
                for (int j = j_max - 1; j >= k; j--)
                {
                    for (int i = 0; i < n; i++)
                    {
                        (matrix[i, j], matrix[i, j + 1]) = (matrix[i, j + 1], matrix[i, j]);
                    }
                }
            }

            //Console.WriteLine("Сдвинули по j, итог:\n");

            // end

        }
        public int[,] Task10(int[,] A, int[,] B)
        {
            int[,] answer = null;

            // code here

            int nA = A.GetLength(0), mA = A.GetLength(1);
            int nB = B.GetLength(0), mB = B.GetLength(1);
            if (mA != nB)
            {
                return null;
            }
            answer = new int[nA, mB];

            for (int i = 0; i < nA; ++i)
            {
                for (int j = 0; j < mB; ++j)
                {
                    for (int k = 0; k < mA; ++k)
                    {
                        answer[i, j] += A[i, k] * B[k, j];
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
                int cnt_pos = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        cnt_pos++;
                    }
                }
                int[] pos = new int[cnt_pos];
                int i_pos = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        pos[i_pos++] = matrix[i, j];
                    }
                }
                answer[i] = pos;
            }

            // end

            return answer;
        }
        public int[,] Task12(int[][] array)
        {
            int[,] answer = null;

            // code here

            int cnt = 0;
            foreach (int[] v in array)
            {
                if (v != null)
                {
                    cnt += v.Length;
                }
            }
            int len = (int)Math.Ceiling(Math.Sqrt(cnt));
            answer = new int[len, len];
            int i_ans = 0;

            foreach (int[] v in array)
            {
                if (v != null)
                {
                    foreach (int x in v)
                    {
                        answer[i_ans / len, i_ans % len] = x;
                        i_ans++;
                    }
                }
            }

            // end

            return answer;
        }
    }
}