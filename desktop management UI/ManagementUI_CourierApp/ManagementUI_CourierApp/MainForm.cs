using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagementUI_CourierApp
{
    public partial class MainForm : Form
    {
        string currentUser = null;
        public MainForm(string username)
        {
            currentUser = username;
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            labelShowCurrentUser.Text = string.Empty;
            labelShowCurrentUser.Text = "Connected as: " + currentUser;
        }

        private void labelShowCurrentUser_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to exit the application?",
                "Exit Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }

        }

    }
}
