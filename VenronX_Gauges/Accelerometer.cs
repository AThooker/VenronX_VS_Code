using System;

namespace VenronX_Gauges
{
    public class Accelerometer
    {
        private double fastestAccel;
        public double FastestAccel
        {
            get
            {
                return fastestAccel;
            }
        }
        public DateTime End { get; set; }
        public DateTime Start { get; set; }
        public double TimeFromStartToEnd
        {
            get
            {
                return Math.Round(End.Subtract(Start).TotalSeconds, 0);
            }
        }
        public int StartingVelocity { get; set; } = 0;
        public int EndingVelocity { get; set; }

        // Accleration formula: 
        //A = (EndingV - StartingV) / time
        public double GettingAcceleration()
        {
            var velocityDifference = EndingVelocity - StartingVelocity;
            var acceleration = velocityDifference / TimeFromStartToEnd;
            if (acceleration > fastestAccel)
            {
                fastestAccel = acceleration;
            }
            return Math.Round(acceleration, 3);
        }

    }
}