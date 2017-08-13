using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Euricom.MjrCenter.ScheduleApi.Model;
using Euricom.MjrCenter.ScheduleApi.Repositories;

namespace Euricom.MjrCenter.ScheduleApi.BusinessComponents
{
    public class VenueBusinessComponent : IVenueBusinessComponent
    {
        private readonly IVenueRepository _venueRepository;

        public VenueBusinessComponent(IVenueRepository venueRepository)
        {
            _venueRepository = venueRepository;
        }

        public async Task<Venue> Create(Venue venue)
        {
            await _venueRepository.Add(venue);
            await _venueRepository.Commit();
            return venue;
        }

        public async Task<bool> DeleteById(long id)
        {
            var venue = await GetById(id);
            if(venue == null) return false;
            await _venueRepository.Remove(venue);
            await _venueRepository.Commit();
            return true;
        }

        public async Task<IList<Venue>> GetAll()
        {
            return await _venueRepository.All.ToListAsync();
        }

        public Task<Venue> GetById(long id)
        {
            return _venueRepository.All
                .Include(v=>v.Extended)
                .SingleOrDefaultAsync(v=>v.Id == id);
        }

        public async Task<bool> Update(Venue venue)
        {
            var dbVenue = await GetById(venue.Id);
            if(dbVenue == null) return false;

            dbVenue.Location = venue.Location;
            dbVenue.Name = venue.Name;
            await _venueRepository.Commit();
            return true;
        }
    }
}