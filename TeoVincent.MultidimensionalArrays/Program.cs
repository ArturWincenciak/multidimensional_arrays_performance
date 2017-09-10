using System;
using System.Diagnostics;

namespace TeoVincent.MultidimensionalArrays
{
    static class Program
    {
        const int X = 10000;
        const int Y = 10000;

        private static void Main(string[] args)
        {
            Console.WriteLine($"Size X: {X}; Size: Y: {Y}");
            
            MultiDimensionalArray(X, Y);
            JaggedArray(X, Y);
            UnsafeArray(X, Y);
            
            Console.ReadLine();
        }

        private static void MultiDimensionalArray(int x, int y)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            int[,] array = new int[x, y];
            stopwatch.Stop();
            Console.WriteLine($"\n\nCreating - Multidimensional array: {stopwatch.ElapsedTicks} count of ticks of processor.");

            stopwatch.Restart();
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    Function(array[i, j]);
                }
            }
            stopwatch.Stop();
            Console.WriteLine($"Access - Multidimensional array: {stopwatch.ElapsedTicks} count of ticks of processor.");
        }

        private static void JaggedArray(int x, int y)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            var array = new int[x][];
            for (int i = 0; i < array.Length; i++)
                array[i] = new int[y];
            stopwatch.Stop();
            Console.WriteLine($"\n\nCreating - Jagged array: {stopwatch.ElapsedTicks} count of ticks of processor.");

            stopwatch.Restart();
            for (var i = 0; i < x; i++)
            {
                for (var j = 0; j < y; j++)
                {
                    Function(array[i][j]);
                }
            }
            stopwatch.Stop();
            Console.WriteLine($"Access - Jagged array: {stopwatch.ElapsedTicks} count of ticks of processor.");
        }

        private static unsafe void UnsafeArray(int x, int y)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            var array = new int[x, y];
            fixed (int* pointer = array)
            {
                stopwatch.Stop();
                Console.WriteLine($"\n\nCreating - Unsafe array: {stopwatch.ElapsedTicks} count of ticks of processor.");
                
                stopwatch.Restart();
                for (var i = 0; i < y; i++)
                {
                    var baseIndex = i * x;
                    for (var j = 0; j < x; j++)
                    {
                        Function(pointer[baseIndex + j]);
                    }
                }
                stopwatch.Stop();
                Console.WriteLine($"Access - Unsafe array: {stopwatch.ElapsedTicks} count of ticks of processor.");
            }
        }

        private static void Function(int arg)
        {
        }
    }
}
