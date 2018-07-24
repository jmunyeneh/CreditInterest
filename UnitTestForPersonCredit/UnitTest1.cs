using System;
using System.Collections.Generic;
using System.Text;
using ConsoleApplication3;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace UnitTestForPersonCredit
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {

        }
        [TestMethod]
        public void TestOnePersonOneWalletAndThreeCards()
        {
            Person p = new Person("Person 1");
            Wallet w = new Wallet("Wallet 1", new List<CardItem>
            {
                new CardItem {_Name = "Visa", _bal = 100, _pct=0.1}
               ,new CardItem {_Name = "MC", _bal = 100, _pct = 0.05}
               ,new CardItem {_Name = "Discover", _bal = 100, _pct = 0.01}
            });
            p.Add(w);

            double d = w.CalculateCardsInWallet();
            Assert.AreEqual(16, d);

            StringBuilder xStr = new StringBuilder();

            double cd;
            foreach(CardItem x in w.lst)
            {
                cd = x.CalculateSimpleInterest();
                xStr.AppendFormat($"{x._Name}" + "\t" + $"{cd}");
            }

            var twallet = new[]
            {
                new {_Name = "Visa", _bal = 10 }
               ,new {_Name = "MC", _bal = 5 }
               ,new {_Name = "Discover", _bal = 1 }
            };
            StringBuilder str = new StringBuilder();

            foreach(var i in twallet)
            {
                str.AppendFormat($"{i._Name}" + "\t" + $"{i._bal}");
            }

            StringAssert.Contains(xStr.ToString(), str.ToString());            
        }

        [TestMethod]
        public void TestOnePersonTwoWalletsAndCards()
        {
            Person P2 = new Person("Person 2");
            Wallet w1 = new Wallet("Wallet 1", new List<CardItem>
            {
                new CardItem {_Name = "Visa", _bal = 100, _pct=0.1}
               ,new CardItem {_Name = "Discover", _bal = 100, _pct = 0.01}
            });
            Wallet w2 = new Wallet("Wallet 2", new List<CardItem>
            {
               new CardItem {_Name = "MC", _bal = 100, _pct = 0.05}
            });

            P2.Add(w1);
            P2.Add(w2);

            double total;
            total = P2.CalculateInterestPerWallet();
            Assert.AreEqual(16, total);

            StringBuilder str = new StringBuilder();
            double d;
            foreach (Wallet ws in P2.lst)
            {
                d = ws.CalculateCardsInWallet();
               str.AppendFormat($"Interest Per Wallet {ws._walletName}" + "\t" + $"{d}");
            }

            var twallets = new[]
            {
                 new {_Name = "Wallet 1", _bal = 11 }
                ,new {_Name = "Wallet 2", _bal = 5 }
            };

            StringBuilder xstr = new StringBuilder();
            foreach(var i in twallets)
            {
                str.AppendFormat($"Interest Per Wallet {i._Name}" + "\t" + $"{i._bal}");
            }

            StringAssert.Contains(str.ToString(), xstr.ToString());


        }

        [TestMethod]
        public void TestTwoPeopelOneWalletEach()
        {
            Person e1 = new Person("Person 3");
            Wallet ew = new Wallet("Wallet 1", new List<CardItem>
            {
                 new CardItem {_Name = "Visa", _bal = 100, _pct=0.1}
                 ,new CardItem {_Name = "MC", _bal = 100, _pct = 0.05}
                 ,new CardItem {_Name = "MC", _bal = 100, _pct = 0.05}
            });
            e1.Add(ew);

            // Calculate the Total interest for Person 3
            double total3;
            total3 = e1.CalculateInterestPerWallet();

            Assert.AreEqual(20, total3);
        }

    }
}
