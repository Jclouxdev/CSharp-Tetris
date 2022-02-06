using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;


namespace LDCTetris
{
    public partial class Menu : Form
    {
        private string diff;
        private Boolean clears;
        private int clearValue;
        public Menu()
        {
            InitializeComponent();
            diff = "easy";
            clears = false;
            clearValue = 0;
        }

        private void option_Click(object sender, EventArgs e)
        {
            this.Hide();
            option_page option = new option_page(this);
            option.Show();
            

        }

        private void start_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form = new Form1(diff,clears,clearValue);
            form.ShowDialog();


        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public string getDiff()
        {
            return diff;
        }
        public void setDiff(string str)
        {
            diff = str;
        }
        public Boolean getClears()
        {
            return clears;
        }
        public void setClears(Boolean cl)
        {
            clears = cl;
        }
        public int getClearValue()
        {
            return clearValue;
        }
        public void setClearValue(int clv)
        {
            clearValue = clv;
        }
    }
}
