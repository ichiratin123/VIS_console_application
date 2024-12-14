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
    public partial class Manage : Form
    {
        BLUser bluser = new BLUser();
        RoleBL rolebl = new RoleBL();
        public Manage()
        {
            InitializeComponent();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 1)
            {
                var selectedItem = listView1.SelectedItems[0];
                string userId = selectedItem.SubItems[0].Text;
                int id = Int32.Parse(userId);
                string username = selectedItem.SubItems[1].Text;
                string password = selectedItem.SubItems[2].Text;
                string name = selectedItem.SubItems[3].Text;
                string surname = selectedItem.SubItems[4].Text;
                string address = selectedItem.SubItems[5].Text;
                string phone = selectedItem.SubItems[6].Text;
                string role = selectedItem.SubItems[7].Text;
                int roleId = rolebl.GetRoleIdByRoleName(role);
                User user1 = new User(id, username, password, name, surname, address, phone, roleId);
                EditUserForm user = new EditUserForm(user1);
                user.ShowDialog();
            }
            ReloadData();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 1)
            {
                var selectedItem = listView1.SelectedItems[0];
                string userId = selectedItem.SubItems[0].Text;
                int id = Int32.Parse(userId);
                string username = selectedItem.SubItems[1].Text;
                string password = selectedItem.SubItems[2].Text;
                string name = selectedItem.SubItems[3].Text;
                string surname = selectedItem.SubItems[4].Text;
                string address = selectedItem.SubItems[5].Text;
                string phone = selectedItem.SubItems[6].Text;
                string role = selectedItem.SubItems[7].Text;
                int roleId = rolebl.GetRoleIdByRoleName(role);
                User user1 = new User(id, username, password, name, surname, address, phone, roleId);
                bluser.DeleteUser(user1);
            }
            ReloadData();
        }

        private void ReloadData()
        {
            UserSingleton.getInstance().LoadUsers();
            listView1.Items.Clear();

            foreach (var user in UserSingleton.getInstance().Users)
            {
                var item = new ListViewItem(user.UserId.ToString());
                item.SubItems.Add(user.Username);
                item.SubItems.Add(user.Password);
                item.SubItems.Add(user.Name);
                item.SubItems.Add(user.Surname);
                item.SubItems.Add(user.Address);
                item.SubItems.Add(user.Phone);
                int roleid = user.RoleId;
                string role = rolebl.GetRoleNameByRoleId(roleid);
                item.SubItems.Add(role);
                listView1.Items.Add(item);
            }
        }

        private void Manage_Load(object sender, EventArgs e)
        {
            List<User> user = bluser.GetAllUser();
            listView1.View = View.Details;
            listView1.Columns.Add("User ID", 100);
            listView1.Columns.Add("Username", 150);
            listView1.Columns.Add("Password", 150);
            listView1.Columns.Add("Name", 200);
            listView1.Columns.Add("Surname", 200);
            listView1.Columns.Add("Address", 200);
            listView1.Columns.Add("Phone Number", 200);
            listView1.Columns.Add("Role", 100);
            listView1.Items.Clear();
            string role;
            foreach (User user1 in user)
            {
                role = rolebl.GetRoleNameByRoleId(user1.RoleId);
                var item = new ListViewItem(user1.UserId.ToString());
                item.SubItems.Add(user1.Username);
                item.SubItems.Add(user1.Password);
                item.SubItems.Add(user1.Name);
                item.SubItems.Add(user1.Surname);
                item.SubItems.Add(user1.Address);
                item.SubItems.Add(user1.Phone);
                item.SubItems.Add(role);
                listView1.Items.Add(item);
            }
        }
    }
}
