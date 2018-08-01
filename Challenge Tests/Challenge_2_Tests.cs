using System;
using Challenge_2;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Challenge_Tests
{
    [TestClass]
    public class Challenge_2_Tests
    {
        private ClaimsRepository _claimsQueue;

        [TestInitialize]
        public void Arrange()
        {
            _claimsQueue = new ClaimsRepository();
        }

        [TestMethod]
        public void ClaimsRepository_AddItemToQueue_ShouldIncreaseCountByOne()
        {
            Claims bob = new Claims(1, TypeOfClaim.Car, "Accident on 65", 500.0m, "7/29/2018", "5/22/2018", false);
            _claimsQueue.AddClaimToQueue(bob);

            //GetClaims method is tested within this method as well.
            var actual = _claimsQueue.GetClaims().Count;
            var expected = 1;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ClaimsRepository_RemoveQueueItem_ShouldDecreaseCountByOne()
        {
            Claims bob = new Claims(1, TypeOfClaim.Car, "Accident on 65", 500.0m, "7/29/2018", "5/22/2018", false);
            Claims sue = new Claims(2, TypeOfClaim.Car, "Flat tire", 125.0m, "7/25/2018", "6/30/2018", true);
            _claimsQueue.AddClaimToQueue(bob);
            _claimsQueue.AddClaimToQueue(sue);

            _claimsQueue.RemoveQueueItem();

            var actual = _claimsQueue.GetClaims().Count;
            var expected = 1;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ClaimsRepository_GetBoolean_ShouldReturnBoolean ()
        {
            //I changed the boolean in the object bob to be true even though it would be false to show the get boolean method generates an accurate boolean.
            Claims bob = new Claims(1, TypeOfClaim.Car, "Accident on 65", 500.0m, "7/29/2018", "5/22/2018", true);
            _claimsQueue.AddClaimToQueue(bob);

            var actual = _claimsQueue.GetBoolean(bob);
            var expected = false;

            Assert.AreEqual(expected, actual);
        }

    }
}
