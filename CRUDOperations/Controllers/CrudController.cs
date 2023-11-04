using CRUDOperations.Models.CrudModels;
using CRUDOperations.Models.RequestedModels;
using CRUDOperations.Services.CrudServices;
using ExcepitionMidLib.GlobalResponce;
using ExcepitionMidLib.Models;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CRUDOperations.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CrudController : BaseController
    {
        private readonly ICrudService _iCrudService;
        private readonly ILogger<CrudController> _logger;

        public CrudController(ICrudService iCrudService, ILogger<CrudController> logger)
        {
            _iCrudService = iCrudService;
            _logger = logger;
            _logger.LogInformation("Application is Starting....");
        }

        /// <summary>
        /// Get all product data.
        /// </summary>
        /// <returns>Returns all product data from the database with all details.</returns>
        [HttpGet("read")]
        [SwaggerOperation("Get all Product data.", "This API gets all Product Data from the database with all details.")]
        [SwaggerResponse(200, "Product details found successfully", typeof(List<Product>))]
        [SwaggerResponse(401, "Data not found", typeof(HttpActionResponce))]
        [SwaggerResponse(400, "Failed to load Product details.", typeof(HttpActionResponce))]
        [SwaggerResponse(500, "Unexpected error encountered.", typeof(HttpActionResponce))]
        public HttpActionResponce GetData()
        {
            return HttpActionResult(_iCrudService.ReadDataFromDb());
        }

        /// <summary>
        /// Create a new product.
        /// </summary>
        /// <param name="ProductCreate">The product to create.</param>
        /// <returns>Returns the newly created product.</returns>
        [HttpPost("create")]
        [SwaggerOperation("Create a Product.", "This API creates a new Product in the database.")]
        [SwaggerResponse(201, "Product created successfully", typeof(bool))]
        [SwaggerResponse(400, "Failed to create the product.", typeof(HttpActionResponce))]
        [SwaggerResponse(500, "Unexpected error encountered.", typeof(HttpActionResponce))]
        public HttpActionResponce Create(ProductCreate productReq)
        {
            return HttpActionResult(_iCrudService.Create(productReq));
        }

        /// <summary>
        /// Update a product.
        /// </summary>
        /// <param name="id">The ID of the product to update.</param>
        /// <param name="product">The updated product data.</param>
        /// <returns>Returns the updated product.</returns>
        [HttpPut("update/{id}")]
        [SwaggerOperation("Update a Product.", "This API updates an existing Product in the database.")]
        [SwaggerResponse(200, "Product updated successfully", typeof(bool))]
        [SwaggerResponse(400, "Failed to update the product.", typeof(HttpActionResponce))]
        [SwaggerResponse(404, "Product not found", typeof(HttpActionResponce))]
        [SwaggerResponse(500, "Unexpected error encountered.", typeof(HttpActionResponce))]
        public HttpActionResponce Update(int id,ProductUpdate productReq)
        {
            return HttpActionResult(_iCrudService.Update(id, productReq));
        }

        /// <summary>
        /// Delete a product.
        /// </summary>
        /// <param name="productId">The ID of the product to delete.</param>
        /// <returns>Returns an HTTP status code indicating the result of the delete operation.</returns>
        [HttpDelete("delete/{productId}")]
        [SwaggerOperation("Delete a Product.", "This API deletes an existing Product from the database.")]
        [SwaggerResponse(200, "Product deleted successfully", typeof(bool))]
        [SwaggerResponse(404, "Product not found", typeof(HttpActionResponce))]
        [SwaggerResponse(500, "Unexpected error encountered.", typeof(HttpActionResponce))]
        public HttpActionResponce Delete(int productId)
        {
            return HttpActionResult(_iCrudService.Detele(productId));
        }
    }
}
