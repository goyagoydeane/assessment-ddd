using assessment_ddd.Domain.Application.Abstract;
using assessment_ddd.Domain.Model.Money;
using System;
using System.Collections.Generic;
using System.Text;

namespace assessment_ddd.Domain.Application.Service
{
    public class UserService : IUser
    {

        private readonly IBalance _balance;
        public UserService(IBalance balance)
        {
            _balance = balance;
        }

        public void AddMoney(int id, MoneyModel money) {
            _balance.AddMoney(money);
        }

        public void ChargeMoney(int id, MoneyModel money) {
            _balance.ChargeMoney(money);
        }
        public void ExchangeMoney(int id, MoneyModel money, CurrencyModel currency)
        {
            _balance.ExchangeMoney(money, currency);
        }

        public List<MoneyModel> GetAllMoney(int id) {
            return _balance.GetAllMoney();
        }
    }
}
