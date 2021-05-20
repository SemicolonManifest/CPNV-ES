using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace TheVendingMachine.Model
{
    [TestClass]
    public class ValidationExtention
    {
        


        [TestMethod]
        public void TestMethod1()
        {
        }
    }

    [TestClass]
    public class Validation
    {
        List<Item> productList;
        Selecta mySelecta;

        [TestInitialize]
        public void TestInitialize()
        {
            productList = new List<Item>();

            productList.Add(new Item("A01", "Smarlies", 10, 1.60));
            productList.Add(new Item("A02", "Carampar", 5, 0.60));
            productList.Add(new Item("A03", "Avril", 2, 2.10));
            productList.Add(new Item("A04", "KokoKola", 1, 2.95));

            mySelecta = new Selecta(1, "Selecta of Ste-Croix's railway station", productList);
        }

        [TestCleanup]
        public void testClean()
        {
            productList = null;
            mySelecta = null;
        }

        [TestMethod]
        public void Scenario1()
        {
            string chooseExpectedResult = "Vending Smarlies";
            decimal getChangeExpectedResult = (decimal)1.80;

            mySelecta.Insert(3.40);
            string chooseResult = mySelecta.Choose("A01");
            decimal getChangeResult = mySelecta.GetChange();

            Assert.AreEqual(chooseExpectedResult, chooseResult);
            Assert.AreEqual(getChangeExpectedResult, getChangeResult);

        }

        [TestMethod]
        public void Scenario2()
        {
            string chooseExpectedResult = "Vending Avril";
            decimal getChangeExpectedResult = (decimal)0.00;
            decimal getBalanceExpectedResult = (decimal)2.10;

            mySelecta.Insert(2.10);
            string chooseResult = mySelecta.Choose("A03");
            decimal getChangeResult = mySelecta.GetChange();
            decimal getBalanceResult = mySelecta.GetBalance();

  

            Assert.AreEqual(chooseExpectedResult, chooseResult);
            Assert.AreEqual(getChangeExpectedResult, getChangeResult);
            Assert.AreEqual(getBalanceExpectedResult, getBalanceResult);


        }
    }
}
