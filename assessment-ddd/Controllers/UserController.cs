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
        public IActionResult Balance([FromRoute]int id)
        {
            return Ok(_user.GetAllUserMoney(id));
        }

        [Route("{id:int}/exchange")]
        [HttpPost]
        public IActionResult ExchangeMoney([FromRoute]int id, MoneyModel money, CurrencyModel to)
        {
            _user.ExchangeMoney(id, money, to);
            return Ok();
        }

        [Route("{id:int}/money")]
        [HttpPost]
        public IActionResult SetUserMoney([FromRoute]int id, [FromBody] MoneyModel money)
        {
            _user.SetMoney(id, money);
            return Ok();
        }
    }
}