namespace Lab5 {
    public class Blue {
        public double[] Task1(int[,] matrix) {
            double[] answer = null;
            // code here

            var rows = matrix.GetLength(0);
            var cols = matrix.GetLength(1);

            answer = new double[rows];

            for (var row_index = 0; row_index < rows; row_index += 1) {
                var positives = 0;

                for (var col_index = 0; col_index < cols; col_index += 1) {
                    var item = matrix[row_index, col_index];

                    if (0.0 >= item) { continue; }

                    positives += 1;
                    answer[row_index] += item;
                }

                if (0 == positives) { continue; }

                answer[row_index] /= positives;
            }

            // end
            return answer;
        }

        public int[,] Task2(int[,] matrix) {
            int[,] answer = null;
            // code here

            var rows = matrix.GetLength(0);
            var cols = matrix.GetLength(1);

            var max_item_row = 0;
            var max_item_col = 0;

            for (var row = 0; row < rows; row += 1) {
                for (var col = 0; col < cols; col += 1) {
                    if (matrix[row, col] > matrix[max_item_row, max_item_col]) {
                        max_item_row = row;
                        max_item_col = col;
                    }
                }
            }

            answer = new int[rows - 1, cols - 1];

            for (var row = 0; row < max_item_row; row += 1) {
                for (int col = 0; col < max_item_col; col += 1) {
                    answer[row, col] = matrix[row, col];
                }

                for (int col = max_item_col + 1; col < cols; col += 1) {
                    answer[row, col - 1] = matrix[row, col];
                }
            }

            for (var row = max_item_row + 1; row < rows; row += 1) {
                for (int col = 0; col < max_item_col; col += 1) {
                    answer[row - 1, col] = matrix[row, col];
                }

                for (int col = max_item_col + 1; col < cols; col += 1) {
                    answer[row - 1, col - 1] = matrix[row, col];
                }
            }

            // end
            return answer;
        }

        public void Task3(int[,] matrix) {
            // code here

            var rows = matrix.GetLength(0);
            var cols = matrix.GetLength(1);

            // end
        }

        public int[,] Task4(int[,] matrix) {
            int[,] answer = null;
            // code here

            // var rows = matrix.GetLength(0);
            // var cols = matrix.GetLength(1);

            // answer

            // end
            return answer;
        }

        public int[] Task5(int[,] matrix) {
            int[] answer = null;

            // code here

            // end

            return answer;
        }

        public void Task6(int[,] matrix, int k) {

            // code here

            // end

        }

        public void Task7(int[,] matrix, int[] array) {

            // code here

            // end

        }

        public void Task8(int[,] matrix) {

            // code here

            // end

        }

        public void Task9(int[,] matrix) {

            // code here

            // end

        }

        public void Task10(int[,] matrix) {

            // code here

            // end

        }

        public void Task11(int[,] matrix) {

            // code here

            // end

        }

        public int[][] Task12(int[][] array) {
            int[][] answer = null;

            // code here

            // end

            return answer;
        }
    }
}