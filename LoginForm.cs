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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            using (var context = new Session2Entities())
            {
                if (string.IsNullOrWhiteSpace(txtUserID.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
                {
                    MessageBox.Show("Please check your fields and try again!", "Empty Field(s)", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                else
                {
                    var getUser = (from x in context.Users
                                   where x.userId == txtUserID.Text
                                   select x).FirstOrDefault();

                    if (getUser == null)
                    {
                        MessageBox.Show("User does not exits!", "Invalid Login", MessageBoxButtons.OK,
                       MessageBoxIcon.Error);
                    }
                    else
                    {
                        if (getUser.passwd != txtPassword.Text)
                        {
                            MessageBox.Show("Password or User ID does not match our database!", "Invalid Login", MessageBoxButtons.OK,
                       MessageBoxIcon.Error);
                        }
                        else
                        {
                            if (getUser.userTypeIdFK == 1)
                            {
                                MessageBox.Show($"Welcome {getUser.name}!", "Login", MessageBoxButtons.OK,
                       MessageBoxIcon.Information);
                                Hide();
                                (new ManagerMain()).ShowDialog();
                                Close();
                            }
                            else if (getUser.userTypeIdFK == 2)
                            {
                                MessageBox.Show($"Welcome {getUser.name}!", "Login", MessageBoxButtons.OK,
                       MessageBoxIcon.Information);
                                Hide();
                                (new SponsorMain(getUser)).ShowDialog();
                                Close();
                            }
                        }
                    }
                }
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            Hide();
            (new CreateForm()).ShowDialog();
            Close();
        }
    }
}
