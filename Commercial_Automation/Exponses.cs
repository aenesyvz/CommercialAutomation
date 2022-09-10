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
    public partial class Exponses : Form
    {
        public Exponses()
        {
            InitializeComponent();
        }
        sqlBaglantisi bgl = new sqlBaglantisi();

        void giderListesi()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From Exponses", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }

        void temizle()
        {
            txtid.Text = "";
            txtSu.Text = "";
            txtDogalagaz.Text = "";
            txtElektrik.Text = "";
            txtMaaslar.Text = "";
            txtİnternet.Text = "";
            cmbAy.Text = "";
            cmbYil.Text = "";
            txtEkstra.Text = "";
            RchNotlar.Text = "";
        }
        private void Exponses_Load(object sender, EventArgs e)
        {
            giderListesi();
            temizle();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into Exponses  (Elektrik,Su,Dogalgaz,Internet,Maaslar,Ekstra,Notlar,Ay,Yıl) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", decimal.Parse(txtElektrik.Text));
            komut.Parameters.AddWithValue("@p2", decimal.Parse(txtSu.Text));
            komut.Parameters.AddWithValue("@p3", decimal.Parse(txtDogalagaz.Text));
            komut.Parameters.AddWithValue("@p4", decimal.Parse(txtİnternet.Text));
            komut.Parameters.AddWithValue("@p5", decimal.Parse(txtMaaslar.Text));
            komut.Parameters.AddWithValue("@p6", decimal.Parse(txtEkstra.Text));
            komut.Parameters.AddWithValue("@p7", RchNotlar.Text);
            komut.Parameters.AddWithValue("@p8", cmbAy.Text);
            komut.Parameters.AddWithValue("@p9", cmbYil.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Gider tabloya eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            giderListesi();
            temizle();
        }

        

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Delete From Exponses where Id=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtid.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Gider tablodan silindi", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            giderListesi();
            temizle();
        }

        private void BtnGüncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Update Exponses set Elektrik=@p1,Su=@p2,Dogalgaz=@p3,Internet=@p4,Maaslar=@p5,Ekstra=@p6,Notlar=@p7,Ay=@p8,Yıl=@p9 where Id=@p10", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", decimal.Parse(txtElektrik.Text));
            komut.Parameters.AddWithValue("@p2", decimal.Parse(txtSu.Text));
            komut.Parameters.AddWithValue("@p3", decimal.Parse(txtDogalagaz.Text));
            komut.Parameters.AddWithValue("@p4", decimal.Parse(txtİnternet.Text));
            komut.Parameters.AddWithValue("@p5", decimal.Parse(txtMaaslar.Text));
            komut.Parameters.AddWithValue("@p6", decimal.Parse(txtEkstra.Text));
            komut.Parameters.AddWithValue("@p7", RchNotlar.Text);
            komut.Parameters.AddWithValue("@p8", cmbAy.Text);
            komut.Parameters.AddWithValue("@p9", cmbYil.Text);
            komut.Parameters.AddWithValue("@p10", txtid.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Gider bilgisi güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            giderListesi();
            temizle();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                txtid.Text = dr["Id"].ToString();
                txtElektrik.Text = dr["Elektrik"].ToString();
                txtDogalagaz.Text = dr["Dogalgaz"].ToString();
                txtSu.Text = dr["Su"].ToString();
                txtİnternet.Text = dr["Internet"].ToString();
                txtMaaslar.Text = dr["Maaslar"].ToString();
                txtEkstra.Text = dr["Ekstra"].ToString();
                RchNotlar.Text = dr["Notlar"].ToString();
                cmbAy.Text = dr["Ay"].ToString();
                cmbYil.Text = dr["Yıl"].ToString();
            }
        }
    }
}
