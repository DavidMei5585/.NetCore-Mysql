using System.Collections.Generic;

using Wytn.Sys.Model.Entity;

namespace Wytn.Sys.Repository.Interface
{
    /// <summary>
    /// 日曆Repository
    /// </summary>
    public interface ICalendarRepository : IGenericRepository<Calendar>
    {
        /// <summary>
        /// 取日曆資料
        /// </summary>
        /// <param name="year">年度 yyyy</param>
        /// <returns>List Calendar</returns>
        List<Calendar> getByYear(int year);
    }
}
