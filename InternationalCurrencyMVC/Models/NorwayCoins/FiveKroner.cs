using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternationalCurrencyMVC.Models
{
    public class FiveKroner:NorwayCoin
    {
        public FiveKroner() : base()
        {
            Name = "5 kroner";
            MonetaryValue = 5;
        }
    }
}
