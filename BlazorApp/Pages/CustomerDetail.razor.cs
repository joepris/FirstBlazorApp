using FirstBlazorApp.Model;
using Microsoft.AspNetCore.Components;

namespace FirstBlazorApp.Pages
{
    public partial class CustomerDetail
    {
        [Parameter]
        public string CustomerId { get; set; }
        public Customer Customer { get; set; } = new Customer();

        protected override Task OnInitializedAsync()
        {
            Customer = MockDataService.Customers.FirstOrDefault(e => e.CustomerId == int.Parse(CustomerId));

            return base.OnInitializedAsync();
        }

    }
}
