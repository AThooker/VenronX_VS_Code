using System;

namespace VenronX_Gauges
{
    public class Accelerometer
    {
        private double fastestAccel;
        public DateTime Start
        {
            get
            {
                return DateTime.Now;
            }
        }
        public DateTime End
        {
            get
            {
                return DateTime.Now;
            }
        }
        public double TimeFromStartToEnd
        {
            get
            {
                TimeSpan secondsOfAccel = End - Start;
                return secondsOfAccel.TotalSeconds;
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
          if(acceleration > fastestAccel)
          {
              fastestAccel = acceleration;
          }  
          return Math.Round(acceleration, 3);
        }

    }
}