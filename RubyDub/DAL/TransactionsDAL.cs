using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cassandra;
using RubyDub.Models;
using RubyDub.Util;
namespace RubyDub.DAL
{
    public static class TransactionsDAL
    {
        public static List<Transaction> GetTransactions(string phonenumber)
        {
            List<Transaction> transactions = new List<Transaction>();
            string req = "SELECT * FROM transaction WHERE phonenumber=\'" + phonenumber + "\'";
            var result = DataConnection.SendQuery(req);
            
            foreach (Row row in result.GetRows())
            {
                transactions.Add(new Transaction(row));
            }
            return transactions;
        }
    }
}
