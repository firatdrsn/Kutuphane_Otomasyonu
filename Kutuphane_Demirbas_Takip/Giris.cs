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
    
    public partial class Giris : Form
    {
        public SqlConnection baglan;
        public SqlDataReader oku;
        public SqlDataReader oku_admin;
        public SqlDataReader oku_mudur;
        public SqlCommand komut;
        public SqlCommand komut2;
        public SqlCommand komut3;
      
        public Giris()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        public static string kullanici;
        private void button2_Click(object sender, EventArgs e)
        {
            Sifremi_unutum sifre = new Sifremi_unutum();
            sifre.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            kullanici = kullanici_adi.Text;
            string sifre = kullanici_sifre.Text;
            baglan = new SqlConnection("server=DESKTOP-MN7VBMP\\SQL_2014; Initial Catalog=KutuphaneDemirbasVT;Integrated Security=SSPI");
            komut = new SqlCommand();
            komut.Connection = baglan;
            komut2 = new SqlCommand();
            komut3 = new SqlCommand();
            baglan.Open();
            //Personel giriş kontrolü
            komut.CommandText = "select * from Personel inner join Kullanici On Personel.Kullanici_ID = Kullanici.Kullanici_ID Where Personel.Yetki_ID = '3' and Kullanici_Adi = '" + kullanici.ToString() +"' and Sifre = '"+sifre.ToString()+"'";
            oku =komut.ExecuteReader();

            if (oku.Read())
            {
                baglan.Close();
                this.Hide();
                Personel_Ekrani personel_form = new Personel_Ekrani();
                personel_form.Show();
            }
            else
            {
                oku.Close();
                komut2.Connection = baglan;
                komut2.CommandText = "select * from Personel inner join Kullanici On Personel.Kullanici_ID = Kullanici.Kullanici_ID Where Personel.Yetki_ID = '2' and Kullanici_Adi = '" + kullanici.ToString() + "' and Sifre = '" + sifre.ToString() + "'";
                oku_mudur = komut2.ExecuteReader();

                if (oku_mudur.Read())
                {
                    baglan.Close();
                    this.Hide();
                    Mudur_Ekrani mudur_form = new Mudur_Ekrani();
                    mudur_form.Show();
                }
                else
                {
                    oku_mudur.Close();
                    komut3.Connection = baglan;
                    komut3.CommandText = "select * from Personel inner join Kullanici On Personel.Kullanici_ID = Kullanici.Kullanici_ID Where Personel.Yetki_ID = '1' and Kullanici_Adi = '" + kullanici.ToString() + "' and Sifre = '" + sifre.ToString() + "'";
                    oku_admin = komut3.ExecuteReader();
                    if (oku_admin.Read())
                    {
                        baglan.Close();
                        this.Hide();
                        Admin_Ekrani admin_form = new Admin_Ekrani();
                        admin_form.Show();
                    }
                    else
                    {
                        MessageBox.Show("Yanlış Kullanıcı Adı veya Şifre");
                        baglan.Close();
                    }
                }
            }
 
        }
        private void Giris_Load(object sender, EventArgs e)
        {

        }

        private void kullanici_adi_TextChanged(object sender, EventArgs e)
        {

        }

        private void kullanici_sifre_TextChanged(object sender, EventArgs e)
        {

        }

        private void Giris_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
