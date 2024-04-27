using System;
using System.Data;

using System.Windows.Forms;
namespace DB_Forms
{
    public partial class DB_Forms : Form
    {
        public DB_Forms()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox4.PasswordChar = '*';
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string host = textBox1.Text;
            string port = textBox2.Text;
            string username = textBox3.Text;
            string password = textBox4.Text;
            string databaseName = textBox5.Text;
            try
            {
                DataBaseConnection.OpenConnection(host, port, databaseName, username, password);
                //DataBaseConnection.OpenConnection("localhost", "5432", "Barbershop", "postgres", "password");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        //Menu -> Справочники
        private void dfdfToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dictForm = new Dict();
            //Проверка на установку соединения
            try
            {
                var connection = DataBaseConnection.connection;
                if (connection.State == ConnectionState.Open)
                {
                    dictForm.ShowDialog();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error: connection is not set");
            }
            
        }
        //Menu -> Данные
        private void dfdfToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var DataForm = new Data();
            //Проверка на установку соединения
            try
            {
                var connection = DataBaseConnection.connection;
                if (connection.State == ConnectionState.Open)
                {
                    DataForm.ShowDialog();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error: connection is not set");
            }
        }

        private void отчетыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var ReportForm = new Reports();
            //Проверка на установку соединения
            try
            {
                var connection = DataBaseConnection.connection;
                if (connection.State == ConnectionState.Open)
                {
                    ReportForm.ShowDialog();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error: connection is not set");
            }
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var AboutForm = new About();
            AboutForm.ShowDialog();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void экспортToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var exportForm = new exportForm();
            exportForm.ShowDialog();
        }
    }
}
