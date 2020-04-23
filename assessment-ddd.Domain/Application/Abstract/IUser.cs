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
        void SetMoney(int id, MoneyModel money);
        void ExchangeMoney(int id, MoneyModel money, CurrencyModel to);
        List<MoneyModel> GetAllUserMoney(int id);
    }
}
