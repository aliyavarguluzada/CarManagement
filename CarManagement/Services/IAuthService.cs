using CarManagement.Entities;

namespace CarManagement.Services
{
    public interface IAuthService
    {
        public string GenerateToken(User user);
        public string ValidateToken(string token);
    }
}
