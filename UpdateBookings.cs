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
    public partial class UpdateBookings : Form
    {
        User _user;
        public UpdateBookings(User user)
        {
            InitializeComponent();
            _user = user;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Hide();
            (new SponsorMain(_user)).ShowDialog();
            Close();
        }

        private void UpdateBookings_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            dataGridView1.Rows.Clear();
            using (var context = new Session2Entities())
            {
                var getBookings = (from x in context.Bookings
                                   where x.userIdFK == _user.userId
                                   where x.status == "Approved"
                                   select x);
                foreach (var item in getBookings)
                {
                    var newRow = new List<String>()
                    {
                        item.bookingId.ToString(), item.Package.packageTier, item.Package.packageName,
                        item.Package.packageValue.ToString(), item.quantityBooked.ToString(),
                        (item.Package.packageValue * item.quantityBooked).ToString()
                    };
                    dataGridView1.Rows.Add(newRow.ToArray());

                }

                long totalValue = 0;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    totalValue += Convert.ToInt64(dataGridView1.Rows[row.Index].Cells[5].Value);
                }
                lblTotalValue.Text = totalValue.ToString();
            }
        }

        private void btnUpdateQuantity_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Please select a booking to update!", "Update Quantity",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int toUpdate = Convert.ToInt32(nudQuantity.Value);
                var getPackage = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                using (var context = new Session2Entities())
                {
                    var getCurrentQuantity = (from x in context.Packages
                                              where x.packageName == getPackage
                                              select x.packageQuantity).FirstOrDefault();
                    if (getCurrentQuantity - toUpdate < 0)
                    {
                        MessageBox.Show("There are not enough sponsorship bookings for new quantity!",
                            "Update Quantity", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        var getPackageToUpdate = (from x in context.Packages
                                                  where x.packageName == getPackage
                                                  select x).FirstOrDefault();
                        getPackageToUpdate.packageQuantity += Convert.ToInt32(dataGridView1.CurrentRow.Cells[4].Value);
                        context.SaveChanges();
                        var bookingID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                        var getBookingToUpdate = (from x in context.Bookings
                                                  where x.bookingId == bookingID
                                                  select x).FirstOrDefault();
                        getBookingToUpdate.quantityBooked = toUpdate;
                        getBookingToUpdate.status = "Pending";
                        context.SaveChanges();
                        MessageBox.Show("Booking updated! Please wait for manager to approve the new quantity.",
                            "Update Quantity", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                    }
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Please select a booking to update!", "Update Quantity",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                var getBookingID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                var getPackageName = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                using (var context = new Session2Entities())
                {
                    var toDelete = (from x in context.Bookings
                                    where x.bookingId == getBookingID
                                    select x).FirstOrDefault();
                    var toAddBackPackage = (from x in context.Packages
                                            where x.packageName == getPackageName
                                            select x).FirstOrDefault();
                    toAddBackPackage.packageQuantity += toDelete.quantityBooked;
                    context.SaveChanges();
                    context.Bookings.Remove(toDelete);
                    context.SaveChanges();
                    MessageBox.Show("Booking deleted!", "Delete Booking", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    LoadData();
                }
            }
        }
    }
}
