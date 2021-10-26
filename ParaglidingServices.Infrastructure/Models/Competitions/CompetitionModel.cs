using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParaglidingServices.Infrastructure.Models.Competitions
{
    public class CompetitionModel
    {
        public long Id { get; set; }
        public string CompetitionName { get; set; }
        public string CompetitionCode { get; set; }
        public string Location { get; set; }
        public DateTimeOffset PeriodFrom { get; set; }
        public DateTimeOffset PeriodTo { get; set; }

    }
}
