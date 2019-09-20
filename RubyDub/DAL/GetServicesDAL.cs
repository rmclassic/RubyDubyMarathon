using Cassandra;
using RubyDub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RubyDub.DAL
{
    public static class GetServicesDAL
    {
        public static GetService GetService(string _id)
        {
            string req = "SELECT * FROM GetService WHERE id=\'" + _id + "\'";
            Cluster cluster = Cluster.Builder().AddContactPoint(Constants.DatabaseAddress).Build();
            var session = cluster.Connect(Constants.DatabaseKeySpace);
            var result = session.Execute(req);

            return new GetService(result.First());

        }

        public static void AddService(GetService _service)
        {
            string req = "INSERT INTO GetService (phonenumber, idservice, id, starttime, endtime, barcode, col) Values(" + _service.ToString() + ")";
            Cluster cluster = Cluster.Builder().AddContactPoint(Constants.DatabaseAddress).Build();
            var session = cluster.Connect(Constants.DatabaseKeySpace);
            var result = session.Execute(req);
        }
        public static void DeleteService(string _id)
        {
            string req = "SELECT * FROM GetService WHERE id=\'" + _id + "\'";
            Cluster cluster = Cluster.Builder().AddContactPoint(Constants.DatabaseAddress).Build();
            var session = cluster.Connect(Constants.DatabaseKeySpace);
            var result = session.Execute(req);
        }
    }
}
