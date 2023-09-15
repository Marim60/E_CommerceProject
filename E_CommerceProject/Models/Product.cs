using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_CommerceProject.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Remote("IsProductNameUnique", "Product", AdditionalFields = "Id", ErrorMessage = "Name already exists.")]
        public string? Name { get; set; }
        public string? Description { get; set; }
        public double? Price { get; set; }
        public string? Image { get; set; }
        public int? Quantity { get; set; }
        //public byte[]? Image { get; set; }
        [ForeignKey("Category")]
        public int ?CategoryId { get; set; }
        
        public virtual Category? Category { get; set; }
    }
}
