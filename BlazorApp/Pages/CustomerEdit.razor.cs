using FirstBlazorApp.Model;
using FirstBlazorApp.Services;
using Microsoft.AspNetCore.Components;

namespace FirstBlazorApp.Pages
{
    public partial class CustomerEdit
    {
        [Inject]
        public ICustomerDataService? CustomerDataService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; } 
        [Parameter]
        public string? CustomerId { get; set; }
        public Customer Customer { get; set; } = new Customer();


        protected override async Task OnInitializedAsync()
        {
            if (CustomerId != null && int.TryParse(CustomerId, out int parsedId))
            {
                Customer = await CustomerDataService.GetCustomerDetails(parsedId);
            }
            else
            {
                // Creating Do nothing for now
            }
        }

        private async Task SaveCustomer()
        {
            if (CustomerId != null)
            {
                var response = await CustomerDataService.UpdateCustomer(Customer);

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
            else
            {
                var response = await CustomerDataService.AddCustomer(Customer);

                if (response)
                {
                    NavigationManager.NavigateTo("/customers?success=add");
                }
                else
                {
                    // Display Error
                }
            }
        }
    }
}
