using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParaglidingServices.Infrastructure.Models.Participants
{
    public class ParticipantCreateModel
    {
        public long PilotId { get; set; }
        public long CompetitionId { get; set; }
    }
}
