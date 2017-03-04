using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        //postback event
        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Write("Button clicked " + "<br/>");
        }
        //cashed event till enabling postback property => psotback
        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {
            Response.Write("Text Clicked " + "<br/>");
        }
    }
}