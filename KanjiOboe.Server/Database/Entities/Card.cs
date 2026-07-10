namespace KanjiOboe.Server.Database.Entities
{
    public class Card
    {
        public long CardId { get; set; }
        public string Kanji { get; set; } = string.Empty;
        public string Romaji { get; set; } = string.Empty;
        public string Reading { get; set; } = string.Empty;
        public string Meaning { get; set; } = string.Empty;

        public long DeckId { get; set; }
        public Deck? Deck { get; set; }
    }
}