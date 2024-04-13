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
    public partial class Dict : Form
    {
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

            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
