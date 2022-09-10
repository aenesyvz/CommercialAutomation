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
    public partial class Movements : Form
    {
        public Movements()
        {
            InitializeComponent();
        }
        sqlBaglantisi bgl = new sqlBaglantisi();
        void firmaHareketleri()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Exec CompanyMovement",bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }
        void musteriHareketleri()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Exec CustomerMovement", bgl.baglanti());
            da.Fill(dt);
            gridControl2.DataSource = dt;
        }
        private void Movements_Load(object sender, EventArgs e)
        {
            firmaHareketleri();
            musteriHareketleri();
        }
    }
}
