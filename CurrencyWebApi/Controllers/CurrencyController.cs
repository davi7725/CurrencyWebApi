using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CurrencyWebApi.DAL;
using CurrencyWebApi.Models;

namespace CurrencyWebApi.Controllers
{
    public class CurrencyController : ApiController
    {
        Dictionary<string, Currency> currencies = CurrencyRepo.Instance.GetCurrenciesDictionary();
        HistoryRepo history = HistoryRepo.Instance;

        [Route("DkkToEur/{value}")]
        [HttpGet]
        public decimal DkkToEur(decimal value)
        {
            history.AddHistory(value, currencies["EUR"].ExchangeRate);

            return value / currencies["EUR"].ExchangeRate;
        }

        [Route("GetExchangeRate/{iso}")]
        [HttpGet]
        public decimal GetExchangeRate(string iso)
        {
            if (currencies.ContainsKey(iso))
                return currencies[iso].ExchangeRate;
            else
                return -1;
        }

        [Route("GetCurrencies/")]
        [HttpGet]
        public IEnumerable<Currency> GetCurrencies()
        {
            return currencies.Values.ToList();
        }

        [Route("ConvertCurrency/{isoFrom}/{isoTo}/{value}")]
        [HttpGet]
        public decimal ConvertCurrency(string isoFrom, string isoTo, decimal value)
        {
            decimal convertToDkk = currencies[isoFrom].ExchangeRate * value;

            history.AddHistory(value, currencies[isoTo].ExchangeRate);

            return convertToDkk / currencies[isoTo].ExchangeRate;
        }

        [Route("GetHistory/")]
        [HttpGet]
        public IEnumerable<History> GetHistory()
        {
            return history.GetHistory().ToList();
        }

        [Route("ChangeExchangeRate/{iso}/{value}")]
        [HttpPut]
        public bool ChangeExchangeRate(string iso, decimal value)
        {
            bool changed = false;
            if(currencies.ContainsKey(iso))
            {
                currencies[iso].ExchangeRate = value;
                changed = true;
            }

            return changed;
        }

        [Route("CreateCurrency/{name}/{iso}/{exchangeRate}")]
        [HttpPost]
        public bool CreateCurrency(string name, string iso, decimal exchangeRate)
        {
            bool created = CurrencyRepo.Instance.AddCurrency(name, iso, exchangeRate);

            return created;
        }
    }
}
