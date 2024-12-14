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
    public partial class EditUserForm : Form
    {
        private User loggedInUser;
        BLUser bluser = new BLUser();
        public EditUserForm(User user)
        {
            InitializeComponent();
            loggedInUser = user;
        }

        private void EditUserForm_Load(object sender, EventArgs e)
        {
            idTB.Text = loggedInUser.UserId.ToString();
            usernameTB.Text = loggedInUser.Username.ToString();
            passwordTB.Text = loggedInUser.Password.ToString();
            nameTB.Text = loggedInUser.Name.ToString();
            surnameTB.Text = loggedInUser.Surname.ToString();
            addressTB.Text = loggedInUser.Address.ToString();
            phoneTB.Text = loggedInUser.Phone.ToString();
            int role = loggedInUser.RoleId;
            if (role == 1)
            {
                adminRBT.Checked = true;
            }
            else if (role == 2)
            {
                customerRBT.Checked = true;
            }
            else if (role == 3)
            {
                productionRBT.Checked = true;
            }
            else
            {
                sellingRBT.Checked = true;
            }
        }

        private void saveBT_Click(object sender, EventArgs e)
        {
            idTB.Text = loggedInUser.UserId.ToString();
            int id = Convert.ToInt32(idTB.Text);
            usernameTB.Text = loggedInUser.Username.ToString();
            string password = passwordTB.Text;
            string name = nameTB.Text;
            string surname = surnameTB.Text;
            string address = addressTB.Text;
            string phone = phoneTB.Text;
            int role;
            if (adminRBT.Checked == true)
            {
                role = 1;
            }
            else if (customerRBT.Checked == true)
            {
                role = 2;
            }
            else if (productionRBT.Checked == true)
            {
                role = 3;
            }
            else
            {
                role = 4;
            }
            if (idTB.Text == null || usernameTB.Text == null || password == null || name == null || surname == null || address == null || phone == null)
            {
                MessageBox.Show("Must fill all detail");
            }
            else
            {
                User user = new User(id, usernameTB.Text, password, name, surname, address, phone, role);
                UserSingleton.getInstance().UpdateUser(user);
                bluser.EditUser(user);
                this.Close();
            }
        }

        private void backBT_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
