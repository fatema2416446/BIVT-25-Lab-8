using System.Buffers;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.SymbolStore;
using System.Formats.Asn1;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;

namespace Lab5
{
    public class Blue
    {
        public double[] Task1(int[,] matrix)
        {
            double sr = 0;
            int sr_index = 0;
            double[] answer = new double[matrix.GetLength(0)];
            int index = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                    if (matrix[i, j] > 0)
                    { sr += matrix[i, j]; sr_index++; }

                answer[index++] = sr_index > 0 ? sr / sr_index : 0;
                (sr, sr_index) = (0, 0);
            }

            return answer;
        }
        public int[,] Task2(int[,] matrix)
        {
            int[,] answer = new int[matrix.GetLength(0) - 1, matrix.GetLength(1) - 1];
            int max = matrix[0, 0];
            int x = 0, y = 0;
            int u = 0, h = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++)
                    if (max < matrix[i, j])
                    {
                        max = matrix[i, j];
                        (x, y) = (i, j);
                    }

            for(int i = 0; i < matrix.GetLength(0); i++)
            {
                if (i == x) continue;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (j == y) continue;
                    answer[u, h++] = matrix[i, j];
                }
                u++;
                h = 0;
            }

            return answer;
        }
        public void Task3(int[,] matrix)
        {
            int localMax = 0;
            int localMaxIndex = 0;

            for (int i = 0; i != matrix.GetLength(0); i++)
            {
                localMax = matrix[i, 0];
                for (int j = 0; j != matrix.GetLength(1); j++)
                    if (localMax < matrix[i, j])
                    {
                        localMax = matrix[i, j];
                        localMaxIndex = j;
                    }

                for (int j = localMaxIndex; j < matrix.GetLength(1) - 1; j++)
                    (matrix[i, j], matrix[i, j + 1]) = (matrix[i, j + 1], matrix[i, j]);
                
                localMax = matrix[i, 0];
                localMaxIndex = 0;
            }

        }
        public int[,] Task4(int[,] matrix)
        {
            int[,] answer = new int[matrix.GetLength(0), matrix.GetLength(1) + 1];
            int[] maxArray = new int[matrix.GetLength(0)];
            
            int max = 0, Index = 0;

            for (int i = 0; i != matrix.GetLength(0); i++)
            {
                max = matrix[i, 0];
                for (int j = 0; j != matrix.GetLength(1); j++)
                    if (max < matrix[i, j])
                        max = matrix[i, j];
                maxArray[Index++] = max;
            }

            Index = 0;

            for (int rows = 0; rows != matrix.GetLength(0); rows++)
            {
                for (int cows = 0; cows != matrix.GetLength(1) - 1; cows++)
                    answer[rows, cows] = matrix[rows, cows];
                
                answer[rows, matrix.GetLength(1) - 1] = maxArray[rows];
                answer[rows, matrix.GetLength(1)] = matrix[rows, matrix.GetLength(1) - 1];
            }

            return answer;
        }
        public int[] Task5(int[,] matrix)
        {
            int[] answer = new int[matrix.Length / 2];
            int index = 0;

            for (int i = 0; i != matrix.GetLength(0); i++)
                for (int j = 0; j != matrix.GetLength(1); j++)
                    if ((i + j) % 2 != 0)
                        answer[index++] = matrix[i, j];
            
            return answer;
        }
        public void Task6(int[,] matrix, int k)
        {
            int max = matrix[0, 0], maxIndex = 0;
            int index = -1;

            if (matrix.GetLength(0) != matrix.GetLength(1) || matrix.GetLength(0) == 0)
                return;

            for (int i = 0; i != matrix.GetLength(0); i++)
            {
                if (matrix[i, i] > max)
                    {max = matrix[i, i]; maxIndex = i;}
                
                if (index == -1 && matrix[i, k] < 0) 
                    index = i;
            }
            
            if (index == -1)
                return;
            
            for (int i = 0; i < matrix.GetLength(1); i++)
                (matrix[maxIndex, i], matrix[index, i]) = (matrix[index, i], matrix[maxIndex, i]);
        }
        public void Task7(int[,] matrix, int[] array)
        {
            if (matrix.GetLength(1) < 3)
                return;
            
            if (matrix.GetLength(1) != array.Length)
                return;
            
            int max = matrix[0, 0], maxIndex = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
                if (max < matrix[i, matrix.GetLength(1) - 2])
                    {max = matrix[i, matrix.GetLength(1) - 2]; maxIndex = i;}
            
            for (int i = 0; i < matrix.GetLength(1); i++)
                matrix[maxIndex, i] = array[i];
        }
        public void Task8(int[,] matrix)
        {
            int max = matrix[0, 0], maxIndex = 0;
            int sum = 0;

            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                max = matrix[0, j];
                maxIndex = 0;
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                        maxIndex = i;
                    }
                }

                if (maxIndex < matrix.GetLength(0) / 2)
                {
                    sum = 0;
                    for (int i = maxIndex + 1; i < matrix.GetLength(0); i++)
                    {
                        sum += matrix[i, j];
                    }
                    matrix[0, j] = sum;
                }
            }
        }
        public void Task9(int[,] matrix)
        {            
            int maxOdd = matrix[0, 0], maxOddIndex = 0;
            int maxEven = matrix[0, 0], maxEvenIndex = 0;

            for (int i = 0; i < matrix.GetLength(0) - 1; i += 2)
            {
                maxOdd = matrix[i, 0]; maxOddIndex = 0;

                for (int j = 1; j < matrix.GetLength(1); j++)
                {
                    if (maxOdd < matrix[i, j])
                    {
                        maxOdd = matrix[i, j];
                        maxOddIndex = j;
                    }
                }

                maxEven = matrix[i + 1, 0]; maxEvenIndex = 0;

                for (int j = 1; j < matrix.GetLength(1); j++)
                {
                    if (maxEven < matrix[i + 1, j])
                    {
                        maxEven = matrix[i + 1, j];
                        maxEvenIndex = j;
                    }
                }

                (matrix[i, maxOddIndex], matrix[i + 1, maxEvenIndex]) = 
                (matrix[i + 1, maxEvenIndex], matrix[i, maxOddIndex]);

            }
        }
        public void Task10(int[,] matrix)
        {
            if (matrix.GetLength(0) != matrix.GetLength(1))
                return;
            
            int max = matrix[0, 0], maxIndex = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
                if (matrix[i, i] > max)
                {
                    max = matrix[i, i];
                    maxIndex = i;
                }
            
            for (int i = 0; i < maxIndex; i++)
                for (int j = i + 1; j < matrix.GetLength(1); j++)
                    matrix[i, j] = 0;
        }
        public void Task11(int[,] matrix)
        {
            int[] array = new int[matrix.GetLength(0)];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int count = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                    if (matrix[i, j] > 0)
                        count++;

                array[i] = count;
            }

            for (int i = 0; i < matrix.GetLength(0) - 1; i++)
            {
                int maxIndex = i;

                for (int j = i + 1; j < matrix.GetLength(0); j++)
                    if (array[j] > array[maxIndex])
                        maxIndex = j;

                if (maxIndex == i)
                    continue;

                for (int j = 0; j < matrix.GetLength(1); j++)
                    (matrix[i, j], matrix[maxIndex, j]) = (matrix[maxIndex, j], matrix[i, j]);

                (array[i], array[maxIndex]) = (array[maxIndex], array[i]);
            }
        }
        public int[][] Task12(int[][] array)
        {
            int[][] answer = null;
            int num = 0, count = 0;
            double sr = 0;
            int index1 = 0, index2 = 0;

            foreach (int[] i in array)
                foreach (int j in i)
                {
                    sr += j;
                    num++;
                }
            
            sr /= num;

            foreach (int[] i in array)
            {
                int sr2 = 0, num2 = 0;
                foreach (int j in i)
                {
                    sr2 += j;
                    num2 ++;
                }
                if ((double) sr2 / num2 >= sr)
                    count++;
            }

            answer = new int[count][];

            foreach (int[] i in array)
            {
                index2 = 0;
                int sr2 = 0, num2 = 0;
                foreach (int j in i)
                {
                    sr2 += j;
                    num2 ++;
                }
                if ((double) sr2 / num2 >= sr)
                {
                    int[] preanswer = new int[i.Length];
                    foreach (int j in i)
                        preanswer[index2++] = j;
                    answer[index1++] = preanswer;
                }
            }
            return answer;
        }
    }
}
