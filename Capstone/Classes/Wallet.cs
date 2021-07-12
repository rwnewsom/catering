using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
   public class Wallet
    {
        //properties
        public decimal AmountStored { get; private set; }


        //constructor
        public Wallet(decimal amountStored)
        {
            this.AmountStored = amountStored;
        }

        //method
        public void AddMoney(decimal amount)
        {
            this.AmountStored += amount;

        }
        public void Purchase(decimal amount)
        {
            if ((this.AmountStored - amount) < 0)
            {
                return;
            }
            else
            {
                this.AmountStored -= amount; ;
            }
        }
    }
}
