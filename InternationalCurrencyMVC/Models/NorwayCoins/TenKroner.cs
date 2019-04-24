using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternationalCurrencyMVC.Models
{
    public class TenKroner:NorwayCoin
    {
        public TenKroner() : base()
        {
            Name = "10 kroner";
            MonetaryValue = 10;
        }
    }
}
