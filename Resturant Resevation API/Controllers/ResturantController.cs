using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db;
using Resturant_Resevation_API.Responses;
using Resturant_Resevation_API.Validators;
using ResturantDataModel;

namespace Resturant_Resevation_API.Controllers
{
    [ApiController]
    [Route("api/resturant")]
    public class ResturantController : Controller
    {
        private readonly RestaurantReservationDbContext _context;
        public ResturantController()
        {
            _context = new RestaurantReservationDbContext();
        }

        // GET: api/Customers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Resturants>>> GetResturants()
        {
            return await _context.Resturants.ToListAsync();
        }

        // GET: api/Customers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Resturants>> GetResturant(int id)
        {
            var resturant = await _context.Resturants.FindAsync(id);

            if (resturant == null)
            {
                return NotFound();
            }

            return resturant;
        }

        // POST: api/Customers
        [HttpPost]
        public async Task<ActionResult<Resturants>> PostResturant(Resturants resturant)
        {
            ResturantValidator validator = new ResturantValidator();
            ValidationResult results = validator.Validate(resturant);

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
            _context.Resturants.Add(resturant);
            await _context.SaveChangesAsync();


            return Ok("Resturant is created successfully!");

        }

        // PUT: api/Customers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutResturant(int id, Resturants resturant)
        {
            if (id != resturant.resturant_id)
            {
                return BadRequest("id you provided does not match with the resturant id!");
            }

            _context.Entry(resturant).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ResturantExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok("Resturant updated successfully!");
        }


        // DELETE: api/Customers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteResturant(int id)
        {
            var resturant = await _context.Resturants.FindAsync(id);
            if (resturant == null)
            {
                return NotFound();
            }

            _context.Resturants.Remove(resturant);
            await _context.SaveChangesAsync();

            return Ok($"Resturant with id {id} is deleted successfully!");
        }

        private bool ResturantExists(int id)
        {
            return _context.Customers.Any(e => e.customer_id == id);
        }

    }
}
