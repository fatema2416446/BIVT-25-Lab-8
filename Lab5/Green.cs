using System.IO.IsolatedStorage;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.JavaScript;

namespace Lab5
{
    public class Green
    {
        public int[] Task1(int[,] matrix)
        {
            int[] answer = null;

            // code here
            answer = new int[matrix.GetLength(0)];
            for(int i = 0; i<matrix.GetLength(0); i++)
            {
                int mi = 0;
                int mel = int.MaxValue;
                for (int j = 0; j<matrix.GetLength(1); j++)
                {
                    if(mel > matrix[i, j])
                    {
                        mel = matrix[i, j];
                        mi = j;
                    }
                }
                answer[i] = mi;
            }
            
            // end

            return answer;
        }
        public void Task2(int[,] matrix)
        {

            // code here
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int melisik = int.MinValue;
                int mi = 0;
                for(int j = 0; j<matrix.GetLength(1); j++)
                {
                    if (matrix[i,j] > melisik)
                    {
                        melisik = matrix[i,j];
                        mi = j;
                    }
                }

                for(int j = 0; j<mi; j++)
                {
                    if (matrix[i, j] < 0)
                    {
                        matrix[i, j] = (int)Math.Floor((double)matrix[i, j] / melisik);
                    }
                }
            }
            // end

        }
        public void Task3(int[,] matrix, int k)
        {

            // code here
            if(matrix.GetLength(0)==matrix.GetLength(1) && matrix.GetLength(1) > k)
            {
                int mi = 0;
                int el = matrix[0, 0];

                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    if (matrix[i, i] > el)
                    {
                        el = matrix[i, i];
                        mi = i;
                    }
                }

                for(int i = 0;i < matrix.GetLength(0); i++)
                {
                    int t = matrix[i, k];
                    matrix[i,k]=matrix[i,mi];
                    matrix[i,mi]=t;
                }
                
            }
            // end

        }
        public void Task4(int[,] matrix)
        {

            // code here
            if (matrix.GetLength(0) != matrix.GetLength(1)) return;

            int m = matrix[0, 0];
            int mi = 0;
            int mj = 0;

            for (int i = 0; i<matrix.GetLength(0); i++)
            {
                if (matrix[i, i] > m)
                {
                    m = matrix[i, i];
                    mi = i;
                    mj = i;
                }
                
            }

            int[] m1 = new int[matrix.GetLength(0)];
            int[] m2 = new int[matrix.GetLength(0)];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                m1[i] = matrix[mi, i];
                m2[i] = matrix[i, mj];
            }
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                matrix[mi, i] = m2[i];
            }
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                matrix[i, mj] = m1[i];
            }
            // end

        }
        public int[,] Task5(int[,] matrix)
        {
            int[,] answer = null;

            // code here
            int s = 0;
            int mi = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int cur_s = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        cur_s += matrix[i, j];
                    }
                }
                if(cur_s > s)
                {
                    s = cur_s;
                    mi = i;
                }
            }
            answer = new int[matrix.GetLength(0)-1,matrix.GetLength(1)];
            for(int i = 0; i < answer.GetLength(0); i++)
            {
                for(int j = 0; j < answer.GetLength(1); j++)
                {
                    if (i < mi)
                    {
                        answer[i,j] = matrix[i,j];
                    }
                    else
                    {
                        answer[i,j] = matrix[i+1,j];
                    }
                }
            }
            // end

            return answer;
        }
        public void Task6(int[,] matrix)
        {

            // code here
            int maxc = -1;
            int minc = 1000;
            int indmax = -1;
            int indmin = -1;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int c = 0;

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < 0)
                    {
                        c++;
                    }
                }
                if (maxc == -1 || c > maxc)
                {
                    maxc = c;
                    indmax = i;
                }
                if (minc == int.MaxValue || c < minc)
                {
                    minc = c;
                    indmin = i;
                }
            }

            if (maxc == minc || indmax == -1 || indmin == -1)
            {
                return;
            }

            else
            {
                for (int i = 0; i < matrix.GetLength(1); i++)
                {
                    int t = matrix[indmax, i];
                    matrix[indmax, i] = matrix[indmin, i];
                    matrix[indmin, i] = t;
                }
            }
            // end

        }
        public int[,] Task7(int[,] matrix, int[] array)
        {
            int[,] answer = null;

            // code here
            if (array.Length != matrix.GetLength(0))
                return matrix;

            int min = int.MaxValue;
            int mi = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < min)
                    {
                        min = matrix[i, j];
                        mi = j;
                    }
                }
            }

            answer = new int[matrix.GetLength(0), matrix.GetLength(1) + 1];
            int ma = 0;

            for (int i = 0; i < answer.GetLength(0); i++)
            {
                int ma1 = 0;

                for (int j = 0; j < answer.GetLength(1); j++)
                {
                    if (j == mi + 1)
                        answer[i, j] = array[i];
                    else
                        answer[i, j] = matrix[ma, ma1++];
                }

                ma++;
            }
            // end

            return answer;
        }
        public void Task8(int[,] matrix)
        {

            // code here
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                int p = 0;
                int m = 0;
                int max = int.MinValue;
                int imax = 0;
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    if (matrix[j, i] > max)
                    {
                        max = matrix[j, i];
                        imax = j;
                    }
                    if (matrix[j, i] > 0)
                        p++;
                    else if (matrix[j, i] < 0)
                        m++;
                }

                if (p > m)
                    matrix[imax, i] = 0;
                else if (m > p)
                    matrix[imax, i] = imax;
            }
            // end

        }
        public void Task9(int[,] matrix)
        {

            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            if (rows != cols)
                return;
            for (int i = 0; i < rows * rows; i++)
            {
                int x = i / rows;
                int b = i % rows;
                if (x == 0 || x == rows - 1 || b == 0 || b == rows - 1)
                {
                    matrix[x, b] = 0;
                }
            }
            // end

        }
        public (int[] A, int[] B) Task10(int[,] matrix)
        {
            int[] A = null, B = null;

            // code here
            if (matrix.GetLength(0) != matrix.GetLength(1))
            {
                return (A, B);
            }
            else
            {
                int a = 0;
                int b = 0;
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        if (j >= i)
                        {
                            a++;
                        }
                        if (j < i)
                        {
                            b++;
                        }
                    }
                }

                A = new int[a];
                B = new int[b];
                int ia = 0;
                int ib = 0;

                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        if (j >= i)
                        {
                            A[ia] = matrix[i, j];
                            ia++;
                        }
                        if (j < i)
                        {
                            B[ib] = matrix[i, j];
                            ib++;
                        }
                    }
                }
            }
            // end

            return (A, B);
        }
        public void Task11(int[,] matrix)
        {

            // code here
            int m1 = matrix.GetLength(0);
            int m2 = matrix.GetLength(1);

            for (int j = 0; j < m2; j++)
            {
                for (int x = 0; x < m1 - 1; x++)
                {
                    for (int i = 0; i < m1 - 1 - x; i++)
                    {
                        if (j % 2 == 0 && matrix[i, j] < matrix[i + 1, j])
                        {
                            (matrix[i, j], matrix[i + 1, j]) = (matrix[i + 1, j], matrix[i, j]);
                        }

                        if (j % 2 != 0 && matrix[i, j] > matrix[i + 1, j])
                        {
                            (matrix[i, j], matrix[i + 1, j]) = (matrix[i + 1, j], matrix[i, j]);
                        }
                    }
                }
            }
            // end

        }
        public void Task12(int[][] array)
        {

            // code here
            for (int i = 0; i < array.Length - 1; i++)
            {
                int m = i;
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j].Length > array[m].Length) m = j;
                    else if (array[j].Length == array[m].Length)
                    {
                        int s = 0;
                        int su = 0;
                        for (int k = 0; k < array[j].Length; k++) s += array[j][k];
                        for (int k = 0; k < array[m].Length; k++) su += array[m][k];
                        if (s > su) m = j;
                    }
                }
                if (m != i) (array[i], array[m]) = (array[m], array[i]);
            }
            // end

        }
    }
}
