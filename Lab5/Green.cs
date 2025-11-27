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
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < min)
                    {
                        min = matrix[i, j];
                        answer[i] = j;
                    }
                }
                
            }
            // end

            return answer;
        }
        public void Task2(int[,] matrix)
        {

            // code here
            int[] maxind = new int[matrix.GetLength(0)];
            int[] maxs = new int[matrix.GetLength(0)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int max = int.MinValue;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                        maxind[i] = j;
                        maxs[i] = max;
                    }
                }
            }
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < maxind[i]; j++)
                {
                    if (matrix[i, j] < 0)
                    {
                        matrix[i, j] = (int)Math.Floor((double)matrix[i, j] / maxs[i]);
                    }
                }
            }
            // end

        }
        public void Task3(int[,] matrix, int k)
        {

            // code here
            if (matrix.GetLength(1) != matrix.GetLength(0))
                return;
            int ind = -1;
            int max = int.MinValue;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, i] > max)
                {
                    max = matrix[i, i];
                    ind = i;
                }
            }
            if (k >= 0 && k < matrix.GetLength(1) && ind != -1)
            {
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    (matrix[i, k], matrix[i, ind]) = (matrix[i, ind], matrix[i, k]);
                }
            }
        }
        public void Task4(int[,] matrix)
        {

            // code here
            if (matrix.GetLength(1) != matrix.GetLength(0))
                return;
            int max = int.MinValue;
            int ind = -1;
            for (int i=0; i<matrix.GetLength(0); i++)
            {
                if (matrix[i, i] > max)
                {
                    max = matrix[i, i];
                    ind = i;
                }
            }
            for (int i=0; i<matrix.GetLength(1); i++)
            {
                (matrix[i, ind], matrix[ind, i]) = (matrix[ind, i], matrix[i, ind]);
            }
            // end

        }
        public int[,] Task5(int[,] matrix)
        {
            int[,] answer = null;

            // code here
            int ind = 0;
            int s = 0;
            for (int i=0; i<matrix.GetLength(0);i++)
            {
                int curs = 0;
                for (int j=0; j<matrix.GetLength(1);j++)
                {
                    if (matrix[i, j] > 0)
                        curs += matrix[i, j];
                }
                if (curs>s)
                {
                    s= curs;
                    ind = i;
                }
            }
            answer=new int[matrix.GetLength(0)-1, matrix.GetLength(1)];
            for (int i = 0; i < answer.GetLength(0); i++)
            {
                if (i < ind)
                {
                    for (int j = 0; j < answer.GetLength(1); j++)
                        answer[i, j] = matrix[i, j];
                }
                else
                {
                    for (int j = 0; j < answer.GetLength(1); j++)
                        answer[i, j] = matrix[i + 1, j];
                }
            }
            // end

            return answer;
        }
        public void Task6(int[,] matrix)
        {

            // code here
            int maxotr = int.MinValue;
            int imaxotr = -1;
            int iminotr = -1;
            int minotr = int.MaxValue;
            for (int i=0; i<matrix.GetLength (0); i++)
            {
                int k = 0;
                for (int j=0; j<matrix.GetLength (1); j++)
                {
                    if (matrix[i, j] < 0)
                        k++;
                }
                if (k>maxotr)
                {
                    maxotr = k;
                    imaxotr = i;
                }
                if (k < minotr)
                {
                    minotr = k;
                    iminotr = i;
                }
            }
            if (maxotr != minotr)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    (matrix[imaxotr, j], matrix[iminotr, j]) = (matrix[iminotr, j], matrix[imaxotr, j]);
                }
            }
            // end

        }
        public int[,] Task7(int[,] matrix, int[] array)
        {
            int[,] answer = null;

            // code here
            if (array.Length != matrix.GetLength(0))
            {
                return matrix;
            }
            int min = int.MaxValue;
            int jmin = -1;
            for (int i=0; i<matrix.GetLength(0);i++)
            {
                for (int j=0; j<matrix.GetLength(1);j++)
                {
                    if (matrix [i, j] < min)
                    {
                        min=matrix [i, j];
                        jmin = j;
                    }
                }
            }
            answer=new int[matrix.GetLength(0), matrix.GetLength(1)+1];
            for (int i = 0; i < answer.GetLength(0); i++)
            {
                for (int j = 0; j < answer.GetLength(1); j++)
                {
                    if (j <= jmin)
                        answer[i, j] = matrix[i, j];
                    else if (j == jmin+1)
                        answer[i, j] = array[i];
                    else
                        answer[i, j] = matrix[i, j-1];
                }
            }
            // end

            return answer;
        }
        public void Task8(int[,] matrix)
        {

            // code here
            for (int j=0; j<matrix.GetLength(1);j++)
            {
                int kpol = 0;
                int kotr = 0;
                int max = int.MinValue;
                for (int i=0; i<matrix.GetLength (0);i++)
                {
                    if (matrix[i, j] < 0)
                        kotr++;
                    if (matrix[i, j] > 0)
                        kpol++;
                }
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    if (matrix[i, j]>max)
                    {
                        max = matrix[i, j];
                    }
                }
                if (kpol>kotr)
                {
                    for (int i = 0; i < matrix.GetLength(0); i++)
                    {
                        if (matrix[i, j] == max)
                        {
                            matrix[i, j]=0;
                            break;
                        }
                    }
                }
                if (kpol < kotr)
                {
                    for (int i = 0; i < matrix.GetLength(0); i++)
                    {
                        if (matrix[i, j] == max)
                        {
                            matrix[i, j] = i;
                            break;
                        }
                    }
                }
            }
            // end

        }
        public void Task9(int[,] matrix)
        {

            // code here
            if (matrix.GetLength(0) != matrix.GetLength(1))
                return;
            int size = matrix.GetLength(0);
            for (int i = 0; i < size * size; i++)
            {
                int row = i / size;
                int col = i % size;
                if (row == 0 || row == size - 1 || col == 0 || col == size - 1)
                {
                    matrix[row, col] = 0;
                }
            }
            // end

        }
        public (int[] A, int[] B) Task10(int[,] matrix)
        {
            int[] A = null, B = null;

            // code here
            if (matrix.GetLength(0) == matrix.GetLength(1))
            {
                int countA = 0, countB = 0;
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = i; j < matrix.GetLength(0); j++)
                        countA++;
                    for (int j = 0; j < i; j++)
                        countB++;
                }
                A = new int[countA];
                B = new int[countB];
                int indA = 0;
                int indB = 0;
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(0); j++)
                    {
                        if (j >= i)
                        {
                            A[indA] = matrix[i, j];
                            indA++;
                        }
                        else
                        {
                            B[indB] = matrix[i, j];
                            indB++;
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
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                int[] a = new int[matrix.GetLength(0)];
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    a[i] = matrix[i, j];
                }
                if (j % 2 == 0)
                {
                    for (int i = 0; i < matrix.GetLength(0) - 1; i++)
                    {
                        for (int k = 0; k < matrix.GetLength(0) - i -1; k++)
                        {
                            if (a[k] < a[k+1])
                                (a[k], a[k+1]) = (a[k + 1], a[k]);
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < matrix.GetLength(0) - 1; i++)
                    {
                        for (int k = 0; k < matrix.GetLength(0) - i - 1; k++)
                        {
                            if (a[k] > a[k + 1])
                                (a[k], a[k + 1]) = (a[k + 1], a[k]);
                        }
                    }
                }
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    matrix[i, j] = a[i];
                }
            }
            // end

        }
        public void Task12(int[][] array)
        {

            // code here
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length - 1 - i; j++)
                {
                    if (array[j].Length < array[j + 1].Length)
                        (array[j], array[j + 1]) = (array[j + 1], array[j]);
                    if (array[j].Length == array[j + 1].Length)
                    {
                        int s1 = 0;
                        int s2 = 0;
                        for (int l=0; l < array[j].Length; l++)
                        {
                            s1 += array[j][l];
                            s2 += array[j + 1][l];
                        }
                        if (s2 > s1)
                            (array[j], array[j + 1]) = (array[j + 1], array[j]);
                    }
                }
            }
            // end

        }
    }
}