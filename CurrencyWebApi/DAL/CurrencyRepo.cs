using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CurrencyWebApi.Models;

namespace CurrencyWebApi.DAL
{
    public class CurrencyRepo
    {
        private List<Currency> currencies = new List<Currency>();

        private static CurrencyRepo instance = null;

        public static CurrencyRepo Instance
        {
            get
            {
                if (instance == null)
                    instance = new CurrencyRepo();
                return instance;
            }
        }


        private CurrencyRepo()
        {
            currencies.Add(new Currency("America", "USD", 524.02M));
            currencies.Add(new Currency("Canada", "CAD", 492.27M));
            currencies.Add(new Currency("Euro", "EUR", 745.99M));
            currencies.Add(new Currency("Norway", "NOK", 90.34M));
            currencies.Add(new Currency("Pounds", "GBP", 947.53M));
            currencies.Add(new Currency("Sweden", "SEK", 78.21M));
        }

        public bool AddCurrency(string name, string iso, decimal exRate)
        {
            bool found = false;
            foreach (Currency c in currencies)
            {
                if (c.ISO == iso)
                    found = true;
            }
            if (found == false)
                currencies.Add(new Currency(name, iso, exRate));

            return !found;
        }

        public IEnumerable<Currency> GetCurrencies()
        {
            return currencies;
        }

        public Dictionary<string, Currency> GetCurrenciesDictionary()
        {
            Dictionary<string, Currency> tmpDic = new Dictionary<string, Currency>();

            foreach (Currency c in currencies)
            {
                tmpDic.Add(c.ISO, c);
            }

            return tmpDic;
        }
    }
}