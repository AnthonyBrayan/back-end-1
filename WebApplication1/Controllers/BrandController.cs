using Data;
using Entities;
using Microsoft.AspNetCore.Mvc;
using System.Security.Authentication;
using System.Web.Http.Cors;
using WebApplication1.IServices;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [Route("[controller]/[action]")]

    public class BrandController : ControllerBase
    {

        private readonly IBrandService _brandService;
        private readonly ServiceContext _serviceContext;

        public BrandController(IBrandService brandService, ServiceContext serviceContext)
        {
            _brandService = brandService;
            _serviceContext = serviceContext;
        }


        [HttpPost(Name = "InsertBrand")]
        public int Post([FromQuery] string userName, [FromQuery] string userPassword, [FromBody] Brand brand)
        {
            var selectedUser = _serviceContext.Set<Supplier>()
                               .Where(u => u.name_supplier == userName
                                   && u.Password == userPassword
                                   && u.IdTypeUsuario == 1)
                                .FirstOrDefault();

            if (selectedUser != null)
            {
                return _brandService.InsertBrand(brand);
            }
            else
            {
                throw new InvalidCredentialException("El usuario no está autorizado o no existe");
            }
        }

        [HttpPut("{brandId}", Name = "UpdateBrand")]
        public IActionResult Put([FromQuery] string userName, [FromQuery] string userPassword, int brandId, [FromBody] Brand updatedBrand)
        {
            var selectedUser = _serviceContext.Set<Supplier>()
                   .Where(u => u.name_supplier == userName
                       && u.Password == userPassword
                       && u.IdTypeUsuario == 1)
                    .FirstOrDefault();

            if (selectedUser != null)
            {
                _brandService.UpdateBrand(brandId, updatedBrand);
                return NoContent();
            }
            else
            {
                throw new InvalidCredentialException("El usuario no está autorizado o no existe");
            }
        }

        [HttpDelete("{brandId}", Name = "DeleteBrand")]
        public IActionResult Delete([FromQuery] string userName, [FromQuery] string userPassword, int brandId)
        {
            var selectedUser = _serviceContext.Set<Supplier>()
                   .Where(u => u.name_supplier == userName
                       && u.Password == userPassword
                       && u.IdTypeUsuario == 1)
                    .FirstOrDefault();

            if (selectedUser != null)
            {
                _brandService.DeleteBrand(brandId);
                return Ok(new { message = "Marca eliminada exitosamente" });
            }
            else
            {
                throw new InvalidCredentialException("El usuario no está autorizado o no existe");
            }
        }

        [HttpGet(Name = "GetBrands")]
        public IActionResult Get([FromQuery] string userName, [FromQuery] string userPassword)
        {
            var selectedUser = _serviceContext.Set<Supplier>()
                   .Where(u => u.name_supplier == userName
                       && u.Password == userPassword
                       && u.IdTypeUsuario == 1)
                    .FirstOrDefault();

            if (selectedUser != null)
            {
                var brands = _brandService.GetBrands();
                return Ok(brands);
            }
            else
            {
                throw new InvalidCredentialException("El usuario no está autorizado o no existe");
            }
        }

    }
}
