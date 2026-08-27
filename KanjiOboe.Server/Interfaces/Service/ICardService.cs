using KanjiOboe.Server.Database.Entities;
using KanjiOboe.Server.DTOs;

namespace KanjiOboe.Server.Interfaces
{
    public interface ICardService
    {
        Task<List<Card>> GetAllCardsByDeckId(long deckId);
        Task<Card> CreateCardAsync(CreateCardDTO cardDTO);
        Task<Card?> GetCardByIdAsync(long id);
        Task UpdateCardById(long id, UpdateCardDTO cardDTO);
    }
}
