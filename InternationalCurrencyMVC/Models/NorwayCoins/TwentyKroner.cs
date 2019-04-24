using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternationalCurrencyMVC.Models
{
    public class TwentyKroner:NorwayCoin
    {
        public TwentyKroner() : base()
        {
            Name = "20 kroner";
            MonetaryValue = 20;
        }
    }
}
