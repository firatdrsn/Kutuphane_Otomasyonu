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
    public partial class Kullanici_Ekrani : Form
    {
        public Kullanici_Ekrani()
        {
            InitializeComponent();
        }

        private void ANASAYFA_Load(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection("server=DESKTOP-MN7VBMP\\SQL_2014; Initial Catalog=KutuphaneDemirbasVT;Integrated Security=SSPI");
            baglanti.Open();
            string kayit = "SELECT Kitap_Adi'Kitap Adı',Kitap_Basim_Yili'Basım Yılı',Adet,Yazarlar.Yazar_Adi'Yazar',Barkod_No'Barkod Numarası',YayinEvi.YayinEvi_Adi'Yayın Evi',Kategori.KategoriAd'Kategori' from Kitaplar inner join Yazarlar on Kitaplar.Yazar_ID=Yazarlar.Yazar_ID inner join YayinEvi on Kitaplar.YayinEvi_ID=YayinEvi.YayinEvi_ID inner join Kategori on Kitaplar.Kategori_ID=Kategori.Kategori_ID";
            SqlCommand komut = new SqlCommand(kayit, baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection baglan = new SqlConnection("server=DESKTOP-MN7VBMP\\SQL_2014; Initial Catalog=KutuphaneDemirbasVT;Integrated Security=SSPI");

            baglan.Open();
            SqlCommand komut = new SqlCommand();
            komut.Connection = baglan;
            komut.CommandText = "select * from Kitaplar";
            SqlDataReader oku = komut.ExecuteReader();
            if (oku.Read())
            {
                oku.Close();
                DataTable dt = new DataTable();
                string komut2;
                komut2 = "SELECT Kitap_Adi'Kitap Adı',Kitap_Basim_Yili'Basım Yılı',Adet,Yazarlar.Yazar_Adi'Yazar',Barkod_No'Barkod Numarası',YayinEvi.YayinEvi_Adi'Yayın Evi',Kategori.KategoriAd'Kategori' from Kitaplar inner join Yazarlar on Kitaplar.Yazar_ID=Yazarlar.Yazar_ID inner join YayinEvi on Kitaplar.YayinEvi_ID=YayinEvi.YayinEvi_ID inner join Kategori on Kitaplar.Kategori_ID=Kategori.Kategori_ID Where Kitap_Adi Like '%" + textBox1.Text.ToString()+"%'";
                SqlDataAdapter da = new SqlDataAdapter(komut2, baglan);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                baglan.Close();
            }
            else
            {
                MessageBox.Show("Aradığınız Kitap Bulunamadı");
                oku.Close();
                baglan.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection("server=DESKTOP-MN7VBMP\\SQL_2014; Initial Catalog=KutuphaneDemirbasVT;Integrated Security=SSPI");
            baglanti.Open();
            string kayit = "SELECT Kitap_Adi'Kitap Adı',Kitap_Basim_Yili'Basım Yılı',Adet,Yazarlar.Yazar_Adi'Yazar',Barkod_No'Barkod Numarası',YayinEvi.YayinEvi_Adi'Yayın Evi',Kategori.KategoriAd'Kategori' from Kitaplar inner join Yazarlar on Kitaplar.Yazar_ID=Yazarlar.Yazar_ID inner join YayinEvi on Kitaplar.YayinEvi_ID=YayinEvi.YayinEvi_ID inner join Kategori on Kitaplar.Kategori_ID=Kategori.Kategori_ID";
            SqlCommand komut = new SqlCommand(kayit, baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection baglan = new SqlConnection("server=DESKTOP-MN7VBMP\\SQL_2014; Initial Catalog=KutuphaneDemirbasVT;Integrated Security=SSPI");

            baglan.Open();
            SqlCommand komut = new SqlCommand();
            komut.Connection = baglan;
            komut.CommandText = "select * from Kitaplar";
            SqlDataReader oku = komut.ExecuteReader();
            if (oku.Read())
            {
                oku.Close();
                DataTable dt = new DataTable();
                string komut2;
                komut2 = "SELECT Kitap_Adi'Kitap Adı',Kitap_Basim_Yili'Basım Yılı',Adet,Yazarlar.Yazar_Adi'Yazar',Barkod_No'Barkod Numarası',YayinEvi.YayinEvi_Adi'Yayın Evi',Kategori.KategoriAd'Kategori' from Kitaplar inner join Yazarlar on Kitaplar.Yazar_ID=Yazarlar.Yazar_ID inner join YayinEvi on Kitaplar.YayinEvi_ID=YayinEvi.YayinEvi_ID inner join Kategori on Kitaplar.Kategori_ID=Kategori.Kategori_ID Where Yazarlar.Yazar_Adi Like '%" + textBox2.Text.ToString() + "%'";
                SqlDataAdapter da = new SqlDataAdapter(komut2, baglan);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                baglan.Close();
            }
            else
            {
                MessageBox.Show("Aradığınız Yazar Bulunamadı");
                oku.Close();
                baglan.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection baglan = new SqlConnection("server=DESKTOP-MN7VBMP\\SQL_2014; Initial Catalog=KutuphaneDemirbasVT;Integrated Security=SSPI");

            baglan.Open();
            SqlCommand komut = new SqlCommand();
            komut.Connection = baglan;
            komut.CommandText = "select * from Kitaplar";
            SqlDataReader oku = komut.ExecuteReader();
            if (oku.Read())
            {
                oku.Close();
                DataTable dt = new DataTable();
                string komut2;
                komut2 = "SELECT Kitap_Adi'Kitap Adı',Kitap_Basim_Yili'Basım Yılı',Adet,Yazarlar.Yazar_Adi'Yazar',Barkod_No'Barkod Numarası',YayinEvi.YayinEvi_Adi'Yayın Evi',Kategori.KategoriAd'Kategori' from Kitaplar inner join Yazarlar on Kitaplar.Yazar_ID=Yazarlar.Yazar_ID inner join YayinEvi on Kitaplar.YayinEvi_ID=YayinEvi.YayinEvi_ID inner join Kategori on Kitaplar.Kategori_ID=Kategori.Kategori_ID Where Kategori.KategoriAd Like '%" + textBox3.Text.ToString() + "%'";
                SqlDataAdapter da = new SqlDataAdapter(komut2, baglan);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                baglan.Close();
            }
            else
            {
                MessageBox.Show("Aradığınız Kategori Bulunamadı");
                oku.Close();
                baglan.Close();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection baglan = new SqlConnection("server=DESKTOP-MN7VBMP\\SQL_2014; Initial Catalog=KutuphaneDemirbasVT;Integrated Security=SSPI");

            baglan.Open();
            SqlCommand komut = new SqlCommand();
            komut.Connection = baglan;
            komut.CommandText = "select * from Kitaplar";
            SqlDataReader oku = komut.ExecuteReader();
            if (oku.Read())
            {
                oku.Close();
                DataTable dt = new DataTable();
                string komut2;
                komut2 = "exec sp_kitap_ara " + textBox4.Text.ToString();
                SqlDataAdapter da = new SqlDataAdapter(komut2, baglan);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                baglan.Close();
            }
            else
            {
                MessageBox.Show("Bulunamadı");
                oku.Close();
                baglan.Close();
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            SqlConnection baglan = new SqlConnection("server=DESKTOP-MN7VBMP\\SQL_2014; Initial Catalog=KutuphaneDemirbasVT;Integrated Security=SSPI");

            baglan.Open();
            SqlCommand komut = new SqlCommand();
            komut.Connection = baglan;
            komut.CommandText = "select * from Kitaplar";
            SqlDataReader oku = komut.ExecuteReader();
            if (oku.Read())
            {
                oku.Close();
                DataTable dt = new DataTable();
                string komut2;
                komut2 = "exec sp_kitap_yazar_ara '"+ textBox5.Text.ToString()+"','"+textBox6.Text.ToString()+"'";
                SqlDataAdapter da = new SqlDataAdapter(komut2, baglan);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                baglan.Close();
            }
            else
            {
                MessageBox.Show("Bulunamadı");
                oku.Close();
                baglan.Close();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Giris giris = new Giris();
            giris.Show();
            this.Hide();
        }

        private void Kullanici_Ekrani_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
