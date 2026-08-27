using KanjiOboe.Server.Database.Entities;

namespace KanjiOboe.Server.Interfaces
{
    public interface ICardRepository
    {
        Task CreateCardAsync(Card card);
        void DeleteCard(Card card);
        Task<IEnumerable<Card>> GetAllCardsAsync();
        Task<Card?> GetCardByIdAsync(long cardId);
        Task<IEnumerable<Card>> GetAllCardsByDeckId(long deckId);
        void UpdateCard(Card card);
        Task SaveChangesAsync();
    }
}
