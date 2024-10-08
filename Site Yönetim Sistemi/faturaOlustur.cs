using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Site_Yönetim_Sistemi
{
    public partial class faturaOlustur : Form
    {
        int id;
        siteyonetimsistemiEntities st;
        public faturaOlustur(int _id)
        {
            InitializeComponent();
            id = _id;
            st = new siteyonetimsistemiEntities();
            apartman apr = st.apartmen.Where(x => x.apartmanYoneticisi == id).FirstOrDefault();
            List<uye> uyeler = st.uyes.Where(x => x.apartmanId == apr.id).ToList();
            
            string[] aylar = { "Ocak", "Şubat", "Mart", "Nisan", "Mayıs", "Haziran", "Temmuz", "Ağustos", "Eylül", "Ekim", "Kasım", "Aralık" };
          
            cmbAy.DataSource = aylar;
        }

        private void faturaOlustur_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            

        }
    }
}
