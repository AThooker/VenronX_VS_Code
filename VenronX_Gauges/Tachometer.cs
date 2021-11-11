using System;
using CustomExceptions;

namespace VenronX_Gauges
{
    public class Tachometer
    {
        public int Rpm { get; set; }
        //Without user input
        private int tacMin = 0;
        private int tacMax = 7000;
        private int tacRedline = 5500;
        public Tuple<int, int, int> TachometerMinMaxRedline
        {
            get
            {
                return Tuple.Create(tacMin, tacMax, tacRedline);
            }
        }

        //User input
        public int TacMin { get; set; }
        public int TacMax { get; set; }
        public int TacRedline { get; set; }
        public Tuple<int, int, int> UserTachometerMinMaxRed
        {
            get
            {
                return Tuple.Create(TacMin, TacMax, TacRedline);
            }
        }

        //Exception if rpm is at or exceed redline value
        public void TestRpmAgainstRedline()
        {
            if(Rpm >= tacRedline)
            {
                throw new DoNotExceedRedline(tacRedline);
            }
        }
    }
}