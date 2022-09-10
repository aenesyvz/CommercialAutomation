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
    public partial class NoteDetail : Form
    {
        public NoteDetail()
        {
            InitializeComponent();
        }
        public string note;
        private void NoteDetail_Load(object sender, EventArgs e)
        {
            richTextBox1.Text = note;
        }
    }
}
