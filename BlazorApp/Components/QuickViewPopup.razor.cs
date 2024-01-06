using FirstBlazorApp.Model;
using Microsoft.AspNetCore.Components;

namespace FirstBlazorApp.Components
{
    public partial class QuickViewPopup
    {
        private Customer? _customer;

        [Parameter]
        public Customer? Customer { get; set; }

        protected override void OnParametersSet()
        {
            _customer = Customer;
         
        }

        public void Close()
        {
            _customer = null;
        }
    }
}
