using System;
using System.Collections.Generic;
using System.Text;

namespace assessment_ddd.Infrastructure.Model
{
    public class CurrencyModel
    {
        public int CurrencyID { get; set; }
        public string CurrencyName { get; set; }
        public double Ratio { get; set; }
    }
}
