

using Euricom.MjrCenter.ScheduleApi.Model.Mappings;

namespace Euricom.MjrCenter.ScheduleApi.Model
{
    public class Speaker
    {
        public long Id { get; set; }
        public SpeakerExtended Extended { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
