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
    public partial class BillOfProductLayout : Form
    {
        public BillOfProductLayout()
        {
            InitializeComponent();
        }
        public string urunId;

        sqlBaglantisi bgl = new sqlBaglantisi();
        private void BillOfProductLayout_Load(object sender, EventArgs e)
        {
            txtUId.Text = urunId;
            SqlCommand komut = new SqlCommand("Select * From BillDetails where Id=@p1",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", urunId);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                txtUAD.Text = dr[1].ToString();
                txtMiktar.Text = dr[2].ToString();
                txtFiyat.Text = dr[3].ToString();
                txtTutar.Text = dr[4].ToString();

                bgl.baglanti().Close();
            }
        }

        private void BtnGüncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Update BillDetails set ProductName=@p1,Quantity=@p2,Price=@p3,Amount=@p4 where Id=@p5", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtUAD.Text);
            komut.Parameters.AddWithValue("@p2", txtMiktar.Text);
            komut.Parameters.AddWithValue("@p3", decimal.Parse(txtFiyat.Text));
            komut.Parameters.AddWithValue("@p4", decimal.Parse(txtTutar.Text));
            komut.Parameters.AddWithValue("@p5", txtUId.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Değişiklikler kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Delete From BillDetails where Id=@p1");
            komut.Parameters.AddWithValue("@p1", txtUId.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Ürün faturadan silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
