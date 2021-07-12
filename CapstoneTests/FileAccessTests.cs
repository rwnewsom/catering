using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.Classes;

namespace CapstoneTests
{
    [TestClass]
    public class FileAccessTests
    {
        [TestMethod]
        public void FileWith18ItemsShouldNotBeNullOrEmpty()
        {
            //Arange and Act
            FileAccess fileAccess = new FileAccess();

            // Assert
            Assert.IsNotNull(fileAccess);
        }

        [TestMethod]
        
        public void FileWith18ItemsShouldGenerateListOf18Items()
        //This test only works with default file containing 18 valid lines!!!    
        {
            //Arange
            FileAccess fileAccess = new FileAccess();

            List<CateringItem> testInventory = new List<CateringItem>();
            testInventory = fileAccess.GenerateInventory();

            //Act
            int result = testInventory.Count;

            // Assert
            Assert.AreEqual(18, result);
        }
    }
}
