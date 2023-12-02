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
    [Route("api/reservation")]
    public class ReservationController : Controller
    {
        private readonly RestaurantReservationDbContext _context;
        public ReservationController()
        {
            _context = new RestaurantReservationDbContext();
        }

        // GET: api/Customers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reservations>>> GetReservations()
        {
            return await _context.Reservations.ToListAsync();
        }

        // GET: api/Customers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Reservations>> GetReservation(int id)
        {
            var reservation = await _context.Reservations.FindAsync(id);

            if (reservation == null)
            {
                return NotFound();
            }

            return reservation;
        }

        // POST: api/Customers
        [HttpPost]
        public async Task<ActionResult<Reservations>> PostReservation(Reservations reservation)
        {
            ReservationValidator validator = new ReservationValidator();
            ValidationResult results = validator.Validate(reservation);

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
            _context.Reservations.Add(reservation);
            await _context.SaveChangesAsync();


            return Ok("Reservation is created successfully!");

        }

        // PUT: api/Customers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReservation(int id, Reservations reservation)
        {
            if (id != reservation.reservation_id)
            {
                return BadRequest("id you provided does not match with the reservation id!");
            }

            _context.Entry(reservation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReservationExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok("Reservation updated successfully!");
        }


        // DELETE: api/Customers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReservation(int id)
        {
            var reservation = await _context.Reservations.FindAsync(id);
            if (reservation == null)
            {
                return NotFound();
            }

            _context.Reservations.Remove(reservation);
            await _context.SaveChangesAsync();

            return Ok($"Reservation with id {id} is deleted successfully!");
        }

        private bool ReservationExists(int id)
        {
            return _context.Reservations.Any(e => e.reservation_id == id);
        }

    }
}
