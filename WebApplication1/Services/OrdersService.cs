using Data;
using Entities;
using WebApplication1.IServices;

namespace WebApplication1.Services
{
    public class OrdersService : BaseContextService, IOrdersService
    {
        public OrdersService(ServiceContext serviceContext) : base(serviceContext)
        {
        }

        public int insertOrders(Orders orders)
        {
            _serviceContext.Orders.Add(orders);
            _serviceContext.SaveChanges();
            return orders.Id_order;
        }

        public List<Orders> GetOrdersByCustomer(int customerId)
        {
            return _serviceContext.Orders
                .Where(o => o.IdCustomer == customerId)
                .ToList();
        }

        public List<Orders> GetAllOrders()
        {
            return _serviceContext.Orders.ToList();
        }

        public void UpdateOrderStatus(int orderId, string newStatus)
        {
            var order = _serviceContext.Orders.FirstOrDefault(o => o.Id_order == orderId);

            if (order != null)
            {
                order.Order_status = newStatus;
                _serviceContext.SaveChanges();
            }
            else
            {
                throw new ArgumentException("Pedido no encontrado.");
            }
        }
    }
}
