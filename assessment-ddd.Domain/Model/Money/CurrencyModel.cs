using System;

namespace assessment_ddd.Domain.Model.Money
{
    public class CurrencyModel
    {
        public int currencyId { get; set; }
        public string name { get; set; }
        public double ratio { get; set; }
    }
}
