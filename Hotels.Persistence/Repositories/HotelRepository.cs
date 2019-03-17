using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Hotels.Core.Contracts.Repositories;
using Hotels.Core.Enums;
using Hotels.Core.Models;
using Newtonsoft.Json.Linq;

namespace Hotels.Persistence.Repositories
{
    /// <inheritdoc />
    public sealed class HotelRepository : IHotelRepository
    {
        private readonly string _dataSource;

        public HotelRepository(string dataSource) => _dataSource = dataSource;

        /// <inheritdoc />
        public async Task<IEnumerable<Hotel>> GetAllAsync() =>
            await Task.Run(() => JObject.Parse(File.ReadAllText(_dataSource))["hotels"].ToList().Select(x => x.ToObject<Hotel>()));

        /// <inheritdoc />
        public async Task<IEnumerable<Hotel>> GetListByMatchAsync(string name) =>
            await GetAllAsync().ContinueWith(x => x.Result.Where(y => y.Name.Contains(name, StringComparison.CurrentCultureIgnoreCase)));

        /// <inheritdoc />
        public async Task<IEnumerable<Hotel>> GetListByRatingAsync(Rating rating) =>
            await GetAllAsync().ContinueWith(x => x.Result.Where(y => y.Rating == rating));
    }
}
