using System.ComponentModel.DataAnnotations;

namespace MyApp.Models.Requests
{
    public class AttributeRequest
    {
            [Required(ErrorMessage = "Name is required!")]
            public int AttributeNameId { get; set; }
            [Required(ErrorMessage = "Value is required!")]
            public string  Value { get; set; }
            [Required(ErrorMessage = "Product is required!")]
            public int ProductId { get; set; }
    }
}
