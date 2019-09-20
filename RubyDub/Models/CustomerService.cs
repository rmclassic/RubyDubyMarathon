using Cassandra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RubyDub.Models
{
    public class CustomerService : GetService
    {

        public string cardnumber;
        public string condition;
        public int notif;
        public int notiftimeday;
        public int notiftimehour;

        public CustomerService()
        {

        }
        public CustomerService(Row _row)
        {
            phoneunumber = _row["phonenumber"] as string;
            idservice = _row["idservice"] as string;
            id = _row["id"] as string;
            cardnumber = _row["cardnumber"] as string;
            condition = _row["endtime"] as string;
            notif = (int)_row["notif"];
            notiftimeday = (int)_row["notiftimeday"];
            notiftimehour = (int)_row["notiftimehour"];
            starttime = (long)_row["starttime"];
            endtime = (long)_row["endtime"];
            barcode = _row["barcode"] as string;
            col = _row["col"] as string;
           
        }

        public CustomerService(string _phonenumber, string _idservice, string _id, string _cardnumber, string _condition, int _notif, int _notiftimeday, int _notiftimehour)
        {
            idservice = _idservice;
            phoneunumber = _phonenumber;
            id = _id;
            cardnumber = _cardnumber;
            condition = _condition;
            notif = _notif;
            notiftimeday = _notiftimeday;
            notiftimehour = _notiftimehour;
        }
        public override string ToString()
        {
            return "\'" + phoneunumber + "\',\'" + idservice + "\',\'" + id + "\',\'" + cardnumber + "\'," + condition + "," + notif + "," + notiftimeday + "," + notiftimehour;
        }
    }
}
