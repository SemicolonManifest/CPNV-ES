using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheVendingMachine.Model;

namespace TheVendingMachine.console
{
    class Program
    {
        /** This method is used as entry point of the program to test the classes of the vending machine.
        */
        static void Main(string[] args)
        {

            List<Item> productList;
            Selecta mySelecta;
            int i;
            decimal[][] balancePerHour;

            //Main scenarios
            // Scenario 1
            NewSelecta();

            Console.WriteLine("Scenario 1:");
            Console.WriteLine(" insert(3.40)");
            mySelecta.Insert(3.40);
            Console.WriteLine(" Choose(\"A01\"): "+mySelecta.Choose("A01"));
            Console.WriteLine(" GetChange(): {0:#0.00}", mySelecta.GetChange());

            // Scenario 2
            NewSelecta();

            Console.WriteLine("\nScenario 2:");
            Console.WriteLine(" insert(2.10)");
            mySelecta.Insert(2.10);
            Console.WriteLine(" Choose(\"A03\"): " + mySelecta.Choose("A03"));
            Console.WriteLine(" GetChange(): {0:#0.00}", mySelecta.GetChange());
            Console.WriteLine(" GetBalance(): {0:#0.00}", mySelecta.GetBalance());

            // Scenario 3
            NewSelecta();

            Console.WriteLine("\nScenario 3:");
            Console.WriteLine(" Choose(\"A01\"): " + mySelecta.Choose("A01"));

            // Scenario 4
            NewSelecta();

            Console.WriteLine("\nScenario 4:");
            Console.WriteLine(" insert(1.00)");
            mySelecta.Insert(1.00);
            Console.WriteLine(" Choose(\"A01\"): " + mySelecta.Choose("A01"));
            Console.WriteLine(" GetChange(): {0:#0.00}", mySelecta.GetChange());
            Console.WriteLine(" Choose(\"A02\"): " + mySelecta.Choose("A02"));
            Console.WriteLine(" GetChange(): {0:#0.00}", mySelecta.GetChange());

            // Scenario 5
            NewSelecta();

            Console.WriteLine("\nScenario 5:");
            Console.WriteLine(" insert(1.00)");
            mySelecta.Insert(1.00);
            Console.WriteLine(" Choose(\"A05\"): " + mySelecta.Choose("A05"));

            // Scenario 6
            NewSelecta();

            Console.WriteLine("\nScenario 6:");
            Console.WriteLine(" insert(6.00)");
            mySelecta.Insert(6.00);
            Console.WriteLine(" Choose(\"A04\"): " + mySelecta.Choose("A04"));
            Console.WriteLine(" Choose(\"A04\"): " + mySelecta.Choose("A04"));
            Console.WriteLine(" GetChange(): {0:#0.00}", mySelecta.GetChange());

            // Scenario 7
            NewSelecta();

            Console.WriteLine("\nScenario 7:");
            Console.WriteLine(" insert(6.00)");
            mySelecta.Insert(6.00);
            Console.WriteLine(" Choose(\"A04\"): " + mySelecta.Choose("A04"));
            Console.WriteLine(" insert(6.00)");
            mySelecta.Insert(6.00);
            Console.WriteLine(" Choose(\"A04\"): " + mySelecta.Choose("A04"));
            Console.WriteLine(" Choose(\"A01\"): " + mySelecta.Choose("A01"));
            Console.WriteLine(" Choose(\"A02\"): " + mySelecta.Choose("A02"));
            Console.WriteLine(" Choose(\"A02\"): " + mySelecta.Choose("A02"));
            Console.WriteLine(" GetChange(): {0:#0.00}", mySelecta.GetChange());
            Console.WriteLine(" GetBalance(): {0:#0.00}", mySelecta.GetBalance());

            // Scenario 8
            NewSelecta();

            mySelecta.Insert(1000.00);
            mySelecta.SetTime("2020-01-01T20:30:00"); mySelecta.Choose("A01");
            mySelecta.SetTime("2020-03-01T23:30:00"); mySelecta.Choose("A01");
            mySelecta.SetTime("2020-03-04T09:22:00"); mySelecta.Choose("A01");
            mySelecta.SetTime("2020-04-01T23:00:00"); mySelecta.Choose("A01");
            mySelecta.SetTime("2020-04-01T23:59:59"); mySelecta.Choose("A01");
            mySelecta.SetTime("2020-04-04T09:12:00"); mySelecta.Choose("A01");




            // Scenario extention
            balancePerHour = new decimal[24][];

            for (i=0; i <= 23; i++)
            {
                balancePerHour[i] = new decimal[2];
            }

            // Puting the hour in the firt column in each row
            for(i = 0; i <= 23; i++)
            {
                balancePerHour[i][0] = i;
            }

            // Filling the second column of 0
            for (i = 0; i <= 23; i++)
            {
                balancePerHour[i][1] = 0;
            }

            // Adding total of purchases to each hour
            foreach (Purchase purchase in mySelecta.Purchases) {
                balancePerHour[purchase.Date.Hour][1] += purchase.Price;
            }

            // Ordering
            balancePerHour = balancePerHour.OrderByDescending(num => num[1]).ToArray();

            // Outputting to console
            Console.WriteLine("\nScenario extension:");

            for (i = 0; i <= 2; i++)
            {
                Console.WriteLine(" Hour {0} generated a revenue of {1:#0.00}", balancePerHour[i][0], balancePerHour[i][1]);
            }

            Console.ReadKey();

            /* This function is used to reset the initials conditions of the vending machine
            */
            Selecta NewSelecta()
            {

                productList = new List<Item>
                {
                    new Item("A01", "Smarlies", 10, (decimal)1.60),
                    new Item("A02", "Carampar", 5, (decimal)0.60),
                    new Item("A03", "Avril", 2, (decimal)2.10),
                    new Item("A04", "KokoKola", 1, (decimal)2.95)
                };

                mySelecta = new Selecta(1, "Selecta of Ste-Croix's railway station", productList);

                return mySelecta;

            }
        }
    }
}
