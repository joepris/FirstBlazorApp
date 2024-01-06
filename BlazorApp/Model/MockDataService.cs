namespace FirstBlazorApp.Model
{
    public class MockDataService
    {
        private static List<Customer>? _customers = default!;
        private static List<JobCategory> _jobCategories = default!;

        public static List<Customer> Customers
        {
            get
            {
                _jobCategories ??= InitializeMockJobCategories();
                _customers ??= InitializeMockCustomers();
                return _customers;
            }
        }
        private static List<JobCategory> InitializeMockJobCategories()
        {
            return new List<JobCategory>
            {
                new JobCategory{JobCategoryId = 1, JobCategoryName = "Engineering" },
                new JobCategory{JobCategoryId = 2, JobCategoryName = "Sales"},
                new JobCategory{JobCategoryId = 3, JobCategoryName = "Management" },
                new JobCategory{JobCategoryId = 4, JobCategoryName = "Staff"}
            };
        }
        private static List<Customer> InitializeMockCustomers()
        {

            var c1 = new Customer
            {
                CustomerId = 1,
                FirstName = "John",
                LastName = "Doe",
                Age = 12,
                Gender = Gender.Male,
                PhoneNumber = "587-123-4567",
                Email = "John.Doe@Email.com",
                MaritalStatus = MaritalStatus.Single,
                JobCategoryId = _jobCategories[3].JobCategoryId,
                JobCategory = _jobCategories[3]

            };
            var c2 = new Customer
            {
                CustomerId = 2,
                FirstName = "Jane",
                LastName = "Doe",
                Age = 33,
                Gender = Gender.Female,
                PhoneNumber = "403-123-4567",
                Email = "Jane.Doe@Email.com",
                MaritalStatus = MaritalStatus.Married,
                JobCategoryId = _jobCategories[2].JobCategoryId,
                JobCategory = _jobCategories[2]

            };

            return new List<Customer>() { c1, c2 };
        }
    }
}
