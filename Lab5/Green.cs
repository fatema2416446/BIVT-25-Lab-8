using System.ComponentModel.DataAnnotations.Schema;
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
            answer = new int[matrix.GetLength(0)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int min = int.MaxValue;
                int min1 = -1;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < min)
                    {
                        min = matrix[i, j];
                        min1 = j;
                    }
                }
                answer[i] = min1;
            }
            // end

            return answer;
        }
        public void Task2(int[,] matrix)
        {

            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            for (int i = 0; i < rows; i++)
            {
                int maxindex = 0;
                int maxvalue = matrix[i, 0];
                for (int j = 1; j < cols; j++)
                {
                    if (matrix[i, j] > maxvalue)
                    {
                        maxvalue = matrix[i, j];
                        maxindex = j;
                    }
                }
                for (int j = 0; j < maxindex; j++)
                {
                    if (matrix[i, j] < 0)
                    {
                        matrix[i, j] = (int)Math.Floor((double)matrix[i, j] / maxvalue);
                    }
                }
            }
            // end

        }
        public void Task3(int[,] matrix, int k)
        {

            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            if (rows == cols && k < cols)
            {
                int maxi = 0;
                int max = 0;
                for (int i = 0; i < rows; i++)
                {
                    int j = i;
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                        maxi = i;
                    }
                }
                if (maxi != k)
                {
                    for (int i = 0; i < rows; i++)
                    {
                        (matrix[i, k], matrix[i, maxi]) = (matrix[i, maxi], matrix[i, k]);
                    }
                }


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
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            int str = -1, maxs = 0;
            for (int i = 0; i < rows; i++)
            {
                int s = 0;
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] > 0)
                        s += matrix[i, j];
                }
                if (s > maxs)
                {
                    maxs = s;
                    str = i;
                }
            }
            answer = new int[rows - 1, cols];
            for (int i = 0; i < answer.GetLength(0); i++)
            {
                for (int j = 0; j < answer.GetLength(1); j++)
                {
                    if (i < str)
                        answer[i, j] = matrix[i, j];
                    else
                        answer[i, j] = matrix[i + 1, j];
                }
            }
            // end

            return answer;
        }
        public void Task6(int[,] matrix)
        {

            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            if (rows <= 1)
                return;
            int minnegc = cols + 1;
            int maxnegc = -1;
            int minrowind = -1;
            int maxrowind = -1;
            for (int i = 0; i < rows; i++)
            {
                int negc = 0;
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] < 0)
                        negc++;
                }
                if (negc < minnegc)
                {
                    minnegc = negc;
                    minrowind = i;
                }
                if (negc > maxnegc)
                {
                    maxnegc = negc;
                    maxrowind = i;
                }
            }
            if (minnegc == maxnegc)
                return;
            for (int j = 0; j < cols; j++)
            {
                int x = matrix[minrowind, j];
                matrix[minrowind, j] = matrix[maxrowind, j];
                matrix[maxrowind, j] = x;
            }
            // end

        }
        public int[,] Task7(int[,] matrix, int[] array)
        {
            int[,] answer = null;

            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            if (array.Length != rows)
            {
                return matrix;
            }

            int min = int.MaxValue;
            int str = -1;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] < min)
                    {
                        min = matrix[i, j];
                        str = j;
                    }
                }
            }
            answer = new int[rows, cols + 1];
            for (int i = 0; i < answer.GetLength(0); i++)
            {
                for (int j = 0; j < answer.GetLength(1); j++)
                {
                    if (j <= str)
                    {
                        answer[i, j] = matrix[i, j];
                    }
                    else if (j == str + 1)
                    {
                        answer[i, j] = array[i];
                    }
                    else
                    {
                        answer[i, j] = matrix[i, j - 1];
                    }
                }
            }
            // end

            return answer;
        }
        public void Task8(int[,] matrix)
        {

            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            for (int j = 0; j < cols; j++)
            {
                int poz = 0;
                int neg = 0;
                int maxvalue = matrix[0, j];
                int maxind = 0;
                for (int i = 0; i < rows; i++)
                {
                    if (matrix[i, j] > 0)
                        poz++;
                    else if (matrix[i, j] < 0)
                        neg++;
                    if (matrix[i, j] > maxvalue)
                    {
                        maxvalue = matrix[i, j];
                        maxind = i;
                    }
                }
                if (poz > neg)
                    matrix[maxind, j] = 0;
                else if (neg > poz)
                    matrix[maxind, j] = maxind;
            }
            // end

        }
        public void Task9(int[,] matrix)
        {

            // code here
            int rows= matrix.GetLength(0);
            int cols= matrix.GetLength(1);
            if (rows != cols)
                return;
            for(int i = 0; i < rows * rows; i++)
            {
                int x = i / rows;
                int k = i % rows;
                if(x==0|| x == rows - 1 || k == 0 || k == rows - 1)
                {
                    matrix[x, k] = 0;
                }
            }
            // end

        }
        public (int[] A, int[] B) Task10(int[,] matrix)
        {
            int[] A = null, B = null;

            // code here
            int rows= matrix.GetLength(0);
            int cols=matrix.GetLength(1);
            if (rows!=cols)
                return(A, B);
            int ca = 0;
            int cb = 0;
            for(int i=0;i<rows;i++)
            {
                for(int j = 0; j < cols; j++)
                {
                    if (i <= j)
                        ca++;
                    else
                        cb++;
                }
            }
            A= new int[ca];
            B = new int[cb];
            int iA = 0;
            int iB = 0;
            for(int i = 0; i < rows; i++)
            {
                for(int j=0; j < cols; j++)
                {
                    if (i <= j)
                    {
                        A[iA++] = matrix[i,j];
                    }
                    else
                    {
                        B[iB++] = matrix[i,j];
                    }
                }
            }
            // end

            return (A, B);
        }
        public void Task11(int[,] matrix)
        {

            // code here
            int rows=matrix.GetLength(0);
            int cols= matrix.GetLength(1);
            for(int j = 0; j < cols; j++)
            {
                int[]nov=new int[rows];
                for(int i = 0; i < rows; i++)
                {
                    nov[i] = matrix[i,j];
                }
                if (j % 2 == 0)
                {
                    for(int i = 0; i < rows - 1; i++)
                    {
                        for(int k = i+1; k < rows ; k++)
                        {
                            if (nov[i] < nov[k])
                            {
                                int ans = nov[i];
                                nov[i] = nov[k];
                                nov[k] = ans;
                            }
                        }
                    }
                }
                else
                {
                    for(int i = 0; i < rows - 1; i++)
                    {
                        for(int k = i + 1; k < rows; k++)
                        {
                            if (nov[i] > nov[k])
                            {
                                int ans = nov[i];
                                nov[i]=nov[k];
                                nov[k]=ans;
                            }
                        }
                    }
                }
                for(int i = 0; i < rows; i++)
                {
                    matrix[i, j] = nov[i];
                }
            }
            // end

        }
        public void Task12(int[][] array)
        {

            // code here
            for(int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length - 1 - i; j++)
                {
                    if (array[j].Length < array[j + 1].Length)
                    {
                        (array[j], array[j + 1]) = (array[j + 1], array[j]);
                    }
                    if (array[j].Length == array[j + 1].Length)
                    {
                        int s = 0;
                        int s1 = 0;
                        for(int k=0;k<array[j].Length; k++)
                        {
                            s += array[j][k];
                            s1 += array[j + 1][k];
                        }
                        if (s1 > s)
                        {
                            (array[j], array[j + 1]) = (array[j+1], array[j]);
                        }
                    }
                }
            }
            // end

        }
    }
}