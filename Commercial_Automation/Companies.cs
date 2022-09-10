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
    public partial class Companies : Form
    {
        public Companies()
        {
            InitializeComponent();
        }

        sqlBaglantisi bgl = new sqlBaglantisi();
        void firmaListesi()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * From Companies", bgl.baglanti());
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }
        private void Companies_Load(object sender, EventArgs e)
        {
            firmaListesi();
            sehirListesi();
            
            carikodaciklamalar();
        }
        void carikodaciklamalar()
        {
            SqlCommand komut = new SqlCommand("Select FirmaKod1 from Kodlar", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                txtKod1.Text = dr[0].ToString();
            }
            bgl.baglanti().Close();
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
        

        void temizle()
        {
            txtid.Text = "";
            txtAd.Text = "";
            txtYetkiliGorev.Text = "";
            txtYetkili.Text = "";
            mskTc.Text = "";
            txtSektor.Text = "";
            mskTel1.Text = "";
            mskTel2.Text = "";
            mskTel3.Text = "";
            txtEmail.Text = "";
            mskFax.Text = "";
            cmbİl.Text = "";
            cmbİlce.Text = "";
            txtVergi.Text = "";
            RchAdres.Text = "";
            txtKod1.Text = "";
            txtKod2.Text = "";
            txtKod3.Text = "";

        }
        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into Companies (CompanyName,AuthorizedStatus,AuthorizedNameSurname,AuthorizedTc,Sector,PhoneNumber,PhoneNumber2,PhoneNumber3,Email,Fax,City,District,TaxAdministration,Address,SpecialCode1,SpecialCode2,SpecialCode3) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12,@p13,@p14,@p15,@p16,@p17)",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtAd.Text);
            komut.Parameters.AddWithValue("@p2", txtYetkiliGorev.Text);
            komut.Parameters.AddWithValue("@p3", txtYetkili.Text);
            komut.Parameters.AddWithValue("@p4", mskTc.Text);
            komut.Parameters.AddWithValue("@p5", txtSektor.Text);
            komut.Parameters.AddWithValue("@p6", mskTel1.Text);
            komut.Parameters.AddWithValue("@p7", mskTel2.Text);
            komut.Parameters.AddWithValue("@p8", mskTel3.Text);
            komut.Parameters.AddWithValue("@p9", txtEmail.Text);
            komut.Parameters.AddWithValue("@p10", mskFax.Text);
            komut.Parameters.AddWithValue("@p11", cmbİl.Text);
            komut.Parameters.AddWithValue("@p12", cmbİlce.Text);
            komut.Parameters.AddWithValue("@p13", txtVergi.Text);
            komut.Parameters.AddWithValue("@p14", RchAdres.Text);
            komut.Parameters.AddWithValue("@p15", txtKod1.Text);
            komut.Parameters.AddWithValue("@p16", txtKod2.Text);
            komut.Parameters.AddWithValue("@p17", txtKod3.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Firma sisteme kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            firmaListesi();
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

        private void BtnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Delete From Companies where Id=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtid.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            firmaListesi();
            MessageBox.Show("Firma listeden siindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }

        private void BtnGüncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Update Companies set CompanyName=@p1,AuthorizedStatus=@p2,AuthorizedNameSurname=@p3,AuthorizedTc=@p4,Sector=@p5,PhoneNumber=@p6,PhoneNumber2=@p7,PhoneNumber3=@p8,Email=@p9,Fax=@p10,City=@p11,District=@p12,TaxAdministration=@p13,Address=@p14,SpecialCode1=@p15,SpecialCode2=@p16,SpecialCode3=@p17 where Id=@p18",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtAd.Text);
            komut.Parameters.AddWithValue("@p2", txtYetkiliGorev.Text);
            komut.Parameters.AddWithValue("@p3", txtYetkili.Text);
            komut.Parameters.AddWithValue("@p4", mskTc.Text);
            komut.Parameters.AddWithValue("@p5", txtSektor.Text);
            komut.Parameters.AddWithValue("@p6", mskTel1.Text);
            komut.Parameters.AddWithValue("@p7", mskTel2.Text);
            komut.Parameters.AddWithValue("@p8", mskTel3.Text);
            komut.Parameters.AddWithValue("@p9", txtEmail.Text);
            komut.Parameters.AddWithValue("@p10", mskFax.Text);
            komut.Parameters.AddWithValue("@p11", cmbİl.Text);
            komut.Parameters.AddWithValue("@p12", cmbİlce.Text);
            komut.Parameters.AddWithValue("@p13", txtVergi.Text);
            komut.Parameters.AddWithValue("@p14", RchAdres.Text);
            komut.Parameters.AddWithValue("@p15", txtKod1.Text);
            komut.Parameters.AddWithValue("@p16", txtKod2.Text);
            komut.Parameters.AddWithValue("@p17", txtKod3.Text);
            komut.Parameters.AddWithValue("@p18", txtid.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Firma bilgileri güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            firmaListesi();
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if(dr != null)
            {
                txtid.Text = dr["Id"].ToString();
                txtAd.Text = dr["CompanyName"].ToString();
                txtYetkiliGorev.Text = dr["AuthorizedStatus"].ToString();
                txtYetkili.Text = dr["AuthorizedNameSurname"].ToString();
                mskTc.Text = dr["AuthorizedTc"].ToString();
                txtSektor.Text = dr["Sector"].ToString();
                mskTel1.Text = dr["PhoneNumber"].ToString();
                mskTel2.Text = dr["PhoneNumber2"].ToString();
                mskTel3.Text = dr["PhoneNumber3"].ToString();
                txtEmail.Text = dr["Email"].ToString();
                mskFax.Text = dr["Fax"].ToString();
                cmbİl.Text = dr["City"].ToString();
                cmbİlce.Text = dr["District"].ToString();
                txtVergi.Text = dr["TaxAdministration"].ToString();
                RchAdres.Text = dr["Address"].ToString();
                txtKod1.Text = dr["SpecialCode1"].ToString();
                txtKod2.Text = dr["SpecialCode2"].ToString();
                txtKod3.Text = dr["SpecialCode3"].ToString();
            }
        }
    }
}
