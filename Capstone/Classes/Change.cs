using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{

    //TODO - Automate tests for this class
    //TODO - Impact of more restrictive access modifiers
    public class Change
    {
        //Properties generated at instantiation by modulo to initial parameter; remainder assigned to parameter for next denomination
        /// <summary>
        /// $100.00 USD
        /// </summary>
        public int HundredDollarBills { get; }
        /// <summary>
        /// $50.00 USD
        /// </summary>
        public int FiftyDollarBills { get; }
        /// <summary>
        /// $20.00 USD
        /// </summary>
        public int TwentyDollarBills { get; }
        /// <summary>
        /// $10.00 USD
        /// </summary>
        public int TenDollarBills { get; }
        /// <summary>
        /// $5.00 USD
        /// </summary>
        public int FiveDollarBills { get; }
        /// <summary>
        /// $1.00 USD
        /// </summary>
        public int DollarBills { get; }
        /// <summary>
        /// $0.25 USD
        /// </summary>
        public int Quarters { get; }
        /// <summary>
        /// $0.10 USD
        /// </summary>
        public int Dimes { get; }
        /// <summary>
        /// #0.05 USD
        /// </summary>
        public int Nickels { get; }
        /// <summary>
        /// $0.01 USD
        /// </summary>
        public int Pennies { get; }

        //Constructor 

        /// <summary>
        /// Returns a change object containing a breakout of change owed by bill AND/OR coin.
        /// </summary>
        /// <param name="price">The decimal amount of change owed.</param>
        public Change(decimal price)
        {

            HundredDollarBills = (int)(price / 100);
            price %= 100;

            FiftyDollarBills = (int)(price / 50);
            price %= 50;

            TwentyDollarBills = (int)(price / 20);
            price %= 20;

            TenDollarBills = (int)(price / 10);
            price %= 10;

            FiveDollarBills = (int)(price / 5);
            price %= 5;

            DollarBills = (int)(price / 1);
            price %= 1;

            Quarters = (int)(price / .25m);
            price %= .25m;

            Dimes = (int)(price / .10m);
            price %= .10m;

            Nickels = (int)(price / .05m);
            price %= .05m;

            Pennies = (int)(price / .01m);
        }

        //method
        /// <summary>
        /// Returns a report of change owed by type.
        /// </summary>
        /// <returns>a string by denomination from 100 Dollar Bills to Pennies</returns>

        public string ShowChangeOwed()
        {

            return $"Change owed:\nHundred Dollar Bills: {HundredDollarBills}\nFifty Dollar Bills: {FiftyDollarBills}\nTwenty Dollar Bills: {TwentyDollarBills}\n" +
                $"Ten Dollar Bills: {TenDollarBills}\nFive Dollar Bills: {FiveDollarBills}\nDollar Bills: {DollarBills}\n" +
                $"Quarters: {Quarters}\nDimes: {Dimes}\nNickels: {Nickels}\nPennies: {Pennies}";
        }

    }
}
