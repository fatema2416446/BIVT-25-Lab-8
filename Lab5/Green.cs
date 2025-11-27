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
    
                
                int maxSumRow = 0;
                int maxSum = 0;
    
                for (int i = 0; i < rows; i++)
                {
                    
                    int currentSum = 0;
                    for (int j = 0; j < cols; j++)
                    {
                        if (matrix[i, j] > 0)
                        {
                            currentSum += matrix[i, j];
                        }
                    }
        
                    
                    if (currentSum > maxSum || i == 0)
                    {
                        maxSum = currentSum;
                        maxSumRow = i;
                    }
                }
    
                
                answer = new int[rows - 1, cols];
    
                
                int newRowIndex = 0;
                for (int i = 0; i < rows; i++)
                {
                    
                    if (i == maxSumRow)
                        continue;
                    
                    for (int j = 0; j < cols; j++)
                    {
                        answer[newRowIndex, j] = matrix[i, j];
                    }
                    newRowIndex++;
                }
    
            
            
            // end

            return answer;
        }
        public void Task6(int[,] matrix)
        {

            // code here
    
                int rows = matrix.GetLength(0);
                int cols = matrix.GetLength(1);
    
                
                int minNegativeRow = 0;
                int maxNegativeRow = 0;
                int minNegativeCount = 0;
                int maxNegativeCount = 0;
    
                
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[0, j] < 0)
                    {
                        minNegativeCount++;
                        maxNegativeCount++;
                    }
                }
    
                
                for (int i = 1; i < rows; i++)
                {
                    
                    int currentCount = 0;
                    for (int j = 0; j < cols; j++)
                    {
                        if (matrix[i, j] < 0)
                        {
                            currentCount++;
                        }
                    }
        
                    
                    if (currentCount < minNegativeCount)
                    {
                        minNegativeCount = currentCount;
                        minNegativeRow = i;
                    }
        
                    
                    if (currentCount > maxNegativeCount)
                    {
                        maxNegativeCount = currentCount;
                        maxNegativeRow = i;
                    }
                }
    
                
                if (minNegativeCount == maxNegativeCount)
                {
                    return; 
                }
    
                
                for (int j = 0; j < cols; j++)
                {
                    int temp = matrix[minNegativeRow, j];
                    matrix[minNegativeRow, j] = matrix[maxNegativeRow, j];
                    matrix[maxNegativeRow, j] = temp;
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
                    return matrix;
    
                
                int minCol = 0;
                int minValue = matrix[0, 0];
    
                
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        if (matrix[i, j] < minValue)
                        {
                            minValue = matrix[i, j];
                            minCol = j;
                        }
                    }
                }
    
                
                answer = new int[rows, cols + 1];
    
                
                for (int i = 0; i < rows; i++)
                {
                    int newColIndex = 0;
        
                    
                    for (int j = 0; j <= minCol; j++)
                    {
                        answer[i, newColIndex] = matrix[i, j];
                        newColIndex++;
                    }
        
                    
                    answer[i, newColIndex] = array[i];
                    newColIndex++;
        
                    
                    for (int j = minCol + 1; j < cols; j++)
                    {
                        answer[i, newColIndex] = matrix[i, j];
                        newColIndex++;
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

                
                for (int i = 0; i < array.Length - 1; i++)
                {
                    for (int j = i + 1; j < array.Length; j++)
                    {
                        
                        int lengthI = array[i]?.Length ?? 0;
                        int lengthJ = array[j]?.Length ?? 0;
            
                        bool Swap = false;
            
                        if (lengthI < lengthJ)
                        {
                            
                            Swap = true;
                        }
                        else if (lengthI == lengthJ && array[i] != null && array[j] != null)
                        {
                            
                            int sumI = 0;
                            int sumJ = 0;
                            
                            for (int k = 0; k < array[i].Length; k++)
                            {
                                sumI += array[i][k];
                            }
                            
                            for (int k = 0; k < array[j].Length; k++)
                            {
                                sumJ += array[j][k];
                            }
                            
                            if (sumI < sumJ)
                            {
                                Swap = true;
                            }
                        }
            
                        
                        if (Swap)
                        {
                            
                            int[] temp = array[i];
                            array[i] = array[j];
                            array[j] = temp;
                        }
                    }
                }
            
            // end

        }
    }
}
