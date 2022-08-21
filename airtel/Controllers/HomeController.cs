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
                    price = tempPack.cost
                };

                _context.orders.Add(t);

                _context.SaveChanges();
                string str = "success";
                //var resp = new HttpResponseMessage(HttpStatusCode.OK)
                //{
                //    Content = new StringContent(str, System.Text.Encoding.UTF8, "text/plain")
                //};

                //return resp;
                
                return Ok(Json("success"));
            }
            else
            {
                return BadRequest();
            }
        }

    }

}