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
    public partial class RegisterForm : Form
    {
        BLUser bluser = new BLUser();
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void backButton_Click_1(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string username = usernameTB.Text;
            string password = passwordTB.Text;
            string name = nameTB.Text;
            string surname = surnameTB.Text;
            string address = addressTB.Text;
            string phone = phonenumberTB.Text;
            User user = new User(username, password, name, surname, address, phone, 3);
            if (bluser.createUser(user) == -1)
            {
                MessageBox.Show("User name exits, please choose another one");
            }
            else
            {
                MessageBox.Show("Register Sucess");
                LoginForm loginForm = new LoginForm();
                loginForm.Show();
                this.Hide();
            }
        }
    }
}
