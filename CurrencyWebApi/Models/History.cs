namespace CurrencyWebApi.Models
{

    public class History
    {
        public decimal Value { get; set; }
        public decimal ExchangeRate { get; set; }

        public History(decimal val, decimal ex)
        {
            Value = val;
            ExchangeRate = ex;
        }

        public History()
        { }
    }
}