using System;
using CustomExceptions;

namespace VenronX_Gauges
{
    class OilPressure : Gauge
    {
        //measured in psi
        //10-15 psi at idle, 30-40 psi at drive (on avg)
        public int Pressure { get; set; }
        public override int Max { get; set; } = 45;
        public Tuple<int, int> OilPressureMinMax
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