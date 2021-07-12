using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.Classes;

namespace CapstoneTests
{
    [TestClass]
    public class WalletTests
    {
    [TestMethod]
    public void FiveDollarsShouldStoreFiveDollars()
        {
            //Arrange
            Wallet wallet = new Wallet(0);

            //Act
            wallet.AddMoney(5);
            decimal result = wallet.AmountStored;

            //Assert
            Assert.AreEqual(5, result);
        }

        [TestMethod]
        public void DepositingFourKAndPurchasingTwoKShouldLeaveTwoK()
        {
            //Arrange
            Wallet wallet = new Wallet(0);

            //Act
            wallet.AddMoney(4000);
            wallet.Purchase(2000);
            decimal result = wallet.AmountStored;

            //Assert
            Assert.AreEqual(2000, result);
        }

        [TestMethod]
        public void AttemptToOverdrawShouldNotALterBalance()
        {
            //Arrange
            Wallet wallet = new Wallet(0);

            //Act
            wallet.AddMoney(4000);
            wallet.Purchase(5020);
            decimal result = wallet.AmountStored;

            //Assert
            Assert.AreEqual(4000, result);
        }

    }

    
}

