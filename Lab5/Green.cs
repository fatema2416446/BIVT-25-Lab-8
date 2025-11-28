using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
using System.Xml.Schema;

namespace Lab5
{
    public class Green
    {
        public int[] Task1(int[,] matrix)
        {
            int[] answer = new int[matrix.GetLength(0)];
            int count = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int mini = int.MaxValue;
                int minj = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < mini)
                    {
                        mini = matrix[i, j];
                        minj = j;
                    }
                }
                answer[count] = minj;
                count++;
            }
            // code here

            // end

            return answer;
        }
        public void Task2(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int maxi = int.MinValue;
                int maxindex = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > maxi){
                        maxi = matrix[i, j];
                        maxindex = j;
                    }
                }
                if (maxi == 0)
                    continue;
                for (int j = 0; j < maxindex; j++)
                {
                    if (matrix[i, j] < 0)
                    {
                        matrix[i, j] = (int)Math.Floor((double)matrix[i, j] / maxi);
                    }
                }
            }
            // code here

            // end

        }
        public void Task3(int[,] matrix, int k)
        {
            

            if (matrix.GetLength(0) != matrix.GetLength(1))
            {
                return;
            }

            if (k < 0 || k >= matrix.GetLength(1))
            {
                return;
            }

            
            int maxi = int.MinValue;
            int maxindex = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, i]  > maxi)
                {
                    maxindex = i;
                    maxi = matrix[i, i];
                }
            }
            if (maxindex == k)
            {
                return;
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int temp = matrix[i, k];
                matrix[i, k] = matrix[i, maxindex];
                matrix[i, maxindex] = temp;
            }

            // code here

            // end

        }
        public void Task4(int[,] matrix)
        {

            if (matrix.GetLength(0) != matrix.GetLength(1))
            {
                return;
            }

            int maxi = int.MinValue;
            int maxindex = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (maxi < matrix[i, i])
                {
                    maxi = matrix[i, i];
                    maxindex = i;
                }
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int temp = matrix[maxindex, i];
                matrix[maxindex, i] = matrix[i, maxindex];
                matrix[i, maxindex] = temp;
            }
            // code here

            // end

        }
        public int[,] Task5(int[,] matrix)
        {
            int[,] answer = new int[matrix.GetLength(0) - 1, matrix.GetLength(1)];
            int maxi = int.MinValue;
            int maxindex = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int sum = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > 0)
                        sum += matrix[i, j];
                }
                if (sum > maxi)
                {
                    maxi = sum;
                    maxindex = i;
                }
                
            }

            int count = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (i == maxindex)
                    continue; 

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    answer[count, j] = matrix[i, j];
                }
                count++;
            }

            
        
            // code here

            // end

            return answer;
        }
        public void Task6(int[,] matrix)
        {
            int mini = int.MaxValue;
            int minindex = 0;
            int maxi = int.MinValue;
            int maxindex = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int count = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < 0)
                    {
                        count++;
                    }
                }
                if (count > maxi)
                {
                    maxi = count;
                    maxindex = i;
                }
                if (count < mini)
                {
                    mini = count;
                    minindex = i;
                }
            }
            if (minindex == maxindex)
            {
                return;
            }

            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                int temp = matrix[minindex, i];
                matrix[minindex, i] = matrix[maxindex, i];
                matrix[maxindex, i] = temp;

            }

            // code here

            // end

        }
        public int[,] Task7(int[,] matrix, int[] array)
        {
            if (matrix.GetLength(0) != array.Length){
                return matrix;
            }
            int[,] answer = new int[matrix.GetLength(0), matrix.GetLength(1) + 1];
            int mini = int.MaxValue;
            int mincolumn = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < mini)
                    {
                        mini = matrix[i, j];
                        mincolumn = j;
                    }
                }
            }
            int count = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j <= matrix.GetLength(1); j++)
                {
                    if (j <= mincolumn)
                        answer[i, j] = matrix[i, j];          
                    else if (j == mincolumn + 1)
                        answer[i, j] = array[i];
                    else
                        answer[i, j] = matrix[i, j - 1];      
                }
            }

            // code here

            // end

            return answer;
        }
        public void Task8(int[,] matrix)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                int maxi = int.MinValue;
                int maxindex = -1;
                int countpositive = 0;
                int countnegative = 0;
                for (int i = 0; i < matrix.GetLength(0); i++)
                {

                    if (matrix[i, j] < 0) countnegative += 1;
                    if (matrix[i, j] > 0) countpositive += 1;

                    if ((matrix[i, j] > maxi))
                    {
                        maxi = matrix[i, j];
                        maxindex = i;
                    }

                }
                if (maxindex != -1)
                {
                    if (countpositive > countnegative)
                    {
                        matrix[maxindex, j] = 0;
                    }
                    else if (countnegative > countpositive)
                    {
                        matrix[maxindex, j] = maxindex;
                    }

                }
            }
            // code here

            // end

        }
        public void Task9(int[,] matrix)
        {
            
            if (matrix.GetLength(0) != matrix.GetLength(1))
                return;

            for (int k = 0; k < matrix.GetLength(0) * matrix.GetLength(1); k++)
            {
                int i = k / matrix.GetLength(0);
                int j = k % matrix.GetLength(0);
                if (i == 0 || i == matrix.GetLength(0) - 1 || j == 0 || j == matrix.GetLength(0) - 1)
                {
                    matrix[i, j] = 0;
                }
            }
        }
        public (int[] A, int[] B) Task10(int[,] matrix)
        {
            int[] A = null, B = null;

            if(matrix.GetLength(0) != matrix.GetLength(1)){
                return (A, B);

            }
            int n = matrix.GetLength(0);
            
            int sizeA = n * (n + 1) / 2;
            int sizeB = n * (n - 1) / 2;

            A = new int[sizeA];
            B = new int[sizeB];

            int indexA = 0;
            int indexB = 0;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (j >= i) 
                    {
                        A[indexA] = matrix[i, j];
                        indexA++;
                    }
                    else 
                    {
                        B[indexB] = matrix[i, j];
                        indexB++;
                    }
                }
            }
            // code here

            // end

            return (A, B);
        }
        public void Task11(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    for (int k = 0; k < matrix.GetLength(0) - i - 1; k++)
                    {
                        
                        if (j % 2 == 0 && matrix[k, j] < matrix[k + 1, j])
                        {
                            int temp = matrix[k, j];
                            matrix[k, j] = matrix[k + 1, j];
                            matrix[k + 1, j] = temp;
                        }

                        if (j % 2 != 0 && matrix[k, j] > matrix[k + 1, j])
                        {
                            int temp = matrix[k, j];
                            matrix[k, j] = matrix[k + 1, j];
                            matrix[k + 1, j] = temp;
                        }
                    }
                }
            }

            // code here

            // end

        }
        public void Task12(int[][] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    int sumI = 0;
                    for (int k = 0; k < array[i].Length; k++)
                        sumI += array[i][k];

                    int sumJ = 0;
                    for (int k = 0; k < array[j].Length; k++)
                    {
                        sumJ += array[j][k];
                    }
                    
                    if (array[j].Length > array[i].Length || (array[j].Length == array[i].Length && sumJ > sumI))
                    {
                        int[] temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
                }
            }

        }
    }
}