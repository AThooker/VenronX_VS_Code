using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VenronX_Gauges;

namespace GaugeLibraryTest
{
    [TestClass]
    public class AccelerometerTests
    {
        Accelerometer _acc;
        [TestInitialize]
        public void TestInitialize()
        {
            _acc = new Accelerometer();
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