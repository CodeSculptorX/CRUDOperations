#nullable disable
using CRUDOperations.Models.CrudModels;
using CRUDOperations.Models.RequestedModels;
using ExcepitionMidLib.Exception;
using Microsoft.EntityFrameworkCore;

namespace CRUDOperations.DataContext
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options) { }

        private DbSet<Product> products { get; set; }

        public List<Product> ReadData() => products.Select(x => x).ToList();

        public int Create(Product product)
        {
            products.Add(product);
            var entity = SaveChanges();
            return entity;
        }

        public int Update(int id,ProductUpdate product) 
        {
            var enitity = products.FirstOrDefault(x => x.Id == id);

            if (enitity == null) { return 0; }

            if (product.ProductName != null && !string.IsNullOrEmpty(product.ProductName))
                enitity.ProductName = product.ProductName;
            
            if (product.Price != null )
                enitity.Price = (int)product.Price;
           
            if (product.ProductDetails != null && !string.IsNullOrEmpty(product.ProductDetails))
                enitity.ProductDetails = product.ProductDetails;

            products.Update(enitity);
            var entity = SaveChanges();
            return entity;
        }

        public int Detele(Product product)
        {
            products.Remove(product);
            var entity = SaveChanges();
            return entity;
        }

        public Product GetProductById(int id) => products.Where(x => x.Id == id).FirstOrDefault();
    }
}
