using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotels.Core.Contracts.Repositories;
using Hotels.Core.Contracts.Services;
using Hotels.Core.Enums;
using Hotels.Core.Models;
using Hotels.Core.Services;
using Moq;
using NUnit.Framework;

namespace Hotels.UnitTests.Services
{
    [TestFixture]
    public class HotelServiceTests
    {
        private Mock<IHotelRepository> _hotelRepository;
        private IHotelService _hotelService;

        [SetUp]
        public void Setup()
        {
            // Set up and assign mocks.
            _hotelRepository = new Mock<IHotelRepository>();
            _hotelService = new HotelService(_hotelRepository.Object);
        }

        [Test]
        public async Task GetAllAsync_GetAllHotelsAsync_ReturnsThreeHotels()
        {
            // Set up sample data.
            var data = new List<Hotel>
            {
                new Hotel{Id = 1, Name = "Name1", Description = "Description1", Location = "Location1", Rating = Rating.Five},
                new Hotel{Id = 2, Name = "Name2", Description = "Description2", Location = "Location2", Rating = Rating.Three},
                new Hotel{Id = 3, Name = "Name3", Description = "Description3", Location = "Location3", Rating = Rating.One}
            };

            // Ensure this method returns the sample data.
            _hotelRepository.Setup(x => x.GetAllActiveAsync()).ReturnsAsync(data);

            var result = await _hotelService.GetAllAsync();

            // Cast to list to make assertions.
            var hotels = result.ToList();

            Assert.That(hotels, Is.TypeOf<List<Hotel>>());
            Assert.That(hotels.Count, Is.EqualTo(3));
        }
    }
}
