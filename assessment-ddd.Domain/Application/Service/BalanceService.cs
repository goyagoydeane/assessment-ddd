using assessment_ddd.Domain.Application.Abstract;
using assessment_ddd.Domain.Model.Money;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace assessment_ddd.Domain.Application.Service
{
    public class BalanceService : IBalance
    {
        private Dictionary<CurrencyModel, double> currencies = new Dictionary<CurrencyModel, double>();

        public void AddMoney(MoneyModel money)
        {
            if (currencies.ContainsKey(money.currency))
            {
                currencies[money.currency] = (currencies[money.currency] + money.amount);
            }
            else
            {
                currencies.Add(money.currency, money.amount);
            }
        }

        public void ChargeMoney(MoneyModel money)
        {
            if (currencies.ContainsKey(money.currency))
            {
                currencies[money.currency] = (currencies[money.currency] - money.amount);
            }
            else
            {
                currencies.Add(money.currency, money.amount * -1);
            }
        }

        public void ExchangeMoney(MoneyModel money, CurrencyModel currency)
        {
            double ratio = Math.Round(money.currency.ratio / currency.ratio, 2);
            AddMoney(new MoneyModel { 
                currency = currency, 
                amount = (Math.Round(money.amount * ratio * 100) / 100) 
            });

            ChargeMoney(money);
        }

        public List<MoneyModel> GetAllMoney()
        {
            return currencies.Select(a => new MoneyModel { 
                currency = a.Key, 
                amount = a.Value 
            }).ToList();
        }    
    }
}
