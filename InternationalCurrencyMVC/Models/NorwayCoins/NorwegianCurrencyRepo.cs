using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//https://www.norwaytravelplanner.com/money/krone.html

namespace InternationalCurrencyMVC.Models
{
    public class NorwegianCurrencyRepo : ICurrencyRepo
    {
        public List<ICoin> Coins { get; set; }

        public string About()
        {
            throw new NotImplementedException();
        }

        public void AddCoin(ICoin c)
        {
            throw new NotImplementedException();
        }

        public int GetCoinCount()
        {
            throw new NotImplementedException();
        }

        public ICurrencyRepo MakeChange(double Amount)
        {
            throw new NotImplementedException();
        }

        public ICurrencyRepo MakeChange(double AmountTendered, double TotalCost)
        {
            throw new NotImplementedException();
        }

        public ICoin RemoveCoin(ICoin c)
        {
            throw new NotImplementedException();
        }

        public double TotalValue()
        {
            throw new NotImplementedException();
        }
    }
}
