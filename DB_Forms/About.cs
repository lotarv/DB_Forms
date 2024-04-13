using System;
using System.Windows.Forms;

namespace DB_Forms
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
        }

        private void About_Load(object sender, EventArgs e)
        {
            label1.Text = "Программа была разработана студентом группы 26/1 Лотаревым Сергеем в 2024 году";
            label2.Text = "Инструменты: C#, Visual Studio 2022, Npgsql, Windows Forms";
        }
    }
}
