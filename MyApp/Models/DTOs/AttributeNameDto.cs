namespace MyApp.Models.DTOs
{
    public class AttributeNameDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public UnitDto? Unit { get; set; }

    }
}
