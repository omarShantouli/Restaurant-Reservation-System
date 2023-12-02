using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db;
using Resturant_Resevation_API.Responses;
using ResturantDataModel;

namespace Resturant_Resevation_API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/customer")]
    public class CustomerController : Controller
    {
        private readonly RestaurantReservationDbContext _context;
        public CustomerController()
        {
            _context = new RestaurantReservationDbContext();
        }

        // GET: api/Customers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customers>>> GetCustomers()
        {
            return await _context.Customers.ToListAsync();
        }

        // GET: api/Customers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Customers>> GetCustomer(int id)
        {
            var customer = await _context.Customers.FindAsync(id);

            if (customer == null)
            {
                return NotFound();
            }

            return customer;
        }

        // POST: api/Customers
        [HttpPost]
        public async Task<ActionResult<Customers>> PostCustomer(Customers customer)
        {
            CustomerValidator validator = new CustomerValidator();
            ValidationResult results = validator.Validate(customer);

            if (!results.IsValid)
            {
                List<ErrorModel> errors = new List<ErrorModel>();
                foreach (var failure in results.Errors)
                {
                    errors.Add(new ErrorModel()
                    {
                        FieldName = failure.PropertyName,
                        ErrorMessage = failure.ErrorMessage
                    });
                }
                return BadRequest(errors);
            }
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();


            return Ok("Customer is created successfully!");

        }

        // PUT: api/Customers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(int id, Customers customer)
        {
            if (id != customer.customer_id)
            {
                return BadRequest("id you provided does not match with the customer id!");
            }

            _context.Entry(customer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok("Customer updated successfully!");
        }


        // DELETE: api/Customers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();

            return Ok($"Customer with id {id} is deleted successfully!");
        }

        private bool CustomerExists(int id)
        {
            return _context.Customers.Any(e => e.customer_id == id);
        }

    }
}
