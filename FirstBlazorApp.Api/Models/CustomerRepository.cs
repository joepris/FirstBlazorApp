using FirstBlazorApp.Model;

namespace FirstBlazorApp.Api.Models
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AppDbContext _appDbContext;
        private Random random = new Random();

        public CustomerRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return _appDbContext.Customers;
        }

        public Customer GetCustomerById(int customerId)
        {
            return _appDbContext.Customers.FirstOrDefault(c => c.CustomerId == customerId);
        }

        public Customer AddCustomer(Customer employee)
        {
            var addedEntity = _appDbContext.Customers.Add(employee);
            _appDbContext.SaveChanges();
            return addedEntity.Entity;
        }

        public Customer UpdateCustomer(Customer customer)
        {
            var foundCustomer = _appDbContext.Customers.FirstOrDefault(e => e.CustomerId == customer.CustomerId);

            if (foundCustomer != null)
            {
                foundCustomer.MaritalStatus = customer.MaritalStatus;
                foundCustomer.Email = customer.Email;
                foundCustomer.FirstName = customer.FirstName;
                foundCustomer.LastName = customer.LastName;
                foundCustomer.Gender = customer.Gender;
                foundCustomer.PhoneNumber = customer.PhoneNumber;
                foundCustomer.JobCategoryId = customer.JobCategoryId;

                _appDbContext.SaveChanges();

                return foundCustomer;
            }

            return null;
        }

        public void DeleteCustomer(int customerId)
        {
            var foundEmployee = _appDbContext.Customers.FirstOrDefault(e => e.CustomerId == customerId);
            if (foundEmployee == null) return;

            _appDbContext.Customers.Remove(foundEmployee);
            _appDbContext.SaveChanges();
        }
    }
}
