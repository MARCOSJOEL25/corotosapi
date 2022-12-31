using AutoMapper;
using corotosapi.Models;
using corotosapi.Models.Dto;
using Microsoft.EntityFrameworkCore;

namespace corotosapi.Services
{
    public class ServicesProducto : IServicesProducto
    {
        private readonly corotosapiContext _db;
        private readonly IMapper _mapper;
        public ServicesProducto(corotosapiContext context, IMapper mapper)
        {
            _db = context;
            _mapper = mapper;
        }
        public async Task<DtoProducto> CreateOrUpdate(DtoProducto producto)
        {
            Producto Producto = _mapper.Map<DtoProducto, Producto>(producto);
            if (Producto.Id > 0)
            {
                _db.Productos.Update(Producto);
            }
            else
            {
                await _db.Productos.AddAsync(Producto);
            }
            await _db.SaveChangesAsync();
            return _mapper.Map<DtoProducto>(Producto);
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                Producto producto = await _db.Productos.FindAsync(id);
                if (producto == null)
                {
                    return false;
                }
                _db.Productos.Remove(producto);
                await _db.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<DtoProducto> GetProductoById(int id)
        {
            Producto producto = await _db.Productos.FindAsync(id);
            return _mapper.Map<DtoProducto>(producto);
        }

        public async Task<List<DtoProducto>> GetProductos()
        {
            List<Producto> listProducto = await _db.Productos.ToListAsync();
            return _mapper.Map<List<DtoProducto>>(listProducto);
        }
    }
}
