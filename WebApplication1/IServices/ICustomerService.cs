using Entities;

namespace WebApplication1.IServices
{
    public interface ICustomerService
    {
        int InsertCustomer(Customer customer);
        void UpdateCustomer(int customertId, Customer updatedCustomer);
        void DeleteCustomer(int customerId);
        List<Customer> GetCustomers();
    }
}
