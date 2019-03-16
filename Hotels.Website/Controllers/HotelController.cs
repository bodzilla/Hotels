using System.Collections.Generic;
using System.Threading.Tasks;
using Hotels.Core.Contracts.Services;
using Hotels.Core.Enums;
using Hotels.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hotels.Website.Controllers
{
    [Route("api")]
    public class HotelController : Controller
    {
        private readonly IHotelService _hotelService;

        public HotelController(IHotelService hotelService) => _hotelService = hotelService;

        // GET: api/hotels
        /// <summary>
        /// Gets all <see cref="Hotels"/>s.
        /// </summary>
        /// <returns></returns>
        [HttpGet("hotels")]
        public async Task<ActionResult<IEnumerable<Hotel>>> GetAllAsync() => Ok(await _hotelService.GetAllAsync());

        // GET: api/hotels/name
        /// <summary>
        /// Gets list of <see cref="Hotel"/>s with matching name.
        /// </summary>
        /// <returns></returns>
        [HttpGet("hotels/name/{name}")]
        public async Task<ActionResult<IEnumerable<Hotel>>> GetListByMatchAsync(string name) => Ok(await _hotelService.GetListByMatchAsync(name));

        // GET: api/hotels/rating
        /// <summary>
        /// Get list of <see cref="Hotel"/>s by <see cref="Rating"/>.
        /// </summary>
        /// <returns></returns>
        [HttpGet("hotels/rating/{rating}")]
        public async Task<ActionResult<Hotel>> GetListByIdAsync(int rating) => Ok(await _hotelService.GetListByRatingAsync((Rating)rating));
    }
}
