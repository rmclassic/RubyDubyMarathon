using Cassandra;
using RubyDub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RubyDub.Util;
namespace RubyDub.DAL
{
    public static class GetServicesDAL
    {
        public static GetService GetService(string _id)
        {
            string req = "SELECT * FROM GetService WHERE id=\'" + _id + "\'";

            var result = DataConnection.SendQuery(req);

            if (result.Count() > 0)
            return new GetService(result.ElementAt(0));
            return null;

        }

        public static void AddService(GetService _service)
        {
            string req = "INSERT INTO GetService (phonenumber, idservice, id, starttime, endtime, barcode, col) Values(" + _service.ToString() + ")";
            DataConnection.SendQuery(req);
        }
        public static void DeleteService(string _id)
        {
            string req = "SELECT * FROM GetService WHERE id=\'" + _id + "\'";
            DataConnection.SendQuery(req);
        }
    }
}
