using assessment_ddd.Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace assessment_ddd.Infrastructure.DataManager.Abstract
{
    public interface ICurrencyDataManager
    {
        public List<CurrencyModel> GetCurrencies();
    }
}
