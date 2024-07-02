using CarManagement.Entities;
using CarManagement.RequestsResponses;

namespace CarManagement.Services
{
    public interface IAccountService
    {
        public Task<User> Register(RegisterRequest request);
        public Task<User> AdminRegister(RegisterRequest request);
        public Task<string> Login(LoginRequest request);

    }
}
