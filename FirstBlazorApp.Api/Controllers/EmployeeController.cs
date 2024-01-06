using FirstBlazorApp.Api.Models;
using FirstBlazorApp.Model;
using Microsoft.AspNetCore.Mvc;

namespace FirstBlazorApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _customerRepository;
        //private readonly IWebHostEnvironment _webHostEnvironment;
        //private readonly IHttpContextAccessor _httpContextAccessor;
        public CustomerController(ICustomerRepository customerRepository)//, IWebHostEnvironment webHostEnvironment, IHttpContextAccessor httpContextAccessor)
        {
            _customerRepository = customerRepository;
            //_webHostEnvironment = webHostEnvironment;
            //_httpContextAccessor = httpContextAccessor;
        }

        [HttpGet]
        public IActionResult GetAllCustomers()
        {
            return Ok(_customerRepository.GetAllCustomers());
        }

        [HttpGet("{id}")]
        public IActionResult GetCustomerById(int id)
        {
            return Ok(_customerRepository.GetCustomerById(id));
        }

        [HttpPost]
        public IActionResult CreateCustomer([FromBody] Customer customer)
        {
            if (customer == null)
                return BadRequest();

            if (customer.FirstName == string.Empty || customer.LastName == string.Empty)
            {
                ModelState.AddModelError("Name/FirstName", "The name or first name shouldn't be empty");
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            //handle image upload
            //string currentUrl = _httpContextAccessor.HttpContext.Request.Host.Value;
            //var path = $"{_webHostEnvironment.WebRootPath}\\uploads\\{employee.ImageName}";
            //var fileStream = System.IO.File.Create(path);
            //fileStream.Write(employee.ImageContent, 0, employee.ImageContent.Length);
            //fileStream.Close();

           // employee.ImageName = $"https://{currentUrl}/uploads/{employee.ImageName}";

            var createdCustomer = _customerRepository.AddCustomer(customer);

            return Created("customer", createdCustomer);
        }

        [HttpPut]
        public IActionResult UpdateCustomer([FromBody] Customer customer)
        {
            if (customer == null)
                return BadRequest();

            if (customer.FirstName == string.Empty || customer.LastName == string.Empty)
            {
                ModelState.AddModelError("Name/FirstName", "The name or first name shouldn't be empty");
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var customerToUpdate = _customerRepository.GetCustomerById(customer.CustomerId);

            if (customerToUpdate == null)
                return NotFound();

            _customerRepository.UpdateCustomer(customer);

            return NoContent(); //success
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            if (id == 0)
                return BadRequest();

            var customerToDelete = _customerRepository.GetCustomerById(id);
            if (customerToDelete == null)
                return NotFound();

            _customerRepository.DeleteCustomer(id);

            return NoContent();//success
        }
    }
}
