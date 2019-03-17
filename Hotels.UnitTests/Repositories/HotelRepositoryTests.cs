using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotels.Core.Contracts.Repositories;
using Hotels.Core.Enums;
using Hotels.Core.Models;
using Hotels.Persistence.Repositories;
using NUnit.Framework;

namespace Hotels.UnitTests.Repositories
{
    [TestFixture]
    public class HotelRepositoryTests
    {
        private IHotelRepository _hotelRepository;

        [Test]
        public async Task GetAllAsync_GetAllHotelsAsync_ReturnsFiveHotels()
        {
            // Set up sample data.
            var data = new List<Hotel>
            {
                new Hotel{Id = 1, Name = "Test", Description = "Description1", Location = "Location1", Rating = Rating.Five},
                new Hotel{Id = 2, Name = "Testing", Description = "Description2", Location = "Location2", Rating = Rating.Three},
                new Hotel{Id = 3, Name = "Example", Description = "Description2", Location = "Location2", Rating = Rating.Two},
                new Hotel{Id = 4, Name = "Mocks", Description = "Description2", Location = "Location2", Rating = Rating.One},
                new Hotel{Id = 5, Name = "Units", Description = "Description2", Location = "Location2", Rating = Rating.One},
            };

            // Initialise and assign the dataset.
            _hotelRepository = new HotelRepository(data);

            var result = await _hotelRepository.GetAllAsync();

            // Cast to list to make assertions.
            var hotels = result.ToList();

            Assert.That(hotels, Is.TypeOf<List<Hotel>>());
            Assert.That(hotels.Count, Is.EqualTo(5));
        }

        [TestCase("Test", "X", 4)]
        [TestCase("Hotel", "X", 4)]
        [TestCase("Name", "X", 4)]
        public async Task GetListByMatchAsync_GetHotelListByMatchingNameAsync_ReturnsMatchingHotels(string name, string nonMatch, int matches)
        {
            // Set up sample data.
            var data = new List<Hotel>
            {
                new Hotel{Id = 1, Name = $"{name}", Description = "Description2", Location = "Location2", Rating = Rating.Two},
                new Hotel{Id = 2, Name = $"{name.ToUpper()}", Description = "Description1", Location = "Location1", Rating = Rating.Five},
                new Hotel{Id = 3, Name = $"{name.ToLower()}", Description = "Description2", Location = "Location2", Rating = Rating.Three},
                new Hotel{Id = 4, Name = $"{name} {nonMatch}", Description = "Description2", Location = "Location2", Rating = Rating.One},
                new Hotel{Id = 5, Name = nonMatch, Description = "Description2", Location = "Location2", Rating = Rating.One},
            };

            // Initialise and assign the dataset.
            _hotelRepository = new HotelRepository(data);

            var result = await _hotelRepository.GetListByMatchAsync(name);

            // Cast to list to make assertions.
            var hotels = result.ToList();

            Assert.That(hotels, Is.TypeOf<List<Hotel>>());
            Assert.That(hotels.Count, Is.EqualTo(matches));
        }

        [TestCase(5, 3, 4)]
        [TestCase(3, 1, 4)]
        [TestCase(1, 5, 4)]
        public async Task GetListByRatingAsync_GetHotelListByRatingAsync_ReturnsMatchingHotels(Rating match, Rating nonMatch, int matches)
        {
            // Set up sample data.
            var data = new List<Hotel>
            {
                new Hotel{Id = 1, Name = "Test", Description = "Description2", Location = "Location2", Rating = match},
                new Hotel{Id = 2, Name = "Testing", Description = "Description1", Location = "Location1", Rating = match},
                new Hotel{Id = 3, Name = "Example", Description = "Description2", Location = "Location2", Rating = match},
                new Hotel{Id = 4, Name = "Mocks", Description = "Description2", Location = "Location2", Rating = match},
                new Hotel{Id = 5, Name = "Units", Description= "Description2", Location = "Location2", Rating = nonMatch},
            };

            // Initialise and assign the dataset.
            _hotelRepository = new HotelRepository(data);

            var result = await _hotelRepository.GetListByRatingAsync(match);

            // Cast to list to make assertions.
            var hotels = result.ToList();

            Assert.That(hotels, Is.TypeOf<List<Hotel>>());
            Assert.That(hotels.Count, Is.EqualTo(matches));
        }
    }
}
