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
    public partial class Personel_Ekrani : Form
    {
        public Personel_Ekrani()
        {
            InitializeComponent();
        }

        private void Personel_Ekrani_Load(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection("server=DESKTOP-MN7VBMP\\SQL_2014; Initial Catalog=KutuphaneDemirbasVT;Integrated Security=SSPI");
            baglanti.Open();
            string kayit = "SELECT Kitap_Adi'Kitap Adı',Kitap_Basim_Yili'Basım Yılı',Adet,Yazarlar.Yazar_Adi'Yazar',Barkod_No'Barkod Numarası',YayinEvi.YayinEvi_Adi'Yayın Evi',Kategori.KategoriAd'Kategori' from Kitaplar inner join Yazarlar on Kitaplar.Yazar_ID=Yazarlar.Yazar_ID inner join YayinEvi on Kitaplar.YayinEvi_ID=YayinEvi.YayinEvi_ID inner join Kategori on Kitaplar.Kategori_ID=Kategori.Kategori_ID";
            SqlCommand komut = new SqlCommand(kayit, baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Kullanici_View.DataSource = dt;
            baglanti.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Kullanici_Ekle k = new Kullanici_Ekle();
            k.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection baglan = new SqlConnection("server=DESKTOP-MN7VBMP\\SQL_2014; Initial Catalog=KutuphaneDemirbasVT;Integrated Security=SSPI");
            SqlCommand komut = new SqlCommand();
            komut.Connection = baglan;
            baglan.Open();
            komut.CommandText = "Update Odunc Set Verme_Tarihi=GETDATE() Where Kullanici_ID=(Select Kullanici_ID From Kullanici Where TC_No = '" + textBox1.Text.ToString() + "') and Kitap_ID=(Select Kitap_ID From Kitaplar inner join Yazarlar On Kitaplar.Yazar_ID = Yazarlar.Yazar_ID Where Kitap_Adi = '" + textBox2.Text.ToString() + "' and Yazarlar.Yazar_Adi = '" + textBox3.Text.ToString() + "') and Yazar_ID=(Select Yazar_ID From Yazarlar Where Yazar_Adi='" + textBox3.Text.ToString() + "')";
            komut.ExecuteReader();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection baglan = new SqlConnection("server=DESKTOP-MN7VBMP\\SQL_2014; Initial Catalog=KutuphaneDemirbasVT;Integrated Security=SSPI");
            SqlCommand komut = new SqlCommand();
            komut.Connection = baglan;
            baglan.Open();
            komut.CommandText = "insert into Odunc Values((Select Kitap_ID From Kitaplar inner join Yazarlar On Kitaplar.Yazar_ID = Yazarlar.Yazar_ID Where Kitap_Adi = '"+textBox2.Text.ToString()+"' and Yazarlar.Yazar_Adi = '"+textBox3.Text.ToString()+"'),(Select Personel_ID From Personel inner join Kullanici On Personel.Kullanici_ID = Kullanici.Kullanici_ID Where Kullanici.Kullanici_Adi = '"+Giris.kullanici+"'),(Select Kullanici_ID From Kullanici Where TC_No = '"+textBox1.Text.ToString()+"'),(Select Yazar_ID From Yazarlar Where Yazar_Adi = '"+textBox3.Text.ToString()+"'),GETDATE(),Null)";
            komut.ExecuteReader();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection("server=DESKTOP-MN7VBMP\\SQL_2014; Initial Catalog=KutuphaneDemirbasVT;Integrated Security=SSPI");
            baglanti.Open();
            string kayit = "SELECT Kitap_Adi'Kitap Adı',Kitap_Basim_Yili'Basım Yılı',Adet,Yazarlar.Yazar_Adi'Yazar',Barkod_No'Barkod Numarası',YayinEvi.YayinEvi_Adi'Yayın Evi',Kategori.KategoriAd'Kategori' from Kitaplar inner join Yazarlar on Kitaplar.Yazar_ID=Yazarlar.Yazar_ID inner join YayinEvi on Kitaplar.YayinEvi_ID=YayinEvi.YayinEvi_ID inner join Kategori on Kitaplar.Kategori_ID=Kategori.Kategori_ID";
            SqlCommand komut = new SqlCommand(kayit, baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Kullanici_View.DataSource = dt;
            baglanti.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection("server=DESKTOP-MN7VBMP\\SQL_2014; Initial Catalog=KutuphaneDemirbasVT;Integrated Security=SSPI");
            baglanti.Open();
            string kayit = "SELECT * from Odunc";
            SqlCommand komut = new SqlCommand(kayit, baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Kullanici_View.DataSource = dt;
            baglanti.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Kitap_Ekle kitap_ekle = new Kitap_Ekle();
            kitap_ekle.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Giris giris = new Giris();
            giris.Show();
            this.Hide();
            
        }

        private void button8_Click(object sender, EventArgs e)
        {
            rapor rpr = new rapor();
            rpr.ShowDialog();
                }

        private void Kullanici_View_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
