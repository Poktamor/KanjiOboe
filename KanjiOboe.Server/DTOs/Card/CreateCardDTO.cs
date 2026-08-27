namespace KanjiOboe.Server.DTOs
{
    public class CreateCardDTO
    {
        public string Front { get; set; } = string.Empty;
        public string Back { get; set; } = string.Empty;
        public long DeckId { get; set; }
    }
}
