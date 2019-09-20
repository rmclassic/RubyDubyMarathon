using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cassandra;
using RubyDub.Models;
namespace RubyDub.DAL
{
    public static class AccountsDAL
    {
            public static List<Account> GetAccounts(string phonenumber)
            {
                List<Account> transactions = new List<Account>();
                string req = "SELECT * FROM Account WHERE phonenumber=\'" + phonenumber + "\' ALLOW FILTERING";
                Cluster cluster = Cluster.Builder().AddContactPoint(Constants.DatabaseAddress).Build();
                var session = cluster.Connect(Constants.DatabaseKeySpace);
                var result = session.Execute(req);

                foreach (Row row in result.GetRows())
                {
                    transactions.Add(new Account(row));
                }
                return transactions;
            }

        public static void AddAccount(Account _account)
        {
            string req = "INSERT INTO Account (cardnumber,password,cv2,month,year,phonenumber) Values(" + _account.ToString() + ")";
            Cluster cluster = Cluster.Builder().AddContactPoint(Constants.DatabaseAddress).Build();
            var session = cluster.Connect(Constants.DatabaseKeySpace);
            session.Execute(req);
            
        }
    }
}
