using System.Linq;
using System.Runtime.InteropServices;

namespace Lab5
{
    public class Purple
    {
        public int[] Task1(int[,] matrix)
        {
            int n0 = matrix.GetLength(0), n1 = matrix.GetLength(1);
            int[] answer = new int[n1];
            
            for (int j = 0; j < n1; j++){
                int k = 0;
                for (int i = 0; i < n0; i++){
                    if (matrix[i, j] < 0){
                        k++;
                    }
                }
                answer[j] = k;
            }
            return answer;
        }
        public void Task2(int[,] matrix)
        {
            int n0 = matrix.GetLength(0), n1 = matrix.GetLength(1);
            for (int i = 0; i < n0; i++){
                int mi = matrix[i, 0];
                int indmi = 0;
                for (int j = 0; j < n1; j++){
                    if (matrix[i, j] < mi){
                        mi = matrix[i, j];
                        indmi = j;
                    }
                }
                int[] temp = new int[indmi+1];
                temp[0] = mi;
                for (int j = 1; j <= indmi; j++){
                    temp[j] = matrix[i, j-1];

                }
                for (int j = 0; j <= indmi; j++){
                    matrix[i, j] = temp[j];
                }
            }

        }
        public int[,] Task3(int[,] matrix)
        {
            int n0 = matrix.GetLength(0), n1 = matrix.GetLength(1);
            int[,] answer = new int[n0, n1+1];
            for (int i = 0; i < n0; i++){
                int ma = matrix[i, 0], indma = 0;
                for (int j = 0; j < n1; j++){
                    if (matrix[i, j] > ma){
                        ma = matrix[i, j];
                        indma = j;
                    }
                }
                answer[i, indma+1] = ma;
                for (int j = 0; j < n1; j++){
                    if (j <= indma){
                        answer[i, j] = matrix[i, j];
                    }
                    else{
                        answer[i, j+1] = matrix[i, j];
                    }
                }
            }

            return answer;
        }
        public void Task4(int[,] matrix)
        {
            int n = matrix.GetLength(0), n1 = matrix.GetLength(1);
            for (int i = 0; i < n; i++){
                int ma = matrix[i, 0];
                int maind = 0;
                int summ = 0, kol = 0;
                for (int j = 0; j < n1; j++){
                    if (ma < matrix[i, j])
                    {
                        ma = matrix[i, j];
                        maind = j;
                    }
                }
                if (maind != n1-1 && ma > 0){
                    for (int j = maind+1; j < n1; j++){
                        if (matrix[i, j] > 0){
                            kol++;
                            summ+=matrix[i, j];
                        }
                    }
                    if (kol > 0){
                        int sr = summ / kol;
                        for (int j = 0; j < maind; j++){
                            if (matrix[i, j] < 0){
                                matrix[i, j] = sr;
                            }
                        }
                    }
                }
            }

        }
        public void Task5(int[,] matrix, int k)
        {
            int[] ks = new int[matrix.GetLength(0)];
            int n = matrix.GetLength(0), n1 = matrix.GetLength(1);
            int indks = 0;
            for (int i = n-1; i > -1; i--){
                int ma = matrix[i, 0];
                for (int j = 0; j < n1; j++){
                    if (ma < matrix[i, j]){
                        ma = matrix[i, j];
                    }
                }
                ks[indks++] = ma;
            }
            if (k < n1){
                for (int i = 0; i < n; i++){
                    matrix[i, k] = ks[i];
            }
            }

        }
        public void Task6(int[,] matrix, int[] array)
        {
            int n = matrix.GetLength(0), n1 = matrix.GetLength(1);
            if (array.Length == n1){
                for (int j = 0; j < n1; j++){
                    int ma = matrix[0, j], indma = 0;
                    for (int i = 0; i < n; i++){
                        if (ma < matrix[i, j]){
                            ma = matrix[i, j];
                            indma = i;
                        }
                    }
                    if (array[j] > ma){
                        matrix[indma, j] = array[j];
                    }
                    
                }
            }
            
        }
        public void Task7(int[,] matrix)
        {
            int n = matrix.GetLength(0), n1 = matrix.GetLength(1);
            int[,] array = new int[n, 2];
            for (int i = 0; i < n; i++){
                int mi = matrix[i, 0];
                for (int j = 1; j < n1; j++){
                    if (matrix[i, j]<mi){
                        mi = matrix[i, j];
                    }
                }
                array[i, 0] = mi;
                array[i, 1] = i;
            }
            for (int i = 0; i<n-1; i++){
                for (int j = 0; j < n-i-1; j++){
                    if (array[j, 0] < array[j+1, 0]){
                        (array[j, 0], array[j+1, 0]) = (array[j+1, 0], array[j, 0]);
                        (array[j, 1], array[j+1, 1]) = (array[j+1, 1], array[j, 1]);

                    }
                }
            }
            int[,] matrix1 = new int[n, n1];
            for (int i = 0; i < n; i++){
                for (int j = 0; j < n1; j++){
                    matrix1[i, j] = matrix[array[i, 1], j];
                }
            }
            for (int i = 0; i < n; i++){
                for (int j = 0; j < n1; j++){
                    matrix[i, j] = matrix1[i, j];
                }
            }

        }
        public int[] Task8(int[,] matrix)
        {
            int[] answer = null;
            int n = matrix.GetLength(0);
            if (n == matrix.GetLength(1)){
                answer = new int[2*n-1];
                int indexx = 0;
                int indexx2 = 2*n - 2;
                for (int i = n-1; i > 0; i--){
                    int j = 0;
                    int summ1 = 0, summ2 = 0;
                    int i1 = i;
                    while(i1 <= n-1 && j <= n-1){
                        summ1 += matrix[i1, j];
                        summ2 += matrix[j++, i1++];
                    }
                    answer[indexx++] = summ1;
                    answer[indexx2--] = summ2;
                }
                for (int i = 0; i < n; i++){
                    answer[n-1] += matrix[i, i];
                }
            }

            return answer;
        }
        public void Task9(int[,] matrix, int k)
        {

            int n = matrix.GetLength(0);
            if (n == matrix.GetLength(1)){
                int ma = Math.Abs(matrix[0, 0]), indrow = 0, indcol = 0;
                for(int i = 0; i < n; i++){
                    for (int j = 0; j < n; j++){
                        if (ma < Math.Abs(matrix[i, j])){
                            ma = Math.Abs(matrix[i, j]);
                            indrow = i;
                            indcol = j;
                        }
                    }
                }
                for(int i = Math.Max(k, indrow); i > Math.Min(k, indrow); i--){
                    for (int j = 0; j < n; j++){
                        (matrix[i-1, j], matrix[i, j]) = (matrix[i, j], matrix[i-1, j]);
                    }
                }
                for(int i = Math.Max(k, indcol); i > Math.Min(k, indcol); i--){
                    for (int j = 0; j < n; j++){
                        (matrix[j, i-1], matrix[j, i]) = (matrix[j, i], matrix[j, i-1]);
                    }
                }
                
                
            }

        }
        public int[,] Task10(int[,] A, int[,] B)
        {
            int[,] answer = null;

            int n = A.GetLength(0), n1 = A.GetLength(1);
            int nn = B.GetLength(0), nn1 = B.GetLength(1);
            if (n1 == nn){
                answer = new int[n, nn1];
                for(int i = 0; i < n; i++){
                    for (int j = 0; j < nn1; j++){
                        for(int k = 0; k < n1; k++){
                            answer[i, j]+=A[i, k]*B[k, j];
                        }

                    }
                }
            }
            else if (nn1 == n){
                answer = new int[nn, n1];
                for(int i = 0; i < nn; i++){
                    for (int j = 0; j < n1; j++){
                        for(int k = 0; k < nn1; k++){
                            answer[i, j]+=B[i, k]*A[k, j];
                        }

                    }
                }
            }

            return answer;
        }
        public int[][] Task11(int[,] matrix)
        {
            int[][] answer = null;
            int n = matrix.GetLength(0), n1 = matrix.GetLength(1);
            answer = new int[n][];
            for (int i = 0; i < n; i++){
                int k = 0;
                for (int j = 0; j < n1; j++){
                    if (matrix[i, j]>0){
                        k++;
                    }
                }
                answer[i] = new int[k];
                int k1 = 0;
                for (int j = 0; j<n1; j++){
                    if(matrix[i, j]>0){
                        answer[i][k1++] = matrix[i, j];
                    }
                }
            }

            return answer;
        }
        public int[,] Task12(int[][] array)
        {
            int[,] answer = null;
            int n = array.Length;
            int n1 = 0;
            for (int i = 0; i < n; i++){
                n1 += array[i].Length;
            }
            int k = 1;
            while(k*k < n1){
                k++;
            }
            answer = new int[k, k];
            int j1 = 0, j = 0;
            for (int i = 0; i < k; i++){
                int t = 0;
                while (t < k && j != array.Length){
                    if(j1 < array[j].Length){
                        answer[i, t++] = array[j][j1++];
                    }
                    if (j1 == array[j].Length){
                        j++;
                        j1 = 0;
                    }
                }
                                
            }
            return answer;

        }
    }
}