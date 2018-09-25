using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CurrencyRates.Models
{
    public class CurrencyRatesModel
    {
        public DateTime Date { get; set; }
        public decimal Rates { get; set; }
        public string Currencie { get; set; }
        public IEnumerable<CurrencieRateList> CurrencieList { get; set; }
    }

    public class CurrencieRateList
    {
        public DateTime Date { get; set; }
        public decimal Rates { get; set; }
        public string Currencie { get; set; }
    }
}