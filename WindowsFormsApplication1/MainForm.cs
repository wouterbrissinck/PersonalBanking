using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BankTest
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.categoriesTableAdapter.Fill(this.bankTestDataSet.Categories);
        }

        private void categoriesBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }



    }
}
