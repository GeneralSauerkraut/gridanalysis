using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gridanalysis
{
    public partial class Form1 : Form
    {
        AnalysisRefactored refanal = new AnalysisRefactored();
        public Form1()
        {
            InitializeComponent();
            refanal.AddRib(500);
            refanal.AddRib(200);
            foreach (int item in refanal.ribs)
            {
                if(item != 0||item != 1500)
                    listView1.Items.Add(Convert.ToString(item));
            }
        }

        #region old
        Analysis anal = new Analysis();

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            anal.Addnode(new int[] { Convert.ToInt32(tbi.Text), Convert.ToInt32(tbj.Text) }, Convert.ToInt32(tbend.Text));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            anal.Clearwalls();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            anal.AddStrbot(Convert.ToInt32(tbpos.Text), Convert.ToInt32(tbcount.Text));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            anal.ClrStrbot();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            anal.GetSomeArrays();
            anal.GetStress(Convert.ToInt32(tbf.Text));
            anal.GetSfactor();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            anal.DumpArray(anal.stress, "stress");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            anal.DumpArray(anal.sigmabckl, "bckl");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            anal.DumpArray(anal.walls, "walls");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            anal.DumpArray(anal.sfactor, "sfactor");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            anal.DumpArray(anal.designguide, "design");
        }

        private void tbf_TextChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }
        #endregion
    }
}
