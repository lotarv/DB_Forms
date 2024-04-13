using Npgsql;
using System;
using System.Data;
using System.Windows.Forms;

namespace DB_Forms
{
    public partial class Reports : Form
    {
        public Reports()
        {
            InitializeComponent();
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }

        private void Reports_Load(object sender, EventArgs e)
        {
            using (var connection = DataBaseConnection.connection)
            {
                using (var cmd = new NpgsqlCommand("select * from blackbox", connection))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        var dt = new DataTable();
                        dt.Load(reader);
                        dataGridView1.DataSource = dt;
                    }
                }
            }
        }
    }
}
