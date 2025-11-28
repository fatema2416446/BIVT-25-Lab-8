using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics.X86;

namespace Lab5
{
    public class Green
    {
        public int[] Task1(int[,] matrix)
        {
            int[] answer = null;

            // code here
            int n=matrix.GetLength(0);
            answer = new int[n];
            n = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int imn = -1;
                int mn = int.MaxValue;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < mn)
                    {
                        mn=matrix[i, j];
                        imn = j;
                    }
                }
                answer[n++] = imn;
            }
            // end

            return answer;
        }
        public void Task2(int[,] matrix)
        {

            // code here
            if (matrix == null) return;
            for (int i = 0;i < matrix.GetLength(0); i++)
            {
                int mx = int.MinValue;
                int jmx = -1;
                for (int j=0;j<matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > mx)
                    {
                        mx=matrix[i, j];
                        jmx = j;
                    }
                }
                for (int j = 0;j<jmx; j++)
                {
                    if (matrix[i,j]<0)
                    {
                        matrix[i, j] = (int)Math.Floor((double)matrix[i,j]/mx);
                    }
                }
            }
            // end

        }
        public void Task3(int[,] matrix, int k)
        {

            // code here
            if (matrix == null) return;
            int m = matrix.GetLength(0); int l = matrix.GetLength(1);
            if (m != l) return;
            if (k > l-1) return;
            int mx = int.MinValue; int imx = -1;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, i] > mx)
                {
                    mx = matrix[i, i];
                    imx = i;
                }
            }
            if (k == imx) return;
            for (int i = 0;i < matrix.GetLength(0); i++)
            {
                (matrix[i, imx], matrix[i, k]) = (matrix[i, k], matrix[i, imx]);
            }
            // end

        }
        public void Task4(int[,] matrix)
        {

            // code here
            if (matrix == null) return;
            int m = matrix.GetLength(0); int l = matrix.GetLength(1);
            if (m != l) return;
            int mx = int.MinValue;
            int imx= -1;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, i] > mx)
                {
                    mx = matrix[i, i];
                    imx = i;
                }
            }
            for (int i = 0; i < matrix.GetLength(0);i++)
            {
                (matrix[i, imx], matrix[imx, i]) = (matrix[imx, i], matrix[i, imx]);
            }
            // end

        }
        public int[,] Task5(int[,] matrix)
        {
            int[,] answer = null;

            // code here
            int mxs = int.MinValue;
            int imxs = -1;
            int m= matrix.GetLength(0)-1; int l= matrix.GetLength(1);
            answer = new int[m, l];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int sum = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        sum += matrix[i, j];
                    }
                }
                if (sum > mxs)
                {
                    mxs = sum;
                    imxs = i;
                }
            }
            for (int i = 0; i < imxs; i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    answer[i, j] = matrix[i , j];
                }
            }
            for (int i = imxs; i < matrix.GetLength(0)-1; i++)
            {
                for (int j = 0;j < matrix.GetLength(1); j++)
                {
                    answer[i, j] = matrix[i + 1, j];
                }
            }
            // end

            return answer;
        }
        public void Task6(int[,] matrix)
        {

            // code here
            int il = matrix.GetLength(0);
            int mn = int.MaxValue; int imn = -1;
            int mx = int.MinValue; int imx = -1;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int n = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < 0)
                    {
                        n++;
                    }
                }
                if (n < mn)
                {
                    mn = n; imn = i;
                }
                if (n > mx)
                {
                    mx = n; imx = i;
                }
            }
            if (mn == mx) return;
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                (matrix[imn, i], matrix[imx, i]) = (matrix[imx, i], matrix[imn, i]);
            }
            
            // end

        }
        public int[,] Task7(int[,] matrix, int[] array)
        {
            int[,] answer = null;

            // code here
            int m= matrix.GetLength(0);
            int l= matrix.GetLength(1);
            answer = new int[m, l + 1];
            int ar = array.Length;
            if (m != ar) return matrix;
            int mn = int.MaxValue; int jmx = -1;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0;j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < mn)
                    {
                        mn= matrix[i, j]; jmx = j;
                    }
                }
            }
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j <=l; j++)
                {
                    if (j <= jmx) 
                    { 
                        answer[i, j] = matrix[i, j]; 
                    }
                    else if (j == jmx + 1) 
                    {
                        answer[i, j] = array[i]; 
                    }
                    else 
                    { 
                        answer[i, j] = matrix[i, j - 1]; 
                    }
                }
            }
            
            // end

            return answer;
        }
        public void Task8(int[,] matrix)
        {

            // code here
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                int n = 0;
                int p = 0;
                int mx = int.MinValue; int imx = -1;
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    
                    if (matrix[j, i] > mx)
                    {
                        mx = matrix[j, i];
                        imx = j;
                    }
                    if (matrix[j, i] < 0)
                    {
                        n++;
                    }
                    if (matrix[j, i] > 0)
                    {
                        p++;
                    }
                }
                if (p > n)
                {
                    matrix[imx, i] = 0;
                }
                if (p<n)
                {
                    matrix[imx, i] = imx;
                }
            }
            // end

        }
        public void Task9(int[,] matrix)
        {

            // code here
            if (matrix.GetLength(0) != matrix.GetLength(1)) return;
            
            int n = matrix.GetLength(0)-1;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                matrix[i, 0] = 0;
                matrix[0, i] = 0;
                matrix[i, n] = 0;
                matrix[n,i]=0;
                
            }
            // end

        }
        public (int[] A, int[] B) Task10(int[,] matrix)
        {
            int[] A = null, B = null;

            // code here
            if (matrix.GetLength(0) != matrix.GetLength(1)) return (A,B);
            int v = 0;
            int n = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (i <= j)
                    {
                        v++;
                    }
                    else
                    {
                        n++;
                    }
                }
            }
            
            A = new int[v];B= new int[n];
            v = 0;
            n = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (i <= j)
                    {
                        A[v]=matrix[i,j];
                        v++;
                    }
                    else
                    {
                        B[n]=matrix[i,j];
                        n++;
                    }
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
                int[] ar = new int[matrix.GetLength(0)];
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    ar[j] = matrix[j, i];
                }
                Array.Sort(ar);
                if (i % 2 == 0)
                {
                    Array.Reverse(ar);
                }
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    matrix[j,i]=ar[j];
                }
            }
                
            // end

        }
        public void Task12(int[][] array)
        {

            // code here
            if (array == null) return;

            int[] sums = new int[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                sums[i] = 0;
                if (array[i] != null)
                {
                    for (int k = 0; k < array[i].Length; k++)
                    {
                        sums[i] = sums[i] + array[i][k];
                    }
                }
            }

            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = 0; j < array.Length - 1 - i; j++)
                {
                    int countCurrent = 0;
                    int countNext = 0;

                    if (array[j] != null)
                        countCurrent = array[j].Length;
                    if (array[j + 1] != null)
                        countNext = array[j + 1].Length;

                    bool needToSwap = false;

                    if (countCurrent < countNext)
                    {
                        needToSwap = true;
                    }
                    else if (countCurrent == countNext)
                    {
                        if (sums[j] < sums[j + 1])
                        {
                            needToSwap = true;
                        }
                    }

                    if (needToSwap)
                    {
                        int[] tempRow = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = tempRow;

                        int tempSum = sums[j];
                        sums[j] = sums[j + 1];
                        sums[j + 1] = tempSum;
                    }
                }
            }
            // end

        }
    }
}
