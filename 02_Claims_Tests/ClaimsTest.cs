using System;
using System.Collections.Generic;
using _02_Claims_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _02_Claims_Tests
{
    [TestClass]
    public class ClaimsTest
    {
        public void AddClaimToDirectory_Test()
        {
            ClaimsContent firstClaim = new ClaimsContent();
            ClaimsRepository repo = new ClaimsRepository();

            bool addClaim = repo.AddClaimToDirectory(firstClaim);

            Assert.IsTrue(addClaim);
        }
        [TestMethod]
        public void GetDirectory_Test()
        {
            ClaimsContent testClaim = new ClaimsContent();
            ClaimsRepository repo = new ClaimsRepository();
            repo.AddClaimToDirectory(testClaim);

            Queue<ClaimsContent> testQueue = repo.GetClaims();
            bool directoryHasClaim = testQueue.Contains(testClaim);
            Assert.IsTrue(directoryHasClaim);
        }
        private ClaimsContent _claims;
        private ClaimsRepository _repository;
        [TestInitialize]
        public void Arrange()
        {
            _repository = new ClaimsRepository();
            _claims = new ClaimsContent(5, TypeOfClaim.Home, "Drive by Pickle Flicking", 25.00m,
                new DateTime(2020, 10, 03), new DateTime(2020, 10, 04), true);
            _repository.AddClaimToDirectory(_claims);
        }
        [TestMethod]
        public void GetByClaimId_Test()
        {
            ClaimsContent idSearch = _repository.GetClaimById(5);
            Assert.AreEqual(_claims, idSearch);
        }
        [TestMethod]
        public void UpdateClaim_Test()
        {
            ClaimsContent newClaim = new ClaimsContent(5, TypeOfClaim.Home, "Drive By Pickle Flicking", 25.00m,
                new DateTime(2020, 10, 03), new DateTime(2020, 10, 04), true);
            bool updateClaim = _repository.UpdateExistingClaim(5, newClaim);
            Assert.IsTrue(updateClaim);
        }
    }
}
