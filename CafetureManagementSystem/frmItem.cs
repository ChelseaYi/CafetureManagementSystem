using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using CafetureManagementSystem.USER_CONTROL;
using MySql.Data.MySqlClient;

namespace CafetureManagementSystem
{
    public partial class frmItem : Form
    {
        public string Username { get; set; } 
       
        public frmItem()
        {
            InitializeComponent();
            UC_hotcof uc = new UC_hotcof();
            addUserControl(uc);

        }
        private void addUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            HAHAHA.Controls.Clear();
            HAHAHA.Controls.Add(userControl);
            userControl.BringToFront();
        }
        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

      

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string itemName = txtItem.Text;
            int price = Convert.ToInt32(txtPrice.Text);
            int quantity = (int)numUpdown.Value;
            int total = price * quantity;

            string connectionString = "datasource=localhost;port=3306;username=root;password=;database=cafeturedb";
            string query = "INSERT INTO addtocart (customer_name, item_name, price, quantity, total) VALUES (@customer_name, @ItemName, @Price, @Quantity, @Total)";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@customer_name", Username);
                    command.Parameters.AddWithValue("@ItemName", itemName);
                    command.Parameters.AddWithValue("@Price", price);
                    command.Parameters.AddWithValue("@Quantity", quantity);
                    command.Parameters.AddWithValue("@Total", total);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Order successfully added to cart!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtItem.Clear();
                        txtPrice.Clear();
                        numUpdown.Value = 0;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            UC_NonCoffee uc = new UC_NonCoffee();
            addUserControl(uc);
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            UC_hotcof uc = new UC_hotcof();
            addUserControl(uc);
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            UC_IceCoffee uc = new UC_IceCoffee();
            addUserControl(uc);
        }
    }
}
