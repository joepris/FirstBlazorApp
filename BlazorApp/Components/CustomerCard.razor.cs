using FirstBlazorApp.Model;
using Microsoft.AspNetCore.Components;

namespace FirstBlazorApp.Components
{
    public partial class CustomerCard
    {
        [Parameter]
        public Customer Customer { get; set; } = default!;

        [Parameter]
        public EventCallback<Customer> CustomerQuickViewClicked { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        protected override void OnInitialized()
        {
            if (string.IsNullOrEmpty(Customer.LastName))
            {
                throw new Exception("Last name can't be empty");
            }
        }

        public void NavigateToDetails(Customer selectedCustomer)
        {

            NavigationManager.NavigateTo($"/customerdetail/{selectedCustomer.CustomerId}");

        }

    }
}
