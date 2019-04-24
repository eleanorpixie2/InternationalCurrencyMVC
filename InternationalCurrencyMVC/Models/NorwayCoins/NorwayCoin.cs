using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace InternationalCurrencyMVC.Models
{
    public class NorwayCoin:Coin
    {
        public NorwayCoin()
        {
            Year = System.DateTime.Now.Year;
        }

        public override string About()
        {
            return "Norwegian " + Name + " is from " + Year + ". It is worth " + MonetaryValue.ToString("C", CultureInfo.CreateSpecificCulture("nb-NO"))
                + ". It was made in Norway.";
        }
    }
}
