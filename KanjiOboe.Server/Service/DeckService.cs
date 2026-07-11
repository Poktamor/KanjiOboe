using KanjiOboe.Server.Database.Entities;
using KanjiOboe.Server.DTOs;
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

        public async Task<Deck?> GetDeckByIdAsync(long id)
        {
            return await _deckRepository.GetDeckByIdAsync(id);
        }

        public async Task CreateDeckAsync(CreateDeckDTO deckDTO)
        {
            Deck deck = new Deck
            {
                Name = deckDTO.Name,
                OwnerId = deckDTO.OwnerId,
                Owner = null!
            };
            await _deckRepository.AddDeckAsync(deck);
            await _deckRepository.SaveChangesAsync();
        }

        public async Task UpdateDeckAsync(UpdateDeckDTO deckDTO, long id)
        {
            Deck deck = await _deckRepository.GetDeckByIdAsync(id) ?? throw new Exception("Deck not found");
            deck.Name = deckDTO.Name;

            _deckRepository.UpdateDeck(deck);
            await _deckRepository.SaveChangesAsync();
        }
    }
}
