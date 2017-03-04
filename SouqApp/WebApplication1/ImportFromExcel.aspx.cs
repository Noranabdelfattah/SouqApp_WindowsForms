using System;
using System.IO;
using Excel;
using System.Data;

namespace WebApplication1
{
    public partial class ImportFromExcel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

 
    protected void btn_Import_Click(object sender, EventArgs e)
        {
            FileStream stream = File.Open("E:/Technovil/Managers.xls", FileMode.Open, FileAccess.Read);

            // Reading from a OpenXml Excel file (2007 format; *.xlsx)
            IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
            //...
            // DataSet - The result of each spreadsheet will be created in the result.Tables
            // DataSet - Create column names from first row
            excelReader.IsFirstRowAsColumnNames = true;
            DataSet result = excelReader.AsDataSet();

            //5. Data Reader methods
            while (excelReader.Read())
            {
               excelReader.GetString(0);
            }

            //6. Free resources (IExcelDataReader is IDisposable)
            excelReader.Close();

            //Show in GridView
            gv.DataSource = result;
            gv.DataBind();


        }
    }
}