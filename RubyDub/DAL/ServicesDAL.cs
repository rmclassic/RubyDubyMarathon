using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cassandra;
using RubyDub.Models;
using RubyDub.Util;
namespace RubyDub.DAL
{
    public static class ServicesDAL
    {
        public static Service GetService(string _id)
        {
            string req = "SELECT * FROM Service WHERE id=\'" + _id + "\'";
            var result = DataConnection.SendQuery(req);

            if (result.Count() > 0)
                return new Service(result.First());
            else return null;
        }

        public static void AddService(Service _service)
        {
            string req = "INSERT INTO Service (name, id, price, period, pricepp, col) Values(" + _service.ToString() + ")";
            DataConnection.SendQuery(req);
        }

        public static void DeleteService(string _id)
        {
            string req = "SELECT * FROM Service WHERE id=\'" + _id + "\'";
            DataConnection.SendQuery(req);
        }
    }
}
