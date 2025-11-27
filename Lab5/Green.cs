using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design.Serialization;
using System.Diagnostics.CodeAnalysis;
using System.Transactions;

namespace Lab5 {
    public class Green {
        public int[] Task1(int[,] matrix) {
            int[] answer = null;
            // code here

            var rows = matrix.GetLength(0);
            var cols = matrix.GetLength(1);
            answer = new int[rows];

            for (var r = 0; r < rows; r += 1) {
                for (var c = 0; c < cols; c += 1) {
                    if (matrix[r, c] < matrix[r, answer[r]]) {
                        answer[r] = c;
                    }
                }
            }

            // end
            return answer;
        }

        public void Task2(int[,] matrix) {
            // code here

            var rows = matrix.GetLength(0);
            var cols = matrix.GetLength(1);

            for (var r = 0; r < rows; r += 1) {
                var max_c = 0;

                for (var c = 0; c < cols; c += 1) {
                    if (matrix[r, c] > matrix[r, max_c]) {
                        max_c = c;
                    }
                }

                var max_item = (double)matrix[r, max_c];

                for (var c = 0; c < max_c; c += 1) {
                    if (matrix[r, c] < 0) {
                        matrix[r, c] = (int)Math.Floor(matrix[r, c] / max_item);
                    }
                }
            }

            // end
        }
        public void Task3(int[,] matrix, int k) {
            // code here

            var size = matrix.GetLength(0);

            if (matrix.GetLength(1) != size) {
                return;
            }

            if (k >= size) {
                return;
            }

            var max_item_index = 0;
            for (var i = 0; i < size; i += 1) {
                if (matrix[i, i] > matrix[max_item_index, max_item_index]) {
                    max_item_index = i;
                }
            }

            if (k == max_item_index) {
                return;
            }

            for (var i = 0; i < size; i += 1) {
                (matrix[i, max_item_index], matrix[i, k]) = (matrix[i, k], matrix[i, max_item_index]);
            }

            // end
        }
        public void Task4(int[,] matrix) {
            // code here

            var rows = matrix.GetLength(0);
            var cols = matrix.GetLength(1);

            if (cols != rows) {
                return;
            }

            var max_item_row = 0;
            var max_item_col = 0;

            for (var r = 0; r < rows; r += 1) {
                for (var c = 0; c < cols; c += 1) {
                    if (matrix[r, c] > matrix[max_item_row, max_item_col]) {
                        max_item_col = c;
                        max_item_row = r;
                    }
                }
            }
            /*
Input: Matrix [4x4]
 1      2       4       6
 5     -6       7      11
-1      4      -5       6
 1      4       5       6

Output: Matrix [4x4]
 1      2       4       5
 6     11       6       6
-1      4      -5       7
 1      4       5      -6

Answer: Matrix [4x4]
 1      2       4       5
 6     11       6       6
-1      4      -5       7
 1      4       5      11 --- Ошибка, пропал элемент =(-6)
            */

            /*
            * 0 1 2 3 4
            0     |
            1 - - x - -
            2     |   
            3     | 
            4     | 
            */

            for (int i = 0; i < rows; i += 1) {
                (matrix[i, max_item_col], matrix[max_item_row, i]) = (matrix[max_item_row, i], matrix[i, max_item_col]);
                // (matrix[max_item_col, i], matrix[i, max_item_row]) = (matrix[i, max_item_row], matrix[max_item_col, i]);
                // matrix[max_item_row, i] = matrix[i, max_item_col];
            }

            // end
        }
        public int[,] Task5(int[,] matrix) {
            int[,] answer = null;
            // code here

            var rows = matrix.GetLength(0);
            var cols = matrix.GetLength(1);

            var target_row_index = 0;
            var target_row_items_sum = 0;

            for (var r = 0; r < rows; r += 1) {
                var current_row_items_sum = 0;
                for (var c = 0; c < cols; c += 1) {
                    var item = matrix[r, c];
                    if (item > 0) {
                        current_row_items_sum += item;
                    }
                }

                if (current_row_items_sum > target_row_items_sum) {
                    target_row_index = r;
                    target_row_items_sum = current_row_items_sum;
                }
            }

            answer = new int[rows - 1, cols];

            for (var c = 0; c < cols; c += 1) {
                for (var r = 0; r < target_row_index; r += 1) {
                    answer[r, c] = matrix[r, c];
                }

                for (var r = target_row_index + 1; r < rows; r += 1) {
                    answer[r - 1, c] = matrix[r, c];
                }
            }

            // end
            return answer;
        }
        public void Task6(int[,] matrix) {
            // code here

            var rows = matrix.GetLength(0);
            var cols = matrix.GetLength(1);

            var row_negative_items_map = new int[rows];

            for (var r = 0; r < rows; r += 1) {
                for (var c = 0; c < cols; c += 1) {
                    if (matrix[r, c] < 0) {
                        row_negative_items_map[r] += 1;
                    }
                }
            }

            var min_negatives_index = 0;
            var max_negatives_index = 0;

            for (var r = 0; r < rows; r += 1) {
                var item = row_negative_items_map[r];

                if (row_negative_items_map[min_negatives_index] < item) {
                    min_negatives_index = r;
                }

                if (row_negative_items_map[max_negatives_index] > item) {
                    max_negatives_index = r;
                }
            }

            for (var c = 0; c < cols; c += 1) {
                (matrix[min_negatives_index, c], matrix[max_negatives_index, c]) = (matrix[max_negatives_index, c], matrix[min_negatives_index, c]);
            }

            // end
        }
        public int[,] Task7(int[,] matrix, int[] array) {
            int[,] answer = null;
            // code here

            var rows = matrix.GetLength(0);
            var cols = matrix.GetLength(1);

            if (rows != array.Length) {
                return matrix;
            }

            var min_item_row = 0;
            var min_item_col = 0;

            for (var r = 0; r < rows; r += 1) {
                for (var c = 0; c < cols; c += 1) {
                    if (matrix[r, c] < matrix[min_item_row, min_item_col]) {
                        min_item_col = c;
                        min_item_row = r;
                    }
                }
            }

            answer = new int[rows, cols + 1];

            for (var r = 0; r < rows; r += 1) {
                for (var c = 0; c < min_item_col + 1; c += 1) {
                    answer[r, c] = matrix[r, c];
                }

                answer[r, min_item_col + 1] = array[r];

                for (var c = min_item_col + 1; c < cols; c += 1) {
                    answer[r, c + 1] = matrix[r, c];
                }
            }

            // end
            return answer;
        }
        public void Task8(int[,] matrix) {
            // code here

            var rows = matrix.GetLength(0);
            var cols = matrix.GetLength(1);

            for (var c = 0; c < cols; c += 1) {
                var positives = 0;
                var negatives = 0;

                var max_item_row = 0;

                for (var r = 0; r < rows; r += 1) {
                    var item = matrix[r, c];

                    if (item > 0) {
                        positives += 1;
                    }

                    if (item < 0) {
                        negatives += 1;
                    }

                    if (item > matrix[max_item_row, c]) {
                        max_item_row = r;
                    }
                }

                if (positives > negatives) {
                    matrix[max_item_row, c] = 0;
                }

                if (negatives > positives) {
                    matrix[max_item_row, c] = max_item_row;
                }
            }

            // end
        }
        public void Task9(int[,] matrix) {
            // code here

            var size = matrix.GetLength(0);

            if (size != matrix.GetLength(1)) {
                return;
            }

            var last_index = size - 1;

            for (var i = 0; i < size; i += 1) {
                matrix[0, i] = 0;
                matrix[last_index, i] = 0;
                matrix[i, 0] = 0;
                matrix[i, last_index] = 0;
            }

            // end
        }
        public (int[] A, int[] B) Task10(int[,] matrix) {
            int[] A = null, B = null;
            // code here

            /*
            6x6 
            5 + 4 + 3 + 2 + 1 = 10 = (6 * 6 - 6) / 2

            NxN => (N * N - N) / 2

            * 0 1 2 3 4 5
            0 *     i > j
            1   *     
            2     *   
            3       *
            4         *
            5  i < j    *
            */
            var size = matrix.GetLength(0);

            if (size != matrix.GetLength(1)) {
                return (A, B);
            }

            var items = (size * size - size) / 2;

            A = new int[items + size];
            var a_cursor = 0;

            B = new int[items];
            var b_cursor = 0;

            for (var i = 0; i < size; i += 1) {
                for (var j = 0; j < size; j += 1) {
                    var item = matrix[i, j];

                    if (i <= j) {
                        A[a_cursor] = item;
                        a_cursor += 1;
                    }

                    if (i > j) {
                        B[b_cursor] = item;
                        b_cursor += 1;
                    }
                }
            }

            // end
            return (A, B);
        }
        public void Task11(int[,] matrix) {
            // code here
            
            if (null == matrix) { return; }
             
            var rows = matrix.GetLength(0);
            var cols = matrix.GetLength(1);
            
            for (var j = 0; j < cols; j += 1) {
            	for (var i = 0; i < rows - 1; i += 1) {
            		ref var a = ref matrix[i, j];
            		
            		for (var k = i + 1; k < rows; k += 1) {
            			ref var b = ref matrix[k, j];
            			
            			if ((j % 2 == 0) ? (a < b) : (a > b)) {
            				(a, b) = (b, a);
            			}
            		}
            	} 
            }
            
            // end
        }
        public void Task12(int[][] array) {
            // code here

            var n = array.Length - 1;

            for (var i = 0; i <= n; i += 1) {

                bool skip = true;
                for (var j = 0; i + j < n; j += 1) {
                    // 
                    ref var a = ref array[j];
                    ref var b = ref array[j + 1];

                    var key_a = a.Length;
                    var key_b = b.Length;

                    if (key_a == key_b) {
                        key_a = a.Sum();
                        key_b = b.Sum();
                    }

                    if (key_a < key_b) {
                        (b, a) = (a, b);
                        skip = false;
                    }
                }

                if (skip) {
                    break;
                }
            }

            // end
        }
    }

}
