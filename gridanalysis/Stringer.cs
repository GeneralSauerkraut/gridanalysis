using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gridanalysis
{
    class Stringer
    {
        public int vert, start, end;
        
        public Stringer(int verpos, int beginning, int ending)
        {
            vert = verpos;
            start = beginning;
            end = ending;
        }
    }
}
