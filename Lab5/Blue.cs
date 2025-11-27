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
            for(int i = 0; i < matrix.GetLength(0); i++)
            {
                double sr = 0;
                int kvo = 0;
                for(int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > 0) {sr += matrix[i, j];kvo++;}
                }
                if (sr != 0) sr /= kvo;
                answer[i] = sr;
            }
            // end

            return answer;
        }
        public int[,] Task2(int[,] matrix)
        {
            int[,] answer = null;

            // code here
            answer=new int[matrix.GetLength(0)-1,matrix.GetLength(1)-1];
            int maxi=0, maxj=0;
            int k = int.MinValue;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if(matrix[i, j] > k) { k=matrix[i, j]; maxj=j;maxi = i; }
                }
            }
            int eli = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int elj = 0;
                if(i == maxi) continue;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if(j==maxj) continue;
                    else answer[eli,elj++]=matrix[i,j];
                }
                eli++;
            }
            // end

            return answer;
        }
        public void Task3(int[,] matrix)
        {

            // code here
            for(int i = 0;i< matrix.GetLength(0); i++)
            {
                int maxs = int.MinValue;
                int indm = 0;
                int[] kop=new int[matrix.GetLength(1)];
                for(int j=0;j< matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > maxs) { maxs = matrix[i, j]; indm = j; }
                }
                kop[^1] = maxs;
                int elk = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (j == indm) continue;
                    kop[elk++]=matrix[i,j];
                }
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = kop[j];
                }
            }
            // end

        }
        public int[,] Task4(int[,] matrix)
        {
            int[,] answer = null;

            // code here
            int[] maxs = new int[matrix.GetLength(0)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int elstr = int.MinValue;
                for (int j = 0; j < matrix.GetLength(1); j++) elstr = Math.Max(elstr, matrix[i, j]);
                maxs[i] = elstr;
            }
            answer = new int[matrix.GetLength(0), matrix.GetLength(1) + 1];
            for (int j = 0; j < matrix.GetLength(1) - 1; j++)
            {
                for (int i = 0; i < matrix.GetLength(0); i++) answer[i, j] = matrix[i, j];
            }
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                answer[i, answer.GetLength(1) - 2] = maxs[i];
                answer[i, answer.GetLength(1) - 1] = matrix[i, matrix.GetLength(1) - 1];
            }
            // end

            return answer;
        }
        public int[] Task5(int[,] matrix)
        {
            int[] answer = null;

            // code here
            int sch = 0;
            for(int i=0; i< matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++) if ((i + j) % 2 != 0) sch++;
            }
            answer=new int[sch];
            if (sch == 0) return null;
            int ela = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++) if ((i + j) % 2 != 0) answer[ela++]=matrix[i,j];
            }
            // end

            return answer;
        }
        public void Task6(int[,] matrix, int k)
        {

            // code here
            if(k>=matrix.GetLength(1) || k<0 || matrix.GetLength(0)!=matrix.GetLength(1)) return;
            int maxd = int.MinValue, maxk = int.MinValue;
            int indd = 0, indk = 0;
            for(int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, i] > maxd) {  maxd = matrix[i, i]; indd = i; }
                if (matrix[i,k] > maxk) { maxk = matrix[i, k]; indk = i; }
            }
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, k] < 0) { indk = i; break; }
            }
            if (indd == indk) return;
            int[] sd = new int[matrix.GetLength(1)];
            int[] sk = new int[matrix.GetLength(1)];
            for(int j = 0; j < matrix.GetLength(1); j++)
            {
                sd[j] = matrix[indd, j];
                sk[j] = matrix[indk, j];
            }
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                matrix[indd, j]=sk[j];
                matrix[indk, j]=sd[j];
            }
            // end

        }
        public void Task7(int[,] matrix, int[] array)
        {

            // code here
            if (matrix.GetLength(1) < 2) return;
            if (matrix.GetLength(1) != array.Length) return;
            int maxe = int.MinValue;
            int indm = 0;
            int sto = matrix.GetLength(1);
            for(int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, sto - 2] > maxe) {maxe=matrix[i, sto - 2];indm = i; }
            }
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                matrix[indm, j] = array[j];
            }
            // end

        }
        public void Task8(int[,] matrix)
        {

            // code here
            if(matrix.GetLength(0) < 2) return;
            for(int j = 0; j < matrix.GetLength(1); j++)
            {
                int maxs = int.MinValue;
                int indm = 0;
                int sume = 0;
                for(int i=0;i < matrix.GetLength(0); i++)
                {
                    if (matrix[i, j] > maxs) { maxs = matrix[i, j]; indm = i; }
                }
                if (matrix.GetLength(0) % 2 == 0)
                {
                    if (indm > ((matrix.GetLength(0) - 1) / 2)) continue;
                    for (int i = indm + 1; i < matrix.GetLength(0); i++)
                    {
                        sume += matrix[i, j];
                    }
                    matrix[0, j] = sume;
                }
                else
                {
                    if (indm >= ((matrix.GetLength(0) - 1) / 2)) continue;
                    for (int i = indm + 1; i < matrix.GetLength(0); i++)
                    {
                        sume += matrix[i, j];
                    }
                    matrix[0, j] = sume;
                }
            }
            // end

        }
        public void Task9(int[,] matrix)
        {

            // code here
            if (matrix.GetLength(0) < 3) return;
            for(int i=0; i<matrix.GetLength(0)-1; i+=2)
            {
                int maxs1 = int.MinValue;
                int maxs2 =  int.MinValue;
                int indm1 = 0, indm2 = 0;
                for(int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j]>maxs1) {  maxs1 = matrix[i, j];indm1 = j; }
                    if (matrix[i+1, j] > maxs2) { maxs2 = matrix[i+1, j]; indm2 = j; }
                }
                matrix[i, indm1] = maxs2;
                matrix[i + 1, indm2] = maxs1;
            }
            // end

        }
        public void Task10(int[,] matrix)
        {

            // code here
            if (matrix.GetLength(0) != matrix.GetLength(1)) return;
            int maxd = int.MinValue;
            int indm = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if ((matrix[i, i]) > maxd) { maxd = matrix[i, i]; indm = i; }
            }
            for (int i = 0; i < indm; i++)
            {
                for (int j = i + 1; j < matrix.GetLength(0); j++) matrix[i, j] = 0;
            }
            // end

        }
        public void Task11(int[,] matrix)
        {

            // code here
            for (int k = 0; k < matrix.GetLength(0); k++)
            {
                for (int i = 0; i < matrix.GetLength(0) - 1; i++)
                {
                    int p1 = 0, p2 = 0;
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        if (matrix[i, j] > 0) p1++;
                        if (matrix[i + 1, j] > 0) p2++;
                    }
                    if (p2 > p1)
                    {
                        for (int j = 0; j < matrix.GetLength(1); j++)
                        {
                            (matrix[i, j], matrix[i + 1, j]) = (matrix[i + 1, j], matrix[i, j]);
                        }
                    }
                }
            }
            // end

        }
        public int[][] Task12(int[][] array)
        {
            int[][] answer = null;

            // code here
            double sr = 0, sch = 0;
            int sch2 = 0;
            for(int i = 0; i < array.Length; i++)
            {
                for(int j = 0; j < array[i].Length; j++)
                {
                    sr+= array[i][j];
                    sch++;
                }
            }
            sr /= sch;
            for (int i = 0; i < array.Length; i++)
            {
                double srs = 0;
                for (int j = 0; j < array[i].Length; j++)
                {
                    srs+= array[i][j];
                }
                srs /= array[i].Length;
                if (srs < sr) sch2++;
            }
            if (array.Length == sch2) return null;
            answer = new int[array.Length - sch2][];
            int ela = 0;
            for (int i = 0; i < array.Length; i++)
            {
                double srs = 0;
                for (int j = 0; j < array[i].Length; j++)
                {
                    srs += array[i][j];
                }
                srs /= array[i].Length;
                if (srs >= sr) answer[ela++]=array[i];
            }
            // end

            return answer;
        }
    }
}
