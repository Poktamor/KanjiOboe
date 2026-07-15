using KanjiOboe.Server.Database.Entities;

namespace KanjiOboe.Server.Interfaces
{
    public interface ICardRepository
    {
        Task AddCardAsync(Card card);
        void DeleteCard(Card card);
        Task<IEnumerable<Card>> GetAllCardsAsync();
        Task<Card?> GetCardByIdAsync(int cardId);
        void UpdateCard(Card card);
        Task SaveChangesAsync();
    }
}
