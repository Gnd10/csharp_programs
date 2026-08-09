using System;
using System.Linq; // Wajib menyertakan namespace ini
using MyApp;
using cleancode;

class Program
{
    static void Main()
    {
        // var calc = new Calculator();
        // int result = calc.Add(8, 5);
        // float result2 = calc.Subtract(10, 15);
        // int result3 = calc.Multiplie(3, 15);
        // double result4 = calc.Divide(6.5, 10.25);
        // Console.WriteLine($"Hasil: {result}");
        // Console.WriteLine($"Hasil: {result2}");
        // Console.WriteLine($"Hasil: {result3}");
        // Console.WriteLine($"Hasil: {result4}");
         // 1. Ambil data dari file Produk.cs
            List<Produk> semuaProduk = DataRepository.AmbilDaftarProduk();

            // 2. Jalankan LINQ (Contoh: Cari barang Elektronik yang harganya di atas 500rb)
            var produkPilihan = semuaProduk
                .Where(p => p.Kategori == "Elektronik" && p.Harga > 500000)
                .OrderBy(p => p.Harga)
                .ToList();

            // 3. Menampilkan Output ke Layar
            Console.WriteLine("=== DAFTAR PRODUK ELEKTRONIK PILIHAN ===");
            foreach (var item in produkPilihan)
            {
                Console.WriteLine($"- {item.Nama} | Harga: Rp {item.Harga:N0}");
            }

    }
}