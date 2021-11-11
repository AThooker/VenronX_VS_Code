using System;

namespace CustomExceptions
{
    public class OilPressureAtMaxException : Exception
    {
        public OilPressureAtMaxException(int pressureMax)
        :base(string.Format("Engine software will shut down, oil pressure over max value: " + pressureMax))
        {
            Console.WriteLine("Engine shutting down");
        }
    }
}