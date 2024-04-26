using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CafetureManagementSystem.USER_CONTROL;

namespace CafetureManagementSystem
{
    public partial class HOMEPAGEcs : Form
    {
        public HOMEPAGEcs()
        {
            InitializeComponent();
            Uc_Home uc = new Uc_Home();
            addUserControl(uc);
        }
        private void addUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            PANELS.Controls.Clear();
            PANELS.Controls.Add(userControl);
            userControl.BringToFront();
        }
        private void guna2Button3_Click(object sender, EventArgs e)
        {
            UC_About uc = new UC_About();
            addUserControl(uc);
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Uc_Home uc = new Uc_Home();
            addUserControl(uc);
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            UC_Menu uc = new UC_Menu();
            addUserControl(uc);
        }
    }
}
