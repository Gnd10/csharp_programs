using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyApp.Data;      // Untuk akses Produk, DataRepository
using MyApp.Helpers;   // Untuk akses CookingHelper, AsyncDemo

namespace MyApp
{
    class Program
    {
        public static async Task Main()
        {
            Console.WriteLine("=".PadRight(60, '='));
            Console.WriteLine("DEMO ASYNC BEST PRACTICE & LINQ");
            Console.WriteLine("=".PadRight(60, '='));
            
            // ========== DEMO 1: Async All the Way (BENAR) ==========
            Console.WriteLine("\n📌 DEMO 1: Async All the Way (Best Practice)");
            Console.WriteLine("-".PadRight(50, '-'));
            
            // PERBAIKAN: Panggil dari AsyncDemo, bukan CookingHelper
            string hasilBenar = await AsyncDemo.GetFormattedDataAsync(123);
            Console.WriteLine($"✅ Hasil (Benar): {hasilBenar}");
            
            // ========== DEMO 2: Async dengan Memasak (BENAR) ==========
            Console.WriteLine("\n📌 DEMO 2: Memasak dengan Async (Best Practice)");
            Console.WriteLine("-".PadRight(50, '-'));
            
            Console.WriteLine("🏠 Memulai memasak malam...\n");
            
            // MULAI MEMASAK - Semua async, tidak ada blocking
            var nasiTask = CookingHelper.MasakNasiAsync();
            var ayamTask = CookingHelper.MasakAyamAsync();
            var sayurTask = CookingHelper.MasakSayurAsync();
            
            // TUNGGU SEMUA SELESAI - Menggunakan await, bukan .Wait()
            await Task.WhenAll(nasiTask, ayamTask, sayurTask);
            
            Console.WriteLine("\n🍽️ Semua makanan siap! Makan malam siap disajikan!");
            
            // ========== DEMO 3: LINQ Query ==========
            Console.WriteLine("\n📌 DEMO 3: LINQ Query dengan Data Produk");
            Console.WriteLine("-".PadRight(50, '-'));
            DemoLINQ();
            
            // ========== DEMO 4: PERBANDINGAN (Baik vs Buruk) ==========
            Console.WriteLine("\n📌 DEMO 4: Perbandingan Async Best Practice");
            Console.WriteLine("-".PadRight(50, '-'));
            await DemoAsyncComparison();
            
            Console.WriteLine("\n" + "=".PadRight(60, '='));
            Console.WriteLine("✅ SEMUA DEMO SELESAI!");
            Console.WriteLine("=".PadRight(60, '='));
        }
        
        // ========== DEMO LINQ ==========
        public static void DemoLINQ()
        {
            // 1. Ambil data dari DataRepository
            List<Produk> semuaProduk = DataRepository.AmbilDaftarProduk();
            
            // 2. Jalankan LINQ (Cari barang Furnitur yang harganya di atas 100rb)
            var produkPilihan = semuaProduk
                .Where(p => p.Kategori == "Furnitur" && p.Harga > 100000)
                .OrderBy(p => p.Harga)
                .ToList();
            
            // 3. Tampilkan Output
            Console.WriteLine("\n=== DAFTAR PRODUK FURNITUR PILIHAN ===");
            foreach (var item in produkPilihan)
            {
                Console.WriteLine($"- {item.Nama} | Harga: Rp {item.Harga:N2}");
            }
            
            // 4. Aggregate Operators
            var nums = new List<int> { 3, 7, 12, 5, 18, 2 };
            Console.WriteLine("\n=== DEMO AGGREGATE OPERATORS ===");
            Console.WriteLine($"Count (>5): {nums.Count(n => n > 5)}");     // → 3
            Console.WriteLine($"Sum: {nums.Sum()}");                         // → 47
            Console.WriteLine($"Average: {nums.Average():F2}");              // → 7.83
            Console.WriteLine($"Any (>15): {nums.Any(n => n > 15)}");       // → true
            Console.WriteLine($"All (>0): {nums.All(n => n > 0)}");         // → true
        }
        
        // ========== DEMO PERBANDINGAN ASYNC ==========
        public static async Task DemoAsyncComparison()
        {
            Console.WriteLine("\n🔴 CONTOH SALAH (JANGAN DITIRU):");
            Console.WriteLine("   Mencampur blocking code dengan async");
            Console.WriteLine("   Bisa menyebabkan DEADLOCK!\n");
            
            // 🔴 CONTOH SALAH - Commented karena berbahaya
            // var resultSalah = AsyncDemo.GetDataWithBlocking();
            // Console.WriteLine($"Hasil (Salah): {resultSalah}");
            
            Console.WriteLine("✅ CONTOH BENAR:");
            Console.WriteLine("   Seluruh call stack menggunakan async/await\n");
            
            // PERBAIKAN: Panggil dari AsyncDemo, bukan CookingHelper
            var resultBenar = await AsyncDemo.GetDataInternalAsync(456);
            Console.WriteLine($"Hasil (Benar): {resultBenar}");
            
            Console.WriteLine("\n💡 PRINSIP: 'Async menular ke atas'");
            Console.WriteLine("   - Sekali async, tetap async sampai ke pemanggil paling atas");
            Console.WriteLine("   - Hindari .Result atau .Wait()");
            Console.WriteLine("   - Gunakan ConfigureAwait(false) di library");
        }
    }
}