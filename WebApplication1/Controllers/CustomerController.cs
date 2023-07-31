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
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly ServiceContext _serviceContext;

        public CustomerController(ICustomerService customerService, ServiceContext serviceContext)
        {
            _customerService = customerService;
            _serviceContext = serviceContext;

        }

        [HttpPost(Name = "InsertCustomer")]
        public int Post([FromQuery] string userName, [FromQuery] string userPassword, [FromBody] Customer customer)
        {
            var selectedUser = _serviceContext.Set<Supplier>()
                               .Where(u => u.name_supplier == userName
                                   && u.Password == userPassword
                                   && u.IdTypeUsuario == 1)
                                .FirstOrDefault();

            if (selectedUser != null)
            {
                return _customerService.InsertCustomer(customer);
            }
            else
            {
                throw new InvalidCredentialException("El usuario no está autorizado o no existe");
            }
        }

        [HttpPut("{customerId}", Name = "UpdateCustomer")]
        public IActionResult Put([FromQuery] string userName, [FromQuery] string userPassword, int customerId, [FromBody] Customer updatedCustomer)
        {
            var selectedUser = _serviceContext.Set<Supplier>()
                   .Where(u => u.name_supplier == userName
                       && u.Password == userPassword
                       && u.IdTypeUsuario == 1)
                    .FirstOrDefault();

            if (selectedUser != null)
            {
                _customerService.UpdateCustomer(customerId, updatedCustomer);
                return NoContent();
            }
            else
            {
                throw new InvalidCredentialException("El usuario no está autorizado o no existe");
            }
        }

        [HttpDelete("{customerId}", Name = "DeleteCustomer")]
        public IActionResult Delete([FromQuery] string userName, [FromQuery] string userPassword, int customerId)
        {
            var selectedUser = _serviceContext.Set<Supplier>()
                   .Where(u => u.name_supplier == userName
                       && u.Password == userPassword
                       && u.IdTypeUsuario == 1)
                    .FirstOrDefault();

            if (selectedUser != null)
            {
                _customerService.DeleteCustomer(customerId);
                return Ok(new { message = "Cliente eliminado exitosamente" });
            }
            else
            {
                throw new InvalidCredentialException("El usuario no está autorizado o no existe");
            }
        }

        [HttpGet(Name = "GetAllCustomers")]
        public IActionResult GetCustomers([FromQuery] string userName, [FromQuery] string userPassword)
        {
            var selectedUser = _serviceContext.Set<Supplier>()
                   .Where(u => u.name_supplier == userName
                       && u.Password == userPassword
                       && u.IdTypeUsuario == 1)
                    .FirstOrDefault();

            if (selectedUser != null)
            {
                var customers = _customerService.GetCustomers();
                return Ok(customers);
            }
            else
            {
                throw new InvalidCredentialException("El usuario no está autorizado o no existe");
            }
        }
    }
}
