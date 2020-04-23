using assessment_ddd.Domain.Application.Abstract;
using assessment_ddd.Domain.Model.Money;
using assessment_ddd.Infrastructure.DataManager.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace assessment_ddd.Domain.Application.Service
{
    public class UserService : IUser
    {
        private readonly ICurrencyDataManager _currencyDataManager;
        private readonly IBalanceDataManager _balanceDataManager;

        private readonly IBalance _balance;
        public UserService(
            ICurrencyDataManager currencyDataManager,
            IBalance balance
            )
        {
            _currencyDataManager = currencyDataManager;
            _balance = balance;
        }

        public void SetMoney(int id, MoneyModel money) {

            _balance.AddMoney(new MoneyModel
            {
                currency = money.currency, 
                amount = money.amount
            });

            _balanceDataManager.UpdateMoneyAmount(
                id, 
                money.currency.currencyId, 
                money.amount
            );
        }

        public void ExchangeMoney(int id, MoneyModel money, CurrencyModel to)
        {
            _balance.ExchangeMoney(money, to);

            foreach (var currency in _balance.GetCurrencies()) {
                _balanceDataManager.UpdateMoneyAmount(id, currency.Key.currencyId, currency.Value);
            }
        }

        public List<MoneyModel> GetAllUserMoney(int id) {
            var currencies = _currencyDataManager.GetCurrencies();
            var data = _balanceDataManager.GetMoneyBalanceByUserID(id);
            
            foreach (var value in data) {
                _balance.AddMoney(new MoneyModel
                {
                    currency = currencies.Where(x => x.CurrencyID == value.CurrencyID).Cast<CurrencyModel>().FirstOrDefault(),
                    amount = value.Amount
                });
            }

            return data.Select(x => 
                new MoneyModel { 
                    amount = x.Amount, 
                    currency = new CurrencyModel { 
                        currencyId = x.CurrencyID, 
                        name = x.CurrencyName, 
                        ratio = x.Ratio 
                    } 
                }).ToList();
        }
    }
}
