using Data;
using Entities;
using WebApplication1.IServices;

namespace WebApplication1.Services
{
        public class CustomerService : BaseContextService, ICustomerService
        {
            public CustomerService(ServiceContext serviceContext) : base(serviceContext)
            {
            }


            public int InsertCustomer(Customer customer)
            {
                _serviceContext.Customer.Add(customer);
                _serviceContext.SaveChanges();
                return customer.Id_customer;
            }

            public void UpdateCustomer(int customerId, Customer updatedCustomer)
            {
                var existingCustomer = _serviceContext.Customer.FirstOrDefault(c => c.Id_customer == customerId);

                if (existingCustomer == null)
                {
                    // Si el producto no existe, podrías lanzar una excepción o manejar el caso según tus requerimientos.
                    throw new InvalidOperationException("El cliente no existe.");
                }

                // Actualiza las propiedades del producto con la información del producto modificado
                existingCustomer.Name_customer = updatedCustomer.Name_customer;
                existingCustomer.Email = updatedCustomer.Email;

                _serviceContext.SaveChanges();
            }

             public void DeleteCustomer(int customerId)
             {
                var customer = _serviceContext.Customer.Find(customerId);
                if (customer != null)
                {
                _serviceContext.Customer.Remove(customer);
                _serviceContext.SaveChanges();
                }
                else
                {
                throw new InvalidOperationException("El cliente no existe.");
                }
             }

             public List<Customer> GetCustomers()
             {
                return _serviceContext.Customer.ToList();
             }

    }   
}
