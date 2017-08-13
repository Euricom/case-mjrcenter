using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Euricom.MjrCenter.ScheduleApi.Model
{
    public class Schedule
    {
        public long Id { get; set; }
        public decimal BasePrice { get; set; }
        public string Comments { get; set; }
        public string Language { get; set; }
        public ScheduleStatus Status { get; set; }
        public string Dates { get; set; }
        public int NumberOfSeats { get; set; }
        public DateTime RegistrationDeadline { get; set; }

        public long VenueId { get; set; }
        public Venue Venue { get; set; }
        public long SpeakerId { get; set; }
        public Speaker Speaker { get; set; }
    }
}
