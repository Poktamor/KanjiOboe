using KanjiOboe.Server.Database.Entities;
using KanjiOboe.Server.DTOs;
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

        [HttpGet("{id}")]
        public async Task<ActionResult<Deck>> HttpGetDeckByIdAsync(long id)
        {
            Deck? deck = await _deckService.GetDeckByIdAsync(id);
            if (deck == null)
            {
                return NotFound();
            }
            return Ok(deck);
        }

        [HttpPost]
        public async Task<ActionResult<Deck>> HttpCreateDeckAsync(CreateDeckDTO deckDTO)
        {
            await _deckService.CreateDeckAsync(deckDTO);
            return CreatedAtAction(nameof(HttpGetDeckByIdAsync), new { id = deckDTO.OwnerId }, deckDTO);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> HttpUpdateDeckAsync(long id, UpdateDeckDTO deckDTO)
        {
            await _deckService.UpdateDeckAsync(deckDTO, id);
            return NoContent();
        }
    }
}
