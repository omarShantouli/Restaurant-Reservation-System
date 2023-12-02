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

        // GET
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reservations>>> GetReservations()
        {
            return await _context.Reservations.ToListAsync();
        }

        // GET
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

        // GET
        [HttpGet("customer/{customer_id}")]
        public async Task<ActionResult<IEnumerable<Reservations>>> GetReservations(int customer_id)
        {
            return await _context.Reservations.Where(r => r.customer_id == customer_id).ToListAsync();
        }

        // GET
        [HttpGet("{reservation_id}/orders")]
        public async Task<ActionResult<IEnumerable<Orders>>> GetOrders(int reservation_id)
        {
            return await _context.Orders.Where(o => o.reservation_id == reservation_id).ToListAsync();
        }

        // GET
        [HttpGet("{reservation_id}/menu-items")]
        public ActionResult<IEnumerable<MenuItems>> GetMenuItems(int reservation_id)
        {
            var orders = _context.Orders.Where(o => o.reservation_id == reservation_id).ToList();
            var orderItems = orders.Join(_context.OrderItems, orderItem => orderItem.order_id,
                            order => order.order_id, (orderItems, order) => new
                            {
                                order.item_id,
                            });
            return  orderItems.Join(_context.MenuItems, menuItem => menuItem.item_id,
                    orderItem => orderItem.item_id, (menuItem, orderItem) => new MenuItems
                    {
                        item_id = menuItem.item_id,
                        resturant_id = orderItem.resturant_id,
                        name = orderItem.name,
                        description = orderItem.description,
                        price = orderItem.price
                    }).ToList();
        }


        // POST
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

        // PUT
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


        // DELETE
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
