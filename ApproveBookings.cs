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
    public partial class ApproveBookings : Form
    {
        public ApproveBookings()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Hide();
            (new ManagerMain()).ShowDialog();
            Close();
        }

        private void ApproveBookings_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            dataGridView1.Rows.Clear();
            using (var context = new Session2Entities())
            {
                var getBookings = (from x in context.Bookings
                                   orderby x.status == "Rejected", x.status == "Approved", x.status == "Pending",
                                   x.User.name
                                   select x);
                foreach (var item in getBookings)
                {
                    var newRow = new List<string>()
                    {
                        item.bookingId.ToString(), item.User.name, item.Package.packageName, item.status
                    };
                    dataGridView1.Rows.Add(newRow.ToArray());
                }
            }
        }

        private void btnReject_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select at least one booking to reject!", "No bookings selected",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                bool boolCheck = true;
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    if (dataGridView1.Rows[row.Index].Cells[3].Value.ToString() != "Pending")
                    {
                        boolCheck = false;
                    }
                }
                if (boolCheck == false)
                {
                    MessageBox.Show("You can only reject pending bookings! Re-select and try again!",
                        "Invalid bookings selected",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                    {
                        using (var context = new Session2Entities())
                        {
                            var getBookingID = Convert.ToInt32(dataGridView1.Rows[row.Index].Cells[0].Value);
                            var toReject = (from x in context.Bookings
                                            where x.bookingId == getBookingID
                                            select x).FirstOrDefault();
                            toReject.status = "Rejected";
                            context.SaveChanges();
                        }
                    }
                    MessageBox.Show("Successfully rejected bookings!", "Reject Bookings",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select at least one booking to accept!", "No bookings selected",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                bool boolCheck = true;
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    if (dataGridView1.Rows[row.Index].Cells[3].Value.ToString() != "Pending")
                    {
                        boolCheck = false;
                    }
                }
                if (boolCheck == false)
                {
                    MessageBox.Show("You can only accept pending bookings! Re-select and try again!",
                        "Invalid bookings selected",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                    {
                        using (var context = new Session2Entities())
                        {
                            var getBookingID = Convert.ToInt32(dataGridView1.Rows[row.Index].Cells[0].Value);
                            var toAccept = (from x in context.Bookings
                                            where x.bookingId == getBookingID
                                            select x).FirstOrDefault();
                            var checkPackageQuantity = (from x in context.Packages
                                                        where x.packageId == toAccept.packageIdFK
                                                        select x).FirstOrDefault();
                            if (checkPackageQuantity.packageQuantity - toAccept.quantityBooked >= 0)
                            {
                                toAccept.status = "Approved";
                                context.SaveChanges();
                                checkPackageQuantity.packageQuantity -= toAccept.quantityBooked;
                                context.SaveChanges();
                            }
                            else
                            {
                                MessageBox.Show($"{toAccept.User.name}'s {toAccept.Package.packageName} cannot be approved as it will cause a shortage in the werehouse!",
                                    "Unable to approve", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                continue;
                            }
                            
                        }
                    }
                    MessageBox.Show("Successfully Accepted bookings!", "Reject Bookings",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                }
            }
        }
    }
}
