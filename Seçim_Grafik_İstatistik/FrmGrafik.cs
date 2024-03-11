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

namespace Seçim_Grafik_İstatistik
{
    public partial class FrmGrafik : Form
    {
        public FrmGrafik()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-GIZEM\SQLEXPRESS01;Initial Catalog=DBSECIMMPROJE;Integrated Security=True");
        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void progressBar5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void FrmGrafik_Load(object sender, EventArgs e)
        {   //ilçe adlarını comboboxa çekme
            baglanti.Open();
            SqlCommand komut= new SqlCommand("select ILCEAD from TBLILCEAD",baglanti);
            SqlDataReader dr=komut.ExecuteReader();
            while (dr.Read()) 
            {
                comboBox1.Items.Add(dr[0]);
            }
            baglanti.Close();
            // grafiğe sonuçları getirme
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand(" select SUM(apartı),SUM(BPARTI),SUM(CPARTI),SUM(DPARTI),SUM(EPARTI) FROM TBLILCEAD", baglanti);
            SqlDataReader dr2=komut2.ExecuteReader();
            while (dr2.Read()) 
            {
                chart1.Series["Partiler"].Points.AddXY("A Parti", dr2[0]);
                chart1.Series["Partiler"].Points.AddXY("B Parti", dr2[1]);
                chart1.Series["Partiler"].Points.AddXY("C Parti", dr2[2]);
                chart1.Series["Partiler"].Points.AddXY("D Parti", dr2[3]);
                chart1.Series["Partiler"].Points.AddXY("E Parti", dr2[4]);
            }
            baglanti.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * From TBLILCEAD where ILCEAD=@P1", baglanti);
            komut.Parameters.AddWithValue("@P1", comboBox1.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read()) 
            {
                progressBar1.Value = int.Parse(dr[2].ToString());
                progressBar2.Value = int.Parse(dr[3].ToString());
                progressBar3.Value = int.Parse(dr[4].ToString());
                progressBar4.Value = int.Parse(dr[5].ToString());
                progressBar5.Value = int.Parse(dr[6].ToString());
                lblA.Text = dr[2].ToString();
                lblB.Text = dr[3].ToString();
                lblC.Text = dr[4].ToString();
                lblD.Text = dr[5].ToString();
                lblE.Text = dr[6].ToString();
            }
            baglanti.Close();
        }
    }
}
