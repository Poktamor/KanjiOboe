using KanjiOboe.Server.Database.Entities;
using KanjiOboe.Server.DTOs;
using KanjiOboe.Server.Repositories;
using Microsoft.AspNetCore.Identity;

namespace KanjiOboe.Server.Service
{
    public class UserService
    {
        private readonly UserRepository _userRepository;
        private readonly PasswordHasher<User> _passwordHasher;
        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
            _passwordHasher = new PasswordHasher<User>();
        }
        public async Task<bool> ValidatePassword(string email, string password)
        {
            User? user = await _userRepository.GetUserByEmailAsync(email);
            if (user == null)
            {
                return false;
            }
            var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, password);
            return result == PasswordVerificationResult.Success;
        }

        public async Task RegisterUserAsync(RegisterUserDTO registerUserDTO)
        {
            User? findUser = await _userRepository.GetUserByEmailAsync(registerUserDTO.Email);
            if (findUser != null)
            {
                throw new Exception("Email already exists.");
            }
            User user = new()
            {
                Username = registerUserDTO.Username,
                Email = registerUserDTO.Email
            };

            user.PasswordHash = _passwordHasher.HashPassword(user, registerUserDTO.Password);

            await _userRepository.AddUserAsync(user);
            await _userRepository.SaveChangesAsync();
        }
    }
}
