using System.Collections.Generic;
using System.Threading.Tasks;
using Hotels.Core.Contracts.Services;
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
        /// Gets all hotels.
        /// </summary>
        /// <returns></returns>
        [HttpGet("hotels")]
        public async Task<ActionResult<IEnumerable<Hotel>>> GetAllAsync() => Ok(await _hotelService.GetAllAsync());

        // GET: api/hotels/id
        /// <summary>
        /// Gets hotel with id.
        /// </summary>
        /// <returns></returns>
        [HttpGet("hotels/{id}")]
        public async Task<ActionResult<Hotel>> GetByIdAsync(int id) => Ok(await _hotelService.GetByIdAsync(id));

        // GET: api/hotels/name
        /// <summary>
        /// Gets list of hotels with matching name.
        /// </summary>
        /// <returns></returns>
        [HttpGet("hotels/name/{name}")]
        public async Task<ActionResult<IEnumerable<Hotel>>> GetListByMatchAsync(string name) => Ok(await _hotelService.GetListByMatchAsync(name));
    }
}
