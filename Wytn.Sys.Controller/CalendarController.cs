using System.Collections.Generic;

using Wytn.Sys.Model.Entity;
using Wytn.Sys.Model.Payload;
using Wytn.Sys.Service.Interface;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Wytn.Sys.Controller
{
    /// <summary>
    /// 日曆相關API
    /// </summary>
    [Route("api/calendars")]
    [Authorize]
    [ApiController]
    public class CalendarController : ControllerBase
    {
        ICalendarService calendarService;
        public CalendarController(ICalendarService calendarService)
        {
            this.calendarService = calendarService;
        }

        /// <summary>
        /// 取日曆資料
        /// </summary>
        /// <param name="year">年度 yyyy</param>
        /// <returns>List Calendar</returns>
        [HttpGet("{year}")]
        public ActionResult<List<Calendar>> getCalendar(int year)
        {
            List<Calendar> obj = calendarService.getCalendar(year);
            return Ok(obj);
        }

        /// <summary>
        /// 儲存日曆資料
        /// </summary>
        /// <param name="calendarPayload">CalendarPayload</param>
        /// <returns>Calendar</returns>
        [HttpPost]
        public ActionResult<Calendar> save(CalendarPayload calendarPayload)
        {
            Calendar obj = calendarService.save(calendarPayload);
            return Ok(obj);
        }

        /// <summary>
        /// 刪除日曆資料
        /// </summary>
        /// <param name="id">uuid</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult delete(string id)
        {
            calendarService.deleteById(id);
            return Ok();
        }
    }
}
