using airtel.Data;
using airtel.DTO;
using airtel.Model;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace airtel.Controllers
{
    [ApiController]
    [Route("/[controller]")]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpPost("/Login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO users)
        {
            if (users.customerId == null || users.password == null)
            {
                return NotFound();
            }
            else
            {
                IEnumerable<User> userc = _context.user
                                                  .Where(x => x.customerId == users.customerId);
                if (userc == null)
                {
                    return BadRequest("User Not Found");
                }
                else if (!userc.Any(x => x.password == users.password))
                {
                    return BadRequest("Incorrect Password");
                }
                else
                {

                    return Ok(userc.Select(x => x.customerName));

                    //return Ok(_context.packs);
                }
            }

        }

        [HttpGet("/Plans")]
        public async Task<IActionResult> GetPlans()
        {
            IEnumerable<Packs> plans = _context.packs;
            if (plans != null)
            {
                return Ok(plans);
            }
            else
            {
                return BadRequest();
            }

        }
        [HttpGet("/Cart/{customerId}")]
        public async Task<IActionResult> GetOrders(long customerId)
        {
            if (customerId != null)
            {
                var orders = _context.orders
                                     .Where(x => x.customerId == customerId);

                return Ok(orders.ToArray());
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost("/Addtocart")]
        public async Task<IActionResult> Addtocart([FromBody] AddtocartDTO addtocart)
        {
            Packs tempPack = _context.packs
                                     .Where(u => u.packId == addtocart.packId)
                                     .SingleOrDefault();
            if (addtocart != null)
            {
                var t = new Orders
                {
                    customerId = addtocart.customerId,
                    packId = addtocart.packId,
                    packName = tempPack.PackName,
                    price = tempPack.cost,
                    purchased = false
            
                };

                _context.orders.Add(t);

                _context.SaveChanges();
                string str = "success";
                
                return Ok(Json("success"));
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpGet("/Getallcart")]
        public async Task<IActionResult> Getallcart([FromQuery] long customerId)
        {
            if (customerId != null)
            {
                return Ok( _context.orders.Where(x => x.customerId == customerId));
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("/Deletecartitem")]
        public async Task<IActionResult> Deletecartitem([FromQuery] int orderid)
        {
            if(orderid != null)
            {
                var items = _context.orders.Where(x => x.orderId == orderid).FirstOrDefault();
                if (items !=  null)
                {
                    var t= _context.orders.Remove(items);
                    _context.SaveChangesAsync();
                    return Ok(Json("success"));
                }
                else
                {
                    return BadRequest("Item not present in cart");
                }
                
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpGet("/Getcustname")]
        public async Task<IActionResult> Getcustname([FromQuery] long customerId)
        {
            if (customerId != null)
            {
                IEnumerable<User> userc = _context.user
                                                  .Where(x => x.customerId == customerId);
                return Ok(userc.Select(x => x.customerName));
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpGet("/PlaceOrder")]
        public async Task<IActionResult> PlaceOrder([FromQuery] long customerId)
        {
            if (customerId != null)
            {
                using (_context)
                {
                    var temp = _context.orders.Where(x => x.customerId == customerId).ToList();
                    temp.ForEach(a => a.purchased = true);
                    _context.SaveChanges();

                }
                
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }

}