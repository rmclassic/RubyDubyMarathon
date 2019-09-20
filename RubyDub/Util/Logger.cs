using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RubyDub.Models;
using RubyDub.DAL;
using System.IO;
namespace RubyDub.Util
{
    public static class Logger
    {
        public static void LogCustomerService(CustomerService _service)
        {
            var baseservice = ServicesDAL.GetService(_service.id);
            var getservice = GetServicesDAL.GetService(_service.id);

            string logstr = DateTime.Now.ToShortDateString() + '\t' + getservice.phoneunumber + '\t' + baseservice.name + '\t' + baseservice.price + '\t' + getservice.price + '\t' + new DateTime(getservice.starttime).ToString() + '\t' + new DateTime(getservice.endtime).ToString() + "\n";
            File.AppendAllText("I:\\test.txt", logstr);
        }
    }
}
