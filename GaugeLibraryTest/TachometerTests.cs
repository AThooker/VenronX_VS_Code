using System;
using CustomExceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VenronX_Gauges;

namespace GaugeLibraryTest
{
    
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
        [TestMethod]
        public void TestTachometerValuesSetByDeveloper()
        {
            //values hard coded at 0,7000,5500
            var minMaxRed = tach.TachometerMinMaxRedline;
            Assert.AreEqual(minMaxRed, new Tuple<int, int, int>(0,7000,5500));
        } 
        //get gauge with user-set min/max/redline
        [TestMethod]
        public void TestTachometerValuesSetByUser()
        {
            tach.TacMin = 50;
            tach.TacMax = 12000;
            tach.TacRedline = 9000;
            Assert.AreEqual(tach.UserTachometerMinMaxRed, new Tuple<int, int, int>(50, 12000, 9000));
        }
        //set rpm > redline and expect custom exception
        [TestMethod]
        [ExpectedException(typeof(DoNotExceedRedline))]
        public void GetExceptionDoNotExceedRedline()
        {
            tach.Rpm = 6000;
            tach.TestRpmAgainstRedline();
        }
        
    }
}