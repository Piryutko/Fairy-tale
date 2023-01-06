using System;
using FairyTale;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FairyTaleTests
{
    [TestClass]
    public class NutcrackerTests
    {
        private Nutcracker _nutcracker;

        [TestInitialize]
        public void NutcrackerInitialize()
        {
            _nutcracker = new Nutcracker();

        }

        [TestMethod]
        public void NutcrackerDie_ShouldDie()
        {
            //act
            _nutcracker.Die();

            //validation
            var expectedResult = false;

            Assert.AreEqual(expectedResult, _nutcracker.Live);
        }

    }
}
