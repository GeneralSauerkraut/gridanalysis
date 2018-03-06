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
            CBStrBotAdd1.Items.Clear();
            CBStrBotAdd2.Items.Clear();

            foreach (int item in Analysis.ReturnRibs())
            { 
                LVRibs.Items.Add(Convert.ToString(item));
                LVRibsOver.Items.Add(Convert.ToString(item));
                CBRibs.Items.Add(Convert.ToString(item));
                CbRibStr1.Items.Add(Convert.ToString(item));
                CbRibStr2.Items.Add(Convert.ToString(item));
                CBStrBotAdd1.Items.Add(Convert.ToString(item));
                CBStrBotAdd2.Items.Add(Convert.ToString(item));
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
            CBStrTopRemove.Items.Clear();

            foreach (Stringer item in Analysis.ReturnTopStringers())
            {
                string str = Convert.ToString(item.vert) +", "+ Convert.ToString(item.start) + ", " + Convert.ToString(item.end) ;

                LVStrTop.Items.Add(str);
                LVStrTopOver.Items.Add(str);
                CBStrTopRemove.Items.Add(str);
            }
        }

        private void BtStrTopRemove_Click(object sender, EventArgs e)
        {
            String strtemp = CBStrTopRemove.Text;
            strtemp.Replace(" ", String.Empty);
            string[] words = strtemp.Split(',');

            int[] data = new int[3];
            for (int i = 0; i < data.Length; i++)
                data[i] = Convert.ToInt32(words[i]);

            Analysis.RemoveTopStringer(100, 0, 1500);

            UpdateTopStr();
        }

        private void BtStrBotAdd_Click(object sender, EventArgs e)
        {
            Analysis.AddBotStringer(Convert.ToInt32(CBStrBotAdd1.Text), Convert.ToInt32(CBStrBotAdd2.Text));
            UpdateStrBot();
        }

        private void UpdateStrBot()
        {
            LVStrBot.Items.Clear();
            LVStrBotOver.Items.Clear();

            foreach (Stringer item in Analysis.ReturnBotStringers())
            {
                string str = Convert.ToString(item.start) + ", " + Convert.ToString(item.end);

                LVStrBot.Items.Add(str);
                LVStrBotOver.Items.Add(str);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Analysis.Calculate(Convert.ToInt32(TbForce.Text));
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Analysis = new AnalysisRefactored();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ArrayDumper.DumpArray(Analysis.ReturnStress(), "stress");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ArrayDumper.DumpArray(Analysis.ReturnBckling(), "bckl");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ArrayDumper.DumpArray(Analysis.ReturnSfactor(), "sfactor");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ArrayDumper.DumpArray(Analysis.ReturnDesignGuide(), "design");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ArrayDumper.DumpArray(Analysis.ReturnWalls(), "walls");
        }
    }
}
