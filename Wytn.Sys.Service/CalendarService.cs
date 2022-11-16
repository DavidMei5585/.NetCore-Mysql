using System;
using System.Collections.Generic;

using AutoMapper;

using Wytn.Sys.Model.Entity;
using Wytn.Sys.Model.Payload;
using Wytn.Sys.Repository.Interface;
using Wytn.Sys.Service.Interface;

namespace Wytn.Sys.Service
{
    /// <inheritdoc/>
    public class CalendarService : ICalendarService
    {
        /// <summary>
        /// 日曆 Repository
        /// </summary>
        private readonly ICalendarRepository calendarRepository;

        /// <summary>
        /// Model Mapper
        /// </summary>
        private readonly IMapper mapper;

        public CalendarService(ICalendarRepository calendarRepository,
            IMapper mapper)
        {
            this.calendarRepository = calendarRepository;
            this.mapper = mapper;
        }

        public void deleteById(string id)
        {
            calendarRepository.Delete(id);
        }

        public List<Calendar> getCalendar(int year)
        {
            return calendarRepository.getByYear(year);
        }

        public void initCalendar(int year)
        {
            throw new NotImplementedException();
        }

        public Calendar save(CalendarPayload calendarPayload)
        {
            Calendar calendar = new Calendar();
            if (!string.IsNullOrEmpty(calendarPayload.id))
                calendar = calendarRepository.Query(calendarPayload.id);
            mapper.Map(calendarPayload, calendar);
            calendarRepository.Update(calendar);
            return calendar;
        }
    }
}
