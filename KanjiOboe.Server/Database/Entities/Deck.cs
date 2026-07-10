namespace KanjiOboe.Server.Database.Entities
{
    public class Deck
    {
        public long DeckId { get; set; }
        public List<Card> Cards { get; set; } = new();
        public long OwnerId { get; set; }
        public User? Owner { get; set; }
    }
}