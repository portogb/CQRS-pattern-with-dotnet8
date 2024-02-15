namespace Cities.Core.Entities
{
    public class Restaurant(string name, decimal lunch, Guid cityId) : BaseEntity
    {
        public string Name { get; private set; } = name;
        public decimal Lunch { get; private set; } = lunch;
        public Guid CityId { get; private set; } = cityId;
        public City? City { get; private set; }
    }
}