using System.Collections.Generic;
using System.Threading.Tasks;
using Hotels.Core.Contracts.Repositories;
using Hotels.Core.Contracts.Services;
using Hotels.Core.Enums;
using Hotels.Core.Models;

namespace Hotels.Core.Services
{
    public sealed class HotelService : IHotelService
    {
        /// <summary>
        /// The hotel repository.
        /// </summary>
        private readonly IHotelRepository _hotelRepository;

        /// <inheritdoc />
        public HotelService(IHotelRepository hotelRepository) => _hotelRepository = hotelRepository;

        /// <inheritdoc />
        public async Task<IEnumerable<Hotel>> GetAllAsync() => await _hotelRepository.GetAllAsync();

        /// <inheritdoc />
        public async Task<IEnumerable<Hotel>> GetListByMatchAsync(string name) => await _hotelRepository.GetListByMatchAsync(name);

        /// <inheritdoc />
        public async Task<IEnumerable<Hotel>> GetListByRatingAsync(Rating rating) => await _hotelRepository.GetListByRatingAsync(rating);
    }
}
