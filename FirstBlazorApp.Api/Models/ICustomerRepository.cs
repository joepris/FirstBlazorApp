using FirstBlazorApp.Model;

namespace FirstBlazorApp.Api.Models
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetAllCustomers();
        Customer GetCustomerById(int customerId);
        Customer AddCustomer(Customer customer);
        Customer UpdateCustomer(Customer customer);
        void DeleteCustomer(int customerId);
        //IEnumerable<EmployeeListModel> GetLongEmployeeList();
        //IEnumerable<EmployeeListModel> GetTakeLongEmployeeList(int request, int count);
    }
}
