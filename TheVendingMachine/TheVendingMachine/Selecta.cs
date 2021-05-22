using System;
using System.Collections.Generic;

namespace TheVendingMachine.Model
{
    /* This class is the vending machine.
    */
    public class Selecta
    {
        #region private attributes
        /* id - The ID of the machine.
        *  description - A description of the machoine, it's situation.
        *  items - This method is the list of items sold by the machine.
        *  credit - The remaining credit in the machine.
        *  balance - This is the total value of sales in the machine.
        *  time - This attribute is used for testing purposes. It stores a given date this is used for the sales list.
        *  purchases - The list of sales.
        */
        private int id;
        private string description;
        private List<Item> items;
        private decimal credit;
        private decimal balance;
        private DateTime time;
        private List<Purchase> purchases;

        #endregion

        #region constructor
        public Selecta(int id, string description, List<Item> items)
        {
            this.id = id;
            this.description = description;
            this.items = items;
            this.credit = 0;
            this.balance = 0;
            this.time = new DateTime();
            this.purchases = new List<Purchase>();
        }
        #endregion

        #region public methodes
        public int Id
        {
            get
            {
                return id;
            }
        }

        public string Description
        {
            get
            {
                return description;
            }
        }

        public List<Item> Items
        {
            get
            {
                return items;
            }
        }

        public List<Purchase> Purchases
        {
            get
            {
                return purchases;
            }
        }

        /* This method is used to insert credit in the machine
        */
        public void Insert(decimal amount)
        {
            credit += amount;
            // Why dont we check if the value is an actual possible value (amount % 0.05 == 0.00) for the swiss franc?
        }

        /* This method is an override of the initial insert() to accept double too.
        */
        public void Insert(double amount)
        {
            Insert((decimal)amount);
        }

        /* This method is used to choose and buy an item.
        */
        public string Choose(string code)
        {
            Item result = items.Find(item => item.Code == code);
            string myReturn;

            if (result == null)
            {
                myReturn = "Invalid selection!";
            }
            else if (result.Quantity == 0)
            {
                myReturn = "Item " + result.Name + ": Out of stock!";
            }
            else if (result.Price > credit)
            {
                myReturn = "Not enough money!";
            }
            else
            {
                myReturn = "Vending " + result.Name;
                credit -= result.Price;
                result.Take();
                balance += result.Price;

                // This part is mainly used for testing purposes. If the time attribute is at the default datetime, the purchase object is created with the current timestamp of the system.
                // If not, it will use the date stored in the time attribute.
                if (time.Year == 1)
                {
                    purchases.Add(new Purchase(result.Code, result.Price, DateTime.Now));
                }
                else
                {
                    purchases.Add(new Purchase(result.Code, result.Price, time));
                }

            }


            return myReturn;
        }

        /* This method is used to get the remaining credit.
        */
        public decimal GetChange()
        {
            return credit;
        }

        /*This method is used to get the total balance of this that as been buyed
        */
        public decimal GetBalance()
        {
            return balance;
        }


        /* This method is used to reset the static time setted.
        */
        public void SetTime()
        {
            time = new DateTime();
        }

        /* Testing-only override. This method is used to set the machine internal time for sales statistics' test purposes.
        */
        public void SetTime(string date)
        {
            time = Convert.ToDateTime(date);
        }

        #endregion
    }

}
