using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FairyTale;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FairyTaleTests
{
    [TestClass]
    public class FairyTaleFacadeTests
    {
        private IDollStorage _dollStorage;
        private ICandyStorage _candyStorage;
        private ICandyFacade _candyFacade;
        private IFairyTaleFacade _fairyTaleFacade;
        private List<string> _dollNames;
        private string _dollName;

        [TestInitialize]
        public void FairyTaleFacadeInitialize()
        {
            _dollStorage = new DollStorage();
            _candyStorage = new CandyStorage();
            _candyFacade = new CandyFacade(_candyStorage);
            _fairyTaleFacade = new FairyTaleFacade(_dollStorage, _candyFacade);
            _dollName = "Test";
            _dollNames = new List<string> { _dollName };
        }

        [TestMethod]
        public void AddCandy_ShouldAddCandy()
        {
            //act
            _fairyTaleFacade.AddCandies(_dollNames);

            //validation 
            var expectedCandyCount = 1;
            var expectedName = _dollName;

            Assert.AreEqual(expectedCandyCount, _fairyTaleFacade.GetAllCandies().Count);
            Assert.AreEqual(expectedName, _fairyTaleFacade.GetAllCandies().Single().Name);
        }

        [TestMethod]
        public void AddGingerbreadDoll_ShouldAddGingerbreadDoll()
        {
            //act
            _fairyTaleFacade.AddGingerbreadDolls(_dollNames);

            //validation 
            var expectedCandyCount = 1;
            var expectedType = typeof(GingerbreadDoll);
            var expectedName = "Test";

            Assert.AreEqual(expectedCandyCount, _fairyTaleFacade.GetAllDolls().Count);
            Assert.AreEqual(expectedType, _fairyTaleFacade.GetAllDolls().Single().GetType());
            Assert.AreEqual(expectedName, _fairyTaleFacade.GetAllDolls().Single().Name);

        }

        [TestMethod]
        public void AddSugarDoll_ShouldAddSugarDoll()
        {
            //act
            _fairyTaleFacade.AddSugarDolls(_dollNames);

            //validation 
            var expectedCandyCount = 1;
            var expectedType = typeof(SugarDoll);
            var expectedName = "Test";

            Assert.AreEqual(expectedCandyCount, _fairyTaleFacade.GetAllDolls().Count);
            Assert.AreEqual(expectedType, _fairyTaleFacade.GetAllDolls().Single().GetType());
            Assert.AreEqual(expectedName, _fairyTaleFacade.GetAllDolls().Single().Name);
        }


        [TestMethod]
        public void ExecuteMovementDoll_ShouldExecuteMovementDoll()
        {
            //prepare
            var dollName = new List<string>() { "Postman" };
            _fairyTaleFacade.AddSugarDolls(dollName);

            //act
            _fairyTaleFacade.ExecuteMovementDoll(_fairyTaleFacade.GetAllDolls().Single(d => d.Name == dollName.Single()));

            //validation
            var expectedMovement = MovementType.Stand;

            Assert.AreEqual(expectedMovement, _fairyTaleFacade.GetAllDolls().Single(d => d.Name == dollName.Single()).Movement);
        }

        [TestMethod]
        public void GetAllCandy_ShouldGetAllCandy()
        {
            //prepare
            _fairyTaleFacade.AddCandies(_dollNames);

            //act
            var dolls = _fairyTaleFacade.GetAllCandies();

            //validation
            var expectedCount = 1;

            Assert.AreEqual(expectedCount, dolls.Count);
        }

        [TestMethod]
        public void GetAllDolls_ShouldGetAllDolls()
        {
            //prepare
            _fairyTaleFacade.AddGingerbreadDolls(_dollNames);
            _fairyTaleFacade.AddSugarDolls(_dollNames);

            //act
            var doll = _fairyTaleFacade.GetAllDolls();

            //validation
            var expectedDoll = 2;

            Assert.AreEqual(expectedDoll, doll.Count);
        }

    }
}
