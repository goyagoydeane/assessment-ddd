using assessment_ddd.Domain.Application.Abstract;
using assessment_ddd.Domain.Model.Money;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace assessment_ddd.Domain.Application.Service
{
    public class CurrencyService : ICurrency
    {

        public CurrencyModel GetCurrencyByID(int currencyId)
        {
            Dictionary<int, CurrencyModel> currencyDic = new Dictionary<int, CurrencyModel>();
            currencyDic.Add(1, new CurrencyModel { name = "USD", ratio = 1 });
            currencyDic.Add(2, new CurrencyModel { name = "EUR", ratio = 1.5 });

            return currencyDic.Where(x => x.Key == currencyId).FirstOrDefault().Value;
        }
    }
}
