using Npgsql;
using System;
using System.Data;
using System.Windows.Forms;

namespace DB_Forms
{
    public partial class Data : Form
    {
        private string selectedTable;
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
                selectedTable = comboBox1.SelectedItem.ToString();
                string selectedDict = comboBox1.SelectedItem.ToString();
                if (selectedDict == "orders") selectedDict = "\"ordersview1\"";
                updateOrdersView();
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

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            var delForm = new deleteForm(dataGridView1, selectedTable);
            delForm.ShowDialog();
        }

        private void createBtn_Click(object sender, EventArgs e)
        {
            if (selectedTable == "orders")
            {
                var creationForm = new CreateOrderForm(dataGridView1, selectedTable);
                creationForm.ShowDialog();
            }
            else if (selectedTable == "services_in_orders")
            {
                var creationForm = new CreateServiceInOrderForm(dataGridView1, selectedTable);
                creationForm.ShowDialog();
            }
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            if (selectedTable == "orders")
            {
                var updateForm = new UpdateOrderForm(dataGridView1, selectedTable);
                updateForm.ShowDialog();
            }
            else if (selectedTable == "services_in_orders")
            {
                var updateForm = new UpdateServiceInOrderForm(dataGridView1, selectedTable);
                updateForm.ShowDialog();
            }
        }
        private void updateOrdersView()
        {
            string sqlQuery = "REFRESH MATERIALIZED VIEW ordersview1\r\n";
            using (var cmd = new NpgsqlCommand(sqlQuery, DataBaseConnection.connection))
            {
                cmd.ExecuteNonQuery();
            }
            
        }
    }
}
