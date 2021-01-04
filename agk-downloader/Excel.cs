using System;
using System.IO;
using System.Data;

using ExcelDataReader;
//using SpreadsheetLight;
using System.Windows.Forms;

namespace agk_downloader
{
    public class Excel
    {
        private string rutaArchivo = AppDomain.CurrentDomain.BaseDirectory + @"\Referencia.xlsx";

        public Excel() { }

        public Tuple<int, object> LeerArchivo(string archivo)
        {
            try
            {
                using (var stream = File.Open(archivo, FileMode.Open, FileAccess.Read))
                {
                    using (var reader = ExcelReaderFactory.CreateReader(stream))
                    {
                        var result = reader.AsDataSet();
                        DataTable table = result.Tables[0];

                        return new Tuple<int, object>(1, table);
                    }
                }
            }
            catch (Exception e)
            {
                return new Tuple<int, object>(0, "Error al leer el archivo: " + Environment.NewLine + e.Message);
            }
        }

        public Tuple<int, object> ExportaReferencia(ListView listView)
        {
            try
            {
                if (listView.Items.Count > 0)
                {
                    //DataTable dataTable = new DataTable();
                    //dataTable.Columns.Add("Cliente", typeof(int));
                    //dataTable.Columns.Add("Referencia", typeof(string));
                    //dataTable.Columns.Add("Documento", typeof(string));
                    //dataTable.Columns.Add("Archivo", typeof(string));

                    //for (int i = 0; i < listView.Items.Count - 1; i++)
                    //{
                    //    DataRow row = dataTable.NewRow();
                    //    row["Cliente"] = listView.Items[i].SubItems[0].Text;
                    //    row["Referencia"] = listView.Items[i].SubItems[1].Text;
                    //    row["Documento"] = listView.Items[i].SubItems[2].Text;
                    //    row["Archivo"] = listView.Items[i].SubItems[3].Text;

                    //    dataTable.Rows.Add(row);
                    //}

                    //SLDocument slDoc = new SLDocument();
                    //slDoc.ImportDataTable(1, 1, dataTable, true);

                    //SLStyle style = slDoc.CreateStyle();
                    //style.Font.Bold = true;
                    //slDoc.SetRowStyle(1, style);

                    //SLTable table = slDoc.CreateTable(1, 1, dataTable.Rows.Count, 4);
                    //table.SetTableStyle(SLTableStyleTypeValues.Medium17);
                    //table.HasTotalRow = true;
                    //table.SetTotalRowFunction(5, SLTotalsRowFunctionValues.Sum);
                    //slDoc.InsertTable(table);

                    ////Guardar como, y aqui ponemos la ruta de nuestro archivo
                    //slDoc.SaveAs(rutaArchivo);

                    Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
                    Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
                    Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
                    app.Visible = false;
                    //worksheet = workbook.Sheets["Hoja1"];
                    //worksheet = workbook.ActiveSheet;
                    worksheet.Name = "Referencia";

                    worksheet.Cells[1, 1] = "Cliente";
                    worksheet.Cells[1, 2] = "Referencia";
                    worksheet.Cells[1, 3] = "Documento";
                    worksheet.Cells[1, 4] = "Archivo";

                    for (int i = 0; i < listView.Items.Count - 1; i++)
                    {
                        for (int j = 0; j < 4; j++)
                        {
                            worksheet.Cells[i + 2, j + 1] = listView.Items[i].SubItems[j].Text.ToString();
                        }
                    }

                    workbook.SaveAs(rutaArchivo, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal);
                    workbook.Close(true);
                    app.Quit();

                    return new Tuple<int, object>(1, "OK");
                }
                else
                {
                    return new Tuple<int, object>(0, "Sin datos que exportar");
                }
            }
            catch (Exception ex)
            {
                return new Tuple<int, object>(0, "Ocurrio una Excepción: " + ex.Message);
            }
        }
    }
}
