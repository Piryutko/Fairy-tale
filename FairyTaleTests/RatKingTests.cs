using System.Collections.Generic;
using FairyTale;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FairyTaleTests
{
    [TestClass]
    public class RatKingTests
    {
        private RatKing _ratKing;
        private Nutcracker _nutcracker;
        private GoodMarie _goodMarie;

        [TestInitialize]
        public void RatKingInitialize()
        {
            var dolls = new List<Doll> { new Doll("TestDoll"), new Doll("TestDoll") };

            var candies = new List<Candy> { new Candy("TestCandy"), new Candy("TestCandy") };
            
            _nutcracker = new Nutcracker();
            _ratKing = new RatKing();
            _goodMarie = new GoodMarie(dolls, candies);
        }


        [TestMethod]
        public void ExecuteMovement_ShouldExecuteMovement()
        {
            //act
            _ratKing.ExecuteMovement(MovementType.FlashingEyes);

            //validation
            var expectedResult = MovementType.FlashingEyes;

            Assert.AreEqual(expectedResult, _ratKing.Movement);

        }

        [TestMethod]
        public void ExecuteWhistle_ShouldMarieHear()
        {
            //prapare
            _ratKing.NotifyGoodMarie += _goodMarie.ExecuteMovement;

            //act
            _ratKing.ExecuteMovement(MovementType.Whistling);

            //validation
            var expectedResult = MovementType.Hear;

            Assert.AreEqual(expectedResult, _goodMarie.Movement);

        }

        [TestMethod]
        public void ChangeLocation_ShouldChangeLocation()
        {
            //act
            _ratKing.ChangeLocation(LocationType.Table);

            //validation
            var expectedResult = LocationType.Table;

            Assert.AreEqual(expectedResult, _ratKing.Location);
        }

        [TestMethod]
        public void EatCandies_ShouldCorrectlyEatCandies()
        {
            //prepare
            var candies = new List<Candy>()
            {
                new Candy("TestCandy"),
                new Candy("TestCandy"),
                new Candy("TestCandy"),
                new Candy("Marzipan")
            };

            //act
            _ratKing.EatCandies(candies);

            //validation
            var expectedResult = 3;

            Assert.AreEqual(expectedResult, _ratKing.EatenSweetsCount);
        }

        [TestMethod]
        public void GnawNutcracker_ShouldDieNutcracker()
        {
            //prepare
            _ratKing.GnawNutcracker += _nutcracker.Die;

            //act
            _ratKing.Gnaw(_nutcracker);

            //validation
            var expectedResult = false;

            Assert.AreEqual(expectedResult, _nutcracker.Live);
        }

    }
}
