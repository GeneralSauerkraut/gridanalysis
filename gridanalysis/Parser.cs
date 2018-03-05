using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace gridanalysis
{
    class Parser
    {
        public double[,] inertia;
        public double[,] y;

        public Parser()
        {
            inertia = ReadCSV(@"C:\Ginger\inertia.csv");
            y = ReadCSV(@"C:\Ginger\invaxis.csv");
        }

        public double[,] ReadCSV(string file)
        {
            string[] lines = File.ReadAllLines(file);

            string[][] parts = new string[lines.Length][];

            for (int i = 0; i < lines.Length; i++)
            {
                parts[i] = lines[i].Split(';');
            }

            double[,] ret = new double[15,15];

            for(int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    ret[i, j] = Convert.ToDouble(parts[i][j]);
                }
            }
            return ret;
        }
    }
}
