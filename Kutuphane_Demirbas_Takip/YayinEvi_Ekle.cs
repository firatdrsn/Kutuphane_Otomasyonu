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
    public partial class YayinEvi_Ekle : Form
    {
        public YayinEvi_Ekle()
        {
            InitializeComponent();
        }

        private void YayinEvi_Ekle_Load(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection("server=DESKTOP-MN7VBMP\\SQL_2014; Initial Catalog=kutuphane_demirbasVT;Integrated Security=SSPI");
            baglanti.Open();
            string kayit = "SELECT * from YayinEvi";
            SqlCommand komut = new SqlCommand(kayit, baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti.Close();
        }
    }
}
