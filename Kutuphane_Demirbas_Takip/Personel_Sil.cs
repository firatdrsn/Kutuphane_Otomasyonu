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
    public partial class Personel_Sil : Form
    {
        public Personel_Sil()
        {
            InitializeComponent();
        }

        private void Personel_Sil_Load(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection("server=DESKTOP-MN7VBMP\\SQL_2014; Initial Catalog=KutuphaneDemirbasVT;Integrated Security=SSPI");
            try
            {
                baglanti.Open();
                string kayit = "SELECT Personel_ID'Personel ID',Kullanici.Ad,Kullanici.Kullanici_Adi'Kullanıcı Adı',Maas'Maaş',Ise_Bas_Tarihi'İşe Başlama Tarihi',Isten_Cikis_Tarihi'İşten Çıkış Tarihi' from Personel inner join Kullanici On Personel.Kullanici_ID=Kullanici.Kullanici_ID";
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

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection("server=DESKTOP-MN7VBMP\\SQL_2014; Initial Catalog=KutuphaneDemirbasVT;Integrated Security=SSPI");
            try
            {
                baglanti.Open();
                string kayit = "SELECT Personel_ID'Personel ID',Kullanici.Ad,Kullanici.Kullanici_Adi'Kullanıcı Adı',Maas'Maaş',Ise_Bas_Tarihi'İşe Başlama Tarihi',Isten_Cikis_Tarihi'İşten Çıkış Tarihi' from Personel inner join Kullanici On Personel.Kullanici_ID=Kullanici.Kullanici_ID";
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

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection("server=DESKTOP-MN7VBMP\\SQL_2014; Initial Catalog=KutuphaneDemirbasVT;Integrated Security=SSPI"); 
            baglanti.Open();
            SqlCommand komut = new SqlCommand();
            komut.Connection = baglanti;
            komut.CommandText = "Delete From Personel Where Personel_ID=" + textBox1.Text.ToString();
            SqlDataReader oku = komut.ExecuteReader();

            baglanti.Close();
            MessageBox.Show("Personel Silindi");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
