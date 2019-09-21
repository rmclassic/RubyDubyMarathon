using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cassandra;
using RubyDub.Models;
using RubyDub.Util;
namespace RubyDub.DAL
{
    public static class AccountsDAL
    {
            public static List<Account> GetAccounts(string phonenumber)
            {
                List<Account> transactions = new List<Account>();
                string req = "SELECT * FROM Account WHERE phonenumber=\'" + phonenumber + "\' ALLOW FILTERING";
                var result = DataConnection.SendQuery(req);

                foreach (Row row in result.GetRows())
                {
                    transactions.Add(new Account(row));
                }
                return transactions;
            }

        public static void AddAccount(Account _account)
        {
            string req = "INSERT INTO Account (cardnumber,password,cv2,month,year,phonenumber) Values(" + _account.ToString() + ")";
            DataConnection.SendQuery(req);
            
        }
    }
}
