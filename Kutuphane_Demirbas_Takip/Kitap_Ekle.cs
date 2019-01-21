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
    public partial class Kitap_Ekle : Form
    {
        public Kitap_Ekle()
        {
            InitializeComponent();
        }

        private void Kitap_Ekle_Load(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection("server=DESKTOP-MN7VBMP\\SQL_2014; Initial Catalog=KutuphaneDemirbasVT;Integrated Security=SSPI");
            try
            {
                baglanti.Open();
                string kayit = "SELECT Kitap_Adi'Kitap Adı',Kitap_Basim_Yili'Basım Yılı',Adet,Yazarlar.Yazar_Adi'Yazar',Barkod_No'Barkod Numarası',YayinEvi.YayinEvi_Adi'Yayın Evi',Kategori.KategoriAd'Kategori' from Kitaplar inner join Yazarlar on Kitaplar.Yazar_ID=Yazarlar.Yazar_ID inner join YayinEvi on Kitaplar.YayinEvi_ID=YayinEvi.YayinEvi_ID inner join Kategori on Kitaplar.Kategori_ID=Kategori.Kategori_ID";
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

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection("server=DESKTOP-MN7VBMP\\SQL_2014; Initial Catalog=KutuphaneDemirbasVT;Integrated Security=SSPI");
            baglanti.Open();
            SqlCommand komut = new SqlCommand();
            komut.Connection = baglanti;
            komut.CommandText = "insert into Kitaplar values ('" + textBox1.Text.ToString() + "','" + dateTimePicker1.Value.Date.ToString("yyyyMMdd") + "','" + textBox3.Text.ToString() + "',(select Yazar_ID From Yazarlar Where Yazar_Adi='"+textBox4.Text.ToString()+"'),'" + textBox5.Text.ToString() + "',(Select YayinEvi_ID From YayinEvi Where YayinEvi_Adi='"+textBox6.Text.ToString()+"'),(Select Kategori_ID From Kategori Where KategoriAd='"+textBox7.Text.ToString()+"'))";
            SqlDataReader oku = komut.ExecuteReader();
            baglanti.Close();
            MessageBox.Show("Kitap Eklendi");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection("server=DESKTOP-MN7VBMP\\SQL_2014; Initial Catalog=KutuphaneDemirbasVT;Integrated Security=SSPI");
            try
            {
                baglanti.Open();
                string kayit = "SELECT Kitap_Adi'Kitap Adı',Kitap_Basim_Yili'Basım Yılı',Adet,Yazarlar.Yazar_Adi'Yazar',Barkod_No'Barkod Numarası',YayinEvi.YayinEvi_Adi'Yayın Evi',Kategori.KategoriAd'Kategori' from Kitaplar inner join Yazarlar on Kitaplar.Yazar_ID=Yazarlar.Yazar_ID inner join YayinEvi on Kitaplar.YayinEvi_ID=YayinEvi.YayinEvi_ID inner join Kategori on Kitaplar.Kategori_ID=Kategori.Kategori_ID";
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


        private void button3_Click(object sender, EventArgs e)
        {
            Form.ActiveForm.Close();
        }
    }
}
