using KanjiOboe.Server.Database.Entities;
using KanjiOboe.Server.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace KanjiOboe.Server.Service
{
    public class DeckService
    {
        private readonly DeckRepository _deckRepository;
        public DeckService(DeckRepository deckRepository)
        {
            _deckRepository = deckRepository;
        }

        public async Task<List<Deck>> GetAllDecksAsync()
        {
            IEnumerable<Deck> decks = await _deckRepository.GetAllDecksAsync();
            return decks.ToList();
        }

        public async Task CreateDeckAsync(Deck deck)
        {
            await _deckRepository.AddDeckAsync(deck);
            await _deckRepository.SaveChangesAsync();
        }
    }
}
