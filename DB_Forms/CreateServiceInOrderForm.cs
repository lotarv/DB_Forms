using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DB_Forms
{
    public partial class CreateServiceInOrderForm : Form
    {
        private DataGridView dgv;
        private string tableName;
        private List<Tuple<string, string>> services = new List<Tuple<string, string>>();
        public CreateServiceInOrderForm(DataGridView dgv, string tableName)
        {
            InitializeComponent();
            this.dgv = dgv;
            this.tableName = tableName;
        }

        private void CreateServiceInOrderForm_Load(object sender, EventArgs e)
        {
            fillServices();
        }
        private void fillServices()
        {
            Console.WriteLine("kek");
            string sqlQuery = "SELECT id, name FROM services";
            using (var cmd = new NpgsqlCommand(sqlQuery, DataBaseConnection.connection))
            {
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string id = reader.GetInt16(0).ToString();
                        string name = reader.GetString(1);
                        Console.WriteLine(id);
                        Console.WriteLine(name);
                        services.Add(new Tuple<string, string>(id, name));
                        serviceInput.Items.Add(reader.GetString(1));
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string order_id = order_idInput.Text;
            string service_id = "";
            //Поиск id услуги
            foreach (var service in services)
            {
                if (service.Item2 == serviceInput.SelectedItem.ToString())
                {
                    service_id = service.Item1;
                }
            }

            try
            {
                string sqlQuery = $"insert into services_in_orders values ({order_id}, {service_id})";
                using (var cmd = new NpgsqlCommand(sqlQuery, DataBaseConnection.connection))
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Запись успешно добавлена");
                    Program.refreshTableView(dgv, tableName);
                    this.Close();

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
