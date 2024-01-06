using FirstBlazorApp.Model;
using Microsoft.AspNetCore.Components;

namespace FirstBlazorApp.Pages
{
    public partial class CustomerEdit
    {
        [Parameter]

        public string? CustomerId { get; set; }
        public Customer Customer { get; set; } = new Customer();
    }
}
