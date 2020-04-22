using assessment_ddd.Domain.Application.Service;
using assessment_ddd.Domain.Model.Money;
using assessment_ddd.Domain.Model.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace assessment_ddd.Domain.Application.Abstract
{
    public interface IUser
    {
        void AddMoney(int id, MoneyModel money);
        void ChargeMoney(int id, MoneyModel money);
        void ExchangeMoney(int id, MoneyModel money, CurrencyModel currency);
        List<MoneyModel> GetAllMoney(int id);
    }
}
