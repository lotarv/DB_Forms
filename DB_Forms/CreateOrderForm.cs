using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DB_Forms
{
    public partial class CreateOrderForm : Form
    {
        private List<Tuple<string, string>> hairdressersList = new List<Tuple<string, string>>();
        private List<Tuple<string, string>> clientsList = new List<Tuple<string, string>>();


        private DataGridView dgv;
        private string tableName;
        public CreateOrderForm(DataGridView dgv, string tableName)
        {
            InitializeComponent();
            this.dgv = dgv;
            this.tableName = tableName;
        }

        private void CreateOrderForm_Load(object sender, EventArgs e)
        {
            statusInput.Items.Add("Выполнен");
            statusInput.Items.Add("Не выполнен");
            fillHairdressers();
            fillClients();
            
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

        private void addOrderBtn_Click(object sender, EventArgs e)
        {
            string id = "default";
            string status = statusInput.SelectedItem.ToString() == "Выполнен" ? "'1'" : "'0'";
            string date = dateInput.Text.ToString() == "default" ? "default" : $"'{dateInput.Text}'";
            string cost = costInput.Text;

            string hairdresser_id = "";
            string client_id = "";

            //Поиск id выбранного парикмахера
            foreach (var hairInfo in hairdressersList)
            {
                if (hairInfo.Item2 == hairdresserInput.SelectedItem.ToString())
                {
                    hairdresser_id = hairInfo.Item1;
                }
            }

            //Поиск id выбранного клиента
            foreach (var clientInfo in clientsList)
            {
                if (clientInfo.Item2 == clientInput.SelectedItem.ToString())
                {
                    client_id = clientInfo.Item1;
                }
            }

            string sqlCommand = $"INSERT INTO orders values ({id}, {hairdresser_id}, {client_id}, {date}, {status}, {cost})";
            
            using (var cmd = new NpgsqlCommand(sqlCommand, DataBaseConnection.connection))
            {
                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Запись успешно добавлена!");
                    Program.refreshTableView(dgv, tableName);
                    this.Close();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }





        }
    }
}
