using System;
using Hotels.Core.Services;
using Hotels.Persistence.Repositories;

namespace Hotels.ConsoleApp
{
    public class Program
    {
        private static void Main(string[] args)
        {
            var dataSource = $@"{Environment.CurrentDirectory}\Data\hotels.json";
            var hotelService = new HotelService(new HotelRepository(dataSource));
            var result = hotelService.GetAllActiveAsync().Result;
        }
    }
}
