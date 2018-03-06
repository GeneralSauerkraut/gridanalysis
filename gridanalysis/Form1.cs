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
        AnalysisRefactored Analysis = new AnalysisRefactored();
        public Form1()
        {
            InitializeComponent();
            UpdateRibs();
        }

        private void BtAddRib_Click(object sender, EventArgs e)
        {
            Analysis.AddRib(Convert.ToInt32(TBRibAdd.Text));
            UpdateRibs();
        }

        private void UpdateRibs()
        {
            LVRibs.Items.Clear();
            LVRibsOver.Items.Clear();
            CBRibs.Items.Clear();
            CbRibStr1.Items.Clear();
            CbRibStr2.Items.Clear();

            foreach (int item in Analysis.ReturnRibs())
            { 
                LVRibs.Items.Add(Convert.ToString(item));
                LVRibsOver.Items.Add(Convert.ToString(item));
                CBRibs.Items.Add(Convert.ToString(item));
                CbRibStr1.Items.Add(Convert.ToString(item));
                CbRibStr2.Items.Add(Convert.ToString(item));
            }
        }

        private void BtRemoveRib_Click(object sender, EventArgs e)
        {
            Analysis.RemoveRib(Convert.ToInt32(CBRibs.Text));
            UpdateRibs();
        }

        private void BtAddStrTop_Click(object sender, EventArgs e)
        {
            Analysis.AddTopStringer(Convert.ToInt32(TBStrTopVert.Text), Convert.ToInt32(CbRibStr1.Text), Convert.ToInt32(CbRibStr2.Text));
            UpdateTopStr();
        }

        private void UpdateTopStr()
        {
            LVStrTopOver.Items.Clear();
            LVStrTop.Items.Clear();

            foreach (Stringer item in Analysis.ReturnTopStringers())
            {
                string str = Convert.ToString(item.vert) +", "+ Convert.ToString(item.start) + ", " + Convert.ToString(item.end) ;

                LVStrTop.Items.Add(str);
                LVStrTopOver.Items.Add(str);
            }
        }
    }
}
