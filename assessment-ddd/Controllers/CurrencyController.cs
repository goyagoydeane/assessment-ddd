using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using assessment_ddd.Domain.Application.Abstract;
using assessment_ddd.Domain.Model.Money;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace assessment_ddd.Controllers
{
    [Route("currency")]
    [Produces("application/json")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        public readonly IBalance _balance;
        public readonly IUser _user;
        public CurrencyController(
            IBalance balance,
            IUser user
            ) 
        {
            _balance = balance;
            _user = user;
        }

        [HttpGet]
        public IActionResult Get() {
            return Ok();
        }
    }
}