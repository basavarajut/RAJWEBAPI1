namespace RAJWEBAPI1.Models.DTO
{
    public record ContactDTO
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool Favorite { get; set; }
    }
}
