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
    public partial class Profile : Form
    {
        private User loggedInUser;
        BLUser bluser = new BLUser();
        RoleBL rolebl = new RoleBL();
        public Profile(User user)
        {
            InitializeComponent();
            loggedInUser = user;
        }

        private void Profile_Load(object sender, EventArgs e)
        {
            idTB.Text = loggedInUser.UserId.ToString();
            usernameTB.Text = loggedInUser.Username.ToString();
            passwordTB.Text = loggedInUser.Password.ToString();
            string fullname = $"{loggedInUser.Name} {loggedInUser.Surname}";
            fullnameTB.Text = fullname;
            addressTB.Text = loggedInUser.Address.ToString();
            phoneTB.Text = loggedInUser.Phone.ToString();
            int role = loggedInUser.RoleId;
            string nameRole = rolebl.GetRoleNameByRoleId(role);
            roleTB.Text = nameRole;
        }
    }
}
