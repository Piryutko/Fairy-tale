using System;
using System.Collections.Generic;
using FairyTale;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FairyTaleTests
{
    [TestClass]
    public class GoodMarieTests
    {
        private GoodMarie _goodMarie;

        private List<Doll> _dolls;

        private List<Candy> _candies;

        [TestMethod]
        public void CreateGoodMarie_ThrowExeption()
        {
            //act
            var result = Assert.ThrowsException<ArgumentNullException>(() => new GoodMarie(null, null));

            //validation
            var expectedResult = "Value can not be null.";

            Assert.AreEqual(expectedResult, result.Message);
        }

        [TestInitialize]
        public void GoodMarieInitialize()
        {
            _dolls = new List<Doll>()
            {
                new Doll("DollTest_1"),
                new Doll("DollTest_2"),
                new Doll("DollTest_3")
            };

            _candies = new List<Candy>()
            {
                new Candy("CandyTest_1"),
                new Candy("CandyTest_2"),
                new Candy("CandyTest_3"),
            };

            _goodMarie = new GoodMarie(_dolls, _candies);

        }

        [TestMethod]
        public void ChangeSoulMood_ShouldCorrectlyChangeSoulMood()
        {
            //prepare
            var mood = SoulMoodType.Happy;

            //act
            _goodMarie.ChangeSoulMood(mood);

            //validation
            var expectedMood = SoulMoodType.Happy;

            Assert.AreEqual(expectedMood, _goodMarie.SoulMood);
        }

        [TestMethod]
        [DataRow("Pachter Feldkummel")]
        [DataRow("Maid of Orleans")]
        public void DontReallyLike_ReturnTrue(string name)
        {
            //act
            var result =  _goodMarie.DontReallyLike(name);

            //validation
            var expectedMood = SoulMoodType.Upset;
            var expectedResult = true;

            Assert.AreEqual(expectedResult, result);
            Assert.AreEqual(expectedMood, _goodMarie.SoulMood);
        }

        [TestMethod]
        public void DontReallyLike_ReturnFalse()
        {
            //prepare
            string name = "NameTest";
            //act
            var result = _goodMarie.DontReallyLike(name);

            //validation
            var expectedMood = SoulMoodType.Happy;
            var expectedResult = false;

            Assert.AreEqual(expectedResult, result);
            Assert.AreEqual(expectedMood, _goodMarie.SoulMood);
        }

        [TestMethod]
        public void ReallyLike_ReturnTrue()
        {
            //prepare
            string name = "Red-Cheeked baby";

            //act
            var result = _goodMarie.ReallyLike(name);

            //validation
            var expectedMood = SoulMoodType.Happy;
            var expectedResult = true;

            Assert.AreEqual(expectedResult, result);
            Assert.AreEqual(expectedMood, _goodMarie.SoulMood);
        }

        [TestMethod]
        public void ReallyLike_ReturnFalse()
        {
            //prepare
            string name = "TestDoll";

            //act
            var result = _goodMarie.ReallyLike(name);

            //validation
            var expectedMood = SoulMoodType.Happy;
            var expectedResult = false;

            Assert.AreEqual(expectedResult, result);
            Assert.AreEqual(expectedMood, _goodMarie.SoulMood);
        }

        [TestMethod]
        public void CanGiveAllDolls_ReturnTrue()
        {
            //prepare
            var ratKing = new RatKing();

            //act
            var result = _goodMarie.CanGiveAllDolls(ratKing);

            //validation
            var expectedResult = true;

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void CanGiveAllDolls_ReturnFalse()
        {
            //prepare
            var ratKing = new object();

            //act
            var result = _goodMarie.CanGiveAllDolls(ratKing);

            //validation
            var expectedResult = false;

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void GiveAllCandies_ShouldGiveAllCandies()
        {
            //act
            var candies = _goodMarie.GiveAllCandies();

            //validation
            var expectedCandiesCount = 3;
            var expectedCandiesFromMarie = 0;

            Assert.AreEqual(expectedCandiesFromMarie, _goodMarie.Candies.Count);
            Assert.AreEqual(expectedCandiesCount, candies.Count);
        }

        [TestMethod]
        public void ShowAllDolls_ShouldShowAllDolls()
        {
            //act
            var candies = _goodMarie.ShowAllDolls();

            //validation
            var expectedCandiesCount = 3;

            Assert.AreEqual(expectedCandiesCount, candies.Count);
        }

        [TestMethod]
        public void ExecuteMovement_ShouldExecuteMovement()
        {
            //act
            _goodMarie.ExecuteMovement(MovementType.See);

            //validation
            var expectedResult = MovementType.See;

            Assert.AreEqual(expectedResult, _goodMarie.Movement);
        }

        [TestMethod]
        public void ChangeLocation_ShouldChamgeLocation()
        {
            //act
            _goodMarie.ChangeLocation(LocationType.Wardrobe);

            //validation
            var expectedResult = LocationType.Wardrobe;

            Assert.AreEqual(expectedResult, _goodMarie.Location);
            
        }
    }
}
