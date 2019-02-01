using System;
using System.Collections.Generic;

namespace FuncPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Fibonacci 40: {fibonacci(40)}");
        }

        // memoization, meng-cache hasil kalkulasi fungsi
        static Dictionary<int, int> cache = new Dictionary<int, int>();
        static int fibonacci(int n)
        {
            int hasil = cache.GetValueOrDefault(n, 0);
            if (hasil != 0) return hasil;

            if (n == 0 || n == 1)
            {
                hasil = 1;
            }
            else
            {
                hasil = fibonacci(n-1) + fibonacci(n-2);
            }
            cache[n] = hasil;
            return hasil;
        }
    }
}
