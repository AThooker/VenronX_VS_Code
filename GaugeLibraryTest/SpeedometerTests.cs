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
        Tachometer _tach;
        Ammeter _ammeter;
        Accelerometer _acc;
        [TestInitialize]
        public void TestInitialize()
        {
            _speed = new Speedometer();
            _tach = new Tachometer();
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


        //***TACHOOMETER TESTS***//

        //get gauge with min/max/redline
        [TestMethod]
        public void TestTachometerValuesSetByDeveloper()
        {
            //values hard coded at 0,7000,5500
            var minMaxRed = _tach.TachometerMinMaxRedline;
            Assert.AreEqual(minMaxRed, new Tuple<int, int, int>(0,7000,5500));
        } 
        //get gauge with user-set min/max/redline
        [TestMethod]
        public void TestTachometerValuesSetByUser()
        {
            _tach.TacMin = 50;
            _tach.TacMax = 12000;
            _tach.TacRedline = 9000;
            Assert.AreEqual(_tach.UserTachometerMinMaxRed, new Tuple<int, int, int>(50, 12000, 9000));
        }
        //set rpm > redline and expect custom exception
        [TestMethod]
        [ExpectedException(typeof(DoNotExceedRedline))]
        public void GetExceptionDoNotExceedRedline()
        {
            _tach.Rpm = 6000;
            _tach.TestRpmAgainstRedline();
        }


        //***OIL PRESSURE TESTS***//

        //get min/max oil pressure
        [TestMethod]
        public void TestOilPressureValues()
        {
            var minMaxOil = _oil.OilPressureMinMax;
            Assert.AreEqual(minMaxOil, new Tuple<int, int>(5, 65));
        }
        //get user set values for min/max oil pressure
        [TestMethod]
        public void TestOilPressureUserSetValues()
        {
            _oil.Min = 10;
            _oil.Max = 70;
            var userGauge = _oil.UserOilPressureMinMax;
            Assert.AreEqual(userGauge, new Tuple<int, int>(10,70));
        }
        //set pressure > max value and expect custome exception (output engine shutdown)
        [TestMethod]
        [ExpectedException(typeof(OilPressureAtMaxException))]
        public void GetExceptionOilPressureAtMax()
        {
            _oil.Pressure = 80;
            _oil.WarnsEngineToShutDown();
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
