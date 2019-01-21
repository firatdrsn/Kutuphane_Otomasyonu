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
    public partial class Personel_Yetkilendir : Form
    {
        public Personel_Yetkilendir()
        {
            InitializeComponent();
        }

        private void Personel_Yetkilendir_Load(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection("server=DESKTOP-MN7VBMP\\SQL_2014; Initial Catalog=KutuphaneDemirbasVT;Integrated Security=SSPI");
            try
            {
                baglanti.Open();
                string kayit = "SELECT Personel_ID'Personel ID',Yetkiler.Yetki_ID'Yetki Kodu',Yetkiler.Yetki_Adı'Yetki',Kullanici.Ad,Kullanici.Kullanici_Adi'Kullanıcı Adı',Maas'Maaş',Ise_Bas_Tarihi'İşe Başlama Tarihi',Isten_Cikis_Tarihi'İşten Çıkış Tarihi' from Personel inner join Kullanici On Personel.Kullanici_ID=Kullanici.Kullanici_ID inner join Yetkiler On Personel.Yetki_ID=Yetkiler.Yetki_ID";
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
            try
            {
                baglanti.Open();
                string kayit = "SELECT Personel_ID'Personel ID',Yetkiler.Yetki_ID'Yetki Kodu',Yetkiler.Yetki_Adı'Yetki',Kullanici.Ad,Kullanici.Kullanici_Adi'Kullanıcı Adı',Maas'Maaş',Ise_Bas_Tarihi'İşe Başlama Tarihi',Isten_Cikis_Tarihi'İşten Çıkış Tarihi' from Personel inner join Kullanici On Personel.Kullanici_ID=Kullanici.Kullanici_ID inner join Yetkiler On Personel.Yetki_ID=Yetkiler.Yetki_ID";
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
            SqlConnection baglan = new SqlConnection("server=DESKTOP-MN7VBMP\\SQL_2014; Initial Catalog=KutuphaneDemirbasVT;Integrated Security=SSPI");
            SqlCommand komut = new SqlCommand();
            SqlCommand komut2 = new SqlCommand();
            komut.Connection = baglan;
            komut2.Connection = baglan;
            baglan.Open();
            komut.CommandText = "disable trigger PersonelCikar on Personel Update Personel Set Yetki_ID=" + textBox2.Text.ToString() + " Where Personel_ID=" + textBox1.Text + "";
            komut.ExecuteReader();
            baglan.Close();
            baglan.Open();
            komut2.CommandText = "enable trigger PersonelCikar on Personel";
            komut2.ExecuteReader();
            baglan.Close();
        }
    }
}
