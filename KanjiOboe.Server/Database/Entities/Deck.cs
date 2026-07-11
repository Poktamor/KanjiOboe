namespace KanjiOboe.Server.Database.Entities
{
    public class Deck
    {
        public long DeckId { get; set; }
        public string Name { get; set; } = string.Empty;
        public long OwnerId { get; set; }
        public User Owner { get; set; } = null!;
        public ICollection<Card> Cards { get; set; } = new List<Card>();
    }
}