namespace VenronX_Gauges
{
    //"flow meter" to measure electrical current flow to/from the battery
    class Ammeter : Gauge
    {
        //typical amperage is ~ 30 - 75 amps
        //holds min and max values

        public int MaxAmps
        {
            get { return Max; }
            set { Max = value; }
        }
    }
}