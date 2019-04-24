using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternationalCurrencyMVC.Models
{
    public class halfKrone:NorwayCoin
    {
        public halfKrone():base()
        {
            Name = "50 øre";
            MonetaryValue = .5;
        }
    }
}
