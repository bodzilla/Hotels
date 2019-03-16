﻿using System;
using Hotels.Core.Enums;
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

            var allHotels = hotelService.GetAllAsync().Result;
            var hotelsWithChickenInName = hotelService.GetListByMatchAsync("chicken").Result;
            var hotelsWithRatingOne = hotelService.GetListByRatingAsync(Rating.One).Result;
        }
    }
}
