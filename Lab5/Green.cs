using System.Linq;
using System.Runtime.InteropServices;

namespace Lab5
{
    public class Green
    {
        public int[] Task1(int[,] matrix)
        {
            int[] answer = new int[matrix.GetLength(0)];

            // code here
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
            int stolb = matrix.GetLength(0);
            int strok = matrix.GetLength(1);
            for (int i = 0; i < stolb; i++)
            {
                int max = matrix[i, 0];
                int maxj = 0;
                for (int j = 1; j < strok; j++)
                {
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                        maxj = j;
                    }
                }
                for (int j = 0; j < maxj; j++)
                {
                    if (matrix[i, j] < 0)
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
            int stolb = matrix.GetLength(0);
            int strok = matrix.GetLength(1);

            if (stolb != strok || k < 0 || k >= stolb)
                return;
            int n = stolb;

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
            int stolb = matrix.GetLength(0);
            if (stolb != matrix.GetLength(1))
            {
                return;
            }

            int maxDiagonalValue = matrix[0, 0];
            int maxIndex = 0;

            for (int i = 1; i < stolb; i++)
            {
                if (matrix[i, i] > maxDiagonalValue)
                {
                    maxDiagonalValue = matrix[i, i];
                    maxIndex = i;
                }
            }

            for (int i = 0; i < stolb; i++)
            {
                if (i != maxIndex)
                {
                    int temp = matrix[maxIndex, i];
                    matrix[maxIndex, i] = matrix[i, maxIndex];
                    matrix[i, maxIndex] = temp;
                }
            }
            // end

        }
        public int[,] Task5(int[,] matrix)
        {

            // code here
             int stolb = matrix.GetLength(0);
            int stroc = matrix.GetLength(1);
            
            int maxSum = -1;
            int maxSumstolb = -1;
            
            for (int i = 0; i < stolb; i++)
            {
                int sum = 0;
                for (int j = 0; j < stroc; j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        sum += matrix[i, j];
                    }
                }
                
                if (sum > maxSum)
                {
                    maxSum = sum;
                    maxSumstolb = i;
                }
            }
            
            if (maxSumstolb == -1) return matrix;
            
            int[,] answer = new int[stolb - 1, stroc];
            int newstolb = 0;
            
            for (int i = 0; i < stolb; i++)
            {
                if (i != maxSumstolb)
                {
                    for (int j = 0; j < stroc; j++)
                    {
                        answer[newstolb, j] = matrix[i, j];
                    }
                    newstolb++;
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
            if (array.Length != matrix.GetLength(0))
                return matrix;

            int min = Int32.MaxValue, minIndex = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < min)
                    {
                        min = matrix[i, j];
                        minIndex = j;
                    }
                }
            }

            answer = new int[matrix.GetLength(0), matrix.GetLength(1) + 1];

            int matrixI = 0;
            for (int i = 0; i < answer.GetLength(0); i++)
            {
                int matrixJ = 0;
                for (int j = 0; j < answer.GetLength(1); j++)
                {
                    if (j == minIndex + 1)
                        answer[i, j] = array[i];
                    else
                        answer[i, j] = matrix[matrixI, matrixJ++];
                }
                matrixI++;
            }
            // end

            return answer;
        }
        public void Task8(int[,] matrix)
        {

            // code here
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                int pn = 0, mn = 0, max = int.MinValue, imax = 0;
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    if (matrix[j, i] > max)
                    {
                        max = matrix[j, i];
                        imax = j;
                    }
                    if (matrix[j, i] > 0)
                        pn++;
                    else if (matrix[j, i] < 0)
                        mn++;
                }

                if (pn > mn)
                    matrix[imax, i] = 0;
                else if (mn > pn)
                    matrix[imax, i] = imax;
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
            int stolb = matrix.GetLength(0);
            int stroka = matrix.GetLength(1);

            if (stolb == stroka)
            {
                int n = stolb;
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
            int stolb = matrix.GetLength(0);
            int stroka = matrix.GetLength(1);
            for (int j = 0; j < stroka; j++)
            {
                int[] nov = new int[stolb];
                for (int i = 0; i < stolb; i++)
                {
                    nov[i] = matrix[i, j];
                }
                if (j % 2 == 0)
                {
                    for (int i = 0; i < stolb - 1; i++)
                    {
                        for (int k = i + 1; k < stolb; k++)
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
                    for (int i = 0; i < stolb - 1; i++)
                    {
                        for (int k = i + 1; k < stolb; k++)
                        {
                            if (nov[i] > nov[k])
                            {
                                int ans = nov[i];
                                nov[i] = nov[k];
                                nov[k] = ans;
                            }
                        }
                    }
                }
                for (int i = 0; i < stolb; i++)
                {
                    matrix[i, j] = nov[i];
                }
            }
            // end

        }
        public void Task12(int[][] array)
        {

            // code here
            int n = array.Length;

            for (int i = 0; i < n - 1; i++)
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
                        for (int k = 0; k < array[j].Length; k++)
                        {
                            sum1 += array[j][k];
                        }
                        for (int k = 0; k < array[j + 1].Length; k++)
                        {
                            sum2 += array[j + 1][k];
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
