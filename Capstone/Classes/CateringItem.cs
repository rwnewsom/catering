using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    /// <summary>
    /// This represents a single catering item in your system
    /// </summary>
    /// <remarks>
    /// NO Console statements are allowed in this class
    /// </remarks>
    public class CateringItem
    {
        //property
        /// <summary>
        /// unique letter and number combinations
        /// </summary>
        public string ProductCode { get; private set; }
        /// <summary>
        /// name of the product
        /// </summary>
        public string ProductName { get; private set; }
        /// <summary>
        /// price in USD
        /// </summary>
        public decimal ProductPrice { get; private set; }
        /// <summary>
        /// units of stock available
        /// </summary>
        public int ProductQuantity { get; private set;  }

        //constructer
        /// <summary>
        /// Instantiate an inventory item as an object.
        /// </summary>
        /// <param name="productCode">The unique stock identifier, one letter and one number.</param>
        /// <param name="productName">The name of the product.</param>
        /// <param name="productPrice">Price in USD </param>
        public CateringItem(string productCode, string productName, decimal productPrice)
        {
            this.ProductCode = productCode;
            this.ProductName = productName;
            this.ProductPrice = productPrice;
            this.ProductQuantity = 50;
        }


        //methods
        public string DisplayInventory()
        {
            string inventory = "";
            if (this.ProductQuantity <= 0 )
            {
                inventory = "SOLD OUT";
            }
            else
            {
                inventory = this.ProductQuantity.ToString();
            }
            return $"Product Code: {ProductCode}  Name: {ProductName}  Price: {ProductPrice} Stock: {inventory} ";

        }

        //order method that reduces balance

        public void AddInventory(int amount) 
        {
            this.ProductQuantity += amount;
        }

        public void RemoveInventory(int amount)
        {
            this.ProductQuantity -= amount;
        }

    }
}
