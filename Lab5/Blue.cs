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
            double[] a = new double[matrix.GetLength(0)];
            double sum = 0;
            int counter = 0;
            int cnt = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                    if (matrix[i, j] > 0)
                    {
                        sum += matrix[i, j];
                        cnt++;
                    }
                if (cnt != 0)
                    a[counter++] = sum / cnt;
                else
                {
                    a[counter++] = 0;
                }
                sum = 0;
                cnt = 0;
            }

            answer = a;
            // end

            return answer;
        }
        public int[,] Task2(int[,] matrix)
        {
            int[,] answer = null;

            // code here
            int mx = int.MinValue;
            int str = 0;
            int st = 0;
            if (matrix.GetLength(1) == 0 || matrix.GetLength(0) == 0)
            {
                return null;
            }
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > mx)
                    {
                        mx = matrix[i, j];
                        str = i;
                        st = j;
                    }
                }
            }
            
            int[,] a = new int[matrix.GetLength(0) - 1, matrix.GetLength(1)];
            for (int i = 0; i < matrix.GetLength(0) - 1; i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (i < str)
                        a[i, j] = matrix[i, j];
                    if (i >= str)
                    {
                        a[i, j] = matrix[i + 1, j];
                    }
                }
            }
            
            int[,] b = new int[a.GetLength(0), a.GetLength(1) - 1];
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1) - 1; j++)
                {
                    if (j < st)
                        b[i, j] = a[i, j];
                    if (j >= st)
                    {
                        b[i, j] = a[i, j + 1];
                    }
                }
            }

            
            // end

            return b;
        }
        public void Task3(int[,] matrix)
        {

            // code here
            int cnt = 0;
            if (matrix.GetLength(1) == 1)
                return;
            int[] mx = new int[matrix.GetLength(0)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int mx_line = matrix[i, 0];
                int ind = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > mx_line)
                    {
                        mx_line = matrix[i, j];
                        ind = j;
                    }
                        
                }
                mx[cnt++] = ind;
            }
            int[,] answer = new int[matrix.GetLength(0), matrix.GetLength(1)];
            cnt = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1) - 1; j++)
                {
                    if (j < mx[cnt])
                    {
                        answer[i, j] = matrix[i, j];
                    }
                    if (j >= mx[cnt])
                    {
                        answer[i, j] = matrix[i, j + 1];
                    }
                }
                answer[i, matrix.GetLength(1) - 1] = matrix[i, mx[cnt++]];
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = answer[i, j];
                }
            }
            // end

        }
        public int[,] Task4(int[,] matrix)
        {

            // code here
            int[] mx = new int[matrix.GetLength(0)];
            int cnt = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int mx_line = matrix[i, 0];
                int ind = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > mx_line)
                    {
                        mx_line = matrix[i, j];
                        ind = j;
                    }
                }
                mx[cnt++]  = ind;
            }

            cnt = 0;
            int[,] answer = new int[matrix.GetLength(0), matrix.GetLength(1) + 1];
            if (matrix.GetLength(1) == 1)
            {
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        answer[i, j] = matrix[i, j];
                    }
                    answer[i,  answer.GetLength(1) - 1] = matrix[i, matrix.GetLength(1) - 1];
                }
            }
            else
            {
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1) - 1; j++)
                    {
                        answer[i, j] = matrix[i, j];
                    }

                    answer[i, answer.GetLength(1) - 2] = matrix[i, mx[cnt++]];
                    answer[i, answer.GetLength(1) - 1] = matrix[i, matrix.GetLength(1) - 1];
                }
            }
            // end

            return answer;
        }
        public int[] Task5(int[,] matrix)
        {
            int[] answer = null;
            // code here
            int cnt = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if ((i + j) % 2 == 1)
                        cnt++;
                }
            }
            int[] a = new int[cnt];
            cnt = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if ((i + j) % 2 == 1)
                        a[cnt++] = matrix[i, j];
                }
            }
            // end

            return a;
        }
        public void Task6(int[,] matrix, int k)
        {

            // code here
            if (k < 0 || k >= matrix.GetLength(1) || matrix.GetLength(1) != matrix.GetLength(0))
                return;
            int cnt = -1;
            int mx = matrix[0, 0];
            int ind = 0;
            
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, k] < 0)
                {
                    cnt = i;
                    break;
                }
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, i] > mx)
                {
                    mx = matrix[i, i];
                    ind = i;
                }
            }

            if (cnt == -1 || cnt == ind)
                return;

            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                (matrix[ind, i], matrix[cnt, i]) = (matrix[cnt, i], matrix[ind, i]);
            }
            // end

        }
        public void Task7(int[,] matrix, int[] array)
        {

            // code here
            int ind = 0;
            if (matrix.GetLength(1) <= 2 || matrix.GetLength(1) != array.Length)
                return;
            int mx = matrix[0, matrix.GetLength(1) - 2];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, matrix.GetLength(1) - 2] > mx)
                {
                    mx = matrix[i, matrix.GetLength(1) - 2];
                    ind = i;
                }
            }

            int cnt = 0;
            for  (int j = 0; j < matrix.GetLength(1); j++)
                matrix[ind, j] =  array[cnt++];
            // end

        }
        public void Task8(int[,] matrix)
        {

            // code here
            if (matrix.GetLength(0) == 0)
                return;
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                int mx = int.MinValue;
                int str = -1;
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    if (matrix[i, j] > mx)
                    {
                        mx = matrix[i, j];
                        str = i;
                    }
                }

                if (str < matrix.GetLength(0) / 2)
                {
                    int su = 0;
                    for (int k = str + 1; k < matrix.GetLength(0); k++)
                    {
                        su += matrix[k, j];
                    }
                    matrix[0, j] = su;
                }
                else
                {
                    continue;
                }
            }
            // end

        }
        public void Task9(int[,] matrix)
        {

            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
    
            if (rows <= 1) return;
    
            for (int i = 0; i < rows - 1; i += 2)
            {
                int maxRow1 = matrix[i, 0];
                int colMax1 = 0;
                for (int j = 1; j < cols; j++)
                {
                    if (matrix[i, j] > maxRow1)
                    {
                        maxRow1 = matrix[i, j];
                        colMax1 = j;
                    }
                }
        
                int maxRow2 = matrix[i + 1, 0];
                int colMax2 = 0;
                for (int j = 1; j < cols; j++)
                {
                    if (matrix[i + 1, j] > maxRow2)
                    {
                        maxRow2 = matrix[i + 1, j];
                        colMax2 = j;
                    }
                }
        
                matrix[i, colMax1] = maxRow2;
                matrix[i + 1, colMax2] = maxRow1;
            }
        }
        public void Task10(int[,] matrix)
        {

            // code here
            if (matrix.GetLength(1) != matrix.GetLength(0))
                return;
            int mx = int.MinValue;
            int ind = -1;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, i] > mx)
                {
                    mx = matrix[i, i];
                    ind = i;
                }
            }

            for (int i = 0; i < ind; i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (j > i)
                    {
                        matrix[i, j] = 0;
                    }
                }
            }
            // end
        }
        public void Task11(int[,] matrix)
        {
    
            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            if (rows <= 1) return;
            int[] plus = new int[rows];
            for (int i = 0; i < rows; i++)
            {
                int cnt = 0;
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        cnt++;
                    }
                }
                plus[i] = cnt;
            }
            int[,] answer = new int[rows, cols];
            for (int l = 0; l < rows; l++)
            {
                int mx = int.MinValue;
                int ind = -1;
                for (int i = 0; i < plus.Length; i++)
                {
                    if (plus[i] > mx)
                    {
                        mx = plus[i];
                        ind = i;
                    }
                }

                for (int c = 0; c < cols; c++)
                {
                    answer[l, c] = matrix[ind, c];
                }

                plus[ind] = -1;
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = answer[i, j];
                }
            }
            // end

        }
        public int[][] Task12(int[][] array)
        {
            if (array == null || array.Length == 0)
                return array;

            double totalSum = 0;
            int totalCount = 0;
    
            foreach (int[] row in array)
            {
                if (row != null)
                {
                    foreach (int num in row)
                    {
                        totalSum += num;
                    }
                    totalCount += row.Length;
                }
            }
    
            if (totalCount == 0) 
                return new int[0][];
    
            double totalAverage = totalSum / totalCount;

            int countToKeep = 0;
            foreach (int[] row in array)
            {
                if (row != null && row.Length > 0)
                {
                    double rowSum = 0;
                    foreach (int num in row)
                    {
                        rowSum += num;
                    }
                    if (rowSum / row.Length >= totalAverage)
                    {
                        countToKeep++;
                    }
                }
            }

            int[][] result = new int[countToKeep][];
            int index = 0;
    
            foreach (int[] row in array)
            {
                if (row != null && row.Length > 0)
                {
                    double rowSum = 0;
                    foreach (int num in row)
                    {
                        rowSum += num;
                    }
                    if (rowSum / row.Length >= totalAverage)
                    {
                        result[index++] = row;
                    }
                }
            }

            return result;
        }
    }
}