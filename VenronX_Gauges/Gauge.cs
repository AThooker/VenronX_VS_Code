namespace VenronX_Gauges
{
    //every class has a min and max, some have preset Max, all have preset min = 0;
    abstract class Gauge
    {
        public virtual int Max { get; set; }
        public virtual int Min { get; } = 0;
    }
}