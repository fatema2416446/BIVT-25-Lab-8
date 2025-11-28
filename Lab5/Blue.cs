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

            int first = matrix.GetLength(0);
            int second = matrix.GetLength(1);

            double[] n = new double[first];

            for (int i = 0; i < first; i++)
            {
                int sum = 0;
                int ns = 0;
                for (int j = 0; j < second; j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        sum += matrix[i, j];
                        ns++;
                    }
                }
                if (sum == 0)
                {
                    n[i] = 0;
                }
                else
                {
                    n[i] = Convert.ToDouble(sum) / ns;
                }
            }

            answer = n;
            // done

            return answer;
        }
        public int[,] Task2(int[,] matrix)
        {
            int[,] answer = null;

            // code here

            int first = matrix.GetLength(0);
            int second = matrix.GetLength(1);

            int maxx = int.MinValue;
            int str = 0;
            int stolb = 0;

            for (int i = 0; i < first; i++)
            {
                for (int j = 0; j < second; j++)
                {
                    if (matrix[i, j] > maxx){
                        maxx = matrix[i, j];
                        str = i;
                        stolb = j;
                    }
                }
            }

            int[,] a = new int[first - 1, second];
            for (int i = 0; i < first - 1; i++)
            {
                for (int j = 0; j < second; j++)
                {
                    if (i < str)
                    {
                        a[i, j] = matrix[i, j];
                    }
                    else
                    {
                        a[i, j] = matrix[i + 1, j];
                    }
                }
            }

            int[ , ] ans = new int[first - 1, second - 1];

            for (int i = 0; i < first - 1; i++)
            {
                for (int j = 0; j < second - 1; j++)
                {
                    if (j < stolb)
                    {
                        ans[i, j] = a[i, j];
                    } else
                    {
                        ans[i, j] = a[i, j + 1];
                    }
                }
            }

            answer = ans;

            // done

            return answer;
        }
        public void Task3(int[,] matrix)
        {

            // code here

            int str = matrix.GetLength(0);
            int stolb = matrix.GetLength(1);

            for (int i = 0; i < str; i++)
            {
                int m = int.MinValue;
                int n = 0;
                for (int j = 0; j < stolb; j++)
                {
                    if (matrix[i, j] > m)
                    {
                        m = matrix[i, j];
                        n = j;

                    }
                }
                for (int k = n; k < stolb - 1; k++)
                {
                    (matrix[i, k], matrix[i, k + 1]) = (matrix[i, k + 1], matrix[i, k]);
                }
                matrix[i, stolb - 1] = m;
            }
            // done

        }
        public int[,] Task4(int[,] matrix)
        {
            int[,] answer = null;

            // code here

            int str = matrix.GetLength(0);
            int stolb = matrix.GetLength(1);

            int[,] ans = new int[str, stolb + 1];

            for (int i = 0; i < str; i++)
            {
                for( int j = 0; j < stolb; j++)
                {
                    ans[i, j] = matrix[i, j];
                }
            }

            for (int i = 0; i < str; i++)
            {
                int m = int.MinValue;
                int n = 0;

                for (int j = 0; j < stolb; j++)
                {
                    if (ans[i, j] > m)
                    {
                        m = ans[i, j];
                        n = j;
                    }
                }
                ans[i, stolb] = m;
                (ans[i, stolb - 1], ans[i, stolb]) = (ans[i, stolb], ans[i, stolb - 1]);
            }

            answer = ans;

            // done

            return answer;
        }
        public int[] Task5(int[,] matrix)
        {
            int[] answer = null;

            // code here

            int str = matrix.GetLength(0);
            int stolb = matrix.GetLength(1);

            int n = 0;

            for (int i = 0; i < str; i++)
            {
                for (int j = 0; j < stolb; j++)
                {
                    if ((i + j) % 2 != 0)
                    {
                        n++;
                    }
                }
            }

            int[] ans = new int[n];

            int k = 0;

            for (int i = 0; i < str; i++)
            {
                for (int j = 0; j < stolb; j++)
                {
                    if ((i + j) % 2 != 0)
                    {
                        ans[k] = matrix[i, j];
                        k++;
                    }
                }
            }

            answer = ans;
            // done

            return answer;
        }
        public void Task6(int[,] matrix, int k)
        {

            // code here

            int str = matrix.GetLength(0);
            int stolb = matrix.GetLength(1);

            int nm = 0;
            int m = int.MinValue;

            if (str == stolb)
            {
                for (int i = 0; i < str; i++)
                {
                    if (matrix[i, i] > m)
                    {
                        m = matrix[i, i];
                        nm = i;
                    }
                }

                int minn = int.MaxValue;
                int mix = 0;

                for (int i = 0; i < str; i++)
                {
                    if (matrix[i, k] < 0)
                    {
                        minn = matrix[i, k];
                        mix = i;
                        break;
                    }
                }

                for (int i = 0; i < str; i++)
                {
                    if (minn < 0 && nm != mix)
                    {
                        (matrix[nm, i], matrix[mix, i]) = (matrix[mix, i], matrix[nm, i]);
                    }
                }
            }

            // done

        }
        public void Task7(int[,] matrix, int[] array)
        {

            // code here

            int str = matrix.GetLength(0);
            int stolb = matrix.GetLength(1);
            int len = array.Length;

            int m = int.MinValue;
            int mix = 0;

            if (stolb > 2 && str == len)
            {

                for (int i = 0; i < str; i++)
                {
                   if (matrix[i, stolb - 2] > m)
                    {
                        m = matrix[i, stolb - 2];
                        mix = i;
                    }
                }

                for (int i = 0; i < str; i++)
                {
                    matrix[mix, i] = array[i];
                }

            }

            // done

        }
        public void Task8(int[,] matrix)
        {

            // code here

            int str = matrix.GetLength(0);
            int stolb = matrix.GetLength(1);
            double mm = Convert.ToDouble(str) / 2;
            int mid = (int)Math.Floor(mm);

            for (int i = 0; i < stolb; i++)
            {
                int max = int.MinValue;
                int mi = 0;
                for (int j = 0; j < str; j++)
                {
                    if (matrix[j, i] > max)
                    {
                        max = matrix[j, i];
                        mi = j;
                    }

                }
                if (mi < mid)
                {
                    int sum = 0;
                    for (int j = mi + 1; j < str; j++)
                    {
                        sum += matrix[j, i];
                    }
                    matrix[0, i] = sum;
                }
            }

            // done

        }
        public void Task9(int[,] matrix)
        {

            // code here

            int str = matrix.GetLength(0);
            int stolb = matrix.GetLength(1);

            if (str % 2 != 0)
            {
                str -= 1;
            }

            for (int i = 0; i < str; i+=2)
            {
                int max = int.MinValue;
                int mi = 0;
                int max1 = int.MinValue;
                int mi1 = 0;

                for (int j = 0; j < stolb; j++)
                {
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                        mi = j;
                    }
                }

                for (int j = 0; j < stolb; j++)
                {
                    if (matrix[i+1, j] > max1)
                    {
                        max1 = matrix[i+1, j];
                        mi1 = j;
                    }
                }

                (matrix[i, mi], matrix[i + 1, mi1]) = (matrix[i + 1, mi1], matrix[i, mi]);
                
            }

            // done

        }
        public void Task10(int[,] matrix)
        {

            // code here

            int str = matrix.GetLength(0);
            int stolb = matrix.GetLength(1);

            if (str == stolb)
            {
                int max = int.MinValue;
                int mi = 0;
                for (int i = 0; i < str; i++)
                {
                    if (matrix[i, i] > max)
                    {
                        max = matrix[i, i];
                        mi = i;
                    }
                }
                for (int i = 0; i < str; i++)
                {
                    for (int j = 0; j < str; j++)
                    {
                        if ( j > i && i < mi)
                        {
                            matrix[i, j] = 0;
                        }
                    }
                }
            }

            // done

        }
        public void Task11(int[,] matrix)
        {

            // code here

            int str = matrix.GetLength(0);
            int stolb = matrix.GetLength(1);

            int[] count = new int[str];

            for (int i = 0; i < str; i++)
            {
                int c = 0;
                for (int j = 0; j < stolb; j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        c++;
                    }
                }
                count[i] = c;
            }

            int[] arr = new int[str];

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = i;
            }

            for (int i = 0; i < count.Length; i++)
            {
                for (int j = 0; j < count.Length - 1 - i; j++)
                {
                    if (count[j] < count[j + 1])
                    {
                        (count[j], count[j + 1]) = (count[j + 1], count[j]);
                        (arr[j], arr[j + 1]) = (arr[j + 1], arr[j]);
                    }
                }
            }

            int[,] mat = new int[str, stolb];

            for (int i = 0; i < str; i++)
            {
                for (int j = 0; j < stolb; j++)
                {
                    mat[i, j] = matrix[i, j];
                }
            }


            for (int i = 0; i < str; i++)
            {
                int d = arr[i];
                for (int j = 0; j < stolb; j++)
                {
                    matrix[i, j] = mat[d, j];
                }
            }

            // end


        }
        public int[][] Task12(int[][] array)
        {
            int[][] answer = null;

            // code here
            int str = array.Length;

            int c = 0;
            int sum = 0;
            for (int i = 0; i < str; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    sum += array[i][j];
                    c++;
                }
            }

            double avg = Convert.ToDouble(sum) / Convert.ToDouble(c);


            double[] s = new double[str]; // сюда записываю сумму по очереди(индекс-строка)
            int k = 0;

            //записала сумму
            for (int i = 0; i < str; i++)
            {
                int sr = 0;
                int co = 0;
                for (int j = 0; j < array[i].Length; j++)
                {
                    sr += array[i][j];
                    co++;
                }
                double avg1 = Convert.ToDouble(sr) / Convert.ToDouble(co);
                s[i] = avg1;
            }

            //done
            int n = 0;

            for (int i = 0; i < str; i++)
            {
                if (s[i] >= avg)
                {
                    n++;
                }
            }

            int[][] mef = new int[n][];

            //создаю массив где срзнач эл ниже ср знач всех эл
            for (int i = 0; i < str; i++)
            {
                if (s[i] >= avg)
                {
                    mef[k] = new int[array[i].Length];
                    k++;
                }
            }

            //done

            int g = 0;
            //записываю теперь в новый массив элемнты которые нам надо



            //mef - заполнен нулями и он по размеру как аррей без строк которые нам не нужны
            //аррей - наш первоначальный массив
            //с - массив со всеми средзнач (индекс = индексу строки в [][])

            for (int i = 0; i < array.Length; i++)
            {
                if (s[i] >= avg)
                {
                    for (int j = 0; j < array[i].Length; j++)
                    {
                        mef[g][j] = array[i][j];
                    }
                    g++;
                }
            }

            answer = mef;
            // end

            return answer;
        }
    }
}
