namespace FirstBlazorApp.Model
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public int Age { get; set; } = 0;
        public Gender Gender { get; set; }
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public MaritalStatus MaritalStatus { get; set; }
        public int? JobCategoryId { get; set; }
        public JobCategory? JobCategory { get; set; } = default!;
    }
}
