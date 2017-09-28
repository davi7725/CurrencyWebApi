using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CurrencyWebApi.Models;

namespace CurrencyWebApi.DAL
{
    public class HistoryRepo
    {
        List<History> history = new List<History>();

        public static HistoryRepo instance = null;

        public static HistoryRepo Instance
        {
            get
            {
                if (instance == null)
                    instance = new HistoryRepo();
                return instance;
            }
        }

        private HistoryRepo()
        { }

        public void AddHistory(decimal value, decimal exchangeRate)
        {
            history.Add(new History(value, exchangeRate));
        }

        public IEnumerable<History> GetHistory()
        {
            return history;
        }
    }
}