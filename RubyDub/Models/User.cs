using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cassandra;
namespace RubyDub.Models
{
    public class User
    {
        public string username;
        public string phoneunumber;
        public string email;
        public string password;
        public string tokenpass;
        public string lastcode;
        public DateTime date;

        public User(Row _row)
        {
            username = _row["username"] as string;
            phoneunumber = _row["phonenumber"] as string;
            email = _row["email"] as string;
            password = _row["password"] as string;
            tokenpass = _row["tokenpass"] as string;
            lastcode = _row["lastcode"] as string;
            date = DateTime.Parse(_row["date"] as string);
        }

        public User(string _username, string _phonenumber, string _email, string _password, string _tokenpass, string _lastcode, string _date)
        {
            username = _username;
            phoneunumber = _phonenumber;
            email = _email;
            password = _password;
            tokenpass = _tokenpass;
            lastcode = _lastcode;
            if (_date != "")
            date = DateTime.Parse(_date);
        }
        public override string ToString()
        {
            return "\'" + username + "\',\'" + phoneunumber + "\',\'" + email + "\',\'" + password + "\',\'" + tokenpass + "\',\'" + lastcode + "\',\'" + date.Millisecond + "\'";
        }
    }
}
