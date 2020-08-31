using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPQR_Session2_31_8
{
    public partial class AddPackages : Form
    {
        List<string> benefitsList = new List<string>();
        public AddPackages()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Hide();
            (new ManagerMain()).ShowDialog();
            Close();
        }

        private void AddPackages_Load(object sender, EventArgs e)
        {
            LoadComboBox();
        }

        private void LoadComboBox()
        {
            cbTier.Items.Clear();
            using (var context = new Session2Entities())
            {
                var getTier = (from x in context.Packages
                               select x.packageTier).Distinct().ToArray();
                cbTier.Items.AddRange(getTier);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtPackageName.Text = string.Empty;
            nudQuantity.Value = 0;
            nudValue.Value = 0;
            LoadComboBox();
            cbBanner.Checked = false;
            cbFlyer.Checked = false;
            cbOnline.Checked = false;
            txtFilePath.Text = string.Empty;
        }

        private void txtFilePath_DoubleClick(object sender, EventArgs e)
        {
            OpenFileDialog odf = new OpenFileDialog();
            var prompt = odf.ShowDialog();
            if (prompt == DialogResult.OK)
            {
                var filePath = odf.FileName;
                txtFilePath.Text = filePath;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPackageName.Text) || nudValue.Value <= 0 || nudQuantity.Value <= 0 || cbTier.SelectedItem == null)
            {
                MessageBox.Show("Please check your entries! Make sure there is a package name and values are correct!",
                    "Invalid Field(s)", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (cbTier.SelectedItem.ToString() == "Bronze" && (nudValue.Value <= 0 || nudValue.Value > 10000))
            {
                MessageBox.Show("Bronze tier pricing is between $0 and up to $10,000!", "Invalid Value",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (cbTier.SelectedItem.ToString() == "Silver" && (nudValue.Value <= 10000 || nudValue.Value >= 50000))
            {
                MessageBox.Show("Silver tier pricing is between $10000 inclusive, to $50,000!", "Invalid Value",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (cbTier.SelectedItem.ToString() == "Gold" && nudValue.Value < 50000)
            {
                MessageBox.Show("Gold tier pricing is more than or equal $50,000!", "Invalid Value",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (cbTier.SelectedItem.ToString() == "Bronze" && benefitsList.Count != 1)
            {
                MessageBox.Show("Bronze tier requires up to one benfit!", "Invalid number of benefit",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (cbTier.SelectedItem.ToString() == "Silver" && benefitsList.Count != 2)
            {
                MessageBox.Show("Silver tier requires only two benfits!", "Invalid number of benefit",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (cbTier.SelectedItem.ToString() == "Gold" && benefitsList.Count != 3)
            {
                MessageBox.Show("Gold tier requires all benefits!", "Invalid number of benefit",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                using (var context = new Session2Entities())
                {
                    var getPackageName = (from x in context.Packages
                                          where x.packageName == txtPackageName.Text
                                          select x).FirstOrDefault();
                    if (getPackageName != null)
                    {
                        MessageBox.Show("Unable to add package as name is used!", "Existing Package Name",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        var newPackage = new Package()
                        {
                            packageTier = cbTier.SelectedItem.ToString(),
                            packageName = txtPackageName.Text,
                            packageQuantity = Convert.ToInt32(nudQuantity.Value),
                            packageValue = Convert.ToInt32(nudValue.Value)
                        };
                        context.Packages.Add(newPackage);
                        context.SaveChanges();
                        var getNewID = (from x in context.Packages
                                        where x.packageName == txtPackageName.Text
                                        select x.packageId).FirstOrDefault();
                        foreach (var item in benefitsList)
                        {
                            context.Benefits.Add(new Benefit() { packageIdFK = getNewID, benefitName = item });
                            context.SaveChanges();
                        }
                        MessageBox.Show("Added package successfully!", "Add Package",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnClear_Click(null, null);
                    }
                }
            }

        }

        private void cbOnline_CheckedChanged(object sender, EventArgs e)
        {
            if (cbOnline.Checked)
            {
                benefitsList.Add("Online");
            }
            else
            {
                if (benefitsList.Contains("Online"))
                {
                    benefitsList.Remove("Online");
                }
            }
        }

        private void cbFlyer_CheckedChanged(object sender, EventArgs e)
        {
            if (cbFlyer.Checked)
            {
                benefitsList.Add("Flyer");
            }
            else
            {
                if (benefitsList.Contains("Flyer"))
                {
                    benefitsList.Remove("Flyer");
                }
            }
        }

        private void cbBanner_CheckedChanged(object sender, EventArgs e)
        {
            if (cbBanner.Checked)
            {
                benefitsList.Add("Banner");
            }
            else
            {
                if (benefitsList.Contains("Banner"))
                {
                    benefitsList.Remove("Banner");
                }
            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            var value = File.ReadAllLines(txtFilePath.Text).Skip(1);
            foreach (var item in value)
            {

                var rowValue = item.Split(',');
                var newPackage = new Package()
                {
                    packageTier = rowValue[0],
                    packageName = rowValue[1],
                    packageValue = Convert.ToInt64(rowValue[2]),
                    packageQuantity = Convert.ToInt32(rowValue[3])
                };
                using (var context  = new Session2Entities())
                {
                    context.Packages.Add(newPackage);
                    context.SaveChanges();
                }
            }
            MessageBox.Show("Added all new packages", "Add Packages",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnClear_Click(null, null);
        }
    }
}
