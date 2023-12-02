using FluentValidation;
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
    [Route("api/orderItem")]
    public class OrderItemController : Controller
    {
        private readonly RestaurantReservationDbContext _context;
        public OrderItemController()
        {
            _context = new RestaurantReservationDbContext();
        }

        // GET: api/Customers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderItems>>> GetOrderItems()
        {
            return await _context.OrderItems.ToListAsync();
        }

        // GET: api/Customers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderItems>> GetOrderItem(int id)
        {
            var orderItem = await _context.OrderItems.FindAsync(id);

            if (orderItem == null)
            {
                return NotFound();
            }

            return orderItem;
        }

        // POST: api/Customers
        [HttpPost]
        public async Task<ActionResult<OrderItems>> PostCustomer(OrderItems orderItem)
        {
            OrderItemValidator validator = new OrderItemValidator();
            ValidationResult results = validator.Validate(orderItem);

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
            _context.OrderItems.Add(orderItem);
            await _context.SaveChangesAsync();


            return Ok("OrderItem is created successfully");

        }

        // PUT: api/Customers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrderItems(int id, OrderItems orderItem)
        {
            if (id != orderItem.order_id)
            {
                return BadRequest("id you provided does not match with the orderItem id");
            }

            _context.Entry(orderItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok("OrderItem updated successfully");
        }


        // DELETE: api/Customers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderItem(int id)
        {
            var orderItem = await _context.OrderItems.FindAsync(id);
            if (orderItem == null)
            {
                return NotFound();
            }

            _context.OrderItems.Remove(orderItem);
            await _context.SaveChangesAsync();

            return Ok($"OrderItem with id {id} is deleted successfully");
        }

        private bool OrderItemExists(int id)
        {
            return _context.OrderItems.Any(e => e.order_id == id);
        }

    }
}
