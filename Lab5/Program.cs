namespace Lab5
{
    public class Program
    {
        public static int[,] Mt(int n, int m, int max_val = 14)
        {
            Random rnd = new Random();
            int[,] a = new int[n, m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    a[i, j] = rnd.Next(-5, max_val);
                }
            }
            return a;
        }
        public static int[] List(int n, int max_val = 14)
        {
            Random rnd = new Random();
            int[] a = new int[n];
            for (int i = 0; i < n; i++)
            {
                a[i] = rnd.Next(-5, max_val);
            }
            return a;
        }
        public static int[][] Jag(int n, int m, int max_val = 14)
        {
            Random rnd = new Random();
            int[][] a = new int[n][];
            for (int i = 0; i < n; i++)
            {
                int size = rnd.Next(0, m + 1);
                a[i] = new int[size];
                for (int j = 0; j < size; j++)
                {
                    a[i][j] = rnd.Next(-5, max_val);
                }
            }
            for (int iter = 0; iter < 2; iter++)
            {
                if (rnd.Next(0, 2) == 0)
                {
                    int i_r_null = rnd.Next(0, n);
                    a[i_r_null] = null;
                }
            }
            int i_r_size0 = rnd.Next(0, n);
            a[i_r_size0] = new int[0];

            return a;
        }
        public static void Out(int[,] a)
        {
            int n = a.GetLength(0), m = a.GetLength(1);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write($"{a[i, j], 4}");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        public static void Out(int[][] a)
        {
            foreach (int[] v in a)
            {
                if (v != null)
                {
                    if (v.Length > 0)
                    {
                        foreach (int x in v)
                        {
                            Console.Write($"{x,4}");
                        }
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine("'empty'");
                    }
                }
                else
                {
                    Console.WriteLine("'null'");
                }
            }
            Console.WriteLine();
        }
        public static void Out(int[] a)
        {
            int n = a.GetLength(0);
            for (int j = 0; j < n; j++)
            {
                Console.Write($"{a[j],4}");
            }
            Console.WriteLine('\n');
        }
        public static void Main()
        {
            Purple purple = new Purple();

            Console.WriteLine("Task 1\n");
            var a = Mt(4, 5);
            Out(a);
            var ans1 = purple.Task1(a);
            Out(ans1);

            Console.WriteLine("Task 2\n");
            a = Mt(6, 8);
            Out(a);
            purple.Task2(a);
            Out(a);

            Console.WriteLine("Task 3\n");
            var b = Mt(7, 8);
            Out(b);
            var ans3 = purple.Task3(b);
            Out(ans3);

            Console.WriteLine("Task 4\n");
            var c = Mt(9, 10);
            Out(c);
            purple.Task4(c);
            Out(c);

            Console.WriteLine("Task 5\n");
            var d = Mt(4, 6);
            Out(d);
            purple.Task5(d, 2);
            Out(d);
            Console.WriteLine($"k = {8}:\n");
            purple.Task5(d, 8);
            Out(d);

            Console.WriteLine("Task 6\n");
            var e = Mt(7, 8, 6);
            Out(e);

            var l1 = List(8, 22);
            Out(l1);
            purple.Task6(e, l1);
            Out(e);

            l1 = List(9, 100);
            Out(l1);
            purple.Task6(e, l1);
            Console.WriteLine("Нет изменений?\n");
            Out(e);

            Console.WriteLine("Task 7\n");
            var f = Mt(6, 7);
            Out(f);
            purple.Task7(f);
            Out(f);

            Console.WriteLine("Task 8\n");
            var g = Mt(6, 6);
            Out(g);
            var ans8 = purple.Task8(g);
            Out(ans8);

            Console.WriteLine("Task 9\n");
            var h = Mt(9, 9, 24);
            Out(h);
            purple.Task9(h, 3);
            Out(h);

            Console.WriteLine("Task 10\n");
            var kA = Mt(2, 4);
            Out(kA);
            var kB = Mt(4, 3);
            Out(kB);
            var ans10 = purple.Task10(kA, kB);
            Out(ans10);
            kB = Mt(3, 3);
            ans10 = purple.Task10(kA, kB);
            if (ans10 == null)
            {
                Console.WriteLine("Не найдено\n");
            }

            Console.WriteLine("Task 11\n");
            var w11 = Mt(7, 8, 7);
            Out(w11);
            var ans = purple.Task11(w11);
            Out(ans);

            Random rnd = new Random();
            Console.WriteLine("Task 12\n");
            var jag12 = Jag(rnd.Next(2, 12), rnd.Next(2, 12), 21);
            Out(jag12);
            var q = purple.Task12(jag12);
            Out(q);
        }
    }
}
