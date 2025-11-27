namespace Lab5
{
    public class Purple
    {
        public int[] Task1(int[,] matrix)
        {
            int[] answer = null;

            // code here
            int num_of_rows = matrix.GetLength(0), num_of_columns = matrix.GetLength(1);
            answer = new int[num_of_columns];
            int k = 0;
            for (int j = 0; j < num_of_columns; j++)
            {
                int n_count = 0;
                for (int i = 0; i < num_of_rows; i++)
                {
                    if (matrix[i,j] < 0) n_count++;
                }
                answer[j]=n_count;
            }
            // end

            return answer;
        }
        public void Task2(int[,] matrix)
        {

            // code here
            int num_of_rows = matrix.GetLength(0), num_of_columns = matrix.GetLength(1);
            for (int i = 0; i < num_of_rows; i++)
            {
                int min_j = -1, min_value = int.MaxValue;
                for (int j = 0; j < num_of_columns; j++) //min element and it's index
                {
                    if (matrix[i,j]<min_value)
                    {
                        min_j=j;
                        min_value = matrix[i,j];
                    }
                }
                // int min_value = matrix[i,min_j];
                int[] values = new int[num_of_columns-1];
                int k = 0;
                for (int j = 0; j < num_of_columns; j++) //aaray with edited row
                {
                    if (j != min_j)
                    {
                        values[k]=matrix[i,j];
                        k++;
                    }
                }
                matrix[i,0]=matrix[i,min_j];
                for (int j = 1; j < num_of_columns; j++) //replacing row with edited array
                {
                    matrix[i,j]=values[j-1];
                }
            }
            // end

}
        public int[,] Task3(int[,] matrix)
        {
            int[,] answer = null;

            // code here
            int num_of_rows = matrix.GetLength(0), num_of_columns = matrix.GetLength(1);
            answer = new int[num_of_rows, num_of_columns+1];
            for (int i = 0; i < num_of_rows; i++)
            {
                int max_j = -1, max_value = int.MinValue;
                for (int j = 0; j < num_of_columns; j++) //max element and it's index
                {
                    if (matrix[i,j]>max_value)
                    {
                        max_j=j;
                        max_value = matrix[i,j];
                    }
                }
                // int min_value = matrix[i,min_j];
                int[] values = new int[num_of_columns+1];
                int k = 0;
                for (int j = 0; j < num_of_columns; j++) //arr with edited row
                {
                    values[k]=matrix[i,j];
                    k++;
                    if (j==max_j)
                    {
                        values[k]=matrix[i,j];
                        k++;
                    }
                }
                
                for (int j = 0; j < num_of_columns+1; j++) //filling row with edited array
                {
                    answer[i,j]=values[j];
                }
            }
            // end

            return answer;
        }
        public void Task4(int[,] matrix)
        {

            // code here
            int num_of_rows = matrix.GetLength(0), num_of_columns = matrix.GetLength(1);
            for (int i = 0; i < num_of_rows; i++)
            {
                int max_j = -1, max_value = int.MinValue;
                for (int j = 0; j < num_of_columns; j++) //max element and it's index
                {
                    if (matrix[i,j]>max_value)
                    {
                        max_j=j;
                        max_value = matrix[i,j];
                    }
                }

                int mean = 0, mean_k = 0; //calculating mean
                for (int j = max_j+1; j < num_of_columns; j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        mean+=matrix[i,j];
                        mean_k++;
                    }
                }
                if (mean_k > 0)
                {
                    mean/=mean_k;

                    for (int j = 0; j < max_j; j++)
                    {
                        if (matrix[i, j] < 0)
                        {
                            matrix[i,j]=mean;
                        }
                    }
                }
            }
            // end

        }
        public void Task5(int[,] matrix, int k)
        {

            // code here
            int num_of_rows = matrix.GetLength(0), num_of_columns = matrix.GetLength(1);
            int[] max_vals = new int[num_of_rows];
            int c = 0;
            for (int i = 0; i < num_of_rows; i++)
            {
                int max_j = -1, max_value = int.MinValue;
                for (int j = 0; j < num_of_columns; j++) //max element and it's index
                {
                    if (matrix[i,j]>max_value)
                    {
                        max_j=j;
                        max_value = matrix[i,j];
                    }
                }
                max_vals[num_of_rows-1-c]=max_value;
                c++;
            }
            if (k<num_of_columns)
            {
                for (int i = 0; i<num_of_rows; i++)
                {
                    matrix[i,k]=max_vals[i];
                }
            }
            // end

        }
        public void Task6(int[,] matrix, int[] array)
        {

            // code here
            int num_of_rows = matrix.GetLength(0), num_of_columns = matrix.GetLength(1);
            for (int j = 0; j < num_of_columns; j++)
            {
                int max_i = -1, max_value = int.MinValue;
                for (int i = 0; i < num_of_rows; i++)
                {
                    if (matrix[i,j]>max_value)
                    {
                        max_i=i;
                        max_value = matrix[i,j];
                    }
                }
                if (array.Length==num_of_columns && array[j]>matrix[max_i,j])
                {
                    matrix[max_i,j]=array[j];
                }
            }
            // end

        }
        public void Task7(int[,] matrix)
        {

            // code here
            int rows = matrix.GetLength(0), columns = matrix.GetLength(1);
            int[] min_elemnets= new int[rows];
            for (int i = 0; i < rows; i++)
            {
                int min_j = 0;
                for (int j = 0; j < columns; j++)
                {
                    if (matrix[i, j]<matrix[i,min_j]) min_j=j;
                }
                min_elemnets[i]=matrix[i,min_j];
            }

            for (int i = 0; i < rows; i++)
            {
                bool swap = false;
                for (int j = 0; j < rows - 1 - i; j++)
                {
                    if (min_elemnets[j] < min_elemnets[j + 1])
                    {
                        (min_elemnets[j], min_elemnets[j+1]) = (min_elemnets[j+1], min_elemnets[j]);
                        for (int col = 0; col < columns; col++) //swapping rows in matrix
                        {
                            int temp = matrix[j,col];
                            matrix[j,col] = matrix[j+1,col];
                            matrix[j+1,col] = temp;
                        }
                        swap = true;
                    }
                }
                if (swap == false) break;
            }
            // end

        }
        public int[] Task8(int[,] matrix)
        {
            int[] answer = null;

            // code here
            int rows = matrix.GetLength(0), columns = matrix.GetLength(1);
            if (rows == columns)
            {
                answer = new int[2*rows-1];
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < columns; j++)
                    {
                        answer[rows-1+(j-i)]+=matrix[i,j];
                    }
                }
            }
            // end

            return answer;
        }
        public void Task9(int[,] matrix, int k)
        {

            // code here
            int rows = matrix.GetLength(0), columns = matrix.GetLength(1);
            if (rows == columns && k<rows)
            {
                //max elements
                int max_i=0, max_j=0;
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < columns; j++)
                    {
                        if ( Math.Abs(matrix[i, j]) > Math.Abs(matrix[max_i, max_j]) )
                        {
                            max_i=i;
                            max_j=j;
                        }
                    }
                }
                int[,] temp = new int[rows,rows];
                //shfting matrix by rows
                for (int j = 0; j < rows; j++) //temp is matrix with shifted rows
                {
                    for (int i = 0; i < rows; i++)
                    {
                        if (i == k)
                        {
                            temp[i,j]=matrix[max_i,j];
                        }
                        else if (k<max_i && i > k && i <= max_i)
                        {
                            temp[i,j]=matrix[i-1,j];
                        }
                        else if (k>max_i && i>=max_i && i < k)
                        {
                            temp[i,j]=matrix[i+1,j];
                        }
                        else
                        {
                            temp[i,j]=matrix[i,j];
                        }
                    }
                }
                for (int i = 0; i < rows; i++) //rewriting og matrix
                {
                    for (int j = 0; j < columns; j++)
                    {
                        matrix[i,j]=temp[i,j];
                    }
                }
                //shfting matrix by columns
                for (int i = 0; i < rows; i++) //temp is matrix with shifted cols
                {
                    for (int j = 0; j < rows; j++)
                    {
                        if (j == k)
                        {
                            temp[i,j]=matrix[i,max_j];
                        }
                        else if (k<max_j && j > k && j <= max_j)
                        {
                            temp[i,j]=matrix[i,j-1];
                        }
                        else if (k>max_j && j>=max_j && j < k)
                        {
                            temp[i,j]=matrix[i,j+1];
                        }
                        else
                        {
                            temp[i,j]=matrix[i,j];
                        }
                    }
                }
                for (int i = 0; i < rows; i++) //rewriting og matrix
                {
                    for (int j = 0; j < columns; j++)
                    {
                        matrix[i,j]=temp[i,j];
                    }
                }
            }
            // end

        }
        public int[,] Task10(int[,] A, int[,] B)
        {
            int[,] answer = null;

            // code here
            int rA = A.GetLength(0), cA = A.GetLength(1);
            int rB = B.GetLength(0), cB = B.GetLength(1);
            
            if (cA == rB)
            {
                answer = new int[rA,cB];
                for (int i = 0; i < rA; i++)
                {
                    for (int j = 0; j < cB; j++)
                    {
                        int sum = 0;
                        for (int x = 0; x < cA;x++)
                        {
                            sum+= A[i,x]*B[x,j];
                        }
                        answer[i,j]=sum;
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
            int rows = matrix.GetLength(0), columns = matrix.GetLength(1);
            answer=new int[rows][];
            for (int i = 0; i<rows; i++)
            {
                int count = 0;
                for (int j = 0; j<columns; j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        count++;
                    }
                    if (count>0)
                    {
                        answer[i]=new int[count];
                    }
                }
            }

            for (int i = 0; i<rows; i++)
            {
                int k = 0;
                for (int j = 0; j<columns; j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        answer[i][k]=matrix[i,j];
                        k++;
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
            int maxlen=0;

            for (int i = 0; i<array.Length; i++)
            {
                maxlen+=array[i].Length;
            }

            int side = (int)Math.Ceiling(Math.Sqrt(maxlen));
            answer = new int[side,side];

            int y=0,x=0;
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    try
                    {
                        answer[y,x]=array[i][j];
                        x++;
                    }
                    catch (System.IndexOutOfRangeException)
                    {
                        y++;
                        x=0;
                        answer[y,x]=array[i][j];
                        x++;
                    }
                }
            }
            // end

            return answer;
        }
    }

}
