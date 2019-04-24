using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternationalCurrencyMVC.Models
{
    public class OneKrone:NorwayCoin
    {
        public OneKrone() : base()
        {
            Name = "1 krone";
            MonetaryValue = 1;
        }
    }
}
