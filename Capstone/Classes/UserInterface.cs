using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    /// <summary>
    /// This class provides all user communications, but not much else.
    /// All the "work" of the application should be done elsewhere
    /// </summary>
    /// <remarks>
    /// ALL instances of Console.ReadLine and Console.WriteLine in your application should be in this class
    /// </remarks>
    public class UserInterface
    {
        //private Catering catering = new Catering();
        private FileAccess fileAccess = new FileAccess();
        private Wallet wallet = new Wallet(0);
        private string entry = "";
        private decimal runningTotal = 0M;
        private List<string> purchaseLog = new List<string>();
        private LogWriter logWriter = new LogWriter();
        

        /// <summary>
        /// List of catering items that are currently stocked
        /// </summary>
        private List<CateringItem> mainInventory = new List<CateringItem>();
        /// <summary>
        /// List of items that user has purchased
        /// </summary>
        
        //need to instantiate InventoryManager
        //need to instantiate Ledger

        public void RunInterface()
        {

           // logWriter.GenerateLogEntry();
            mainInventory = fileAccess.GenerateInventory();
            
            bool done = false;

            while (!done)
            {
                string userInput = GetUserMenuChoice();
                
                switch (userInput)
                {
                    case "1": // Display available inventory, modify after inventory is working
                        //List<string> currentInventory = catering.DisplayInventory();
                        
                        
                        foreach (CateringItem item in mainInventory)
                        {
                            Console.WriteLine(item.DisplayInventory());
                        }
                        break;

                    case "2": // Place Catering Order
                        bool complete = false;
                        
                        while (!complete)
                        {
                            string secondInput = GetUserSubMenuChoice();
                            switch (secondInput)
                            {
                                case "1":                                    
                                    AddUserFunds();
                                    break;

                                case "2":
                                    SelectProduct();                                   
                                    break;

                                case "3":
                                    Change change = new Change(wallet.AmountStored);
                                    
                                    Console.WriteLine("Ending Balance: "+wallet.AmountStored.ToString("C"));
                                    Console.WriteLine(change.ShowChangeOwed());
                                     entry = $"GIVE CHANGE: {wallet.AmountStored.ToString("C")}";
                                   wallet.Purchase(wallet.AmountStored);
                                    entry += $" {wallet.AmountStored.ToString("C")}";
                                    logWriter.GenerateLogEntry(entry);
                                    Console.WriteLine();

                                    Console.WriteLine("List of purchases:");
                                    foreach (string purchase in purchaseLog)
                                    {
                                        Console.WriteLine(purchase);
                                    }
                                    purchaseLog.Clear();
                                    Console.WriteLine("Validating log cleared.");
                                    foreach (string purchase in purchaseLog)
                                    {
                                        Console.WriteLine(purchase);
                                    }
                                    Console.WriteLine("End of Log.");
                                    complete = true;
                                    break;

                                default:
                                    Console.WriteLine("Please make a valid selection");
                                    break;
                            }
                        }

                        break;

                    case "3":
                        done = true;
                        break;

                    default:
                        Console.WriteLine("Please make a valid selection");
                        break;
                }
            }
        }

        private string GetUserMenuChoice()
        {
            Console.WriteLine("Please make a selection");
            Console.WriteLine("(1) Display Catering Items");
            Console.WriteLine("(2) Order");
            Console.WriteLine("(3) Quit");

            Console.WriteLine();

            string userInput = Console.ReadLine().ToUpper();

            Console.WriteLine();

            return userInput;
        }
        private string GetUserSubMenuChoice()
        {
            Console.WriteLine("Please make a selection");
            Console.WriteLine("(1) Add Money");
            Console.WriteLine("(2) Select Products");
            Console.WriteLine("(3) Complete Transaction");
            Console.WriteLine($"Current Account Balance: {wallet.AmountStored.ToString("C")}");

            Console.WriteLine();

            string userInput = Console.ReadLine().ToUpper();

            Console.WriteLine();

            return userInput;
        }

        private void AddUserFunds()
        {
            
            bool isDouble = false;

            decimal depositAmount = 0;
            Console.WriteLine("Note Max balance is $5000.00");
            Console.WriteLine("How Much Would You Like to Add?");

            Console.WriteLine();

            string reply = Console.ReadLine();
            isDouble = decimal.TryParse(reply, out depositAmount);

           
                while (!isDouble || ((depositAmount<0)||(depositAmount>5000) || ((wallet.AmountStored+depositAmount) > 5000)))
                {
                    Console.WriteLine("Error, please enter a decimal amount between 0.01 and $5000.");
                    Console.WriteLine("Cumulative deposit balance may not exceed $5000.");

                    string newReply = Console.ReadLine();
                    isDouble = decimal.TryParse(newReply, out depositAmount);
                }
                     wallet.AddMoney((decimal)depositAmount);
            entry = $"ADD MONEY: {depositAmount.ToString("C")} {wallet.AmountStored.ToString("C")}";
            logWriter.GenerateLogEntry(entry);
        }


        public void SelectProduct()
        {
            Console.WriteLine("Please enter product code of item you would like to purchase:");            
            string entry = Console.ReadLine().ToUpper();
            CateringItem desiredProduct=null;

            foreach (CateringItem item in mainInventory)
            {
                if (item.ProductCode.Equals(entry))
                {
                   desiredProduct = item;

                    if (desiredProduct.ProductQuantity >= 1)
                    {
                        Console.WriteLine($"Product {desiredProduct.ProductName} has {desiredProduct.ProductQuantity} units available for ${desiredProduct.ProductPrice} each.");
                        Console.WriteLine("What quantity would you like to purchase?");
                        bool isInt = false;
                        int purchaseQuantity = 0;
                        string reply = Console.ReadLine();
                        isInt = int.TryParse(reply, out purchaseQuantity);

                        while (!isInt)
                        {
                            Console.WriteLine("Error, please enter whole numbers only");
                            string newReply = Console.ReadLine();
                            isInt = int.TryParse(newReply, out purchaseQuantity);
                        }

                        decimal transactionCost = desiredProduct.ProductPrice * purchaseQuantity;
                        if (wallet.AmountStored - transactionCost <= 0)
                        {
                            Console.WriteLine("Insufficient Funds Available");
                            Console.WriteLine("Available Funds: $" + wallet.AmountStored);
                            Console.WriteLine("Needed Funds: $" + transactionCost);
                            return;
                        }
                        else if (desiredProduct.ProductQuantity < purchaseQuantity)
                        {
                            Console.WriteLine("Insufficient Stock On Hand");
                            return;
                        }
                        else
                        {
                            wallet.Purchase(transactionCost);
                            runningTotal += transactionCost;
                            
                            foreach (CateringItem item2 in mainInventory)
                            {
                                if (item2.Equals(desiredProduct))
                                {
                                    string productType = "";
                                    if (desiredProduct.ProductCode.StartsWith("A"))
                                    {
                                        productType = "Appetizer";
                                    }
                                    else if (desiredProduct.ProductCode.StartsWith("B"))
                                    {
                                        productType = "Beverage";
                                    }
                                    else if (desiredProduct.ProductCode.StartsWith("D"))
                                    {
                                        productType = "Dessert";
                                    }
                                    else
                                    {
                                        productType = "Entree";
                                    }
                                    item2.RemoveInventory(purchaseQuantity);
                                    purchaseLog.Add($"{purchaseQuantity} {productType} {desiredProduct.ProductName} {desiredProduct.ProductPrice.ToString("C")} {transactionCost.ToString("C")}");
                                    entry = $"{purchaseQuantity} {desiredProduct.ProductName} {desiredProduct.ProductCode} {transactionCost.ToString("C")} {wallet.AmountStored.ToString("C")} ";
                                    logWriter.GenerateLogEntry(entry);
                                }
                            }

                            return;
                        }

                    }

                    break;
                }
                
            }
            if (desiredProduct == null)
            {
                Console.WriteLine("Product code not found: " + entry);
            }

        }

    }


}
