namespace EventApi.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public DateOnly Date { get; set; }
        public int Capacity { get; set; }
        public int AgeRange { get; set; }
        public string time { get; set; }
        public string Location { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public int CreatorId { get; set; }
        public string CreatorName { get; set; }
        public DateTime CreatedAt { get; set; }
       
    }
}
