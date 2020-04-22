using assessment_ddd.Domain.Application.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace assessment_ddd.Domain.Model.User
{
    public class UserModel
    {
        public long id { get; set; }
        public string username { get; set; }
        public BalanceService balance { get; set; }
    }
}
