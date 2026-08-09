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
                new Produk { Nama = "Keyboard Mechanical", Harga = 700000, Kategori = "Elektronik" }
            };
        }
    }
}