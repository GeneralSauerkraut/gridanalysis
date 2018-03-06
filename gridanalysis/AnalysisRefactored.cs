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
         * First all the relevant arrays are defined
         * */
        static int sizex = 1500;
        static int sizey = 400;

        private bool[,] walls = new bool[sizey + 1, sizex + 1];
        private int[] n_of_botstringers;

        private List<Stringer> topstringers;
        private List<Stringer> botstringers;
        private List<int> ribs;

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
