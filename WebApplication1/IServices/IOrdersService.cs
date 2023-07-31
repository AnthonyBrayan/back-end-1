using Entities;

namespace WebApplication1.IServices
{
    public interface IOrdersService
    {
        int insertOrders(Orders orders);

        List<Orders> GetOrdersByCustomer(int customerId);

        List<Orders> GetAllOrders();
    }
}
