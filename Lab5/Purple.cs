using System.Linq;
using System.Runtime.InteropServices;

namespace Lab5
{
    public class Purple
    {
        public int[] Task1(int[,] matrix)
        {
            int[] answer = new int[matrix.GetLength(1)];
            int countNegatives = 0;
            // code here
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                countNegatives = 0;
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    if (matrix[j, i] < 0)
                    {
                        countNegatives++;
                    }
                }
                answer[i] = countNegatives;
            }
            // end

            return answer;
        }
        public void Task2(int[,] matrix)
        {

            // code here
            int [,] res = new int[matrix.GetLength(0), matrix.GetLength(1)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int minIndex = -1;
                int minValue = int.MaxValue;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < minValue)
                    {
                        minValue = matrix[i, j];
                        minIndex = j;
                    }
                }
                res[i, 0] = minValue;
                int j1 = 1;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (j != minIndex)
                    {
                        res[i, j1++] = matrix[i, j]; 
                    }
                }   
            }
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = res[i, j];                    
                }
            }
            // end

        }
        public int[,] Task3(int[,] matrix)
        {
            int[,] answer = new int[matrix.GetLength(0), matrix.GetLength(1) + 1];

            // code here
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int maxIndex = -1;
                int maxValue = int.MinValue;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > maxValue)
                    {
                        maxValue = matrix[i, j];
                        maxIndex = j;
                    }
                }
                int j1 = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {

                    answer[i, j1++] = matrix[i, j];
                    if (j == maxIndex)
                    {
                        answer[i, j1++] = maxValue;
                    }
                }
            }
            // end

            return answer;
        }
        public void Task4(int[,] matrix)
        {

            // code here
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int maxValue = int.MinValue;
                int maxIndex = -1;
                int avarage = 0;
                int count = 0;
                int sum = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > maxValue)
                    {
                        maxValue = matrix[i, j];
                        maxIndex = j;
                    }
                }
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (j > maxIndex && matrix[i, j] > 0)
                    {
                        sum += matrix[i, j];
                        count++;
                    }
                }
                if (count > 0)
                {
                    avarage = sum / count;
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        if (j < maxIndex && matrix[i, j] < 0)
                        {
                            matrix[i, j] = avarage;
                        }
                    }
                }
            }
            // end
        }
        public void Task5(int[,] matrix, int k)
        {

            // code here
            int i1 = 0;
            int[] MaxSpisok = new int[matrix.GetLength(0)];
            for (int i = matrix.GetLength(0) - 1; i >= 0; i--)
            {
                int maxValue = int.MinValue;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > maxValue)
                    {
                        maxValue = matrix[i, j];
                    }
                }
                MaxSpisok[i1++] = maxValue;
            }
            if (k < matrix.GetLength(1))
            {  
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    matrix[i, k] = MaxSpisok[i];
                }  
            } 
            // end

        }
        public void Task6(int[,] matrix, int[] array)
        {
            if (matrix.GetLength(0) == 0)
            {
                return;
            }
            if (array.Length != matrix.GetLength(1))
            {
                return;
            }

            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                int maxValue = matrix[0, j];
                int maxIndex = 0;

                for (int i = 1; i < matrix.GetLength(0); i++)
                {
                    if (matrix[i, j] > maxValue)
                    {
                        maxValue = matrix[i, j];
                        maxIndex = i;
                    }
                }

                if (array[j] > maxValue)
                {
                    matrix[maxIndex, j] = array[j];
                }
            }
        }
        public void Task7(int[,] matrix)
        {

            // code here
            int[,] temp = new int[matrix.GetLength(0), matrix.GetLength(1)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    temp[i, j] = matrix[i, j];
                }
            }
            int[] minIndexes = new int[matrix.GetLength(0)];
            int[] minValues = new int[matrix.GetLength(0)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int minValue = int.MaxValue;
                int minIndex = -1;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < minValue)
                    {
                        minValue = matrix[i, j];
                        minIndex = i;
                    }
                }
                minIndexes[i] = minIndex;
                minValues[i] = minValue;
            }
            for (int a = 0; a < minValues.Length; a++)
            {
                for (int b = 0; b < minValues.Length - 1 - a; b++)
                {
                    if (minValues[b] < minValues[b + 1])
                    {
                        (minValues[b], minValues[b + 1]) = (minValues[b + 1], minValues[b]);
                        (minIndexes[b], minIndexes[b + 1]) = (minIndexes[b + 1], minIndexes[b]);
                    }
                }
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = temp[minIndexes[i], j];
                }
            }
            // end

        }
        public int[] Task8(int[,] matrix)
        {
            int[] answer = new int[2*matrix.GetLength(0) - 1];
            int sumIndex = 0;
            // code here
            if (matrix.GetLength(0) != matrix.GetLength(1))
            {
                return null;
            }
            for (int i = matrix.GetLength(0) - 1; i >= 0; i--)
            {
                int sum = 0;
                int i1 = i;
                int j1 = 0;
                while (i1 < matrix.GetLength(0) && j1 < matrix.GetLength(0)) 
                {
                    sum += matrix[i1, j1];
                    i1++; 
                    j1++; 
                }
                answer[sumIndex++] = sum;
            }

            for (int i = 1; i < matrix.GetLength(0); i++)
            {
                int sum = 0;
                int i1 = 0;
                int j1 = i;
                while (i1 < matrix.GetLength(0) && j1 < matrix.GetLength(0))
                {
                    sum += matrix[i1, j1];
                    i1++;
                    j1++;
                }
                answer[sumIndex++] = sum;
            }
            // end

            return answer;
        }
        public void Task9(int[,] matrix, int k)
        {

            // code here
            if (matrix.GetLength(0) != matrix.GetLength(1))
            {
                return;
            }
            if (k < 0 || k >= matrix.GetLength(0))
            {
                return;
            }
            int AbsMax = int.MinValue;
            int MaxStroka = -1;
            int MaxStolbec = -1;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (Math.Abs(matrix[i, j]) > AbsMax)
                    {
                        AbsMax = Math.Abs(matrix[i, j]);
                        MaxStroka = i;
                        MaxStolbec = j;
                    }
                }
            }

            if (MaxStroka > k)
            {
                for (int a = MaxStroka; a > k; a--)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        (matrix[a, j], matrix[a - 1, j]) = (matrix[a - 1, j], matrix[a, j]);
                    }
                }
            }
            else
            {
                for (int a = MaxStroka; a < k; a++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        (matrix[a, j], matrix[a + 1, j]) = (matrix[a + 1, j], matrix[a, j]);
                    }
                }
            }

            if (MaxStolbec > k)
            {
                for (int a = MaxStolbec; a > k; a--)
                {
                    for (int i = 0; i < matrix.GetLength(0); i++)
                    {
                        (matrix[i, a], matrix[i, a - 1]) = (matrix[i, a - 1], matrix[i, a]);
                    }
                }
            }
            else
            {
                for (int a = MaxStolbec; a < k; a++)
                {
                    for (int i = 0; i < matrix.GetLength(0); i++)
                    {
                        (matrix[i, a], matrix[i, a + 1]) = (matrix[i, a + 1], matrix[i, a]);
                    }
                }
            }
            // end

        }
        public int[,] Task10(int[,] A, int[,] B)
        {
            int[,] answer = null;

            // code here
            if (A.GetLength(1) != B.GetLength(0))
            {
                return null;
            }
            answer = new int[A.GetLength(0), B.GetLength(1)];
            for (int i = 0; i < A.GetLength(0); i++)
            {
                for (int j = 0; j < B.GetLength(1); j++)
                {
                    int sum = 0;
                    for (int k = 0; k < A.GetLength(1); k++)
                    {
                        sum += A[i, k] * B[k, j];
                    }
                    answer[i, j] = sum;
                }
            }
            // end
            return answer;
        }

        public int[][] Task11(int[,] matrix)
        {
            int[][] answer = new int[matrix.GetLength(0)][];

            // code here
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int count = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        count++;
                    }
                }
                answer[i] = new int[count];
            }
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int count = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        answer[i][count++] = matrix[i, j];
                    }
                }
            }
            // end

            return answer;
        }
        public int[,] Task12(int[][] array)
        {

            // code here
            int count = 0;
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    count++;
                }
            }
            int n = 1;
            for (int _ = 1; n < count; n++)
            {

                if (n * n >= count)
                {
                    break;
                }
            }
            int[,] answer = new int[n,n];
            int[] temp = new int[count];
            int index = 0;
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    temp[index++] = array[i][j];
                }
            }
            int k = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (k >= count)
                    {
                        answer[i, j] = 0;
                        continue;
                    }
                    answer[i, j] = temp[k++];
                }
            }
            // end
            return answer;
        }
    }
}
