using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyApp.Data
{
    // ============================================
    // 1. DEFINISI PRODUK
    // ============================================
    public class Produk
    {
        public string Nama { get; set; } = string.Empty;
        public int Harga { get; set; }
        public string Kategori { get; set; } = string.Empty;
    }

    // ============================================
    // 2. DATA REPOSITORY
    // ============================================
    public static class DataRepository
    {
        public static List<Produk> AmbilDaftarProduk()
        {
            return new List<Produk>
            {
                new Produk { Nama = "Laptop Asus", Harga = 12000000, Kategori = "Elektronik" },
                new Produk { Nama = "Mouse Wireless", Harga = 250000, Kategori = "Elektronik" },
                new Produk { Nama = "Meja Kerja", Harga = 850000, Kategori = "Furnitur" },
                new Produk { Nama = "Keyboard Mechanical", Harga = 700000, Kategori = "Elektronik" },
                new Produk { Nama = "Monitor 32 Inch", Harga = 850000, Kategori = "Elektronik"},
                new Produk { Nama = "Kursi Gaming", Harga = 1000000, Kategori = "Furnitur" }
            };
        }
    }
}

namespace MyApp.Helpers
{
    // ============================================
    // 3. COOKING HELPER (Async)
    // ============================================
    public static class CookingHelper
    {
        //  Memasak Nasi - 5 detik
        public static async Task MasakNasiAsync()
        {
            Console.WriteLine(" Mulai masak nasi...");
            await Task.Delay(5000); // 5 detik
            Console.WriteLine(" Nasi matang!");
        }
        
        //  Memasak Ayam - 3 detik
        public static async Task MasakAyamAsync()
        {
            Console.WriteLine("🍗 Mulai goreng ayam...");
            await Task.Delay(3000); // 3 detik
            Console.WriteLine(" Ayam goreng siap!");
        }
        
        //  Memasak Sayur - 2 detik
        public static async Task MasakSayurAsync()
        {
            Console.WriteLine(" Mulai tumis sayur...");
            await Task.Delay(2000); // 2 detik
            Console.WriteLine(" Sayur tumis siap!");
        }
    }

    // ============================================
    // 4. ASYNC BEST PRACTICE DEMO
    // ============================================
    public static class AsyncDemo
    {
        //  BENAR: Async all the way
        public static async Task<string> GetDataInternalAsync(int id)
        {
            // Untuk library, ConfigureAwait(false) menghindari 
            // peningkatan SynchronizationContext
            await Task.Delay(500).ConfigureAwait(false);
            return $"Data untuk id: {id}";
        }
        
        // ✅ BENAR: Tetap async sampai ke atas
        public static async Task<string> GetFormattedDataAsync(int id)
        {
            var rawData = await GetDataInternalAsync(id);
            return $"Formatted: {rawData}";
        }
        
        //  SALAH: Mencampur blocking dengan async (BERBAHAYA!)
        // Method ini bisa menyebabkan DEADLOCK!
        public static string GetDataWithBlocking()
        {
            // .Result memblokir thread yang sedang menunggu task.
            // Task mungkin butuh thread itu untuk selesai,
            // menyebabkan deadlock!
            return GetDataInternalAsync(999).Result;
        }
        
        // ❌ SALAH: Juga berbahaya menggunakan .Wait()
        public static void GetDataWithWait()
        {
            // .Wait() juga memblokir thread dan bisa deadlock
            GetDataInternalAsync(888).Wait();
        }
    }
}

namespace MyApp.Controllers
{
    // ============================================
    // 5. CONTROLLER SIMULASI (Entry Point)
    // ============================================
    public static class ControllerSimulator
    {
        //  BENAR: Controller juga async
        public static async Task<string> GetUserEndpoint(int id)
        {
            var data = await Helpers.AsyncDemo.GetFormattedDataAsync(id);
            return $"Response: {data}";
        }
    }
}