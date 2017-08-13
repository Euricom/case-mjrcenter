using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Euricom.MjrCenter.ScheduleApi.Model;
using Euricom.MjrCenter.ScheduleApi.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Euricom.MjrCenter.ScheduleApi.BusinessComponents
{
    public class SpeakerBusinessComponent : ISpeakerBusinessComponent
    {
        private readonly ISpeakerRepository _speakerRepository;

        public SpeakerBusinessComponent(ISpeakerRepository speakerRepository)
        {
            _speakerRepository = speakerRepository;
        }

        public async Task<Speaker> Create(Speaker speaker)
        {
            await _speakerRepository.Add(speaker);
            await _speakerRepository.Commit();
            return speaker;
        }

        public async Task<bool> DeleteById(long id)
        {
            var speaker = await GetById(id);
            if (speaker == null) return false;
            await _speakerRepository.Remove(speaker);
            await _speakerRepository.Commit();
            return true;
        }

        public async Task<IList<Speaker>> GetAll()
        {
            return await _speakerRepository.All.ToListAsync();
        }

        public Task<Speaker> GetById(long id)
        {
            return _speakerRepository.All
                .Include(s => s.Extended)
                .SingleOrDefaultAsync(s => s.Id == id);
        }

        public async Task<bool> Update(Speaker speaker)
        {
            var dbSpeaker = await GetById(speaker.Id);
            if (speaker == null) return false;

            dbSpeaker.Name = speaker.Name;
            dbSpeaker.Description = speaker.Description;
            await _speakerRepository.Commit();
            return true;
        }
    }
}
