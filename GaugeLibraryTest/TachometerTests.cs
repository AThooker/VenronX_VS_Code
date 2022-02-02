using System;
using CustomExceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VenronX_Gauges;

namespace GaugeLibraryTest
{
    [TestClass]
    public class TachometerTests
    {
        Tachometer tach;
        [TestInitialize]
        public void TestInitialize()
        {
            tach = new Tachometer();
        }
        //***TACHOOMETER TESTS***//

        //get gauge with min/max/redline
        //moreso just a test for myself to see if Tuple works this way
        [TestMethod]
        public void TestTachometerValuesSetByDeveloper()
        {
            //testing tuple return int min, int max, int redlineVal
            //values hard coded at 0,7000,5500
            var minMaxRed = tach.TachometerMinMaxRedline;
            Assert.AreEqual(minMaxRed, new Tuple<int, int, int>(0,7000,5500));
        } 
        //set rpm > redline and expect custom exception
        [TestMethod]
        [ExpectedException(typeof(DoNotExceedRedline))]
        public void GetExceptionDoNotExceedRedline()
        {
            Random rnd = new Random();
            tach.Rpm = rnd.Next(5500,7000);
        }
        
    }
}