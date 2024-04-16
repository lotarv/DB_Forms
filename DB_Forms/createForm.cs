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
        public createForm(string tableName)
        {
            InitializeComponent();
            showCreationInfo(tableName);
            this.tableName = tableName;
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
            using (var cmd = new NpgsqlCommand($"SELECT column_name FROM information_schema.columns WHERE table_name = '{tableName}'", connection))
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
            string createCommand = $"INSERT INTO {tableName} VALUES (";
            var parameters = new List<NpgsqlParameter>();
            int parameterIndex = 1;
            foreach (var field in fieldList)
            {
                createCommand += $"@{parameterIndex},";
                parameters.Add(new NpgsqlParameter($"@{parameterIndex}", field.Item2.Text));
                parameterIndex++;
            }
            string newstr = createCommand.Remove(createCommand.Length - 1) + ")";
            try
            {
                using (var command = new NpgsqlCommand(newstr, DataBaseConnection.connection))
                {
                    //Добавление параметров в команду
                    foreach (var parameter in parameters)
                    {
                        command.Parameters.Add(parameter);
                    }
                    command.ExecuteNonQuery();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
