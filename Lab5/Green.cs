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
            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);
            
            answer = new int[rows];
            
            for (int i = 0; i < rows; i++)
            {
                int minElement = matrix[i, 0];
                int minIndex = 0;
                for (int j = 0; j < columns; j++)
                {
                    if (matrix[i, j] < minElement)
                    {
                        minElement = matrix[i, j];
                        minIndex = j;
                    }
                }
                answer[i] = minIndex;
            }
            // end

            return answer;
        }
        public void Task2(int[,] matrix)
        {

            // code here
            int  rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);
            
            for (int i = 0; i < rows; i++)
            {
                int maxElement = matrix[i, 0];
                int maxIndex = 0;
                for (int j = 0; j < columns; j++)
                {
                    if (matrix[i, j] > maxElement)
                    {
                        maxElement = matrix[i, j];
                        maxIndex = j;
                    }
                }

                for (int k = 0; k < maxIndex; k++)
                {
                    if (matrix[i, k] < 0)
                        matrix[i, k] = (int) Math.Floor((double)matrix[i, k] / maxElement);
                }
            }
            
            // end

        }
        public void Task3(int[,] matrix, int k)
        {

            // code here
            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);
            
            if (rows != columns)
                return;
            if (k >= columns)
                return;

            int maxElement = matrix[0, 0];
            int indexMaxColumn = 0;
            for (int i = 0; i < rows; i++)
            {
                if (matrix[i, i] > maxElement)
                {
                    maxElement = matrix[i, i];
                    indexMaxColumn = i;
                }
            }

            if (indexMaxColumn == k)
                return;
            
            for (int l = 0; l < rows; l++)
            {
                int temprorary = matrix[l, k];
                matrix[l, k] = matrix[l, indexMaxColumn];
                matrix[l, indexMaxColumn] = temprorary;
            }

            // end

        }
        public void Task4(int[,] matrix)
        {

            // code here
            int  rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);

            if (rows != columns)
                return;

            int n = rows;
            
            int maxElement = matrix[0, 0];
            int maxRow = 0;
            int maxColumn = 0;
            for (int i = 0; i < rows; i++)
            {
                if (matrix[i, i] > maxElement)
                {
                    maxElement = matrix[i, i];
                    maxRow = i;
                    maxColumn = i;
                }
            }

            int[] temproraryRow = new int[n];
            int[] temproraryColumn = new int[n];
            
            for (int i = 0; i < n; i++)
            {
                temproraryRow[i] = matrix[maxRow, i];
                temproraryColumn[i] = matrix[i, maxColumn];
            }

            for (int i = 0; i < n; i++)
            {
                matrix[maxRow, i] = temproraryColumn[i];
            }

            for (int i = 0; i < n; i++)
            {
                matrix[i, maxColumn] = temproraryRow[i];
            }

            // end

        }

        public int[,] Task5(int[,] matrix)
        {
            int[,] answer = null;

            // code here
            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);
            
            int maxSum = 0;
            int rowIndex = 0;
            
            for (int i = 0; i < rows; i++)
            {
                int sum = 0;
                for (int j = 0; j < columns; j++)
                {
                    if (matrix[i, j] > 0)
                        sum += matrix[i, j];
                }
                if (sum > maxSum)
                {
                    maxSum = sum;
                    rowIndex = i;
                }
            }
            
            answer = new int[rows-1, columns];
            
            int rowNumber = 0;
            for (int i = 0; i < rows; i++)
            {
                if (i == rowIndex)
                    continue;
                for (int j = 0; j < columns; j++)
                {
                    answer[rowNumber, j] = matrix[i, j];
                }
                rowNumber++;
            }
            // end

        return answer;
        }
        public void Task6(int[,] matrix)
        {

            // code here
            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);
            int maxCount = 0;
            int minCount = columns; //максимально возможное количество отрицательных элементов строки
            int indexMaxCountRow = 0;
            int indexMinCountRow = 0;

            for (int i = 0; i < rows; i++)
            {
                int count = 0;
                for (int j = 0; j < columns; j++)
                {
                    if (matrix[i, j] < 0)
                        count++;
                }
                if (count > maxCount)
                {
                    maxCount = count;
                    indexMaxCountRow = i;
                }
                if (count < minCount)
                {
                    minCount = count;
                    indexMinCountRow = i;
                }
            }

            if (indexMaxCountRow == indexMinCountRow)
                return;
            
            for (int j = 0; j < columns; j++)
            {
                int temprorary = matrix[indexMaxCountRow, j];
                matrix[indexMaxCountRow, j] =  matrix[indexMinCountRow, j];
                matrix[indexMinCountRow, j] = temprorary;
            }
            // end

        }
        public int[,] Task7(int[,] matrix, int[] array)
        {
            int[,] answer = null;

            // code here
            int rows =  matrix.GetLength(0);
            int columns = matrix.GetLength(1);
            int minElement = matrix[0, 0];
            int minColumnIndex = 0;
            
            if (array.Length != rows)
            {
                return matrix;
            }
            
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if  (matrix[i, j] < minElement)
                        {
                            minElement = matrix[i, j];
                            minColumnIndex = j;
                        }
                }
            }
            answer = new int[rows, columns+1];
            
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j <= minColumnIndex; j++)
                {
                    answer[i, j] = matrix[i, j];
                }
                answer[i, minColumnIndex + 1] = array[i];
                for (int j = minColumnIndex + 1; j < columns; j++)
                {
                    answer[i, j+1] = matrix[i, j];
                }
            }
            // end

            return answer;
        }
        public void Task8(int[,] matrix)
        {

            // code here
            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);

            for (int i = 0; i < columns; i++)
            {
                int countNegative = 0;
                int countPositive = 0;
                for (int j = 0; j < rows; j++)
                {
                    if (matrix[j, i] > 0)
                        countPositive++;
                    if (matrix[j, i] < 0)
                        countNegative++;
                }
                
                int maxElement = matrix[0, 0];
                int indexRow = 0;
                for (int j = 0; j < rows; j++)
                {
                    if  (matrix[j, i] > maxElement)
                    {
                        maxElement = matrix[j, i];
                        indexRow = j;
                    }
                }
                
                if (countNegative < countPositive)
                    matrix[indexRow, i] = 0;
                
                else if (countNegative > countPositive)
                    matrix[indexRow, i] = indexRow;
            }
            // end

        }
        public void Task9(int[,] matrix)
        {

            // code here
            int  rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);

            if (rows != columns)
                return;

            for (int i = 0; i < rows; i++)
            {
                matrix[0, i] = 0;        //верхняя сторона
                matrix[i, 0] = 0;        //левая сторона
                matrix[rows - 1, i] = 0; //нижняя сторона
                matrix[i, rows - 1] = 0; //правая сторона
            }
            // end

        }
        public (int[] A, int[] B) Task10(int[,] matrix)
        {
            int[] A = null, B = null;

            // code here
            int  rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);
            
            if (rows != columns)
                return (null, null);

            int n = rows;

            A = new int[n * (n + 1) / 2];
            B = new int[n * (n - 1) / 2];

            int indexA = 0;
            int indexB = 0;
            
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (j >= i)
                    {
                        A[indexA] = matrix[i, j];
                        indexA++;
                    }
                    else
                    {
                        B[indexB] = matrix[i, j];
                        indexB++;
                    }
                }
            }
            // end

            return (A, B);
        }
        public void Task11(int[,] matrix)
        {

            // code here
            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);
            for (int j = 0; j < columns; j++)
            {
                int[] array = new int[rows];
                for (int i = 0; i < rows; i++)
                {
                    array[i] = matrix[i, j];
                }

                Array.Sort(array);
                if (j % 2 == 0)
                    Array.Reverse(array);
                
                for (int i = 0; i < rows; i++)
                {
                    matrix[i, j] = array[i];
                }
            }
            // end

        }
        public void Task12(int[][] array)
        {

            // code here
            int rows = array.Length;
            
            for (int i = 0; i < rows - 1; i++)
            {
                for (int j = 0; j < rows - i - 1; j++)
                {
                    int[] firstRow = array[j];
                    int[] secondRow = array[j + 1];
                    
                    bool needSwap = false;
                    if (firstRow.Length < secondRow.Length)
                    {
                        needSwap = true;
                    }
                    else if (firstRow.Length > secondRow.Length)
                    {
                        needSwap = false;
                    }
                    else
                    {
                        int firstRowSum = 0;
                        int secondRowSum = 0;
                        
                        //так как длины строк равны
                        int n = firstRow.Length;

                        for (int k = 0; k < n; k++)
                        {
                            firstRowSum += firstRow[k];
                            secondRowSum += secondRow[k];
                        }
                        
                        needSwap = firstRowSum < secondRowSum;
                    }

                    if (needSwap)
                    {
                        int[] temprorary = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temprorary;
                    }
                }
            }
            // end

        }
    }
}