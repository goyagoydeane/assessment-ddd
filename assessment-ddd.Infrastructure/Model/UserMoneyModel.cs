using System;
using System.Collections.Generic;
using System.Text;

namespace assessment_ddd.Infrastructure.Model
{
    public class UserMoneyModel 
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public int UserName { get; set; }
        public int CurrencyID { get; set; }
        public string CurrencyName { get; set; }
        public double Ratio { get; set; }
        public double Amount { get; set; }
    }
}
