using System;
using System.Collections.Generic;
using System.Linq;

namespace Euricom.MjrCenter.ScheduleApi.Model
{
    internal class MjrContextInitializer
    {
        private MjrContext mjrContext;

        public MjrContextInitializer(MjrContext mjrContext)
        {
            this.mjrContext = mjrContext;
        }

        internal void Initialize()
        {
            InitializeVenue();
            InitializeSpeaker();
            InitializeSchedule();

            mjrContext.SaveChanges();
        }

        private void InitializeVenue()
        {
            mjrContext.Venues.Add(new Venue { Name = "Test Venue 1" });
            mjrContext.Venues.Add(new Venue
            {
                Name = "Test Venue 2",
                Extended = new VenueExtended { Description = "Description of venue 2" }
            });
            mjrContext.SaveChanges();
        }

        private void InitializeSpeaker()
        {
            mjrContext.Speakers.Add(new Speaker { Name = "Ted", Description = "classic schmosby" });
            mjrContext.Speakers.Add(new Speaker
            {
                Name = "Fred Flinstone",
                Description = "WILMAAAAAAAAAAA",
                Extended = new SpeakerExtended { Description = "Extended descr" }
            });
            mjrContext.SaveChanges();
        }

        private void InitializeSchedule()
        {
            mjrContext.Schedules.Add(new Schedule()
            {
                BasePrice = 350,
                Comments = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam tellus turpis, volutpat vel elementum quis, laoreet et sem. Etiam sollicitudin pharetra tortor a rutrum. Donec ac libero at libero dapibus ullamcorper rutrum at est. Vivamus faucibus ipsum id lectus vehicula, in efficitur arcu semper. Nullam vestibulum erat commodo, lobortis lectus.",
                Dates = "20/3/2017, 21/03/2017, 22/03/2017, 23/03/2017, 24/03/2017",
                Language = "NL",
                NumberOfSeats = 20,
                RegistrationDeadline = new DateTime(2017, 3, 15),
                Speaker = mjrContext.Speakers.First(x => x.Name == "Ted"),
                Status = ScheduleStatus.Published,
                Venue = mjrContext.Venues.First()
            });
            mjrContext.SaveChanges();
        }
    }
}
