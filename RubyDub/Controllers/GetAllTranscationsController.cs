using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RubyDub.Models;
using RubyDub.DAL;
namespace RubyDub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetAllTranscationsController : Controller
    {
        [HttpGet]
        public IActionResult Get(string phonenumber, string token)
        {
            if (!UserAuthDAL.VerifyToken(phonenumber, token))
                return Unauthorized();
            var transcations = TransactionsDAL.GetTransactions(phonenumber);
            return Ok(transcations);
        }
    }
}