using System.Linq;
using System.Reflection;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;

namespace Lab5
{
    public class Green
    {
        public int[] Task1(int[,] matrix)
        {
            int[] answer = null;

            if (matrix.Length == 0) return null;
            // code here
            int[] ans = new int[matrix.GetLength(0)];
            for(int i = 0; i < matrix.GetLength(0); i++)
            {
                int min = matrix[i, 0], indm = 0;
                for(int j = 1; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < min)
                    {
                        min = matrix[i, j];
                        indm = j;
                    }
                }
                ans[i] = indm;
            }
            // end

            return ans;
        }
        public void Task2(int[,] matrix)
        {
            int[] ind = new int[matrix.GetLength(0)];
            // code here
            for(int i = 0; i < matrix.GetLength(0); i++)
            {
                int max = matrix[i, 0], indm = 0;
                for(int j = 1; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                        indm = j;
                    }
                }
                ind[i] = indm;
            }
            for(int i = 0; i < matrix.GetLength(0); i++)
            {
                for(int j = 0; j < matrix.GetLength(1); j++)
                {
                    if(j < ind[i] && (matrix[i, j] < 0))
                    {
                        double del = (double)matrix[i, j] / matrix[i, ind[i]];
                        matrix[i, j] = (int)Math.Floor(del);
                    }
                }
            }

            // end

        }
        public void Task3(int[,] matrix, int k)
        {
            // code here
            if (matrix.GetLength(0) != matrix.GetLength(1)) return;
            if (k >= matrix.GetLength(1) || k < 0) return;
            int maxd = int.MinValue, indm = 0;
            for(int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, i] > maxd)
                {
                    maxd = matrix[i, i];
                    indm = i;
                }
            }
            if (k == indm) return;
            int p = 0;
            for(int i = 0; i < matrix.GetLength(0); i++)
            {
                p = matrix[i, k];
                matrix[i, k] = matrix[i, indm];
                matrix[i, indm] = p;
            }

            // end

        }
        public void Task4(int[,] matrix)
        {
            if (matrix.GetLength(0) != matrix.GetLength(1)) return;
            // code here
            int[] str = new int[matrix.GetLength(1)];
            int[] stl = new int[matrix.GetLength(0)];
            int maxd = int.MinValue, indm = 0;

            for(int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, i] > maxd)
                {
                    maxd = matrix[i, i];
                    indm = i;
                }
            }
            for(int i = 0; i < matrix.GetLength(1); i++)
            {
                str[i] = matrix[indm, i];
            }
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                stl[i] = matrix[i, indm];
            }
            for(int i = 0; i < matrix.GetLength(0); i++)
            {
                matrix[indm, i] = stl[i];
            }
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                matrix[i, indm] = str[i];
            }
            // end

        }
        public int[,] Task5(int[,] matrix)
        {
            int[,] answer = new int[matrix.GetLength(0) - 1, matrix.GetLength(1)];
            if (matrix.Length == 0) return null;
            // code here
            int maxs = int.MinValue, inds = 0;
            for(int i = 0; i < matrix.GetLength(0); i++)
            {
                int s = 0;
                for(int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        s += matrix[i, j];
                    }
                }
                if (s > maxs)
                {
                    maxs = s;
                    inds = i;
                }
            }
            for(int i = 0; i < answer.GetLength(0); i++)
            {
                for(int j = 0; j < answer.GetLength(1); j++)
                {
                    if(i < inds)
                    {
                        answer[i, j] = matrix[i, j];
                    }
                    else
                    {
                        answer[i, j] = matrix[i + 1, j];
                    }
                }
            }

            // end

            return answer;
        }
        public void Task6(int[,] matrix)
        {
            if (matrix.Length == 0) return;
            // code here

            int min = int.MaxValue, max = int.MinValue, indmin = 0, indmax = 0;
            for(int i = 0; i < matrix.GetLength(0); i++)
            {
                int cot = 0;
                for(int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < 0)
                    {
                        cot++;
                    }
                }
                if (cot < min)
                {
                    min = cot;
                    indmin = i;
                }
                if (cot > max)
                {
                    max = cot;
                    indmax = i;
                }
            }
            if (max == min) return;
            int p = 0;
            for(int i = 0; i < matrix.GetLength(1); i++)
            {
                p = matrix[indmin, i];
                matrix[indmin, i] = matrix[indmax, i];
                matrix[indmax, i] = p;
            }
            // end

        }
        public int[,] Task7(int[,] matrix, int[] array)
        {
            int[,] answer = new int[matrix.GetLength(0), matrix.GetLength(1) + 1];
            if (matrix.Length == 0) return null;
            // code here
            int mine = int.MaxValue, indm = 0;
            for(int i = 0; i < matrix.GetLength(0); i++)
            {
                for(int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < mine)
                    {
                        mine = matrix[i, j];
                        indm = j;
                    }
                }
            }
            if (array.Length != matrix.GetLength(0)) return matrix;
            for(int i = 0; i < answer.GetLength(0); i++)
            {
                int newc = 0;
                for(int j = 0; j < matrix.GetLength(1); j++)
                {
                    answer[i, newc] = matrix[i, j];
                    if(j == indm)
                    {
                        newc++;
                        answer[i, newc] = array[i];
                    }
                    newc++;
                }
            }
            // end

            return answer;
        }
        public void Task8(int[,] matrix)
        {
            if (matrix.Length == 0) return;
            // code here
            for(int j = 0; j < matrix.GetLength(1); j++)
            {
                int cp = 0, co = 0;
                int max = int.MinValue, maxs = 0;
                for(int i = 0; i < matrix.GetLength(0); i++)
                {
                    if (matrix[i, j] > 0) cp++;
                    else if (matrix[i, j] < 0) co++;
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                        maxs = i;
                    }
                }

                if (cp > co) matrix[maxs, j] = 0;
                else if (co > cp) matrix[maxs, j] = maxs;
            }
            

            // end

        }
        public void Task9(int[,] matrix)
        {
            if (matrix.Length == 0) return;
            if (matrix.GetLength(0) != matrix.GetLength(1)) return;
            // code here
            int cnt = 0;
            for (int i = 0; i < matrix.GetLength(1) * matrix.GetLength(1); i++)
            {
                int row = i / matrix.GetLength(1);
                int col = i % matrix.GetLength(1);
                if(row == 0 || row == matrix.GetLength(1) - 1 || col == 0 || col == matrix.GetLength(1) - 1)
                {
                    matrix[row, col] = 0;
                    cnt++;
                }
            }

            // end

        }
        public (int[] A, int[] B) Task10(int[,] matrix)
        {

            int[] A = null, B = null;
            if (matrix.GetLength(0) != matrix.GetLength(1) || matrix.Length == 0) return (A, B);
            // code here
            int n = matrix.GetLength(0);
            int lena = 0, lenb = 0;
            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j < n; j++)
                {
                    if (j >= i) lena++;
                    else lenb++;
                }
            }
            // end
            int[] a = new int[lena];
            int[] b = new int[lenb];
            int cnta = 0, cntb = 0;
            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j < n; j++)
                {
                    if (j >= i)
                    {
                        a[cnta++] = matrix[i, j];
                    }
                    else b[cntb++] = matrix[i, j];
                }
            }

            return (a, b);
        }
        public void Task11(int[,] matrix)
        {
            if (matrix.Length == 0) return;
            // code here
            int rows = matrix.GetLength(0);
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                int[] st = new int[rows];
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    st[i] = matrix[i, j];
                }
                if(j % 2 != 0)
                {
                    Array.Sort(st);
                }
                else
                {
                    Array.Sort(st, (a, b) => b.CompareTo(a));
                }
                for(int i = 0; i < rows; i++)
                {
                    matrix[i, j] = st[i];
                }
            }    

            // end

        }
        public void Task12(int[][] array)
        {
            if (array.Length == 0) return;
            // code here

            int[] l = new int[array.Length];
            int[] sums = new int[array.Length];
            for(int i = 0; i < array.Length; i++)
            {
                l[i] = array[i].Length;
                int sum = 0;
                for(int j = 0; j < l[i]; j++)
                {
                    sum += array[i][j];
                }
                sums[i] = sum;
            }
            for(int i = 0; i < array.Length; i++)
            {
                for(int j = 0; j < array.Length - 1 - i; j++)
                {
                    if (l[j] < l[j + 1] || (l[j] == l[j + 1] && sums[j] < sums[j + 1]))
                    {
                        (l[j], l[j + 1]) = (l[j + 1], l[j]);
                        (sums[j], sums[j + 1]) = (sums[j + 1], sums[j]);
                        (array[j], array[j + 1]) = (array[j + 1], array[j]);
                    }
                }
            }

            // end

        }
    }
}
