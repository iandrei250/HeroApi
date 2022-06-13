namespace HeroApi.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int Age { get; set; }

        public string Email { get; set; }

        public string PasswordHash { get; set; }

        public byte[]? Image { get; set; }

        public string? Description { get; set; }

        public string Country { get; set; }
        
        public DateTime? Birthday { get; set; }
    }
}
