using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benzetim4
{
    class Rassal
    {
        public int CDSure { get; set; }
        public int GAS { get; set; }
        Random rnd = new Random();
        public void CDSureCek()
        {
            double rassal;

            rassal = rnd.NextDouble();
            if (rassal >= 0 && rassal <= 0.05)
            {
                CDSure = 6;
            }
            if (rassal > 0.05 && rassal <= 0.25)
            {
                CDSure = 7;
            }
            if (rassal > 0.25 && rassal <= 0.50)
            {
                CDSure = 8;
            }
            if (rassal > 0.50 && rassal <= 0.80)
            {
                CDSure = 9;
            }
            if (rassal > 0.8 && rassal <= 1)
            {
                CDSure = 10;
            }
        }
        public void GASCek()
        {

            double rassal;

            rassal = rnd.NextDouble();
            if (rassal >= 0 && rassal <= 0.40)
            {
                GAS = 3;
            }
            if (rassal > 0.40 && rassal <= 0.75)
            {
                GAS = 4;
            }
            if (rassal > 0.75 && rassal <= 0.9)
            {
                GAS = 5;
            }
            if (rassal > 0.90 && rassal <= 1)
            {
                GAS = 6;
            }

        }
    }
}

