using System;
using System.Collections.Generic;
using System.Text;

namespace TheVendingMachine.Model
{
    public class Item
    {
        #region private attributes
        private string code;
        private string name;
        private int quantity;
        private decimal price;
        #endregion

        #region constructor
        public Item(string code, string name, int quantity, decimal price)
        {
            this.code = code;
            this.name = name;
            this.quantity = quantity;
            this.price = price;
        }

        public Item(string code, string name, int quantity, double price)
        {
            this.code = code;
            this.name = name;
            this.quantity = quantity;
            this.price = (decimal)price;
        }
        #endregion

        #region public methodes
        public string Code
        {
            get
            {
                return code;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }
        }

        public int Quantity
        {
            get
            {
                return quantity;
            }
        }

        public decimal Price
        {
            get
            {
                return price;
            }
        }

        public void Take()
        {
            if (quantity > 0)
            {
                quantity = quantity - 1;
            }
            
        }

        public override string ToString()
        {
            return code;
        }
        #endregion
    }
}
