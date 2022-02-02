using System;
using CustomExceptions;

namespace VenronX_Gauges
{
    class OilPressure : Gauge
    {
        //measured in psi
        //10-15 psi at idle, 30-40 psi at drive (on avg)
        private int _pressure;
        public int Pressure
        {
            get
            {
                return _pressure;
            }
            set
            {
                if(value >= 45)
                {
                    throw new OilPressureAtMaxException(Max);
                }
                _pressure = value;
            }
        }
        public override int Max { get; set; } = 45;
        public Tuple<int, int> OilPressureMinMax
        {
            get
            {
                return Tuple.Create(Min, Max);
            }
        }

        //Method to test pressure against max

        // public void WarnsEngineToShutDown()
        // {
        //     if(Pressure >= Max)
        //     {
        //         throw new OilPressureAtMaxException(Max);
        //     }
        // }
    }
}