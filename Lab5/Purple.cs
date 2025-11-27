using System.Linq;
using System.Runtime.InteropServices;

namespace Lab5
{
    public class Purple
    {
        public int[] Task1(int[,] matrix)
        {
            int[] answer = new int[matrix.GetLength(1)];
            int index = 0;
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                int temp = 0;
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    if (matrix[i, j] < 0)
                        temp++;
                }
                
                answer[index] = temp;
                index++;
            }

            return answer;
        }
        
        int[] GetArrayWithoutMinElement(int[] array, int indexMin)
        {
            int[] newArray = new int[array.Length - 1];
            int index = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (i != indexMin)
                {
                    newArray[index] = array[i];
                    index++;
                }

                if (i == indexMin)
                {
                    i++;
                    if (i <  array.Length)
                        newArray[index] = array[i];
                    index++;
                }
            }
            
            int[] answer = new int[array.Length];
            answer[0] =  array[indexMin];
            for (int i = 0; i < newArray.Length; i++)
            {
                answer[i + 1] =  newArray[i];
            }
            return answer;
        }
        public void Task2(int[,] matrix)
        {
                
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int[] temp = new int[matrix.GetLength(1)]; // временный массив для хранения имененной строки
                int min = int.MaxValue;
                int minIndex = 0;
                
                // нахожднение минимального элемента и его индекса
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (min > matrix[i, j])
                    {
                        min = matrix[i, j];
                        minIndex = j;
                    }

                    temp[j] = matrix[i, j];
                }
                
                // массив для перестановки
                int[] newArray = GetArrayWithoutMinElement(temp, minIndex);
                
                // замена на корректные данные
                for (int p = 0; p < matrix.GetLength(1); p++)
                {
                    matrix[i, p] =  newArray[p];
                }
            }
        }
        public int[,] Task3(int[,] matrix)
        {
            int[,] answer = new int[matrix.GetLength(0), matrix.GetLength(1) + 1];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                // нахождение максимального элемента
                int indexMax = 0, max =  int.MinValue;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (max < matrix[i, j])
                    {
                        max = matrix[i, j];
                        indexMax = j;
                    }
                }

                int index = 0; // индекс изначального массива
                for (int k = 0; k < answer.GetLength(1); k++)
                {
                    if (k != indexMax)
                    {
                        answer[i, k] =  matrix[i, index];
                        index++;
                    }
                    else if (k == indexMax)
                    {
                        answer[i, k] = matrix[i, indexMax];
                        k++;
                        answer[i, k] = matrix[i, indexMax];
                        index++;
                    }
                }
            }
            return answer;
        }
        
        public void Task4(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);

            for (int row = 0; row < rows; row++)
            {
                int mx = int.MinValue;
                int cmx = -1;
                for (int column = 0; column < columns; column++)
                {
                    if (matrix[row, column] > mx)
                    {
                        mx = matrix[row, column];
                        cmx = column;
                    }
                }



                bool isPositiveAfterMax = false;
                for (int column = cmx + 1; column < columns; column++)
                {
                    if (matrix[row, column] > 0) { 
                        isPositiveAfterMax = true;
                        break;
                    }
                }


                if (isPositiveAfterMax) {
                    int ln = columns - cmx - 1;
                    int aver;

                    if (ln != 0) { 
                        int sum = 0;
                        for (int column = cmx + 1; column < columns; column++)
                        {
                            sum += matrix[row, column];
                        }
                        aver = sum / ln;
                    }
                    else
                        aver = 0;

                    for (int column = 0; column < cmx; column++)
                    {
                        if (matrix[row, column] < 0)
                            matrix[row, column] = aver;
                    }
                }
            }
        }

        public void Task5(int[,] matrix, int k)
        {
            if (k > matrix.GetLength(1) - 1)
                return;

            int[] maxValue = new int[matrix.GetLength(0)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int max = int.MinValue;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (max < matrix[i, j])
                        max = matrix[i, j];
                }

                maxValue[i] = max;
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
                matrix[i, k] = maxValue[maxValue.Length - 1 - i];

        }
        public void Task6(int[,] matrix, int[] array)
            {
                if (array.Length != matrix.GetLength(1))
                    return;
                
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    int max = Int32.MinValue, indexMax = 0;
                    for (int i = 0; i < matrix.GetLength(0); i++)
                    {
                        if (max < matrix[i, j])
                        {
                            max = matrix[i, j];
                            indexMax = i;
                        }
                    }

                    if (array[j] > max)
                        matrix[indexMax, j] = array[j];
                }
            }
        
        public void Task7(int[,] matrix)
        {
            // min value from each strings
            int[] minValue = new int[matrix.GetLength(0)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int min = Int32.MaxValue;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (min > matrix[i, j])
                        min = matrix[i, j];
                }
                minValue[i] = min;
            }
            
            // index of strings in matrix
            int[] index = new int[minValue.Length];
            for (int i = 0; i < minValue.Length; i++)
            {
                index[i] = i;
            }
            
            // Bubble Sort
            for (int i = 0; i < minValue.Length; i++)
            {
                for (int j = 1; j < minValue.Length - i; j++)
                {
                    if (minValue[j - 1] < minValue[j])
                    {
                        (minValue[j], minValue[j - 1]) = (minValue[j - 1], minValue[j]);
                        (index[j], index[j - 1]) = (index[j - 1], index[j]);
                    }
                }
            }
            
            // copy of initial array
            int[,] clone =  new int[matrix.GetLength(0), matrix.GetLength(1)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    clone[i, j] = matrix[i, j];
                }
            }

            // replace with correct value
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = clone[index[i], j];
                }
            }
        }
        public int[] Task8(int[,] matrix)
        {
            int[] answer = null;
            if (matrix.GetLength(0) != matrix.GetLength(1))
                return answer;
            
            int size = matrix.GetLength(0); // size of matrix n * n
            answer = new int[2 * size - 1];
            
            int count = 1;
            for (int step = 0; step < answer.Length; step++)
            {
                // value below the main diagonal
                if (step < size - 1)
                {
                    int length = size - 1, row = step;
                    for (int i = 0; i < step + 1; i++)
                    {
                        answer[step] += matrix[length, row];
                        length--;
                        row--;
                    }

                    continue;
                }
                
                // the main diagonal
                if (step == size - 1)
                {
                    int length = 0, row = 0;
                    for (int i = 0; i < size; i++)
                    {
                        answer[step] += matrix[length, row];
                        length++;
                        row++;
                    }
                    
                    continue;
                }
                
                // above the main diagonal
                if (step > size - 1)
                {
                    int length = size - 1 - count, row = size - 1;
                    for (int i = 0; i < size - count; i++)
                    {
                        answer[step] += matrix[length, row];
                        length--;
                        row--;
                    }
                    
                    count++;
                }
            }

            return answer;
        }
        void SwapRows(int[,] matrix, int rowA, int rowB)
        {
            if (rowA == rowB)
                return;

            int cols = matrix.GetLength(1);
            for (int j = 0; j < cols; j++)
            {
                (matrix[rowA, j], matrix[rowB, j]) = (matrix[rowB, j], matrix[rowA, j]);
            }
        }

        void SwapColumns(int[,] matrix, int colA, int colB)
        {
            if (colA == colB)
                return;

            int rows = matrix.GetLength(0);
            for (int i = 0; i < rows; i++)
            {
                (matrix[i, colA], matrix[i, colB]) = (matrix[i, colB], matrix[i, colA]);
            }
        }
        public void Task9(int[,] matrix, int k)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            if (rows != cols || k < 0 || k >= rows)
                return;

            int maxRow = 0, maxCol = 0, maxValue = 0;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (Math.Abs(matrix[i, j]) > Math.Abs(maxValue))
                    {
                        maxValue = matrix[i, j];
                        maxRow = i;
                        maxCol = j;
                    }
                }
            }
            
            if (maxRow < k)
            {
                for (int i = maxRow; i < k; i++)
                    SwapRows(matrix, i, i + 1);
            }
            else if (maxRow > k)
            {
                for (int i = maxRow; i > k; i--)
                    SwapRows(matrix, i, i - 1);
            }
            
            if (maxCol < k)
            {
                for (int j = maxCol; j < k; j++)
                    SwapColumns(matrix, j, j + 1);
            }
            else if (maxCol > k)
            {
                for (int j = maxCol; j > k; j--)
                    SwapColumns(matrix, j, j - 1);
            }
        }
        public int[,] Task10(int[,] A, int[,] B)
        {
            if (A.GetLength(1) != B.GetLength(0))
                return null;

            int rows = A.GetLength(0);
            int cols = B.GetLength(1);
            int common = A.GetLength(1);
            int[,] answer = new int[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    int sum = 0;
                    for (int k = 0; k < common; k++)
                        sum += A[i, k] * B[k, j];
                    answer[i, j] = sum;
                }
            }

            return answer;
        }
        public int[][] Task11(int[,] matrix)
        {
            int[][] answer = new int[matrix.GetLength(0)][];

            int[] numOfElements = new int[matrix.GetLength(0)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int count = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > 0)
                        count++;
                }
                numOfElements[i] = count;
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int index = 0;
                answer[i] = new int[numOfElements[i]];
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        answer[i][index] = matrix[i, j];
                        index++;
                    }
                }
            }
            return answer;
        }
        public int[,] Task12(int[][] array)
        {
            int[,] answer = null;

            double countELements = 0;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                countELements += array[i].Length;
            }
            
            // size of matrix n * n
            int size = 0;
            if (Math.Pow(countELements, 0.5) - (int)Math.Pow(countELements, 0.5) != 0.0)
                size = (int)Math.Pow(countELements, 0.5) + 1;
            else
                size = (int)Math.Pow(countELements, 0.5);
            
            answer = new int[size, size];

            int[] value = new int[size * size];
            int index = 0;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    value[index] = array[i][j];
                    index++;
                }
            }

            index = 0;
            for (int i = 0; i < answer.GetLength(0); i++)
            {
                for (int j = 0; j < answer.GetLength(1); j++)
                {
                    answer[i, j] = value[index];
                    index++;
                }
            }
            return answer;
        }
    }
}




