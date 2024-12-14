using BL;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VIS_Project
{
    public partial class LoginForm : Form
    {
        BLUser bluser = new BLUser();
        public LoginForm()
        {
            InitializeComponent();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            string username = loginTB.Text;
            string password = passwordTB.Text;
            User user = bluser.checkLogin(new User(username, password));

            if (user != null)
            {
                int roleId = bluser.GetRoleId(username);
                if (roleId == 2 || roleId == 4)
                {
                    MessageBox.Show("You are not Admin or production team");
                }
                else
                {
                    MainForm mainform = new MainForm(user);
                    mainform.Show();
                    this.Hide();
                }

            }
            else
            {
                MessageBox.Show("Error username or password");
            }
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            RegisterForm registerForm = new RegisterForm();
            registerForm.Show();
            this.Hide();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            DialogResult res;
            res = MessageBox.Show("Exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                this.Show();
            }
        }
    }
}
