using MyApp.Models.Entities;

namespace MyApp.Models.DTOs
{
    public class AttributeDto
    {
        public int Id { get; set; }

        public string? Value { get; set; }

        public virtual AttributeNameDto AttributeName { get; set; } = null!;

    //    public virtual ProductDto Product { get; set; } = null!;
    }
}
