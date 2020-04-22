using System;
using System.Collections.Generic;
using System.Text;
using assessment_ddd.Domain.Model.Money;
namespace assessment_ddd.Domain.Application.Abstract
{
    public interface ICurrency
    {
        CurrencyModel GetCurrencyByID(int currencyId);
    }
}
