using KanjiOboe.Server.Database.Entities;
using KanjiOboe.Server.DTOs;
using KanjiOboe.Server.Service;
using Microsoft.AspNetCore.Mvc;

namespace KanjiOboe.Server.Controllers
{
    [ApiController]
    public class CardController : Controller
    {
        private readonly CardService _cardService;
        public CardController(CardService cardService)
        {
            _cardService = cardService;
        }

        [HttpGet]
        [Route("api/card/{id}")]
        public async Task<ActionResult<List<Card>>> GetAllCardsByDeckId(long id)
        {
            List<Card> cards = await _cardService.GetAllCardsByDeckId(id);
            return Ok(cards);
        }

        [HttpPost]
        [Route("api/card")]
        public async Task<ActionResult<Card>> CreateCard(CreateCardDTO cardDTO)
        {
            _cardService.CreateCardAsync(cardDTO);
            return CreatedAtAction(nameof(GetAllCardsByDeckId), new { id = card.CardId }, card);
        }
}
