using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Capstone.Classes;

namespace CapstoneTests
{
    [TestClass]
    public class CateringItemTests
    {
        [TestMethod]
        public void CateringItemShouldConstructWith50ItemsOnHand()
        {
            //Arrange
            CateringItem cateringItem = new CateringItem("A1", "Steak Sauce", 5.99M);

            //Act
            int result = cateringItem.ProductQuantity;

            //Assert
            Assert.AreEqual(50, result);
        }
        [TestMethod]
        public void CateringItemMinus20ShouldLeaveThirty()
        {
            //Arrange
            CateringItem cateringItem = new CateringItem("A1", "Steak Sauce", 5.99M);

            //Act
            cateringItem.RemoveInventory(20);
            int result = cateringItem.ProductQuantity;

            //Assert
            Assert.AreEqual(30, result);
        }
    }
}
