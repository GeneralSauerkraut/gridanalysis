using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace gridanalysis
{
    class ArrayDumper
    {
        public static void DumpArray(double[,] data, string nname)
        {
            string name = @"C:\Ginger\" + nname + ".csv";

            using (StreamWriter file = new StreamWriter(name))
            {
                for (int i = 0; i < data.GetLength(0); i++)
                {
                    for (int j = 0; j < data.GetLength(1); j++)
                    {
                        file.Write(Convert.ToString(data[i, j]) + ',');
                    }
                    file.Write(Environment.NewLine);
                }
            }
        }

        public static void DumpArray(int[,] data, string nname)
        {
            string name = @"C:\Ginger\" + nname + ".csv";

            using (StreamWriter file = new StreamWriter(name))
            {
                for (int i = 0; i < data.GetLength(0); i++)
                {
                    for (int j = 0; j < data.GetLength(1); j++)
                    {
                        file.Write(Convert.ToString(data[i, j]) + ',');
                    }
                    file.Write(Environment.NewLine);
                }
            }
        }
    }
}
