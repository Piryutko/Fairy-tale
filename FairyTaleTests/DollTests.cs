using System.Collections.Generic;
using FairyTale;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FairyTaleTests
{
    [TestClass]
    public class DollTests
    {
        private IDollStorage _dollStorage;
        private List<string> _dollNames;
        private string _dollName;


        [TestInitialize]
        public void DollInitialize()
        {
             _dollName = "TestDoll";
            _dollStorage = new DollStorage();

            _dollNames = new List<string>();
            _dollNames.Add(_dollName);
            _dollStorage.AddGingerbreadDolls(_dollNames);
        }

        [TestMethod]
        public void ExecuteMovement_ShouldCorrectlyExecuteMovement()
        {
            //prepare
            var doll = _dollStorage.GetDoll(_dollName);

            //act
            doll.ExecuteMovement(MovementType.Dance);

            //validation
            var expectedMovement = MovementType.Dance;

            Assert.AreEqual(expectedMovement, doll.Movement);
        }

        [TestMethod]
        public void ChangeLocation_ShouldCorrectlyChangeLocation()
        {
            //prepare
            var doll = _dollStorage.GetDoll(_dollName);

            //act
            doll.ChangeLocation(LocationType.Table);

            //validation
            var expectedLocation = LocationType.Table;

            Assert.AreEqual(expectedLocation, doll.Location);
        }

    }
}
