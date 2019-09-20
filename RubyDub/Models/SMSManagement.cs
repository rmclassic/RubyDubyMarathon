using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
namespace RubyDub.Models
{
    public static class SMSManagement
    {
        public static void SendVerificationCode(User _user)
        {
            
            using (WebClient client = new WebClient())
            {
                byte[] response = client.UploadValues("http://textbelt.com/text", new NameValueCollection() {
                { "phone", "+989303567288" },
                { "message", "Your hey-pay verification code is: " + _user.lastcode },
                { "key", "textbelt" },
            });

                string result = System.Text.Encoding.UTF8.GetString(response);
            }
        }
    }
}
