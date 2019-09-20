using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cassandra;
using RubyDub.Models;
namespace RubyDub.DAL
{
    public static class ServicesDAL
    {
        public static Service GetService(string _id)
        {
            string req = "SELECT * FROM Service WHERE id=\'" + _id + "\'";
            Cluster cluster = Cluster.Builder().AddContactPoint(Constants.DatabaseAddress).Build();
            var session = cluster.Connect(Constants.DatabaseKeySpace);
            var result = session.Execute(req);

                return new Service(result.First());
        
        }

        public static void AddService(Service _service)
        {
            string req = "INSERT INTO Service (name, id, price, period, pricepp, col) Values(" + _service.ToString() + ")";
            Cluster cluster = Cluster.Builder().AddContactPoint(Constants.DatabaseAddress).Build();
            var session = cluster.Connect(Constants.DatabaseKeySpace);
            var result = session.Execute(req);
        }

        public static void DeleteService(string _id)
        {
            string req = "SELECT * FROM Service WHERE id=\'" + _id + "\'";
            Cluster cluster = Cluster.Builder().AddContactPoint(Constants.DatabaseAddress).Build();
            var session = cluster.Connect(Constants.DatabaseKeySpace);
            var result = session.Execute(req);
        }
    }
}
