namespace Kutuphane_Demirbas_Takip
{
    partial class rapor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.KitaplarBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.KutuphaneDemirbasVTDataSet = new Kutuphane_Demirbas_Takip.KutuphaneDemirbasVTDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.KitaplarTableAdapter = new Kutuphane_Demirbas_Takip.KutuphaneDemirbasVTDataSetTableAdapters.KitaplarTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.KitaplarBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.KutuphaneDemirbasVTDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // KitaplarBindingSource
            // 
            this.KitaplarBindingSource.DataMember = "Kitaplar";
            this.KitaplarBindingSource.DataSource = this.KutuphaneDemirbasVTDataSet;
            // 
            // KutuphaneDemirbasVTDataSet
            // 
            this.KutuphaneDemirbasVTDataSet.DataSetName = "KutuphaneDemirbasVTDataSet";
            this.KutuphaneDemirbasVTDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.KitaplarBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Kutuphane_Demirbas_Takip.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 450);
            this.reportViewer1.TabIndex = 0;
            this.reportViewer1.Load += new System.EventHandler(this.reportViewer1_Load);
            // 
            // KitaplarTableAdapter
            // 
            this.KitaplarTableAdapter.ClearBeforeFill = true;
            // 
            // rapor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "rapor";
            this.Text = "Rapor_Ekrani";
            this.Load += new System.EventHandler(this.rapor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.KitaplarBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.KutuphaneDemirbasVTDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource KitaplarBindingSource;
        private KutuphaneDemirbasVTDataSet KutuphaneDemirbasVTDataSet;
        private KutuphaneDemirbasVTDataSetTableAdapters.KitaplarTableAdapter KitaplarTableAdapter;
    }
}