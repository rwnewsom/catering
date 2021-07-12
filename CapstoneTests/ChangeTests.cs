using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.Classes;

namespace CapstoneTests
{
    [TestClass]
    public class ChangeTests
    {
        [TestMethod]
        public void FortyFiveDotTenShouldHaveTwoTwenties()
        {
            //Arrange
            Change change = new Change(45.10M);
            //Act 
            int result = change.TwentyDollarBills;
            //Assert
            Assert.AreEqual(2, result);

        }
        [TestMethod]
        public void FortyFiveDotTenShouldHaveOneDime()
        {
            //Arrange
            Change change = new Change(45.10M);
            //Act 
            int result = change.Dimes;
            //Assert
            Assert.AreEqual(1, result);

        }
        [TestMethod]
        public void NinetyNineCentsShouldBeFourPennies()
        {
            //Arrange
            Change change = new Change(0.99M);
            //Act 
            int result = change.Pennies;
            //Assert
            Assert.AreEqual(4, result);

        }

    }
}
