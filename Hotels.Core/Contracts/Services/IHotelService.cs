using System.Collections.Generic;
using System.Threading.Tasks;
using Hotels.Core.Enums;
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
        /// Get list of <see cref="Hotel"/>s by matching case-insensitive string.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        Task<IEnumerable<Hotel>> GetListByMatchAsync(string name);

        /// <summary>
        /// Get list of <see cref="Hotel"/>s by <see cref="Rating"/>.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Hotel>> GetListByRatingAsync(Rating rating);
    }
}
