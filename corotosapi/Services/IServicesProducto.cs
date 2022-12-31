using corotosapi.Models;
using corotosapi.Models.Dto;

namespace corotosapi.Services
{
    public interface IServicesProducto
    {
        Task<List<DtoProducto>> GetProductos();
        Task<DtoProducto> GetProductoById(int id);

        Task<DtoProducto> CreateOrUpdate(DtoProducto producto);

        Task<bool> Delete(int id);

    }
}
