using System;
using System.Linq; // Wajib menyertakan namespace ini
using MyApp;
using cleancode;
using System.Threading.Tasks;

class Program
{
    public static async Task Main()
    {
        Console.WriteLine("🏠 Memulai memasak malam...\n");
        
        // MULAI MEMASAK
        var nasiTask = MasakNasiAsync();
        var ayamTask = MasakAyamAsync();
        var sayurTask = MasakSayurAsync();
        
        // TUNGGU SEMUA SELESAI
        await Task.WhenAll(nasiTask, ayamTask, sayurTask);
        
        Console.WriteLine("\n🍽️ Semua makanan siap! Makan malam siap disajikan!");
    }
    
    public static async Task MasakNasiAsync()
    {
        Console.WriteLine("🍚 Mulai masak nasi...");
        await Task.Delay(5000); // 5 detik
        Console.WriteLine("✅ Nasi matang!");
    }
    
    public static async Task MasakAyamAsync()
    {
        Console.WriteLine("🍗 Mulai goreng ayam...");
        await Task.Delay(3000); // 3 detik
        Console.WriteLine("✅ Ayam goreng siap!");
    }
    
    public static async Task MasakSayurAsync()
    {
        Console.WriteLine("🥬 Mulai tumis sayur...");
        await Task.Delay(2000); // 2 detik
        Console.WriteLine("✅ Sayur tumis siap!");
    }
    // public static void MainProgram()
    // {
    //     // var calc = new Calculator();
    //     // int result = calc.Add(8, 5);
    //     // float result2 = calc.Subtract(10, 15);
    //     // int result3 = calc.Multiplie(3, 15);
    //     // double result4 = calc.Divide(6.5, 10.25);
    //     // Console.WriteLine($"Hasil: {result}");
    //     // Console.WriteLine($"Hasil: {result2}");
    //     // Console.WriteLine($"Hasil: {result3}");
    //     // Console.WriteLine($"Hasil: {result4}");
    //     //  // 1. Ambil data dari file Produk.cs
    //     //     List<Produk> semuaProduk = DataRepository.AmbilDaftarProduk();

    //     //     // 2. Jalankan LINQ (Contoh: Cari barang Furniture yang harganya di atas 100rb)
    //     //     var produkPilihan = semuaProduk
    //     //         .Where(p => p.Kategori == "Furnitur" && p.Harga > 100000)
    //     //         .OrderBy(p => p.Harga)
    //     //         .ToList();

    //     //     // 3. Menampilkan Output ke Layar
    //     //     Console.WriteLine("=== DAFTAR PRODUK ELEKTRONIK PILIHAN ===");
    //     //     foreach (var item in produkPilihan)
    //     //     {
    //     //         Console.WriteLine($"- {item.Nama} | Harga: Rp {item.Harga:N2}");
    //     //     }

    //     //     // Aggregate Operators
    //         var nums = new List<int> { 3, 7, 12, 5, 18, 2 };
    //             Console.WriteLine(nums.Count(n => n > 5)); // → 3
    //             Console.WriteLine(nums.Sum()); // → 47
    //             Console.WriteLine(nums.Average()); // → 7.83
    //             Console.WriteLine(nums.Any(n => n > 15)); // → true
    //             Console.WriteLine(nums.All(n => n > 0)); // → true
    

    // }



}