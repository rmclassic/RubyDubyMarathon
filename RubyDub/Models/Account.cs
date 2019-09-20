using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cassandra;
namespace RubyDub.Models
{
    public class Account
    {
        public string cardnumber;
        public string password;
        public string cv2;
        public int month;
        public int year;
        public string phonenumber;

        public Account(string _cardnumber, string _password, string _cv2, int _month, int _year, string _phonenumber)
        {
            cardnumber = _cardnumber;
            password = _password;
            cv2 = _cv2;
            month = _month;
            year = _year;
            phonenumber = _phonenumber;
        }

        public Account(Row _row)
        {
            cardnumber = _row["cardnumber"] as string;
            password = _row["password"] as string;
            cv2 = _row["cv2"] as string;
            month = (int)_row["month"];
            year = (int)_row["year"];
            phonenumber = _row["phonenumber"] as string;
        }

        public override string ToString()
        {
            return "\'" + cardnumber + "\',\'" + password + "\',\'" + cv2 + "\'," + month + "," + year + ",\'" + phonenumber + "\'";
        }
    }
}
