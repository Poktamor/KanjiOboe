using Microsoft.EntityFrameworkCore;
using KanjiOboe.Server.Database.Entities;
using KanjiOboe.Server.Interfaces;

namespace KanjiOboe.Server.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext context)
        {
            _context = context;
        }
        public void AddUserAsync(User user)
        { 
            _context.Users.Add(user);
        }

        public void DeleteUser(User user)
        {
            _context.Users.Remove(user);
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User?> GetUserByIdAsync(int deckId)
        {
            return await _context.Users.FindAsync(deckId);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void UpdateUserAsync(User user)
        {
            _context.Users.Update(user);
        }
    }
}
