using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DB_Forms
{
    public partial class UpdateServiceInOrderForm : Form
    {
        private DataGridView dgv;
        private string tableName;
        public UpdateServiceInOrderForm(DataGridView dgv, string tableName)
        {
            InitializeComponent();
            this.dgv = dgv;
            this.tableName = tableName;
        }

        private void UpdateServiceInOrderForm_Load(object sender, EventArgs e)
        {
            fillServices();
        }

        private void fillServices()
        {
            Console.WriteLine("kek");
            string sqlQuery = "SELECT name FROM services";
            using (var cmd = new NpgsqlCommand(sqlQuery, DataBaseConnection.connection))
            {
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine(reader.GetString(0));
                    }
                }
            }
        }
    }
}
