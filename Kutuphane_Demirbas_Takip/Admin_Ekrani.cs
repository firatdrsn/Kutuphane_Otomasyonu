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
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;
using System.IO;


namespace Kutuphane_Demirbas_Takip
{
    public partial class Admin_Ekrani : Form
    {
        public Admin_Ekrani()
        {
            InitializeComponent();
        }

        private void Admin_Ekrani_Load(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
           
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Yedek yedek = new Yedek();
            yedek.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Kitap_Ekle kitap_ekle = new Kitap_Ekle();
            kitap_ekle.Show();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            Kullanici_Ekle kullanici_ekle = new Kullanici_Ekle();
            kullanici_ekle.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Mudur_Ekrani mudur = new Mudur_Ekrani();
            mudur.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Kitap_Sil kitap_sil = new Kitap_Sil();
            kitap_sil.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Sql_islemleri sql = new Sql_islemleri();
            sql.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Kullanici_Sil kullanici_sil = new Kullanici_Sil();
            kullanici_sil.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Personel_Sil persil = new Personel_Sil();
            persil.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Personel_Yetkilendir peryetki = new Personel_Yetkilendir();
            peryetki.Show();
        }
    }
}
