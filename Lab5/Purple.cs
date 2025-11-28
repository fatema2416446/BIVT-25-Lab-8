using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Numerics;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;

namespace Lab5
{
    public class Purple
    {
        public int[] Task1(int[,] matrix)
        {
            int[] answer = null;

            // code here
            answer = new int[matrix.GetLength(1)];
            for (int column = 0; column < matrix.GetLength(1); column++)
            {
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    if (matrix[row,column] < 0)
                    {
                        answer[column]++;
                    }
                }
            }
            // end

            return answer;
        }
        public void Task2(int[,] matrix)
        {

            // code here
            for (int row = 0; row < matrix.GetLength(0);row++)
            {
                int MinIndex = -1, CurrMin = Int32.MaxValue;
                for (int column = 0;column < matrix.GetLength(1);column++)
                {
                    if (matrix[row,column] < CurrMin)
                    {
                        MinIndex = column;
                        CurrMin = matrix[row,column];
                    }
                }
                for (int column = MinIndex-1; column >= 0; column--)
                {
                    matrix[row, column+1] = matrix[row,column];
                }
                matrix[row, 0] = CurrMin;
            }
            // end

        }
        public int[,] Task3(int[,] matrix)
        {
            int[,] answer = null;

            // code here
            answer = new int[matrix.GetLength(0), matrix.GetLength(1)+1];
            for (int row = 0; row<matrix.GetLength(0);row++)
            {
                int MaxIndex = -1, CurrMax = Int32.MinValue;
                for (int column = 0; column < matrix.GetLength(1);column++)
                {
                    if (matrix[row,column] > CurrMax)
                    {
                        CurrMax = matrix[row,column];
                        MaxIndex = column;
                    }
                }
                for (int column = 0; column < matrix.GetLength(1)+1; column++)
                {
                    if (column <= MaxIndex)
                    {
                        answer[row,column] = matrix[row,column];
                    }
                    else
                    {
                        answer[row, column] = matrix[row, column - 1];
                    }
                }
            }
            // end

            return answer;
        }
        public void Task4(int[,] matrix)
        {

            // code here
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int MaxIndex = 1, CurrMax = Int32.MinValue, CurrSum = 0, CurrCount = 0;
                for (int column = 0; column < matrix.GetLength(1); column++)
                {
                    if (matrix[row, column] > CurrMax)
                    {
                        CurrMax = matrix[row, column];
                        MaxIndex = column;
                        CurrSum = 0;
                        CurrCount = 0;
                    }
                    else
                    {
                        if (matrix[row, column] > 0)
                        {
                            CurrSum += matrix[row, column];
                            CurrCount++;
                        }
                    }
                }
                if (CurrCount > 0)
                {
                    for (int column = 0; column < MaxIndex; column++)
                    {
                        if (matrix[row, column] < 0)
                        {
                            matrix[row, column] = CurrSum / CurrCount;
                        }
                    }
                }
            }
            // end

        }
        public void Task5(int[,] matrix, int k)
        {

            // code here
            int[] maxes = new int[matrix.GetLength(0)];
            for (int row = matrix.GetLength(0)-1;  row >= 0; row--)
            {
                int CurrMax = Int32.MinValue;
                for (int column = 0; column < matrix.GetLength(1); column++)
                {
                    if (matrix[row, column] > CurrMax)
                    {
                        CurrMax = matrix[row, column];
                    }
                }
                maxes[matrix.GetLength(0)-row-1] = CurrMax; 
            }
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                if (k >= 0 && k < matrix.GetLength(1))
                {
                    matrix[row, k] = maxes[row];
                }
            }
            // end

        }
        public void Task6(int[,] matrix, int[] array)
        {

            // code here
            if (matrix.GetLength(1) == array.Length)
            {
                for (int column = 0; column < matrix.GetLength(1); column++)
                {
                    int MaxIndex = -1, CurrMax = Int32.MinValue;
                    for (int row = 0; row < matrix.GetLength(0); row++)
                    {
                        if (matrix[row, column] > CurrMax)
                        {
                            CurrMax = matrix[row, column];
                            MaxIndex = row;
                        }
                    }
                    if (matrix[MaxIndex, column] < array[column])
                    {
                        matrix[MaxIndex, column] = array[column];
                    }
                }
            }
            // end

        }
        public void Task7(int[,] matrix)
        {

            // code here
            int[] mins = new int[matrix.GetLength(0)];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int CurrMin = Int32.MaxValue;
                for (int column = 0; column < matrix.GetLength(1); column++)
                {
                    if (matrix[row, column] < CurrMin)
                    {
                        CurrMin = matrix[row, column];
                    }
                }
                mins[row] = CurrMin;
            }
            int sorttill = matrix.GetLength(0);
            bool change = true;
            while (change)
            {
                change = false;
                for (int CurrRow = 0; CurrRow < sorttill - 1; CurrRow++)
                {
                    if (mins[CurrRow] < mins[CurrRow + 1])
                    {
                        for (int column = 0; column < matrix.GetLength(1); column++)
                        {
                            (matrix[CurrRow, column], matrix[CurrRow + 1, column]) = (matrix[CurrRow + 1, column], matrix[CurrRow, column]);
                        }
                        (mins[CurrRow], mins[CurrRow + 1]) = (mins[CurrRow + 1], mins[CurrRow]);
                        change = true;
                    }
                }
                sorttill--;
            }
        }
        public int[] Task8(int[,] matrix)
        {
            int[] answer = null;

            // code here
            if (matrix.GetLength(0) == matrix.GetLength(1))
            {
                int n = matrix.GetLength(0);
                answer = new int[2 * n - 1];
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int column = 0; column < matrix.GetLength(1); column++)
                    {
                        answer[n - 1 - row + column] += matrix[row, column];
                    }
                }
            }
            // end

            return answer;
        }
        public void Task9(int[,] matrix, int k)
        {

            // code here
            if (matrix.GetLength(0) == matrix.GetLength(1) && k < matrix.GetLength(0))
            {
                int MaxRow = -1, MaxColumn = -1, CurrMax = Int32.MinValue;
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int column = 0;column < matrix.GetLength(1); column++)
                    {
                        if (Math.Abs(matrix[row, column]) > CurrMax)
                        {
                            CurrMax = Math.Abs(matrix[row, column]);
                            MaxRow = row;
                            MaxColumn = column;
                        }
                    }
                }
                while (MaxRow != k)
                {
                    int moveR = Math.Sign(k - MaxRow);
                    for (int column = 0; column < matrix.GetLength(1); column++)
                    {
                        (matrix[MaxRow, column], matrix[MaxRow + moveR, column]) = (matrix[MaxRow + moveR, column], matrix[MaxRow, column]);
                    }
                    MaxRow += moveR;
                }
                while (MaxColumn != k)
                {
                    int moveC = Math.Sign(k - MaxColumn);
                    for (int row = 0; row < matrix.GetLength(0); row++)
                    {
                        (matrix[row, MaxColumn], matrix[row, MaxColumn + moveC]) = (matrix[row, MaxColumn + moveC], matrix[row, MaxColumn]);
                    }
                    MaxColumn += moveC;
                }
            }
            // end

        }
        public int[,] Task10(int[,] A, int[,] B)
        {
            int[,] answer = null;

            // code here
            if (A.GetLength(1) == B.GetLength(0))
            {
                answer = new int[A.GetLength(0),B.GetLength(1)];
                for (int row = 0; row < answer.GetLength(0); row++)
                {
                    for (int column = 0; column < answer.GetLength(1); column++)
                    {
                        for (int ind = 0; ind < A.GetLength(1);  ind++)
                        {
                            answer[row, column] += A[row, ind] * B[ind, column];
                        }
                    }
                }
            }
            // end

            return answer;
        }
        public int[][] Task11(int[,] matrix)
        {
            int[][] answer = null;

            // code here
            answer = new int[matrix.GetLength(0)][];
            int poscounter;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                poscounter = 0;
                for (int column = 0; column< matrix.GetLength(1); column++)
                {
                    if (matrix[row, column] > 0)
                    {
                        poscounter++;
                    }
                }
                answer[row] = new int[poscounter];
            }
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                poscounter = 0;
                for (int column = 0; column < matrix.GetLength(1); column++)
                {
                    if (matrix[row, column] > 0)
                    {
                        answer[row][poscounter++] = matrix[row,column];
                    }
                }
            }
            // end

            return answer;
        }
        public int[,] Task12(int[][] array)
        {
            int[,] answer = null;

            // code here
            double size = 0;
            foreach (int[] row in array)
            {
                size += row.Length;
            }
            size = Math.Ceiling(Math.Sqrt(size));
            answer = new int[(int)size, (int)size];
            int absoluteInd = 0;
            foreach (int[] row in array)
            {
                foreach (int element in row)
                {
                    answer[absoluteInd / (int)size, absoluteInd % (int)size] = element;
                    absoluteInd++;
                }
            }
            // end

            return answer;
        }
    }
}
