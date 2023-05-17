﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using HotelManagement_ADO.Interface;
using HotelManagement_ADO.DB_Layer;
using HotelManagement_ADO.BS_Layer;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace HotelManagement_ADO
{
    public partial class FormLogin : Form
    {
        BLLogin Login = new BLLogin();
        public FormLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = email.Text;
            string password = userPassword.Text;
            if (Login.CheckLogin(username, password))
            {
                InteractionInterface inter = new InteractionInterface();
                this.Hide();
                inter.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Invalid username or password");
            }
        }
    }
}
