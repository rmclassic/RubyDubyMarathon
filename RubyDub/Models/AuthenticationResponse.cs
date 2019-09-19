using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RubyDub.Models
{
    public class AuthenticationResponse
    {
        public string token;
        public AuthenticationResponse(string _token)
        {
            token = _token;
        }
    }
}
