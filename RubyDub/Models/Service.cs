using Cassandra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RubyDub.Models
{
    public class Service
    {
        public string name;
        public string id;
        public string price;
        public string period;
        public string pricepp;
        public string col;

        public Service(string _name, string _id, string _price, string _period, string _pricepp, string _col)
        {
            name = _name;
            id = _id;
            price = _price;
            period = _period;
            pricepp = _pricepp;
            col = _col;
        }

        public Service()
        {

        }

        public Service(Row _row)
        {
            id = _row["id"] as string;
            price = _row["price"] as string;
            period = _row["period"] as string;
            pricepp = _row["pricepp"] as string;
            col = _row["col"] as string;
            name = _row["name"] as string;
        }

        public override string ToString()
        {
            return "\'" + name + "\',\'" + id + "\',\'" + price + "\',\'" + period + "\',\'" + pricepp + "\',\'" + col + "\'";
        }
    }
}
