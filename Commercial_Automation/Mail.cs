using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;

namespace Commercial_Automation
{
    public partial class Mail : Form
    {
        public Mail()
        {
            InitializeComponent();
        }
        public string mail;
        private void Mail_Load(object sender, EventArgs e)
        {
            txtMail.Text = mail;
        }

        private void BtnGonder_Click(object sender, EventArgs e)
        {
            MailMessage mesaj = new MailMessage();
            SmtpClient istemci = new SmtpClient();
            istemci.Credentials = new System.Net.NetworkCredential("Mail", "Şifre");
            istemci.Port = 587;
            istemci.Host = "smtp.live.com";
            istemci.EnableSsl = true;
            mesaj.To.Add(RchMesaj.Text);
            mesaj.From = new MailAddress("Mail");
            mesaj.Subject = txtKonu.Text;
            mesaj.Body = RchMesaj.Text;
            istemci.Send(mesaj);
        }
    }
}
