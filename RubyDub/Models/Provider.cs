using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cassandra;
namespace RubyDub.Models
{
    public class Provider
    {
        public string username;
        public string password;
        public string companyname;
        public string companycode;
        public string ssn;
        public string phonenumber;
        public string cardnumber;

        public Provider(string _username, string _password, string _companyname, string _companycode, string _ssn, string _phonenumber, string _cardnumber)
        {
            username = _username;
            password = _password;
            companyname = _companyname;
            companycode = _companycode;
            ssn = _ssn;
            phonenumber = _phonenumber;
            cardnumber = _cardnumber;
        }

        public Provider(Row _row)
        {
            username = _row["username"] as string;
            phonenumber = _row["phonenumber"] as string;
            companycode = _row["companycode"] as string;
            password = _row["password"] as string;
            companyname = _row["companyname"] as string;
            cardnumber = _row["cardnumber"] as string;
            ssn = _row["ssn"] as string;
        }

        public override string ToString()
        {
            return "\'" + username + "\',\'" + password + "\',\'" + companyname + "\',\'" + companycode + "\',\'" + ssn + "\',\'" + phonenumber + "\',\'" + cardnumber + "\'";
        }
    }
}
