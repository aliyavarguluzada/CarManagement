using CarManagement.Entities;
using CarManagement.RequestsResponses;
using CarManagement.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarManagement.Controllers
{
    [ApiController]
    [Route("api/account")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService) => _accountService = accountService;




        [HttpPost("register")]
        public async Task<User> Register(RegisterRequest request) => await _accountService.Register(request);

        [HttpPost("adminregister")]
        public async Task<User> AdminRegister(RegisterRequest request) => await _accountService.AdminRegister(request);


        [HttpPost("login")]
        public async Task<string> Login(LoginRequest request) => await _accountService.Login(request);


    }
}
