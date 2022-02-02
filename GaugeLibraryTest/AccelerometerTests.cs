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

        //test fastest acceleration saved for later eval
        [TestMethod]
        public void TestFastestAccelerationStored()
        {
            //get first acceleration value
            var accelerationValue = _acc.Accleration;
            //get the max value from acceleration list
            var highestAccel = _acc.HighestAccelerations.Max();
            //assert the list's max value is equal to the new acceleration value since the only other value is 0
            Assert.AreEqual(accelerationValue, highestAccel);
        }
        //test multiple acceleration values
        [TestMethod]
        public void TestMultipleAccelerationsCanBeDifferentForSameObject()
        {
            //get first acceleration value to compare
            var accelValOne = _acc.Accleration;
            //grab second acceleration value
            var accelValTwo = _acc.Accleration;
            //assert they are not equal, VERY small chance they could be equal
            Assert.AreNotEqual(accelValOne, accelValTwo);
        }
    }
}