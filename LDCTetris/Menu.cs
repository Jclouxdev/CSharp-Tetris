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
        public Menu()
        {
            InitializeComponent();
            wplayer.URL = "musique.mp3";
            wplayer.controls.play();
        }

        WindowsMediaPlayer wplayer = new WindowsMediaPlayer();

        private void option_Click(object sender, EventArgs e)
        {
            this.Hide();
            option_page option = new option_page();
            option.Show();
            

        }

        private void start_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form = new Form1();
            form.ShowDialog();


        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
