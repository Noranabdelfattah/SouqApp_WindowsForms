using SouqApp;
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
    public partial class Form1 : Form
    {

        private UserRepository newuserRep = new UserRepository();

        SouqApp.User newuser = new SouqApp.User();
        public Form1()
        {
            InitializeComponent();
        }

        private void reg_btn_Click(object sender, EventArgs e)
        {
            string name = name_txt.Text;
            string pass = pass_txt.Text;
            string ID = ID_txt.Text;

            newuser.Username = name;
            newuser.Password = pass;
            newuser.UserId = Convert.ToInt32( ID);
            List<SouqApp.User> resList = new List<SouqApp.User> { newuserRep.Add(newuser) };
            newuserRep.Save();
            result_txt.Text = "Succsesfully Add The user " + name + "  " + ID; 

        }

        private void login_btn_Click(object sender, EventArgs e)
        {
            string name = name1_txt.Text;
            string pass = pass1_txt.Text;


            if (newuserRep.Get(name, pass).FirstOrDefault() == null)
            {
                label7.Visible = true;
                label7.Text = "NOT Valid !!!! ";

            }
            else
            {
                label7.Visible = true;
                label7.Text = "Valid ";
                int retid = (newuserRep.Get(name, pass)).FirstOrDefault().UserId;

                profile_form frm = new profile_form(name,Convert.ToString(retid));
            
                frm.Show();

             

                
            }
        }
    }
}
