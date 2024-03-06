using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cities.Core.Entities
{
    public sealed class TouristPackage(Guid id, DateTime travelDay, int totalDays, int mealsPerDay, Guid cityId, Guid hotelId, Guid restaurantId) : BaseEntity
    {
        public DateTime TravelDay { get; init; } = travelDay;
        public int TotalDays { get; init; } = totalDays;
        public int MealsPerDay { get; init; } = mealsPerDay;
        public Guid CityId { get; init; } = cityId;
        public City City { get; set; }
        public Guid HotelId { get; init; } = hotelId;
        public Hotel Hotel { get; set; }
        public Guid RestaurantId { get; init; } = restaurantId;
        public Restaurant Restaurant { get; set; }

        public TouristPackage(DateTime travelDay, int totalDays, int mealsPerDay, Guid cityId, Guid hotelId, Guid restaurantId)
            : this(Guid.Empty, travelDay, totalDays, mealsPerDay, cityId, hotelId, restaurantId) { }
    }
}
