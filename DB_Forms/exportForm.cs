using Npgsql;
using System;
using OfficeOpenXml;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DB_Forms
{
    public partial class exportForm : Form
    {

        public exportForm()
        {
            InitializeComponent();
        }

        private void exportForm_Load(object sender, EventArgs e)
        {

        }

        private void exportBtn_Click(object sender, EventArgs e)
        {
            string selectedView = "";
            string selectedExport = "";
            if (blackboxCheck.Checked)
            {
                selectedView = "blackbox";
            }
            else if (ordersviewCheck.Checked)
            {
                selectedView = "ordersview1";
            }

            if (excelRadio.Checked) //Эскпорт в Excel
            {
                try
                {
                    exportToExcel(selectedView);
                    MessageBox.Show("Данные успешно экспортированы");
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            else if (htmlRadio.Checked)
            {
                exportToHTML(selectedView);
                MessageBox.Show("Данные успешно экспортированы");
                this.Close();
            }

            else
            {
                MessageBox.Show("Пожалуйста, выберите формат экспорта");
            }



        }

        private void exportToExcel(string selectedView)
        {
            string sqlQuery = $"SELECT * FROM {selectedView}";
            using (var cmd = new NpgsqlCommand(sqlQuery, DataBaseConnection.connection))
            {
                using (var dataAdapter = new NpgsqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    dataAdapter.Fill(dt);

                    ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

                    //Создание Excel файла и заполнение его данными

                    string filePath = "C:\\Users\\Sergey\\OneDrive\\КубГУ\\2 курс\\4 семестр\\КАиСД\\лабы\\lab10\\ExportedData.xlsx";
                    FileInfo fi = new FileInfo(filePath);

                    using (ExcelPackage excel = new ExcelPackage(fi))
                    {
                        ExcelWorksheet ws = excel.Workbook.Worksheets.Add("Sheet1");
                        ws.Cells["A1"].LoadFromDataTable(dt, true);

                        int dateColumn; // Индексация начинается с 1
                        int rowCount = dt.Rows.Count;
                        Console.WriteLine(rowCount);
                        if (selectedView == "ordersview1") dateColumn = 4;
                        else dateColumn = 5;
                        for (int row = 1; row <= rowCount; row++)
                        {
                            if (dt.Rows[row - 1][dateColumn - 1] is DateTime)
                            {
                                ws.Cells[row, dateColumn].Style.Numberformat.Format = "dd/MM/yyyy";
                            }
                        }
                        excel.Save();
                    }

                }
            }
        }

        private void exportToHTML(string selectedView)
        {
            string sqlQuery = $"SELECT * FROM {selectedView}";
            using (var cmd = new NpgsqlCommand(sqlQuery, DataBaseConnection.connection))
            {
                using (var dataAdapter = new NpgsqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    dataAdapter.Fill(dt);

                    //Создание html страницы
                    StringBuilder htmlContent = new StringBuilder();
                    htmlContent.Append("<html><body><table border='1'>");

                    //Заголовки таблицы
                    htmlContent.Append("<tr>");
                    foreach(DataColumn column in dt.Columns)
                    {
                        htmlContent.Append("<th>").Append(column.ColumnName).Append("</th>");
                    }
                    htmlContent.Append("</tr>");

                    // Данные таблицы
                    foreach (DataRow row in dt.Rows)
                    {
                        htmlContent.Append("<tr>");
                        foreach (var item in row.ItemArray)
                        {
                            htmlContent.Append("<td>").Append(item).Append("</td>");
                        }
                        htmlContent.Append("</tr>");
                    }

                    //Сохранение HTML-страницы в файл
                    File.WriteAllText("C:\\Users\\Sergey\\OneDrive\\КубГУ\\2 курс\\4 семестр\\КАиСД\\лабы\\lab10\\ExportedData.html", htmlContent.ToString());
                }
            }
        }
    }
}
