using System;
using System.IO;
using System.Linq;
using Hotels.Core.Enums;
using Hotels.Core.Models;
using Hotels.Core.Services;
using Hotels.Persistence.Repositories;
using Newtonsoft.Json.Linq;

namespace Hotels.ConsoleApp
{
    public class Program
    {
        private static void Main(string[] args)
        {
            var dataSource = $@"{Environment.CurrentDirectory}\Data\hotels.json";
            var data = JObject.Parse(File.ReadAllText(dataSource))["hotels"].ToList().Select(x => x.ToObject<Hotel>());

            var hotelService = new HotelService(new HotelRepository(data));

            var allHotels = hotelService.GetAllAsync().Result;
            var hotelsWithChickenInName = hotelService.GetListByMatchAsync("chicken").Result;
            var hotelsWithRatingOne = hotelService.GetListByRatingAsync(Rating.One).Result;
        }
    }
}
