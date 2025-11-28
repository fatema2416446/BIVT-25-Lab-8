using System.Linq;
using System.Runtime.InteropServices;

namespace Lab5
{
    public class Green
    {
        public int[] Task1(int[,] matrix)
        {
            int[] answer;

            // code here
            answer = new int[matrix.GetLength(0)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int minIndex = 0;
                for (int j = 1; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < matrix[i, minIndex])
                    {
                        minIndex = j;
                    }
                }
                answer[i] = minIndex;
            }
            // end

            return answer;
        }
        public void Task2(int[,] matrix)
        {

            // code here
            int stolbech = matrix.GetLength(0);
            int stroka = matrix.GetLength(1);
            for (int i = 0; i < stolbech; i++)
            {
                int maxIndex = 0;
                int maxValue = matrix[i, 0];
                for (int j = 1; j < stroka; j++)
                {
                    if (matrix[i, j] > maxValue)
                    {
                        maxValue = matrix[i, j];
                        maxIndex = j;
                    }
                }
                for (int j = 0; j < maxIndex; j++)
                {
                    if (matrix[i, j] < 0)
                    {
                        matrix[i, j] = (int)Math.Floor((double)matrix[i, j] / maxValue);
                    }
                }
            }
            // end

        }
        public void Task3(int[,] matrix, int k)
        {
            if (matrix.GetLength(0) == matrix.GetLength(1) && k < matrix.GetLength(1))
            {
                int maxI = 0, max = 0;
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    int j = i;
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                        maxI = i;
                    }
                }
                if (maxI != k)
                {
                    for (int i = 0; i < matrix.GetLength(0); i++)
                    {
                        (matrix[i, k], matrix[i, maxI]) = (matrix[i, maxI], matrix[i, k]);
                    }
                }
            }
        }
        // end
        public void Task4(int[,] matrix)
        {

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            if (n == m)
            {
                int ma = int.MinValue, mak = -1;
                for (int i = 0; i < n; i++)
                {
                    if (matrix[i, i] > ma)
                    {
                        ma = matrix[i, i];
                        mak = i;
                    }
                }
                for (int i = 0; i < n; i++)
                {
                    (matrix[i, mak], matrix[mak, i]) = (matrix[mak, i], matrix[i, mak]);
                }
            }
            // end
        }
        public int[,] Task5(int[,] matrix)
        {
            int[,] answer = null;

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            answer = new int[n - 1, m];
            int s = 0, s1 = 0, sk = -1;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        s1 += matrix[i, j];
                    }
                }
                if (s1 > s)
                {
                    s = s1;
                    sk = i;
                }
                s1 = 0;
            }
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (i < sk)
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
            // code here
            int stroka = matrix.GetLength(0);
            int stolbec = matrix.GetLength(1);
            if (stroka == 0) return;
            int[] negativeCounts = new int[stroka];
            for (int i = 0; i < stroka; i++)
            {
                int count = 0;
                for (int j = 0; j < stolbec; j++)
                {
                    if (matrix[i, j] < 0)
                    {
                        count++;
                    }
                }
                negativeCounts[i] = count;
            }

            int minIndex = 0;
            int maxIndex = 0;
            int minCount = negativeCounts[0];
            int maxCount = negativeCounts[0];
            for (int i = 1; i < stroka; i++)
            {
                if (negativeCounts[i] < minCount)
                {
                    minCount = negativeCounts[i];
                    minIndex = i;
                }
                if (negativeCounts[i] > maxCount)
                {
                    maxCount = negativeCounts[i];
                    maxIndex = i;
                }
            }
            if (minCount != maxCount)
            {
                for (int j = 0; j < stolbec; j++)
                {
                    int temp = matrix[minIndex, j];
                    matrix[minIndex, j] = matrix[maxIndex, j];
                    matrix[maxIndex, j] = temp;
                }
            }
            // end

        }
        public int[,] Task7(int[,] matrix, int[] array)
        {
            int[,] answer = null;

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            int minibro = int.MaxValue;
            int minibroStolbech = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] < minibro)
                    {
                        minibro = matrix[i, j];
                        minibroStolbech = j;
                    }
                }
            }
            if (array.Length == n)
            {
                answer = new int[n, m + 1];
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m + 1; j++)
                    {
                        if (j <= minibroStolbech)
                        {
                            answer[i, j] = matrix[i, j];
                        }
                        else if (j == minibroStolbech + 1)
                        {
                            answer[i, j] = array[i];
                        }
                        else
                        {
                            answer[i, j] = matrix[i, j - 1];
                        }
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
            int stroka = matrix.GetLength(0);
            int stolbec = matrix.GetLength(1);
            for (int j = 0; j < stolbec; j++)
            {
                int SchetDobrix = 0;
                int SchetZlix = 0;
                int maxchislo = matrix[0, j];
                int maxIndex = 0;
                for (int i = 0; i < stroka; i++)
                {
                    if (matrix[i, j] > 0) SchetDobrix++;
                    else if (matrix[i, j] < 0) SchetZlix++;
                    if (matrix[i, j] > maxchislo)
                    {
                        maxchislo = matrix[i, j];
                        maxIndex = i;
                    }
                }
                if (SchetDobrix > SchetZlix)
                {
                    matrix[maxIndex, j] = 0;
                }
                else if (SchetZlix > SchetDobrix)
                {
                    matrix[maxIndex, j] = maxIndex;
                }
            }
            // end

        }
        public void Task9(int[,] matrix)
        {

            // code here
            if (matrix.GetLength(0) != matrix.GetLength(1))
                return;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                matrix[0, i] = 0;
                matrix[i, 0] = 0;
                matrix[matrix.GetLength(0) - 1, i] = 0;
                matrix[i, matrix.GetLength(0) - 1] = 0;
            }
            // end

        }
        public (int[] A, int[] B) Task10(int[,] matrix)
        {
            int[] A = null, B = null;

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            int k = 0, c = 0, k1 = 0, c1 = 0;
            if (n == m)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        if (j - i > -1)
                        {
                            k++;
                        }
                        else
                        {
                            c++;
                        }
                    }
                }
                A = new int[k];
                B = new int[c];
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        if (j - i > -1)
                        {
                            A[k1] = matrix[i, j];
                            k1++;
                        }
                        else
                        {
                            B[c1] = matrix[i, j];
                            c1++;
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
            int stroka = matrix.GetLength(0);
            int stolbec = matrix.GetLength(1);
            for (int j = 0; j < stolbec; j++)
            {

                if (j % 2 == 0)
                {
                    for (int i = 0; i < stroka - 1; i++)
                    {
                        for (int k = 0; k < stroka - 1 - i; k++)
                        {
                            if (matrix[k, j] < matrix[k + 1, j])
                            {
                                int temp = matrix[k, j];
                                matrix[k, j] = matrix[k + 1, j];
                                matrix[k + 1, j] = temp;
                            }
                        }
                    }
                }

                else
                {
                    for (int i = 0; i < stroka - 1; i++)
                    {
                        for (int k = 0; k < stroka - 1 - i; k++)
                        {
                            if (matrix[k, j] > matrix[k + 1, j])
                            {
                                int temp = matrix[k, j];
                                matrix[k, j] = matrix[k + 1, j];
                                matrix[k + 1, j] = temp;
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
            if (array == null || array.Length == 0) return;
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = 0; j < array.Length - 1 - i; j++)
                {
                    int length1;
                    int length2;
                    if (array[j] != null)
                    {
                        length1 = array[j].Length;
                    }
                    else
                    {
                        length1 = 0;
                    }
                    if (array[j + 1] != null)
                    {
                        length2 = array[j + 1].Length;
                    }
                    else
                    {
                        length2 = 0;
                    }
                    if (length1 < length2)
                    {
                        int[] temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                    else if (length1 == length2 && length1 > 0)
                    {
                        int sum1 = 0;
                        int sum2 = 0;
                        for (int k = 0; k < length1; k++)
                        {
                            sum1 += array[j][k];
                        }
                        for (int k = 0; k < length2; k++)
                        {
                            sum2 += array[j + 1][k];
                        }
                        if (sum1 < sum2)
                        {
                            int[] temp = array[j];
                            array[j] = array[j + 1];
                            array[j + 1] = temp;
                        }
                    }
                }
            }
            // end

        }
    }
}
