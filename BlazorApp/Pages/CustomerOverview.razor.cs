using FirstBlazorApp.Model;

namespace FirstBlazorApp.Pages
{
    public partial class CustomerOverview
    {
        public List<Customer>? Customers { get; set; } = default!;
        private Customer? _selectedCustomer;

        //private string Title = "Customer Overview";
        //private string Description = "customer overview";
        protected override void OnInitialized()
        {
            Customers = MockDataService.Customers;
        }

        public void ShowQuickViewPopup(Customer selectedCustomer)
        {
            _selectedCustomer = selectedCustomer;
        }
    }
}
