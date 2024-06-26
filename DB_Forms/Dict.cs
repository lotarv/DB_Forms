﻿using Npgsql;
using System;
using System.Data;
using System.Windows.Forms;

namespace DB_Forms
{
    public partial class Dict : Form
    {
        static string selectedTable;
        public Dict()
        {
            InitializeComponent();
        }

        private void Dict_Load(object sender, EventArgs e)
        {

            //Создание combobox
            comboBox1.Items.Add("clients");
            comboBox1.Items.Add("hairdressers");
            comboBox1.Items.Add("services");

            comboBox1.SelectedIndexChanged += comboBoxDictSelectedIndexChanged;

            //Задание параметров для блока с таблицей
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            



        }
        //Обработка изменения выбранного справочника
        private void comboBoxDictSelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                selectedTable = comboBox1.SelectedItem.ToString();
                using (var cmd = new NpgsqlCommand($"SELECT * FROM {selectedTable}", DataBaseConnection.connection))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        var dt = new DataTable();
                        dt.Load(reader);

                        dataGridView1.DataSource = dt;


                    }
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void createBtn_Click(object sender, EventArgs e)
        {
            var createForm1 = new createForm(selectedTable, dataGridView1);
            createForm1.ShowDialog();
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            var delForm = new deleteForm(dataGridView1, selectedTable);
            delForm.ShowDialog();
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            var updForm = new updateForm(dataGridView1,selectedTable);
            updForm.ShowDialog();
        }
    }
}
