using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Runtime.InteropServices;
using DevExpress.Utils.Extensions;
using System.Configuration;
using Site_Yönetim_Sistemi.AfetYonetimi;
using DevExpress.Internal;
using System.Security.Cryptography;
namespace Site_Yönetim_Sistemi
{
    public partial class yoneticics : Form
    {
        int id;
        siteyonetimsistemiEntities st;
        kullanici kl;
        uye uy, bilgi;
        apartman ap;

        int aratmanId;
        public yoneticics(int _id)
        {

            InitializeComponent();
            try
            {
                id = _id;
                st = new siteyonetimsistemiEntities();
                kl = st.kullanicis.Where(x => x.id == id).FirstOrDefault();
                label1.Text = "Hoş geldiniz " + kl.ad + " " + kl.soyAd;
                //resimGetir();
                uy = st.uyes.Where(x => x.Id == id).FirstOrDefault();
                aratmanId = Convert.ToInt32(uy.apartmanId);
                panelPasifEt();
                var ank = st.ankets.Where(x => x.yoneticiId == id).Select(x => x.anketKonusu).ToList();
                // lblAnketler.DataSource = ank;
                guvenlik gv = st.guvenliks.Where(x => x.id == aratmanId).FirstOrDefault();
                lblGuvenlik.Text = gv.Ad + " " + gv.Soyad;
                //  lbAnketYapan.DataSource = ank;

            }
            catch { }

        }
        void SongelenMesajlar()
        {

        }

        private void yoneticics_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            var uyell = st.uyes.Where(x => x.Id == id);

            mesaj();


        }

        private void panelPasifEt()
        {
            pnlBilgiler.Visible = false;
            pnlDaireler.Visible = true;

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

            try

            {


                if (tabControl1.SelectedIndex == 0)
                {


                }
                else if (tabControl1.SelectedIndex == 1)
                {

                    //  tabControl1.SelectedIndex = 0;
                    panelPasifEt();
                    pnlBilgiler.Visible = true;
                    labelControl1.Text = kl.ad;
                    labelControl2.Text = kl.soyAd;

                    textEdit1.Text = kl.dogumTarihi.ToString();
                    if (kl.cinsiyet == "E")
                        labelControl4.Text = "Erkek";
                    else
                        labelControl4.Text = "Kadın";
                    labelControl5.Text = kl.mailAdresi;

                    textEdit2.Text = kl.telefon;
                    if (kl.mailAdresi == "e")
                        labelControl7.Text = "Evli";
                    else
                        labelControl7.Text = "Bekar";
                    uye uy = st.uyes.Where(x => id == x.Id).FirstOrDefault();
                    aratmanId = Convert.ToInt32(uy.apartmanId);

                    apartman aprt = st.apartmen.Where(x => x.id == aratmanId).FirstOrDefault();
                    labelControl8.Text = aprt.apartmanAdi;
                    labelControl9.Text = aprt.apartmanBlok;
                    labelControl10.Text = uy.kat.ToString();
                    labelControl11.Text = uy.daireNo.ToString();

                    kullanici kulY = st.kullanicis.Where(x => x.id == aprt.apartmanYoneticisi).FirstOrDefault();
                    labelControl12.Text = kulY.ad + " " + kulY.soyAd;
                    // labelControl13.Text = kulY.soyAd;


                }
                else if (tabControl1.SelectedIndex == 2)
                {
                    apartmanSakinleri();
                }
                else if (tabControl1.SelectedIndex == 3)
                {
                    mesaj();
                }
                else if (tabControl1.SelectedIndex == 4)
                {
                    duyuru();
                }
            }
            catch
            { }
        }

        private void duyuru()
        {
            List<duyurular> duy = st.duyurulars.Where(x => x.yoneticiId == id).ToList();
            listBox1.Items.Clear();

            for (int i = duy.Count - 1; i > -1; i--)
            {
                listBox1.Items.Add(duy[i].duyuruKonusu);
            }
        }
        private void listBoxBosalt()
        {
            lbDaireNo.Items.Clear();
            lbEvSahibi.Items.Clear();
            lbKat.Items.Clear();
            lbKisiSayisi.Items.Clear();

        }

        void apartmanSakinleri()
        {
            listBoxBosalt();
            panelPasifEt();
            pnlDaireler.Visible = true;

            apartman apr = st.apartmen.Where(x => x.id == aratmanId).FirstOrDefault();

            lblApartman.Text = apr.apartmanAdi;
            List<uye> uyeler = st.uyes.Where(x => x.apartmanId == aratmanId).OrderBy(x => x.daireNo).ToList();

            var uyeId = st.uyes.Where(x => x.apartmanId == aratmanId).Select(x => x.Id).ToList();
            List<kullanici> kullanicilar = st.kullanicis.ToList();

            List<daireSakini> daireSakin = st.daireSakinis.ToList();
            for (int i = 0; i < uyeler.Count; i++)
            {
                lbKat.Items.Add(uyeler[i].kat);
                lbDaireNo.Items.Add(uyeler[i].daireNo);
                var kad = kullanicilar.Where(x => x.id == uyeler[i].Id).Select(x => x.ad).FirstOrDefault();
                var ksoyad = kullanicilar.Where(x => x.id == uyeler[i].Id).Select(x => x.soyAd).FirstOrDefault();
                var kisiSay = daireSakin.Where(x => x.uyeId == uyeId[i]).ToList();
                lbKisiSayisi.Items.Add((Convert.ToInt32(kisiSay.Count) + 1));
                lbEvSahibi.Items.Add(kad + " " + ksoyad);
            }
        }
        private void btnEkle_Click(object sender, EventArgs e)
        {
            uyeekle uy = new uyeekle(id);
            uy.ShowDialog();
        }

        private void btnGuncelle_Click_1(object sender, EventArgs e)
        {

            try
            {
                int daireNo = Convert.ToInt32(lbDaireNo.SelectedItem);
                uye uyeler = st.uyes.Where(x => x.daireNo == daireNo && x.apartmanId == uy.apartmanId).FirstOrDefault();
                Guncelle dt = new Guncelle(uyeler);


                dt.ShowDialog();
            }
            catch
            {
                MessageBox.Show("Lütfen birini seçiniz");
            }
            apartmanSakinleri();
        }

        private void pnlBilgiler_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnAyarlar_Click(object sender, EventArgs e)
        {
            ayarlar ay = new ayarlar(id);
            ay.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult secenek = MessageBox.Show("Çıkış yapmak istediğinize emin misinz?", "Bilgilendirme Penceresi", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (secenek == DialogResult.Yes)
            {
                Application.Exit();
            }
            else if (secenek == DialogResult.No)
            {
                MessageBox.Show("İşlem iptal edildi..");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult secenek = MessageBox.Show("Çıkış yapmak istediğinize emin misinz?", "Bilgilendirme Penceresi", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (secenek == DialogResult.Yes)
            {
                this.Close();
            }
            else if (secenek == DialogResult.No)
            {
                MessageBox.Show("İşlem iptal edildi..");
            }

        }

        private void lbKat_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox lb = (ListBox)sender;
            lbKat.SelectedIndex = lb.SelectedIndex;
            lbDaireNo.SelectedIndex = lb.SelectedIndex;
            lbEvSahibi.SelectedIndex = lb.SelectedIndex;
            lbKisiSayisi.SelectedIndex = lb.SelectedIndex;






        }


        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                listBox2.Items.Clear();
                List<duyurular> duy = st.duyurulars.Where(x => x.yoneticiId == id).ToList();
                int top = duy.Count - 1;
                int index = listBox1.SelectedIndex;
                listBox2.Items.Add(duy[top - index].duyurAdi);
            }
            catch
            { }
        }
        int oncelik;
        private void lbmesajisim_SelectedIndexChanged(object sender, EventArgs e)
        {
            int sec = lbmesajisim.SelectedIndex;
            lbMesaj.Items.Clear();
            try
            {
                List<gelenMesaj> mesajlar = st.gelenMesajs.ToList();
                List<kullanici> kullanicilar = st.kullanicis.ToList();
                var uyeId = st.uyes.Where(x => x.apartmanId == aratmanId).Select(x => x.Id).ToList();
                int uyeid = uyeId[sec];
                string ben = kl.ad + " " + kl.soyAd + " :";
                var kad = kullanicilar.Where(x => x.id == uyeid).Select(x => x.ad).FirstOrDefault();
                var kSoyAd = kullanicilar.Where(x => x.id == uyeid).Select(x => x.soyAd).FirstOrDefault();

                List<gelenMesaj> mesajla = st.gelenMesajs.Where(x => ((x.mesajId == id) || (x.mesajId == uyeid)) && ((x.gelenId == id && x.gidenId == uyeid) || (x.gelenId == uyeid && x.gidenId == id))).OrderBy(x => x.oncelik).ToList();
                string mesaj = "";
                bool b = true;
                for (int i = 0; i < mesajlar.Count; i++)
                {

                    if (mesajla[i].mesajId == id)
                    {
                        mesaj = ben + mesajla[i].mesaj;

                    }
                    else
                    {
                        mesaj = kad + " " + kSoyAd + " : " + mesajla[i].mesaj;

                    }
                    lbMesaj.Items.Add(mesaj);
                    oncelik = Convert.ToInt32(mesajla[i].oncelik);
                }
            }
            catch (Exception ex)
            {

            }

        }
        private void btnGonder_Click(object sender, EventArgs e)
        {
            try
            {

                int index = lbmesajisim.SelectedIndex;
                var uyeId = st.uyes.Where(x => x.apartmanId == aratmanId).Select(x => x.Id).ToList();
                int uyeid = uyeId[index];

                oncelik++;
                gelenMesaj gm = new gelenMesaj();
                gm.mesaj = txtMesaj.Text;
                gm.gidenId = id;
                gm.gelenId = uyeid;
                gm.mesajId = id;
                gm.oncelik = oncelik;
                st.gelenMesajs.Add(gm);
                st.SaveChanges();
                txtMesaj.Clear();
                lbmesajisim_SelectedIndexChanged(sender, e);
            }
            catch
            { }

        }
        private void mesaj()
        {
            lbmesajisim.Items.Clear();
            List<uye> uyeler = st.uyes.Where(x => x.apartmanId == aratmanId).ToList();

            var uyeId = st.uyes.Where(x => x.apartmanId == aratmanId).Select(x => x.Id).ToList();

            List<kullanici> kullanicilar = st.kullanicis.ToList();

            for (int i = 0; i < uyeler.Count; i++)
            {
                lbKat.Items.Add(uyeler[i].kat);
                lbDaireNo.Items.Add(uyeler[i].daireNo);
                var kad = kullanicilar.Where(x => x.id == uyeId[i]).Select(x => x.ad).FirstOrDefault();

                lbmesajisim.Items.Add(kad);
            }
        }

        private void lbMesajAtan_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbAy_SelectedIndexChanged(object sender, EventArgs e)
        {

        }



        private void btnSakinEk_Click(object sender, EventArgs e)
        {
            uyeekle uy = new uyeekle(id);
            uy.ShowDialog();
        }

        private void btnGuncel_Click(object sender, EventArgs e)
        {

            string apa;
            int kat, daire, apartman, b;
            kat = Convert.ToInt32(lbKat.SelectedItem);
            daire = Convert.ToInt32(lbDaireNo.SelectedItem);
            apa = lblApartman.Text;
            var a = st.apartmen.Where(x => x.apartmanAdi == apa).FirstOrDefault();
            apartman = a.id;

            bilgi = st.uyes.Where(x => x.daireNo == daire && x.kat == kat && x.apartmanId == apartman).FirstOrDefault();
            b = bilgi.Id;
            try
            {
                int daireNo = Convert.ToInt32(lbDaireNo.SelectedItem);
                uye uyeler = st.uyes.Where(x => x.daireNo == daireNo && x.apartmanId == uy.apartmanId).FirstOrDefault();
                Guncelle dt = new Guncelle(uyeler);
                var deger = uyeler;

                dt.ShowDialog();


            }
            catch
            {
                MessageBox.Show("Lütfen birini seçiniz");
            }
            apartmanSakinleri();
        }

        private void btnSakinSil_Click(object sender, EventArgs e)
        {
            try
            {


                int daireNo = Convert.ToInt32(lbDaireNo.SelectedItem);
                uye uyeler = st.uyes.Where(x => x.daireNo == daireNo && x.apartmanId == aratmanId).FirstOrDefault();


                aidatlar ai = st.aidatlars.Where(x => x.id == uyeler.Id).FirstOrDefault();
                List<aidatAy> ad = st.aidatAys.Where(x => x.aidatId == uyeler.Id).ToList();
                kullanici kll = st.kullanicis.Where(x => x.id == uyeler.Id).FirstOrDefault();

                DialogResult secenek = MessageBox.Show(kll.ad + " isme sahip üyeyi silmek istiyor musunuz?", "Bilgilendirme Penceresi", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (secenek == DialogResult.Yes)
                {
                    List<daireSakini> dr = st.daireSakinis.Where(x => x.uyeId == uyeler.Id).ToList();
                    resimler rs = st.resimlers.Where(x => x.id == uyeler.Id).FirstOrDefault();
                    mesaj ms = st.mesajs.Where(x => x.id == uyeler.Id).FirstOrDefault();
                    List<gelenMesaj> gms = st.gelenMesajs.Where(x => x.mesajId == uyeler.Id).ToList();
                    for (int i = 0; i < gms.Count; i++)
                    {
                        st.gelenMesajs.Remove(gms[i]);
                    }
                    st.mesajs.Remove(ms);
                    for (int i = 0; i < dr.Count; i++)
                    {
                        st.daireSakinis.Remove(dr[i]);
                    }
                    List<aracbilgisi> ar = st.aracbilgisis.Where(x => x.uyeId == uyeler.Id).ToList();
                    for (int i = 0; i < ar.Count; i++)
                    {
                        st.aracbilgisis.Remove(ar[i]);
                    }
                    for (int i = 0; i < ad.Count; i++)
                    {
                        st.aidatAys.Remove(ad[i]);
                    }
                    if (ai != null)
                        st.aidatlars.Remove(ai);
                    if (uyeler != null)
                        st.uyes.Remove(uyeler);
                    if (kl != null)
                        st.kullanicis.Remove(kl);
                    st.SaveChanges();
                    MessageBox.Show("Üye Silindi!");
                    listBox1.SelectedIndex = 0;

                }
                else if (secenek == DialogResult.No)
                {
                    MessageBox.Show("Silme işlemi iptal edildi..");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            apartmanSakinleri();
        }
        public static string BilgileriFormatla(List<Bilgiler> bilgilerListesi)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var bilgiler in bilgilerListesi)
            {
                sb.AppendLine($"Apartman Adı: {bilgiler.ApartmanAdi}");
                sb.AppendLine($"Üye Sayısı: {bilgiler.UyeSayisi}");
                if (bilgiler.KatSayisi.HasValue)
                {
                    sb.AppendLine($"Kat Sayısı: {bilgiler.KatSayisi.Value}");
                }
                sb.AppendLine("Üye Bilgileri:");
                sb.AppendLine("--------------");

                foreach (var uye in bilgiler.UyeBilgileri)
                {
                    sb.AppendLine($"Ad Soyad: {uye.AdSoyad}");
                    sb.AppendLine($"Yaş: {uye.Yas}");
                    sb.AppendLine($"Cinsiyet: {uye.Cinsiyet}");
                    sb.AppendLine($"Medeni Durum: {uye.MedeniDurum}");
                    sb.AppendLine($"Telefon: {uye.Telefon}");
                    sb.AppendLine("--------------");
                }

                sb.AppendLine();
            }

            return sb.ToString();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //kullanıcı verilri al
            /*
             apartman Apartman ismi
                
                uyeler
                        üye bilgileri, ad soyad yaş cinsiyet
             
             */
            var afetSistemBilgisi = new List<Bilgiler>();
            var apartmanlar = st.apartmen.ToList();
            foreach (var apartman in apartmanlar)
            {
                var uyeBilgileri = apartman.uyes.Select(x => new UyeBilgileri
                {
                    AdSoyad = x.kullanici.ad + " " + x.kullanici.soyAd,
                    Yas = (DateTime.Now.Year - x.kullanici.dogumTarihi.Value.Year),
                    Cinsiyet = x.kullanici.cinsiyet,
                    MedeniDurum = x.kullanici.medeniDurum,
                    Telefon = x.kullanici.telefon,
                }).ToList();
                afetSistemBilgisi.Add(new Bilgiler
                {
                    ApartmanAdi = apartman.apartmanAdi + " - " + apartman.apartmanBlok + " Blok",
                    UyeSayisi = apartman.uyes.Count,
                    KatSayisi = apartman.katSayisi,
                    UyeBilgileri = uyeBilgileri
                });
            }
            var mailBody = BilgileriFormatla(afetSistemBilgisi);
            MailYardimcisi.Gonder("Afet Bilgi Sistemi", mailBody);
        }

        private void btnYayin_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtDuyuru.Text.Length > 0 && txtDuyuruKonu.Text.Length > 0)
                {
                    duyurular dr = new duyurular();
                    dr.duyuruKonusu = txtDuyuruKonu.Text;
                    dr.yoneticiId = id;
                    dr.duyurAdi = txtDuyuru.Text;
                    st.duyurulars.Add(dr);
                    st.SaveChanges();
                    MessageBox.Show("Duyuru başarıyla yayınlanmıştır!");
                }
                else
                    MessageBox.Show("Lütfen bilgileri doğru bir şekilde doldurunuz!");
            }
            catch
            { }

        }

        /* private void label18_Click(object sender, EventArgs e)
         {

         }*/

        /* private void panel8_Paint(object sender, PaintEventArgs e)
         {

         }*/
    }
}
