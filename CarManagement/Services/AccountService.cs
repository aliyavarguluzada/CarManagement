using CarManagement.Data;
using CarManagement.Entities;
using CarManagement.Enums;
using CarManagement.RequestsResponses;
using Microsoft.EntityFrameworkCore;

namespace CarManagement.Services
{
    public class AccountService : IAccountService
    {
        private readonly ApplicationDbContext _context;
        private readonly IAuthService _authService;

        public AccountService(IAuthService authService, ApplicationDbContext context)
        {
            _authService = authService;
            _context = context;
        }

        public async Task<string> Login(LoginRequest request)
        {
            if (request.Email == string.Empty || request.Password == string.Empty)
                return "Email or password is wrong";


            var user = await _context.Users.Where(c => c.Email == request.Email)
                .Include(c => c.UserRole)
                .FirstAsync();

            if (user is null)
                return "No such User Exists";

            var validatePass = user.VerifyPassword(request.Password);

            if (validatePass is false)
                return "Password is wrong";

            var token = _authService.GenerateToken(user);

            return token;
        }

        public async Task<User> Register(RegisterRequest request)
        {
            var newUser = new User
            {
                Name = request.Name,
                Email = request.Email,
                UserRoleId = (int)UserRolesEnum.Customer

            };

            newUser.CreatePassword(request.Password);

            await _context.Users.AddAsync(newUser);

            await _context.SaveChangesAsync();
            return newUser;
        }
        public async Task<User> AdminRegister(RegisterRequest request)
        {
            var newUser = new User
            {
                Name = request.Name,
                Email = request.Email,
                UserRoleId = (int)UserRolesEnum.Admin

            };

            newUser.CreatePassword(request.Password);

            await _context.Users.AddAsync(newUser);

            await _context.SaveChangesAsync();
            return newUser;
        }

    }
}
