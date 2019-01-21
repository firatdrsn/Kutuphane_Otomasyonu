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
    public partial class Mudur_Ekrani : Form
    {
        public Mudur_Ekrani()
        {
            InitializeComponent();
        }

        private void Mudur_Ekrani_Load(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection("server=DESKTOP-MN7VBMP\\SQL_2014; Initial Catalog=KutuphaneDemirbasVT;Integrated Security=SSPI");
            baglanti.Open();
            string kayit = "SELECT Kullanici.Ad,Kullanici.Kullanici_Adi'Kullanıcı Adı',Maas'Maaş',Ise_Bas_Tarihi'İşe Başlama Tarihi',Isten_Cikis_Tarihi'İşten Çıkış Tarihi' from Personel inner join Kullanici On Personel.Kullanici_ID=Kullanici.Kullanici_ID";
            string kayit2 = "SELECT * from Gizli_Soru";
            SqlCommand komut = new SqlCommand(kayit, baglanti);
            SqlCommand komut2 = new SqlCommand(kayit2, baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            SqlDataReader dr;
            dr = komut2.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr["Gizli_Soru"]);
            }
            baglanti.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection("server=DESKTOP-MN7VBMP\\SQL_2014; Initial Catalog=KutuphaneDemirbasVT;Integrated Security=SSPI");
            try
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand();
                komut.Connection = baglanti;
                komut.CommandText = "insert into Personel Values((Select Kullanici_ID From Kullanici Where Kullanici_Adi='" + textBox1.Text.ToString() + "'),3,'" + textBox2.Text.ToString() + "','" + textBox3.Text.ToString() + "','" + dateTimePicker1.Value.Date.ToString("yyyyMMdd") + "',NULL," + (comboBox1.SelectedIndex.ToString() + 1) + ",'" + textBox4.Text.ToString() + "')";
                SqlDataReader oku = komut.ExecuteReader();
                MessageBox.Show("Personel İşe Alındı");
                //baglanti.Close(); finally de olacak
            }
            catch(Exception hata)
            {
                MessageBox.Show("Hata" +hata.ToString());
            }
            finally
            {
                baglanti.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Kullanici_Ekle kullanici_ekle = new Kullanici_Ekle();
            kullanici_ekle.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Kitap_Ekle kitap_ekle = new Kitap_Ekle();
            kitap_ekle.Show();
        }

       

        private void button7_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection("server=DESKTOP-MN7VBMP\\SQL_2014; Initial Catalog=KutuphaneDemirbasVT;Integrated Security=SSPI");
            try {
            baglanti.Open();
            string kayit = "SELECT Kullanici.Ad,Kullanici.Kullanici_Adi'Kullanıcı Adı',Maas'Maaş',Ise_Bas_Tarihi'İşe Başlama Tarihi',Isten_Cikis_Tarihi'İşten Çıkış Tarihi' from Personel inner join Kullanici On Personel.Kullanici_ID=Kullanici.Kullanici_ID";
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
                SqlCommand komut = new SqlCommand();
                komut.Connection = baglanti;
                komut.CommandText = "update Personel Set Isten_Cikis_Tarihi='" + dateTimePicker2.Value.Date.ToString("yyyyMMdd") + "' Where Personel_ID=(Select Personel_ID From Personel inner join Kullanici On Personel.Kullanici_ID=Kullanici.Kullanici_ID Where Kullanici.Kullanici_Adi='"+textBox5.Text.ToString()+"')";
                SqlDataReader oku = komut.ExecuteReader();
                MessageBox.Show("Personel İşten Çıkarıldı");
                //baglanti.Close(); finally de olacak
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

        private void button6_Click_1(object sender, EventArgs e)
        {
            Giris giris = new Giris();
            this.Hide();
            giris.Show();
            
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void button5_click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
