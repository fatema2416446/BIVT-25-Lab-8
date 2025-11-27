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
            int counter = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int min = 1000, minIndex = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < min)
                    {
                        min = matrix[i, j];
                        minIndex = j;
                    }
                }
                answer[counter++] = minIndex;
            }
            // end
            return answer;
        }
        public void Task2(int[,] matrix)
        {
            // code here
            for (int i = 0; i < matrix.GetLength(0); i++)
            {   
                int max = Int32.MinValue, maxIndex = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                        maxIndex = j;
                    }
                }

                for (int j = 0; j < maxIndex; j++)
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
            if ((matrix.GetLength(0) != matrix.GetLength(1)) || (k >= matrix.GetLength(1)))
                return;

            int max = int.MinValue, maxIndex = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, i] > max)
                {
                    max = matrix[i, i];
                    maxIndex = i;
                }
            }
            
            for (int i = 0; i < matrix.GetLength(0); i++)
                (matrix[i, maxIndex], matrix[i, k]) = (matrix[i, k], matrix[i, maxIndex]);
            // end
        }
        public void Task4(int[,] matrix)
        {

            // code here
            if (matrix.GetLength(0) != matrix.GetLength(1))
                return;
            
            int max = int.MinValue,  maxIndex = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, i] > max)
                {
                    max = matrix[i, i];
                    maxIndex = i;
                }
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
                (matrix[i, maxIndex], matrix[maxIndex, i]) = (matrix[maxIndex, i], matrix[i, maxIndex]);
            // end

        }
        public int[,] Task5(int[,] matrix)
        {
            int[,] answer = null;

            // code here
            answer = new int[matrix.GetLength(0) - 1, matrix.GetLength(1)];
            int maxSum = -10000, maxSumIndex = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int sum = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > 0)
                        sum += matrix[i, j];
                }

                if (sum > maxSum)
                {
                    maxSum = sum;
                    maxSumIndex = i;
                }
            }

            int counter = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (i == maxSumIndex)
                    continue;
                
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    answer[counter, j] = matrix[i, j];
                }

                counter++;
            }
            // end

            return answer;
        }
        public void Task6(int[,] matrix)
        {
            // code here
            int maxIndex = 0, minIndex = 0, max = Int32.MinValue, min = Int32.MaxValue;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int counter = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < 0)
                    {
                        counter++;
                    }
                }

                if (counter > max)
                {
                    max = counter;
                    maxIndex = i;
                }
                
                if (counter < min)
                {
                    min = counter;
                    minIndex = i;
                }
            }

            for (int i = 0; i < matrix.GetLength(1); i++)
                (matrix[maxIndex, i], matrix[minIndex, i]) = (matrix[minIndex, i], matrix[maxIndex, i]);
            // end
        }
        public int[,] Task7(int[,] matrix, int[] array)
        {
            int[,] answer = null;
            // code here
            
            if (array.Length != matrix.GetLength(0))
                return matrix;
            
            int min =  Int32.MaxValue, minIndex = 0;
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
                int plusNumbers = 0, minusNumbers = 0, max = Int32.MinValue, maxIndex = 0;
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    if (matrix[j, i] > max)
                    {
                        max = matrix[j, i];
                        maxIndex = j;
                    }
                    if (matrix[j, i] > 0)
                        plusNumbers++;
                    else if (matrix[j, i] < 0)
                        minusNumbers++;
                }

                if (plusNumbers > minusNumbers)
                    matrix[maxIndex, i] = 0;
                else if (minusNumbers > plusNumbers)
                    matrix[maxIndex, i] = maxIndex;
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
            if (matrix.GetLength(0) != matrix.GetLength(1))
                return (A, B);

            int counterA = 0, counterB = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (i <= j)
                        counterA++;
                    else
                        counterB++;
                }
            }

            A = new int[counterA];
            B = new int[counterB];

            counterA = 0;
            counterB = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (i <= j)
                        A[counterA++] = matrix[i, j];
                    else
                        B[counterB++] = matrix[i, j];
                }
            }

            // end

            return (A, B);
        }
        public void Task11(int[,] matrix)
        {

            // code here
            
            for (int i = 0; i < matrix.GetLength(1); i++)
            {   
                int[] arrayA = new int[matrix.GetLength(0)];
                for (int j = 0; j < matrix.GetLength(0); j++)
                    arrayA[j] =  matrix[j, i];
                
                Array.Sort(arrayA);
                
                if (i % 2 == 0)
                    Array.Reverse(arrayA);
                
                for  (int j = 0; j < matrix.GetLength(0); j++)
                    matrix[j, i] = arrayA[j];
            }
            // end

        }
        public void Task12(int[][] array)
        {

            // code here
            if (array == null)
                return;

            int[] sums = new int[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                sums[i] = 0;
                if (array[i] != null)
                {
                    for (int j = 0; j < array[i].Length; j++)
                        sums[i] += array[i][j];
                }
            }

            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = 0; j < array.Length - 1 - i; j++)
                {
                    int counterNow = 0;      
                    int counterNext = 0;         

                    if (array[j] != null)
                        counterNow = array[j].Length;
                    
                    if (array[j + 1] != null)
                        counterNext = array[j + 1].Length;

                    bool swap = false;

                    if (counterNow < counterNext)
                        swap = true;
                    else if (counterNow == counterNext)
                    {
                        if (sums[j] < sums[j + 1])
                            swap = true;
                    }

                    if (swap)
                    {
                        int[] temp = array[j];
                        (array[j], array[j + 1]) = (array[j + 1], temp);

                        int tempA = sums[j];
                        (sums[j], sums[j + 1]) = (sums[j + 1], tempA);
                    }
                }
            }
            // end

        }
        
    }
}
