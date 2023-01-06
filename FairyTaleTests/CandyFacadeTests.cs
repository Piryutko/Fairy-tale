using FairyTale;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace FairyTaleTests
{
    [TestClass]
    public class CandyFacadeTests
    {
        private ICandyFacade _candyFacade;

        private List<string> _dollNames;

        private string _dollName;

        [TestMethod]
        public void CreateCandyFacade_ThrowExeption()
        {
            //act
            var result = Assert.ThrowsException<ArgumentNullException>(() => new CandyFacade(null));

            //validation
            var expectedMessage = "Value can not be null.";
            Assert.AreEqual(expectedMessage, result.Message);
        }

        [TestInitialize]
        public void CandiesFacadeInitialize()
        {
            _candyFacade = new CandyFacade(new CandyStorage());
            _dollName = "test";
            _dollNames = new List<string>() { _dollName, _dollName };
        }

        [TestMethod]
        public void AddCandies_ShouldAddCandy()
        {
            //act
            _candyFacade.Add(_dollNames);

            //validation
            var expectedCandyCount = 2;
            var expectedName = _dollName;

            Assert.AreEqual(expectedCandyCount, _candyFacade.GetAllCandies().Count);

            foreach (var candy in _candyFacade.GetAllCandies())
            {
                Assert.AreEqual(expectedName, candy.Name);
            }
        }

        [TestMethod]
        public void GetAllCandies_ShouldAllGetCandies()
        {
            //act
            _candyFacade.Add(_dollNames);

            //validation
            var expectedCandyCount = 2;
            var expectedName = _dollName;

            Assert.AreEqual(expectedCandyCount, _candyFacade.GetAllCandies().Count);

            foreach (var candy in _candyFacade.GetAllCandies())
            {
                Assert.AreEqual(expectedName, candy.Name);
            }
        }

        [TestMethod]
        public void DeleteAllCandies_ShouldDeleteCandies()
        {
            //act
            _candyFacade.DeleteAll();

            //validation
            var expectedCandyCount = 0;

            Assert.AreEqual(expectedCandyCount, _candyFacade.GetAllCandies().Count);
        }

    }

}

