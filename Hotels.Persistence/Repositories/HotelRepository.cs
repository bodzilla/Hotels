using System.Collections.Generic;
using System.Threading.Tasks;
using Hotels.Core.Contracts.Repositories;
using Hotels.Core.Models;

namespace Hotels.Persistence.Repositories
{
    /// <inheritdoc />
    public sealed class HotelRepository : IHotelRepository
    {
        public async Task<Hotel> GetByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<Hotel>> GetListByMatch(string name)
        {
            throw new System.NotImplementedException();
        }
    }
}
