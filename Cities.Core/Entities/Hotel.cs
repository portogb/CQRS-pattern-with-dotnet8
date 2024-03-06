namespace Cities.Core.Entities
{
    public sealed class Hotel(Guid id, string name, decimal daily, Guid cityId) : BaseEntity
    {
        public string Name { get; init; } = name;
        public decimal Daily { get; init; } = daily;
        public Guid CityId { get; init; } = cityId;
        public City? City { get; init; }

        public Hotel(string name, decimal daily, Guid cityId) : this(Guid.Empty, name, daily, cityId) { }
    }
}