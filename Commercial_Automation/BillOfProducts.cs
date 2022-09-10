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
    public partial class BillOfProducts : Form
    {
        public BillOfProducts()
        {
            InitializeComponent();
        }

        public string id;
        sqlBaglantisi bgl = new sqlBaglantisi();

        void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From BillDetails where BillId='"+id+"'",bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }
        private void BillOfProducts_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            BillOfProductLayout billOfProductLayout = new BillOfProductLayout();
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if(dr != null)
            {
                billOfProductLayout.urunId = dr["Id"].ToString();
            }
            billOfProductLayout.Show();
        }
    }
}
