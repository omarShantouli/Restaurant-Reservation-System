using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db;
using Resturant_Resevation_API.Responses;
using Resturant_Resevation_API.Validators;
using ResturantDataModel;
using System.ComponentModel.Design.Serialization;

namespace Resturant_Resevation_API.Controllers
{
    [ApiController]
    [Route("api/menuitem")]
    public class MenuItemController : Controller
    {
        private readonly RestaurantReservationDbContext _context;
        public MenuItemController()
        {
            _context = new RestaurantReservationDbContext();
        }

        // GET:
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MenuItems>>> GetMenuItems()
        {
            return await _context.MenuItems.ToListAsync();
        }

        // GET:
        [HttpGet("{id}")]
        public async Task<ActionResult<MenuItems>> GetMenuItem(int id)
        {
            var menuItem = await _context.MenuItems.FindAsync(id);

            if (menuItem == null)
            {
                return NotFound();
            }

            return menuItem;
        }

        // POST
        [HttpPost]
        public async Task<ActionResult<MenuItems>> PostMenuItem(MenuItems menuItem)
        {
            MenuItemValidator validator = new MenuItemValidator();
            ValidationResult results = validator.Validate(menuItem);

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
            _context.MenuItems.Add(menuItem);
            await _context.SaveChangesAsync();


            return Ok("MenuItem is created successfully!");

        }

        // PUT
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMenuItem(int id, MenuItems menuItem)
        {
            if (id != menuItem.item_id)
            {
                return BadRequest("id you provided does not match with the menuItem id!");
            }

            _context.Entry(menuItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MenuItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok("MenuItem updated successfully!");
        }

        // DELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMenuItem(int id)
        {
            var menuItem = await _context.MenuItems.FindAsync(id);
            if (menuItem == null)
            {
                return NotFound();
            }

            _context.MenuItems.Remove(menuItem);
            await _context.SaveChangesAsync();

            return Ok($"MenuItem with id {id} is deleted successfully!");
        }

        private bool MenuItemExists(int id)
        {
            return _context.MenuItems.Any(e => e.item_id == id);
        }
    }
}
