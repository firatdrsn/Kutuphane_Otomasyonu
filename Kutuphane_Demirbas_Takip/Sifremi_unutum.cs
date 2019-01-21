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
    public partial class Sifremi_unutum : Form
    {
        public SqlConnection baglan;
        public SqlDataReader oku;
        public SqlCommand komut;
        public SqlCommand komut3;

        public Sifremi_unutum()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            baglan = new SqlConnection("server=DESKTOP-MN7VBMP\\SQL_2014; Initial Catalog=KutuphaneDemirbasVT;Integrated Security=SSPI");
            string kullanici = textBox1.Text;
            komut = new SqlCommand();
            baglan.Open();
            komut.Connection = baglan;

            komut.CommandText = "select * from Personel inner join Kullanici On Personel.Kullanici_ID = Kullanici.Kullanici_ID Where Kullanici_Adi = '" + textBox1.Text.ToString() + "'";
            oku = komut.ExecuteReader();
            if(oku.Read())
            {
                oku.Close();
                DataTable dt = new DataTable();
                string komut2;
                komut2 = "select Gizli_Cevap from Personel inner join Kullanici On Personel.Kullanici_ID = Kullanici.Kullanici_ID Where Kullanici_Adi = '" + textBox1.Text.ToString() + "'";
                SqlDataAdapter da = new SqlDataAdapter(komut2, baglan);
                da.Fill(dt);
                label5.Text = dt.Rows[0][0].ToString();
                label5.Visible = true;
                
            }
            baglan.Close();
        }

        private void Sifremi_unutum_Load(object sender, EventArgs e)
        {
            label5.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglan.Open();
            komut3 = new SqlCommand();
            komut3.Connection = baglan;
            komut3.CommandText = "select * from Personel inner join Kullanici On Personel.Kullanici_ID = Kullanici.Kullanici_ID Where Gizli_Cevap = '"+textBox3.Text.ToString()+"' and Kullanici_Adi = '" + textBox1.Text.ToString() + "' and Kullanici.TC_No='"+textBox2.Text.ToString()+"'";
            oku = komut3.ExecuteReader();
            if(oku.Read())
            {
                oku.Close();
                DataTable dt = new DataTable();
                string komut4;
                komut4 = "select Sifre from Personel inner join Kullanici On Personel.Kullanici_ID = Kullanici.Kullanici_ID Where Kullanici_Adi = '" + textBox1.Text.ToString() + "' and Kullanici.TC_No='"+textBox2.Text.ToString()+"' and Gizli_Cevap='"+textBox3.Text.ToString()+"'";
                SqlDataAdapter da = new SqlDataAdapter(komut4, baglan);
                da.Fill(dt);
                MessageBox.Show(dt.Rows[0][0].ToString());
                baglan.Close();
            }
            else
            {
                MessageBox.Show("Bilgilerinizi yanlış girdiniz!");
            }
            baglan.Close();
        }

        private void Sifremi_unutum_FormClosing(object sender, FormClosingEventArgs e)
        {
           
        }
    }
}
