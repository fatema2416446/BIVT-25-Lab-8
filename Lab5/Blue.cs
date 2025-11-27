using System.Linq;
using System.Runtime.InteropServices;

namespace Lab5
{
    public class Blue
    {
        public double[] Task1(int[,] matrix)
        {
            double[] answer = null;

            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            int count = 0;
            
            answer = new double[rows];
            
            for (int i = 0; i < rows; i++)
            {
                int sum = 0;
                double number = 0; //количество положительных элементов
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        sum += matrix[i, j];
                        number++;
                    }
                }
                
                double average = 0;
                
                if (number == 0)
                    average = 0;
                else
                    average = sum / number;
                count++;
                
                answer[i] = average; //добавляем в массив
            }
            return answer;
        }
        public int[,] Task2(int[,] matrix)
        {
            int[,] answer = null;

            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            int maxElement = matrix[0, 0];
            int maxRowIndex = 0;
            int maxColumnIndex = 0;
            
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] > maxElement)
                    {
                        maxElement = matrix[i, j];
                        maxRowIndex = i;
                        maxColumnIndex = j;
                    }
                }
            }
            
            answer = new int[rows-1, cols-1]; //матрица с удаленным строкой и столцом

            int answerRowIndex = 0;
            for (int i = 0; i < rows; i++)
            {
                if (i == maxRowIndex)
                    continue;
                
                int answerColumnIndex = 0;
                for (int j = 0; j < cols; j++)
                {
                    if (j == maxColumnIndex)
                        continue;
                    
                    if (i!= maxRowIndex && j!= maxColumnIndex) //если элемент не находится на нужном пересечении, то
                        answer[answerRowIndex, answerColumnIndex++] = matrix[i, j]; //сначала по столбцам
                }
                answerRowIndex++;//потом по строкам
            }
            // end

            return answer;
        }
        public void Task3(int[,] matrix)
        {

            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                int indexMaxElement = 0;
                int maxElement = matrix[i,0];
                
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] > maxElement)
                    {
                        maxElement = matrix[i, j];
                        indexMaxElement = j;
                    }
                }

                for (int k = indexMaxElement; k < cols-1; k++)
                {
                    matrix[i, k] = matrix[i, k+1];
                }

                matrix[i, cols - 1] = maxElement;
            }
            // end

        }

        public int[,] Task4(int[,] matrix)
        {
            int[,] answer = null;

            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            int[] temprorary = new int[rows];

            for (int i = 0; i < rows; i++)
            {
                int indexMaxElement = 0;
                int maxElement = matrix[i, 0];

                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] > maxElement)
                    {
                        maxElement = matrix[i, j];
                        indexMaxElement = j;
                    }
                }

                temprorary[i] = maxElement;
            }

            answer = new int[rows, cols + 1];

            for (int i = 0; i < rows; i++)
            {
                int answerJ = 0;
                for (int j = 0; j < cols; j++)
                {
                    if (j == cols - 1)
                    {
                        answer[i, answerJ] = temprorary[i];
                        answerJ++;
                    }

                    answer[i, answerJ] = matrix[i, j];
                    answerJ++;
                }
                
            }
            // end

            return answer;
        }

        public int[] Task5(int[,] matrix)
        {
            int[] answer = null;

            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            answer = new int[rows * cols / 2];

            int index = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if ((i + j) % 2 != 0)
                    {
                        answer[index++] = matrix[i, j];
                    }
                }
            }
            // end

            return answer;
        }
        public void Task6(int[,] matrix, int k)
        {

            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            if (rows != cols)
                return;
            
            int n = rows;
            
            if (k >= n)
                return;

            int maxElement = matrix[0, 0];
            int maxRowIndex = 0;
            
            for (int i = 0; i < n; i++)
            {
                if (matrix[i, i] > maxElement)
                {
                    maxElement = matrix[i, i];
                    maxRowIndex = i;
                }
            }

            int firstNegativeRow = -1;
            
            for (int i = 0; i < n; i++)
            {
                if (matrix[i, k] < 0)
                {
                    firstNegativeRow = i;
                    break;
                }
            }

            if (firstNegativeRow == -1 || firstNegativeRow == maxRowIndex)
            {
                return;
            }

            int temprorary = 0;
            for (int j = 0; j < n; j++)
            {
                temprorary = matrix[maxRowIndex, j];
                matrix[maxRowIndex, j] = matrix[firstNegativeRow, j];
                matrix[firstNegativeRow, j] = temprorary;
            }
            // end

        }
        public void Task7(int[,] matrix, int[] array)
        {

            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            if (cols < 2)
            {
                return;
            }

            if (array.Length != cols)
            {
                return;
            }

            int maxElement = matrix[0, 0];
            int rowIndex = 0;
            
            for (int i = 0; i < rows; i++)
            {
                if (matrix[i, cols - 2] > maxElement) //cols - 2 индекс предпоследнего столбца
                {
                    maxElement = matrix[i, cols - 2];
                    rowIndex = i;
                }
            }

            for (int j = 0; j < cols; j++)
            {
                matrix[rowIndex, j] = array[j];
            }
            // end

        }
        public void Task8(int[,] matrix)
        {

            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int j = 0; j < cols; j++)
            {
                int indexMaxElement = 0;
                int maxElement = matrix[0, j];
                
                for (int i = 0; i < rows; i++)  //ищем макс элемент
                {
                    if (matrix[i, j] > maxElement)
                    {
                        maxElement = matrix[i, j];
                        indexMaxElement = i;
                    }
                }
                
                if (indexMaxElement < rows / 2) //выполняем, если в первой половине столбца
                {
                    int sum = 0;
                    for (int k = indexMaxElement + 1; k < rows; k++) //от этого элемента не вкл. ниже
                    {
                        sum+=matrix[k, j];
                    }
                    matrix[0, j] = sum;
                }
            }
            // end

        }
        public void Task9(int[,] matrix)
        {

            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            if (rows != cols)
                return;

            int n = rows;

            for (int i = 0; i < n-1; i += 2) //по строке
            {
                int oddRowIndex = i; //индекс нечетной строки
                int evenRowIndex = i + 1; //индекс четной строки

                int oddMaxElement = matrix[oddRowIndex, 0];
                int maxOddIndex = 0;
                
                for (int j = 0; j < n; j++) //по столбцу
                {
                    if (matrix[oddRowIndex, j] > oddMaxElement)
                    {
                        maxOddIndex = j;
                        oddMaxElement = matrix[oddRowIndex, j];
                    }
                }
                
                int evenMaxElement = matrix[evenRowIndex, 0];
                int maxEvenIndex = 0;
                
                for (int j = 0; j < n; j++) //по столбцу
                {
                    if (matrix[maxEvenIndex, j] > evenMaxElement)
                    {
                        maxOddIndex = j;
                        evenMaxElement = matrix[maxEvenIndex, j];
                    }
                }

                int temprorary = matrix[evenRowIndex, maxEvenIndex];
                matrix[evenRowIndex, maxEvenIndex] = matrix[oddRowIndex, maxOddIndex];
                matrix[oddRowIndex, maxOddIndex] = temprorary;
            }
            
            // end

        }
        public void Task10(int[,] matrix)
        {

            // code here

            // end

        }
        public void Task11(int[,] matrix)
        {

            // code here

            // end

        }
        public int[][] Task12(int[][] array)
        {
            int[][] answer = null;

            // code here

            // end

            return answer;
        }
    }
}