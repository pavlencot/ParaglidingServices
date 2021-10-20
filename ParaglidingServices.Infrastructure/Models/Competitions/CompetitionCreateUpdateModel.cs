using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParaglidingServices.Infrastructure.Models.Competitions
{
    public class CompetitionCreateUpdateModel
    {
        public string CompetitionName { get; set; }
        public string CompetitionCode { get; set; }
        public long LocationId { get; set; }
        public DateTimeOffset PeriodFrom { get; set; }
        public DateTimeOffset PeriodTo { get; set; }
    }
}
