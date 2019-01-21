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
    public partial class Yedek : Form
    {
        public Yedek()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-MN7VBMP\\SQL_2014; Initial Catalog=master;Integrated Security=true;");
            try
            {
                openFileDialog1.Title = "Backup Dosyasını Seçin";
                openFileDialog1.FileName = "KutuphaneDemirbasVT";
                openFileDialog1.Filter = "Backup Dosyası |*.bak";
                openFileDialog1.FilterIndex = 2;
                openFileDialog1.InitialDirectory = "D:\\";
                openFileDialog1.ShowDialog();
                string vt_adresi = openFileDialog1.FileName.ToString();
                baglanti.Open();
                SqlCommand komut = new SqlCommand(@"RESTORE DATABASE KutuphaneDemirbasVT FROM DISK = '" + vt_adresi.ToString() + "' WITH REPLACE;", baglanti);
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Başarıyla Açıldı");
            }
            catch(Exception exc)
            {
                MessageBox.Show("Hata oluştu"+"  Hata = > "+exc.ToString());
            }
            finally
            {
                baglanti.Close();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-MN7VBMP\\SQL_2014; Initial Catalog=master;Integrated Security=true;");
            try
            {
            folderBrowserDialog1.RootFolder = Environment.SpecialFolder.MyComputer;
            folderBrowserDialog1.ShowDialog();
            string vt_adresi = folderBrowserDialog1.SelectedPath.ToString();
            vt_adresi = vt_adresi + "\\KutuphaneDemirbasVT.bak";
            baglanti.Open();
            SqlCommand komut = new SqlCommand(@"BACKUP DATABASE KutuphaneDemirbasVT TO DISK = '" + vt_adresi.ToString() + "'  WITH FORMAT,     MEDIANAME = 'KutuphaneDemirbasVT_BACKUP',   NAME = 'KutuphaneDemirbasVT-FULL_BACKUP';", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Başarıyla Kaydedildi");
            }
            catch (Exception exc)
            {
                MessageBox.Show("Hata oluştu" + "  Hata = > " + exc.ToString());
            }
            finally
            {
                baglanti.Close();
            }
        }

        private void Yedek_Load(object sender, EventArgs e)
        {

        }
    }
}
