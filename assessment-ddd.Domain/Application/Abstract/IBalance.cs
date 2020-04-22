using assessment_ddd.Domain.Model.Money;
using System;
using System.Collections.Generic;
using System.Text;

namespace assessment_ddd.Domain.Application.Abstract
{
    public interface IBalance
    {
        void AddMoney(MoneyModel money);
        void ChargeMoney(MoneyModel money);
        void ExchangeMoney(MoneyModel money, CurrencyModel currency);
        List<MoneyModel> GetAllMoney();
    }
}
