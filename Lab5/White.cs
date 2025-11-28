using System.Data;
using System.Linq;
using System.Runtime.InteropServices;

namespace Lab5
{
    public class White
    {
        public double Task1(int[,] matrix)
        {
            double average = 0;

            // code here
            int cnt = 0;
            for (int i=0; i<matrix.GetLength(0); i++)
                for (int j=0; j<matrix.GetLength(1);j++)
                {
                if (matrix[i,j]>0)
                    {
                        cnt++;
                        average += matrix[i,j];
                    }
                }
            average /= cnt;
            // end

            return average;
        }
        public (int row, int col) Task2(int[,] matrix)
        {
            int row = 0, col = 0;
            int min = matrix[0, 0];
            // code here
            for (int i=0; i<matrix.GetLength(0); i++)
                for (int j=0; j<matrix.GetLength(1);j++)
                {
                if (matrix[i, j]<min)
                    {
                        min=matrix[i, j];
                        row = i; col=j;
                    }
                }
            // end

            return (row, col);
        }
        public void Task3(int[,] matrix, int k)
        {

            // code here
            int index = 0;
            int rows = matrix.GetLength(0), cols = matrix.GetLength(1), max = matrix[0, 0];
            for (int i=0; i<rows; i++)
            {
                for (int j=0; j<cols; j++)
                {
                    if ((j==k) && matrix[i,j]>max)
                    {
                        max=matrix[i,j];
                        index = i;
                    }
                }
            }
            for (int i=0; i<cols; i++)
            {
                (matrix[0, i], matrix[index, i]) = (matrix[index, i], matrix[0,i]);
            }
            // end

        }
        public int[,] Task4(int[,] matrix)
        {
            int[,] answer = null;

            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            int min = matrix[0, 0], index = 0;
            int[,] b = new int[rows-1, cols];
            for (int i=0; i<rows;i++)
            {
                if (matrix[i,0]<min)
                {
                    min=matrix[i,0];
                    index= i;
                }
            }
            for (int i=0;i<rows-1;i++)
            {
                if (i<index)
                {
                    for (int j=0; j<cols; j++)
                    {
                        b[i,j] = matrix[i,j];
                    }
                }
                else
                {
                    for (int j=0; j<cols;j++)
                        b[i,j]= matrix[i+1,j];
                }
            }
            answer = b;
            // end

            return answer;
        }
        public int Task5(int[,] matrix)
        {
            int sum = 0;

            // code here
            if (matrix.GetLength(0) == matrix.GetLength(1))
            {
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    sum += matrix[i, i];
                }
            }
            // end

            return sum;
        }
        public void Task6(int[,] matrix)
        {

            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            for (int i = 0; i < rows; i++)
            {
                int ind = -1;
                int neg = -1;
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] < 0)
                    {
                        neg = j;
                    }
                    else if (neg == -1 && (ind == -1 || matrix[i, j] > matrix[i, ind]))
                    {
                        ind = j;
                    }
                }
                if (ind != -1 && neg != -1 && ind != neg)
                {
                    (matrix[i, ind], matrix[i, neg]) = (matrix[i,neg], matrix[i, ind]);
                }
            }
            // end

        }
        public int[] Task7(int[,] matrix)
        {
            int[] negatives = null;

            // code here
            int count = 0;
            for (int i = 0; i<matrix.GetLength(0);i++)
            {
                for (int j = 0;j<matrix.GetLength(1);j++)
                {
                    if (matrix[i,j]<0)
                    {
                        count++;
                    }
                }
            }
            if (count == 0)
                return null;
            negatives = new int[count];
            int pos = 0;
            for (int i = 0; i<matrix.GetLength(0);i++)
            {
                for (int j = 0; j<matrix.GetLength(1);j++)
                {
                    if (matrix[i,j]<0)
                    {
                        negatives[pos]=matrix[i,j];
                        pos++;
                    }
                }
            }
            // end

            return negatives;
        }
        public void Task8(int[,] matrix)
        {

            // code here
            int rows=matrix.GetLength(0);
            int cols=matrix.GetLength(1);
            for (int i = 0; i < rows; i++)
            {
                if (cols==1)
                    continue; 
                int max = matrix[i, 0], index_max = 0;
                for (int j = 0; j<cols;j++)
                {
                    if (matrix[i,j]>max)
                    {
                        max = matrix[i, j];
                        index_max = j;
                    }
                }
                if (index_max==cols-1)
                {
                    matrix[i,index_max-1]*=2;
                }
                else if (index_max==0)
                {
                    matrix[i,index_max+1]*=2;
                }
                else
                {
                    if (matrix[i, index_max - 1] <= matrix[i, index_max + 1])
                    {
                        matrix[i, index_max -1] *= 2;
                    }
                    else
                    {
                        matrix[i, index_max + 1] *= 2;
                    }
                }   
            }
            // end

        }
        public void Task9(int[,] matrix)
        {

            // code here
            int rows = matrix.GetLength(0); 
            int cols = matrix.GetLength(1);
            for (int i=0;i<rows;i++)
            {
                int left=0, right=cols-1;
                for (int j=0;j<cols;j++)
                {
                    if (left<right)
                    {
                        (matrix[i, left], matrix[i, right]) = (matrix[i,right], matrix[i,left]);
                        left++;
                        right--;
                    }
                }
            }
            // end

        }
        public void Task10(int[,] matrix)
        {

            // code here
            int rows=matrix.GetLength(0);
            int cols=matrix.GetLength(1);
            if (rows == cols)
            {
                for (int i = 0; i < rows; i++)
                {
                    if (i >= (rows / 2))
                    {
                        for (int j = 0; j <= i; j++)
                        {
                            matrix[i, j] = 1;
                        }
                    }
                }
            }
            // end

        }
        public int[,] Task11(int[,] matrix)
        {
            int[,] answer = null;

            // code here
            int rows= matrix.GetLength(0);
            int cols= matrix.GetLength(1);
            int length = 0;
            for (int i = 0; i < rows; i++)
            {
                bool haszero = false;
                for (int j = 0; j < cols; j++)
                {
                    if ((matrix[i, j]==0))
                    {
                        haszero = true;
                        break;
                    }

                }
                if (!haszero)
                {
                    length++;
                }
            }
            int[,] answer2=new int[length,cols];
            int pos = 0;
            for (int i=0; i<rows;i++)
            {
                bool haszero=false;
                for (int j=0; j<cols; j++)
                {
                    if ((matrix[i, j] == 0))
                    {
                        haszero = true;
                        break;
                    }

                }
                if (!haszero)
                {
                    for (int j=0; j<cols;j++)
                    {
                        answer2[pos,j] = matrix[i, j];
                    }
                    pos++;
                }
            }
            answer = answer2;    

            // end

            return answer;
        }
        public void Task12(int[][] array)
        {

            // code here
            int[] sum = new int[array.Length];

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    sum[i] += array[i][j];
                }
            }

            for (int i = 0; i < sum.Length - 1; i++)
            {
                for (int j = 0; j < sum.Length - 1 - i; j++)
                {
                    if (sum[j] > sum[j + 1])
                    {
                        (array[j], array[j + 1]) = (array[j + 1], array[j]);
                        (sum[j], sum[j + 1]) = (sum[j + 1], sum[j]);
                    }
                }
            }
            // end

        }
    }
}