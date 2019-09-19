using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RubyDub.Models
{
    public class AuthenticationResponse
    {
        public string Token;
        //?????
        public AuthenticationResponse(string _token)
        {
            Token = _token;
        }
    }
}
