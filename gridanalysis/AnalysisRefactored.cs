using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gridanalysis
{
    class AnalysisRefactored
    {
        //TODO: Add a Logfile output
        //TODO: Add dumping functions
        /**<summary>
         * Author: Malte Wegener
         * 
         * This Class represents the Wingbox by abstraction of the former to a Matrix of the upper part
         * Here is some pretty ASCII Art:
         * 
         * *-------x-------->
         * |
         * |  [0,0]_________________________________________[0,1269]
         * y    |                                              \
         * |    |         Wingbox                               \
         * V    |                                                \
         *      |_________________________________________________\
         *   [400,0]                                          [400,1500]
         *      
         * </summary>
         * */

        #region Variables
        /**
         * These are the characteristic defining variables for the Wingbox
         * */
        static int sizex = 1500;
        static int sizey = 400;

        private bool[,] walls = new bool[sizey + 1, sizex + 1];
        private int[] n_of_botstringers;
        private int[] n_of_topstringers;

        private List<Stringer> topstringers;
        private List<Stringer> botstringers;
        private List<int> ribs;

        /**
         * These are all of the calculated Arrays
         * */
        private double[,] ab;
        private double[,] kc;
        private double[,] sigma_buckling;

        private double[,] Inertia;
        private double[,] offset_from_neutral_axis;
        private double[,] Sigma_compression;

        private double[,] Sfactor;
        private int[,] designguide;

        //Material specific Properties
        private static int e_modulus = 72400; //MPa
        private static double thickness = 0.8; //mm
        #endregion

        public AnalysisRefactored()
        {
            ClearWalls();
            InitRibs(false);
            InitTopStringers(false);
            InitBotStringers(true);
        }

        #region ribs
        public void InitRibs(bool recal)
        {
            ribs = new List<int>{0, 1500};
            if(recal) RecalculateWalls();
        }

        public void AddRib(int position)
        {

            if(!ribs.Contains(position))
            {
                ribs.Add(position);
                ribs.Sort();
            }

            RecalculateWalls();
        }

        public void RemoveRib(int position)
        {
            if (ribs.Contains(position) && position != 0 && position != 1500)
                ribs.Remove(position);

            RecalculateWalls();
        }
        #endregion

        #region TopStringers
        public void InitTopStringers(bool recal)
        {
            topstringers = new List<Stringer>();
            if(recal) RecalculateWalls();
            RecalculateTopStringers();
        }

        public void AddTopStringer(int verticalpos, int start, int end)
        {
            //exceptions for inaccurate user input
            if (end > 1500)
                end = 1500;

            if(start>end)
            {
                int temp = start;
                start = end;
                end = temp;
            }

            if (verticalpos >= sizey || !ribs.Contains(start) || !ribs.Contains(end))
                throw new Exception("Invalid ");

            Stringer TempStr = new Stringer(verticalpos, start, end);

            //Add the Stringer to the List if it doesnt exist yet
            if (!topstringers.Contains(TempStr))
            {
                topstringers.Add(TempStr);
            }

            RecalculateWalls();
            RecalculateTopStringers();
        }

        public void RemoveTopStringer(int verticalpos, int start, int end)
        {
            //exceptions for inaccurate user input
            if (end > 1500)
                end = 1500;

            if (start > end)
            {
                int temp = start;
                start = end;
                end = temp;
            }

            Stringer TempStr = new Stringer(verticalpos, start, end);

            //Add the Stringer to the List if it doesnt exist yet
            if (!topstringers.Contains(TempStr))
            {
                topstringers.Remove(TempStr);
            }

            RecalculateWalls();
            RecalculateTopStringers();
        }

        private void RecalculateTopStringers()
        {
            n_of_topstringers = new int[sizex + 1];

            for(int i = 0; i<walls.GetLength(1);i++)
            {
                /**<remarks>
                 * First we run through the 2d array to count the amount of stringers
                 * if the index is higher or equal to 1269 the previous amount of stringers
                 * If there is a rib present it will be later filled by the value of its right
                 * </remarks>*/
                if (i < 1269)
                {
                    int counter = 0;
                    for (int j = 0; j < walls.GetLength(0); j++)
                        if (walls[j, i]) counter++;
                    if (counter < 200)
                        n_of_topstringers[i] = counter - 2;
                    else
                        n_of_topstringers[i] = 0;
                }
                else
                    n_of_topstringers[i] = n_of_topstringers[i - 1];
            }

            for (int i = 0; i<n_of_topstringers.Length-1; i++)
            {
                if (n_of_topstringers[i] == 0)
                    n_of_topstringers[i] = n_of_topstringers[i + 1];
            }
        }
        #endregion

        #region Walls
        public void RecalculateWalls()
        {
            ClearWalls(); //Clear all walls to get rid of old structures in the Panel

            //add all the stringers on the upper skin Panel
            foreach (Stringer item in topstringers)
            {
                for(int i=item.start; i<=item.end;i++)
                    walls[item.vert, i] = true;
            }

            //add all the ribs on the upper skin panel
            foreach (int item in ribs)
            {
                for (int i = 0; i < walls.GetLength(0); i++)
                    walls[i, item] = true;
            }
        }

        public void ClearWalls()
        {
            /**
             * Draws the outer walls and the 30deg notch on the right end
             * */
            for (int i = 0; i < walls.GetLength(0); i++)
            {
                for (int j = 0; j < walls.GetLength(1); j++)
                {
                    walls[i, j] = false;
                    if (i == 0 || i == sizey || j == 0 || j > 1269 + i * Math.Tan(Math.PI / 6))
                        walls[i, j] = true;
                }
            }
        }
        #endregion

        #region BotStringers
        /**
         * For the Stringers on the bottom side the vertical positions does not matter therefore it is just assumed to be 200mm from the top
         * */
        public void InitBotStringers(bool recal)
        {
            botstringers = new List<Stringer>();
            if (recal) RecalculateBotStringers();
        }

        public void AddBotStringer(int start, int end)
        {
            //MAke the input amore userfriendly also for retards
            if (end > 1500)
                end = 1500;

            if (start > end)
            {
                int temp = start;
                start = end;
                end = temp;
            }

            Stringer tempstringer = new Stringer(200, start, end);

            botstringers.Add(tempstringer);
            RecalculateBotStringers();
        }

        public void RemoveBotStringer(int start, int end)
        {
            //Make the input amore userfriendly also for retards
            if (end > 1500)
                end = 1500;

            if (start > end)
            {
                int temp = start;
                start = end;
                end = temp;
            }

            Stringer tempstr = new Stringer(200, start, end);
            if (botstringers.Contains(tempstr))
            {
                botstringers.Remove(tempstr);
            }

            RecalculateBotStringers();
        }

        public void RecalculateBotStringers()
        {
            n_of_botstringers = new int[sizex + 1];
            for (int i = 0; i<n_of_botstringers.Length;i++)
            {
                n_of_botstringers[i] = 0;
            }

            foreach (Stringer item in botstringers)
            {
                for (int i = item.start; i <= item.end; i++)
                    n_of_botstringers[i]++;
            }
        }
        #endregion

        #region Calculation Management for Multithreading
        //TODO: Multithreading
        public void Calculate(double force)
        {
            RecalculateWalls();
            RecalculateBotStringers();
            RecalculateTopStringers();

            //Left tree
            ab = GetAB();
            kc = GetKc();
            sigma_buckling = GetSigmaBuckle();
            //interpolation
            ab = Interpolatedsmoothing(ab);
            kc = Interpolatedsmoothing(kc);
            sigma_buckling = Interpolatedsmoothing(sigma_buckling);

            //right tree
            Inertia = GetInertia();
            offset_from_neutral_axis = GetOffset();
            Sigma_compression = GetStress(force);
            Sfactor = GetSfactor();
            designguide = GetDesignGuide();

            //truncation
            sigma_buckling = TruncateData(sigma_buckling);
            Sigma_compression = TruncateData(Sigma_compression);
            Sfactor = TruncateData(Sfactor);
            designguide = TruncateData(designguide);
        }
        #endregion

        #region Calculations
        //TODO: There is a way more efficient way to solve this
        private double[,] GetAB()
        {
            /**<summary>
             * This Function returns the quotient of the disatance between ribs and the distance between the stringers
             * </summary>*/
            double[,] data = new double[sizey + 1, sizex + 1];

            //get the real ab values
            for (int i = 0; i < data.GetLength(0); i++)
                for (int j = 0; j < data.GetLength(1); j++)
                    data[i, j] = GetHorizontalSpacing(i, j) / GetVerticalSpacing(i, j);

            /**<remarks>
             * The obtained data is pretty but not very useful
             * Due to the slanted nature of the Wingbox we use the value left of the 
             * elemnt if we are in the slanted part.
             * We also set the truncated part and all "walls" of the wingbox to 0
             * </remarks>*/

            for(int i = 0; i < data.GetLength(0); i++)
            {
                for(int j = 0; j < data.GetLength(1); j++)
                {
                    if (j > 1268)
                        data[i, j] = data[i, j - 1];
                    if (i == 0 || i == sizey || j == 0 || j > 1269 + i * Math.Tan(Math.PI / 6))
                        data[i, j] = 0;
                }
            }

            return data;
        }

        private double[,] GetKc()
        {
            /**<summary>
             * In this function we get the relevant Coefficient of buckling
             * Walls and truncated Parts are still left 0
             * </summary>*/
            double[,] data = new double[sizey + 1, sizex + 1];

            for (int i = 0; i < data.GetLength(0); i++)
            {
                for (int j = 0; j < data.GetLength(1); j++)
                {
                    if (ab[i, j] != 0)
                        data[i, j] = GetKcValue(ab[i, j]);
                    else
                        data[i, j] = 0;
                }
            }

            return data;
        }

        private double[,] GetSigmaBuckle()
        {
            /**<summary>
             * In this functiopn the needed stress for buckling will be calculated
             * Walls and truncated Parts are still set to 0
             * </summary>*/
            double[,] data = new double[sizey + 1, sizex + 1];

            for (int i = 0; i < data.GetLength(0); i++)
            {
                for (int j = 0; j < data.GetLength(1); j++)
                {
                    if (ab[i, j] != 0)
                    {
                        data[i, j] = kc[i, j] * e_modulus * Math.Pow(thickness / GetVerticalSpacing(i, j), 2);
                    }
                }
            }

            return data;
        }

        private double[,] GetInertia()
        {
            double[,] data = new double[sizey + 1, sizex + 1];
            Parser parser = new Parser();

            for(int i = 0; i<data.GetLength(0);i++)
            {
                for(int j = 0; j<data.GetLength(1);j++)
                {
                    data[i, j] = parser.inertia[n_of_topstringers[j], n_of_botstringers[j]];
                }
            }

            return data;
        }

        private double[,] GetOffset()
        {
            double[,] data = new double[sizey + 1, sizex + 1];
            Parser parser = new Parser();

            for (int i = 0; i < data.GetLength(0); i++)
            {
                for (int j = 0; j < data.GetLength(1); j++)
                {
                    data[i, j] = parser.y[n_of_topstringers[j], n_of_botstringers[j]];
                }
            }

            return data;
        }

        private double[,] GetStress(double force)
        {
            double[,] data = new double[sizey + 1, sizex + 1];

            for (int i = 0; i < data.GetLength(0); i++)
            {
                for (int j = 0; j < data.GetLength(1); j++)
                {
                    data[i, j] = force * j / 1000 * offset_from_neutral_axis[i, j] / Inertia[i, j];
                    if (j > 1268) data[i, j] *= 3 / 4;
                }
            }

            return data;
        }

        private double[,] GetSfactor()
        {
            double[,] data = new double[sizey + 1, sizex + 1];

            for (int i = 0; i < data.GetLength(0); i++)
            {
                for (int j = 0; j < data.GetLength(1); j++)
                {
                    if(Sigma_compression[i,j]!=0)
                    {
                        data[i, j] = sigma_buckling[i, j] / Sigma_compression[i, j];
                    }
                    else
                    {
                        data[i, j] = 0;
                    }
                }
            }

            return data;
        }

        private int[,] GetDesignGuide()
        {
            int[,] data = new int[sizey + 1, sizex + 1];

            for (int i = 0; i < data.GetLength(0); i++)
            {
                for (int j = 0; j < data.GetLength(1); j++)
                {
                    if (Sfactor[i, j] < 1)
                        data[i, j] = 0;
                    else if (Sfactor[i,j] < 2.5)
                        data[i, j] = 1;
                    else
                        data[i, j] = 2;
                }
            }

            return data;
        }
        #endregion

        #region Assisting Functions
        private int GetVerticalSpacing(int vert, int hor)
        {
            /**<remarks>
             * I didnt add an Exceptiopn for reaching the end of the array,
             * because when in use the outermost cells wil never be false.
             * </remarks>*/
            int count = 0;
            int pos = vert;
            
            //First we go up with our checker
            while(!walls[pos,hor])
            {
                count++;
                pos--;
            }

            //Then we go down with it(Because You always return the favour ;)
            pos = vert;
            while(!walls[pos,hor])
            {
                count++;
                pos++;
            }

            if (count != 0) return count;
            else return 1;
        }

        private int GetHorizontalSpacing(int vert, int hor)
        {
            /**<remarks>
             * I didnt add an Exceptiopn for reaching the end of the array,
             * because when in use the outermost cells wil never be false.
             * </remarks>*/
            int count = 0;
            int pos = hor;

            //First we go up with our checker
            while (!walls[vert, pos])
            {
                count++;
                pos--;
            }

            //Then we go down with it(Because You always return the favour ;)
            pos = hor;
            while (!walls[vert, pos])
            {
                count++;
                pos++;
            }

            if (count != 0) return count;
            else return 1;
        }

        private double GetKcValue(double nab)
        {
            /**<returns>
             * To get the relevent Coefficient of buckling(Kc) data from the
             * Reader is used.
             * The Graph is approxiamted by the following function
             * The Function is first order continuous
             * kc = {   ab under 0.4:   kc = 7
             *          ab under 0.75:  kc = -2*(ab-0.4)+7
             *          ab above 0.75:  kc = 6.3}
             * </returns>*/

            if (nab < 0.4)
                return 7;
            else if (nab < 0.75)
                return -2 * (nab - 0.4) + 7;
            else
                return 6.3;
        }

        private double[,] Interpolatedsmoothing(double[,] data)
        {
            for (int i = 0; i < data.GetLength(0); i++)
            {
                for (int j = 0; j < data.GetLength(1); j++)
                {
                    if(data[i,j]==0&& j < 1269 + i * Math.Tan(Math.PI / 6))
                    {
                        /**<remarks>
                         * A linear Interpolation method is used. the field taken for this are
                         * positioned in the Form of X with the intersection representing the to interpolating cell
                         * </remarks>*/
                        double[] tmp = new double[] { 0, 0, 0, 0 };

                        if (i - 1 < data.GetLength(0) && j + 1 < data.GetLength(1))
                            tmp[0] = data[i - 1, j + 1];

                        if (i - 1 < data.GetLength(0) && j - 1 < data.GetLength(1))
                            tmp[1] = data[i - 1, j - 1];

                        if (i + 1 < data.GetLength(0) && j - 1 < data.GetLength(1))
                            tmp[2] = data[i + 1, j - 1];

                        if (i + 1 < data.GetLength(0) && j + 1 < data.GetLength(1))
                            tmp[3] = data[i + 1, j + 1];

                        double sum = 0;
                        int counter = 0;

                        for (int k = 0; k<tmp.Length; k++)
                        {
                            if(tmp[k]!=0)
                            {
                                sum += tmp[k];
                                counter++;
                            }
                        }

                        data[i, j] = sum / counter;
                    }
                }
            }

            return data;
        }

        private double[,] TruncateData(double[,] data)
        {
            /**<summary>
             * This function truncates the corner of data for inspection
             * </summary>*/
            for(int i = 0; i<data.GetLength(0);i++)
            {
                for(int j = 0; j<data.GetLength(1);j++)
                {
                    if (j > 1269 + i * Math.Tan(Math.PI / 6))
                        data[i, j] = 0;
                }
            }
            return data;
        }

        private int[,] TruncateData(int[,] data)
        {
            /**<summary>
             * This function truncates the corner of data for inspection
             * </summary>*/
            for (int i = 0; i < data.GetLength(0); i++)
            {
                for (int j = 0; j < data.GetLength(1); j++)
                {
                    if (j > 1269 + i * Math.Tan(Math.PI / 6))
                        data[i, j] = 0;
                }
            }
            return data;
        }
        #endregion

        #region ReturningFunctions
        /**
         * To ensure safe data handling all Variables of This class will be private and can only be Accesed by these Functions
         * */

        public List<int> ReturnRibs()
        {
            return ribs;
        }

        public List<Stringer> ReturnTopStringers()
        {
            return topstringers;
        }

        public List<Stringer> ReturnBotStringers()
        {
            return botstringers;
        }

        #endregion
    }
}
