namespace TPQR_Session2_31_8
{
    partial class ManagerMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnBack = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnViewPackages = new System.Windows.Forms.Button();
            this.btnAddPackages = new System.Windows.Forms.Button();
            this.btnApproveBookings = new System.Windows.Forms.Button();
            this.btnViewSummary = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Maroon;
            this.panel1.Controls.Add(this.btnBack);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(995, 104);
            this.panel1.TabIndex = 8;
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(12, 26);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(98, 47);
            this.btnBack.TabIndex = 1;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(754, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(189, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "ASEAN Skills 2020\r\n";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Maroon;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 467);
            this.panel2.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(995, 76);
            this.panel2.TabIndex = 9;
            // 
            // btnViewPackages
            // 
            this.btnViewPackages.Location = new System.Drawing.Point(244, 179);
            this.btnViewPackages.Name = "btnViewPackages";
            this.btnViewPackages.Size = new System.Drawing.Size(224, 85);
            this.btnViewPackages.TabIndex = 10;
            this.btnViewPackages.Text = "View Sponsorship Packages";
            this.btnViewPackages.UseVisualStyleBackColor = true;
            this.btnViewPackages.Click += new System.EventHandler(this.btnViewPackages_Click);
            // 
            // btnAddPackages
            // 
            this.btnAddPackages.Location = new System.Drawing.Point(543, 179);
            this.btnAddPackages.Name = "btnAddPackages";
            this.btnAddPackages.Size = new System.Drawing.Size(224, 85);
            this.btnAddPackages.TabIndex = 11;
            this.btnAddPackages.Text = "Add Sponsorship Pacakges";
            this.btnAddPackages.UseVisualStyleBackColor = true;
            this.btnAddPackages.Click += new System.EventHandler(this.btnAddPackages_Click);
            // 
            // btnApproveBookings
            // 
            this.btnApproveBookings.Location = new System.Drawing.Point(244, 293);
            this.btnApproveBookings.Name = "btnApproveBookings";
            this.btnApproveBookings.Size = new System.Drawing.Size(224, 85);
            this.btnApproveBookings.TabIndex = 12;
            this.btnApproveBookings.Text = "Approve Sponsorship Bookings";
            this.btnApproveBookings.UseVisualStyleBackColor = true;
            this.btnApproveBookings.Click += new System.EventHandler(this.btnApproveBookings_Click);
            // 
            // btnViewSummary
            // 
            this.btnViewSummary.Location = new System.Drawing.Point(543, 293);
            this.btnViewSummary.Name = "btnViewSummary";
            this.btnViewSummary.Size = new System.Drawing.Size(224, 85);
            this.btnViewSummary.TabIndex = 13;
            this.btnViewSummary.Text = "View Sponsorship Summary";
            this.btnViewSummary.UseVisualStyleBackColor = true;
            this.btnViewSummary.Click += new System.EventHandler(this.btnViewSummary_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(339, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(287, 23);
            this.label2.TabIndex = 14;
            this.label2.Text = "Sponsor Manager Main Menu";
            // 
            // ManagerMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(995, 543);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnViewSummary);
            this.Controls.Add(this.btnApproveBookings);
            this.Controls.Add(this.btnAddPackages);
            this.Controls.Add(this.btnViewPackages);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "ManagerMain";
            this.Text = "Manager Main";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnViewPackages;
        private System.Windows.Forms.Button btnAddPackages;
        private System.Windows.Forms.Button btnApproveBookings;
        private System.Windows.Forms.Button btnViewSummary;
        private System.Windows.Forms.Label label2;
    }
}