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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
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
                //DataBaseConnection.OpenConnection(host, port, databaseName, username, password);
                DataBaseConnection.OpenConnection("localhost", "5432", "Barbershop", "postgres", "password");

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

        private void dfdfToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dictForm = new Dict();
            //Проверка на установку соединения
            try
            {
                var connection = DataBaseConnection.connection;
                if (connection.State == ConnectionState.Open)
                {
                    dictForm.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message);
            }
            
        }
    }
}
