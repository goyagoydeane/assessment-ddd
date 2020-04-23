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
        private static Dictionary<CurrencyModel, double> currencies { get; set; }
        public Dictionary<CurrencyModel, double> GetCurrencies() {
            return currencies;
        }
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

        public void ExchangeMoney(MoneyModel moneyFrom, CurrencyModel currencyTo)
        {
            double ratio = Math.Round(moneyFrom.currency.ratio / currencyTo.ratio, 2);
            AddMoney(new MoneyModel { 
                currency = currencyTo, 
                amount = (Math.Round(moneyFrom.amount * ratio * 100) / 100) 
            });

            ChargeMoney(moneyFrom);
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
