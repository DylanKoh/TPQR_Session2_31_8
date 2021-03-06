﻿using System;
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
    public partial class SponsorMain : Form
    {
        User _user;
        public SponsorMain(User user)
        {
            InitializeComponent();
            _user = user;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Hide();
            (new LoginForm()).ShowDialog();
            Close();
        }

        private void btnBook_Click(object sender, EventArgs e)
        {
            Hide();
            (new BookPackages(_user)).ShowDialog();
            Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Hide();
            (new UpdateBookings(_user)).ShowDialog();
            Close();
        }
    }
}
