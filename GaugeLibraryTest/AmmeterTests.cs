using Microsoft.VisualStudio.TestTools.UnitTesting;
using VenronX_Gauges;

namespace GaugeLibraryTest
{
    [TestClass]
    public class AmmeterTests
    {
        Ammeter _ammeter;
        [TestInitialize]
        public void TestInitialize()
        {
            _ammeter = new Ammeter();
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
    }
}