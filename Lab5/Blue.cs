using System.Linq;
using System.Runtime.InteropServices;

namespace Lab5
{
    public class Blue
    {
        public double[] Task1(int[,] matrix)
        {
            double[] answer = new double[matrix.GetLength(0)];

            // code here
            double sum =0 ,c;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                sum = 0;c = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > 0) { sum += matrix[i, j]; c++; }
                }
                if (sum > 0)answer[i] = sum/c;
                else answer[i] = 0;
            }
            // end

            return answer;
        }
        public int[,] Task2(int[,] matrix)
        {
            int[,] answer = new int[matrix.GetLength(0)-1,matrix.GetLength(1)-1];

            // code here
            int max1 = int.MinValue,row=0,col=0;
            bool f= false;
            for (int i =0;i < matrix.GetLength(0); i++)
            {
                for (int j=0;j< matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > max1) max1 = matrix[i, j];
                }
            }
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == max1) 
                    { 
                        row = i;
                        col = j;
                        f = true;
                        break;
                    }
                }
                if (f) break;
            }

            for(int i=0,k=0; i < matrix.GetLength(0); i++)
            {
                if (i == row) continue;
                for(int j=0,l=0; j< matrix.GetLength(1); j++)
                {
                    if (j == col) continue;
                    answer[k,l]=matrix[i,j];
                    l++;
                }
                k++;
            }
            // end

            return answer;
        }
        public void Task3(int[,] matrix)
        {

            // code here
            int max1 = int.MinValue,col=0,temp;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                col = 0; temp = 0; max1=int.MinValue;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > max1) { max1 = matrix[i, j]; col = j; }
                }
                while (col < matrix.GetLength(1)-1)
                {
                    temp = matrix[i,col];
                    matrix[i,col] = matrix[i,col+1];
                    matrix[i, col+1] = temp;
                    col++;
                }
            }
            // end

        }
        public int[,] Task4(int[,] matrix)
        {
            int[,] answer = new int[matrix.GetLength(0), matrix.GetLength(1)+1];
           
            // code here
            int[] max = new int[matrix.GetLength(0)];
            int maxel;
            for (int i=0; i < matrix.GetLength(0); i++)
            {
                maxel = int.MinValue;
                for (int j=0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i,j] > maxel) maxel = matrix[i,j];
                }
                for (int j = 0,r=0; r < answer.GetLength(1);)
                {
                    if (r!=answer.GetLength(1)-2)
                    {
                        answer[i, r] = matrix[i, j];
                        r++;
                        j++;
                    }
                    else
                    {
                        answer[i, r] = maxel;
                        r++;
                    }
                }
            }
            // end

            return answer;
        }
        public int[] Task5(int[,] matrix)
        {
            int[] answer = new int[(matrix.GetLength(0)*matrix.GetLength(1))/2];

            // code here
            int a = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                    if ((i + j) % 2 != 0)
                    {
                        answer[a] = matrix[i, j];
                        a++;
                    }
            } 
            // end

            return answer;
        }
        public void Task6(int[,] matrix, int k)
        {

            // code here
            if (matrix.GetLength(0) != matrix.GetLength(1)) return;
            int max1 = int.MinValue,index1=0,index2=0;
            bool f = false;
            int temp;
            if (k < matrix.GetLength(1))
            {
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        if (i == j)
                        {
                            if (matrix[i, i] > max1)
                            {
                                max1 = matrix[i, i];
                                index1 = i;

                            }
                        }
                        if (!f && j == k && matrix[i, j] < 0)
                        {
                            f = true;
                            index2 = i;
                        }
                    }
                }
                if (f && index1 != index2)
                    for (int r = 0; r < matrix.GetLength(1); r++)
                    {
                        temp = matrix[index1, r];
                        matrix[index1, r] = matrix[index2, r];
                        matrix[index2, r] = temp;
                    }
            }
            // end

        }
        public void Task7(int[,] matrix, int[] array)
        {

            // code here
            int max1 = int.MinValue, index = 0;
            if (matrix.GetLength(1) >= 2 && array.Length == matrix.GetLength(1))
            {
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        if (matrix[i, j] > max1 && j == matrix.GetLength(1)-2)
                        {
                            max1 = matrix[i, j];
                            index = i;
                        }
                    }
                }
                for(int r = 0;r < matrix.GetLength(1); r++)
                {
                    matrix[index,r]=array[r];
                }
            }
            // end


        }
            
        public void Task8(int[,] matrix)
        {
            int max1,sum,row;
            // code here
            for (int j=0; j < matrix.GetLength(1); j++)
            {
                max1 = int.MinValue; sum = 0; row = 0;
                for (int i=0; i < matrix.GetLength(0); i++)
                {
                    if (matrix[i,j] > max1)
                    {
                        max1 = matrix[i,j];
                        sum = 0;
                        row = i+1;
                    }
                    sum+= matrix[i,j];
                }
                sum -= max1;
                if (row <= matrix.GetLength(0)/2)
                {
                    matrix[0, j] = sum;
                }
            }
            // end

        }
        public void Task9(int[,] matrix)
        {

            // code here
            if (matrix.GetLength(0) > 1)
            {
                int max1=int.MinValue,temp=0,max2=int.MinValue,index1=0,index2=0; 
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    if (i % 2 == 0)
                    {
                        max1 = int.MinValue;
                        for (int j = 0; j < matrix.GetLength(1); j++)
                        {
                            if (matrix[i, j] > max1)
                            {
                                max1 = matrix[i, j];
                                index1 = j;
                            }
                        }
                    }
                    else
                    {
                        max2 = int.MinValue;
                        for (int j = 0; j < matrix.GetLength(1); j++)
                        {
                            if (matrix[i, j] > max2)
                            {
                                max2 = matrix[i, j];
                                index2 = j;
                            }
                        }
                        temp = matrix[i-1,index1];
                        matrix[i - 1, index1] = matrix[i, index2];
                        matrix[i, index2] = temp;
                    }
                }
            }
            // end

        }
        public void Task10(int[,] matrix)
        {

            // code here

            if (matrix.GetLength(0) != matrix.GetLength(1)) return;
            
            int max1 = int.MinValue,index=0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, i] > max1)
                {
                    max1 = matrix[i, i];
                    index = i;
                }
            }
            int j;
            for (int i = 0; i < index; i++)
            {
                for (j=i+1; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = 0;
                }
            }
                //end

        }
        public void Task11(int[,] matrix)
        {

            // code here

            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            int[] arr = new int[n];
            int c;
            for (int i =0;i< n;i++)
            {
                c = 0;
                for (int j =0;j< m; j++)
                {
                    if (matrix[i, j] > 0) c++;
                }
                arr[i] = c;
            }
            for (int r = 1; r < n; r++)
            {
                int k = r;
                while (k > 0 && arr[k] > arr[k - 1])
                {
                    int temp1 = arr[k];
                    arr[k] = arr[k - 1];
                    arr[k - 1] = temp1;

                    for (int j = 0; j < m; j++)
                    {
                        int temp2 = matrix[k, j];
                        matrix[k, j] = matrix[k - 1, j];
                        matrix[k - 1, j] = temp2;
                    }
                    k--;
                }
            }

            // end

        }
        public int[][] Task12(int[][] array)
        {

            // code here
            int n=array.Length,c=0,k=0,a=0;
            double sum = 0,avg;
            double strsum =0;
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    sum+= array[i][j];
                    c++;
                }
            }
            avg = sum / c;
            for (int i = 0; i < array.Length; i++)
            {
                strsum = 0; c = 0;
                for (int j = 0; j < array[i].Length; j++)
                {
                    strsum += array[i][j];
                    c++;
                }
                if ((strsum / c) < avg) k++;
            }
            int[] indexes = new int[k];
            for (int i = 0; i < array.Length; i++)
            {
                strsum = 0; c = 0;
                for (int j = 0; j < array[i].Length; j++)
                {
                    strsum += array[i][j];
                    c++;
                }
                if ((strsum / c) < avg)
                {
                    indexes[a]=i;
                    a++;
                }
            }
            int[][] answer = new int[array.Length-k][];

            int r = 0;
            for (int i = 0,g=0; i < array.Length; i++)
            {
                if (r < indexes.Length && i == indexes[r])
                {
                    r++;
                    continue;
                }
                answer[g] = new int[array[i].Length];
                for (int j = 0; j < array[i].Length; j++)
                {
                    answer[g][j] = array[i][j];
                }
                g++;
            }

            // end

            return answer;
        }
    }
}
