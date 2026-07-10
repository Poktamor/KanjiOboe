using KanjiOboe.Server.Database.Entities;

namespace KanjiOboe.Server.Interfaces
{
    public interface ICardRepository
    {
        void AddCardAsync(Card card);
        void DeleteCard(Card card);
        Task<IEnumerable<Card>> GetAllCardsAsync();
        Task<Card?> GetCardByIdAsync(int cardId);
        void UpdateCardAsync(Card card);
        void SaveChanges();
    }
}
