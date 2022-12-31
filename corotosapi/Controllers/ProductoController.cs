using corotosapi.Models;
using corotosapi.Models.Dto;
using corotosapi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace corotosapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    { 

        private readonly IServicesProducto _dbServices;
        public ProductoController(IServicesProducto services)
        {
            _dbServices = services;
        }

        [HttpGet]
        public async Task<ActionResult<List<DtoProducto>>> GetProductos()
        {
            return await _dbServices.GetProductos();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<DtoProducto>> GetProductoById(int id)
        {
            try
            {
                return await _dbServices.GetProductoById(id);
            }
            catch (Exception)
            {
                return BadRequest("No existe un producto con este id");
            }
        }

        [HttpPost]
        public async Task<ActionResult<DtoProducto>> CreateProducto(DtoProducto dtoProducto)
        {
            try
            {
                DtoProducto producto = await _dbServices.CreateOrUpdate(dtoProducto);
                return CreatedAtAction("GetProductoById", new { id = producto.Id }, producto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut]
        public async Task<ActionResult<DtoProducto>> updateProducto(DtoProducto dtoProducto)
        {
            try
            {
                DtoProducto producto = await _dbServices.CreateOrUpdate(dtoProducto);
                return CreatedAtAction("GetProductoById", new { id = producto.Id }, producto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteProducto(int id)
        {
            bool isRemove = await _dbServices.Delete(id);
            if (isRemove)
            {
                return Ok("Se elimino");
            } else
            {
                return BadRequest("No se pudo eliminar este producto");
            }
        }






    }
}
