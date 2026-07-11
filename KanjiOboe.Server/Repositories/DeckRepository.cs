using Microsoft.EntityFrameworkCore;

using KanjiOboe.Server.Database.Entities;
using KanjiOboe.Server.Interfaces;
using System.Runtime.CompilerServices;

namespace KanjiOboe.Server.Repositories
{
    public class DeckRepository : IDeckRepository
    {
        private readonly AppDbContext _context;

        public DeckRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddDeckAsync(Deck deck)
        {
            await _context.Decks.AddAsync(deck);
        }

        public void DeleteDeck(Deck deck)
        {
            _context.Decks.Remove(deck);
        }

        public async Task<IEnumerable<Deck>> GetAllDecksAsync()
        {
            return await _context.Decks.ToListAsync();
        }

        public async Task<Deck?> GetDeckByIdAsync(long deckId)
        {
            return await _context.Decks.FindAsync(deckId);
        }

        public void UpdateDeck(Deck deck)
        {
            _context.Decks.Update(deck);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
