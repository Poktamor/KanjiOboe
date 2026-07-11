using KanjiOboe.Server.Database.Entities;

namespace KanjiOboe.Server.Interfaces
{
    public interface IDeckRepository    
    {
        Task AddDeckAsync(Deck deck);
        void DeleteDeck(Deck deck);
        Task<IEnumerable<Deck>> GetAllDecksAsync();
        Task<Deck?> GetDeckByIdAsync(long deckId);
        void UpdateDeck(Deck deck);
        Task SaveChangesAsync();
    }
}
