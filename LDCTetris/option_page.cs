using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LDCTetris
{
    public partial class option_page : Form
    {
        Menu menuJeu;
        public option_page(Menu menu)
        {
            menuJeu = menu;
            InitializeComponent();
        }
   
        private void RefreshLabelDiff()
        {
            labelDiff.Text = menuJeu.getDiff().ToUpper();
        }
        private void easy_Click(object sender, EventArgs e)
        {
            menuJeu.setDiff("easy");
            RefreshLabelDiff();
        }

        private void medium_Click(object sender, EventArgs e)
        {
            menuJeu.setDiff("medium");
            RefreshLabelDiff();
        }

        private void hard_Click(object sender, EventArgs e)
        {
            menuJeu.setDiff("hard");
            RefreshLabelDiff();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            menuJeu.Show();
            this.Dispose();
        }

        private void Clear_CheckedChanged(object sender, EventArgs e)
        {
            menuJeu.setClears(!menuJeu.getClears());
        }

        private void ClearPoints_ValueChanged(object sender, EventArgs e)
        {
            menuJeu.setClearValue(Decimal.ToInt16(ClearPoints.Value));
        }
    }
}
