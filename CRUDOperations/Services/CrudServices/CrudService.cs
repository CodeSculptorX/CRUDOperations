#nullable disable
using CRUDOperations.Common;
using CRUDOperations.DataContext;
using CRUDOperations.Models.CrudModels;
using CRUDOperations.Models.RequestedModels;
using ExcepitionMidLib.Exception;
using System.Net;

namespace CRUDOperations.Services.CrudServices
{
    public class CrudService : ICrudService
    {
        private readonly ProductDbContext _dbContext;

        public CrudService(ProductDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// This method gets all Product Data from the database with all details.
        /// </summary>
        /// <returns>List of product details</returns>
        public List<Product> ReadDataFromDb()
        {
            var data = _dbContext.ReadData();
            if(data.Count == 0)
                return null;
            return data;
        }

        /// <summary>
        /// This method creates a new Product in the database.
        /// </summary>
        /// <param name="productReq">Product details</param>
        /// <returns>True if product create successfully otherwise false.</returns>
        public bool Create(ProductCreate productReq)
        {
            Product product = new()
            {
                ProductName = productReq.ProductName,
                Price = productReq.Price,
                ProductDetails = productReq.ProductDetails
            };
            if (_dbContext.Create(product) == 0)
                return false;
            return true;
        }

        /// <summary>
        /// This Method Update a Product.
        /// </summary>
        /// <param name="id">Product Id</param>
        /// <param name="productReq">Product Details</param>
        /// <returns>True if product update successfully otherwise false.</returns>
        /// <exception cref="ApiException">If product does not exists.</exception>
        public bool Update(int id, ProductUpdate productReq)
        {
            if (id == 0)
                throw new ApiException(HttpStatusCode.NotAcceptable, 406, Constants.Exception_Message_ProductNotFound);

            Product productData = _dbContext.GetProductById(id);
            if (productData == null) throw new ApiException(HttpStatusCode.NoContent, 204, Constants.Exception_Message_ProductNotFound);

            if (_dbContext.Update(id, productReq) == 0)
                return false;
            return true;
        }

        /// <summary>
        /// This Method deletes an existing Product from the database.
        /// </summary>
        /// <param name="productId">Product Id</param>
        /// <returns>True if product delete successfully otherwise false.</returns>
        /// <exception cref="ApiException">If product does not exists.</exception>
        public bool Detele(int productId)
        {
            if (productId == 0)
                throw new ApiException(HttpStatusCode.NotAcceptable, 406, Constants.Exception_Message_ProductNotFound);

            Product productData = _dbContext.GetProductById(productId);
            if (productData == null) throw new ApiException(HttpStatusCode.NoContent, 204,Constants.Exception_Message_ProductNotFound);

            if (_dbContext.Detele(productData) == 0)
                return false;
            return true;
        }
    }
}
