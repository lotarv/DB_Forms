using Npgsql;
using System;
using System.Windows.Forms;
using System.Collections.Generic;


namespace DB_Forms
{
    public partial class createForm : Form
    {
        static List<Tuple<Label, TextBox>> fieldList = new List<Tuple<Label, TextBox>>();
        private string tableName;
        private DataGridView dgv;
        public createForm(string tableName, DataGridView dgv)
        {
            InitializeComponent();
            showCreationInfo(tableName);
            this.tableName = tableName;
            this.dgv = dgv;
        }

        private void createForm_Load(object sender, EventArgs e)
        {
            
        }

        private void showCreationInfo(string tableName)
        {
            int labelWidth = 75;
            int textBoxWidth = 100;
            int spacing = 10;
            int currentY = 20;
            var connection = DataBaseConnection.connection;
            using (var cmd = new NpgsqlCommand($"SELECT column_name FROM information_schema.columns WHERE table_name = '{tableName}' ORDER BY ordinal_position", connection))
            {
                using (var reader = cmd.ExecuteReader())
                {
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
                        textbox.Location = new System.Drawing.Point(100,currentY);
                        textbox.Size = new System.Drawing.Size(textBoxWidth, textbox.Height);
                        //Поле id делаем недоступным для изменения
                        if (label.Text == "id")
                        {
                            textbox.Text = "default";
                            textbox.ReadOnly = true;
                        }
                        this.Controls.Add(textbox);

                        fieldList.Add(new Tuple <Label, TextBox> (label, textbox));
                        currentY += label.Height + spacing;

                    }
                }
            }

            //Создание кнопки "добавить"
            Button createBtn = new Button();
            createBtn.Text = "create";
            createBtn.Location = new System.Drawing.Point(50, currentY);
            createBtn.Size = new System.Drawing.Size(100, createBtn.Height);
            Controls.Add(createBtn);

            createBtn.Click += new EventHandler(createBtn_click);

        }

        private void createBtn_click(object sender, EventArgs e)
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
                            catch(Exception) { break; }
                            i++;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            //Создание команды для запроса
            string createCommand = $"INSERT INTO {tableName} VALUES (";
            var parameters = new List<NpgsqlParameter>();
            int parameterIndex = 1;
            //Добавление default если поле default
            for (var i = 0; i < dataTypes.Count; i++)
            {
                if (fieldList[i].Item2.Text == "default")
                {
                    createCommand += "default,";
                    continue;
                }
                createCommand += $"@{parameterIndex},";
                //Проверка на тип данных и добавление параметра
                if (dataTypes[i].Contains("int") && fieldList[i].Item2.Text != "default")
                {
                    parameters.Add(new NpgsqlParameter($"@{parameterIndex}", int.Parse(fieldList[i].Item2.Text)));
                    

                }
                else
                {
                    parameters.Add(new NpgsqlParameter($"@{parameterIndex}", fieldList[i].Item2.Text));
                    

                }
                parameterIndex++;
            }


            string newstr = createCommand.Remove(createCommand.Length - 1) + ")";
            createCommand = newstr;
            try
            {
                using (var command = new NpgsqlCommand(createCommand, DataBaseConnection.connection))
                {
                    //Добавление параметров в команду
                    foreach (var parameter in parameters)
                    {
                        command.Parameters.Add(parameter);
                        Console.WriteLine(parameter.ToString());
                    }
                    command.ExecuteNonQuery();
                    fieldList.Clear();
                    MessageBox.Show("Запись успешно добавлена");
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
