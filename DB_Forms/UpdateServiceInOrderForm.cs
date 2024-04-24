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
        private List<string> fields = new List<string>();
        private List<Tuple<string, string>> services = new List<Tuple<string, string>>();
        public UpdateServiceInOrderForm(DataGridView dgv, string tableName)
        {
            InitializeComponent();
            this.dgv = dgv;
            this.tableName = tableName;
        }

        private void UpdateServiceInOrderForm_Load(object sender, EventArgs e)
        {
            fillServices();
            fillFields();
        }

        private void fillServices()
        {
            string sqlQuery = "SELECT id, name FROM services";
            using (var cmd = new NpgsqlCommand(sqlQuery, DataBaseConnection.connection))
            {
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string id = reader.GetInt16(0).ToString();
                        string name = reader.GetString(1);
                        services.Add(new Tuple<string, string>(id, name));
                        serviceInput.Items.Add(reader.GetString(1));
                    }
                }
            }
        }
        private void fillFields()
        {
            foreach(DataGridViewCell cell in dgv.SelectedCells)
            {
                fields.Add(cell.Value.ToString());
            }
            order_idInput.Text = fields[0];

            //поиск выбранной услуги

            using (var command = new NpgsqlCommand("SELECT id, name FROM services", DataBaseConnection.connection))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (fields[1] == reader.GetInt16(0).ToString())
                        {
                            serviceInput.SelectedItem = reader.GetString(1);
                        }
                    }
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string NewOrder_id = order_idInput.Text;
            string NewService_id = "";

            foreach(var service in services)
            {
                if (service.Item2 == serviceInput.SelectedItem.ToString())
                {
                    NewService_id = service.Item1;
                    break;
                }
            }

            try
            {
                string sqlCommand = $"UPDATE services_in_orders SET order_id = {NewOrder_id}, service_id = {NewService_id} WHERE id = {fields[2]}";
                using (var command = new NpgsqlCommand(sqlCommand, DataBaseConnection.connection))
                {
                    command.ExecuteNonQuery();
                    MessageBox.Show("Изменения успешно внесены!");
                    Program.refreshTableView(dgv, tableName);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
