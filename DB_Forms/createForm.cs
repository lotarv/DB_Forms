using Npgsql;
using System;
using System.Windows.Forms;

namespace DB_Forms
{
    public partial class createForm : Form
    {
        public createForm(string tableName)
        {
            InitializeComponent();
            showCreationInfo(tableName);
        }

        private void createForm_Load(object sender, EventArgs e)
        {
            
        }

        private void showCreationInfo(string tableName)
        {
            using (var connection = DataBaseConnection.connection)
            {
                using (var cmd = new NpgsqlCommand($"SELECT column_name FROM information_schema.columns WHERE table_name = {tableName}", connection))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            textBox1.AppendText(reader.GetString(0));
                        }
                    }
                }
            }
        }
    }
}
