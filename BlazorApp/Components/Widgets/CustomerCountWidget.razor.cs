using FirstBlazorApp.Model;
using FirstBlazorApp.Services;
using Microsoft.AspNetCore.Components;

namespace FirstBlazorApp.Components.Widgets
{
    public partial class CustomerCountWidget
    {
        [Inject]
        public ICustomerDataService? CustomerDataService { get; set; }

        public List<Customer>? Customers { get; set; } = default!;
        public int CustomerCounter { get; set; }

        //protected override void OnInitialized()
        //{
        //    CustomerCounter = MockDataService.Customers.Count;
        //}

        protected override async Task OnInitializedAsync()
        {
            Customers = (await CustomerDataService.GetAllCustomers()).ToList();
            CustomerCounter = Customers.Count;
        }
    }
}
