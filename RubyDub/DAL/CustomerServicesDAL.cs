using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cassandra;
using RubyDub.Models;
namespace RubyDub.DAL
{
    public static class CustomerServicesDAL
    {
        public static CustomerService GetService(string _id)
        {
            string req = "SELECT * FROM CustomerService WHERE id=\'" + _id + "\'";
            Cluster cluster = Cluster.Builder().AddContactPoint(Constants.DatabaseAddress).Build();
            var session = cluster.Connect(Constants.DatabaseKeySpace);
            var result = session.Execute(req);

            return new CustomerService(result.First());

        }

        public static void AddService(CustomerService _service)
        {
            string req = "INSERT INTO CustomerService (phonenumber, idservice, id, cardnumber, condition, notif, notiftimeday, notiftimehour) Values(" + _service.ToString() + ")";
            Cluster cluster = Cluster.Builder().AddContactPoint(Constants.DatabaseAddress).Build();
            var session = cluster.Connect(Constants.DatabaseKeySpace);
            var result = session.Execute(req);
        }

        public static void DeleteService(string _id)
        {
            string req = "SELECT * FROM CustomerService WHERE id=\'" + _id + "\'";
            Cluster cluster = Cluster.Builder().AddContactPoint(Constants.DatabaseAddress).Build();
            var session = cluster.Connect(Constants.DatabaseKeySpace);
            var result = session.Execute(req);
        }
    }
}
