namespace TPQR_Session2_31_8
{
    partial class AddPackages
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpload = new System.Windows.Forms.Button();
            this.cbTier = new System.Windows.Forms.ComboBox();
            this.txtPackageName = new System.Windows.Forms.TextBox();
            this.nudValue = new System.Windows.Forms.NumericUpDown();
            this.nudQuantity = new System.Windows.Forms.NumericUpDown();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cbOnline = new System.Windows.Forms.CheckBox();
            this.cbFlyer = new System.Windows.Forms.CheckBox();
            this.cbBanner = new System.Windows.Forms.CheckBox();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Maroon;
            this.panel1.Controls.Add(this.btnBack);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(8, 6, 8, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1093, 98);
            this.panel1.TabIndex = 10;
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(14, 20);
            this.btnBack.Margin = new System.Windows.Forms.Padding(5);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(161, 51);
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
            this.label1.Location = new System.Drawing.Point(848, 30);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(231, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "ASEAN Skills 2020\r\n";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label2.Location = new System.Drawing.Point(392, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(310, 29);
            this.label2.TabIndex = 11;
            this.label2.Text = "Add Sponsorship Packages";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(268, 174);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 25);
            this.label3.TabIndex = 12;
            this.label3.Text = "Tier: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(168, 239);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(157, 25);
            this.label4.TabIndex = 13;
            this.label4.Text = "Package Name: ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(251, 301);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 25);
            this.label5.TabIndex = 14;
            this.label5.Text = "Value: ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(156, 358);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(169, 25);
            this.label6.TabIndex = 15;
            this.label6.Text = "Amount Quantity: ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(167, 419);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(158, 25);
            this.label7.TabIndex = 16;
            this.label7.Text = "Filter By Benefit: ";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(312, 473);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(139, 51);
            this.btnClear.TabIndex = 17;
            this.btnClear.Text = "Clear Form";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(499, 473);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(139, 51);
            this.btnAdd.TabIndex = 18;
            this.btnAdd.Text = "Add Package";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnUpload
            // 
            this.btnUpload.Location = new System.Drawing.Point(622, 558);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(131, 36);
            this.btnUpload.TabIndex = 19;
            this.btnUpload.Text = "Upload";
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // cbTier
            // 
            this.cbTier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTier.FormattingEnabled = true;
            this.cbTier.Location = new System.Drawing.Point(331, 171);
            this.cbTier.Name = "cbTier";
            this.cbTier.Size = new System.Drawing.Size(217, 33);
            this.cbTier.TabIndex = 20;
            // 
            // txtPackageName
            // 
            this.txtPackageName.Location = new System.Drawing.Point(331, 236);
            this.txtPackageName.Name = "txtPackageName";
            this.txtPackageName.Size = new System.Drawing.Size(382, 30);
            this.txtPackageName.TabIndex = 21;
            // 
            // nudValue
            // 
            this.nudValue.Location = new System.Drawing.Point(331, 299);
            this.nudValue.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.nudValue.Name = "nudValue";
            this.nudValue.Size = new System.Drawing.Size(120, 30);
            this.nudValue.TabIndex = 22;
            // 
            // nudQuantity
            // 
            this.nudQuantity.Location = new System.Drawing.Point(331, 356);
            this.nudQuantity.Name = "nudQuantity";
            this.nudQuantity.Size = new System.Drawing.Size(120, 30);
            this.nudQuantity.TabIndex = 23;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Maroon;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 604);
            this.panel2.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1093, 76);
            this.panel2.TabIndex = 24;
            // 
            // cbOnline
            // 
            this.cbOnline.AutoSize = true;
            this.cbOnline.Location = new System.Drawing.Point(331, 418);
            this.cbOnline.Name = "cbOnline";
            this.cbOnline.Size = new System.Drawing.Size(91, 29);
            this.cbOnline.TabIndex = 25;
            this.cbOnline.Text = "Online";
            this.cbOnline.UseVisualStyleBackColor = true;
            this.cbOnline.CheckedChanged += new System.EventHandler(this.cbOnline_CheckedChanged);
            // 
            // cbFlyer
            // 
            this.cbFlyer.AutoSize = true;
            this.cbFlyer.Location = new System.Drawing.Point(428, 418);
            this.cbFlyer.Name = "cbFlyer";
            this.cbFlyer.Size = new System.Drawing.Size(77, 29);
            this.cbFlyer.TabIndex = 26;
            this.cbFlyer.Text = "Flyer";
            this.cbFlyer.UseVisualStyleBackColor = true;
            this.cbFlyer.CheckedChanged += new System.EventHandler(this.cbFlyer_CheckedChanged);
            // 
            // cbBanner
            // 
            this.cbBanner.AutoSize = true;
            this.cbBanner.Location = new System.Drawing.Point(511, 418);
            this.cbBanner.Name = "cbBanner";
            this.cbBanner.Size = new System.Drawing.Size(97, 29);
            this.cbBanner.TabIndex = 27;
            this.cbBanner.Text = "Banner";
            this.cbBanner.UseVisualStyleBackColor = true;
            this.cbBanner.CheckedChanged += new System.EventHandler(this.cbBanner_CheckedChanged);
            // 
            // txtFilePath
            // 
            this.txtFilePath.Location = new System.Drawing.Point(322, 561);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Size = new System.Drawing.Size(294, 30);
            this.txtFilePath.TabIndex = 28;
            this.txtFilePath.DoubleClick += new System.EventHandler(this.txtFilePath_DoubleClick);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(226, 564);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(99, 25);
            this.label8.TabIndex = 29;
            this.label8.Text = "File Path: ";
            // 
            // AddPackages
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1093, 680);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtFilePath);
            this.Controls.Add(this.cbBanner);
            this.Controls.Add(this.cbFlyer);
            this.Controls.Add(this.cbOnline);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.nudQuantity);
            this.Controls.Add(this.nudValue);
            this.Controls.Add(this.txtPackageName);
            this.Controls.Add(this.cbTier);
            this.Controls.Add(this.btnUpload);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "AddPackages";
            this.Text = "Add Packages";
            this.Load += new System.EventHandler(this.AddPackages_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.ComboBox cbTier;
        private System.Windows.Forms.TextBox txtPackageName;
        private System.Windows.Forms.NumericUpDown nudValue;
        private System.Windows.Forms.NumericUpDown nudQuantity;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox cbOnline;
        private System.Windows.Forms.CheckBox cbFlyer;
        private System.Windows.Forms.CheckBox cbBanner;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.Label label8;
    }
}