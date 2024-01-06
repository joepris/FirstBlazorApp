using FirstBlazorApp.Model;
using FirstBlazorApp.Services;
using Microsoft.AspNetCore.Components;

namespace FirstBlazorApp.Pages
{
    public partial class CustomerOverview
    {
        [Inject]
        public ICustomerDataService? CustomerDataService { get; set; }
        //public HttpClient HttpClient { get; set; } 

        public List<Customer>? Customers { get; set; } = default!;
        private Customer? _selectedCustomer;

        //private string Title = "Customer Overview";
        //private string Description = "customer overview";
        protected override async Task OnInitializedAsync()
        {
            Customers = (await CustomerDataService.GetAllCustomers()).ToList();
        }

        public void ShowQuickViewPopup(Customer selectedCustomer)
        {
            _selectedCustomer = selectedCustomer;
        }
    }
}
