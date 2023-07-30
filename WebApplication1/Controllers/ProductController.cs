using Data;
using Entities;
using Microsoft.AspNetCore.Mvc;
using System.Security.Authentication;
using System.Web.Http.Cors;
using WebApplication1.IServices;

namespace WebApplication1.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [Route("[controller]/[action]")]
    public class ProductController : ControllerBase
    {

        private readonly IProductService _productService;
        private readonly ServiceContext _serviceContext;

        public ProductController(IProductService productService, ServiceContext serviceContext)
        {
            _productService = productService;
            _serviceContext = serviceContext;

        }

        [HttpPost(Name = "InsertProduct")]
        public int Post([FromQuery] string userName, [FromQuery] string userPassword, [FromBody] ProductItem productItem)
        {
            var selectedUser = _serviceContext.Set<Supplier>()
                               .Where(u => u.name_supplier == userName
                                   && u.Password == userPassword
                                   && u.IdTypeUsuario == 1)
                                .FirstOrDefault();

            if (selectedUser != null)
            {
                return _productService.insertProduct(productItem);
            }
            else
            {
                throw new InvalidCredentialException("El usuario no está autorizado o no existe");
            }
        }

        [HttpPut("{productId}", Name = "UpdateProduct")]
        public IActionResult Put([FromQuery] string userName, [FromQuery] string userPassword, int productId, [FromBody] ProductItem updatedProduct)
        {
            var selectedUser = _serviceContext.Set<Supplier>()
                   .Where(u => u.name_supplier == userName
                       && u.Password == userPassword
                       && u.IdTypeUsuario == 1)
                    .FirstOrDefault();

            if (selectedUser != null)
            {
                _productService.UpdateProduct(productId, updatedProduct);
                return NoContent();
            }
            else
            {
                throw new InvalidCredentialException("El usuario no está autorizado o no existe");
            }
        }

        [HttpDelete("{productId}", Name = "DeleteProduct")]
        public IActionResult Delete([FromQuery] string userName, [FromQuery] string userPassword, int productId)
        {
            var selectedUser = _serviceContext.Set<Supplier>()
                   .Where(u => u.name_supplier == userName
                       && u.Password == userPassword
                       && u.IdTypeUsuario == 1)
                    .FirstOrDefault();

            if (selectedUser != null)
            {
                _productService.DeleteProduct(productId);

                // Devolver una respuesta con un mensaje de éxito o redirigir a una página de éxito
                return Ok(new { message = "Producto eliminado exitosamente" });
            }
            else
            {
                throw new InvalidCredentialException("El usuario no está autorizado o no existe");
            }
        }

        [HttpGet(Name = "GetProducts")]
        public List<ProductItem> Get([FromQuery] string userName, [FromQuery] string userPassword)
        {

            var selectedUser = _serviceContext.Set<Supplier>()
         .Where(u => u.name_supplier == userName
             && u.Password == userPassword
             && u.IdTypeUsuario == 1)
          .FirstOrDefault();

            if (selectedUser != null)
            {
                return _productService.GetProducts();
            }
            else
            {
                throw new InvalidCredentialException("El usuario no está autorizado o no existe");
            }
        }

        [HttpGet(Name = "GetProductsByStockRange")]
        public List<ProductItem> GetGetProductsByStockRange([FromQuery] string userName, [FromQuery] string userPassword, [FromQuery] int minStock, [FromQuery] int maxStock)
        {

            var selectedUser = _serviceContext.Set<Supplier>()
            .Where(u => u.name_supplier == userName
            && u.Password == userPassword
            && u.IdTypeUsuario == 1)
            .FirstOrDefault();

            if (selectedUser != null)
            {
                return _productService.GetProductsByStockRange(minStock, maxStock);
            }
            else
            {
                throw new InvalidCredentialException("El usuario no está autorizado o no existe");
            }
        }
    }
}