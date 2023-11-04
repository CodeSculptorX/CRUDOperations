using CRUDOperations.Models.CrudModels;
using CRUDOperations.Models.RequestedModels;

namespace CRUDOperations.Services.CrudServices
{
    public interface ICrudService
    {
        List<Product> ReadDataFromDb();
        bool Create(ProductCreate productReq);

        bool Update(int id,ProductUpdate productReq);

        bool Detele(int productId);
    }
}