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
        public static void Test()
        {
            Cluster cluster = Cluster.Builder().AddContactPoint(Constants.DatabaseAddress).Build();
            var session = cluster.Connect(Constants.DatabaseKeySpace);


           var res = session.Execute("TRUNCATE GetService");
             res = session.Execute("TRUNCATE Service");
             session.Execute("TRUNCATE CustomerService");
        }

        public static bool IsPhoneNumberAvailable(string _phonenumber)
        {
            Cluster cluster = Cluster.Builder().AddContactPoint(Constants.DatabaseAddress).Build();
            var session = cluster.Connect(Constants.DatabaseKeySpace);
            var result = session.Execute("select * from Customer where phonenumber =\'" + _phonenumber + "\'");
            foreach (Row item in result)
            {
                if (item["tokenpass"] != null)
                    return false;
            }
            return true;
        }

        public static bool Login(string phonenumber, string password)
        {
            Cluster cluster = Cluster.Builder().AddContactPoint(Constants.DatabaseAddress).Build();
            var session = cluster.Connect(Constants.DatabaseKeySpace);
            var result = session.Execute("select * from Customer where phonenumber =\'" + phonenumber + "\' AND password = \'" + password + '\'');

            if (result.Count() > 0)
                return true;
            return false;
        }

        public static bool VerifyToken(string phonenumber, string token)
        {
            Cluster cluster = Cluster.Builder().AddContactPoint(Constants.DatabaseAddress).Build();
            var session = cluster.Connect(Constants.DatabaseKeySpace);
            var result = session.Execute("select * from Customer where phonenumber =\'" + phonenumber + "\' AND token = \'" + token + "\'");
            if (result.Count() == 0)
                return false;
            return true;
        }

        public static bool UserExists(string _phonenumber)
        {
            Cluster cluster = Cluster.Builder().AddContactPoint(Constants.DatabaseAddress).Build();
            var session = cluster.Connect(Constants.DatabaseKeySpace);
            var result = session.Execute("select * from Customer where phonenumber =\'" + _phonenumber + "\'");
            return (result.Count() != 0);
        }


        public static bool IsUserVerified(string _phonenumber)
        {
            string req = "SELECT * FROM Customer WHERE phonenumber=\'" + _phonenumber + "\'";
            Cluster cluster = Cluster.Builder().AddContactPoint(Constants.DatabaseAddress).Build();
            var session = cluster.Connect(Constants.DatabaseKeySpace);
            var result = session.Execute(req);
            return (result.First()["token"] != null);
    }

        public static void SignUserUp(User _user)
        {
            string req = "INSERT INTO Customer (username,phonenumber,email,password,tokenpass,lastcode,enddate) Values(";
            _user.tokenpass = UserAuthDAL.CreateToken(_user.phoneunumber);
            req += _user.ToString() + ')';
            Cluster cluster = Cluster.Builder().AddContactPoint(Constants.DatabaseAddress).Build();
            var session = cluster.Connect(Constants.DatabaseKeySpace);
            var result = session.Execute(req);
        }

        public static string CreateToken(string phonenumber)
        {
            string token = StringGenerator.GenerateRandomString(50);
            string req = "UPDATE Customer SET tokenpass=\'" + token + "\' WHERE phonenumber=\'" + phonenumber + "\'";
            Cluster cluster = Cluster.Builder().AddContactPoint(Constants.DatabaseAddress).Build();
            var session = cluster.Connect(Constants.DatabaseKeySpace);
            var result = session.Execute(req);
            return token;
        }

        public static bool VerifyUser(string code, string phonenumber)
        {
            string req = "SELECT * FROM Customer WHERE phonenumber=\'" + phonenumber + "\' AND lastcode=\'" + code + "\' ALLOW FILTERING";
            Cluster cluster = Cluster.Builder().AddContactPoint(Constants.DatabaseAddress).Build();
            var session = cluster.Connect(Constants.DatabaseKeySpace);
            var result = session.Execute(req);
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
                Cluster cluster = Cluster.Builder().AddContactPoint(Constants.DatabaseAddress).Build();
                var session = cluster.Connect(Constants.DatabaseKeySpace);
                session.Execute(req);
            }
            else
            {
                _user.lastcode = StringGenerator.GenerateRandomString(6, false, true);
                _user.date = DateTime.Now.Ticks;
                string req = "UPDATE Customer SET lastcode=\'" + StringGenerator.GenerateRandomString(6, false, true) + "\' date=" + DateTime.Now + "WHERE phonenumber=\'" + _user.phoneunumber + "\'";
                req += _user.ToString() + ')';
                SMSManagement.SendVerificationCode(_user);
                Cluster cluster = Cluster.Builder().AddContactPoint(Constants.DatabaseAddress).Build();
                var session = cluster.Connect(Constants.DatabaseKeySpace);
                session.Execute(req);
            }
        }
    }
}
