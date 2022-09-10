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

namespace Commercial_Automation
{
    public partial class Products : Form
    {
        public Products()
        {
            InitializeComponent();
        }
        sqlBaglantisi bgl = new sqlBaglantisi();
        void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From Products", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }
        private void Products_Load(object sender, EventArgs e)
        {
            listele();
            temizle();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into Products (ProductName,Brand,Model,Year,UnitsInStock,PurchasePrice,SalePrice,Detail) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8)",
             bgl.baglanti());

            komut.Parameters.AddWithValue("@p1",txtAd.Text);
            komut.Parameters.AddWithValue("@p2",txtMarka.Text);
            komut.Parameters.AddWithValue("@p3",txtModel.Text);
            komut.Parameters.AddWithValue("@p4",mskYil.Text);
            komut.Parameters.AddWithValue("@p5",int.Parse((NudAdet.Value).ToString()));
            komut.Parameters.AddWithValue("@p6",decimal.Parse(txtAliş.Text));
            komut.Parameters.AddWithValue("@p7",decimal.Parse(txtSatis.Text));
            komut.Parameters.AddWithValue("@p8",RchDetay.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Ürün sisteme eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komutsil = new SqlCommand("Delete From Products where Id=@p1", bgl.baglanti());
            komutsil.Parameters.AddWithValue("@p1", txtid.Text);
            komutsil.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Ürün silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            listele();
        }

        private void BtnGüncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update Products set ProductName=@P1,Brand=@P2,Model=@P3,Year=@P4,UnitsInStock=@P5,PurchasePrice=@P6,SalePrice=@P7,Detail=@P8 where Id=@P9",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtAd.Text);
            komut.Parameters.AddWithValue("@p2", txtMarka.Text);
            komut.Parameters.AddWithValue("@p3", txtModel.Text);
            komut.Parameters.AddWithValue("@p4", mskYil.Text);
            komut.Parameters.AddWithValue("@p5", int.Parse((NudAdet.Value).ToString()));
            komut.Parameters.AddWithValue("@p6", decimal.Parse(txtAliş.Text));
            komut.Parameters.AddWithValue("@p7", decimal.Parse(txtSatis.Text));
            komut.Parameters.AddWithValue("@p8", RchDetay.Text);
            komut.Parameters.AddWithValue("@P9", txtid.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Ürün bilgisi güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
        }

        private void gridView1_FocusedRowChanged_1(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            txtid.Text = dr["Id"].ToString();
            txtAd.Text = dr["ProductName"].ToString();
            txtMarka.Text = dr["Brand"].ToString();
            txtModel.Text = dr["Model"].ToString();
            mskYil.Text = dr["Year"].ToString();
            NudAdet.Value = int.Parse(dr["UnitsInStock"].ToString());
            txtAliş.Text = dr["PurchasePrice"].ToString();
            txtSatis.Text = dr["SalePrice"].ToString();
            RchDetay.Text = dr["Detail"].ToString();
        }

        void temizle()
        {
            txtid.Text = "";
            txtAd.Text = "";
            txtMarka.Text = "";
            txtModel.Text = "";
            mskYil.Text = "";
            txtAliş.Text = "";
            txtSatis.Text = "";
            RchDetay.Text = "";
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }
    }
}
