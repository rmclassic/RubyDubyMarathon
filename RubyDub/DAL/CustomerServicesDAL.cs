using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cassandra;
using RubyDub.Models;
using RubyDub.Util;
namespace RubyDub.DAL
{
    public static class CustomerServicesDAL
    {
        public static CustomerService GetService(string _id)
        {
            string req = "SELECT * FROM CustomerService WHERE id=\'" + _id + "\'";
            var result = DataConnection.SendQuery(req);

            return new CustomerService(result.First());

        }

        public static void AddService(CustomerService _service)
        {
            string req = "INSERT INTO CustomerService (phonenumber, idservice, id, cardnumber, condition, notif, notiftimeday, notiftimehour) Values(" + _service.ToString() + ")";
            DataConnection.SendQuery(req);
        }

        public static void DeleteService(string _id)
        {
            string req = "SELECT * FROM CustomerService WHERE id=\'" + _id + "\'";
            DataConnection.SendQuery(req);
        }

    }
}
