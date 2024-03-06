namespace Cities.Core.Entities
{
    public sealed class Hotel(string name, decimal daily, Guid cityId) : BaseEntity
    {
        public string Name { get; private set; } = name;
        public decimal Daily { get; private set; } = daily;
        public Guid CityId { get; private set; } = cityId;
        public City? City { get; private set; }
    }
}