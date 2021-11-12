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

    }
}