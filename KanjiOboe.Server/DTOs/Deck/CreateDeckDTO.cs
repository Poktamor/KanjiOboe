namespace KanjiOboe.Server.DTOs
{
    public class CreateDeckDTO
    {
        public string Name { get; set; } = string.Empty;
        public long OwnerId { get; set; }
    }
}
