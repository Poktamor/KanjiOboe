using KanjiOboe.Server.Database.Entities;
using KanjiOboe.Server.DTOs;
using KanjiOboe.Server.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace KanjiOboe.Server.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly PasswordHasher<User> _passwordHasher;
        public UserService(IUserRepository userRepository)
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

        public async Task<User?> AuthenticateAsync(string email, string password)
        {
            User? user = await _userRepository.GetUserByEmailAsync(email);
            if (user == null)
            {
                return null;
            }
            var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, password);
            if (result == PasswordVerificationResult.Failed)
                return null;
            return user;
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

        public async Task DeleteUserAsync(long userId)
        {
            User? user = await _userRepository.GetUserByIdAsync(userId);
            if (user == null)
                throw new Exception("User does not exist");

            _userRepository.DeleteUser(user);
            await _userRepository.SaveChangesAsync();
        }
    }
}
