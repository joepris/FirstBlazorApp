using FirstBlazorApp.Model;
using System.Text;
using System.Text.Json;

namespace FirstBlazorApp.Services
{
    public class CustomerDataService : ICustomerDataService
    {
        private readonly HttpClient _httpClient;
        public CustomerDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<Boolean> AddCustomer(Customer customer)
        {
            var jsonCustomer = JsonSerializer.Serialize(customer);
            var content = new StringContent(jsonCustomer, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync($"api/customer/", content);

            return response.IsSuccessStatusCode;
        }

        public async Task<Boolean> DeleteCustomer(int customerId)
        {

            var response = await _httpClient.DeleteAsync($"api/customer/{customerId}");

            return response.IsSuccessStatusCode;
        }

        public async Task<IEnumerable<Customer>> GetAllCustomers()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<Customer>>
                (await _httpClient.GetStreamAsync($"api/customer"), 
                new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<Customer> GetCustomerDetails(int customerId)
        {
            return await JsonSerializer.DeserializeAsync<Customer>
                (await _httpClient.GetStreamAsync($"api/customer/{customerId}"),
                new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<Boolean> UpdateCustomer(Customer customer)
        {
            var jsonCustomer = JsonSerializer.Serialize(customer);
            var content = new StringContent(jsonCustomer, Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync($"api/customer/{customer.CustomerId}", content);

            return response.IsSuccessStatusCode;
        }
    }
}
