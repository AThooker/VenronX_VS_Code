using System;

namespace CustomExceptions
{
    public class DoNotExceedRedline : Exception
    {
        public DoNotExceedRedline(int redlineValue)
        :base(String.Format("Do not exceed the suggested rpm: " + redlineValue))
        {
            Console.WriteLine(Message);
        }
    }
}
