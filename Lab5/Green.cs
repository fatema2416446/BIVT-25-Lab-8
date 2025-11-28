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
            int k = 0;
            int n1 = matrix.GetLength(0);
            int n2 = matrix.GetLength(1);
            answer = new int[n1];
            for (int i = 0; i < n1; i++)
            {
                int min = matrix[i, 0];
                int minj = 0;
                for (int j = 0;j<n2; j++)
                {
                    if (matrix[i,j] < min)
                    {
                        min = matrix[i, j];
                        minj = j;
                    }
                }
                for (int j = 0; j < n2; j++)
                {
                    if (matrix[i, j] == min)
                    {
                        answer[k] = minj;
                        k++;
                        break;
                    }
                }
            }
            // end

            return answer;
        }
        public void Task2(int[,] matrix)
        {

            // code here
            int n1 = matrix.GetLength(0);
            int n2 = matrix.GetLength(1);

            for(int i = 0;i < n1; i++)
            {
                int max = matrix[i, 0];
                int maxj = 0;
                for(int j=1; j<n2; j++)
                {
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                        maxj = j;
                    }
                }


                for (int j=0; j < maxj; j++)
                {
                    if (max == 0)
                    {
                        break;
                    }
                    if(matrix[i, j] < 0)
                    {
                        matrix[i, j] = (int)Math.Floor((double)matrix[i, j] / max);
                    }

                }
            }
            // end

        }
        public void Task3(int[,] matrix, int k)
        {

            // code here
            int n1 = matrix.GetLength(0);
            int n2 = matrix.GetLength(1);

            if (n1 != n2 || k < 0 || k >= n1)
                return;
            int n = n1;

            int max = matrix[0, 0];
            int maxi = 0;
            for (int i = 0; i < n; i++)
            {
                if (max < matrix[i, i])
                {
                    max = matrix[i, i];
                    maxi = i;
                }
            }
            if (maxi != k)
            {
                for (int i = 0; i < n; i++)
                {
                    int temp = matrix[i, k];
                    matrix[i, k] = matrix[i, maxi];
                    matrix[i, maxi] = temp;
                }
            }
            // end

        }
        public void Task4(int[,] matrix)
        {

            // code here
            int n1 = matrix.GetLength(0);
            int n2 = matrix.GetLength(1);

            if (n1 != n2)
                return;
            int n = n1;

            int max = matrix[0, 0];
            int maxi = 0;
            for (int i = 1; i < n; i++)
            {
                if (matrix[i,i] > max)
                {
                    max = matrix[i, i];
                    maxi =i;
                }
            }
            for (int i = 0; i < n; i++)
            {
                if (i == maxi)
                {
                    for (int j = 0; j < n; j++)
                    {
                        (matrix[j, maxi], matrix[maxi, j]) = (matrix[maxi, j], matrix[j, maxi]);
                    }
                }

            }
            // end

        }
        public int[,] Task5(int[,] matrix)
        {
            int[,] answer = null;

            // code here
            int n1 = matrix.GetLength(0);
            int n2 = matrix.GetLength(1);

            answer = new int[n1 - 1, n2];

            int max = 0;
            int maxi = -1;
            for (int i = 0; i < n1; i++)
            {
                int maxs=0;

                for (int j=0; j < n2; j++)
                {
                    if (matrix[i,j] > 0)
                    {
                        maxs = matrix[i,j] + maxs;
                    }
                }
                if (maxs > max)
                {
                    max = maxs;
                    maxi = i;
                }
            }
            if (maxi != -1)
            {

                int t = 0;
                for (int i = 0; i < n1; i++)
                {
                    if (i == maxi)
                    {
                        continue;
                    }
                    for (int j = 0; j < n2; j++)
                    {
                        answer[t, j] = matrix[i, j];
                    }

                    t++;

                }
            }
            // end

            return answer;
        }
        public void Task6(int[,] matrix)
        {

            // code here
            int n1 = matrix.GetLength(0);
            int n2 = matrix.GetLength(1);

            int min=0, max=0;
            int current = 0;
            for (int j = 0; j < n2; j++)
            {
                if (matrix[0, j] < 0)
                {
                    current++;
                }
            }
            min = current;
            int mini = 0;
            max = current;
            int maxi = 0;
            for (int i = 0; i < n1; i++)
            {
                current = 0;
                for (int j = 0;j < n2; j++)
                {
                    if (matrix[i, j] < 0){
                        current++;
                    }
                }
                if (min > current)
                {
                    min = current;
                    mini = i;
                }
                if (max < current)
                {
                    max = current;
                    maxi = i;
                }
            }

            for (int j = 0; j < n2; j++)
            {
                (matrix[mini, j], matrix[maxi, j]) = (matrix[maxi, j], matrix[mini, j]);
            }
            // end

        }
        public int[,] Task7(int[,] matrix, int[] array)
        {
            int[,] answer = null;

            // code here
            int n1 = matrix.GetLength(0);
            int n2 = matrix.GetLength(1);

            int min = matrix[0, 0];
            int minj = 0;
            for (int i = 0; i < n1; i++)
            {
                for (int j = 0; j < n2; j++)
                {
                    if (matrix[i, j] < min)
                    {
                        min = matrix[i, j];
                        minj = j;
                    }
                }
            }
            if (n1 == array.Length)
            {


                answer = new int[n1, n2 + 1];
                int t = 0;
                for (int j = 0; j < n2; j++)
                {
                    for (int i = 0; i < n1; i++)
                    {
                        answer[i, t] = matrix[i, j];

                    }
                    t++;
                    if (j == minj)
                    {
                        for (int i = 0; i < n1; i++)
                        {
                            answer[i, t] = array[i];
                        }
                        t++;
                    }

                }
                if (minj == n2 - 1)
                {
                    for (int i = 0; i < n1; i++)
                    {
                        answer[i, n2] = array[i];
                    }
                }
            }
            else
            {
                answer = matrix;
            }
            // end

            return answer;
        }
        public void Task8(int[,] matrix)
        {

            // code here
            int n1 = matrix.GetLength(0);
            int n2 = matrix.GetLength(1);

            for (int j = 0; j < n2; j++)
            {
                int pos = 0;
                int otr = 0;
                int max = matrix[0, j];
                int maxi = 0;
                for (int i = 0; i < n1; i++)
                {
                    if (matrix[i,j] > 0)
                    {
                        pos++;
                    }
                    if (matrix[i, j] < 0)
                    {
                        otr++;
                    }
                    if (max < matrix[i, j])
                    {
                        max = matrix[i, j];
                        maxi = i;
                    }
                }
                if (pos > otr)
                {
                    matrix[maxi, j] = 0;
                }
                if (otr > pos)
                {
                    matrix[maxi, j] = maxi;
                }
            }
            // end

        }
        public void Task9(int[,] matrix)
        {

            // code here
            int n1 = matrix.GetLength (0);
            int n2 = matrix.GetLength (1);

            if (n1 != n2)
            {
                return;
            }
            int n = n1;
            int j = 0;
            for (int i = 0; i < n; i++)
            {

                matrix[i, 0] = 0;
                matrix[0, i] = 0;
                matrix[i, n-1] = 0;
                matrix[n-1, i] = 0;

            }
            // end

        }
        public (int[] A, int[] B) Task10(int[,] matrix)
        {
            int[] A = null, B = null;

            // code here
            int n1 = matrix.GetLength(0);
            int n2 = matrix.GetLength (1);

            if (n1 == n2) {
                int n = n1;
                A = new int[(n + 1) * n / 2];
                B = new int[n * (n - 1) / 2];
                int ta = 0;
                int tb = 0;
                for (int i = 0; i < n; i++)
                {

                    for (int j = 0; j < n; j++)
                    {
                        if (i <= j)
                        {
                            A[ta] = matrix[i, j];
                            ta++;
                        }
                        else
                        {
                            B[tb] = matrix[i, j];
                            tb++;
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
            int n1 = matrix.GetLength(0);
            int n2 = matrix.GetLength(1);

            for (int j=0;j<n2; j++)
            {

                if (j % 2 == 0)//четные
                {
                    int k = 0;
                    for(int i=0; i < n1-1; i++)
                    {
                        for (k=0; k<n1-i-1; k++)
                        {
                            if (matrix[k,j] < matrix[k + 1,j])
                            {
                                (matrix[k, j], matrix[k + 1, j]) = (matrix[k + 1, j], matrix[k, j]);
                            }
                        }
                    }
                }
                else//нечетные
                {
                    int k = 0;
                    for (int i = 0; i < n1 -1; i++)
                    {
                        for (k = 0; k < n1 - i- 1; k++)
                        {
                            if (matrix[k, j] > matrix[k + 1, j])
                            {
                                (matrix[k, j], matrix[k + 1, j]) = (matrix[k + 1, j], matrix[k, j]);
                            }
                        }
                    }
                }
            }
            // end

        }
        public void Task12(int[][] array)
        {

            // code here
            int n = array.Length;

            for (int i = 0; i < n-1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (array[j].Length < array[j + 1].Length)
                    {

                        (array[j], array[j + 1]) = (array[j + 1], array[j]);

                    }
                    if (array[j].Length == array[j + 1].Length)
                    {
                        int sum1 = 0;
                        int sum2 = 0;
                        for(int k=0;k< array[j].Length;k++){
                            sum1 += array[j][k];
                        }
                        for (int k = 0; k < array[j+1].Length; k++)
                        {
                            sum2 += array[j+1][k];
                        }
                        if (sum1 < sum2)
                        {
                            (array[j], array[j + 1]) = (array[j + 1], array[j]);
                        }


                    }
                }
            }
            // end

        }
    }
}
