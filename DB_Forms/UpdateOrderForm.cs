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
    public partial class UpdateOrderForm : Form
    {
        private List<Tuple<string, string>> hairdressersList = new List<Tuple<string, string>>();
        private List<Tuple<string, string>> clientsList = new List<Tuple<string, string>>();
        private DataGridView dgv;
        private string tableName;
        private List<string> fields = new List<string>();
        public UpdateOrderForm(DataGridView dgv, string tableName)
        {
            InitializeComponent();
            this.dgv = dgv;
            this.tableName = tableName;
        }

        private void UpdateOrderForm_Load(object sender, EventArgs e)
        {
            statusInput.Items.Add("Выполнен");
            statusInput.Items.Add("Не выполнен");
            fillClients();
            fillHairdressers();
            fillFields();
        }

        private void fillClients()
        {
            string sqlCommand = "SELECT id, name from clients";
            using (var cmd = new NpgsqlCommand(sqlCommand, DataBaseConnection.connection))
            {
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string id = reader.GetInt16(0).ToString();
                        string name = reader.GetString(1);
                        clientsList.Add(new Tuple<string, string>(id, name));
                        clientInput.Items.Add(name);
                    }
                }
            }
        }

        private void fillHairdressers()
        {
            string sqlCommand = "SELECT id, fullname from hairdressers";
            using (var cmd = new NpgsqlCommand(sqlCommand, DataBaseConnection.connection))
            {
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string id = reader.GetInt16(0).ToString();
                        string fullname = reader.GetString(1);
                        hairdressersList.Add(new Tuple<string, string>(id, fullname));
                        hairdresserInput.Items.Add(fullname);
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

            string selectedHairdresser_id = fields[1];
            string selectedClient_id = fields[2];
            string selectedDate = fields[3];
            string selectedStatus = fields[4];
            string selectedCost = fields[5];
            Console.WriteLine(selectedStatus);
            costInput.Text = selectedCost;
            dateInput.Text = selectedDate;
            statusInput.SelectedItem = selectedStatus == "True" ? "Выполнен" : "Не выполнен";

            foreach (var hairInfo in hairdressersList)
            {
                if (hairInfo.Item1 == selectedHairdresser_id)
                {
                    hairdresserInput.SelectedItem = hairInfo.Item2;
                }
            }

            foreach(var clientInfo in clientsList)
            {
                if (clientInfo.Item1 == selectedClient_id)
                {
                    clientInput.SelectedItem = clientInfo.Item2;
                }
            } 
        }

        private void updateOrderBtn_Click(object sender, EventArgs e)
        {
            string newHairdresser_id = "";
            string newClient_id = "";
            string newCost = costInput.Text;
            string newDate = dateInput.Text;
            string newStatus = statusInput.SelectedItem.ToString() == "Выполнен" ? "1": "0";

            foreach (var hairInfo in hairdressersList)
            {
                if (hairInfo.Item2 == hairdresserInput.SelectedItem.ToString())
                {
                    newHairdresser_id = hairInfo.Item1;
                }
            }

            foreach (var clientInfo in clientsList)
            {
                if (clientInfo.Item2 == clientInput.SelectedItem.ToString())
                {
                    newClient_id = clientInfo.Item1;
                }
            }
            //newDate = newDate.Replace('.', '-');
            string sqlQuery = $"UPDATE orders SET hairdresser_id = {newHairdresser_id}, client_id = {newClient_id}, cost = {newCost}, form_date = '{newDate}', status = '{newStatus}' WHERE id = {fields[0]}";
            Console.WriteLine(sqlQuery);
            
            using (var cmd = new NpgsqlCommand(sqlQuery, DataBaseConnection.connection))
            {
                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Изменения успешно внесены");
                    Program.refreshTableView(dgv,tableName);
                    this.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }


        }
    }
}
