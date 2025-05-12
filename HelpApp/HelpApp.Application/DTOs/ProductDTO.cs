using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using HelpApp.Domain.Entities;

namespace HelpApp.Application.DTOs
{
    public class ProductDTO
    {
        [Required(ErrorMessage = "Invalid name, name is required.")]
        [MinLength(3)]
        [MaxLength(100)]
        [DisplayName("Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Invalid name, too short, minimum 3 characters.")]
        [MinLength(5)]
        [MaxLength(100)]
        [DisplayName("Required minimum characters.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Invalid price negative value.")]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [DataType(DataType.Currency)]
        [DisplayName("Price")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Invalid stock negative value.")]
        [Range(1, 9999)]
        [DisplayName("Stock")]
        public int Stock { get; set; }

        [MaxLength(250)]
        [DisplayName("Invalid image name, too long, maximum 250 characters.")]
        public string? Image { get; set; }
        
        [JsonIgnore]

        public Category? Category { get; set; }
        
        [DisplayName("Categories")]
        public int CategoryId { get; set; }
    }
}
