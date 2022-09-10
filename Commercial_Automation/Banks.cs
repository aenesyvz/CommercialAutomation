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
    public partial class Banks : Form
    {
        public Banks()
        {
            InitializeComponent();
        }
        sqlBaglantisi bgl = new sqlBaglantisi();

        void bankalarListesi()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Execute BankaBilgileri", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
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
        void firmaListesi()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select Id,CompanyName From Companies", bgl.baglanti());
            da.Fill(dt);
            lupFirma.Properties.ValueMember = "Id";
            lupFirma.Properties.DisplayMember = "CompanyName";
            lupFirma.Properties.DataSource = dt;

        }
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if(dr != null)
            {
                txtid.Text = dr["Id"].ToString();
                txtBankaAd.Text = dr["BankName"].ToString();
                cmbİl.Text = dr["İl"].ToString();
                cmbİlce.Text = dr["İlce"].ToString();
                txtSube.Text = dr["Branch"].ToString();
                mskIban.Text = dr["IBAN"].ToString();
                txtHesapNo.Text = dr["AccountNumber"].ToString();
                txtHesapTuru.Text = dr["AccountType"].ToString();
                txtYetkili.Text = dr["Authorized"].ToString();
                mskTel.Text = dr["Telefon"].ToString();
                mskTarih.Text = dr["Tarih"].ToString();
                lupFirma.Text = dr["CompanyId"].ToString();
            }
        }

        void temizle()
        {
            txtid.Text = "";
            txtBankaAd.Text = "";
            cmbİl.Text = "";
            cmbİlce.Text = "";
            txtSube.Text = "";
            mskIban.Text = "";
            txtHesapNo.Text = "";
            txtHesapTuru.Text = "";
            txtYetkili.Text = "";
            mskTel.Text = "";
            mskTarih.Text = "";
            lupFirma.Text = "";
        }
            private void Banks_Load(object sender, EventArgs e)
        {
            bankalarListesi();
            sehirListesi();
            firmaListesi();
            temizle();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into Banks (BankName,Branch,IBAN,AccountNumber,Authorized,Tarih,AccountType,İl,İlce,Telefon,CompanyId) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11)",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1",txtBankaAd.Text);
            komut.Parameters.AddWithValue("@p2", txtSube.Text);
            komut.Parameters.AddWithValue("@p3", mskIban.Text);
            komut.Parameters.AddWithValue("@p4", txtHesapNo.Text);
            komut.Parameters.AddWithValue("@p5", txtYetkili.Text);
            komut.Parameters.AddWithValue("@p6", mskTarih.Text);
            komut.Parameters.AddWithValue("@p7", txtHesapTuru.Text);
            komut.Parameters.AddWithValue("@p8", cmbİl.Text);
            komut.Parameters.AddWithValue("@p9", cmbİlce.Text);
            komut.Parameters.AddWithValue("@p10", mskTel.Text);
            komut.Parameters.AddWithValue("@p11", lupFirma.EditValue);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Banka bilgisi kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            bankalarListesi();
            temizle();
        }

        private void cmbİlce_SelectedIndexChanged(object sender, EventArgs e)
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

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Delete From Banks where Id=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtid.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            temizle();
            MessageBox.Show("Banka bilgisi silindir", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            bankalarListesi();
        }

        private void BtnGüncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Update Banks set BankName=@p1,Branch=@p2,IBAN=@p3,AccountNumber=@p4,Authorized=@p5,Tarih=@p6,AccountType=@p7,İl=@p8,İlce=@p9,Telefon=@p10,CompanyId=@p11 where Id=@p12", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtBankaAd.Text);
            komut.Parameters.AddWithValue("@p2", txtSube.Text);
            komut.Parameters.AddWithValue("@p3", mskIban.Text);
            komut.Parameters.AddWithValue("@p4", txtHesapNo.Text);
            komut.Parameters.AddWithValue("@p5", txtYetkili.Text);
            komut.Parameters.AddWithValue("@p6", mskTarih.Text);
            komut.Parameters.AddWithValue("@p7", txtHesapTuru.Text);
            komut.Parameters.AddWithValue("@p8", cmbİl.Text);
            komut.Parameters.AddWithValue("@p9", cmbİlce.Text);
            komut.Parameters.AddWithValue("@p10", mskTel.Text);
            komut.Parameters.AddWithValue("@p11", lupFirma.EditValue);
            komut.Parameters.AddWithValue("@P12", txtid.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Banka bilgileri güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            bankalarListesi();
            temizle();
        }
    }
}
