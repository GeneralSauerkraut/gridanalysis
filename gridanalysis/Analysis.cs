using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace gridanalysis
{
    class Analysis
    {
        static int sizey = 400;
        static int sizex = 1500;
        public double[,] walls = new double[sizey + 1, sizex + 1];
        public double[,] ab = new double[sizey + 1, sizex + 1];
        public double[,] kc = new double[sizey + 1, sizex + 1];
        public double[,] sigmabckl = new double[sizey + 1, sizex + 1];
        public double[,] inertia = new double[sizey + 1, sizex + 1];
        public double[,] y = new double[sizey + 1, sizex + 1];
        public int[,] nbot = new int[1, sizex + 1];
        public double[,] stress = new double[sizey + 1, sizex + 1];
        public double[,] sfactor = new double[sizey + 1, sizex + 1];
        public double[,] designguide = new double[sizey + 1, sizex + 1];

        public Analysis()
        {
            Clearwalls();
            ClrStrbot();
        }

        public void Clearwalls()
        {
            walls = new double[sizey + 1, sizex + 1];
            for (int i = 0; i < walls.GetLength(0); i++)
            {
                for (int j = 0; j < walls.GetLength(1); j++)
                {
                    if (j > 1269 + i * Math.Tan(Math.PI / 6))
                    {
                        walls[i, j] = 1;
                    }

                    if (i == 0 || i == sizey || j == 0)
                    {
                        walls[i, j] = 1;
                    }
                }
            }
        }

        public void Addnode(int[] node, int end)
        {
            if(end<node[1])
            {
                throw new Exception("Stringer cant end before he begun");
            }

            for (int i = 0; i < walls.GetLength(0); i++)
            {
                walls[i, node[1]] = 1;
            }

            for (int j = node[1]; j < end; j++)
            {
                walls[node[0], j] = 1;
            }
        }

        public void AddStrbot(int pos, int count)
        {
            for (int i = pos; i < nbot.GetLength(1); i++)
                nbot[0, i] += count;
        }

        public void ClrStrbot()
        {
            for (int i = 0; i < nbot.GetLength(1); i++)
                nbot[0, i] = 0;
        }

        public void DumpArray(double[,] data, string nname)
        {
            string name= @"C:\Ginger\"+ nname + ".csv";

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

        public void GetSomeArrays()
        {
            for (int i = 0; i < ab.GetLength(0); i++)
            {
                for (int j = 0; j < ab.GetLength(1); j++)
                {
                    ab[i, j] = HoriSpacing(new double[] { i, j }) / VertSpacing(new double[] { i, j });
                    kc[i, j] = Getkc(ab[i, j]);
                    sigmabckl[i, j] = 72400 * kc[i, j] * Math.Pow(0.8 / VertSpacing(new double[] { i, j }),2);
                    if (sigmabckl[i, j] > 120)
                        sigmabckl[i, j] = 120;
                    else if (Math.Abs(sigmabckl[i, j] - 0.252) < 0.01)
                        sigmabckl[i, j] = 0;
                }
            }
        }

        public double VertSpacing(double[] position)
        {
            //go up first
            int y = Convert.ToInt32(position[0]);
            int x = Convert.ToInt32(position[1]);

            int counter = 0;

            while (walls[y, x] != 1)
            {
                y--;
                counter++;
            }

            //go down(not only on her LUL)
            y = Convert.ToInt32(position[0]);
            x = Convert.ToInt32(position[1]);

            while (walls[y, x] != 1)
            {
                y++;
                counter++;
            }

            if (counter != 0)
            {
                return Convert.ToDouble(counter);
            }
            else
            {
                return 1523;
            }
        }

        public double HoriSpacing(double[] position)
        {
            //go Left first
            int y = Convert.ToInt32(position[0]);
            int x = Convert.ToInt32(position[1]);

            int counter = 0;

            while (walls[y, x] != 1)
            {
                x-=1;
                counter++;
            }

            //go Right
            y = Convert.ToInt32(position[0]);
            x = Convert.ToInt32(position[1]);

            while (walls[y, x] != 1)
            {
                x++;
                counter++;
            }

            if (counter != 0)
            {
                return Convert.ToDouble(counter);
            }
            else
            {
                return 1;
            }
        }

        public double Getkc(double nab)
        {
            if (nab == 0.000657)
                return 0;
            else if (nab > 3)
                return 6.3;
            else
                return 6.372 * Math.Exp(-5.322 * nab) + 6.248 * Math.Exp(0.002087 * nab);
        }

        public void GetStress(double Force)
        {
            Parser parser = new Parser();

            int[,] ntop = new int[1, sizex + 1];

            for(int i = 0; i<inertia.GetLength(1);i++)
            {
                if(i<1268)
                {
                    ntop[0, i] = 0;
                    for(int j = 0; j < inertia.GetLength(0);j++)
                    {
                        ntop[0, i] += Convert.ToInt32(walls[j, i]);
                    }
                }
                else
                {
                    ntop[0, i] = ntop[0, i - 1];
                }
            }

            for(int i = 0; i<ntop.GetLength(1); i++)
            {
                if (ntop[0, i] > 200)
                    ntop[0, i] = ntop[0, i + 1];
            }

            for(int i = 0; i< inertia.GetLength(1); i++)
            {
                for(int j = 0; j<inertia.GetLength(0); j++)
                {
                    try
                    {
                        inertia[j, i] = parser.inertia[ntop[0, i], nbot[0, i]];
                        y[j, i] = parser.y[ntop[0, i], nbot[0, i]];
                    }
                    catch
                    {
                        throw new Exception("Make a new Reference Table");
                    }
                }
            }

            for(int i = 0; i<stress.GetLength(0);i++)
            {
                for(int j = 0; j<stress.GetLength(1);j++)
                {
                    stress[i, j] = Force * j / 1000 * y[i, j] / inertia[i, j]/Math.Pow(10,6);
                    if(j>1269)
                    {
                        stress[i, j] *= 4 / 3;
                    }
                    if(j > 1269 + i * Math.Tan(Math.PI / 6))
                    {
                        stress[i, j] = 0;
                    }
                }
            }
        }

        public void GetSfactor()
        {
            double[,] astress = stress;

            for(int i = 0; i<astress.GetLength(0); i++)
            {
                for(int j = 0; j<astress.GetLength(1);j++)
                {
                    if (astress[i, j] < 2)
                        astress[i, j] = 2;

                    sfactor[i, j] = sigmabckl[i, j] / astress[i, j];
                }
            }

            GetDesignGuide();
        }

        public void GetDesignGuide()
        {
            for (int i = 0; i < designguide.GetLength(0); i++)
            {
                for (int j = 0; j < designguide.GetLength(1); j++)
                {
                    if (sfactor[i, j] < 1)
                        designguide[i, j] = 0;
                    else if (sfactor[i, j] < 3)
                        designguide[i, j] = 1;
                    else
                        designguide[i, j] = 2;
                }
            }
        }
    }
}

