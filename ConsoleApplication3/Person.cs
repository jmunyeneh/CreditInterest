using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    public class Person
    {
        public string _Name { get; set; }
        public List<Wallet> lst = new List<Wallet>();

        public Person(string name)
        {
            this._Name = name;
        }

        public void Add(Wallet w)
        {
            lst.Add(w);
        }

        public double CalculateInterestPerWallet()
        {
            double d = 0;
            foreach(Wallet c in lst)
            {
                d += c.CalculateCardsInWallet();                
            }
            return d;
            
        }

    }

    public class Wallet
    {
        public List<CardItem> lst = new List<CardItem>();
        public string _walletName { get; set; }
        public Wallet()
        {
        }

        public Wallet(string walletName, List<CardItem> c)
        {
            this._walletName = walletName;
            this.lst = c;
        }

        public void AddCards(CardItem c)
        {
            lst.Add(c);
        }

        public double CalculateCardsInWallet()
        {
            //throw new  NotImplementedException();
            double d = 0;
            foreach(CardItem c in lst)
            {
                d += c.CalculateSimpleInterest();
            }
            return d;
        }
    }

    public class CardItem
    {
        public string _Name { get; set; }
        public double _bal { get; set; }
        public double _pct { get; set; }

        public CardItem()
        {

        }
        public CardItem(double bal, double pct)
        {
            this._bal = bal;
            this._pct = pct;
        }
        public CardItem(string name, double bal, double pct)
        {
            this._Name = name;
            this._bal = bal;
            this._pct = pct;
        }

        public double CalculateSimpleInterest()
        {
            double d;
            return d = 1 * _bal * _pct;
        }
    }
}
