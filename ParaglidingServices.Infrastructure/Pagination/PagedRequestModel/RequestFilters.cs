using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParaglidingServices.Infrastructure.Models.Pagination.PagedRequestModel
{
    public class RequestFilters
    {
        public RequestFilters()
        {
            Filters = new List<Filter>();
        }

        public LogicalOperators LogicalOperator { get; set; }

        public IList<Filter> Filters { get; set; }
    }
}
