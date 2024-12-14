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
    public partial class MainForm : Form
    {
        private User loggedInUser;
        public MainForm(User user)
        {
            InitializeComponent();
            loggedInUser = user;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            profileButton_Click(sender, e);
            int roleid = loggedInUser.RoleId;
            if (roleid != 1)
            {
                manageBttons.Enabled = false;
            }
        }

        private void showForm(object Form)
        {
            if (this.panel1.Controls.Count > 0)
            {
                this.panel1.Controls.RemoveAt(0);
            }
            Form form = Form as Form;
            form.FormBorderStyle = FormBorderStyle.None;
            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            this.panel1.Controls.Add(form);
            form.Show();
        }

        private void profileButton_Click(object sender, EventArgs e)
        {
            showForm(new Profile(loggedInUser));
        }

        private void manageBttons_Click(object sender, EventArgs e)
        {
            showForm(new Manage());
        }

        private void checkButton_Click(object sender, EventArgs e)
        {
            showForm(new OrderCheck());
        }

        private void productButton_Click(object sender, EventArgs e)
        {
            showForm(new Product());
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

        private void buttonsPanel_Paint(object sender, PaintEventArgs e)
        {
            using (Pen borderPen = new Pen(Color.Black, 1))
            {
                e.Graphics.DrawLine(borderPen, buttonsPanel.Width - 1, 0, buttonsPanel.Width - 1, buttonsPanel.Height);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
