using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Euricom.MjrCenter.ScheduleApi.Model
{
    public class SpeakerExtended
    {
        public long Id { get; set; }
        public byte[] Image { get; set; }
        public string Description { get; set; }
    }
}
