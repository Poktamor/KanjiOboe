namespace KanjiOboe.Server.DTOs
{
    public class CardDTO
    {
        public long CardId { get; set; }
        public string Front { get; set; } = string.Empty;
        public string Back { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime ReviewAt { get; set; } = DateTime.UtcNow;
        public long DeckId { get; set; }
    }
}
