using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace CreditCalculator.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WishlistController : ControllerBase
    {
        // In-memory storage for demo purposes
        private static readonly List<string> AvailableWishes = new()
        {
            "Learn ML",
            "Learn Data Analytics",
            "Learn Ruby",
            "Become an ML Expert"
        };
        private static readonly List<string> Wishlist = new();

        [HttpGet("available")]
        public IActionResult GetAvailableWishes() => Ok(AvailableWishes);

        [HttpGet]
        public IActionResult GetWishlist() => Ok(Wishlist);

        [HttpPost("add")]
        public IActionResult AddWish([FromBody] string wish)
        {
            if (string.IsNullOrWhiteSpace(wish))
                return BadRequest("No Items Added !");
            if (!Wishlist.Contains(wish))
            {
                Wishlist.Add(wish);
                return Ok(new { count = Wishlist.Count, wishlist = Wishlist });
            }
            return Ok(new { count = Wishlist.Count, wishlist = Wishlist });
        }

        [HttpDelete("delete/{wish}")]
        public IActionResult DeleteWish(string wish)
        {
            if (!Wishlist.Contains(wish))
                return BadRequest("Select Item to be deleted...");
            Wishlist.Remove(wish);
            return Ok(new { count = Wishlist.Count, wishlist = Wishlist });
        }

        [HttpPost("clear")]
        public IActionResult ClearWishlist()
        {
            Wishlist.Clear();
            return Ok(Wishlist);
        }

        [HttpPost("sort")]
        public IActionResult SortWishlist()
        {
            Wishlist.Sort();
            return Ok(Wishlist);
        }

        [HttpPost("addall")]
        public IActionResult AddAllWishes()
        {
            foreach (var wish in AvailableWishes)
            {
                if (!Wishlist.Contains(wish))
                    Wishlist.Add(wish);
            }
            return Ok(new { count = Wishlist.Count, wishlist = Wishlist });
        }
    }
}
