using Npgsql;
using System;
using System.Data;
using System.Windows.Forms;

namespace DB_Forms
{
    public partial class Data : Form
    {
        public Data()
        {
            InitializeComponent();
        }

        private void Data_Load(object sender, EventArgs e)
        {
            //Заполнение combobox
            comboBox1.Items.Add("orders");
            comboBox1.Items.Add("services_in_orders");

            comboBox1.SelectedIndexChanged += comboBoxData_SelectedIndexChanged;


            //Задание параметров для блока с таблицей
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }

        private void comboBoxData_SelectedIndexChanged(Object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                string selectedDict = comboBox1.SelectedItem.ToString();
                using (var cmd = new NpgsqlCommand($"SELECT * FROM {selectedDict}", DataBaseConnection.connection))
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
