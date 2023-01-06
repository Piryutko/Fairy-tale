using FairyTale;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FairyTaleTests
{
    [TestClass]
    public class CandieStorageTests
    {
        private ICandyStorage _candieStorage;

        [TestInitialize]
        public void CandiesStorageInitialize()
        {
            _candieStorage = new CandyStorage();
        }


        [TestMethod]
        public void AddCandy_ShouldAddCandy()
        {
            //prepare
            var testName = "test";
            var name = new List<string>() { testName };

            //act
            _candieStorage.AddCandy(name);

            //validation
            var expectedCandyCount = 1;
            var expectedName = testName;

            Assert.AreEqual(expectedCandyCount, _candieStorage.GetAllCandies().Count);
            Assert.AreEqual(expectedName, _candieStorage.GetAllCandies().Single(c => c.Name == "test").Name);
        }

        [TestMethod]
        public void GetAllCandies_ShouldGetCandies()
        {
            //prepare
            var testName = "test";
            var name = new List<string>() { testName, testName };

            //act
            _candieStorage.AddCandy(name);

            //validation
            var expectedCandyCount = 2;
            var expectedName = testName;

            Assert.AreEqual(expectedCandyCount, _candieStorage.GetAllCandies().Count);

            foreach (var candy in _candieStorage.GetAllCandies())
            {
                Assert.AreEqual(expectedName, candy.Name); 
            }
        }

        [TestMethod]
        public void DeleteAllCandies_ShouldDeleteCandies()
        {
            //prepare
            var names = new List<string>() { "test" };

            _candieStorage.AddCandy(names);

            //act
            _candieStorage.DeleteAllCandies();

            //validation
            var expectedCandyCount = 0;

            Assert.AreEqual(expectedCandyCount, _candieStorage.GetAllCandies().Count);
        }

        [TestMethod]
        public void AddEmptyName_ThrowExeption()
        {
            //prepare
            var name = new List<string>() { string.Empty };

            //act
            var result = Assert.ThrowsException<ArgumentException>(() => _candieStorage.AddCandy(name));

            //validation
            var expectedMessage = "The string can't be empty or consist of only whitespace characters.";

            Assert.AreEqual(expectedMessage, result.Message);
        }

    }
}
