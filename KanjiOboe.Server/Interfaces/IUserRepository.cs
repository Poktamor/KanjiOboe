using KanjiOboe.Server.Database.Entities;

namespace KanjiOboe.Server.Interfaces
{
    public interface IUserRepository
    {
        void AddUserAsync(User user);
        void DeleteUser(User user);
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User?> GetUserByIdAsync(int deckId);
        void UpdateUserAsync(User user);
        void SaveChanges();
    }
}
