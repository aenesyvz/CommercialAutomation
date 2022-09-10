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
    public partial class Staffs : Form
    {
        public Staffs()
        {
            InitializeComponent();
        }
        sqlBaglantisi bgl = new sqlBaglantisi();
        void PersonelListesi()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Staffs",bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }
        private void Staffs_Load(object sender, EventArgs e)
        {
            PersonelListesi();
            sehirListesi();
            temizle();
        }
        void sehirListesi()
        {
            SqlCommand komut = new SqlCommand("Select Sehir From iller", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                cmbİl.Properties.Items.Add(dr[0]);
            }
            bgl.baglanti().Close();
        }
        
        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into Staffs  (FirstName,LastName,PhoneNumber,NationalityId,Email,City,District,Address,Status) values (@P1,@P2,@P3,@P4,@P5,@P6,@P7,@P8,@P9)",bgl.baglanti());
            komut.Parameters.AddWithValue("@P1", txtAd.Text);
            komut.Parameters.AddWithValue("@P2", txtSoyad.Text);
            komut.Parameters.AddWithValue("@P3", mskTel1.Text);
            komut.Parameters.AddWithValue("@P4", mskTc.Text);
            komut.Parameters.AddWithValue("@P5", txtEmail.Text);
            komut.Parameters.AddWithValue("@P6", cmbİl.Text);
            komut.Parameters.AddWithValue("@P7", cmbİlce.Text);
            komut.Parameters.AddWithValue("@P8", RchAdres.Text);
            komut.Parameters.AddWithValue("@P9", txtGorev.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Personel bilgileri kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            PersonelListesi();
        }

        private void cmbİl_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbİlce.Properties.Items.Clear();
            SqlCommand komut = new SqlCommand("Select ilce from ilceler where sehir=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", cmbİl.SelectedIndex + 1);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                cmbİlce.Properties.Items.Add(dr[0]);
            }
            bgl.baglanti().Close();
        }



        void temizle()
        {
            txtid.Text = "";
            txtAd.Text = "";
            txtSoyad.Text = "";
            mskTel1.Text = "";
            mskTc.Text = "";
            txtEmail.Text = "";
            cmbİl.Text = "";
            cmbİlce.Text = "";
            RchAdres.Text = "";
            txtGorev.Text = "";
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Delete From Staffs where Id=@P1",bgl.baglanti());
            komut.Parameters.AddWithValue("@P1", txtid.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Personel Listeden Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            PersonelListesi();
            temizle();
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void BtnGüncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Update Staffs set FirstName=@P1,LastName=@P2,PhoneNumber=@P3,NationalityId=@P4,Email=@P5,City=@P6,District=@P7,Address=@P8,Status=@P9 where Id=@P10",bgl.baglanti());
            komut.Parameters.AddWithValue("@P1", txtAd.Text);
            komut.Parameters.AddWithValue("@P2", txtSoyad.Text);
            komut.Parameters.AddWithValue("@P3", mskTel1.Text);
            komut.Parameters.AddWithValue("@P4", mskTc.Text);
            komut.Parameters.AddWithValue("@P5", txtEmail.Text);
            komut.Parameters.AddWithValue("@P6", cmbİl.Text);
            komut.Parameters.AddWithValue("@P7", cmbİlce.Text);
            komut.Parameters.AddWithValue("@P8", RchAdres.Text);
            komut.Parameters.AddWithValue("@P9", txtGorev.Text);
            komut.Parameters.AddWithValue("@P10", txtid.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Personel bilgileri güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            PersonelListesi();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if(dr != null)
            {
                txtid.Text = dr["Id"].ToString();
                txtAd.Text = dr["FirstName"].ToString();
                txtSoyad.Text = dr["LastName"].ToString();
                mskTel1.Text = dr["PhoneNumber"].ToString();
                mskTc.Text = dr["NationalityId"].ToString();
                txtEmail.Text = dr["Email"].ToString();
                cmbİl.Text = dr["City"].ToString();
                cmbİlce.Text = dr["District"].ToString();
                RchAdres.Text = dr["Address"].ToString();
                txtGorev.Text = dr["Status"].ToString();
            }
        }
    }
}
