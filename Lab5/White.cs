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
            double srz = 0;
            double pe = 0;
            double count = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        pe += matrix[i, j];
                        count += 1;
                    }
                }
            }
            if (count > 0)
            {
                srz = pe / count;
            }
            average = srz;

            // end

            return average;
        }
        public (int row, int col) Task2(int[,] matrix)
        {
            int row = 0, col = 0;
            int min = matrix[0, 0];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < min)
                    {
                        min = matrix[i, j];
                        row = i;
                        col = j;
                    }
                }
            }
      

            return (row, col);
        }
        public void Task3(int[,] matrix, int k)
        {

            // code here
            if (k < 0 || k >= matrix.GetLength(1))
            {
                return;

            }
            int mr = 0;
            int Mzn = matrix[0, k];
            for (int i = 1; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, k] > Mzn)
                {
                    Mzn = matrix[i, k];
                    mr = i;
                }
            }
            if (mr != 0)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    int t = matrix[0, j];
                    matrix[0, j] = matrix[mr, j];
                    matrix[mr, j] = t;

                }
            }
            // end

        }
        public int[,] Task4(int[,] matrix)
        {
            int[,] answer = null;

            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            if (rows == 1)
            {
          
                answer = new int[0, cols];
                return answer;
            }

           
            int minr = 0;
            int minz = matrix[0, 0];

            for (int i = 1; i < rows; i++)
            {
                if (matrix[i, 0] < minz)
                {
                    minz = matrix[i, 0];
                    minr = i;
                }
            }

           
            answer = new int[rows - 1, cols];

            for (int i = 0, nr = 0; i < rows; i++)
            {
                if (i == minr) continue;

                for (int j = 0; j < cols; j++)
                {
                    answer[nr, j] = matrix[i, j];
                }
                nr++;
            }


            // end

            return answer;
        }
        public int Task5(int[,] matrix)
        {
            int sum = 0;

            // code here
            if (matrix.GetLength(0) != matrix.GetLength(1))
                return 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                sum += matrix[i, i];
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
                int fnind = -1;
                int maxInd = -1;
                int lnind = -1;

                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] < 0)
                    {
                        if (fnind == -1)
                        {
                            fnind = j;
                        }
                        lnind = j;
                    }
                }

             
                if (fnind == -1)
                {
                    continue;
                }

                
                for (int j = 0; j < fnind; j++)
                {
                    if (maxInd == -1 || matrix[i, j] > matrix[i, maxInd])
                    {
                        maxInd = j;
                    }
                }

               
                if (maxInd == -1)
                {
                    continue;
                }

             
                int temp = matrix[i, maxInd];
                matrix[i, maxInd] = matrix[i, lnind];
                matrix[i, lnind] = temp;
            }
        }


        // end


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
                    if (matrix[i, j] < 0)
                    {
                        count++;
                    }
                }
            }

          
            if (count == 0)
            {
                return null;
            }

            negatives = new int[count];
            int ind = 0;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] < 0)
                    {
                        negatives[ind++] = matrix[i, j];
                    }
                }
            }

            // end

            return negatives;
        }
        public void Task8(int[,] matrix)
        {

            // code here
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix.GetLength(1) == 1)
                    continue;

                int maxi = 0;

                for (int j = 1; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > matrix[i, maxi])
                    {
                        maxi = j;
                    }
                }

                if (maxi == 0) 
                {
                    matrix[i, 1] *= 2;
                }
                else if (maxi == matrix.GetLength(1) - 1) 
                {
                    matrix[i, maxi - 1] *= 2;
                }
                else 
                {
                    int left = matrix[i, maxi - 1];
                    int right= matrix[i, maxi + 1];

                    if (left <= right)
                    {
                        matrix[i, maxi - 1] *= 2;
                    }
                    else
                    {
                        matrix[i, maxi + 1] *= 2;
                    }
                }
            }
            // end

        }
        public void Task9(int[,] matrix)
        {

            // code here
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int left = 0;
                int right = matrix.GetLength(1) - 1;

                while (left < right)
                {
                    int temp = matrix[i, left];
                    matrix[i, left] = matrix[i, right];
                    matrix[i, right] = temp;
                    left++;
                    right--;
                }
            }
            // end

        }
        public void Task10(int[,] matrix)
        {

            // code here
            if (matrix.GetLength(0) != matrix.GetLength(1))
                return;

            int n = matrix.GetLength(0);
            int midr = n / 2;

            for (int i = midr; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (j <= i) 
                    {
                        matrix[i, j] = 1;
                    }
                }
            }
            // end

        }
        public int[,] Task11(int[,] matrix)
        {
            int[,] answer = null;

            // code here
            int rows = 0;
            bool[] kr = new bool[matrix.GetLength(0)];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                bool h = false;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        h = true;
                        break;
                    }
                }

                if (!h)
                {
                    kr[i] = true;
                    rows++;
                }
            }

            if (rows == 0)
            {
                return new int[0, matrix.GetLength(1)];
            }

            answer = new int[rows, matrix.GetLength(1)];
            int nr = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (kr[i])
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        answer[nr, j] = matrix[i, j];
                    }
                    nr++;
                }
            }
            // end

            return answer;
        }
        public void Task12(int[][] array)
        {

            // code here
            int[] sums = new int[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                sums[i] = 0;
                for (int j = 0; j < array[i].Length; j++)
                {
                    sums[i] += array[i][j];
                }
            }

            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = 0; j < array.Length - i - 1; j++)
                {
                    if (sums[j] > sums[j + 1])
                    {
                    
                        int tSum = sums[j];
                        sums[j] = sums[j + 1];
                        sums[j + 1] = tSum;

                       
                        int[] tR = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = tR;
                    }
                }
            }
            // end

        }
    }
}
