using SouqApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Providers.Entities;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class RegistrationForm : System.Web.UI.Page

    {
        private UserRepository newuserRep = new UserRepository();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (RecaptchaControl1.IsValid)
            {
                //submit form success
                lblStatus.Text = "Success";
            }
            else
            {
                //captcha challenge failed
                lblStatus.Text = "Captcha Failed!! Please try again!!";
            }
           string name = user_name_txt.Text;
            string pass = pass_txt.Text;

            SouqApp.User newuser = new SouqApp.User();
            newuser.Username = name;
            newuser.Password = pass;
            List<SouqApp.User> resList=new List<SouqApp.User> { newuserRep.Add(newuser) };
            newuserRep.Save();

            gv_result.DataSource = resList;
            gv_result.DataBind();

            

        }
    }
}