using assessment_ddd.Infrastructure.DataManager.Abstract;
using assessment_ddd.Infrastructure.Model;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace assessment_ddd.Infrastructure
{
    public class BalanceDataManager : IBalanceDataManager
    {
        private readonly IDbConnection _db;

        public BalanceDataManager(IDbConnection db)
        {
            _db = db;
        }

        public List<UserMoneyModel> GetMoneyBalanceByUserID(int userId) {
            string sql = @"
                SELECT 
                    UM.ID, 
                    UM.UserID, 
                    U.UserName, 
                    UM.CurrencyID, 
                    C.CurrencyName, 
                    C.Ratio,
                    UM.Amount
                FROM 
                    UserMoney UM 
                    JOIN User U 
                        ON UM.UserID = U.UserID
                    JOIN Currency C 
                        ON UM.CurrencyID = C.CurrencyID
                WHERE UM.UserID = @UserID";
                
            return _db.Query<UserMoneyModel>(sql, 
                param: new { @UserID = userId }
                ).AsList();
        }

        
        public void UpdateMoneyAmount(int userId, int currencyId, double amount) {
            string sql = @"
                IF NOT EXISTS(SELECT 1 FROM UserMoney WHERE UserID = @UserID AND CurrencyID = @CurrencyID)
                    BEGIN
                        INSERT INTO UserMoney(UserID, CurrencyID, Amount)
                        VALUES (@UserID, CurrencyID, @Amount)
                    END
                ELSE
                    BEGIN
                        UPDATE UserMoney
                        SET
                            Amount = @Amount
                        WHERE
                            UserID = @UserID AND CurrencyID = @CurrencyID
                    END
                ";

            _db.Query(sql,
                param: new { 
                    @UserID = userId, 
                    @CurrencyID = currencyId, 
                    @Amount = amount 
                });
        }
    }
}
