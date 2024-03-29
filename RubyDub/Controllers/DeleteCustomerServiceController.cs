﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RubyDub.DAL;
namespace RubyDub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeleteCustomerServiceController : Controller
    {
        [HttpDelete]
        public IActionResult Delete(string id, string token, string phonenumber)
        {
            if (!UserAuthDAL.VerifyToken(phonenumber, token))
                return Unauthorized();
            CustomerServicesDAL.DeleteService(id);
            return Ok();
        }
    }
}