using System;
using CustomExceptions;

namespace VenronX_Gauges
{
    public class OilPressure
    {
        //measured in psi
        //10-15 psi at idle, 30-40 psi at drive (on avg)
        public int Pressure 
        {
            get{return Pressure;}
            set{
                try
                {
                     Pressure = value;
                     if(value >= max)
                     {
                         throw new OilPressureAtMaxException(max);
                     }
                }
                catch (OilPressureAtMaxException)
                {
                    
                    Console.WriteLine("Oil Pressure too high, engine shutting down");
                }
            }
        }
        private int min = 5;
        private int max = 65;
        public Tuple<int, int> OilPressureMinMax
        {
            get
            {
                return Tuple.Create(min, max);
            }
        }
        public int Min { get; set; }
        public int Max { get; set; }
        public Tuple<int, int> UserOilPressureMinMax
        {
            get
            {
                return Tuple.Create(Min, Max);
            }
        }
        public void WarnsEngineToShutDown()
        {
            if(Pressure >= Max)
            {
                throw new OilPressureAtMaxException(Max);
            }
        }
    }
}