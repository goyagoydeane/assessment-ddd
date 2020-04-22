using System;
using System.Collections.Generic;
using System.Text;

namespace assessment_ddd.Domain.Model.Money
{
    public class MoneyModel
    {
        public CurrencyModel currency { get; set; }
        public double amount { get; set; }
    }
}
