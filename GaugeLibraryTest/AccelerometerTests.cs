using System;
using System.Linq;
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

        //test acceleration value
        [TestMethod]
        public void TestAccelerationValueIsCorrect()
        {
            //Arrange
            //set end velocity
            //Act
            //call acceleration method
            var accelerationValue = _acc.GettingNewAcceleration();
            //Assert
            //test piece by piece if necessary
            Assert.IsTrue(_acc.HighestAccelerations.Count > 0);
        }
        //test fastest acceleration saved for later eval
        [TestMethod]
        public void TestFastestAccelerationStored()
        {
            var accelerationValueOne = _acc.GettingNewAcceleration();
            var accelerationValueTwo = _acc.GettingNewAcceleration();
            var highestAccel = _acc.HighestAccelerations.Max();
            Assert.IsTrue(_acc.HighestAccelerations.Contains(highestAccel));
        }
    }
}