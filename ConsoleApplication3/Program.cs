using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*****Beginning of the Program*****\n");

            Person p = new Person("Person 1");
            Wallet w = new Wallet("Wallet 1", new List<CardItem>
            {
                new CardItem {_Name = "Visa", _bal = 100, _pct=0.1}
               ,new CardItem {_Name = "MC", _bal = 100, _pct = 0.05}
               ,new CardItem {_Name = "Discover", _bal = 100, _pct = 0.01}
            });
            p.Add(w);

            double d = w.CalculateCardsInWallet();
            
            Console.WriteLine($"Total Interest for {p._Name}" + "\t" + $"{d}");

            Console.WriteLine("*****Interest Per Card*******");

            double cd;
            foreach(CardItem c in w.lst)
            {
                cd = c.CalculateSimpleInterest();
                Console.WriteLine($"{c._Name}" + "\t" + $"{cd}");

            }
            Console.WriteLine();

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
            Console.WriteLine($"Total Interest(simple interest) {P2._Name}" + "\t" + $"{total}");

            double x;
            foreach(Wallet ws in P2.lst)
            {
                x = ws.CalculateCardsInWallet();
                Console.WriteLine($"Interest Per Wallet {ws._walletName}" + "\t" + $"{x}");
            }
            Console.WriteLine();
            Console.WriteLine("**********This is the third***************");
            Console.WriteLine();
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
            Console.WriteLine($"Total Interest(simple interest) {e1._Name}" + "\t" + $"{total3}");

            // Calculate the interest per wallet - Person 3
            double pwallet;
            foreach(Wallet pw in e1.lst)
            {
                pwallet = pw.CalculateCardsInWallet();
                Console.WriteLine($"Interest Per Wallet {pw._walletName}" + "\t" + $"{pwallet}");
            }

            Console.WriteLine();
            Person e2 = new Person("Person 4");
            Wallet e2w = new Wallet("Wallet 1", new List<CardItem>
            {
                 new CardItem {_Name = "Visa", _bal = 100, _pct=0.1}
                 ,new CardItem {_Name = "MC", _bal = 100, _pct = 0.05}
            });
            e2.Add(e2w);
            // Calculate the Total interest for Person 4
            double total4;
            total4 = e2.CalculateInterestPerWallet();
            Console.WriteLine($"Total Interest(simple interest) {e2._Name}" + "\t" + $"{total4}");

            // Calculate the interest per wallet - Person 3
            double pwallet1;
            foreach (Wallet pw1 in e2.lst)
            {
                pwallet1 = pw1.CalculateCardsInWallet();
                Console.WriteLine($"Interest Per Wallet {pw1._walletName}" + "\t" + $"{pwallet1}");
            }

            Console.WriteLine();


            Console.ReadLine();
        }
    }
}
