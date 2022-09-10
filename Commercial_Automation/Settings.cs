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
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }
        sqlBaglantisi bgl = new sqlBaglantisi();

        void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From Admin", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
     
        }
        void temizle()
        {
            txtUserName.Text = "";
            txtPassword.Text = "";
        }
        private void Settings_Load(object sender, EventArgs e)
        {
            listele();
            temizle();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            if(BtnKaydet.Text == "Kaydet")
            {
                SqlCommand komut = new SqlCommand("insert into Admin values (@p1,@p2)", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", txtUserName.Text);
                komut.Parameters.AddWithValue("@p2", txtPassword.Text);
                komut.ExecuteNonQuery();
                MessageBox.Show("Kullanıcı eklendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listele();
                bgl.baglanti().Close();
            }
            if(BtnKaydet.Text == "Güncelle"){
                SqlCommand komut2 = new SqlCommand("Update Admin set Password=@p2 where UserName=@p1", bgl.baglanti());
                komut2.Parameters.AddWithValue("@p1", txtUserName.Text);
                komut2.Parameters.AddWithValue("@p2", txtPassword.Text);
                komut2.ExecuteNonQuery();
                MessageBox.Show("Kayıt güncellendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listele();
                bgl.baglanti().Close();
            }
            

        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if(dr != null)
            {
                txtUserName.Text = dr["UserName"].ToString();
                txtPassword.Text = dr["Password"].ToString();

            }
        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {
            if(txtUserName.Text != "")
            {
                BtnKaydet.Text = "Güncelle";
            }
            else
            {
                BtnKaydet.Text = "Kaydet";
            }
        }
    }
}
