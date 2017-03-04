using System;

using System.IO; // File.Exists()

using NPOI.XSSF.UserModel; // XSSFWorkbook, XSSFSheet

namespace WebApplication1
{
    public partial class ImportFromExcelUsingNPOI : System.Web.UI.Page
    {
        XSSFWorkbook wb;
        XSSFSheet sh;

        protected void Page_Load(object sender, EventArgs e)
        {
          
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            
            using (FileStream file = new FileStream(@"E:/Technovil/Managers.xlsx", FileMode.Open, FileAccess.Read))
            {
          
                wb=new  XSSFWorkbook(file);
            }
            sh = (XSSFSheet)wb.GetSheet("Sheet1");
         
            dataGridView1.DataSource = sh.GetTables();
            dataGridView1.DataBind();

        }
    }
}