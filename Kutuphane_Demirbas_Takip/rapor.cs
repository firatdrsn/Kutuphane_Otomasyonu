using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kutuphane_Demirbas_Takip
{
    public partial class rapor : Form
    {
        public rapor()
        {
            InitializeComponent();
        }

        private void rapor_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'KutuphaneDemirbasVTDataSet.Kitaplar' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.KitaplarTableAdapter.Fill(this.KutuphaneDemirbasVTDataSet.Kitaplar);

            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
