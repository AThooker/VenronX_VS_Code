using System;
using System.Threading;
using CustomExceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VenronX_Gauges;

namespace GaugeLibraryTest
{
    [TestClass]
    public class SpeedometerTests
    {
        Speedometer _speed;

        [TestInitialize]
        public void TestInitialize()
        {
            _speed = new Speedometer();
        }

        //***SPEEDOMETER TESTS***//

        //test each value, then the return of both in tuple property
        [TestMethod]
        public void GettingMinMaxSpeedShouldPassWithoutUser()
        {
            Assert.AreEqual(_speed.SpeedometerMinMax.Item1, 0);
            Assert.AreEqual(_speed.SpeedometerMinMax.Item2, 200, "Values are not equal");
            Assert.AreEqual(_speed.SpeedometerMinMax, new Tuple<int,int>(0,200), "Values are not equal");
        }
        //test user setting values then returning min/max
        [TestMethod]
        public void UserSettingMinMaxSpeedometer()
        {
            _speed.Max = 250;
            var minMax = _speed.SpeedometerMinMax;
            Assert.AreEqual(minMax, new Tuple<int, int>(0,250));
        }
        [TestMethod]
        public void GettingMinMaxShouldFail()
        {
            Assert.AreNotEqual(_speed.SpeedometerMinMax, new Tuple<int, int>(0, 150), "Values are equal, fail");
        } 
    }
}
