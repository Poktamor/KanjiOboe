using KanjiOboe.Server.Database.Entities;

namespace KanjiOboe.Server.Interfaces
{
    public interface IUserRepository
    {
        Task AddUserAsync(User user);
        void DeleteUser(User user);
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User?> GetUserByIdAsync(int deckId);

        Task<User?> GetUserByEmailAsync(string email);
        void UpdateUserAsync(User user);
        Task SaveChangesAsync();
    }
}
