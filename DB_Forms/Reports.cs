using Npgsql;
using System;
using System.Data;
using System.Security.AccessControl;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DB_Forms
{
    public partial class Reports : Form
    {
        int pageSize = 5; // Количество записей на странице
        int currentPage = 1; // Текущая страница
        public Reports()
        {
            InitializeComponent();
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            createBtn.Enabled = false;
            updateBtn.Enabled = false;
            deleteBtn.Enabled = false;

            textBox1.ReadOnly = true;
            textBox1.TextAlign = HorizontalAlignment.Center;

        }

        private void Reports_Load(object sender, EventArgs e)
        {
            
        }

        private void showReport()
        {

            string sqlQuery = $"SELECT * FROM blackbox LIMIT {pageSize} OFFSET {(currentPage - 1) * pageSize}";
            using (var cmd = new NpgsqlCommand(sqlQuery, DataBaseConnection.connection))
            {
                using (var reader = cmd.ExecuteReader())
                {
                    var dt = new DataTable();
                    dt.Load(reader);
                    dataGridView1.DataSource = dt;
                    textBox1.Text = currentPage.ToString();
                }
            }
        }

        private void readBtn_Click(object sender, EventArgs e)
        {
            showReport();
        }

        private void prevPageBtn_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
            }
            else
            {
                return;
            }
            showReport(); // Перезагрузка данных с новым номером страницы
        }

        private void nextPageBtn_Click(object sender, EventArgs e)
        {
            currentPage++;
            showReport(); // Перезагрузка данных с новым номером страницы
        }
    }
}
