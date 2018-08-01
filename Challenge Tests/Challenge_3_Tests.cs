using System;
using Challenge_3;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Challenge_Tests
{
    [TestClass]
    public class Challenge_3_Tests
    {
        private OutingsRepository _outingsList;
        private OutingsRepository _totalCostList;


        [TestInitialize]
        public void Arrange()
        {
            _outingsList = new OutingsRepository();
            _totalCostList = new OutingsRepository();
        }

        [TestMethod]
        public void OutingsRepository_AddToList_ShouldIncreaseCountByOne()
        {
            Outings royalPin = new Outings(EventType.Bowling, 15, "6/23/2018", 23.00m, 345.0m);
            _outingsList.AddToList(royalPin);

            var actual = _outingsList.GetList().Count;
            var expected = 1;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void OutingsRepository_AddToCostList_ShouldIncreaseCountByOne()
        {
            Outings royalPin = new Outings(EventType.Bowling, 15, "6/23/2018", 23.00m, 345.0m);
            _totalCostList.AddToCostList(royalPin.TotalEventCost);

            var actual = _totalCostList.GetDecimalList().Count;
            var expected = 1;

            Assert.AreEqual(expected, actual);
        }


    }
}
