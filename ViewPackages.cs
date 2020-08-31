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
    public partial class ViewPackages : Form
    {
        List<Package> orderedList = new List<Package>();
        public ViewPackages()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Hide();
            (new ManagerMain()).ShowDialog();
            Close();
        }

        private void ViewPackages_Load(object sender, EventArgs e)
        {
            LoadData(0);
        }

        private void LoadData(int mode)
        {
            dataGridView1.Rows.Clear();
            using (var context = new Session2Entities())
            {

                if (mode == 0)
                {
                    var getPackages = (from x in context.Packages
                                       orderby x.packageTier == "Bronze", x.packageTier == "Silver", x.packageTier == "Gold",
                                       x.packageName
                                       select x);
                    foreach (var item in getPackages)
                    {
                        var getBenefits = (from x in context.Benefits
                                           where x.packageIdFK == item.packageId
                                           select x.benefitName).ToList();
                        var newRow = new List<String>(){item.packageTier, item.packageName, item.packageValue.ToString(),
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
                    foreach (var item in orderedList)
                    {
                        var getBenefits = (from x in context.Benefits
                                           where x.packageIdFK == item.packageId
                                           select x.benefitName).ToList();
                        var newRow = new List<String>(){item.packageTier, item.packageName, item.packageValue.ToString(),
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

        private void rbTier_CheckedChanged(object sender, EventArgs e)
        {
            using (var context = new Session2Entities())
            {
                orderedList = (from x in context.Packages
                               orderby x.packageTier == "Bronze", x.packageTier == "Silver", x.packageTier == "Gold"
                               select x).ToList();
                LoadData(1);
            }
        }

        private void rbName_CheckedChanged(object sender, EventArgs e)
        {
            using (var context = new Session2Entities())
            {
                orderedList = (from x in context.Packages
                               orderby x.packageName
                               select x).ToList();
                LoadData(1);
            }
        }

        private void rbValue_CheckedChanged(object sender, EventArgs e)
        {
            using (var context = new Session2Entities())
            {
                orderedList = (from x in context.Packages
                               orderby x.packageValue
                               select x).ToList();
                LoadData(1);
            }
        }

        private void rbQuantity_CheckedChanged(object sender, EventArgs e)
        {
            using (var context = new Session2Entities())
            {
                orderedList = (from x in context.Packages
                               orderby x.packageQuantity descending
                               select x).ToList();
                LoadData(1);
            }
        }
    }
}
