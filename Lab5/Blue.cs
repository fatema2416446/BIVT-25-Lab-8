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
            answer = new double[matrix.GetLength(0)];
            double sum = 0;
            int cnt = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > 0)
                    { 
                        sum += matrix[i, j]; 
                        cnt++;
                    }
                }
                if (cnt == 0) answer[i] = 0;
                else answer[i] = sum / cnt;
                sum = 0;
                cnt = 0;
            }
            // end

            return answer;
        }
        public int[,] Task2(int[,] matrix)
        {
            int[,] answer = null;

            // code here
            answer = new int[matrix.GetLength(0) - 1, matrix.GetLength(1) - 1];
            int max = int.MinValue;
            int stl = 0;
            int str = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int k = 0; k < matrix.GetLength(1); k++)
                {
                    if (matrix[i, k] > max)
                    {
                        max = matrix[i, k];
                        stl = k;
                        str = i;
                    }
                }
            }
            if (answer.GetLength(0) == 0 || answer.GetLength(1) == 0) return answer;
            for (int i = 0; i < answer.GetLength(0); i++)
            {
                for (int k = 0; k < answer.GetLength(1); k++)
                {
                    if (i < str && k < stl) { answer[i, k] = matrix[i, k]; }
                    else if (i < str && k >= stl) { answer[i, k] = matrix[i, k + 1]; }
                    else if (i >= str && k < stl) { answer[i, k] = matrix[i + 1, k]; }
                    else if (i >= str && k >= stl) { answer[i, k] = matrix[i + 1, k + 1]; }
                }
            }
            // end

            return answer;
        }
        public void Task3(int[,] matrix)
        {

            // code here
            int max = int.MinValue;
            int stl = 0;
            int[,] answer = new int[matrix.GetLength(0), matrix.GetLength(1)];

            for (int i = 0; i < answer.GetLength(0); i++)
            {
                for (int k = 0; k < answer.GetLength(1); k++)
                {
                    answer[i, k] = matrix[i, k];
                }
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int k = 0; k < matrix.GetLength(1); k++)
                {
                    if (matrix[i, k] > max)
                    {
                        max = matrix[i, k];
                        stl = k;
                    }
                }
                for (int k = 0; k < matrix.GetLength(1); k++)
                {
                    if (k < stl) { matrix[i, k] = answer[i, k]; }
                    else if (k == stl) { matrix[i, matrix.GetLength(1) - 1] = answer[i, k]; }
                    else { matrix[i, k - 1] = answer[i, k]; }
                }
                max = int.MinValue;
                stl = 0;
            }
            // end

        }
        public int[,] Task4(int[,] matrix)
        {
            int[,] answer = null;

            // code here
            int max = int.MinValue;
            answer = new int[matrix.GetLength(0), matrix.GetLength(1) + 1];
            int predp = matrix.GetLength(1) - 1;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int k = 0; k < matrix.GetLength(1); k++)
                {
                    if (matrix[i, k] > max)
                    {
                        max = matrix[i, k];
                    }
                }
                for (int k = 0; k < answer.GetLength(1); k++)
                {
                    if (k < predp) { answer[i, k] = matrix[i, k]; }
                    else if (k == predp) { answer[i, k] = max; }
                    else { answer[i, k] = matrix[i, k - 1]; }
                }
                max = int.MinValue;
            }


            for (int i = 0; i < answer.GetLength(0); i++)
            {
                for (int k = 0; k < answer.GetLength(1); k++)
                {
                    Console.Write(answer[i, k] + " ");
                }
                Console.WriteLine();
            }
            // end

            return answer;
        }
        public int[] Task5(int[,] matrix)
        {
            int[] answer = null;

            // code here
            int cnt = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int k = 0; k < matrix.GetLength(1); k++)
                {
                    if ((i + k) % 2 != 0)
                    {
                        cnt++;
                    }
                }
            }

            answer = new int[cnt];
            int j = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int k = 0; k < matrix.GetLength(1); k++)
                {
                    if ((i + k) % 2 != 0)
                    {
                        answer[j] = matrix[i, k];
                        j++;
                    }
                }
            }
            // end

            return answer;
        }
        public void Task6(int[,] matrix, int k)
        {

            // code here
            int max = int.MinValue;
            int str = 0;
            int STRmax = -1;

            if (k > matrix.GetLength(1) - 1) return ;
            if (matrix.GetLength(1) != matrix.GetLength(0)) return ;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, i] > max)
                {
                    max = matrix[i, i];
                    STRmax = i;
                }
            }
            int STRneg = -1;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, k] < 0)
                {
                    STRneg = i;
                    break;
                }
            }

            if (STRneg == -1 || STRneg == STRmax) return ;

            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                int temp = matrix[STRmax, j];
                matrix[STRmax, j] = matrix[STRneg, j];
                matrix[STRneg, j] = temp;
            }
            // end

        }
        public void Task7(int[,] matrix, int[] array)
        {

            // code here
            int max = int.MinValue;
            int str = -1;
            if (matrix.GetLength(1) < 2) return ; 
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, matrix.GetLength(1) - 2] > max)
                {
                    max = matrix[i, matrix.GetLength(1) - 2];
                    str = i;
                }
            }

            if (array.Length != matrix.GetLength(1)) return ;
            if (str == -1) return ;
            for (int i = 0; i < array.Length; i++)
            { matrix[str, i] = array[i];}
            // end

        }
        public void Task8(int[,] matrix)
        {

            // code here

            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                int max = int.MinValue;
                int indmax = -1;
                int sr = matrix.GetLength(0) / 2;
                int sum = 0;
                for (int k = 0; k < matrix.GetLength(0); k++)
                {
                    if (matrix[k, i] > max)
                    { 
                        max = matrix[k, i];
                        indmax = k;
                    }
                }
                if (indmax != -1 && indmax < sr)
                {
                    for (int k = indmax + 1; k < matrix.GetLength(0); k++)
                    {
                        sum += matrix[k, i];
                    }
                    matrix[0, i] = sum;
                }
            }
            // end

        }
        public void Task9(int[,] matrix)
        {

            // code here
            if (matrix == null) return;

            for (int i = 0; i < matrix.GetLength(0) - 1; i += 2)
            {
                int max0 = 0, max1 = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > matrix[i, max0])
                    { max0 = j; }
                }
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i + 1, j] > matrix[i + 1, max1])
                    { max1 = j; }
                }
                (matrix[i, max0], matrix[i + 1, max1]) = (matrix[i + 1, max1], matrix[i, max0]);
            }
            // end

        }
        public void Task10(int[,] matrix)
        {

            // code here
            if (matrix.GetLength(0) != matrix.GetLength(1))
            { return; }
            if (matrix == null) return;

            int max = matrix[0, 0];
            int ind = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, i] > max)
                {
                    max = matrix[i, i];
                    ind = i;
                }
            }


            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (i < ind && j > i)
                    {
                        matrix[i, j] = 0;
                    }
                }
            }
            // end

        }
        public void Task11(int[,] matrix)
        {

            // code here
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            int[] cnt = new int[rows];
            for (int i = 0; i < rows; i++)
            {
                int count = 0;
                for (int j = 0; j < cols; j++) if (matrix[i, j] > 0) count++;
                cnt[i] = count;
            }
            for (int i = 0; i < rows - 1; i++)
            {
                for (int j = 0; j < rows - 1 - i; j++)
                {
                    if (cnt[j] < cnt[j + 1])
                    {
                        (cnt[j], cnt[j + 1]) = (cnt[j + 1], cnt[j]);
                        for (int k = 0; k < cols; k++) (matrix[j, k], matrix[j + 1, k]) = (matrix[j + 1, k], matrix[j, k]);
                    }
                }
            }
            // end

        }
        public int[][] Task12(int[][] array)
        {
            int[][] answer = null;

            // code here
            double allsum = 0;
            int allcnt = 0;
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    allsum += array[i][j];
                    allcnt++;
                }
            }
            double z = allsum / allcnt;
            int cnt = 0;
            for (int i = 0; i < array.Length; i++)
            {
                double rowsum = 0;
                for (int j = 0; j < array[i].Length; j++) rowsum += array[i][j];
                double rw = rowsum / array[i].Length;
                if (rw >= z) cnt++;
            }
            answer = new int[cnt][];
            int index = 0;
            for (int i = 0; i < array.Length; i++)
            {
                double rowsum = 0;
                for (int j = 0; j < array[i].Length; j++) rowsum += array[i][j];
                double rw = rowsum / array[i].Length;
                if (rw >= z) answer[index++] = array[i];
            }
            // end

            return answer;
        }
    }
}
