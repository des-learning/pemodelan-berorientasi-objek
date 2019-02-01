using System;

namespace FuncPatterns
{
    // Maybe adalah tipe data abstract yang merepresentasikan
    // dua jenis nilai, Just untuk nilai yang ada, dan Nothing untuk nilai
    // yang tidak ada. Digunakan untuk menyimpan hasil operasi
    // yang mungkin gagal atau tidak menghasilkan apa-apa
    // Maybe<T> menggunakan Generics untuk type T supaya dapat
    // digunakan bersama tipe data lain, Maybe<int> -> untuk tipe int
    public abstract class Maybe<T>
    {
    }

    // Untuk menampung data yang ada
    public class Just<T>: Maybe<T>
    {
        public T Value {get; private set;}

        public Just(T Value)
        {
            this.Value = Value;
        }
    }

    // Untuk menampung data yang tidak ada
    public class Nothing<T>: Maybe<T>
    {
    }
}