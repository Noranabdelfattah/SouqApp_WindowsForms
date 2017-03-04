using System;
using System.Drawing;
using SouqApp;
using System.Linq;

/* For I/O purpose */
using System.IO;
//
using System.Data;
using System.Web.UI.WebControls;
/* To work eith EPPlus library */
using OfficeOpenXml;
using OfficeOpenXml.Style;
//

/* For Diagnostics */
using System.Diagnostics;
using OfficeOpenXml.Drawing;

namespace WebApplication1
{
    public partial class DataToExcel : System.Web.UI.Page
    {
        private UserRepository newuser = new UserRepository();
        DataTable theTable;
        DataTable productsTable;
        

        protected void Page_Load(object sender, EventArgs e)
        {
            var collection = newuser.Get();
            var collection2 = newuser.GetProducts();
            if (!IsPostBack) {
            
                GridView1.DataSource = collection.ToList();
                GridView1.DataBind();
            }
            theTable = (from x in collection select x).ToDataTable<User>();
            productsTable= (from x in collection select x).ToDataTable();
        }

        private void DumpExcel(DataTable tbl , DataTable tb2)

        {
            using (ExcelPackage pck = new ExcelPackage())
            {
                //Create the worksheet
                ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Users");
                ExcelWorksheet ws2 = pck.Workbook.Worksheets.Add("Products");
                //Load the datatable into the sheet, starting from cell A1. Print the column names on row 1

                ws.Cells["A1"].LoadFromDataTable(tbl, true);
                ws2.Cells["A1"].LoadFromDataTable(tb2,true);
            
                //Cell Font 
                ws.Cells.Style.Font.SetFromFont(new Font("Calibri", 12));

                //Cell background Color
                var fill = ws.Cells.Style.Fill;
                fill.PatternType = ExcelFillStyle.Solid;
                fill.BackgroundColor.SetColor(Color.LightPink); 

                //Cell Border 
                var border = ws.Cells.Style.Border; 
                border.Top.Style = border.Left.Style = border.Bottom.Style = border.Right.Style 
                                 = ExcelBorderStyle.DashDot;
                //
                ws.Cells.AutoFitColumns();

                //Format the header for column 1-3
                using (ExcelRange rng = ws.Cells["A1:C1"])
                {
                    rng.Style.Font.Bold = false;
                    rng.Style.Fill.PatternType = ExcelFillStyle.Solid;   //Set Pattern for the background to Solid
                    rng.Style.Fill.BackgroundColor.SetColor(Color.LightGreen);  //Set color to 
                    rng.Style.Font.Color.SetColor(Color.Black);
                }

                var cell = ws.Cells[2, 1];

                //Setting Sum Formula for each cell  // Usage: Sum(From_Addres:To_Address)
                // e.g. - Sum(A2:A5) -> Sums the value of Column 'A' From Row 2 to Row 5
                cell.Formula = "Sum(" + ws.Cells[2, 1].Address + ":" + ws.Cells[5, 1].Address + ")";

                //Add Image 
           

                AddImage(ws,10,1, "C:/Users/Noran/Documents/Visual Studio 2015/Projects/SouqApp/WebApplication1/Images/img.jpg");


                //Merge Excel Columns: Merging cells and create a center heading for our table
                ws.Cells[1, 1].Value = "Sample DataTable Export";
                ws.Cells[1, 1, 1, theTable.Columns.Count].Merge = true;

                //Write it back to the client    

                if (File.Exists("E:/Technovil/Users.xlsx"))
                    File.Delete("E:/Technovil/Users.xlsx");

                //Create excel file on physical disk    
                FileStream objFileStrm = File.Create("E:/Technovil/Users.xlsx");
                objFileStrm.Close();

                //Write content to excel file    
                File.WriteAllBytes("E:/Technovil/Users.xlsx", pck.GetAsByteArray());

                Label1.Text = "File successfully downloaded";


            }
        }

       

        private void AddImage(ExcelWorksheet oSheet, int rowIndex, int colIndex, string imagePath)
        {
            Bitmap image = new Bitmap(imagePath);
            ExcelPicture excelImage = null;
            if (image != null)
            {
                excelImage = oSheet.Drawings.AddPicture("Debopam Pal", image);
                excelImage.From.Column = colIndex;
                excelImage.From.Row = rowIndex;
                excelImage.SetSize(100, 100);
                // 2x2 px space for better alignment
                excelImage.From.ColumnOff = Pixel2MTU(2);
                excelImage.From.RowOff = Pixel2MTU(2);
            }
        }

        public int Pixel2MTU(int pixels)
        {
            int mtus = pixels * 9525;
            return mtus;
        }
        protected void btnExportToExcel_Click(object sender, EventArgs e)
        {
            DumpExcel(theTable , productsTable);
     
        }


    }
}