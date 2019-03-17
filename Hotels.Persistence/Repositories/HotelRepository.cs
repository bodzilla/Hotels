using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotels.Core.Contracts.Repositories;
using Hotels.Core.Enums;
using Hotels.Core.Models;

namespace Hotels.Persistence.Repositories
{
    /// <inheritdoc />
    public sealed class HotelRepository : IHotelRepository
    {
        private readonly IEnumerable<Hotel> _hotels;

        public HotelRepository(IEnumerable<Hotel> hotels) => _hotels = hotels;

        /// <inheritdoc />
        public async Task<IEnumerable<Hotel>> GetAllAsync() => await Task.Run(() => _hotels);

        /// <inheritdoc />
        public async Task<IEnumerable<Hotel>> GetListByMatchAsync(string name) =>
            await Task.Run(() => _hotels.Where(y => y.Name.Contains(name, StringComparison.CurrentCultureIgnoreCase)));

        /// <inheritdoc />
        public async Task<IEnumerable<Hotel>> GetListByRatingAsync(Rating rating) =>
            await Task.Run(() => _hotels.Where(y => y.Rating == rating));
    }
}
