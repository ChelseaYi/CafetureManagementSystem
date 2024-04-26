using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace CafetureManagementSystem
{
    public partial class frmSignup : Form
    {
        MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=;password=; database=cafeturedb");
        public frmSignup()
        {
            InitializeComponent();
        }

        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSignup_Click(object sender, EventArgs e)
        {
            try
            {
                string firstName = txtFname.Text.ToString();
                string lastName = txtLname.Text.ToString();
                string username = txtUname.Text.ToString();
                string ageString = txtAge.Text.Trim();
                string gender = cbnGender.SelectedItem != null ? cbnGender.SelectedItem.ToString() : null;
                string password = txtPass.Text;
                string confirmpass = txtCPass.Text.Trim().ToString();
                if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName) || string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(ageString) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(confirmpass))
                {
                    MessageBox.Show("Please fill in all the fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int age;
                bool isValidAge = int.TryParse(ageString, out age);


                if (!isValidAge || age < 1)
                {
                    MessageBox.Show("Please enter a valid age.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (password != confirmpass)
                {
                    MessageBox.Show("Password and Confirm Password do not match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string insertQuery = "USE cafeturedb; INSERT INTO userinfo (firstname, lastname, username, age, gender, password) VALUES (@FirstName, @LastName, @Username, @Age, @Gender, @Password)";

                using (MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password="))
                {
                    connection.Open();

                    using (MySqlCommand command = new MySqlCommand(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@FirstName", firstName);
                        command.Parameters.AddWithValue("@LastName", lastName);
                        command.Parameters.AddWithValue("@Username", username);
                        command.Parameters.AddWithValue("@Age", age);
                        command.Parameters.AddWithValue("@Gender", gender);
                        command.Parameters.AddWithValue("@Password", password);

                        command.ExecuteNonQuery();
                       
                        MessageBox.Show("User successfully registered!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        frmLogin formLogin = new frmLogin();
                        this.Hide();
                        formLogin.ShowDialog();
                    }
                }
                txtFname.Clear();
               txtLname.Clear();
                txtUname.Clear();
                txtAge.Clear();
                cbnGender.SelectedIndex = -1;
                txtPass.Clear();
                txtCPass.Clear();


            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        
    }

        private void txtFname_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmSignup_Load(object sender, EventArgs e)
        {

        }

        private void cbnGender_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            frmLogin rmLogin = new frmLogin(); 
            this.Hide();
            rmLogin.ShowDialog();
        }
    }
}
