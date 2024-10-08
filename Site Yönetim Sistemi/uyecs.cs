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
namespace Site_Yönetim_Sistemi
{
    public partial class uyecs : Form
    {
        siteyonetimsistemiEntities st;
        int id;
        int aratmanId;
        uye uy;
        kullanici kul;
        apartman ap;
        gelenMesaj mesajj;
        kullanici kl;

        public uyecs(int _id)
        {
            InitializeComponent();
            st = new siteyonetimsistemiEntities();
            id = _id;
            uy = st.uyes.Where(x => x.Id == id).FirstOrDefault();
            kul = uy.kullanici;
            ap = uy.apartman;
            mesajj = st.gelenMesajs.Where(x => x.gelenId == id).FirstOrDefault();
            label1.Text = kul.ad + " " + kul.soyAd;
            kisiselBilgileriGetir();
            aratmanId = Convert.ToInt32(uy.apartmanId);
            aidatGetir();
            //     lblIsım = st.kullanicis.Where(x => x.id == kul)
            //  resimGetir();
        }
        private void kisiselBilgileriGetir()
        {
            lblIsım.Text = kul.ad;
            lblSoyisim.Text = kul.soyAd;
            lblDogumTarihi.Text = kul.dogumTarihi.ToString();
            lblCinsiyet.Text = kul.cinsiyet;
            lblMail.Text = kul.mailAdresi;
            lblMail.Text = kul.telefon;
            lblMedeniDurum.Text = kul.medeniDurum;

            List<gelenMesaj> mesajlar = st.gelenMesajs.ToList();
            List<kullanici> kullanicilar = st.kullanicis.ToList();
            string ben = kul.ad + " " + kul.soyAd + " :";
            if (mesajj != null)
            {
                var kad = kullanicilar.Where(x => x.id == mesajj.gidenId).Select(x => x.ad).FirstOrDefault();
                var kSoyAd = kullanicilar.Where(x => x.id == mesajj.gidenId).Select(x => x.soyAd).FirstOrDefault();
                string mesaj = "";

                for (int i = 0; i < mesajlar.Count; i++)
                {
                    if (mesajlar[i].gelenId == id)
                    {
                        mesaj = kad + " " + kSoyAd + " : " + mesajlar[i].mesaj;

                    }
                    listBox3.Items.Add(mesaj);
                }
            }


            lblApartmanAdi.Text = ap.apartmanAdi;
            lblBlok.Text = ap.apartmanBlok;
            lblKat.Text = ap.katSayisi.ToString();
            lblDaireno.Text = uy.daireNo.ToString();
            var deneme = ap.apartmanYoneticisi.Value;
            var isim = st.kullanicis.Find(deneme).ad + " " + st.kullanicis.Find(deneme).soyAd;
            var guv = ap.id;
            var guvenlik = st.guvenliks.Find(guv).Ad + " " + st.guvenliks.Find(guv).Soyad;

            lblYonetici.Text = isim.ToString();
            lblguv.Text = guvenlik.ToString();
            duyuru();
        }
        /* private void resimGetir()
         {
             try
             {
                 resimler rs = st.resimlers.Where(x => x.id == id).FirstOrDefault();
                 byte[] resim = rs.resim;
                 MemoryStream mstream = new MemoryStream();
                 mstream.Write(resim, 0, Convert.ToInt32(resim.Length));
                 Bitmap bmp = new Bitmap(mstream, false);
                 ptbResim.Image = bmp;
             }
             catch (Exception ex)
             {

             }
         }*/

        void aidatGetir()
        {
            dataGridView1.ReadOnly = true; // sadece okunabilir olması yani veri düzenleme kapalı
            dataGridView1.AllowUserToDeleteRows = false; // satırların silinmesi engelleniyor
            dataGridView1.ColumnCount = 2;
            dataGridView1.Columns[0].Name = "Ay";//Kolonların adı belirleniyor
            dataGridView1.Columns[1].Name = "Durum";
            List<aidatAy> aidatlar = st.aidatAys.Where(x => x.aidatId == id).ToList();
            Dictionary<int, string> aylar = new Dictionary<int, string>();
            aylar.Add(1, "Ocak");
            aylar.Add(2, "Şubat");
            aylar.Add(3, "Mart");
            aylar.Add(4, "Nisan");
            aylar.Add(5, "Mayıs");
            aylar.Add(6, "Haziran");
            aylar.Add(7, "Temmuz");
            aylar.Add(8, "Ağustos");
            aylar.Add(9, "Eylül");
            aylar.Add(10, "Ekim");
            aylar.Add(11, "Kasım");
            aylar.Add(12, "Aralık");
            int buAy = DateTime.Now.Month;
            if(!aidatlar.Any(x=> x.ay == buAy))
            {
                lblDurum.Text = "Ödenmedi";
                lblBorc.Text = "700";
            }
            else
            {
                lblDurum.Text = "Ödendi";
                lblBorc.Text = "Yok";
            }
            foreach (var ay in aylar)
            {
                string durum = "Ödenmedi";
                if (aidatlar.Any(x => x.ay == ay.Key))
                {
                    durum = "Ödendi";
                }
                dataGridView1.Rows.Add(ay.Value, durum);
            }
        }
        private void uyecs_Load(object sender, EventArgs e)
        {
            //listBox4.Items.Clear();
            try
            {
                // listBox4.Items.Clear();
                apartman apr = st.apartmen.Where(x => x.id == aratmanId).FirstOrDefault();
                int yoneticiId = Convert.ToInt32(apr.apartmanYoneticisi);
                List<anket> ank = st.ankets.Where(x => x.yoneticiId == yoneticiId).ToList();
                List<AnketiGorenler> ankg = st.AnketiGorenlers.Where(x => x.uyeId == id).ToList();
                bool b;
                for (int i = 0; i < ank.Count; i++)
                {
                    b = true;
                    for (int j = 0; j < ankg.Count; j++)
                    {
                        if (ank[i].id == ankg[j].anketId)
                            b = false;
                    }
                    //  if (b == true)
                    //  listBox4.Items.Add(ank[i].anketKonusu);
                }
                // if (listBox4.Items.Count == 0)
                // listBox4.Items.Add("Bütün anketler Çözülmüştür!");
            }
            catch (Exception ex)
            {
                // listBox4.Items.Add("Bütün anketler Çözülmüştür!");
            }

        }
        private void duyuru()
        {



            List<duyurular> duy = st.duyurulars.Where(x => x.yoneticiId == ap.apartmanYoneticisi).ToList();
            listBox1.Items.Clear();

            for (int i = duy.Count - 1; i > -1; i--)
            {
                listBox1.Items.Add(duy[i].duyuruKonusu);
            }
        }
        private void mesaj()
        {

        }
        private void listBoxBosalt()
        {


        }
        private void btnResimdegistir_Click(object sender, EventArgs e)
        {
            try
            {
                resimler resimlerr = st.resimlers.Where(x => x.id == id).FirstOrDefault();

                if (resimlerr == null)
                {
                    openFileDialog1.Title = "Resim aç";
                    if (openFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        Bitmap bmp = new Bitmap(Image.FromFile(openFileDialog1.FileName));
                        string isim = openFileDialog1.FileName;
                        FileStream fs = new FileStream(isim, FileMode.Open, FileAccess.Read);
                        BinaryReader br = new BinaryReader(fs);
                        byte[] resim = br.ReadBytes((int)fs.Length);
                        br.Close();
                        fs.Close();
                        resimler rs = new resimler();
                        rs.id = id;
                        rs.resim = resim;
                        rs.resimAd = "resim";
                        st.resimlers.Add(rs);
                        st.SaveChanges();
                        //ptbResim.Image = bmp;
                        MessageBox.Show("Resim başarıyla değiştirildi.");
                    }
                }
                else
                {
                    openFileDialog1.Title = "Resim aç";
                    if (openFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        Bitmap bmp = new Bitmap(Image.FromFile(openFileDialog1.FileName));
                        string isim = openFileDialog1.FileName;
                        FileStream fs = new FileStream(isim, FileMode.Open, FileAccess.Read);
                        BinaryReader br = new BinaryReader(fs);
                        byte[] resim = br.ReadBytes((int)fs.Length);
                        br.Close();
                        fs.Close();
                        resimler rs = st.resimlers.Where(x => x.id == id).FirstOrDefault();
                        rs.id = id;
                        rs.resimAd = "resim" + id.ToString();
                        rs.resim = resim;
                        st.SaveChanges();
                        //ptbResim.Image = bmp;
                        MessageBox.Show("Resim başarıyla değiştirildi.");
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
        void apartmanSakinleri()
        {

        }
        private void tabDuyuru_Click(object sender, EventArgs e)
        {



        }

        private void tabControl1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }







        private void lbEvSahibi_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
        int oncelik;
        private void lbmesajisim_SelectedIndexChanged_1(object sender, EventArgs e)
        {


        }

        private void cmbDaireSakini_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void btnGonder_Click_1(object sender, EventArgs e)
        {


        }

        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {
                listBox2.Items.Clear();
                List<duyurular> duy = st.duyurulars.Where(x => x.yoneticiId == ap.apartmanYoneticisi).ToList();
                int top = duy.Count - 1;
                int index = listBox1.SelectedIndex;
                listBox2.Items.Add(duy[top - index].duyurAdi);
            }
            catch
            { }
        }

        /*  private void listBox4_SelectedIndexChanged(object sender, EventArgs e)
          {
             try
              {
                //  string konu = listBox4.SelectedItem.ToString();
                //  anket ank = st.ankets.Where(x => x.anketKonusu == konu).FirstOrDefault();
                  int ad = ank.id;

                  AnketCevapla anc = new AnketCevapla(ad, id);
                  anc.ShowDialog();

              }
              catch
              { }
              uyecs_Load(sender, e);

          }*/

        private void cmbAy_SelectedIndexChanged(object sender, EventArgs e)
        {



        }

        private void cmbAys_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbAyd_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox6_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel17_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cmbYil_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            ayarlar ay = new ayarlar(id);
            ay.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
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

        private void button5_Click(object sender, EventArgs e)
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

        /*  private void panel2_Paint(object sender, PaintEventArgs e)
          {

          */

        /*  private void lblMedeniDurum_Click(object sender, EventArgs e)
          {

          }*/

        /*  private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
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

                  List<gelenMesaj> mesajla = st.gelenMesajs.Where(x => ((x.mesajId == id) || (x.mesajId == uyeid)) && ((x.gidenId == id && x.gelenId == uyeid) || (x.gidenId == uyeid && x.gelenId == id))).OrderBy(x => x.oncelik).ToList();
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
                      listBox1.Items.Add(mesaj);
                      oncelik = Convert.ToInt32(mesajla[i].oncelik);
                  }
              }
              catch (Exception ex)
              {

              }

          }
        */
        /*  private void lblIsım_Click(object sender, EventArgs e)
          {

          }*/
    }
}
