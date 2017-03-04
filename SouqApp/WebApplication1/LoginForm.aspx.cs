using SouqApp;
using System;
using System.Linq;

namespace WebApplication1
{
    public partial class WebForm1 : System.Web.UI.Page
    { 
        private UserRepository newuser = new UserRepository();
          
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string name = user_name_txt.Text;
            string pass = pass_txt.Text;
       

            if (newuser.Get(name, pass).FirstOrDefault()==null) {
                Label3.Text = "NOT Valid !!!! ";

            }
            else {
                
                Label3.Text = "Valid ";
            }
          
           


        }

        
    }
}