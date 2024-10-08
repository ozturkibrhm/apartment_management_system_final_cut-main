using System.Collections.Generic;

namespace Site_Yönetim_Sistemi.AfetYonetimi
{
    public class Bilgiler
    {
        public string ApartmanAdi { get; set; } // ApartmanAdi + Blok
        public int UyeSayisi { get; set; }
        public int? KatSayisi { get; set; }
        public  List<UyeBilgileri> UyeBilgileri {  get; set; }
    }

    public class UyeBilgileri
    {
        public string AdSoyad { get; set; }
        public int Yas { get; set; }
        public string Cinsiyet { get; set; }
        public string MedeniDurum { get; set; }
        public string Telefon { get; set; }
    }
}
