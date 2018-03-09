using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace gridanalysis
{
    static class Saver
    {
        public static void Save(List<int> Ribs, List<Stringer> Top, List<Stringer> Bot)
        {
            using (StreamWriter file = new StreamWriter(@"C:\Ginger\temp.dsf"))
            {
                foreach (int rib in Ribs)
                {
                    file.WriteLine("R:" + Convert.ToString(rib));
                }

                foreach (Stringer item in Top)
                {
                    file.WriteLine(String.Format("T:{0},{1},{2}", item.vert, item.start, item.end));
                }

                foreach (Stringer item in Bot)
                {
                    file.WriteLine(String.Format("B:{0},{1}", item.start, item.end));
                }
            }
        }

        public static AnalysisRefactored LoadTemp()
        {
            AnalysisRefactored retAnalysis = new AnalysisRefactored();

            String[] Lines = File.ReadAllLines(@"C:\Ginger\temp.dsf");

            for(int i = 0;i<Lines.Length;i++)
            {
                string input = Lines[i];
                int index = input.IndexOf(":");
                if (index > 0)
                    input = input.Substring(0, index);

                if(input=="R"||input=="r")
                {
                    string temp = Lines[i];
                    temp = temp.Substring(index + 1);
                    retAnalysis.AddRib(Convert.ToInt32(temp));
                }

                else if(input=="T"||input=="t")
                {
                    string temp = Lines[i];
                    temp = temp.Substring(index + 1);
                    string[] chars = temp.Split(',');
                    retAnalysis.AddTopStringer(Convert.ToInt32(chars[0]), Convert.ToInt32(chars[1]), Convert.ToInt32(chars[2]));
                }
                else if(input=="B"||input=="b")
                {
                    string temp = Lines[i];
                    temp = temp.Substring(index + 1);
                    string[] chars = temp.Split(',');
                    retAnalysis.AddBotStringer(Convert.ToInt32(chars[0]), Convert.ToInt32(chars[1]));
                }

            }

            return retAnalysis;
        }
    }
}
