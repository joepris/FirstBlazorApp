using FirstBlazorApp.Model;

namespace FirstBlazorApp.Services
{
    public interface ICustomerDataService
    {
        Task<IEnumerable<Customer>> GetAllCustomers();
        Task<Customer> GetCustomerDetails(int customerId);
        Task<Boolean> AddCustomer(Customer customer);
        Task<Boolean> UpdateCustomer(Customer customer);
        Task<Boolean> DeleteCustomer(int customerId);
    }
}
