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
using DevExpress.Charts;

namespace Commercial_Automation
{
    public partial class StrongBox : Form
    {
        public StrongBox()
        {
            InitializeComponent();
        }
        sqlBaglantisi bgl = new sqlBaglantisi();
        public string Name;

        void giderleriListele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From Exponses", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }

        void musteriHareketleri()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Execute CustomerMovement", bgl.baglanti());
            da.Fill(dt);
            gridControl2.DataSource = dt;
        }

        void firmaHareketleri()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Execute CompanyMovement", bgl.baglanti());
            da.Fill(dt);
            gridControl3.DataSource = dt;
        }

        
        private void StrongBox_Load(object sender, EventArgs e)
        {
            lblAktifKullanici.Text = Name;
            giderleriListele();
            musteriHareketleri();
            firmaHareketleri();

            SqlCommand komut1 = new SqlCommand("Select Sum(Amount) From BillDetails", bgl.baglanti());
            SqlDataReader dr1 = komut1.ExecuteReader();
            while (dr1.Read())
            {
                lblToplamTutar.Text = dr1[0].ToString() + " TL";
            }
            bgl.baglanti().Close();

            SqlCommand komut2 = new SqlCommand("Select (Elektrik + Su + Dogalgaz + Internet + Ekstra) From Exponses order by Id asc", bgl.baglanti());
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                lblOdemeler.Text = dr2[0].ToString() + " TL";
            }
            bgl.baglanti().Close();

            SqlCommand komut3 = new SqlCommand("Select Maaslar From Exponses", bgl.baglanti());
            SqlDataReader dr3 = komut3.ExecuteReader();
            while (dr3.Read())
            {
                lblPersonelMaas.Text = dr3[0].ToString() + " TL";
            }
            bgl.baglanti().Close();


            SqlCommand komut4 = new SqlCommand("Select Count(*) From Customers", bgl.baglanti());
            SqlDataReader dr4 = komut4.ExecuteReader();
            while (dr4.Read())
            {
                lblMusteriSayisi.Text = dr4[0].ToString();
            }
            bgl.baglanti().Close();


            SqlCommand komut5 = new SqlCommand("Select Count(*) From Companies", bgl.baglanti());
            SqlDataReader dr5 = komut5.ExecuteReader();
            while (dr5.Read())
            {
                lblFirmaSayisi.Text = dr5[0].ToString();
            }
            bgl.baglanti().Close();

            SqlCommand komut6 = new SqlCommand("Select Count(Distinct(City)) From Companies", bgl.baglanti());
            SqlDataReader dr6 = komut6.ExecuteReader();
            while (dr6.Read())
            {
                lblFirmaSehirSayisi.Text = dr6[0].ToString();
            }
            bgl.baglanti().Close();

            SqlCommand komut7 = new SqlCommand("Select Count(Distinct(City)) From Customers", bgl.baglanti());
            SqlDataReader dr7 = komut7.ExecuteReader();
            while (dr7.Read())
            {
                lblSehirSayisi.Text = dr7[0].ToString();
            }
            bgl.baglanti().Close();

            SqlCommand komut8 = new SqlCommand("Select Count(*) From Staffs", bgl.baglanti());
            SqlDataReader dr8 = komut8.ExecuteReader();
            while (dr8.Read())
            {
                lblPersonelSayisi.Text = dr8[0].ToString();
            }
            bgl.baglanti().Close();

            SqlCommand komut9 = new SqlCommand("Select Count(UnitsInStock) From Products", bgl.baglanti());
            SqlDataReader dr9 = komut9.ExecuteReader();
            while (dr9.Read())
            {
                lblStokSayisi.Text = dr9[0].ToString();
            }
            bgl.baglanti().Close();
        }

        int counter = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            counter++;
            if(counter > 0 && counter < 5)
            {
                gridControl1.Text = "ELEKTRİK";
                chartControl1.Series["AYLAR"].Points.Clear();
                SqlCommand komut10 = new SqlCommand("Select top 4 Ay,Elektrik from Exponses order by Id Desc", bgl.baglanti());
                SqlDataReader dr10 = komut10.ExecuteReader();
                while (dr10.Read())
                {
                    chartControl1.Series["AYLAR"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr10[0], dr10[1]));
                }
                bgl.baglanti().Close();
            }
            if(counter > 5 && counter <= 10)
            {
                groupControl1.Text = "SU";
                chartControl1.Series["AYLAR"].Points.Clear();
                SqlCommand komut11 = new SqlCommand("Select top 4 Ay,Su from Exponses order by Id Desc", bgl.baglanti());
                SqlDataReader dr11 = komut11.ExecuteReader();
                while (dr11.Read())
                {
                    chartControl1.Series["AYLAR"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr11[0], dr11[1]));
                }
                bgl.baglanti().Close();
            }
            if (counter > 10 && counter <= 15)
            {
                groupControl1.Text = "DOĞALGAZ";
                chartControl1.Series["AYLAR"].Points.Clear();
                SqlCommand komut11 = new SqlCommand("Select top 4 Ay,Dogalgaz from Exponses order by Id Desc", bgl.baglanti());
                SqlDataReader dr11 = komut11.ExecuteReader();
                while (dr11.Read())
                {
                    chartControl1.Series["AYLAR"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr11[0], dr11[1]));
                }
                bgl.baglanti().Close();
            }
            if (counter > 15 && counter <= 20)
            {
                groupControl1.Text = "İNTERNET";
                chartControl1.Series["AYLAR"].Points.Clear();
                SqlCommand komut11 = new SqlCommand("Select top 4 Ay,Internet from Exponses order by Id Desc", bgl.baglanti());
                SqlDataReader dr11 = komut11.ExecuteReader();
                while (dr11.Read())
                {
                    chartControl1.Series["AYLAR"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr11[0], dr11[1]));
                }
                bgl.baglanti().Close();
            }
            if (counter > 20 && counter <= 25)
            {
                groupControl1.Text = "EKSTRA";
                chartControl1.Series["AYLAR"].Points.Clear();
                SqlCommand komut11 = new SqlCommand("Select top 4 Ay,Ekstra from Exponses order by Id Desc", bgl.baglanti());
                SqlDataReader dr11 = komut11.ExecuteReader();
                while (dr11.Read())
                {
                    chartControl1.Series["AYLAR"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr11[0], dr11[1]));
                }
                bgl.baglanti().Close();
            }
            if(counter == 26)
            {
                counter = 0;
            }
        }
        int counter2 = 0;
        private void timer2_Tick(object sender, EventArgs e)
        {
            counter2++;
            if (counter2 > 0 && counter2 < 5)
            {
                groupControl12.Text = "ELEKTRİK";
                chartControl2.Series["AYLAR"].Points.Clear();
                SqlCommand komut10 = new SqlCommand("Select top 4 Ay,Elektrik from Exponses order by Id Desc", bgl.baglanti());
                SqlDataReader dr10 = komut10.ExecuteReader();
                while (dr10.Read())
                {
                    chartControl2.Series["AYLAR"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr10[0], dr10[1]));
                }
                bgl.baglanti().Close();
            }
            if (counter2 > 5 && counter2 <= 10)
            {
                groupControl12.Text = "SU";
                chartControl2.Series["AYLAR"].Points.Clear();
                SqlCommand komut11 = new SqlCommand("Select top 4 Ay,Su from Exponses order by Id Desc", bgl.baglanti());
                SqlDataReader dr11 = komut11.ExecuteReader();
                while (dr11.Read())
                {
                    chartControl2.Series["AYLAR"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr11[0], dr11[1]));
                }
                bgl.baglanti().Close();
            }
            if (counter2 > 10 && counter2 <= 15)
            {
                groupControl12.Text = "DOĞALGAZ";
                chartControl2.Series["AYLAR"].Points.Clear();
                SqlCommand komut11 = new SqlCommand("Select top 4 Ay,Dogalgaz from Exponses order by Id Desc", bgl.baglanti());
                SqlDataReader dr11 = komut11.ExecuteReader();
                while (dr11.Read())
                {
                    chartControl2.Series["AYLAR"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr11[0], dr11[1]));
                }
                bgl.baglanti().Close();
            }
            if (counter2 > 15 && counter2 <= 20)
            {
                groupControl12.Text = "İNTERNET";
                chartControl2.Series["AYLAR"].Points.Clear();
                SqlCommand komut11 = new SqlCommand("Select top 4 Ay,Internet from Exponses order by Id Desc", bgl.baglanti());
                SqlDataReader dr11 = komut11.ExecuteReader();
                while (dr11.Read())
                {
                    chartControl2.Series["AYLAR"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr11[0], dr11[1]));
                }
                bgl.baglanti().Close();
            }
            if (counter2 > 20 && counter2 <= 25)
            {
                groupControl12.Text = "EKSTRA";
                chartControl2.Series["AYLAR"].Points.Clear();
                SqlCommand komut11 = new SqlCommand("Select top 4 Ay,Ekstra from Exponses order by Id Desc", bgl.baglanti());
                SqlDataReader dr11 = komut11.ExecuteReader();
                while (dr11.Read())
                {
                    chartControl2.Series["AYLAR"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr11[0], dr11[1]));
                }
                bgl.baglanti().Close();
            }
            if (counter2 == 26)
            {
                counter2 = 0;
            }
        }
    }
}
