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

        /**
         * These are the characteristic defining variables for the Wingbox
         * */
        static int sizex = 1500;
        static int sizey = 400;

        private bool[,] walls = new bool[sizey + 1, sizex + 1];
        private int[] n_of_botstringers;

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

        //Material specific Properties
        private static int e_modulus = 72400; //MPa
        private static double thickness = 0.8; //mm

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

                    }
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
