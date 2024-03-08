using System.ComponentModel.DataAnnotations;

namespace MyApp.Models.Requests
{
    public class AttributeNameRequest
    {
        [Required(ErrorMessage = "Name is required!")]
        public string Name { get; set; }
        public int UnitId { get; set; }
    }
}
