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
    public partial class ViewSummary : Form
    {
        public ViewSummary()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Hide();
            (new ManagerMain()).ShowDialog();
            Close();
        }

        private void ViewSummary_Load(object sender, EventArgs e)
        {
            LoadComboBox();
        }

        private void LoadComboBox()
        {
            cbTier.Items.Clear();
            cbTier.Items.Add("All Tiers");
            using (var context = new Session2Entities())
            {
                var getTiers = (from x in context.Packages
                                orderby x.packageTier == "Bronze", x.packageTier == "Silver", x.packageTier == "Gold"
                                select x.packageTier).Distinct().ToArray();
                cbTier.Items.AddRange(getTiers);
                cbTier.SelectedIndex = 0;
            }
        }

        private void cbTier_SelectedIndexChanged(object sender, EventArgs e)
        {
            chart1.Series.Clear();
            chart1.Series.Add("Series1");
            chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            if (cbTier.SelectedItem.ToString() == "All Tiers")
            {
                using (var context = new Session2Entities())
                {
                    var getSummary = (from x in context.Bookings
                                      where x.status == "Approved"
                                      group x by x.Package.packageName into y
                                      select new
                                      {
                                          key = y.Key,
                                          totalAmount = context.Bookings.Where(z => z.Package.packageName == y.Key)
                                      .Select(z => z.quantityBooked).Sum()
                                      });
                    var totalValue = 0;
                    foreach (var item in getSummary)
                    {
                        var Idx = chart1.Series[0].Points.AddY(item.totalAmount);
                        chart1.Series[0].Points[Idx].AxisLabel = item.key;
                        totalValue += Convert.ToInt32((from x in context.Bookings
                                                      where x.status == "Approved" && x.Package.packageName == item.key
                                                      select x.Package.packageValue * x.quantityBooked).Sum());
                        chart1.Series[0].Points[Idx].LabelToolTip = $"{item.key}, {item.totalAmount}, #PERCENT";
                    }
                    lblTotalValue.Text = totalValue.ToString();
                }
                

            }
            else
            {
                using (var context = new Session2Entities())
                {
                    var getSummary = (from x in context.Bookings
                                      where x.status == "Approved" && x.Package.packageTier == cbTier.SelectedItem.ToString()
                                      group x by x.Package.packageName into y
                                      select new
                                      {
                                          key = y.Key,
                                          totalAmount = context.Bookings.Where(z => z.Package.packageName == y.Key)
                                      .Select(z => z.quantityBooked).Sum()
                                      });
                    var totalValue = 0;
                    foreach (var item in getSummary)
                    {
                        var Idx = chart1.Series[0].Points.AddY(item.totalAmount);
                        chart1.Series[0].Points[Idx].AxisLabel = item.key;
                        totalValue += Convert.ToInt32((from x in context.Bookings
                                                       where x.status == "Approved" && x.Package.packageName == item.key
                                                       select x.Package.packageValue * x.quantityBooked).Sum());
                        chart1.Series[0].Points[Idx].LabelToolTip = $"{item.key}, {item.totalAmount}, #PERCENT";
                    }
                    lblTotalValue.Text = totalValue.ToString();
                }
            }
        }
    }
}
