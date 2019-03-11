using System.Collections.Generic;
using System.Threading.Tasks;
using Hotels.Core.Contracts.Repositories;
using Hotels.Core.Contracts.Services;
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
        public async Task<IEnumerable<Hotel>> GetAllActiveAsync() => await _hotelRepository.GetAllActiveAsync();

        /// <inheritdoc />
        public async Task<Hotel> GetByIdAsync(int id) => await _hotelRepository.GetByIdAsync(id);

        /// <inheritdoc />
        public async Task<IEnumerable<Hotel>> GetListByMatch(string name) => await _hotelRepository.GetListByMatch(name);
    }
}
