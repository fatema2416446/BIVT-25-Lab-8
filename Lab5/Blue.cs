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

            
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            for (int i = 0; i < n; i++)
            {
                int c = 0;
                double sum = 0;
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        c++;
                        sum += matrix[i, j];
                    }
                }
                if (c > 0)
                {
                    answer[i] = sum / c;
                }
                else
                {
                    answer[i] = 0;
                }
            }
            // end
            return answer;
        }
        public int[,] Task2(int[,] matrix)
        {
            int[,] answer = null;

            // code here
            if (matrix.GetLength(0) == 0 && matrix.GetLength(1) == 0)
            {
                return new int[0, 0];
            }
            answer = new int[matrix.GetLength(0) - 1, matrix.GetLength(1) - 1];
            int iInd = 0;
            int jInd = 0;
            int mx = matrix[0,0];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0;j < matrix.GetLength(1); j++)
                {
                    if (matrix[i,j] > mx)
                    {
                        mx = matrix[i,j];
                        iInd = i;
                        jInd = j;
                    }
                }
            }
            int rows = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (i == iInd) continue;
                int cols = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (j == jInd) continue;
                    answer[rows,cols] = matrix[i,j];
                    cols++;
                }
                rows++;
            }
            // end

            return answer;
        }
        public void Task3(int[,] matrix)
        {

            // code here
            for (int i=0; i < matrix.GetLength(0); i++)
            {
                int mx = matrix[i,0];
                int mInd = 0;
                for (int j = 1;  j < matrix.GetLength(1); j++)
                {
                    if (matrix[i,j] > mx)
                    {
                        mx = matrix[i,j];
                        mInd = j;
                    }
                }
                for (int j = mInd; j < matrix.GetLength(1)-1; j++)
                {
                    matrix[i,j] = matrix[i,j+1];
                }
                matrix[i,matrix.GetLength(1)-1] = mx;
            }
            // end

        }
        public int[,] Task4(int[,] matrix)
        {
            int[,] answer = null;

            // code here
            answer = new int[matrix.GetLength(0), matrix.GetLength(1)+1];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int mx = matrix[i,0];
                for (int j = 0; j < matrix.GetLength(1);j++)
                {
                    if (matrix[i,j] > mx)
                    {
                        mx = matrix[i,j];   
                    }
                }
                for (int j = 0; j < matrix.GetLength(1)-1; j++)
                {
                    answer[i, j] = matrix[i, j];
                }
                answer[i, matrix.GetLength(1)-1] = mx;
                answer[i,matrix.GetLength(1)] = matrix[i, matrix.GetLength(1) - 1];
            }
            // end

            return answer;
        }
        public int[] Task5(int[,] matrix)
        {
            int[] answer = null;

            // code here
            int c = 0;
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0;j < cols; j++)
                {
                    if ((i + j) % 2 != 0)
                    {
                        c++;
                    }
                }
            }
            answer = new int[c];
            int ind = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if ((i + j) % 2 != 0)
                    {
                        answer[ind++] = matrix[i, j];
                    }
                }
            }
            // end

            return answer;
        }
        public void Task6(int[,] matrix, int k)
        {

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            int mxD = int.MinValue;
            int indMxD = 0;
            int ng = 0;
            int indNg = -1;

            if (n != m) return;
            if (k < 0 || k >= m) return;
            for (int i = 0;i < n; i++)
            {
                if (matrix[i,i] > mxD)
                {
                    mxD = matrix[i,i];
                    indMxD = i;
                }
            }
            for (int i = 0; i < n ; i++)
            {
                if (matrix[i,k] < 0)
                {
                    ng = matrix[i,k];
                    indNg = i;
                    break;
                }
            }
            if (indMxD == indNg || indNg == -1)
            {
                return ;
            }
            for (int j = 0; j < m; j++)
            {
                (matrix[indMxD, j], matrix[indNg, j]) = (matrix[indNg, j], matrix[indMxD, j]);
            }
            // end

        }
        public void Task7(int[,] matrix, int[] array)
        {

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            if (m < 2) return;
            int mx = matrix[0, m - 2];
            int indMx = m-2;
            int mxRow = 0;

            if (array == null || array.Length != m) return;
            for (int i = 0 ;i<n ; i++)
            {
                if (matrix[i,indMx] > mx)
                {
                    mx = matrix[i,indMx];
                    mxRow = i;
                }
            }
            for (int j = 0; j < m; j++)
            {
                matrix[mxRow, j] = array[j];
            }     
            // end
        }
        public void Task8(int[,] matrix)
        {

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            for (int j = 0 ; j < m ; j++)
            {
                int ind = 0;
                for (int i = 0; i < n; i++)
                {
                    if (matrix[i, j] > matrix[ind, j])
                    {
                        ind = i;
                    }
                }
                    if (ind < n / 2)
                    {
                        int s = 0;
                        for (int i = ind + 1 ; i < n ; i++)
                        {
                            s += matrix[i,j];
                            matrix[0,j] = s;
                        }
                    }
            }
            // end

        }
        public void Task9(int[,] matrix)
        {

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            for (int i = 0; i + 1 < n ; i+=2)
            {
                int mxOdd = matrix[i, 0];
                int mxOddCol = 0;
                for (int j =1; j < m; j++)
                {
                    if (matrix[i,j] > mxOdd)
                    {
                        mxOdd= matrix[i, j];
                        mxOddCol = j;
                    }
                }
                int mxEv = matrix[i+1,0];
                int mxEvCol = 0;
                for (int j = 1;j<m; j++)
                {
                    if (matrix[i+1,j] > mxEv)
                    {
                        mxEv= matrix[i+1,j];
                        mxEvCol = j;
                    }
                }
                (matrix[i, mxOddCol], matrix[i + 1, mxEvCol]) = (matrix[i + 1, mxEvCol], matrix[i, mxOddCol]);
            }
            
            // end

        }
        public void Task10(int[,] matrix)
        {

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            int mx = matrix[0, 0];
            int mxI = 0;
            if (n != m) return;
            for (int i = 0; i < n; i++)
            {
                if (matrix[i,i] > mx)
                {
                    mx= matrix[i, i];
                    mxI = i;
                }
            }
            for (int i = 0; i < mxI; i++)
            {
                for (int j=i+1; j < n; j++)
                {
                    matrix[i, j] = 0;
                }
            }
            // end

        }
        public void Task11(int[,] matrix)
        {

            // code here
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            int[] pos = new int[n];
            for (int i = 0; i < n; i++)
            {
                int c = 0;
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        c++;
                    }
                }
                pos[i] = c;
            }
            for (int i = 1; i < n; i++)
            {
                int kCnt = pos[i];
                int[] tempRow = new int[m];
                for (int j = 0; j < m; j++)
                    tempRow[j] = matrix[i, j];
                int k = i - 1;
                while (k >= 0 && pos[k] < kCnt)
                {
                    pos[k + 1] = pos[k];
                    for (int j = 0; j < m; j++)
                        matrix[k + 1, j] = matrix[k, j];

                    k--;
                }
                pos[k + 1] = kCnt;
                for (int j = 0; j < m; j++)
                    matrix[k + 1, j] = tempRow[j];
                // end

            }
        }
        public int[][] Task12(int[][] array)
        {
            int[][] answer = null;

            // code here
            double totalSum = 0;
            double avg = 0;
            int cnt = 0;
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    totalSum += array[i][j];
                    cnt++;
                }
            }

            avg = totalSum / cnt;

            double rowSum = 0;
            int rowCnt = 0;
            double rowAvg = 0;
            int newLen = 0;
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    rowSum += array[i][j];
                    rowCnt++;
                }

                rowAvg = rowSum / rowCnt;

                if (rowAvg >= avg)
                {
                    newLen++;
                }
                rowSum = 0;
                rowCnt = 0;
                rowAvg = 0;
            }
            if (newLen > 0)
            {
                answer = new int[newLen][];
            }
            int idx = 0;
            rowSum = 0;
            rowCnt = 0;
            rowAvg = 0;
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    rowSum += array[i][j];
                    rowCnt++;
                }

                rowAvg = rowSum / rowCnt;

                if (rowAvg >= avg)
                {
                    answer[idx] = array[i];
                    idx++;
                }

                rowSum = 0;
                rowCnt = 0;
                rowAvg = 0;
            }
            // end

            return answer;
        }
    }
}

