namespace Cities.Core.Entities
{
    public sealed class Restaurant(Guid id, string name, decimal lunch, Guid cityId) : BaseEntity
    {
        public string Name { get; init; } = name;
        public decimal Lunch { get; init; } = lunch;
        public Guid CityId { get; init; } = cityId;
        public City? City { get; init; }

        public Restaurant(string name, decimal lunch, Guid cityId) : this(Guid.Empty, name, lunch, cityId) { }
    }
}