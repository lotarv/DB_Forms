using System;
using Npgsql;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;

namespace DB_Forms
{
    public class DataBaseConnection
    {
        public static NpgsqlConnection connection;
        public static void OpenConnection(string host, string port, string db_name, string username, string pass)
        {
            string connectionString = $"Host={host};Port={port};Database = {db_name}; User Id = {username};Password = {pass}";
            connection = new NpgsqlConnection(connectionString);
            connection.Open();
            if (connection.State == ConnectionState.Open)
            {
                MessageBox.Show("connected");
            }
            else
            {
                MessageBox.Show("Not connected");
            }
        }

        public static void CloseConnection()
        {
            connection.Close();
        }

    }
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
        public static void printToTextBox(string message, TextBox tb)
        {
            tb.Text = message;
        }

    }
}
