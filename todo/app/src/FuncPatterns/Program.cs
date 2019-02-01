using System;
using System.Collections.Generic;

namespace FuncPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Fibonacci 40: {fibonacci(40)}");
            Console.WriteLine($"Fibonacci 40: {fibonacci1(40)}");
        }

        // memoization, meng-cache hasil kalkulasi fungsi
        static Dictionary<int, int> cache = new Dictionary<int, int>();
        static int fibonacci(int n)
        {
            // nilai 0 kalau jawaban yang dicari belum ada di-cache
            // (karena fibonacci nilainya >= 1)
            int hasil = cache.GetValueOrDefault(n, 0);
            if (hasil != 0) return hasil;

            if (n == 0 || n == 1)
            {
                hasil = 1;
            } else {
                hasil = fibonacci(n-1) + fibonacci(n-2);
            }
            cache[n] = hasil;
            return hasil;
        }

        // memoization dengan menggunakan Maybe untuk sinyal jawaban belum ada
        // di cache
        static Dictionary<int, Maybe<int>> cache1 = new Dictionary<int, Maybe<int>>();
        static int fibonacci1(int n)
        {
            // Hasil bisa dapat jawaban berupa Just<int> atau tidak ada berupa Nothing<int>
            Maybe<int> hasil = cache1.GetValueOrDefault(n, new Nothing<int>());
            // check  dan subcast Maybe<int> menjadi Just<int>
            if (hasil is Just<int>) return ((Just<int>)hasil).Value;
            if (n == 0 || n == 1)
            {
                hasil = new Just<int>(1);
            } else {
                hasil = new Just<int>(fibonacci1(n-1) + fibonacci(n-2));
            }
            cache1[n] = hasil;
            return ((Just<int>)hasil).Value;
        }
    }
}
