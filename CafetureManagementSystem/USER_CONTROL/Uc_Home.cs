using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CafetureManagementSystem.USER_CONTROL
{
    public partial class Uc_Home : UserControl
    {
        public Uc_Home()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            frmItem oRDER_NOW = new frmItem();
            this.Hide();
          
            oRDER_NOW.Show();
        }
    }
}
