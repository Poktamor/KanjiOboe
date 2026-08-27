using KanjiOboe.Server.Database.Entities;
using KanjiOboe.Server.DTOs;

namespace KanjiOboe.Server.Interfaces
{
    public interface IDeckService
    {
        Task<List<Deck>> GetAllDecksAsync();
        Task<Deck?> GetDeckByIdAsync(long id);
        Task<Deck> CreateDeckAsync(CreateDeckDTO deckDTO);
        Task UpdateDeckAsync(UpdateDeckDTO deckDTO, long id);
    }
}
