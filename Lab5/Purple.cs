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
            int row = matrix.GetLength(0);
            int col = matrix.GetLength(1);
            answer = new int[col];
            int k = 0;
            for (int c = 0; c < col; c++)
            {
                int cnt = 0;
                for (int r = 0; r < row; r++)
                {
                    if (matrix[r, c] < 0) cnt++;
                }
                answer[k++] = cnt;
            }
            // end

            return answer;
        }
        public void Task2(int[,] matrix)
        {

            // code here
            int row = matrix.GetLength(0);
            int col = matrix.GetLength(1);
            for (int r = 0; r < row; r++)
            if (col > 1)
            {
                for (int i = 0; i < row; i++)
                {
                    int[] array = new int[col];
                    int k = 0;
                    for (int j = 0; j < col; j++) array[k++] = matrix[i, j];
                    int nmin = array[0];
                    int imin = 0;
                    for (int j = 1; j < col; j++)
                    {
                        if (array[j] < nmin) { nmin = array[j]; imin = j; }
                    }
                    Console.WriteLine(imin);
                    if (imin != 0)
                    {
                        for (int j = imin; j > 0; j--) matrix[i, j] = matrix[i, j - 1];
                        matrix[i, 0] = nmin;
                    }
                }
            }
            // end

        }
        public int[,] Task3(int[,] matrix)
        {
            int[,] answer = null;

            // code here
            int row = matrix.GetLength(0);
            int col = matrix.GetLength(1);
            answer = new int[row, col + 1];
            for (int i = 0; i < row; i++)
            {
                int[] array = new int[col]; int k = 0;
                for (int j = 0; j < col; j++) array[k++] = matrix[i, j];
                int nmax = array[0];
                int imax = 0;
                for (int j = 0; j < col; j++)
                {
                    if (array[j] > nmax) { nmax = array[j]; imax = j; }
                }
                for (int j = 0; j < col + 1; j++)
                {
                    if (j <= imax) answer[i, j] = matrix[i, j];
                    else if (j == imax + 1) answer[i, j] = nmax;
                    else answer[i, j] = matrix[i, j - 1];
                }
            }
            // end

            return answer;
        }
        public void Task4(int[,] matrix)
        {

            // code here
            int row = matrix.GetLength(0);
            int col = matrix.GetLength(1);
            for (int i = 0; i < row; i++)
            {
                int[] array = new int[col]; int k = 0;
                for ( int j = 0; j < col; j++) array[j] = matrix[i, j];
                int nmax = array[0]; int imax = 0;
                for (int j = 1;  j < col; j++)
                {
                    if (array[j] > nmax) { nmax = array[j]; imax = j; }
                }
                int s = 0; int cnt = 0;
                for (int j = imax + 1; j < col; j++)
                {
                    if (array[j] > 0) { s += array[j]; cnt++; }
                }
                if (cnt > 0)
                {
                    int avg = s / cnt;
                    for (int j = 0; j < imax; j++)
                    {
                        if (array[j] < 0) array[j] = avg;
                    }
                    for (int j = 0; j < col; j++) matrix[i, j] = array[j];
                }
            }
            // end

        }
        public void Task5(int[,] matrix, int k)
        {

            // code here
            int row = matrix.GetLength(0);
            int col = matrix.GetLength(1);
            int[] maxel = new int[row];
            int c = 0;
            for (int i = 0; i < row; i++)
            {
                int[] array = new int[col];
                for (int j = 0; j < col; j++) array[j] = matrix[i, j];
                int nmax = array[0]; int imax = 0;
                for (int j = 0; j < col; j++)
                {
                    if (array[j] > nmax) { nmax = array[j]; imax = j; }
                }
                maxel[c++] = nmax;
            }
            Array.Reverse(maxel);
            if (k < col)
            {
                for (int i = 0; i < row; i++)
                {
                    matrix[i, k] = maxel[i];
                }
            }
            // end

        }
        public void Task6(int[,] matrix, int[] array)
        {

            // code here
            int row = matrix.GetLength(0); int col = matrix.GetLength(1);
            if (array.Length == col)
            {
                for (int i = 0; i < col; i++)
                {
                    int[] mas = new int[row];
                    for (int j = 0; j < row; j++) mas[j] = matrix[j, i];
                    int nmax = mas[0]; int imax = 0;
                    for (int j = 0; j < row; j++)
                    {
                        if (mas[j] > nmax) { nmax = mas[j]; imax = j; }
                    }
                    if (i < array.Length && array[i] > mas[imax])
                    {
                        mas[imax] = array[i];
                        for (int j = 0; j < row; j++) matrix[j, i] = mas[j];
                    }
                }
            }
            // end

        }
        public void Task7(int[,] matrix)
        {

            // code here
            int row = matrix.GetLength(0); int col = matrix.GetLength(1);
            int[] masmin = new int[row]; int k = 0;
            for (int i = 0;i < row; i++)
            {
                int[] array = new int[col];
                for (int j = 0;j < col; j++) array[j] = matrix[i, j];
                int nmin = array[0];
                for (int j = 1; j < col; j++)
                {
                    if (array[j] < nmin) nmin = array[j];
                }
                masmin[k++] = nmin;
            }
            int[] sort_masmin = (int[])masmin.Clone();
            Array.Sort(sort_masmin);
            Array.Reverse(sort_masmin);
            int[,] matrix2 = new int[row, col];
            for (int i = 0; i < row; i++)
            {
                int cur = 0;
                for (int j = 0; j < row; j++)
                {
                    if (sort_masmin[i] == masmin[j])
                    {
                        cur = j;
                        masmin[j] = int.MaxValue;
                        break;
                    }
                }
                for (int j = 0; j < col; j++)
                {
                    matrix2[i, j] = matrix[cur, j];
                }
            }
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    matrix[i, j] = matrix2[i, j];
                }
            }
            // end

        }
        public int[] Task8(int[,] matrix)
        {
            int[] answer = null;

            // code here
            int row = matrix.GetLength(0);
            int col = matrix.GetLength(1);
            if (row == col)
            {
                answer = new int[2 * row - 1];
                int k = 0; int s = 0;
                for (int i = row - 1; i > 0; i--)
                {
                    int c = 0;
                    for (int j = i; j < row; j++)
                    {
                        c += matrix[j, j - i];
                    }
                    answer[k++] = c;
                }
                for (int i = 0; i < row; i++) s += matrix[i, i];
                answer[k++] = s;
                for (int i = row - 1; i > 0; i--)
                {
                    int c = 0;
                    for (int j = 0; j < i; j++)
                    {
                        c += matrix[j, j + row - i];
                    }
                    answer[k++] = c;
                }
            }
            // end

            return answer;
        }
        public void Task9(int[,] matrix, int k)
        {

            // code here
            int row = matrix.GetLength(0);
            int col = matrix.GetLength(1);
            if (row == col && k <= row - 1)
            {
                int n_max = 0; int row_max = 0; int col_max = 0;
                for (int i = 0; i < row; i++)
                {
                    for (int j = 0; j < col; j++)
                    {
                        if (Math.Abs(matrix[i, j]) > Math.Abs(n_max))
                        {
                            n_max = matrix[i, j]; row_max = i; col_max = j;
                        }
                    }
                }
                if (row_max > k)
                {
                    for (int j = 0; j < row; j++)
                    {
                        int elk = matrix[row_max, j];
                        for (int i = k + 1; i <= row_max; i++)
                        {
                            matrix[i, j] = matrix[i - 1, j];
                        }
                        matrix[k, j] = elk;
                    }
                }
                else if (row_max < k)
                {
                    for (int j = 0; j < row; j++)
                    {
                        int elk = matrix[row_max, j];
                        for (int i = row_max; i < k; i++)
                        {
                            matrix[i, j] = matrix[i + 1, j];
                        }
                        matrix[k, j] = elk;
                    }
                }
                if (col_max > k)
                {
                    for (int i = 0; i < col; i++)
                    {
                        int elk = matrix[i, col_max];
                        for (int j = col_max; j > k; j--)
                        {
                            matrix[i, j] = matrix[i, j - 1];
                            ;
                        }
                        matrix[i, k] = elk;
                    }
                }
                else if (col_max < k)
                {
                    for (int i = 0; i < col; i++)
                    {
                        int elk = matrix[i, col_max];
                        for (int j = col_max; j < k; j++)
                        {
                            matrix[i, j] = matrix[i, j + 1];
                        }
                        matrix[i, k] = elk;
                    }
                }

            }
            // end

        }
        public int[,] Task10(int[,] A, int[,] B)
        {
            int[,] answer = null;

            // code here
            int row_a = A.GetLength(0); int col_a = A.GetLength(1);
            int row_b = B.GetLength(0); int col_b = B.GetLength(1);
            if (col_a == row_b)
            {
                answer = new int[row_a, col_b];
                for (int c = 0; c < row_a; c++)
                {
                    for (int j = 0; j < col_b; j++)
                    {
                        int s = 0;
                        for (int i = 0; i < row_b; i++)
                        {
                            s += A[c, i] * B[i, j];
                        }
                        answer[c, j] = s;
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
            int row = matrix.GetLength(0); int col = matrix.GetLength(1);
            answer = new int[row][];
            for (int i = 0; i < row; i++)
            {
                int cnt = 0;
                for (int j = 0; j < col; j++)
                {
                    if (matrix[i, j] > 0) cnt++;
                }
                answer[i] = new int[cnt]; int c = 0;
                for (int j = 0; j < col; j++)
                {
                    if (matrix[i, j] > 0) answer[i][c++] = matrix[i, j];
                }
            }
            // end

            return answer;
        }
        public int[,] Task12(int[][] array)
        {
            int[,] answer = null;

            // code here
            int total = 0;
            foreach (int[] a in array)
            {
                if (a != null)
                {
                    foreach (int el in a) total++;
                }
            }
            int len = (int)Math.Ceiling(Math.Sqrt(total));
            answer = new int[len, len];
            int[] list = new int[len * len]; int c = 0;
            foreach (int[] a in array)
            {
                foreach (int el in a) list[c++] = el;
            }
            c = 0;
            for (int i = 0; i < len; i++)
            {
                for (int j = 0; j < len; j++)
                {
                    answer[i, j] = list[c++];
                }
            }
            // end

            return answer;
        }
    }
}