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
        Ammeter _ammeter;
        Accelerometer _acc;
        [TestInitialize]
        public void TestInitialize()
        {
            _speed = new Speedometer();
            _ammeter = new Ammeter();
            _acc = new Accelerometer();
        }

        //***SPEEDOMETER TESTS***//

        //test each value, then the return of both in tuple property
        [TestMethod]
        public void GettingMinMaxSpeedShouldPassWithoutUser()
        {
            Assert.AreEqual(_speed.SpeedometerSetMinMax.Item1, 0);
            Assert.AreEqual(_speed.SpeedometerSetMinMax.Item2, 250);
            Assert.AreEqual(_speed.SpeedometerSetMinMax, new Tuple<int,int>(0,250));
        }
        //test user setting values then returning min/max
        [TestMethod]
        public void UserSettingMinMaxSpeedometer()
        {
            _speed.UserSetMax = 200;
            _speed.UserSetMin = 20;
            var minMax = _speed.UserSpeedometerMinMax;
            Assert.AreEqual(minMax, new Tuple<int, int>(20,200));
        }
        //***AMMETER TEST***//

        //getting/setting max amps
        [TestMethod]
        public void GetAndSetMaxAmps()
        {
            _ammeter.MaxAmps = 30;
            var maxAmps = _ammeter.MaxAmps;
            Assert.AreEqual(30, maxAmps);
        }

        //***ACCELEROMETER**//

        //test getting start time vs end time
        [TestMethod]
        public void TestStartTimeAndEndTime()
        {
            _acc.Start = DateTime.Now;
            Thread.Sleep(8000);
            _acc.End = DateTime.Now;
            var timeDiff = _acc.TimeFromStartToEnd;
            //System.Console.WriteLine(start + " " + end);
            Assert.AreEqual(timeDiff, 8);
        }

        //test acceleration value
       [TestMethod]
        public void GetAccelerationValue()
        {
            //Arrange
            //set start/end times
            _acc.Start = DateTime.Now;
            Thread.Sleep(4000);
            _acc.End = DateTime.Now;
            //set end velocity
            _acc.EndingVelocity = 40;
            //Act
            //call acceleration method
            var accelerationValue = _acc.GettingAcceleration();
            //Assert
            //test piece by piece if necessary
            Assert.AreEqual(accelerationValue, 10);
        }
        //test fastest acceleration saved for later eval
        [TestMethod]
        public void TestFastestAccelerationStored()
        {
            _acc.Start = DateTime.Now;
            Thread.Sleep(4000);
            _acc.End = DateTime.Now;
            _acc.EndingVelocity = 40;
            var accelerationValueOne = _acc.GettingAcceleration();

            _acc.Start = DateTime.Now;
            Thread.Sleep(5000);
            _acc.End = DateTime.Now;
            _acc.EndingVelocity = 150;
            var accelerationValueTwo = _acc.GettingAcceleration();

            Assert.IsTrue(_acc.FastestAccel == 30);
        }
    }
}
