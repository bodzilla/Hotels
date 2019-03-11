using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Hotels.Core.Contracts.Repositories;
using Hotels.Core.Models;
using Newtonsoft.Json.Linq;

namespace Hotels.Persistence.Repositories
{
    /// <inheritdoc />
    public sealed class HotelRepository : IHotelRepository
    {
        /// <summary>
        /// The hotel data.
        /// </summary>
        private IEnumerable<JToken> Hotels { get; }

        public HotelRepository(string dataSource) => Hotels = JObject.Parse(File.ReadAllText(dataSource))["hotels"].ToList();

        /// <inheritdoc />
        public async Task<IEnumerable<Hotel>> GetAllActiveAsync() => await Task.Run(() => Hotels.Select(x => x.ToObject<Hotel>()).ToList());

        /// <inheritdoc />
        public async Task<Hotel> GetByIdAsync(int id) =>
            await Task.Run(() => Hotels.Select(x => x.ToObject<Hotel>()).ToList().FirstOrDefault(x => x.Id == id));

        /// <inheritdoc />
        public async Task<IEnumerable<Hotel>> GetListByMatch(string name) =>
            await Task.Run(() => Hotels.Select(x => x.ToObject<Hotel>()).Where(x => x.Name.Contains(name)).ToList());
    }
}
