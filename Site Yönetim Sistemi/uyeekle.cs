using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Site_Yönetim_Sistemi
{
    public partial class uyeekle : Form
    {
        siteyonetimsistemiEntities st;
        int id;
        kullanici kl;
        uye uy;
        apartman apr;
        List<apartman> apartmanlar;
        bool adminMi = false;
        public uyeekle(int _id)
        {
            InitializeComponent();
            id = _id;
            st = new siteyonetimsistemiEntities();
            uy = st.uyes.Where(x => x.Id == id).FirstOrDefault();
            if (uy.kullanici.tipAdi == "Admin")
                adminMi = true;
            if(adminMi)
            {
                adminIslemleri();
            }

            kl = st.kullanicis.Where(x => x.id == id).FirstOrDefault();
            label1.Text = "Hoş geldiniz " + kl.ad + " " + kl.soyAd;
            cmbDoldur();
            daire();
        }
        private void adminIslemleri()
        {
            lbApartmanSec.Visible = true;
            cmbApartman.Visible = true;
            List<apartman> apartmanlar = st.apartmen.ToList();
            cmbApartman.DisplayMember = "apartmanAdi";
            cmbApartman.ValueMember = "id";
            cmbApartman.DataSource = apartmanlar;
        }
        private void cmbDoldur()
        {
            cmbCinsiyet.Items.Add("Kadın");
            cmbCinsiyet.Items.Add("Erkek");
            cmbMedeni.Items.Add("Evli");
            cmbMedeni.Items.Add("Bekar");
            for (int i = 1; i < 32; i++)
            {
                cmbGun.Items.Add(i.ToString());
                
            }
            for (int i = 1940; i <2018; i++)
            {
                cmbYil.Items.Add(i.ToString());
            }
            string[] aylar = { "Ocak", "Şubat", "Mart", "Nisan", "Mayıs", "Haziran", "Temmuz", "Ağustos", "Eylül", "Ekim", "Kasım", "Aralık" };
            cmbAy.DataSource = aylar;

        }
        private void daire(int? apartmanId = null)
        {
            cmbKat.Items.Clear();
            if (apartmanId == null)
            {
                apartmanId = uy.apartmanId;
            }
           
          apr = st.apartmen.Where(x => x.id == apartmanId).FirstOrDefault();
            
            for (int i = 0; i < apr.katSayisi; i++)
                cmbKat.Items.Add((i + 1).ToString());
        }
        private void uyeekle_Load(object sender, EventArgs e)
        {
            txtKadi.Text = "";
            txtSifre.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {

          

        }

        private void btnEkle_Click_1(object sender, EventArgs e)
        {
            int aprId = Convert.ToInt32(uy.apartmanId.ToString());
            try
            {
                kullanici kYeni = new kullanici();

                if (cmbCinsiyet.SelectedIndex == 0)
                {
                    char c = 'k';
                }
                string tel = textedittelef.Text;
                string isim = txtAd.Text;
                string soyisim = txtSoyad.Text;
                string mail = txtMail.Text;
                int gun = Convert.ToInt32(cmbGun.SelectedItem.ToString());
                int yil = Convert.ToInt32(cmbYil.SelectedItem.ToString());
                int ay = (cmbAy.SelectedIndex + 1);
                string tarih = gun.ToString() +"-"+ ay.ToString()+"-" + yil.ToString();
                
                int kat = Convert.ToInt32(cmbKat.SelectedItem.ToString());
                int daire = Convert.ToInt32(cmbDaireNo.SelectedItem.ToString());
                for (int i = 0; i < textedittelef.Text.Count(); i++)
                {
                    int a = Convert.ToInt32(tel[i]);
                }
                kYeni.ad = isim;
                kYeni.soyAd = soyisim;
                kYeni.telefon = tel;
                kYeni.kAdi =txtKadi.Text;
                if (cmbCinsiyet.SelectedIndex == 0)
                    kYeni.cinsiyet = "k";
                else
                    kYeni.cinsiyet = "e";
                if (cmbMedeni.SelectedIndex == 0)
                    kYeni.medeniDurum = "e";
                else
                    kYeni.medeniDurum = "b";
                DateTime dt = Convert.ToDateTime(tarih);
                kYeni.dogumTarihi = dt;
                kYeni.tipAdi = "Üye";
                kYeni.sifre = txtSifre.Text;
                kYeni.mailAdresi = txtMail.Text;


                st.kullanicis.Add(kYeni);
                uye uYeni = new uye();
                int? apartmanId = uy.apartmanId;
                if(adminMi)
                {
                    try
                    {
                        apartmanId = Convert.ToInt32(cmbApartman.SelectedItem);
                    }catch(Exception ex)
                    {
                        MessageBox.Show("Lütfen Apartman Seçiniz");
                    }

                }
                uYeni.apartmanId = apartmanId;
                uYeni.kat = Convert.ToInt32(Convert.ToInt32(cmbKat.SelectedItem));
                uYeni.daireNo = Convert.ToInt32(Convert.ToInt32(cmbDaireNo.SelectedItem));
                resimler rs = new resimler();
                 st.uyes.Add(uYeni);
                if (isim != "" && soyisim != "" && tel != "" && mail != "" && txtKadi.Text != "" && txtSifre.Text != "" && cmbCinsiyet.SelectedIndex>-1 && cmbMedeni.SelectedIndex>-1 && cmbDaireNo.SelectedIndex>-1 && cmbKat.SelectedIndex>-1)
                {

                    aidatlar ad = new aidatlar();
                    mesaj mh = new mesaj();
                    st.mesajs.Add(mh);
                    st.aidatlars.Add(ad);
                    st.resimlers.Add(rs);
                    DialogResult secenek = MessageBox.Show(" Ekleme yapmak istediğinize emin misiniz?", "Bilgilendirme Penceresi", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (secenek == DialogResult.Yes)
                    {
                        st.SaveChanges();
                    }
                    else if (secenek == DialogResult.No)
                    {
                        MessageBox.Show("Ekleme işlemi iptal edildi..");
                    }
                    MessageBox.Show("Yeni üye başarıyla eklenmiştir!");
                }
                else
                    MessageBox.Show("Bilgileri Doğru Giriniz!");
              
               this.Close();
            }
            catch(Exception ex)
            {
              MessageBox.Show("Bilgileri Doğru Giriniz!!");
            }

        }
 
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txtSifre.PasswordChar = '\0';

            }
            else
            {
                txtSifre.PasswordChar = '*';

            }
        }
        private void cmbKat_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            cmbDaireNo.Items.Clear();
            var daireNo = st.uyes.Where(x => x.apartmanId == uy.apartmanId).Select(x=> x.daireNo).ToList();
            int say = daireNo.Count;
            int daireSayisi = Convert.ToInt32(apr.daireSayisi);         
            int secilen = cmbKat.SelectedIndex;
            int sy;
            for (int i = 0; i < 2; i++)
            {
                sy = (secilen * 2) + 1 + i;
                if (daireNo.Contains(sy))
                {
                    cmbDaireNo.Items.Add("Dolu!");
                }
                else
                    cmbDaireNo.Items.Add(sy);           
            }
        }

        private void cmbDaireNo_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cmbDaireNo.SelectedItem == "Dolu!")
            {
                MessageBox.Show("Dolu daireleri seçemezsiniz!");
                cmbDaireNo.SelectedIndex = -1;
            }

        }

        private void cmbApartman_SelectedIndexChanged(object sender, EventArgs e)
        {
            int apartmanId = Convert.ToInt32(cmbApartman.SelectedValue);
            daire(apartmanId);
        }

     /*   private void label1_Click(object sender, EventArgs e)
        {

        }*/
    }
}
