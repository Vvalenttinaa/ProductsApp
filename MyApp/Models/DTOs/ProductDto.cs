using MyApp.Models.Entities;

namespace MyApp.Models.DTOs
{
    public class ProductDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Code { get; set; } = null!;

        public virtual ICollection<AttributeDto> Attributes { get; set; } = new List<AttributeDto>();

        public virtual TypeDto Type { get; set; } = null!;

        public virtual UnitDto Unit { get; set; } = null!;
    }
}
