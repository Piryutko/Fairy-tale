using System;
using System.Collections.Generic;
using System.Linq;
using FairyTale;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FairyTaleTests
{
    [TestClass]
    public class DollStorageTests
    {
        private IDollStorage _dollStorage;
        private List<string> _dollNames;
        private string _dollName;


        [TestInitialize]
        public void DollStorageInitialize()
        {
            _dollStorage = new DollStorage();
            _dollName = "Test";
            _dollNames = new List<string> { _dollName };
        }

        [TestMethod]
        public void AddGingerbreadDoll_ShouldAddGingerbreadDoll()
        {
            //act
            _dollStorage.AddGingerbreadDolls(_dollNames);

            //validation
            var expectedName = _dollName;
            var expectedDollCount = 1;

            Assert.AreEqual(expectedDollCount, _dollStorage.GetAllDolls().Count);

            Assert.AreEqual(expectedName, _dollStorage.GetAllDolls().Single(d => d.Name == _dollName).Name);
        }

        [TestMethod]
        public void AddSugarDoll_ShouldAddSugarDoll()
        {
            //act
            _dollStorage.AddSugarDolls(_dollNames);

            //validation
            var expectedName = _dollName;
            var expectedDollCount = 1;

            Assert.AreEqual(expectedDollCount, _dollStorage.GetAllDolls().Count);

            Assert.AreEqual(expectedName, _dollStorage.GetAllDolls().Single().Name);
        }

        [TestMethod]
        public void AddEmptyNameSugarDoll_ThrowExeption()
        {
            //prepare
            var names = new List<string> { string.Empty };
            //act
            var result = Assert.ThrowsException<ArgumentException>(() => _dollStorage.AddSugarDolls(names));

            //validation
            var expectedResult = "The string can't be empty or consist of only whitespace characters.";

            Assert.AreEqual(expectedResult, result.Message);

        }

        [TestMethod]
        public void AddEmptyNameGingerbreadDoll_ThrowExeption()
        {
            //prepare
            var names = new List<string> { string.Empty };
            //act
            var result = Assert.ThrowsException<ArgumentException>(() => _dollStorage.AddGingerbreadDolls(names));

            //validation
            var expectedResult = "The string can't be empty or consist of only whitespace characters.";

            Assert.AreEqual(expectedResult, result.Message);

        }
    }
}
