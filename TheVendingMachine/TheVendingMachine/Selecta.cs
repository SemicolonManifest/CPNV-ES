using System;
using System.Collections.Generic;

namespace TheVendingMachine.Model
{
    public class Selecta
    {
        #region private attributes
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

        public void Insert(decimal amount)
        {
            credit += amount;
            // Why dont we check if the value is an actual possible value (amount % 0.05 == 0.00) for the swiss franc?
        }

        public void Insert(double amount)
        {
            Insert((decimal)amount);
        }

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


        public decimal GetChange()
        {
            return credit;
        }

        public decimal GetBalance()
        {
            return balance;
        }



        public void SetTime()
        {
            time = new DateTime();
        }

        public void SetTime(string date)
        {
            time = Convert.ToDateTime(date);
        }

        #endregion
    }

}
