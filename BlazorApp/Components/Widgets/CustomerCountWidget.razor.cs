using FirstBlazorApp.Model;

namespace FirstBlazorApp.Components.Widgets
{
    public partial class CustomerCountWidget
    {
        public int CustomerCounter { get; set; }

        protected override void OnInitialized()
        {
            CustomerCounter = MockDataService.Customers.Count;
        }
    }
}
