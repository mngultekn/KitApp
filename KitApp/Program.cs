using System;
using System.Collections.Generic;

namespace KutuphaneYonetimSistemi
{
    class Kitap
    {
        public string Ad { get; set; }
        public string Yazar { get; set; }
        public string ISBN { get; set; }
        public int YayınYılı { get; set; }

        public override string ToString()
        {
            return $"Kitap Adı: {Ad}, Yazar: {Yazar}, ISBN: {ISBN}, Yayın Yılı: {YayınYılı}";
        }
    }

    // Kütüphane sınıfı
    class Kutuphane
    {
        private List<Kitap> kitaplar;

        public Kutuphane()
        {
            kitaplar = new List<Kitap>();
        }

        public void KitapEkle()
        {
            Kitap yeniKitap = new Kitap();

            Console.Write("Kitap Adı: ");
            yeniKitap.Ad = Console.ReadLine();

            Console.Write("Yazar Adı: ");
            yeniKitap.Yazar = Console.ReadLine();

            Console.Write("ISBN: ");
            yeniKitap.ISBN = Console.ReadLine();

            Console.Write("Yayın Yılı: ");
            yeniKitap.YayınYılı = int.Parse(Console.ReadLine());

            kitaplar.Add(yeniKitap);
            Console.WriteLine("Kitap başarıyla eklendi!\n");
        }

        public void KitaplariListele()
        {
            if (kitaplar.Count == 0)
            {
                Console.WriteLine("Kütüphanede kitap bulunmamaktadır.\n");
                return;
            }

            Console.WriteLine("--- Kayıtlı Kitaplar ---");
            foreach (var kitap in kitaplar)
            {
                Console.WriteLine(kitap);
            }
            Console.WriteLine();
        }

        public void KitapAra()
        {
            Console.Write("Aramak istediğiniz kitabın ISBN'ini girin: ");
            string isbn = Console.ReadLine();

            var kitap = kitaplar.Find(k => k.ISBN == isbn);

            if (kitap != null)
            {
                Console.WriteLine("Kitap bulundu: " + kitap + "\n");
            }
            else
            {
                Console.WriteLine("Kitap bulunamadı!\n");
            }
        }

        public void KitapSil()
        {
            Console.Write("Silmek istediğiniz kitabın ISBN'ini girin: ");
            string isbn = Console.ReadLine();

            var kitap = kitaplar.Find(k => k.ISBN == isbn);

            if (kitap != null)
            {
                kitaplar.Remove(kitap);
                Console.WriteLine("Kitap başarıyla silindi!\n");
            }
            else
            {
                Console.WriteLine("Kitap bulunamadı!\n");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Kutuphane kutuphane = new Kutuphane();
            bool devam = true;

            while (devam)
            {
                Console.WriteLine("--- Kütüphane Yönetim Sistemi ---");
                Console.WriteLine("1. Kitap Ekle");
                Console.WriteLine("2. Kitapları Listele");
                Console.WriteLine("3. Kitap Ara");
                Console.WriteLine("4. Kitap Sil");
                Console.WriteLine("5. Çıkış");
                Console.Write("Seçiminizi yapın: ");
                string secim = Console.ReadLine();

                switch (secim)
                {
                    case "1":
                        kutuphane.KitapEkle();
                        break;
                    case "2":
                        kutuphane.KitaplariListele();
                        break;
                    case "3":
                        kutuphane.KitapAra();
                        break;
                    case "4":
                        kutuphane.KitapSil();
                        break;
                    case "5":
                        devam = false;
                        Console.WriteLine("Çıkış yapılıyor...");
                        break;
                    default:
                        Console.WriteLine("Geçersiz seçim, lütfen tekrar deneyin.");
                        break;
                }
            }
        }
    }
}
