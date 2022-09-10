using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Commercial_Automation
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        Products products;
        private void BtnUrunler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(products == null || products.IsDisposed)
            {
                products = new Products();
                products.MdiParent = this;
                products.Show();
            }
            
        }
        Customers customers;
        private void BtnMusteriler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(customers == null || customers.IsDisposed)
            {
                customers = new Customers();
                customers.MdiParent = this;
                customers.Show();
            }
        }
        public string User;
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        Companies companies;

        private void BtnFirmalar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(companies == null || companies.IsDisposed )
            {
                companies = new Companies();
                companies.MdiParent = this;
                companies.Show();
            }

        }
        Staffs staffs;
        private void BtnPersoneller_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(staffs == null || staffs.IsDisposed )
            {
                staffs = new Staffs();
                staffs.MdiParent = this;
                staffs.Show();
            }
        }
        Guide guide;
        private void BtnRehber_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(guide == null || guide.IsDisposed )
            {
                guide = new Guide();
                guide.MdiParent = this;
                guide.Show();
            }
        }
        Exponses exponses;

        private void BtnGiderler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(exponses == null || exponses.IsDisposed )
            {
                exponses = new Exponses();
                exponses.MdiParent = this;
                exponses.Show();
            }
        }
        Banks banks;
        private void BtnBankalar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(banks == null || banks.IsDisposed )
            {
                banks = new Banks();
                banks.MdiParent = this;
                banks.Show();
            }
        }
        Bills bills;
        private void BtnFaturalar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(bills == null || bills.IsDisposed )
            {
                bills = new Bills();
                bills.MdiParent = this;
                bills.Show();
            }
        }
        Notes notes;
        private void BtnNotlar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(notes == null || notes.IsDisposed )
            {
                notes = new Notes();
                notes.MdiParent = this;
                notes.Show();
            }
        }
        Movements movements;
        private void Movements_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(movements == null || movements.IsDisposed )
            {
                movements = new Movements();
                movements.MdiParent = this;
                movements.Show();
            }
        }
        Stocks stocks;
        private void BtnStoklar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(stocks == null || stocks.IsDisposed )
            {
                stocks = new Stocks();
                stocks.MdiParent = this;
                stocks.Show();
            }
        }
        Settings settings;
        private void BtnAyarlar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(settings == null || settings.IsDisposed )
            {
                settings = new Settings();
                settings.MdiParent = this;
                settings.Show();
            }
        }
        StrongBox strongBox;
        private void BtnKasa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(strongBox == null || strongBox.IsDisposed )
            {
                strongBox = new StrongBox();
                strongBox.Name = User;
                strongBox.MdiParent = this;
                strongBox.Show();
            }
        }
        HomePage homePage;
        private void BtnAnaSayfa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(homePage == null || homePage.IsDisposed )
            {
                homePage = new HomePage();
                homePage.MdiParent = this;
                homePage.Show();
            }
        }
        Reports reports;
        private void Report_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(reports == null || reports.IsDisposed )
            {
                reports = new Reports();
                reports.MdiParent = this;
                reports.Show();
            }
        }
    }
}
