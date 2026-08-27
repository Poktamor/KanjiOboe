using KanjiOboe.Server.Database.Entities;
using KanjiOboe.Server.DTOs;

namespace KanjiOboe.Server.Interfaces
{
    public interface IUserService
    {
        Task<bool> ValidatePassword(string email, string password);
        Task<User?> AuthenticateAsync(string email, string password);
        Task RegisterUserAsync(RegisterUserDTO registerUserDTO);
        Task DeleteUserAsync(long userId);
    }
}
