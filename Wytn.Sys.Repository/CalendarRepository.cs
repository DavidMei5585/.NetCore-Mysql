using System.Collections.Generic;
using System.Linq;

using Wytn.Sys.Model.Entity;
using Wytn.Sys.Repository.Interface;
using Wytn.Util;

namespace Wytn.Sys.Repository
{
    /// <inheritdoc/>
    public class CalendarRepository : GenericRepository<Calendar>, ICalendarRepository
    {
        public CalendarRepository(IConnectionFactory connectionFactory, PrincipalAccessor principalAccessor)
            : base(connectionFactory, principalAccessor) { }

        public List<Calendar> getByYear(int year)
        {
            return ExecuteQuery("select * from CALENDAR where YEAR(DATE)=@year", new { year = year }).ToList();
        }
    }
}
