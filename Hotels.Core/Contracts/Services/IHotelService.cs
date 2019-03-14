using System.Collections.Generic;
using System.Threading.Tasks;
using Hotels.Core.Models;

namespace Hotels.Core.Contracts.Services
{
    /// <summary>
    /// The hotel service interface.
    /// </summary>
    public interface IHotelService
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
        Task<IEnumerable<Hotel>> GetListByMatchAsync(string name);
    }
}
