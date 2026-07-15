using Microsoft.EntityFrameworkCore;

using KanjiOboe.Server.Database.Entities;
using KanjiOboe.Server.Interfaces;

namespace KanjiOboe.Server.Repositories
{
    public class CardRepository : ICardRepository
    {
        private readonly AppDbContext _context;

        public CardRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddCardAsync(Card card)
        {
            await _context.Cards.AddAsync(card);
        }

        public void DeleteCard(Card card)
        {
            _context.Cards.Remove(card);
        }

        public async Task<IEnumerable<Card>> GetAllCardsAsync()
        {
            return await _context.Cards.ToListAsync();
        }

        public async Task<Card?> GetCardByIdAsync(int cardId)
        {
            return await _context.Cards.FindAsync(cardId);
        }

        public void UpdateCard(Card card)
        {
            _context.Cards.Update(card);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
