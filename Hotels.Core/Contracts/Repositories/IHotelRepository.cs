using System.Collections.Generic;
using System.Threading.Tasks;
using Hotels.Core.Models;

namespace Hotels.Core.Contracts.Repositories
{
    /// <summary>
    /// The hotel repository interface.
    /// </summary>
    public interface IHotelRepository
    {
        /// <summary>
        /// Get all active <see cref="Hotel"/>s.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Hotel>> GetAllAsync();

        /// <summary>
        /// Get <see cref="Hotel"/> by id.
        /// </summary>
        /// <returns></returns>
        Task<Hotel> GetByIdAsync(int id);

        /// <summary>
        /// Get list of <see cref="Hotel"/>s by matching case-insensitive string.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        Task<IEnumerable<Hotel>> GetListByMatch(string name);
    }
}
