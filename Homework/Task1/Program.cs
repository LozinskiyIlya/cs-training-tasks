using System;
using System.Diagnostics;
using System.Linq;

namespace Task1
{
    public class Program
    {
        private const int DEFAULT_MATRIX_DIM = 1000;
        private static readonly Stopwatch sw = new Stopwatch();


        private static int[] ParseArgs(string[] args)
        {
            // n*l, l*m -> [n,l,m]
            var dimensions = new int[3];
            switch (args.Length)
            {
                case 1:
                    // 2 square matrices, where n = l = m = args[0]
                    dimensions[0] = dimensions[1] = dimensions[2] = int.Parse(args[0]);
                    break;
                case 2:
                    // n = m = args[0], l = args[1];
                    dimensions[0] = dimensions[2] = int.Parse(args[0]);
                    dimensions[1] = int.Parse(args[1]);
                    break;

                case 3:
                    // n = args[0], l = args[1], m = [args[2]
                    dimensions[0] = int.Parse(args[0]);
                    dimensions[1] = int.Parse(args[1]);
                    dimensions[2] = int.Parse(args[2]);
                    break;
                default:
                    // emtpy or wrong arguments count, 2 square matrices, where n = l = m = 1000
                    dimensions[0] = dimensions[1] = dimensions[2] = DEFAULT_MATRIX_DIM;
                    break;
            }

            return dimensions;
        }

        private static double[,] GenerateMatrix(int n, int m)
        {
            var random = new Random(Guid.NewGuid().GetHashCode());
            var matrix = new double[n, m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    matrix[i, j] = random.NextDouble();
                }
            }
            return matrix;
        }

        private static double[][] GenerateMatrixArrayOfArrays(int n, int m)
        {
            var random = new Random(Guid.NewGuid().GetHashCode());
            var matrix = new double[n][];
            for (int i = 0; i < n; i++)
            {
                matrix[i] = new double[m];
                for (int j = 0; j < m; j++)
                {
                    matrix[i][j] = random.NextDouble();
                }
            }
            return matrix;
        }


        private static double[,] MultiplyMatrices(double[,] a, double[,] b)
        {
            var height = a.GetLength(0);
            var width = b.GetLength(1);
            var c = new double[height, width];
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    for (int r = 0; r < a.GetLength(1); r++)
                    {
                        c[i, j] += a[i, r] * b[r, j];
                    }
                }
            }
            return c;
        }

        private static double[][] MultiplyMatricesArrayOfArrays(double[][] a, double[][] b)
        {
            var height = a.GetLength(0);
            var width = b[0].GetLength(0);
            var c = new double[height][];
            for (int i = 0; i < height; i++)
            {
                c[i] = new double[width];
                for (int j = 0; j < width; j++)
                {
                    for (int r = 0; r < a[0].GetLength(0); r++)
                    {
                        c[i][j] += a[i][r] * b[r][j];
                    }
                }
            }
            return c;
        }

        public static void Mains(string[] args)
        {
            var dim = ParseArgs(args);
            Console.WriteLine("Multiplying matrices...");
            Console.WriteLine($"Dimensions: {dim[0]} * {dim[1]}, {dim[1]} * {dim[2]}");
            var opCnt = Math.Pow(dim.Max(), 3) * 2;
            var a = GenerateMatrix(dim[0], dim[1]);
            var b = GenerateMatrix(dim[1], dim[2]);
            Console.WriteLine("Rectangular Array:");
            sw.Start();
            MultiplyMatrices(a, b);
            sw.Stop();
            Console.WriteLine("Finished, elapsed time, ms: " + sw.ElapsedMilliseconds);
            Console.WriteLine("Perfomance, GFlops: " + opCnt * 1000 / sw.ElapsedMilliseconds);

            Console.WriteLine("Array of Arrays:");
            var a1 = GenerateMatrixArrayOfArrays(dim[0], dim[1]);
            var b1 = GenerateMatrixArrayOfArrays(dim[1], dim[2]);
            sw.Restart();
            MultiplyMatricesArrayOfArrays(a1, b1);
            sw.Stop();
            Console.WriteLine("Finished, elapsed time, ms: " + sw.ElapsedMilliseconds);
            Console.WriteLine("Perfomance, GFlops: " + opCnt * 1000 / sw.ElapsedMilliseconds);


            //comment for tests
            //Console.WriteLine("\nPress any key to close");
            //Console.ReadKey();
        }
    }
}