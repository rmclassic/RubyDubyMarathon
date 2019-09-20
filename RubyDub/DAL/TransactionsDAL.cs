using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cassandra;
using RubyDub.Models;
namespace RubyDub.DAL
{
    public static class TransactionsDAL
    {
        public static List<Transaction> GetTransactions(string phonenumber)
        {
            List<Transaction> transactions = new List<Transaction>();
            string req = "SELECT * FROM transaction WHERE phonenumber=\'" + phonenumber + "\'";
            Cluster cluster = Cluster.Builder().AddContactPoint(Constants.DatabaseAddress).Build();
            var session = cluster.Connect(Constants.DatabaseKeySpace);
            var result = session.Execute(req);
            
            foreach (Row row in result.GetRows())
            {
                transactions.Add(new Transaction(row));
            }
            return transactions;
        }
    }
}
