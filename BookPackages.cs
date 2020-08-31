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
    public partial class BookPackages : Form
    {
        User _user;
        List<Package> modifiedPackages = new List<Package>();
        List<String> benefitList = new List<string>();
        public BookPackages(User user)
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

        private void BookPackages_Load(object sender, EventArgs e)
        {
            LoadComboBox();
            LoadData(0);
        }

        private void LoadData(int mode)
        {
            using (var context = new Session2Entities())
            {
                dataGridView1.Rows.Clear();
                if (mode == 0)
                {
                    var getPackages = (from x in context.Packages
                                       where x.packageQuantity > 0
                                       select x);
                    foreach (var item in getPackages)
                    {
                        var getBenefits = (from x in context.Benefits
                                           where x.packageIdFK == item.packageId
                                           select x.benefitName).ToList();
                        var newRow = new List<String>(){ item.packageId.ToString(),
                            item.packageTier, item.packageName, item.packageValue.ToString(),
                            item.packageQuantity.ToString()};
                        if (getBenefits.Contains("Online"))
                        {
                            newRow.Add("Yes");
                        }
                        else
                        {
                            newRow.Add("");
                        }
                        if (getBenefits.Contains("Flyer"))
                        {
                            newRow.Add("Yes");
                        }
                        else
                        {
                            newRow.Add("");
                        }
                        if (getBenefits.Contains("Banner"))
                        {
                            newRow.Add("Yes");
                        }
                        else
                        {
                            newRow.Add("");
                        }
                        dataGridView1.Rows.Add(newRow.ToArray());
                    }
                }
                else
                {
                    foreach (var item in modifiedPackages)
                    {
                        var getBenefits = (from x in context.Benefits
                                           where x.packageIdFK == item.packageId
                                           select x.benefitName).ToList();
                        var newRow = new List<String>(){ item.packageId.ToString(),
                            item.packageTier, item.packageName, item.packageValue.ToString(),
                            item.packageQuantity.ToString()};
                        if (getBenefits.Contains("Online"))
                        {
                            newRow.Add("Yes");
                        }
                        else
                        {
                            newRow.Add("");
                        }
                        if (getBenefits.Contains("Flyer"))
                        {
                            newRow.Add("Yes");
                        }
                        else
                        {
                            newRow.Add("");
                        }
                        if (getBenefits.Contains("Banner"))
                        {
                            newRow.Add("Yes");
                        }
                        else
                        {
                            newRow.Add("");
                        }
                        dataGridView1.Rows.Add(newRow.ToArray());
                    }
                }

            }
        }

        private void LoadComboBox()
        {

            cbTier.Items.Clear();
            cbTier.Items.Add("No Filter");
            using (var context = new Session2Entities())
            {
                var getTiers = (from x in context.Packages
                                select x.packageTier).Distinct().ToArray();
                cbTier.Items.AddRange(getTiers);
            }
        }

        private void cbTier_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterList();
        }

        private void FilterList()
        {
            modifiedPackages.Clear();
            if ((cbTier.SelectedItem == null || cbTier.SelectedItem.ToString() == "No Filter") && nudBudget.Value == 0)
            {
                using (var context = new Session2Entities())
                {
                    var temporaryPackages = (from x in context.Packages
                                             where x.packageQuantity > 0
                                             select x).ToList();
                    foreach (var item in temporaryPackages)
                    {
                        var getBenefits = (from x in context.Benefits
                                           where x.packageIdFK == item.packageId
                                           select x.benefitName).ToList();
                        var boolCheck = true;
                        foreach (var benefit in benefitList)
                        {
                            if (getBenefits.Contains(benefit))
                            {
                                continue;
                            }
                            else
                            {
                                boolCheck = false;
                                break;
                            }
                        }
                        if (boolCheck)
                            modifiedPackages.Add(item);
                        else
                            continue;
                    }
                    LoadData(1);
                }
            }
            else if ((nudBudget.Value == 0) && (cbTier.SelectedItem != null && cbTier.SelectedItem.ToString() != "No Filter"))
            {
                using (var context = new Session2Entities())
                {
                    var temporaryPackages = (from x in context.Packages
                                             where x.packageTier == cbTier.SelectedItem.ToString()
                                             where x.packageQuantity > 0
                                             select x).ToList();
                    foreach (var item in temporaryPackages)
                    {
                        var getBenefits = (from x in context.Benefits
                                           where x.packageIdFK == item.packageId
                                           select x.benefitName).ToList();
                        var boolCheck = true;
                        foreach (var benefit in benefitList)
                        {
                            if (getBenefits.Contains(benefit))
                            {
                                continue;
                            }
                            else
                            {
                                boolCheck = false;
                                break;
                            }
                        }
                        if (boolCheck)
                            modifiedPackages.Add(item);
                        else
                            continue;
                    }
                    LoadData(1);
                }


            }
            else if ((cbTier.SelectedItem == null || cbTier.SelectedItem.ToString() == "No Filter") && nudBudget.Value > 0)
            {
                using (var context = new Session2Entities())
                {
                    long budget = Convert.ToInt64(nudBudget.Value);
                    var temporaryPackages = (from x in context.Packages
                                             where x.packageValue <= budget
                                             where x.packageQuantity > 0
                                             select x).ToList();
                    foreach (var item in temporaryPackages)
                    {
                        var getBenefits = (from x in context.Benefits
                                           where x.packageIdFK == item.packageId
                                           select x.benefitName).ToList();
                        var boolCheck = true;
                        foreach (var benefit in benefitList)
                        {
                            if (getBenefits.Contains(benefit))
                            {
                                continue;
                            }
                            else
                            {
                                boolCheck = false;
                                break;
                            }
                        }
                        if (boolCheck)
                            modifiedPackages.Add(item);
                        else
                            continue;
                    }
                    LoadData(1);
                }
            }
            else
            {
                using (var context = new Session2Entities())
                {
                    long budget = Convert.ToInt64(nudBudget.Value);
                    var temporaryPackages = (from x in context.Packages
                                             where x.packageValue <= budget && x.packageTier == cbTier.SelectedItem.ToString()
                                             where x.packageQuantity > 0
                                             select x).ToList();
                    foreach (var item in temporaryPackages)
                    {
                        var getBenefits = (from x in context.Benefits
                                           where x.packageIdFK == item.packageId
                                           select x.benefitName).ToList();
                        var boolCheck = true;
                        foreach (var benefit in benefitList)
                        {
                            if (getBenefits.Contains(benefit))
                            {
                                continue;
                            }
                            else
                            {
                                boolCheck = false;
                                break;
                            }
                        }
                        if (boolCheck)
                            modifiedPackages.Add(item);
                        else
                            continue;
                    }
                    LoadData(1);
                }
            }
        }

        private void nudBudget_ValueChanged(object sender, EventArgs e)
        {
            FilterList();
        }

        private void cbOnline_CheckedChanged(object sender, EventArgs e)
        {
            if (cbOnline.Checked)
            {
                benefitList.Add("Online");
            }
            else
            {
                if (benefitList.Contains("Online"))
                {
                    benefitList.Remove("Online");
                }
            }
            FilterList();
        }

        private void cbFlyer_CheckedChanged(object sender, EventArgs e)
        {
            if (cbFlyer.Checked)
            {
                benefitList.Add("Flyer");
            }
            else
            {
                if (benefitList.Contains("Flyer"))
                {
                    benefitList.Remove("Flyer");
                }
            }
            FilterList();
        }

        private void cbBanner_CheckedChanged(object sender, EventArgs e)
        {
            if (cbBanner.Checked)
            {
                benefitList.Add("Banner");
            }
            else
            {
                if (benefitList.Contains("Banner"))
                {
                    benefitList.Remove("Banner");
                }
            }
            FilterList();
        }

        private void btnBook_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Please select a sponsorship package to book!", "Booking", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            else
            {
                if (Convert.ToDecimal(dataGridView1.CurrentRow.Cells[4].Value) < nudQuantity.Value)
                {
                    MessageBox.Show("Sponsorship booking not enough!", "Booking", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                }
                else
                {
                    var newBooking = new Booking()
                    {
                        packageIdFK = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value),
                        status = "Pending",
                        userIdFK = _user.userId,
                        quantityBooked = Convert.ToInt32(nudQuantity.Value)
                    };
                    using (var context =new Session2Entities())
                    {
                        context.Bookings.Add(newBooking);
                        context.SaveChanges();
                        MessageBox.Show("Booking successful!", "Booking", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }
    }
}
