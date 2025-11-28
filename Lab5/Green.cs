using System.Linq;
using System.Runtime.InteropServices;

namespace Lab5
{
    public class Green
    {
        public int[] Task1(int[,] matrix)
        {
            int[] res = null;
            if (matrix == null) return null;
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            res = new int[n];
            for (int i = 0; i < n; i++)
            {
                int mv = matrix[i, 0];
                int jc = 0;
                for (int j = 1; j < m; j++)
                {
                    if (matrix[i, j] < mv)
                    {
                        mv = matrix[i, j];
                        jc = j;
                    }
                }
                res[i] = jc;
            }
            

            return res;
        }
        public void Task2(int[,] matrix)
        {

            if (matrix == null) return;
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            for (int i = 0; i < n; i++)
            {
                int jc = 0;
                int mv = matrix[i, 0];
                for (int j = 1; j < m; j++) 
                {
                    if (matrix[i, j] > mv) 
                    { 
                        mv = matrix[i, j]; jc = j;
                    }
                }
                for (int j = 0; j < jc; j++)
                {
                    if (matrix[i, j] < 0)
                    {
                        matrix[i, j] = (int)Math.Floor((double)matrix[i, j] / mv);
                    }
                }
            }
            

        }
        public void Task3(int[,] matrix, int k)
        {

            // code here
            if (matrix == null) return;
            int size = matrix.GetLength(0);
            if (size != matrix.GetLength(1) || k < 0 || k >= size) return;
            int maxIndex = 0;
            int maxValue = matrix[0, 0];
            for (int i = 1; i < size; i++)
            {
                if (matrix[i, i] > maxValue)
                {
                    maxValue = matrix[i, i];
                    maxIndex = i;
                }
            }
            if (maxIndex != k)
            {
                for (int i = 0; i < size; i++)
                {
                    int tmp = matrix[i, k];
                    matrix[i, k] = matrix[i, maxIndex];
                    matrix[i, maxIndex] = tmp;
                }
            }
            // end

        }
        public void Task4(int[,] matrix)
        {

            // code here
            if (matrix == null) return;
            int size = matrix.GetLength(0);
            if (size != matrix.GetLength(1)) return;
            int maxIndex = 0;
            int maxValue = matrix[0, 0];
            for (int i = 1; i < size; i++)
            {
                if (matrix[i, i] > maxValue)
                {
                    maxValue = matrix[i, i];
                    maxIndex = i;
                }
            }
            for (int i = 0; i < size; i++)
            {
                int tmp = matrix[maxIndex, i];
                matrix[maxIndex, i] = matrix[i, maxIndex];
                matrix[i, maxIndex] = tmp;
            }
            // end

        }
        public int[,] Task5(int[,] matrix)
        {
            if (matrix == null) return null;
            
            int n = matrix.GetLength(0); 
            int m = matrix.GetLength(1);
            
            if (n == 0) return new int[0, m];
            
            int maxSum = -1;
            int rowToRemove = -1;
            
            for (int i = 0; i < n; i++) 
            { 
                int currentSum = 0;
                bool hasPositive = false;
                
                for (int j = 0; j < m; j++) 
                {
                    if (matrix[i, j] > 0) 
                    {
                        currentSum += matrix[i, j];
                        hasPositive = true;
                    }
                }
                if (!hasPositive)
                {
                    currentSum = 0;
                }
                if (currentSum > maxSum || rowToRemove == -1)
                {
                    maxSum = currentSum;
                    rowToRemove = i;
                }
            }
            
            if (rowToRemove == -1)
            {
                return matrix;
            }
            
            int[,] result = new int[n - 1, m];
            int resultRow = 0;
            
            for (int i = 0; i < n; i++) 
            { 
                if (i == rowToRemove) continue;
                
                for (int j = 0; j < m; j++) 
                {
                    result[resultRow, j] = matrix[i, j];
                }
                resultRow++; 
            }
            
            return result;
        }
        public void Task6(int[,] matrix)
        {

            if (matrix == null) return;
            int n = matrix.GetLength(0), m = matrix.GetLength(1);
            int[] neg = new int[n];
            for (int i = 0; i < n; i++) 
            { 
                int c = 0; 
                for (int j = 0; j < m; j++) 
                {
                    if (matrix[i, j] < 0) 
                    {
                        c++; 
                        neg[i] = c; 
                    }
                }
            }
            int imin = 0, imax = 0, mn = neg[0], mx = neg[0];
            for (int i = 1; i < n; i++) 
            { 
                if (neg[i] < mn) 
                { 
                    mn = neg[i]; 
                    imin = i; 
                } 
                if (neg[i] > mx) 
                { 
                    mx = neg[i]; 
                    imax = i; 
                } 
            }
            if (mn != mx) 
            {
                for (int j = 0; j < m; j++) 
                { 
                    int t = matrix[imin, j];
                     matrix[imin, j] = matrix[imax, j]; 
                     matrix[imax, j] = t; 
                }
            }
            // end

        }
        public int[,] Task7(int[,] matrix, int[] array)
        {
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            if (array.Length != n) return matrix;
            int jc = 0; int mv = matrix[0,0];
            for (int j = 0; j < m; j++) 
            {
                for (int i = 0; i < n; i++) 
                {
                    if (matrix[i,j] < mv) { mv = matrix[i,j]; jc = j; }
                }
            }
            int[,] res = new int[n, m + 1];
            for (int i = 0; i < n; i++) 
            {
                for (int j = 0; j <= jc; j++) 
                {
                    res[i,j] = matrix[i,j];
                }
            }
            
            for (int i = 0; i < n; i++)
            {
                 res[i, jc + 1] = array[i];
            }
            for (int i = 0; i < n; i++) 
            {
                for (int j = jc + 1; j < m; j++)
                {
                    res[i, j + 1] = matrix[i,j];
                }
            }
            return res;
        }
        public void Task8(int[,] matrix)
        {

            if (matrix == null) return;
            int n = matrix.GetLength(0), m = matrix.GetLength(1);
            for (int j = 0; j < m; j++)
            {
                int p = 0, q = 0;
                int mv = matrix[0, j];
                int imax = 0;
                for (int i = 0; i < n; i++)
                {
                    if (matrix[i, j] > 0) p++; 
                    else if (matrix[i, j] < 0) q++;
                    if (matrix[i, j] > mv) 
                    { 
                        mv = matrix[i, j]; 
                        imax = i; 
                    }
                }
                if (p > q) matrix[imax, j] = 0; 
                else if (q > p) matrix[imax, j] = imax;
            }
            

        }
        public void Task9(int[,] matrix)
        {

            // code here
            if (matrix == null) return;
            int size = matrix.GetLength(0);
            if (size != matrix.GetLength(1)) return;
            for (int i = 0; i < size * size; i++)
            {
                int rIndex = i / size;
                int cIndex = i % size;

                if (rIndex == 0 || rIndex == size - 1 || cIndex == 0 || cIndex == size - 1)
                {
                    matrix[rIndex, cIndex] = 0;
                }
            }
            // end

        }
        public (int[] A, int[] B) Task10(int[,] matrix)
        {
            int[] A = null, B = null;

            // code here
            if (matrix == null) return (null, null);
            int size = matrix.GetLength(0);
            if (size != matrix.GetLength(1)) return (null, null);
            int countA = size * (size + 1) / 2;
            int countB = size * (size - 1) / 2;
            A = new int[countA];
            B = new int[countB];
            int idxA = 0, idxB = 0;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (j >= i)
                    {
                        A[idxA++] = matrix[i, j];
                    }
                    else
                    {
                        B[idxB++] = matrix[i, j];
                    }
                }
            }
            // end

            return (A, B);
        }
        public void Task11(int[,] matrix)
        {

            // code here
            if (matrix == null) return;
            int rowCount = matrix.GetLength(0);
            int colCount = matrix.GetLength(1);
            for (int j = 0; j < colCount; j++)
            {
                int[] colValues = new int[rowCount];
                for (int i = 0; i < rowCount; i++)
                {
                    colValues[i] = matrix[i, j];
                }
                if (j % 2 == 0)
                {
                    for (int i = 0; i < rowCount - 1; i++)
                    {
                        for (int k = i + 1; k < rowCount; k++)
                        {
                            if (colValues[i] < colValues[k])
                            {
                                int tmp = colValues[i];
                                colValues[i] = colValues[k];
                                colValues[k] = tmp;
                            }
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < rowCount - 1; i++)
                    {
                        for (int k = i + 1; k < rowCount; k++)
                        {
                            if (colValues[i] > colValues[k])
                            {
                                int tmp = colValues[i];
                                colValues[i] = colValues[k];
                                colValues[k] = tmp;
                            }
                        }
                    }
                }
                for (int i = 0; i < rowCount; i++)
                {
                    matrix[i, j] = colValues[i];
                }
            }
            // end

        }
        public void Task12(int[][] array)
        {

            // code here
            if (array == null) return;
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    int lenI = 0;
                    int lenJ = 0;
                    int sumI = 0;
                    int sumJ = 0;
                    if (array[i] != null)
                    {
                        lenI = array[i].Length;
                        for (int k = 0; k < array[i].Length; k++)
                        {
                            sumI += array[i][k];
                        }
                    }
                    if (array[j] != null)
                    {
                        lenJ = array[j].Length;
                        for (int k = 0; k < array[j].Length; k++)
                        {
                            sumJ += array[j][k];
                        }
                    }
                    bool shouldSwap = false;
                    if (lenI < lenJ)
                    {
                        shouldSwap = true;
                    }
                    else if (lenI == lenJ && sumI < sumJ)
                    {
                        shouldSwap = true;
                    }
                    if (shouldSwap)
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
