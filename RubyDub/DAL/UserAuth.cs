using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cassandra.Data;
using System.Data.SqlClient;
using Cassandra;
using RubyDub.Models;
using RubyDub.Util;
namespace RubyDub.DAL
{
    public static class UserAuthDAL
    { 
        public static bool IsPhoneNumberAvailable(string _phonenumber)
        {
            string req = "select * from Customer where phonenumber =\'" + _phonenumber + "\'";
            var result = DataConnection.SendQuery(req);
            foreach (Row item in result)
            {
                if (item["tokenpass"] != null)
                    return false;
            }
            return true;
        }

        public static bool Login(string phonenumber, string password)
        {
            string req = "select * from Customer where phonenumber =\'" + phonenumber + "\' AND password = \'" + password + '\'';

            var result = DataConnection.SendQuery(req);
            if (result.Count() > 0)
                return true;
            return false;
        }

        public static bool VerifyToken(string phonenumber, string token)
        {
            string req = "select * from Customer where phonenumber =\'" + phonenumber + "\' AND token = \'" + token + "\'";
            var result = DataConnection.SendQuery(req);
            if (result.Count() > 0 && result.ElementAt(0) != null)
                return false;
            return true;
        }

        public static bool UserExists(string _phonenumber)
        {
            string req = "select * from Customer where phonenumber =\'" + _phonenumber + "\'";
            var result = DataConnection.SendQuery(req);
            return (result.Count() != 0);
        }


        public static bool IsUserVerified(string _phonenumber)
        {
            string req = "SELECT * FROM Customer WHERE phonenumber=\'" + _phonenumber + "\'";
            var result = DataConnection.SendQuery(req);
            if (result.Count() > 0)
                return (result.First()["token"] != null);
            return false;
    }

        public static void SignUserUp(User _user)
        {
            string req = "INSERT INTO Customer (username,phonenumber,email,password,tokenpass,lastcode,enddate) Values(";
            _user.tokenpass = UserAuthDAL.CreateToken(_user.phoneunumber);
            req += _user.ToString() + ')';
            DataConnection.SendQuery(req);
        }

        public static string CreateToken(string phonenumber)
        {
            string token = StringGenerator.GenerateRandomString(50);
            string req = "UPDATE Customer SET tokenpass=\'" + token + "\' WHERE phonenumber=\'" + phonenumber + "\'";
            DataConnection.SendQuery(req);
            return token;
        }

        public static bool VerifyUser(string code, string phonenumber)
        {
            string req = "SELECT * FROM Customer WHERE phonenumber=\'" + phonenumber + "\' AND lastcode=\'" + code + "\' ALLOW FILTERING";
            var result = DataConnection.SendQuery(req);

            if (result.Count() == 0)
                return false;
            return true;
        }

        public static void SendUserVerificationCode(User _user)
        {
            if (!UserExists(_user.phoneunumber))
            {
                _user.lastcode = StringGenerator.GenerateRandomString(6, false, true);
                _user.date = DateTime.Now.Ticks;
                string req = "INSERT INTO Customer (username,phonenumber,email,password,tokenpass,lastcode,enddate,score) Values(";
                req += _user.ToString() + ')';
                SMSManagement.SendVerificationCode(_user);
                DataConnection.SendQuery(req);
            }
            else
            {
                _user.lastcode = StringGenerator.GenerateRandomString(6, false, true);
                _user.date = DateTime.Now.Ticks;
                string req = "UPDATE Customer SET lastcode=\'" + StringGenerator.GenerateRandomString(6, false, true) + "\' date=" + DateTime.Now + "WHERE phonenumber=\'" + _user.phoneunumber + "\'";
                req += _user.ToString() + ')';
                SMSManagement.SendVerificationCode(_user);
                DataConnection.SendQuery(req);
            }
        }
    }
}
