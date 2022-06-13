namespace HeroApi.Models
{
    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Surname { get; set; }

        public int? Age { get; set; }
        public int? Height { get; set; }
        public int? Weight { get; set; }

        public string? Background { get; set; }
        public string? Ability_Description { get; set; }

        public byte[]? Image { get; set; }

    }
}
