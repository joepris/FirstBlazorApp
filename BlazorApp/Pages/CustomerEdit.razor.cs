using FirstBlazorApp.Model;
using Microsoft.AspNetCore.Components;

namespace FirstBlazorApp.Pages
{
    public partial class CustomerEdit
    {
        [Parameter]

        public string? CustomerId { get; set; }
        public Customer Customer { get; set; } = new Customer();
        private void SaveCustomer(Customer savedCustomer)
        {
            Customer newCustomer = new Customer()
            {
                CustomerId = 3,
                FirstName = savedCustomer.FirstName,
                LastName = savedCustomer.LastName,
                Age = savedCustomer.Age,
                Gender = savedCustomer.Gender,
                MaritalStatus = savedCustomer.MaritalStatus,
                Email = savedCustomer.Email,
                PhoneNumber = savedCustomer.PhoneNumber,
            };
            return 
        }
    }
}
