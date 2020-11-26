using System;
using APIFel.Model;
using APIFel.Services;
using Microsoft.AspNetCore.Mvc;

namespace APIFel.Controllers
{
    [ApiController]
    [Route("ApiFel")]
    public class LoginController : ControllerBase, ILoginService
    {
        [HttpGet("Login")]
        public Login Login()
        {
            Login login = new Login();
            return login;
        }
    }
}
