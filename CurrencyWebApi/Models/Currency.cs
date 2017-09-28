using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CurrencyWebApi.Models
{
    public class Currency
    {
        public string Name { get; set; }
        public string ISO { get; set; }
        public decimal ExchangeRate { get; set; }

        public Currency(string name, string iso, decimal exRate)
        {
            Name = name;
            ISO = iso;
            ExchangeRate = exRate;
        }

        public Currency()
        { }
    }
}