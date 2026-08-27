using KanjiOboe.Server.Database.Entities;
using KanjiOboe.Server.DTOs;
using KanjiOboe.Server.Interfaces;

namespace KanjiOboe.Server.Service
{
    public class CardService : ICardService
    {
        private readonly ICardRepository _cardRepository;
        public CardService(ICardRepository cardRepository)
        {
            _cardRepository = cardRepository;
        }

        public async Task<List<Card>> GetAllCardsByDeckId(long deckId)
        {
            var cards = await _cardRepository.GetAllCardsByDeckId(deckId);
            return cards.ToList();
        }

        public async Task<Card> CreateCardAsync(CreateCardDTO cardDTO)
        {
            Card card = new Card
            {
                Front = cardDTO.Front,
                Back = cardDTO.Back,
                CreatedAt = DateTime.UtcNow,
                ReviewAt = DateTime.UtcNow,
                DeckId = cardDTO.DeckId
            };
            await _cardRepository.CreateCardAsync(card);
            await _cardRepository.SaveChangesAsync();
            return card;
        }

        public async Task<Card?> GetCardByIdAsync(long id)
        {
            return await _cardRepository.GetCardByIdAsync(id);
        }

        public async Task UpdateCardById(long id, UpdateCardDTO cardDTO)
        {
            Card? card = await _cardRepository.GetCardByIdAsync(id);
            if (card == null)
            {
                throw new Exception($"Card with id {id} not found");
            }
            _cardRepository.UpdateCard(card);
            await _cardRepository.SaveChangesAsync();
        }
    }

}
