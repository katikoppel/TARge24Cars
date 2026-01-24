namespace Cars.Core.Dto
{
    public class CarsDto
    {
        public Guid? Id { get; set; }
        public string? Brand { get; set; }
        public string? Model { get; set; }
        public int? ReleaseYear { get; set; }
        public int? Price { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
    }
}
