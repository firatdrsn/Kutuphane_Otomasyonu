using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Kutuphane_Demirbas_Takip
{
    public partial class Odunc : Form
    {
        public Odunc()
        {
            InitializeComponent();
        }

        private void Odunc_Load(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection("server=DESKTOP-MN7VBMP\\SQL_2014; Initial Catalog=KutuphaneDemirbasVT;Integrated Security=SSPI");
            try { 
            baglanti.Open();
            string kayit = " SELECT Odunc_ID'Ödünç ID',Kitaplar.Kitap_Adi'Kitap',Personel2.Kullanici_Adi'Personel',Kullanici2.Kullanici_Adi'Kullanıcı',Alma_Tarihi'Alma Tarihi',Verme_Tarihi'Verme Tarihi' From Odunc inner join Kitaplar On Odunc.Kitap_ID=Kitaplar.Kitap_ID inner join Personel On Odunc.Personel_ID=Personel.Personel_ID inner join Kullanici As Personel2 on Personel.Kullanici_ID=Personel2.Kullanici_ID inner join Kullanici AS Kullanici2 on Odunc.Kullanici_ID=Kullanici2.Kullanici_ID";
            SqlCommand komut = new SqlCommand(kayit, baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            }
            catch (Exception hata)
            {
                MessageBox.Show("Hata" + hata.ToString());
            }
            finally
            {
                baglanti.Close();
            }
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
