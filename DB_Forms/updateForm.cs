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
    public partial class updateForm : Form
    {
        private string tableName;
        static List<Tuple<Label, TextBox>> fieldList = new List<Tuple<Label, TextBox>>();
        private DataGridView dgv;

        public updateForm(DataGridView dgv, string tname)
        {
            InitializeComponent();
            tableName = tname;
            this.dgv = dgv;
        }

        private void updateForm_Load(object sender, EventArgs e)
        {
            showUpdateInfo();
        }
        private void showUpdateInfo()
        {
            List<string> Selectedvalues = new List<string>();
            foreach (DataGridViewCell cell in dgv.SelectedCells)
            {
                Selectedvalues.Add(cell.Value.ToString());
            }
            Console.WriteLine("AMount of selectedItems: " + Selectedvalues.Count);

            int labelWidth = 75;
            int textBoxWidth = 100;
            int spacing = 10;
            int currentY = 20;
            var connection = DataBaseConnection.connection;
            //сначала создать форму, потом считать и внести данные
            using (var cmd = new NpgsqlCommand($"SELECT column_name FROM information_schema.columns WHERE table_name = '{tableName}' ORDER BY ordinal_position", connection))
            {
                using (var reader = cmd.ExecuteReader())
                {
                    int i = 0;
                    while (reader.Read())
                    {
                        //Создание лейблов
                        Label label = new Label();
                        label.Text = reader.GetString(0);
                        label.Location = new System.Drawing.Point(25, currentY);
                        label.Size = new System.Drawing.Size(labelWidth, label.Height);
                        this.Controls.Add(label);

                        //Создание текстбоксов

                        TextBox textbox = new TextBox();
                        textbox.Location = new System.Drawing.Point(100, currentY);
                        textbox.Size = new System.Drawing.Size(textBoxWidth, textbox.Height);
                        textbox.Text = Selectedvalues[i++];
                        //Поле id делаем недоступным для изменения
                        if (label.Text == "id")
                        {
                            
                            textbox.ReadOnly = true;
                        }
                        this.Controls.Add(textbox);

                        fieldList.Add(new Tuple<Label, TextBox>(label, textbox));
                        currentY += label.Height + spacing;

                    }
                }
            }

            //Создание кнопки "изменить"
            Button updateBtn = new Button();
            updateBtn.Text = "update";
            updateBtn.Location = new System.Drawing.Point(50, currentY);
            updateBtn.Size = new System.Drawing.Size(100, updateBtn.Height);
            Controls.Add(updateBtn);

            updateBtn.Click += new EventHandler(updateTable);

        }

        private void updateTable(object sender, EventArgs e)
        {
            //Список типов данных полей
            List<string> dataTypes = new List<string>();

            //Заполнение типов данных полей
            try
            {
                using (var command = new NpgsqlCommand($"SELECT * from {tableName}", DataBaseConnection.connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        int i = 0;
                        while (reader.Read())
                        {
                            try { dataTypes.Add(reader.GetDataTypeName(i)); }
                            catch (Exception) { break; }
                            i++;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            string updateCommand = $"UPDATE {tableName} SET \n";
            for (int i = 1; i < fieldList.Count; i++)
            {
                if (dataTypes[i].Contains("int"))
                {
                    updateCommand += fieldList[i].Item1.Text + "=" + fieldList[i].Item2.Text + ",";
                }
                else
                {
                    updateCommand += fieldList[i].Item1.Text + "=" + "'" + fieldList[i].Item2.Text + "'" + ",";

                }



            }
            updateCommand = updateCommand.TrimEnd(',');

            updateCommand += $"\nWHERE id = {fieldList[0].Item2.Text}";
            Console.WriteLine(updateCommand);

            //Выполнение запроса SQL

            using (var command = new NpgsqlCommand(updateCommand, DataBaseConnection.connection))
            {
                try
                {
                    command.ExecuteNonQuery();
                    MessageBox.Show("Запись успешно изменена!");
                    fieldList.Clear();
                    Program.refreshTableView(dgv, tableName);
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
