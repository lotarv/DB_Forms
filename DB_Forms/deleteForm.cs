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
    public partial class deleteForm : Form
    {
        private static DataGridView dgv;
        private static string tableName;
        string idToDelete = "";
        public deleteForm(DataGridView view, string tname)
        {
            InitializeComponent();
            dgv = view;
            tableName = tname;

        }

        private void deleteForm_Load(object sender, EventArgs e)
        {
            

            label1.Text = "Вы собираетесь удалить следующую запись:";
            string message = "";
            //Получение id необходимого для удаления
            
            foreach(DataGridViewCell cell in dgv.SelectedCells)
            {
                if (idToDelete == "")
                {
                    idToDelete = cell.Value.ToString();
                }
                message += cell.Value.ToString() + " ";
            }
            label2.Text = message;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void noBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void yesBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string commandText = $"DELETE FROM {tableName} WHERE id = {idToDelete}";
                using (var delCommand = new NpgsqlCommand(commandText, DataBaseConnection.connection))
                {
                    delCommand.ExecuteNonQuery();
                    MessageBox.Show("Запись удалена успешно");
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
