namespace Euricom.MjrCenter.ScheduleApi.Model
{
    public class Venue
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public VenueExtended Extended { get; set; }
    }
}