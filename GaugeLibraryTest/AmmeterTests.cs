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
            _ammeter.Max = 30;
            Assert.AreEqual(30, _ammeter.MaxAmps, "values unequal, make sure your Max and MaxAmps are transferable");
        }
    }
}