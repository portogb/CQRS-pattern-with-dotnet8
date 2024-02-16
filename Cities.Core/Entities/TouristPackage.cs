using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cities.Core.Entities
{
    public class TouristPackage(DateTime travelDay, int totalDays, int mealsPerDay, Guid cityId, Guid hotelId, Guid restaurantId) : BaseEntity
    {
        public DateTime TravelDay { get; private set; } = travelDay;
        public int TotalDays { get; private set; } = totalDays;
        public int MealsPerDay { get; private set; } = mealsPerDay;
        public Guid CityId { get; private set; } = cityId;
        public City City { get; set; }
        public Guid HotelId { get; private set; } = hotelId;
        public Hotel Hotel { get; set; }
        public Guid RestaurantId { get; private set; } = restaurantId;
        public Restaurant Restaurant { get; set; }
    }
}
