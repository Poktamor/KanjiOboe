namespace KanjiOboe.Server.Database.Entities
{
    public class User
    {
        public long UserId { get; set; }
        public string Username { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public ICollection<Deck> Decks { get; set; } = new List<Deck>();
    }
}
