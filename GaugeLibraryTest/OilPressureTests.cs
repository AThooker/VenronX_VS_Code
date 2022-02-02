using System;
using CustomExceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VenronX_Gauges;

namespace GaugeLibraryTest
{
    [TestClass]
    public class OilPressureTests
    {
        OilPressure _oil;

        [TestInitialize]
        public void TestInitialize()
        {
            _oil = new OilPressure();
        }
        //***OIL PRESSURE TESTS***//

        //get min/max oil pressure
        [TestMethod]
        public void TestOilPressureValues()
        {
            var minMaxOil = _oil.OilPressureMinMax;
            Assert.AreEqual(minMaxOil, new Tuple<int, int>(0, 45));
        }
        //get user set values for min/max oil pressure
        [TestMethod]
        public void TestOilPressureUnequalValues()
        {
            //can set _oil.Max to change the oil pressure max and test the difference
            //oil.Max = 70;
            var userGauge = _oil.OilPressureMinMax;
            Assert.AreNotEqual(userGauge, new Tuple<int, int>(10,60));
        }
        //set pressure > max value and expect custome exception (output engine shutdown)
        [TestMethod]
        [ExpectedException(typeof(OilPressureAtMaxException))]
        public void GetExceptionOilPressureAtMax()
        {
            _oil.Pressure = 80;
            // _oil.WarnsEngineToShutDown();
        }
    }
}