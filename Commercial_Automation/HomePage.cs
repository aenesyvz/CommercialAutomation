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
using System.Xml;

namespace Commercial_Automation
{
    public partial class HomePage : Form
    {
        public HomePage()
        {
            InitializeComponent();
        }
        sqlBaglantisi bgl = new sqlBaglantisi();
        void stoklar()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select ProductName,Sum(UnitsInStock) From Products group by ProductName having Sum(UnitsInStock) <= 20 order by Sum(UnitsInStock)", bgl.baglanti());
            da.Fill(dt);
            gridControlStoklar.DataSource = dt;
        }

        void ajanda()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select top 8 NoteDate,NoteTime,NoteTitle from Notes order by Id desc",bgl.baglanti());
            da.Fill(dt);
            gridControlAjanda.DataSource = dt;
        }

        void hareketler()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Exec Movement", bgl.baglanti());
            da.Fill(dt);
            gridControlHareket.DataSource = dt;
        }

        void fihrist()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select CompanyName,PhoneNumber from Companies", bgl.baglanti());
            da.Fill(dt);
            gridControlFihrist.DataSource = dt;
        }

       
        private void HomePage_Load(object sender, EventArgs e)
        {
            stoklar();
            ajanda();
            hareketler();
            fihrist();
        }
    }
}
