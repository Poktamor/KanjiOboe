using KanjiOboe.Server.Database.Entities;

namespace KanjiOboe.Server.DTOs
{
    public class DeckDTO
    {
        public long DeckId { get; set; }
        public string Name { get; set; } = string.Empty;
        public int CardCount { get; set; }
        public long OwnerId { get; set; }

        public DeckDTO(Deck deck)
        {
            DeckId = deck.DeckId;
            Name = deck.Name;
            CardCount = deck.Cards.Count;
            OwnerId = deck.OwnerId;
        }
    }
}
