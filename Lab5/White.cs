using System.Globalization;
using System.Linq;
using System.Linq;

namespace Lab5
{
    public class White
    {
        public double Task1(int[,] matrix)
        {
            double average = 0;

            // code here
            double s = 0;
            int count = 0;
            if (matrix == null)
            {
                return 0;
            }
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        s+= matrix[i, j];
                        count++;
                    }
                }
            }
            if (count > 0)
            {
                average = s / count;
            }
            // end

            return average;
        }
        public (int row, int col) Task2(int[,] matrix)
        {
            int row = -1, col = -1;

            // code here
            int minM = int.MaxValue;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < minM)
                    {
                        minM = matrix[i, j];
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
            int i1 = matrix.GetLength(0);
            int j1 = matrix.GetLength(1);
            if (i1 == 0 || k < 0 || k >= j1)
            {
                return;
            }
            int maxindex = 0;
            int maxVaule = matrix[0, k];
            for (int i = 1; i < i1; i++)
            {
                if(matrix[i, k] > maxVaule)
                {
                    maxVaule = matrix[i, k];
                    maxindex = i;
                }
            } 
            if (maxindex == 0)
            {
                return;
            }
            for (int j = 0; j < j1; j++)
            {
                (matrix[0, j], matrix[maxindex,j]) = (matrix[maxindex,j], matrix[0, j]);
            }
            // end

        }
        public int[,] Task4(int[,] matrix)
        {

            // code here
    // Максимальная защита - проверяем все возможные проблемные случаи
    if (matrix == null)
    {
        return new int[0, 0];
    }
    
    int row = matrix.GetLength(0); 
    
    // Если нет строк - возвращаем пустую матрицу
    if (row == 0)
    {
        return new int[0, 0];
    }
    
    int col = matrix.GetLength(1);
    
    // Если нет столбцов - возвращаем пустую матрицу с 0 столбцов
    if (col == 0)
    {
        return new int[0, 0];
    }
    
    // Если только одна строка - возвращаем пустую матрицу с тем же количеством столбцов
    if (row == 1)
    {
        return new int[0, col];
    }
    
    // Теперь безопасно ищем минимальный элемент в первом столбце
    int minValue = matrix[0, 0]; 
    int minindex = 0; 
    
    for (int i = 1; i < row; i++) 
    { 
        if (matrix[i, 0] < minValue) 
        { 
            minValue = matrix[i, 0]; 
            minindex = i; 
        } 
    } 
    
    // Создаем новую матрицу без найденной строки
    int[,] answer = new int[row - 1, col];  
    int newrow = 0; 
    
    for (int i = 0; i < row; i++) 
    { 
        if (i != minindex) 
        { 
            for (int j = 0; j < col; j++) 
            { 
                answer[newrow, j] = matrix[i, j]; 
            } 
            newrow++; 
        } 
    } 
    
    return answer; 

        }
        public int Task5(int[,] matrix)
        {
            

            // code here
            if (matrix == null)
            {
                return 0;
            }
            int sum = 0; 
            if (matrix == null) return 0; 
            int n = matrix.GetLength(0); 
            if (n != matrix.GetLength(1)) return 0; 
            for (int i = 0; i < n; i++) 
            {
                sum += matrix[i, i]; 
            }
            // end

            return sum;
        }
        public void Task6(int[,] matrix)
        {

            // code here
            int row = matrix.GetLength(0);
            int col = matrix.GetLength(1);
            for (int i = 0; i < row; i++)
            {
                int maxvaul = int.MinValue;
                int maxindex = -1;
                int max1= -1;
                int max2 = -1;
                for (int j = 0; j < col; j++)
                {
                    int count = matrix[i, j];
                    if (count < 0)
                    {
                        if (max1 == -1)
                        {
                            max1 = j;
                        }
                        max2 = j;
                    }
                    if (max1 == -1 && count > maxvaul)
                    {
                        maxvaul = count;
                        maxindex = j;
                    }
                }
                if (max1 != -1 && max2 != -1 && maxindex != -1 && maxindex < max1)
                {
                    (matrix[i, maxindex], matrix[i, max2]) = (matrix[i, max2],matrix[i, maxindex]);
                }
            }

            // end

        }
        public int[] Task7(int[,] matrix)
        {
            int[] negatives = null;

            // code here
            if (matrix == null)
            {
                return null;
            }
            //считаем колво отриц эл
            int row = matrix.GetLength(0);
            int col = matrix.GetLength(1);
            if (row == 0 || col == 0)
            {
                return null;
            }
            int count = 0;
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    if (matrix[i, j] < 0)
                    {
                        count++;
                    }
                }
            } 
            //если отриц нет возвращаем пустой массив
            if (count == 0)
            {
                return null;
            }
            //создаем новый массив
            negatives = new int[count];
            int index = 0;
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    if (matrix[i, j] < 0)
                    {
                        negatives[index] = matrix[i, j];
                        index++;
                    }
                }       
            }
            // end

            return negatives;
        }
        public void Task8(int[,] matrix)
        {

            // code here
            int row = matrix.GetLength(0);
            int col = matrix.GetLength(1);
            for (int i = 0; i < row; i++)
            {
                if (col > 1)
                {
                    int maxindex = 0;
                    for (int j = 0; j < col; j++)
                    {
                        if (matrix[i, j] > matrix[i, maxindex])
                        {
                            maxindex = j;
                        }
                    }
                    if (maxindex == 0)
                    {
                        matrix[i, 1] *= 2;
                    }
                    else if (maxindex == col - 1)
                    {
                        matrix[i, col - 2] *= 2;
                    }
                    else
                    {
                        int leftm = matrix[i, maxindex - 1];
                        int rightm = matrix[i, maxindex + 1];
                        if ( leftm <= rightm)
                        {
                            matrix[i, maxindex - 1] *= 2;
                        }
                        else
                        {
                            matrix[i, maxindex + 1] *= 2;
                        }
                    }

                }
            }

        }

            // end

        
        public void Task9(int[,] matrix)
        {

            // code here
            int row = matrix.GetLength(0);
            int col = matrix.GetLength(1);
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col/2; j++)
                {
                    (matrix[i, j], matrix[i, col - 1 - j]) = (matrix[i, col - 1 - j], matrix[i, j]);

                }    
            }
            // end

        }
        public void Task10(int[,] matrix)
        {

            // code here
            if (matrix == null)
            {
                return;
            }
            int n = matrix.GetLength(0);
            if (n != matrix.GetLength(1))
            {
                return;
            }
            for (int i = n/2; i < n; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    matrix[i, j] = 1;
                }
            }
            // end

        }
        public int[,] Task11(int[,] matrix)
        {
            int[,] answer = null;

            // code here
            if (matrix == null)
            {
                return null;
            }
            int row = matrix.GetLength(0);
            int col = matrix.GetLength(1);
            int count0 = 0;
            //колво строк бкз нулей
            for (int i = 0; i < row; i++)
            {
                bool zero = false;
                for (int j = 0; j < col; j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        zero = true;
                        break;
                    }
                }
                if (zero == false)
                {
                    count0++;
                }
            }
            //если в каждой строке нули 
            if (count0 == 0)
            {
                return new int[0, col];
            }
            //если ни одна строка не содержит нуля возвращаем копию исходной
            if (count0 == row)
            {
                int[,] newmatrix = new int[row, col];
                for (int i = 0; i < row; i++)
                {
                    for (int j = 0; j < col; j++)
                    {
                        newmatrix[i, j] = matrix[i, j];
                    }
                }
                return newmatrix;
            }
            //создать новую матрицу  и заполнить её
            answer = new int[count0, col];
            int indexi = 0;
            for (int i = 0; i < row; i++)
            {
                bool zero2 = false;
                for (int j = 0; j < col; j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        zero2 = true;
                        break;
                    }
                }
                if (zero2 == false)
                {
                    for (int j = 0; j < col; j++)
                    {
                        answer[indexi, j] = matrix[i, j];
                    }
                    indexi++;
                }
            }
            // end

            return answer;
        }
        public void Task12(int[][] array)
        {

            // code here
            // В метод передается зубчатый массив (массив массивов) array. Расположить строки 
            // зубчатогомассива по возрастанию суммы элементов в строке.
            int[] sum = new int[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                int sumstrok = 0;
                for (int j = 0; j < array[i].Length; j++)
                {
                    sumstrok += array[i][j];
                }
                sum[i] = sumstrok;
            }
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = 0; j < array.Length - i - 1; j++)
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