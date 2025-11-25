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
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                Console.WriteLine();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{matrix[i, j]}" + " ");
                }
            }
            Console.WriteLine();
            answer =  new double[matrix.GetLength(0)];
            for (int i = 0; i < matrix.GetLength(0);i++)
            {
                double sp = 0, kl_p = 0;
                for (int j = 0; j < matrix.GetLength(1);j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        kl_p++;
                        sp += matrix[i, j];
                    }
                }
                if (sp > 0) 
                answer[i] = (sp / kl_p);
                else
                answer[i] = 0;
                Console.Write($"{sp} {kl_p} {sp/kl_p} |");

            }
            Console.WriteLine();
            Console.WriteLine(string.Join(" ",answer));
            Console.WriteLine("_________________________-");
            // end

            return answer;
        }
        public int[,] Task2(int[,] matrix)
        {
            int[,] answer = null;

            // code here
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                Console.WriteLine();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{matrix[i, j]}" + " ");
                }
            }

            int n = matrix.GetLength(0), m = matrix.GetLength(1), n_max = 0, m_max = 0;
            double max_a = matrix[0, 0];
            answer = new int[n-1, m-1];
            for (int i = 0; i < n;i++)
            {
                for (int j = 0;j< m; j++)
                {
                    if (matrix[i,j] > max_a)
                    {
                        max_a = matrix[i,j];
                        n_max = i;
                        m_max = j;
                    }
                }
            }
            for (int i = 0; i < n_max; i++)
            {
                for (int j = 0; j < m_max; j++)
                {
                    answer[i, j] = matrix[i, j];
                }
                for (int j = m_max + 1; j < m; j++)
                {
                    answer[i, j - 1] = matrix[i, j];
                }
            }
            for (int i = n_max+1; i < n; i++)
            {
                for (int j = 0; j < m_max; j++)
                {
                    answer[i-1, j] = matrix[i, j];
                }
                for (int j = m_max+1; j < m; j++)
                {
                    answer[i-1, j-1] = matrix[i, j];
                }
            }
            Console.WriteLine();
            for (int i = 0; i < answer.GetLength(0); i++)
            {
                Console.WriteLine();
                for (int j = 0; j < answer.GetLength(1); j++)
                {
                    Console.Write($"{answer[i, j]}" + " ");
                }
            }
            Console.WriteLine() ;
            Console.WriteLine("_________________________-");
            // end

            return answer;
        }
        public void Task3(int[,] matrix)
        {

            // code here
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                Console.WriteLine();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{matrix[i, j]}" + " ");
                }
            }
            int n = matrix.GetLength(0), m = matrix.GetLength(1);
            for (int i = 0; i <n; i++)
            {
                int mx = matrix[i,0], ind_mx = 0;
                for(int j = 0;j < m; j++)
                {
                    if (matrix[i, j] > mx)
                    {
                        mx = matrix[i, j];
                        ind_mx = j;
                    }

                }
                for (int j = ind_mx; j < m-1; j++)
                {
                    matrix[i, j] = matrix[i, j+1];
                }
                matrix[i, m - 1] = mx;
            }
            Console.WriteLine();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                Console.WriteLine();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{matrix[i, j]}" + " ");
                }
            }
            Console.WriteLine();
            Console.WriteLine("____________________");
            // end

        }
        public int[,] Task4(int[,] matrix)
        {
            int[,] answer = null;

            // code here
            Console.WriteLine();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                Console.WriteLine();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{matrix[i, j]}" + " ");
                }
            }
            int n  = matrix.GetLength(0), m = matrix.GetLength(1);
            answer = new int[n, m + 1];
            for (int i = 0; i < n; i++)
            {
                int mx = matrix[i, 0];
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] > mx)
                    {
                        mx = matrix[i, j];
                    }
                }
                for (int j = 0; j < m -1;j++)
                {
                    answer[i, j] = matrix[i, j];
                }
                answer[i, m - 1] = mx;
                answer[i, m] = matrix[i, m - 1];
            }
            Console.WriteLine();
            for (int i = 0; i < answer.GetLength(0); i++)
            {
                Console.WriteLine();
                for (int j = 0; j < answer.GetLength(1); j++)
                {
                    Console.Write($"{answer[i, j]}" + " ");
                }
            }
            Console.WriteLine();
            Console.WriteLine("_________________________-");
            // end

            return answer;
        }
        public int[] Task5(int[,] matrix)
        {
            int[] answer = null;

            // code here
            int n = matrix.GetLength(0), m = matrix.GetLength(1);
            answer = new int[n*m/2];
            int k = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if ((i + j) % 2 != 0)
                    {
                        answer[k] = matrix[i, j];
                        k++;
                    }
                }
            }
            // end

            return answer;
        }
        public void Task6(int[,] matrix, int k)
        {

            // code here
            Console.WriteLine();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                Console.WriteLine();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{matrix[i, j]}" + " ");
                }
            }
            int n = matrix.GetLength(0), m = matrix.GetLength(1),
                mx = matrix[0,0], in_m_c = 0;
            if (n == m) { 
                for (int i = 0; i<n;i++)
                {
                    if (matrix[i,i] > mx)
                    {
                        mx = matrix[i,i];
                        in_m_c = i;
                    }
                }
                Console.WriteLine(in_m_c);
                for (int i =0; i<n; i++)
                {
                    if (matrix[i,k] < 0)
                    {
                        for ( int j = 0; j < m; j++)
                        {
                            int c  = matrix[i,j];
                            matrix[i,j] = matrix[in_m_c,j];
                            matrix[in_m_c, j] = c;
                        }
                        break;
                    }

                }
            }
            
            Console.WriteLine();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                Console.WriteLine();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{matrix[i, j]}" + " ");
                }
            }
            Console.WriteLine();
            Console.WriteLine("____________");
            // end

        }
        public void Task7(int[,] matrix, int[] array)
        {

            // code here
            Console.WriteLine();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                Console.WriteLine();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{matrix[i, j]}" + " ");
                }
            }
            Console.WriteLine();
            int n = matrix.GetLength(0), m = matrix.GetLength(1);
            int mx = matrix[0, 0], ind = 0;
            if (m >= 2 && array.Length == m)
            {
                for (int i = 0; i < n; i++)
                {
                    if (matrix[i, m - 2] > mx)
                    {
                        mx = matrix[i, m - 2];
                        ind = i;
                    }
                }
                for (int j = 0; j < m; j++)
                {
                    matrix[ind, j] = array[j];
                }
            }
            Console.WriteLine();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                Console.WriteLine();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{matrix[i, j]}" + " ");
                }
            }
            Console.WriteLine();
            Console.WriteLine("____________");
            // end

        }
        public void Task8(int[,] matrix)
        {

            // code here
            Console.WriteLine();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                Console.WriteLine();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{matrix[i, j]}" + " ");
                }
            }
            Console.WriteLine();
            int n = matrix.GetLength(0), m = matrix.GetLength(1);
            for (int j =0; j < m; j++)
            {
                int mx = matrix[0, j], ind_j = 0, ind_i = 0;
                for (int i = 0;i < n; i++)
                {
                    if (matrix[i, j] > mx)
                    {
                        mx = matrix[i, j];
                        ind_i = i;
                    }
                }
                if (ind_i < n / 2)
                {
                    int sum = 0;
                    for (int i = ind_i + 1; i < n; i++)
                    {
                        sum += matrix[i, j];
                    }
                    matrix[0, j] = sum;
                    Console.WriteLine('1');
                }
            }
            Console.WriteLine();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                Console.WriteLine();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{matrix[i, j]}" + " ");
                }
            }
            Console.WriteLine();
            Console.WriteLine("____________");
            // end

        }
        public void Task9(int[,] matrix)
        {

            // code here
            Console.WriteLine();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                Console.WriteLine();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{matrix[i, j]}" + " ");
                }
            }
            Console.WriteLine();
            int n = matrix.GetLength(0), m = matrix.GetLength(1);
            int mx_ch = int.MinValue, mx_nch = int.MinValue,
                ind_ch = 0, ind_nch = 0;
            for (int i = 0;i<n;i++)
            {
                if (i % 2 == 0)
                {
                    for (int j = 0; j < m; j++)
                    {
                        if (matrix[i, j] > mx_nch)
                        {
                            mx_nch = matrix[i, j];
                            ind_nch = j;
                        }
                    }
                }
                else
                {
                    for (int j = 0; j < m; j++)
                    {
                        if (matrix[i, j] > mx_ch)
                        {
                            mx_ch = matrix[i, j];
                            ind_ch = j;
                        }
                    }
                    (matrix[i - 1, ind_nch], matrix[i, ind_ch]) = (matrix[i, ind_ch], matrix[i-1, ind_nch]);
                    mx_ch = int.MinValue; 
                    mx_nch = int.MinValue;
                       

                }
            }
            Console.WriteLine();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                Console.WriteLine();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{matrix[i, j]}" + " ");
                }
            }
            Console.WriteLine();
            Console.WriteLine("____________");
            // end

        }
        public void Task10(int[,] matrix)
        {

            // code here
            int n = matrix.GetLength(0), m = matrix.GetLength(1),
                mx = matrix[0, 0], ind_i = 0;
            if (n == m)
            {
                for (int i = 0;i < matrix.GetLength(0);i++)
                {
                    if (matrix[i, i] > mx)
                    {
                        mx = matrix[i, i];
                        ind_i = i;
                    }
                }
                for (int i = 0; i < ind_i; i++)
                {
                    for (int j = i + 1; j < m; j++)
                    {
                        matrix[i, j] = 0;
                    }
                }
            }
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                Console.WriteLine();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{matrix[i, j]}" + " ");
                }
            }
            Console.WriteLine();
            Console.WriteLine("____________");
            // end

        }
        public void Task11(int[,] matrix)
        {

            // code here
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                Console.WriteLine();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{matrix[i, j]}" + " ");
                }
            }
            Console.WriteLine();
            int n = matrix.GetLength(0), m = matrix.GetLength(1);
            int k_1 = 0;
            int[] kl = new int[n];
            for (int i = 0; i < n; i++)
            {
                k_1 = 0;
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        k_1++;
                    }
                }
                kl[i] = k_1;
            }
            Console.WriteLine(string.Join(" ", kl));
            for (int i = 0;i < n-1 ;i++)
            {
                for (int j = 0; j < n-i-1; j++)
                {

                    if (kl[j] < kl[j+1])
                    {
                        (kl[j], kl[j+1]) = (kl[j + 1], kl[j]);
                        for (int j1 = 0; j1 < m; j1++)
                        {
                            (matrix[j, j1], matrix[j + 1, j1]) = (matrix[j + 1, j1], matrix[j, j1]);
                        }
                    }
                }

            }
            Console.WriteLine(string.Join(" ", kl));
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                Console.WriteLine();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{matrix[i, j]}" + " ");
                }
            }
            Console.WriteLine();
            Console.WriteLine("____________");
            // end

        }
        public int[][] Task12(int[][] array)
        {
            int[][] answer = null;

            // code here
            foreach (var row in array)
                Console.WriteLine(string.Join(", ", row));
            int n = array.Length, k = 0;
            double sum = 0, kl = 0;
            for ( int i  = 0; i < n; i++)
            {
                int  m = array[i].Length;
                
                for ( int j = 0;j < m; j++)
                {
                    sum += array[i][j];
                    kl++;
                }
            }
            double sr = (double)sum / kl;

            for (int i = 0; i < n; i++)
            {
                int m = array[i].Length;
                double sr_p = 0;
                sum = 0;
                kl = 0;
                for (int j = 0; j < m; j++)
                {
                    sum += array[i][j];
                    kl++;
                }
                sr_p = (double)sum / kl;
                if (sr_p>=sr)
                {
                    k += 1;
                }
            }
            answer = new int[k][];
            int k_1 = 0;
            for (int i = 0; i < n; i++)
            {
                int m = array[i].Length;
                double sr_p = 0;
                sum = 0;
                kl = 0;
                for (int j = 0; j < m; j++)
                {
                    sum += array[i][j];
                    kl++;
                }
                sr_p = (double)sum / kl;
                if (sr_p >= sr)
                {
                    answer[k_1] = new int[m];
                    for (int j = 0;j < m; j++)
                    {
                        answer[k_1][j] = array[i][j];
                    }
                    k_1++;

                }
            }
            Console.WriteLine();
            foreach (var row in answer)
                Console.WriteLine(string.Join(", ", row));
            Console.WriteLine("__________________");
            // end

            return answer;
        }
    }
}
