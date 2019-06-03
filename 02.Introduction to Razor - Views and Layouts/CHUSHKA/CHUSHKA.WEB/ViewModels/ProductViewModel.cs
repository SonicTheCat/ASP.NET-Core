using CHUSHKA.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace CHUSHKA.WEB.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        [Required]
        [MinLength(10, ErrorMessage = "Product name can not be empty")]
        public string Name { get; set; }

        [DataType(DataType.Currency)]
        [Range(typeof(decimal), "0.1", "79228162514264337593543950335")]
        public decimal Price { get; set; }

        [Display(Name = "Product Description")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Product Type")]
        public ProductType Type { get; set; }
    }
}