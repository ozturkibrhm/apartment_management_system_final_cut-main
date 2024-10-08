using System;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Site_Yönetim_Sistemi
{
    public partial class Guncelle : Form

    {
        uye uye;
        siteyonetimsistemiEntities st;
        public Guncelle(uye uye)
        {
            InitializeComponent();
            st = new siteyonetimsistemiEntities();
            this.uye = uye;
            formDoldur();
        }

        void formDoldur()
        {
            cmbCinsiyet.Items.Add("Kadın");
            cmbCinsiyet.Items.Add("Erkek");
            cmbMedeni.Items.Add("Evli");
            cmbMedeni.Items.Add("Bekar");

        }

        private void Guncelle_Load(object sender, EventArgs e)
        {

            txtAd.Text = uye.kullanici.ad;
            txtSoyad.Text = uye.kullanici.soyAd;
            txtMail.Text = uye.kullanici.mailAdresi;
            txtTelefon.Text = uye.kullanici.telefon;

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            string ad, soyad, telefon, mail, cinsiyet, medeni;
            ad = txtAd.Text;
            soyad = txtSoyad.Text;
            telefon = txtTelefon.Text;
            mail = txtMail.Text;
            cinsiyet = cmbCinsiyet.Text;
            medeni = cmbMedeni.Text;

            if (txtAd.Text != "" && txtSoyad.Text != "" && txtTelefon.Text != "" && txtMail.Text != "")
                if (uye.kullanici.ad.ToString() != ad.ToString())

                {
                    uye.kullanici.ad = ad;
                    uye.kullanici.soyAd = soyad;
                    uye.kullanici.telefon = telefon;
                    uye.kullanici.mailAdresi = mail;
                    uye.kullanici.medeniDurum = medeni;
                    uye.kullanici.cinsiyet = cinsiyet;


                    DialogResult secenek = MessageBox.Show("Hesap bilgilerinizi değiştirmek istediğinize emin misinz?", "Bilgilendirme Penceresi", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (secenek == DialogResult.Yes)
                    {

                        st.SaveChanges();


                    }
                    else if (secenek == DialogResult.No)
                    {
                        MessageBox.Show("İşlem iptal edildi..");
                    }

                    st.SaveChanges();
                    MessageBox.Show(" Başarıyla güncellendi");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Aynı bilgiler güncellenemez");
                }


        }



    }

    /* private void btnAracEkle_Click(object sender, EventArgs e)
     {


     }*/

    /* private void btnAracSil_Click(object sender, EventArgs e)
     {


     }*/

    /*  private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
      {

      }*/

    /*rivate void btnDaireSakiniEkle_Click(object sender, EventArgs e)
     {

     }

     private void btnDaireSakiniSil_Click(object sender, EventArgs e)
     {

     }

     private void btnDaireSakiniGuncelle_Click(object sender, EventArgs e)
     {

     }

     /*  private void txtAd_TextChanged(object sender, EventArgs e)
       {

       }*/
}

