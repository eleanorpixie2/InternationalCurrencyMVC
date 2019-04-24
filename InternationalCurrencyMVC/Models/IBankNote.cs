using System;
using System.Collections.Generic;
using System.Text;

namespace InternationalCurrencyMVC.Models
{
    //bank note interface
    public interface IBankNote:ICurrency
    {
        //return the year
        int Year { get; }
    }
}
