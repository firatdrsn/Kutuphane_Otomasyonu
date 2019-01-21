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
    public partial class Kullanici_Ekle : Form
    {
        public Kullanici_Ekle()
        {
            InitializeComponent();
        }

        private void Kullanici_Ekle_Load(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection("server=DESKTOP-MN7VBMP\\SQL_2014; Initial Catalog=KutuphaneDemirbasVT;Integrated Security=SSPI");
            try
            {
                baglanti.Open();
                string kayit = "SELECT Kullanici_ID'Kullanıcı ID',Kullanici_Adi'Kullanıcı Adı',Ad'Ad',Soyad'Soyad',TC_No'TCK Numarası',Tel_No'Telefon',Dogum_Tarihi'Doğum Tarihi',Sehir.Sehir_Adi'Şehir',Adres'Adres' from Kullanici inner join Sehir On Kullanici.Sehir_ID=Sehir.Sehir_ID";
                SqlCommand komut = new SqlCommand(kayit, baglanti);
                SqlCommand komut2 = new SqlCommand();
                komut2.CommandText = "SELECT * FROM Sehir";
                komut2.Connection = baglanti;
                komut2.CommandType = CommandType.Text;
                SqlDataReader dr;
                dr = komut2.ExecuteReader();
                while (dr.Read())
                {
                    comboBox1.Items.Add(dr["Sehir_Adi"]);
                }
                dr.Close();
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
            baglanti.Open();
            SqlCommand komut = new SqlCommand();
            komut.Connection = baglanti;
            komut.CommandText = "insert into Kullanici values ('" + textBox1.Text.ToString() + "','"+textBox2.Text.ToString()+"','"+textBox3.Text.ToString()+"','"+textBox4.Text.ToString()+"','"+textBox5.Text.ToString()+"','"+ dateTimePicker1.Value.Date.ToString("yyyyMMdd") + "',"+ ((comboBox1.SelectedIndex)+1).ToString() + ",'"+textBox7.Text.ToString()+"')";
            SqlDataReader oku = komut.ExecuteReader();
            baglanti.Close();
            MessageBox.Show("Kullanıcı Eklendi");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection("server=DESKTOP-MN7VBMP\\SQL_2014; Initial Catalog=KutuphaneDemirbasVT;Integrated Security=SSPI");
            baglanti.Open();
            string kayit = "SELECT Kullanici_ID'Kullanıcı ID',Kullanici_Adi'Kullanıcı Adı',Ad'Ad',Soyad'Soyad',TC_No'TCK Numarası',Tel_No'Telefon',Dogum_Tarihi'Doğum Tarihi',Sehir.Sehir_Adi'Şehir',Adres'Adres' from Kullanici inner join Sehir On Kullanici.Sehir_ID=Sehir.Sehir_ID";
            SqlCommand komut = new SqlCommand(kayit, baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form.ActiveForm.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
