using System.Transactions;

namespace Lab5test
{
    [TestClass]
    public sealed class BlueTest
    {
        Lab5.Blue _main = new Lab5.Blue();
        const double E = 0.0001;
        Data _data = new Data();

        [TestMethod]
        public void Test01()
        {
            // Arrange
            var input = _data.GetMatrixes();
            var answer = new double[][] {
                new double[] { 4, 8, 12, 16, 3.5 },
                new double[] { 1, 5, 9, 13 },
                new double[] { 3.5, 7.666666666666667, 4 },
                new double[] { 3.25, 7.666666666666667, 5, 4 },
                new double[] { 4, 7.833333333333333, 9.5, 16.5 },
                new double[] { 2, 8, 0 },
                new double[] { 6 },
                new double[] { 2.5, 7.6, 1, 0, 5 },
                new double[] { 2.5, 7.6, 1, 15, 5, 8.25, 1.6666666666666667, 5 },
                new double[] { 2.5, 8.5, 0, 0, 0 }
                };
            var test = new double[answer.Length][];
            // Act
            for (int i = 0; i < answer.Length; i++)
            {
                test[i] = _main.Task1(input[i]);
            }
            // Assert
            for (int i = 0; i < answer.Length; i++)
            {
                Assert.AreEqual(answer[i].Length, test[i].Length);
                for (int j = 0; j < answer[i].Length; j++)
                {
                    Assert.AreEqual(answer[i][j], test[i][j], E);
                }
            }
        }
        [TestMethod]
        public void Test02()
        {
            // Arrange
            var input = _data.GetMatrixes();
            var answer = new int[][,] {
                new int[,] {
                    {1, 2, 3, 4, 5, 6},
                    {5, 6, 7, 8, 9, 10},
                    {9, 10, 11, 12, 13, 14},
                    {0, 1, 2, 3, 4, 5},
                },
                new int[,] {
                    {},
                    {},
                    {},
                },
                new int[,] {
                    {1, 2, 3, 4, 5},
                    {0, 2, 3, 4, 5},
                },
                new int[,] {
                    {1, 2, 4},
                    {-1, 4, -5},
                    {1, 4, 5},
                },
                new int[,] {
                    {1, 2, 3, 4, 5, 7},
                    {5, 6, 7, 8, -9, 11},
                    {9, 10, -11, -12, -13, -15},
                },
                new int[,] {
                    {1, 3},
                    {0, -3},
                },
                new int[,] {
                },
                new int[,] {
                    {1, 3, 4, -5, -6, -7},
                    {-9, -11, -14, -15, -16, 1},
                    {-9, -11, -14, -15, -6, -2},
                    {-9, -11, -14, -15, 6, 4},
                },
                new int[,] {
                    {1, 2, 3, 4, -6, -7},
                    {5, 11, -17, 11, 6, 5},
                    {-9, -10, -11, -14, -16, 1},
                    {-9, -10, -11, -14, 6, 4},
                    {5, 11, -17, 11, 6, -5},
                    {1, 1, -2, 3, 0, 0},
                    {0, -2, -3, -4, 0, 5},
                },
                new int[,] {
                    {1, 3, 4, -5},
                    {-9, -11, -14, -15},
                    {-9, -11, -14, -6},
                    {0, -3, -4, -5},
                }
            };
            var test = new int[answer.Length][,];
            // Act
            for (int i = 0; i < answer.Length; i++)
            {
                test[i] = _main.Task2(input[i]);
            }
            // Assert
            for (int i = 0; i < answer.Length; i++)
            {
                Assert.AreEqual(answer[i].GetLength(0), test[i].GetLength(0));
                for (int j = 0; j < answer[i].GetLength(0); j++)
                {
                    Assert.AreEqual(answer[i].GetLength(1), test[i].GetLength(1));
                    for (int k = 0; k < answer[i].GetLength(1); k++)
                    {
                        Assert.AreEqual(answer[i][j, k], test[i][j, k]);
                    }
                }
            }
        }
        [TestMethod]
        public void Test03()
        {
            // Arrange
            var input = _data.GetMatrixes();
            var inputk = new int[10] { 1, 2, 3, 4, 5, 0, 1, 3, 5, 7 };
            var answer = new int[][,] {
                new int[,] {
                    {1, 2, 3, 4, 5, 6, 7},
                    {5, 6, 7, 8, 9, 10, 11},
                    {9, 10, 11, 12, 13, 14, 15},
                    {13, 14, 15, 16, 17, 18, 19},
                    {0, 1, 2, 3, 4, 5, 6},
                },
                new int[,] {
                    {1},
                    {5},
                    {9},
                    {13},
                },
                new int[,] {
                    {1, 2, 3, 4, 5, 6},
                    {5, 6, 7, 8, 9, 11},
                    {0, 2, 3, 4, 5, 6},
                },
                new int[,] {
                    {1, 2, 4, 6},
                    {5, -6, 7, 11},
                    {-1, 4, -5, 6},
                    {1, 4, 5, 6},
                },
                new int[,] {
                    {1, 2, 3, 4, 5, 6, 7},
                    {5, 6, 7, 8, -9, 10, 11},
                    {9, -11, -12, -13, -14, -15, 10},
                    {-13, -14, 15, 16, 17, -19, 18},
                },
                new int[,] {
                    {1, 2, 3},
                    {5, -17, 11},
                    {-2, -3, 0},
                },
                new int[,] {
                    {-9, -10, -11, -14, -15, 6},
                },
                new int[,] {
                    {1, 2, 3, -5, -6, -7, 4},
                    {5, -17, 11, -10, 6, 5, 11},
                    {-9, -10, -11, -14, -15, -16, 1},
                    {-9, -10, -11, -14, -15, -6, -2},
                    {-9, -10, -11, -14, -15, 4, 6},
                },
                new int[,] {
                    {1, 2, 3, -5, -6, -7, 4},
                    {5, -17, 11, -10, 6, 5, 11},
                    {-9, -10, -11, -14, -15, -16, 1},
                    {-9, -10, -11, -14, -6, -2, 15},
                    {-9, -10, -11, -14, -15, 4, 6},
                    {5, -17, 11, -10, 6, -5, 11},
                    {1, 1, -2, -4, 0, 0, 3},
                    {0, -2, -3, -4, -5, 0, 5},
                },
                new int[,] {
                    {1, 2, 3, -5, 4},
                    {5, -17, 11, 7, 11},
                    {-10, -11, -14, -15, -9},
                    {-9, -10, -11, -14, -6},
                    {-2, -3, -4, -5, 0},
                }
            };
            // Act
            for (int i = 0; i < answer.Length; i++)
            {
                _main.Task3(input[i]);
            }
            // Assert
            for (int i = 0; i < answer.Length; i++)
            {
                Assert.AreEqual(answer[i].GetLength(0), input[i].GetLength(0));
                for (int j = 0; j < answer[i].GetLength(0); j++)
                {
                    Assert.AreEqual(answer[i].GetLength(1), input[i].GetLength(1));
                    for (int k = 0; k < answer[i].GetLength(1); k++)
                    {
                        Assert.AreEqual(answer[i][j, k], input[i][j, k]);
                    }
                }
            }
        }
        [TestMethod]
        public void Test04()
        {
            // Arrange
            var input = _data.GetMatrixes();
            var answer = new int[][,] {
                new int[,] {
                    {1, 2, 3, 4, 5, 6, 7, 7},
                    {5, 6, 7, 8, 9, 10, 11, 11},
                    {9, 10, 11, 12, 13, 14, 15, 15},
                    {13, 14, 15, 16, 17, 18, 19, 19},
                    {0, 1, 2, 3, 4, 5, 6, 6},
                },
                new int[,] {
                    {1, 1},
                    {5, 5},
                    {9, 9},
                    {13, 13},
                },
                new int[,] {
                    {1, 2, 3, 4, 5, 6, 6},
                    {5, 6, 7, 8, 9, 11, 11},
                    {0, 2, 3, 4, 5, 6, 6},
                },
                new int[,] {
                    {1, 2, 4, 6, 6},
                    {5, -6, 7, 11, 11},
                    {-1, 4, -5, 6, 6},
                    {1, 4, 5, 6, 6},
                },
                new int[,] {
                    {1, 2, 3, 4, 5, 6, 7, 7},
                    {5, 6, 7, 8, -9, 10, 11, 11},
                    {9, 10, -11, -12, -13, -14, 10, -15},
                    {-13, -14, 15, 16, 17, 18, 18, -19},
                },
                new int[,] {
                    {1, 2, 3, 3},
                    {5, 11, 11, -17},
                    {0, -2, 0, -3},
                },
                new int[,] {
                    {-9, -10, -11, -14, -15, 6, 6},
                },
                new int[,] {
                    {1, 2, 3, 4, -5, -6, 4, -7},
                    {5, 11, -17, 11, -10, 6, 11, 5},
                    {-9, -10, -11, -14, -15, -16, 1, 1},
                    {-9, -10, -11, -14, -15, -6, -2, -2},
                    {-9, -10, -11, -14, -15, 6, 6, 4},
                },
                new int[,] {
                    {1, 2, 3, 4, -5, -6, 4, -7},
                    {5, 11, -17, 11, -10, 6, 11, 5},
                    {-9, -10, -11, -14, -15, -16, 1, 1},
                    {-9, -10, -11, -14, 15, -6, 15, -2},
                    {-9, -10, -11, -14, -15, 6, 6, 4},
                    {5, 11, -17, 11, -10, 6, 11, -5},
                    {1, 1, -2, 3, -4, 0, 3, 0},
                    {0, -2, -3, -4, -5, 0, 5, 5},
                },
                new int[,] {
                    {1, 2, 3, 4, 4, -5},
                    {5, 11, -17, 11, 11, 7},
                    {-9, -10, -11, -14, -9, -15},
                    {-9, -10, -11, -14, -6, -6},
                    {0, -2, -3, -4, 0, -5},
                }
            };
            var test = new int[answer.Length][,];
            // Act
            for (int i = 0; i < answer.Length; i++)
            {
                test[i] = _main.Task4(input[i]);
            }
            // Assert
            for (int i = 0; i < answer.Length; i++)
            {
                Assert.AreEqual(answer[i].GetLength(0), test[i].GetLength(0));
                for (int j = 0; j < answer[i].GetLength(0); j++)
                {
                    Assert.AreEqual(answer[i].GetLength(1), test[i].GetLength(1));
                    for (int k = 0; k < answer[i].GetLength(1); k++)
                    {
                        Assert.AreEqual(answer[i][j, k], test[i][j, k]);
                    }
                }
            }
        }
        [TestMethod]
        public void Test05()
        {
            // Arrange
            var input = _data.GetMatrixes();
            var answer = new int[][] {
                new int[] { 2, 4, 6, 5, 7, 9, 11, 10, 12, 14, 13, 15, 17, 19, 1, 3, 5 },
                new int[] { 5, 13 },
                new int[] { 2, 4, 6, 5, 7, 9, 2, 4, 6 },
                new int[] { 2, 6, 5, 7, 4, 6, 1, 5 },
                new int[] { 2, 4, 6, 5, 7, -9, 11, 10, -12, -14, -13, 15, 17, -19 },
                new int[] { 2, 5, -17, -2 },
                new int[] { -10, -14, 6 },
                new int[] { 2, 4, -6, 5, -17, -10, 5, -10, -14, -16, -9, -11, -15, -2, -10, -14, 6 },
                new int[] { 2, 4, -6, 5, -17, -10, 5, -10, -14, -16, -9, -11, 15, -2, -10, -14, 6, 5, -17, -10, -5, 1, 3, 0, 0, -3, -5, 5 },
                new int[] { 2, 4, 5, -17, 7, -10, -14, -9, -11, -6, -2, -4 },
            };
            var test = new int[answer.Length][];
            // Act
            for (int i = 0; i < answer.Length; i++)
            {
                test[i] = _main.Task5(input[i]);
            }
            // Assert
            for (int i = 0; i < answer.Length; i++)
            {
                Assert.AreEqual(answer[i].Length, test[i].Length);
                for (int j = 0; j < answer[i].Length; j++)
                {
                    Assert.AreEqual(answer[i][j], test[i][j]);
                }
            }
        }
        [TestMethod]
        public void Test06()
        {
            // Arrange
            var input = _data.GetMatrixes();
            var inputk = new int[10] { 1, 2, 3, 1, 2, 0, 1, 3, 1, 2 };
            var answer = new int[][,] {
                new int[,] {
                    {1, 2, 3, 4, 5, 6, 7},
                    {5, 6, 7, 8, 9, 10, 11},
                    {9, 10, 11, 12, 13, 14, 15},
                    {13, 14, 15, 16, 17, 18, 19},
                    {0, 1, 2, 3, 4, 5, 6},
                },
                new int[,] {
                    {1},
                    {5},
                    {9},
                    {13},
                },
                new int[,] {
                    {1, 2, 3, 4, 5, 6},
                    {5, 6, 7, 8, 9, 11},
                    {0, 2, 3, 4, 5, 6},
                },
                new int[,] {
                    {1, 2, 4, 6},
                    {1, 4, 5, 6},
                    {-1, 4, -5, 6},
                    {5, -6, 7, 11},
                },
                new int[,] {
                    {1, 2, 3, 4, 5, 6, 7},
                    {5, 6, 7, 8, -9, 10, 11},
                    {9, 10, -11, -12, -13, -14, -15},
                    {-13, -14, 15, 16, 17, 18, -19},
                },
                new int[,] {
                    {1, 2, 3},
                    {5, 11, -17},
                    {0, -2, -3},
                },
                new int[,] {
                    {-9, -10, -11, -14, -15, 6},
                },
                new int[,] {
                    {1, 2, 3, 4, -5, -6, -7},
                    {5, 11, -17, 11, -10, 6, 5},
                    {-9, -10, -11, -14, -15, -16, 1},
                    {-9, -10, -11, -14, -15, -6, -2},
                    {-9, -10, -11, -14, -15, 6, 4},
                },
                new int[,] {
                    {1, 2, 3, 4, -5, -6, -7},
                    {5, 11, -17, 11, -10, 6, 5},
                    {-9, -10, -11, -14, -15, -16, 1},
                    {-9, -10, -11, -14, 15, -6, -2},
                    {-9, -10, -11, -14, -15, 6, 4},
                    {5, 11, -17, 11, -10, 6, -5},
                    {1, 1, -2, 3, -4, 0, 0},
                    {0, -2, -3, -4, -5, 0, 5},
                },
                new int[,] {
                    {1, 2, 3, 4, -5},
                    {5, 11, -17, 11, 7},
                    {-9, -10, -11, -14, -15},
                    {-9, -10, -11, -14, -6},
                    {0, -2, -3, -4, -5},
                }
            };
            // Act
            for (int i = 0; i < answer.Length; i++)
            {
                _main.Task6(input[i], inputk[i]);
            }
            // Assert
            for (int i = 0; i < answer.Length; i++)
            {
                Assert.AreEqual(answer[i].GetLength(0), input[i].GetLength(0));
                for (int j = 0; j < answer[i].GetLength(0); j++)
                {
                    Assert.AreEqual(answer[i].GetLength(1), input[i].GetLength(1));
                    for (int k = 0; k < answer[i].GetLength(1); k++)
                    {
                        Assert.AreEqual(answer[i][j, k], input[i][j, k]);
                    }
                }
            }
        }
        [TestMethod]
        public void Test07()
        {
            // Arrange
            var input = _data.GetMatrixes();
            var inputArray = new int[][] {
                new int[] { -6, -6, -1, -5 },
                new int[] { -6, -6, -1, -5 },
                new int[] { -6, -6, -1, -5 },
                new int[] { -6, -6, -1, -5 },
                new int[] { -9, -11, -12, -13, -14, -15, -13, -14, -19 },
                new int[] { -17, -2, -3 },
                new int[] { -9, -10, -11, -14, -15 },
                new int[] { -5, -6, -7, -17, -10, -9, -10, -11, -14, -15, -16, -9, -10, -11, -14, -15, -6, -2, -9, -10, -11, -14, -15 },
                new int[] { -5 },
                new int[] { -5 }
                };
            var answer = new int[][,] {
                new int[,] {
                    {1, 2, 3, 4, 5, 6, 7},
                    {5, 6, 7, 8, 9, 10, 11},
                    {9, 10, 11, 12, 13, 14, 15},
                    {13, 14, 15, 16, 17, 18, 19},
                    {0, 1, 2, 3, 4, 5, 6},
                },
                new int[,] {
                    {1},
                    {5},
                    {9},
                    {13},
                },
                new int[,] {
                    {1, 2, 3, 4, 5, 6},
                    {5, 6, 7, 8, 9, 11},
                    {0, 2, 3, 4, 5, 6},
                },
                new int[,] {
                    {1, 2, 4, 6},
                    {-6, -6, -1, -5},
                    {-1, 4, -5, 6},
                    {1, 4, 5, 6},
                },
                new int[,] {
                    {1, 2, 3, 4, 5, 6, 7},
                    {5, 6, 7, 8, -9, 10, 11},
                    {9, 10, -11, -12, -13, -14, -15},
                    {-13, -14, 15, 16, 17, 18, -19},
                },
                new int[,] {
                    {1, 2, 3},
                    {-17, -2, -3},
                    {0, -2, -3},
                },
                new int[,] {
                    {-9, -10, -11, -14, -15, 6},
                },
                new int[,] {
                    {1, 2, 3, 4, -5, -6, -7},
                    {5, 11, -17, 11, -10, 6, 5},
                    {-9, -10, -11, -14, -15, -16, 1},
                    {-9, -10, -11, -14, -15, -6, -2},
                    {-9, -10, -11, -14, -15, 6, 4},
                },
                new int[,] {
                    {1, 2, 3, 4, -5, -6, -7},
                    {5, 11, -17, 11, -10, 6, 5},
                    {-9, -10, -11, -14, -15, -16, 1},
                    {-9, -10, -11, -14, 15, -6, -2},
                    {-9, -10, -11, -14, -15, 6, 4},
                    {5, 11, -17, 11, -10, 6, -5},
                    {1, 1, -2, 3, -4, 0, 0},
                    {0, -2, -3, -4, -5, 0, 5},
                }
                };
            // Act
            for (int i = 0; i < answer.Length; i++)
            {
                _main.Task7(input[i], inputArray[i]);
            }
            // Assert
            for (int i = 0; i < answer.Length; i++)
            {
                Assert.AreEqual(answer[i].GetLength(0), input[i].GetLength(0));
                for (int j = 0; j < answer[i].GetLength(0); j++)
                {
                    Assert.AreEqual(answer[i].GetLength(1), input[i].GetLength(1));
                    for (int k = 0; k < answer[i].GetLength(1); k++)
                    {
                        Assert.AreEqual(answer[i][j, k], input[i][j, k]);
                    }
                }
            }
        }
        [TestMethod]
        public void Test08()
        {
            // Arrange
            var input = _data.GetMatrixes();
            var answer = new int[][,] {
                new int[,] {
                    {1, 2, 3, 4, 5, 6, 7},
                    {5, 6, 7, 8, 9, 10, 11},
                    {9, 10, 11, 12, 13, 14, 15},
                    {13, 14, 15, 16, 17, 18, 19},
                    {0, 1, 2, 3, 4, 5, 6},
                },
                new int[,] {
                    {1},
                    {5},
                    {9},
                    {13},
                },
                new int[,] {
                    {1, 2, 3, 4, 5, 6},
                    {5, 6, 7, 8, 9, 11},
                    {0, 2, 3, 4, 5, 6},
                },
                new int[,] {
                    {0, 2, 0, 12},
                    {5, -6, 7, 11},
                    {-1, 4, -5, 6},
                    {1, 4, 5, 6},
                },
                new int[,] {
                    {1, 2, 3, 4, 5, 6, -34},
                    {5, 6, 7, 8, -9, 10, 11},
                    {9, 10, -11, -12, -13, -14, -15},
                    {-13, -14, 15, 16, 17, 18, -19},
                },
                new int[,] {
                    {1, 2, -20},
                    {5, 11, -17},
                    {0, -2, -3},
                },
                new int[,] {
                    {-9, -10, -11, -14, -15, 6},
                },
                new int[,] {
                    {-27, -30, -50, -42, -55, -16, 3},
                    {5, 11, -17, 11, -10, 6, 5},
                    {-9, -10, -11, -14, -15, -16, 1},
                    {-9, -10, -11, -14, -15, -6, -2},
                    {-9, -10, -11, -14, -15, 6, 4},
                },
                new int[,] {
                    {-21, -20, -72, -32, -34, -10, 3},
                    {5, 11, -17, 11, -10, 6, 5},
                    {-9, -10, -11, -14, -15, -16, 1},
                    {-9, -10, -11, -14, 15, -6, -2},
                    {-9, -10, -11, -14, -15, 6, 4},
                    {5, 11, -17, 11, -10, 6, -5},
                    {1, 1, -2, 3, -4, 0, 0},
                    {0, -2, -3, -4, -5, 0, 5},
                }
                };
            // Act
            for (int i = 0; i < answer.Length; i++)
            {
                _main.Task8(input[i]);
            }
            // Assert
            for (int i = 0; i < answer.Length; i++)
            {
                Assert.AreEqual(answer[i].GetLength(0), input[i].GetLength(0));
                for (int j = 0; j < answer[i].GetLength(0); j++)
                {
                    Assert.AreEqual(answer[i].GetLength(1), input[i].GetLength(1));
                    for (int k = 0; k < answer[i].GetLength(1); k++)
                    {
                        Assert.AreEqual(answer[i][j, k], input[i][j, k]);
                    }
                }
            }
        }
        [TestMethod]
        public void Test09()
        {
            // Arrange
            var input = _data.GetMatrixes();
            var answer = new int[][,] {
                new int[,] {
                    {1, 2, 3, 4, 5, 6, 11},
                    {5, 6, 7, 8, 9, 10, 7},
                    {9, 10, 11, 12, 13, 14, 19},
                    {13, 14, 15, 16, 17, 18, 15},
                    {0, 1, 2, 3, 4, 5, 6},
                },
                new int[,] {
                    {5},
                    {1},
                    {13},
                    {9},
                },
                new int[,] {
                    {1, 2, 3, 4, 5, 11},
                    {5, 6, 7, 8, 9, 6},
                    {0, 2, 3, 4, 5, 6},
                },
                new int[,] {
                    {1, 2, 4, 11},
                    {5, -6, 7, 6},
                    {-1, 4, -5, 6},
                    {1, 4, 5, 6},
                },
                new int[,] {
                    {1, 2, 3, 4, 5, 6, 11},
                    {5, 6, 7, 8, -9, 10, 7},
                    {9, 18, -11, -12, -13, -14, -15},
                    {-13, -14, 15, 16, 17, 10, -19},
                },
                new int[,] {
                    {1, 2, 11},
                    {5, 3, -17},
                    {0, -2, -3},
                },
                new int[,] {
                    {-9, -10, -11, -14, -15, 6},
                },
                new int[,] {
                    {1, 2, 3, 11, -5, -6, -7},
                    {5, 4, -17, 11, -10, 6, 5},
                    {-9, -10, -11, -14, -15, -16, -2},
                    {-9, -10, -11, -14, -15, -6, 1},
                    {-9, -10, -11, -14, -15, 6, 4},
                },
                new int[,] {
                    {1, 2, 3, 11, -5, -6, -7},
                    {5, 4, -17, 11, -10, 6, 5},
                    {-9, -10, -11, -14, -15, -16, 15},
                    {-9, -10, -11, -14, 1, -6, -2},
                    {-9, -10, -11, -14, -15, 11, 4},
                    {5, 6, -17, 11, -10, 6, -5},
                    {1, 1, -2, 5, -4, 0, 0},
                    {0, -2, -3, -4, -5, 0, 3},
                },
                new int[,] {
                    {1, 2, 3, 11, -5},
                    {5, 4, -17, 11, 7},
                    {-6, -10, -11, -14, -15},
                    {-9, -10, -11, -14, -9},
                    {0, -2, -3, -4, -5},
                }
                };
            // Act
            for (int i = 0; i < answer.Length; i++)
            {
                _main.Task9(input[i]);
            }
            // Assert
            for (int i = 0; i < answer.Length; i++)
            {
                Assert.AreEqual(answer[i].GetLength(0), input[i].GetLength(0));
                for (int j = 0; j < answer[i].GetLength(0); j++)
                {
                    Assert.AreEqual(answer[i].GetLength(1), input[i].GetLength(1));
                    for (int k = 0; k < answer[i].GetLength(1); k++)
                    {
                        Assert.AreEqual(answer[i][j, k], input[i][j, k]);
                    }
                }
            }
        }
        [TestMethod]
        public void Test10()
        {
            // Arrange
            var input = _data.GetMatrixes();
            var answer = new int[][,] {
                new int[,] {
                    {1, 2, 3, 4, 5, 6, 7},
                    {5, 6, 7, 8, 9, 10, 11},
                    {9, 10, 11, 12, 13, 14, 15},
                    {13, 14, 15, 16, 17, 18, 19},
                    {0, 1, 2, 3, 4, 5, 6},
                },
                new int[,] {
                    {1},
                    {5},
                    {9},
                    {13},
                },
                new int[,] {
                    {1, 2, 3, 4, 5, 6},
                    {5, 6, 7, 8, 9, 11},
                    {0, 2, 3, 4, 5, 6},
                },
                new int[,] {
                    {1, 0, 0, 0},
                    {5, -6, 0, 0},
                    {-1, 4, -5, 0},
                    {1, 4, 5, 6},
                },
                new int[,] {
                    {1, 2, 3, 4, 5, 6, 7},
                    {5, 6, 7, 8, -9, 10, 11},
                    {9, 10, -11, -12, -13, -14, -15},
                    {-13, -14, 15, 16, 17, 18, -19},
                },
                new int[,] {
                    {1, 0, 0},
                    {5, 11, -17},
                    {0, -2, -3},
                },
                new int[,] {
                    {-9, -10, -11, -14, -15, 6},
                },
                new int[,] {
                    {1, 2, 3, 4, -5, -6, -7},
                    {5, 11, -17, 11, -10, 6, 5},
                    {-9, -10, -11, -14, -15, -16, 1},
                    {-9, -10, -11, -14, -15, -6, -2},
                    {-9, -10, -11, -14, -15, 6, 4},
                },
                new int[,] {
                    {1, 2, 3, 4, -5, -6, -7},
                    {5, 11, -17, 11, -10, 6, 5},
                    {-9, -10, -11, -14, -15, -16, 1},
                    {-9, -10, -11, -14, 15, -6, -2},
                    {-9, -10, -11, -14, -15, 6, 4},
                    {5, 11, -17, 11, -10, 6, -5},
                    {1, 1, -2, 3, -4, 0, 0},
                    {0, -2, -3, -4, -5, 0, 5},
                },
                new int[,] {
                    {1, 0, 0, 0, 0},
                    {5, 11, -17, 11, 7},
                    {-9, -10, -11, -14, -15},
                    {-9, -10, -11, -14, -6},
                    {0, -2, -3, -4, -5},
                }
                };
            // Act
            for (int i = 0; i < answer.Length; i++)
            {
                _main.Task10(input[i]);
            }
            // Assert
            for (int i = 0; i < answer.Length; i++)
            {
                Assert.AreEqual(answer[i].GetLength(0), input[i].GetLength(0));
                for (int j = 0; j < answer[i].GetLength(0); j++)
                {
                    Assert.AreEqual(answer[i].GetLength(1), input[i].GetLength(1));
                    for (int k = 0; k < answer[i].GetLength(1); k++)
                    {
                        Assert.AreEqual(answer[i][j, k], input[i][j, k]);
                    }
                }
            }
        }
        [TestMethod]
        public void Test11()
        {
            // Arrange
            var input = _data.GetMatrixes();
            var answer = new int[][,] {
                new int[,] {
                    {1, 2, 3, 4, 5, 6, 7},
                    {5, 6, 7, 8, 9, 10, 11},
                    {9, 10, 11, 12, 13, 14, 15},
                    {13, 14, 15, 16, 17, 18, 19},
                    {0, 1, 2, 3, 4, 5, 6},
                },
                new int[,] {
                    {1},
                    {5},
                    {9},
                    {13},
                },
                new int[,] {
                    {1, 2, 3, 4, 5, 6},
                    {5, 6, 7, 8, 9, 11},
                    {0, 2, 3, 4, 5, 6},
                },
                new int[,] {
                    {1, 2, 4, 6},
                    {1, 4, 5, 6},
                    {5, -6, 7, 11},
                    {-1, 4, -5, 6},
                },
                new int[,] {
                    {1, 2, 3, 4, 5, 6, 7},
                    {5, 6, 7, 8, -9, 10, 11},
                    {-13, -14, 15, 16, 17, 18, -19},
                    {9, 10, -11, -12, -13, -14, -15},
                },
                new int[,] {
                    {1, 2, 3},
                    {5, 11, -17},
                    {0, -2, -3},
                },
                new int[,] {
                    {-9, -10, -11, -14, -15, 6},
                },
                new int[,] {
                    {5, 11, -17, 11, -10, 6, 5},
                    {1, 2, 3, 4, -5, -6, -7},
                    {-9, -10, -11, -14, -15, 6, 4},
                    {-9, -10, -11, -14, -15, -16, 1},
                    {-9, -10, -11, -14, -15, -6, -2},
                },
                new int[,] {
                    {5, 11, -17, 11, -10, 6, 5},
                    {1, 2, 3, 4, -5, -6, -7},
                    {5, 11, -17, 11, -10, 6, -5},
                    {1, 1, -2, 3, -4, 0, 0},
                    {-9, -10, -11, -14, -15, 6, 4},
                    {-9, -10, -11, -14, -15, -16, 1},
                    {-9, -10, -11, -14, 15, -6, -2},
                    {0, -2, -3, -4, -5, 0, 5},
                },
                new int[,] {
                    {1, 2, 3, 4, -5},
                    {5, 11, -17, 11, 7},
                    {-9, -10, -11, -14, -15},
                    {-9, -10, -11, -14, -6},
                    {0, -2, -3, -4, -5},
                }
                };
            // Act
            for (int i = 0; i < answer.Length; i++)
            {
                _main.Task11(input[i]);
            }
            // Assert
            for (int i = 0; i < answer.Length; i++)
            {
                Assert.AreEqual(answer[i].GetLength(0), input[i].GetLength(0));
                for (int j = 0; j < answer[i].GetLength(0); j++)
                {
                    Assert.AreEqual(answer[i].GetLength(1), input[i].GetLength(1));
                    for (int k = 0; k < answer[i].GetLength(1); k++)
                    {
                        Assert.AreEqual(answer[i][j, k], input[i][j, k]);
                    }
                }
            }
        }
        [TestMethod]
        public void Test12()
        {
            // Arrange
            var input = _data.GetArrayArrays();
            var answer = new int[][][] {
                new int[][] {
                new int[] { 2, 1, 3, 3, 5, 6, 3, 4 },
                new int[] { 5, 2, 8, 1, 9, 3, 7, 4, 6, 0 },
                new int[] { 5, 2, 8, 1, 9, 0, 7, 4, 6, 10 },
                new int[] { 5, 2, -8, 1, 9, 3, 7, 4, 6 },
                new int[] { 12, 1, 3, 3, 5, 6, 3, 4 },
                new int[] { 2, 1, 3, 4 },
                new int[] { 5 },
                new int[] { 0, 2, 4, 6, 8 },
                },
                new int[][] {
                new int[] { 2, 1, 3, 3, 5 },
                new int[] { 5, 2, 8, 1, 9 },
                new int[] { 5, 2, 8, 1, 9 },
                new int[] { 12, 1, 3, 0, 5 },
                new int[] { 2, 1, 3, 4, 5 },
                new int[] { 0, 2, 4, 6, 8 },
                },
                new int[][] {
                new int[] { -2, 1, 3, 3, 0, 5, -6, 3, 4 },
                },
                new int[][] {
                new int[] { 2 },
                new int[] { 5 },
                },
                new int[][] {
                new int[] { 2, 1, 3, 3, 5, 6, 3, 4 },
                new int[] { 5, 2, 8, 1, 9, 3, 7, 4, 6, 0 },
                new int[] { 5, 2, 8, 1, 9, 0, 7, 4, 6, 10 },
                new int[] { 5, 2, -8, 1, 9, 3, 7, 4, 6 },
                new int[] { 12, 1, 3, 3, 5, 6, 3, 4 },
                }
            };
            var test = new int[answer.Length][][];
            // Act
            for (int i = 0; i < answer.Length; i++)
            {
                test[i] = _main.Task12(input[i]);
            }
            // Assert
            for (int i = 0; i < answer.Length; i++)
            {
                Assert.AreEqual(answer[i].Length, test[i].Length);
                for (int j = 0; j < answer[i].Length; j++)
                {
                    Assert.AreEqual(answer[i][j].Length, test[i][j].Length);
                    for (int k = 0; k < answer[i][j].Length; k++)
                    {
                        Assert.AreEqual(answer[i][j][k], test[i][j][k]);
                    }
                }
            }
        }
    }
}