using FirstBlazorApp.Model;
using FirstBlazorApp.Services;
using Microsoft.AspNetCore.Components;

namespace FirstBlazorApp.Pages
{
    public partial class CustomerDetail
    {
        [Inject]
        public ICustomerDataService? CustomerDataService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Parameter]
        public string CustomerId { get; set; }
        public Customer Customer { get; set; } = new Customer();

        protected override async Task OnInitializedAsync()
        {
            Customer = await CustomerDataService.GetCustomerDetails(int.Parse(CustomerId));
        }

        public async Task DeleteCustomer()
        {
            var response = await CustomerDataService.DeleteCustomer(Customer.CustomerId);

            // Response is true if successful
            if (response)
            {
                NavigationManager.NavigateTo("/customers?success=edit");
            }
            else
            {
                // Display Error
            }
        }

    }
}
