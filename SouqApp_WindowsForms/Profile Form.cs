using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SouqApp_WindowsForms
{
    public partial class profile_form : Form
    {
        public profile_form(string strname , string strID)
        {
            InitializeComponent();
            label3.Text = strname;
            label4.Text = strID; 
        }

        private void profile_form_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
