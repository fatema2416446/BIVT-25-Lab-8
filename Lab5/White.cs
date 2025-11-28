using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Lab5
{
    public class White
    {
        public double Task1(int[,] matrix)
        {
            double sum = 0;
            

            // code here
            int count = 0;
            int row=matrix.GetLength(0);
            int col=matrix.GetLength(1);
            for (int i = 0;i<row;i++)
            {
                for (int j = 0;j<col;j++)
                {
                    if (matrix[i,j] > 0)
                    {
                        sum += matrix[i,j];
                        count++;
                    }
                }
            }
            if (count == 0)
            {
                return 0;
            }

            // end

            return (double)sum/count ;
        }
        public (int row, int col) Task2(int[,] matrix)
        {
            int row = 0, col = 0;
            int minMat = matrix[0,0];   


            // code here
            int n=matrix.GetLength(0);
            int m=matrix.GetLength(1);
            for (int i = 0;i<n;i++)
            {
                for (int j = 0; j<m;j++)
                {
                    if (matrix[i,j]<minMat)
                    {
                        minMat = matrix[i,j];
                        row = i;
                        col = j;

                    }
                }
            }

            // end

            return (row, col);
        }
        public void Task3(int[,] matrix, int k)
        {

            // code here
            int rows=matrix.GetLength(0);
            int cols=matrix.GetLength(1);
            if (k < 0 || k >= cols)
                return;

            int maxrows = 0;
            int maxValue = matrix[0,k];

            for (int i = 1;i<rows;i++)
            {
                if (matrix[i,k]> maxValue)
                {
                    maxValue = matrix[i,k];
                    maxrows = i;
                }
            }
            if (maxValue == 0)
                return;

            for (int j = 0; j<cols;j++)
            {
                int temp=matrix[0,j];
                matrix[0, j] = matrix[maxrows, j];
                matrix[maxrows,j]=temp;    

            }
        
            // end

        }
        public int[,] Task4(int[,] matrix)
        {
            int[,] answer = null;

            // code here
            int rows= matrix.GetLength(0);
            int cols= matrix.GetLength(1);

            if (rows ==1)
            {
                answer = new int[0, 0];
                return answer;

            }
            int minRows = 0;
            int minvalue=matrix[0,0];

            for (int i = 1;i<rows;i++)
            {
                if ( matrix[i,0]< minvalue)
                {
                    minvalue= matrix[i,0];
                    minRows=i;
                }
            }
            answer=new int[rows-1, cols];
            int NewRows = 0;
            for (int i = 0; i < rows; i++)
            {
                if (minRows == i)
                    continue;

                for (int j = 0; j < cols; j++)
                {
                    answer[NewRows, j] = matrix[i, j];
                }

                NewRows++;
            }
            // end

            return answer;
        }
        public int Task5(int[,] matrix)
        {
            int sum = 0;

            // code here
            int rows= matrix.GetLength(0);
            int cols= matrix.GetLength(1);
            if (rows !=cols)
                return 0;   

            for (int i = 0;i<rows;i++)
            {
                sum += matrix[i,i];
            }

            // end

            return sum;
        }
        public void Task6(int[,] matrix)
        {
            if (matrix == null) return;

            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                int firstNegative = -1;
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] < 0)
                    {
                        firstNegative = j;
                        break;
                    }
                }

                if (firstNegative <= 0) continue;

                int maxIndex = 0;
                for (int j = 1; j < firstNegative; j++)
                {
                    if (matrix[i, j] > matrix[i, maxIndex])
                        maxIndex = j;
                }

                int lastNegative = -1;
                for (int j = cols - 1; j >= 0; j--)
                {
                    if (matrix[i, j] < 0)
                    {
                        lastNegative = j;
                        break;
                    }
                }

                if (lastNegative != -1)
                {
                    int temp = matrix[i, maxIndex];
                    matrix[i, maxIndex] = matrix[i, lastNegative];
                    matrix[i, lastNegative] = temp;
                }
            }
        }
        public int[] Task7(int[,] matrix)
        {
            int[] negatives = null;
           
            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            int count = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if ((matrix[i, j]) < 0)
                        count++;

                }
            }
            if (count == 0)
                return null;
            negatives = new int[count];
            int c = 0;
            for ( int i = 0; i < rows;i++)
            {
                for (int j=0;j<cols;j++)
                {
                    if (matrix[i,j] < 0)
                    {
                        negatives[c] = matrix[i, j];
                        c++;
                    }

                }
            }
            // end

            return negatives;
        }
        public void Task8(int[,] matrix)
        {

            // code here
            int rows= matrix.GetLength(0);
            int cols= matrix.GetLength(1);
            for (int i = 0; i < rows;i ++)
            {
                if (cols == 1)
                    continue;

                int maxindex = 0;
                for(int j = 0;j < cols;j++)
                {
                    if (matrix[i, j] > matrix[i,maxindex])
                        maxindex = j;
                }

                if (maxindex == 0)
                {
                    matrix[i, 1] *= 2;

                }
                else if (maxindex == (cols-1))
                {
                    matrix[i, cols - 2] *= 2;
                }
                else
                {
                    int left = matrix[i, maxindex - 1];
                    int right = matrix[i, maxindex+1];


                    if (left <= right)
                        matrix[i, maxindex - 1] *= 2;
                    else
                        matrix[i, maxindex+1] *= 2;


                }

                
            }
          

            // end

        }
        public void Task9(int[,] matrix)
        {

            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols / 2; j++)
                {
                    int temp = matrix[i, j];
                    matrix[i, j] = matrix[i, cols - 1 - j];
                    matrix[i, cols - 1 - j] = temp;
                }
            }

            // end

        }
        public void Task10(int[,] matrix)
        {

            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
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
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            int count  = 0;
            for (int i = 0; i < rows; i++)
            {
                bool zero = false;
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        zero = true;
                        break;
                    }

                }
                if (!zero)
                    count++;
            }
            if (count == 0)
            {
                answer = new int[0, cols];
                return answer;
            }
            answer = new int[count, cols];
            int count1 = 0;
            for ( int i = 0; i < rows;i++)
            {
                bool zero = false;
                for (int j = 0;j < cols;j++)
                {
                    if ( matrix[i, j] == 0)
                    {
                        zero = true; break;
                    }
                }
                if (!zero)
                {
                    for (int j = 0;j<cols;j++)
                    {
                        answer[count1, j] = matrix[i, j];

                    }
                    count1++;
                }
            }
      
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
