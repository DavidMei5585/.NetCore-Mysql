using System.Collections.Generic;

using Wytn.Sys.Model.Entity;
using Wytn.Sys.Model.Payload;

namespace Wytn.Sys.Service.Interface
{
    /// <summary>
    /// 日曆Service
    /// </summary>
    public interface ICalendarService
    {
        /// <summary>
        /// 初始日曆檔
        /// </summary>
        /// <param name="year">年度 yyyy</param>
        void initCalendar(int year);
        /// <summary>
        /// 取日曆資料
        /// </summary>
        /// <param name="year">年度 yyyy</param>
        /// <returns>List Calendar</returns>
        List<Calendar> getCalendar(int year);
        /// <summary>
        /// 刪除日曆資料
        /// </summary>
        /// <param name="id">uuid</param>
        void deleteById(string id);
        /// <summary>
        /// 儲存日曆資料
        /// </summary>
        /// <param name="calendarPayload">CalendarPayload</param>
        /// <returns>Calendar</returns>
        Calendar save(CalendarPayload calendarPayload);
    }
}
