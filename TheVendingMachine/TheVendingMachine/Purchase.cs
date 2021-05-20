using System;
using System.Collections.Generic;
using System.Text;

namespace TheVendingMachine.Model
{
    public class Purchase
    {
        private string code;
        private decimal price;
        private DateTime date;

        public Purchase(string code, decimal price, DateTime date)
        {
            this.code = code;
            this.price = price;
            this.date = date;
        }

        public string Code { get => code; }
        public decimal Price { get => price; }
        public DateTime Date { get => date; }
    }
}
