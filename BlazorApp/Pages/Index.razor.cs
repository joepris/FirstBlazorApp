using FirstBlazorApp.Components.Widgets;

namespace FirstBlazorApp.Pages
{
    public partial class Index
    {
        public List<Type> Widgets { get; set; } = new List<Type>() { typeof(CustomerCountWidget), typeof(InboxWidget) };

    }
}
