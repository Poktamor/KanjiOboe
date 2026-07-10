using KanjiOboe.Server.Database.Entities;
using KanjiOboe.Server.Service;
using Microsoft.AspNetCore.Mvc;

namespace KanjiOboe.Server.Controllers
{
    [ApiController]
    [Route("api/deck")]
    public class DeckController : Controller
    {
        private readonly DeckService _deckService;

        public DeckController(DeckService deckService)
        {
            _deckService = deckService;
        }


        [HttpGet]
        public async Task<ActionResult<List<Deck>>> HttpGetAllDecksAsync()
        {
            List<Deck> decks = await _deckService.GetAllDecksAsync();
            return Ok(decks);
        }

        [HttpPost]
        public async Task<ActionResult<Deck>> HttpCreateDeckAsync([FromBody] Deck deck)
        {
            // Implement the logic to create a new deck using the DeckService
            // For example, you might have a method like _deckService.CreateDeckAsync(deck)
            // After creating the deck, return the created deck with a 201 Created status code
            // return CreatedAtAction(nameof(HttpGetDeckByIdAsync), new { id = createdDeck.Id }, createdDeck);
            return Ok(); // Placeholder response
        }
    }
}
