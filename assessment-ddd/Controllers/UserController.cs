using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using assessment_ddd.Abstract;
using assessment_ddd.Domain.Application.Abstract;
using assessment_ddd.Domain.Model.Money;
using assessment_ddd.Domain.Model.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace assessment_ddd.Controllers
{
    [Route("user")]
    [Produces("application/json")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly ICurrency _currency;
        private readonly IUser _user;
        public UserController(
            ICurrency currency,
            IUser user
            ) 
        {
            _currency = currency;    
            _user = user;
        }

        [Route("{id:int}/balance")]
        [HttpGet]
        public IActionResult Balance([FromRoute]int id, int currencyId, double amount)
        {
            var currency = _currency.GetCurrencyByID(currencyId);
            _user.AddMoney(id, new MoneyModel { amount = amount, currency = currency });

            return Ok(_user.GetAllMoney(id));
        }

        [Route("{id:int}/exchange")]
        [HttpPost]
        public IActionResult Exchange([FromRoute]int id, int currencyId, double amount)
        {
            var currency = _currency.GetCurrencyByID(currencyId);
            _user.AddMoney(id, new MoneyModel { amount = amount, currency = currency });

            return Ok(_user.GetAllMoney(id));
        }

        [Route("{id:int}/balance")]
        [HttpGet]
        public IActionResult GetBalance([FromRoute]int id)
        {
            //var currency = _currency.GetCurrencyByID(money.currency.currencyId);

            _user.GetAllMoney(id);
    
            return Ok("1");
        }
    }
}