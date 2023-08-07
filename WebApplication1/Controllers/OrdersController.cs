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
    public class OrdersController : ControllerBase
    {

        private readonly IOrdersService _orderService;
        private readonly ServiceContext _serviceContext;

        public OrdersController(IOrdersService orderService, ServiceContext serviceContext)
        {
            _orderService = orderService;
            _serviceContext = serviceContext;
        }

        [HttpPost(Name = "insertOrders")]
        public int Post([FromQuery] string userName, [FromBody] Orders orders)
        {
            var selectedUser = _serviceContext.Set<Customer>()
                               .Where(u => u.Name_customer == userName
                                   && u.IdTypeUsuario == 2)
                                .FirstOrDefault();

            if (selectedUser != null)
            {
                // Obtener el ID del cliente correspondiente al usuario autenticado
                int customerId = GetCurrentCustomerId(userName);

                // Asignar el ID del cliente al pedido
                orders.IdCustomer = customerId;

                // Asignar el estado del pedido a "Pendiente"
                orders.Order_status = "Pendiente";

                // Guardar el pedido en la base de datos
                return _orderService.insertOrders(orders);
            }
            else
            {
                throw new InvalidCredentialException("El usuario no está autorizado o no existe");
            }
        }

        [HttpGet(Name = "GetOrdersByCustomer")]
        public IActionResult GetOrdersByCustomer([FromQuery] string userName)
        {
            var selectedUser = _serviceContext.Set<Customer>()
                               .Where(u => u.Name_customer == userName
                                   && u.IdTypeUsuario == 2)
                                .FirstOrDefault();

            if (selectedUser != null)
            {
                // Obtener el ID del cliente correspondiente al usuario autenticado
                int customerId = GetCurrentCustomerId(userName);

                // Obtener los pedidos del cliente
                var orders = _orderService.GetOrdersByCustomer(customerId);

                // Devolver los pedidos como resultado
                return Ok(orders);
            }
            else
            {
                throw new InvalidCredentialException("El usuario no está autorizado o no existe");
            }
        }

        private int GetCurrentCustomerId(string userName)
        {
            var customer = _serviceContext.Customer.FirstOrDefault(c => c.Name_customer == userName);
            if (customer != null)
            {
                return customer.Id_customer;
            }
            throw new InvalidCredentialException("No se encontró el cliente correspondiente al usuario autenticado.");
        }

        [HttpGet(Name = "GetAllOrders")]
        public IActionResult GetAllOrders([FromQuery] string userName, [FromQuery] string userPassword)
        {

            var selectedUser = _serviceContext.Set<Supplier>()
                   .Where(u => u.name_supplier == userName
                       && u.Password == userPassword
                       && u.IdTypeUsuario == 1)
                    .FirstOrDefault();

            if (selectedUser != null)
            {
                // Obtener todos los pedidos
                var orders = _orderService.GetAllOrders();

                // Devolver los pedidos como resultado
                return Ok(orders);
            }
            else
            {
                throw new InvalidCredentialException("El usuario no está autorizado o no existe");
            }

        }

            [HttpPatch(Name = "UpdateOrderStatus")]
    public IActionResult UpdateOrderStatus([FromQuery] string userName, [FromQuery] string userPassword, int orderId, string newStatus)
    {


            var selectedUser = _serviceContext.Set<Supplier>()
                   .Where(u => u.name_supplier == userName
                       && u.Password == userPassword
                       && u.IdTypeUsuario == 1)
                    .FirstOrDefault();

            if (selectedUser != null)
            {
                var order = _serviceContext.Orders.FirstOrDefault(o => o.Id_order == orderId);

                if (order != null)
                {
                    // Verificar que el nuevo estado sea válido (por ejemplo, "Entregado")
                    if (newStatus == "Entregado")
                    {
                        // Actualizar el estado del pedido
                        order.Order_status = newStatus;

                        // Guardar los cambios en la base de datos
                        _serviceContext.SaveChanges();

                        return Ok("Estado del pedido actualizado correctamente.");
                    }
                    else
                    {
                        return BadRequest("El nuevo estado del pedido no es válido.");
                    }
                }
                else
                {
                    return NotFound("Pedido no encontrado.");
                }
            }
            else
            {
                throw new InvalidCredentialException("El usuario no está autorizado o no existe");
            }
            // Obtener el pedido por su ID

         }
    }
}
