using System.Collections.Generic;
using System.Threading.Tasks;
using Hotels.Core.Contracts.Services;
using Hotels.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hotels.Website.Controllers
{
    [Route("api/hotels")]
    public class HotelController : Controller
    {
        private readonly IHotelService _hotelService;

        public HotelController(IHotelService hotelService) => _hotelService = hotelService;

        // GET: api/hotels
        /// <summary>
        /// Gets all hotels.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<Hotel>> GetAllAsync() => await _hotelService.GetAllAsync();
    }
}
