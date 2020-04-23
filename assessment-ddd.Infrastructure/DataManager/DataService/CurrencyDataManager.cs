using assessment_ddd.Infrastructure.DataManager.Abstract;
using assessment_ddd.Infrastructure.Model;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace assessment_ddd.Infrastructure
{
    public class CurrencyDataManager : ICurrencyDataManager
    {
        private readonly IDbConnection _db;

        public CurrencyDataManager(IDbConnection db)
        {
            _db = db;
        }

        public List<CurrencyModel> GetCurrencies() {
            string sql = 
                @"
                SELECT
                    CurrencyID, 
                    CurrencyName, 
                    Ratio 
                FROM 
                    Currency";

            return _db.Query<CurrencyModel>(sql).AsList();
        }
    }
}
