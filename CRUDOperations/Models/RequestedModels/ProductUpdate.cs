#nullable disable
using System.ComponentModel.DataAnnotations;

namespace CRUDOperations.Models.RequestedModels
{
    public class ProductUpdate
    {
        public string ProductName { get; set; }
        public int? Price { get; set; }
        public string ProductDetails { get; set; }
    }
}
