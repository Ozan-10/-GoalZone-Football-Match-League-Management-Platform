using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project5Day.WebApi.Context;
using Project5Day.WebApi.Entities;

namespace Project5Day.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ApiContext _context;

        public CustomerController(ApiContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult CustomerList()
        {
            var values = _context.Customers.ToList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return Ok("Müşteri Eklendi");
        }
        [HttpDelete]
        public IActionResult DeleteCustomer(int id)
        {
            var value = _context.Customers.Find(id);
            _context.Customers.Remove(value);
            _context.SaveChanges();
            return Ok("Müşteri Silindi");
        }
        [HttpGet("GetCustomer")]
        public IActionResult GetCustomer(int id)
        {
            var value =_context.Customers.Find(id);
            return Ok(value);  
        }
        [HttpPut]
        public IActionResult UpdateCustomer(Customer customer)
        {
            _context.Customers.Update(customer);
            _context.SaveChanges();
            return Ok("Müşteri Güncellendi");
        }
    }
}
