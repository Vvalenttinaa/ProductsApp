using System.ComponentModel.DataAnnotations;

namespace MyApp.Models.Requests
{
    public class ProductRequest
    {
        [Required(ErrorMessage = "Name is required!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Code is required!")]
        public string Code { get; set; }
        
        [Required(ErrorMessage = "Unit is required!")]
        public int UnitId { get; set; }

        [Required(ErrorMessage = "Type is required!")]
        public int TypeId { get; set; }

      //  [Required(ErrorMessage = "Attributes are required!")]
        public ICollection<AttributeRequest> Attributes { get; set; }

    }
}
