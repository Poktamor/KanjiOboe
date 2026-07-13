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
        public async Task AddUserAsync(User user)
        { 
            await _context.Users.AddAsync(user);
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

        public async Task<User?> GetUserByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(e => e.Email == email);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void UpdateUserAsync(User user)
        {
            _context.Users.Update(user);
        }
    }
}
