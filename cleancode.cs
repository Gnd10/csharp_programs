using System.Collections.Generic;

namespace cleancode
{
// 1. Definisi struktur objek
    public class Produk
    {
        public string Nama { get; set; } = string.Empty;
        public int Harga { get; set; }
        public string Kategori { get; set; } = string.Empty;
    }

    // 2. Class penyedia data mentah
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
                new Produk { Nama = "Montior 32 Inch", Harga = 850000, Kategori = "Elektronik"},
                new Produk { Nama = "Kursi Gaming", Harga = 1000000, Kategori = "Furnitur" }
            };
        }
    }

    public static class CookingHelper
    {
        public static async Task MasakNasiAsync()
        {
        Console.WriteLine("Mulai masak nasi...");
        await Task.Delay(5000); // 5 detik
        Console.WriteLine("✅ Nasi matang!");
        }
    
        public static async Task MasakAyamAsync()
        {
        Console.WriteLine("Mulai goreng ayam...");
        await Task.Delay(3000); // 3 detik
        Console.WriteLine("✅ Ayam goreng siap!");
        }
    
        public static async Task MasakSayurAsync()
        {
        Console.WriteLine("Mulai tumis sayur...");
        await Task.Delay(2000); // 2 detik
        Console.WriteLine("✅ Sayur tumis siap!");
        }


    }
   

}