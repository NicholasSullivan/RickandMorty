using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COMPE_361_Final_Project
{
    public partial class MenuForm : Form
    {
        public MenuForm()
        {
            InitializeComponent();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("A trivia maze game.");
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            Form1 mazeForm = new Form1();
            mazeForm.ShowDialog();
        }
    }
}
