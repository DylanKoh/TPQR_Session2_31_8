using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPQR_Session2_31_8
{
    public partial class CreateForm : Form
    {
        public CreateForm()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Hide();
            (new LoginForm()).ShowDialog();
            Close();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCompanyName.Text) || string.IsNullOrWhiteSpace(txtUserID.Text) || string.IsNullOrWhiteSpace(txtPassword.Text) || string.IsNullOrWhiteSpace(txtRePassword.Text))
            {
                MessageBox.Show("Please check your fields!", "Empty Field(s)", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            else if (txtUserID.TextLength < 8)
            {
                MessageBox.Show("User ID needs to be 8 characters long!", "Short User ID", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
            }
            else if (txtPassword.Text != txtRePassword.Text)
            {
                MessageBox.Show("Passwords do not match!", "Passwords Mismatch", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
            }
            else
            {
                using (var context = new Session2Entities())
                {
                    var getUser = (from x in context.Users
                                   where x.userId == txtUserID.Text
                                   select x).FirstOrDefault();
                    var findCompany = (from x in context.Users
                                       where x.name == txtCompanyName.Text
                                       select x).FirstOrDefault();

                    if (getUser != null)
                    {
                        MessageBox.Show("User ID taken!", "Unvalid User ID", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                    }
                    else if (findCompany != null)
                    {
                        MessageBox.Show("Company has already registered for an account!", "User Account Exist", MessageBoxButtons.OK,
                  MessageBoxIcon.Error);
                    }
                    else
                    {
                        var newUser = new User()
                        {
                            name = txtCompanyName.Text,
                            userId = txtUserID.Text,
                            passwd = txtRePassword.Text,
                            userTypeIdFK = 2
                        };
                        context.Users.Add(newUser);
                        context.SaveChanges();
                        MessageBox.Show("User account created successfully!", "Create Account", MessageBoxButtons.OK,
                  MessageBoxIcon.Information);
                        Hide();
                        (new LoginForm()).ShowDialog();
                        Close();
                    }
                }
            }
        }
    }
}
