using FairyTale;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace FairyTaleTests
{
    [TestClass]
    public class ClockTests
    {
        private DateTime _startDateTime;
        private Clock _clock;

        [TestInitialize]
        public void InitializeClock()
        {
            _startDateTime = new DateTime(2001, 01, 01, 01, 01, 01);
            _clock = new Clock(_startDateTime);
        }

        [TestMethod]
        public void AddDay_ShouldAddDay()
        {
            //act
            _clock.AddDay();

            //validation
            var expectedResult = new DateTime(2001, 01, 02, 01, 01, 01);

            Assert.AreEqual(expectedResult, _clock.Show());
        }

    }
}
