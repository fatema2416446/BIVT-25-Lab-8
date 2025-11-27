using System.Linq;
using System.Runtime.InteropServices;

namespace Lab5
{
    public class White
    {
        public double Task1(int[,] matrix)
        {
            int rows = matrix.GetLength(0), cols = matrix.GetLength(1);
            double average = 0;
            double sum = 0;
            double count = 0;


            // code here
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        sum += matrix[i, j];
                        count++;
                    }
                }
            }
            average = sum / count;
            // end

            return average;
        }
        public (int row, int col) Task2(int[,] matrix)
        {
            int m = matrix.GetLength(0), n = matrix.GetLength(1);
            int row = 0, col = 0;
            int minValue = matrix[0, 0];


            // code here
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (matrix[i, j] < minValue)
                    {
                        row = i;
                        col = j;
                        minValue = matrix[i, j];
                    }
                }
            }
            // end

            return (row, col);
        }
        public void Task3(int[,] matrix, int k)
        {

            // code here
            int rowForSub = 0;
            int rows = matrix.GetLength(0), cols = matrix.GetLength(1);
            int maxValue = int.MinValue;


            if (k < cols)
            {
                for (int i = 0; i < rows; i++)
                {
                    if (matrix[i, k] > maxValue)
                    {
                        maxValue = matrix[i, k];
                        rowForSub = i;
                    }
                }
                for (int j = 0; j < cols; j++)
                {
                    (matrix[0, j], matrix[rowForSub, j]) = (matrix[rowForSub, j], matrix[0, j]);
                }
            }
            // end

        }
        public int[,] Task4(int[,] matrix)
        {
            int[,] answer = null;

            // code here
            int rowForDel = 0;
            int rows = matrix.GetLength(0), cols = matrix.GetLength(1);
            int[,] newMatrix = new int[rows - 1, cols];
            int minValue = matrix[0, 0];


            for (int i = 0; i < rows; i++)
            {
                if (matrix[i, 0] < minValue)
                {
                    minValue = matrix[i, 0];
                    rowForDel = i;
                }
            }
            for (int i = 0; i < rows - 1; i++)
            {
                if (i < rowForDel)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        newMatrix[i, j] = matrix[i, j];
                    }
                }
                else
                {
                    for (int j = 0; j < cols; j++)
                    {
                        newMatrix[i, j] = matrix[i + 1, j];
                    }
                }
            }
            answer = new int[rows - 1, cols];
            for (int i = 0; i < rows - 1; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    answer[i, j] = newMatrix[i, j];
                }
            }
            // end

            return answer;
        }
        public int Task5(int[,] matrix)
        {
            int sum = 0;

            // code here
            int rows = matrix.GetLength(0), cols = matrix.GetLength(1);


            if (rows == cols)
            {
                for (int i = 0; i < rows; i++)
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
            int rows = matrix.GetLength(0), cols = matrix.GetLength(1);


            for (int i = 0; i < rows; i++)
            {
                int indexFirstNeg = -1, indexLastNeg = -1;
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] < 0)
                    {
                        if (indexFirstNeg == -1)
                        {
                            indexFirstNeg = j;
                        }
                        indexLastNeg = j;
                    }
                }
                if (indexFirstNeg == -1)
                {
                    continue;
                }
                int maxCol = -1;
                int maxValue = int.MinValue;
                for (int j = 0; j < indexFirstNeg; j++)
                {
                    if (matrix[i, j] > maxValue)
                    {
                        maxValue = matrix[i, j];
                        maxCol = j;
                    }
                }
                if (maxCol != -1)
                {
                    (matrix[i, maxCol], matrix[i, indexLastNeg]) = (matrix[i, indexLastNeg], matrix[i, maxCol]);
                }
            }
            // end

        }
        public int[] Task7(int[,] matrix)
        {
            int[] negatives = null;
            int countNeg = 0;
            int rows = matrix.GetLength(0), cols = matrix.GetLength(1);


            // code here
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] < 0)
                    {
                        countNeg++;
                    }
                }
            }

            if (countNeg > 0)
            {
                int index = 0;
                negatives = new int[countNeg];
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        if (matrix[i, j] < 0)
                        {
                            negatives[index++] = matrix[i, j];
                        }
                    }
                }
            }
            else negatives = null;
            // end

            return negatives;
        }
        public void Task8(int[,] matrix)
        {
            int rows = matrix.GetLength(0), cols = matrix.GetLength(1);


            // code here
            if (cols != 1)
            {
                for (int i = 0; i < rows; i++)
                {
                    int maxValue = matrix[i, 0];
                    int maxIndex = 0;
                    for (int j = 0; j < cols; j++)
                    {
                        if (matrix[i, j] > maxValue)
                        {
                            maxValue = matrix[i, j];
                            maxIndex = j;
                        }
                    }
                    if (maxIndex == 0)
                    {
                        matrix[i, maxIndex + 1] *= 2;
                    }
                    else if (maxIndex == cols - 1)
                    {
                        matrix[i, maxIndex - 1] *= 2;
                    }
                    else
                    {
                        if (matrix[i, maxIndex - 1] <= matrix[i, maxIndex + 1])
                            matrix[i, maxIndex - 1] *= 2;
                        else
                            matrix[i, maxIndex + 1] *= 2;
                    }
                }
            }
            // end
        }
        public void Task9(int[,] matrix)
        {

            // code here
            int rows = matrix.GetLength(0), cols = matrix.GetLength(1);


            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols / 2; j++)
                {
                    (matrix[i, j], matrix[i, cols - 1 - j]) = (matrix[i, cols - 1 - j], matrix[i, j]);
                }
            }
            // end

        }
        public void Task10(int[,] matrix)
        {

            // code here
            int rows = matrix.GetLength(0), cols = matrix.GetLength(1);


            if (rows == cols)
            {
                for (int i = rows / 2; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        if (j <= i) matrix[i, j] = 1;
                    }
                }
            }
            // end

        }
        public int[,] Task11(int[,] matrix)
        {
            int[,] answer = null;

            // code here
            int rows = matrix.GetLength(0), cols = matrix.GetLength(1);
            int amountStrForDel = 0;


            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        amountStrForDel++;
                        break;
                    }
                }
            }
            answer = new int[rows - amountStrForDel, cols];
            int index = 0;

            for (int i = 0; i < rows; i++)
            {
                Boolean hasZero = false;

                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        hasZero = true;
                        break;
                    }
                }
                if (!hasZero)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        answer[index, j] = matrix[i, j];

                    }
                    index++;
                }

            }
            // end

            return answer;
        }
        public void Task12(int[][] array)
        {

            // code here
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int k = 0; k < array.Length - i - 1; k++)
                {
                    int sumFirst = 0, sumSecond = 0;
                    for (int j = 0; j < array[k].Length; j++)
                    {
                        sumFirst += array[k][j];
                    }
                    for (int j = 0; j < array[k + 1].Length; j++)
                    {
                        sumSecond += array[k + 1][j];
                    }
                    if (sumFirst > sumSecond)
                    {
                        (array[k], array[k + 1]) = (array[k + 1], array[k]);
                    }
                }
            }
            // end

        }
    }
}
