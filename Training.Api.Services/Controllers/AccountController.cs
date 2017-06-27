namespace Training.Api.Services.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Training.Api.Services.Helper;
    using Training.Api.BusinessLayer.Services;
    using Training.Api.BusinessLayer.DTO;
    using System;

    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private string _connectionString;
        private readonly AccountService _accountService;

        public AccountController()
        {
            var configurationSettings = new ConfigurationSettings();
            _connectionString = configurationSettings.GetConfigurationSetting("ConnectionString");
            _accountService = new AccountService(this._connectionString);
        }

        [HttpGet, Route("Users")]
        public IActionResult GetUser()
        {
            var users = _accountService.GetUsers();
            return Ok(Json(users));
        }

        [HttpPost, Route("Users")]
        public IActionResult AddUser([FromBody]UserDTO newUser)
        {
            try
            {
                var user = _accountService.AddUser(newUser);
                if(user == null)
                {
                    return this.BadRequest(new { message = "Bad request" });
                }
                return this.Ok(new { message = "A new user was created" });
            }
            catch(Exception e)
            {
                throw new Exception("Error: " + e.Message);
            }
        }
    }
}
