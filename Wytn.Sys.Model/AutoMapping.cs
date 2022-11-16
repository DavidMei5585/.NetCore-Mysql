
using AutoMapper;

using Wytn.Sys.Model.Dto;
using Wytn.Sys.Model.Entity;
using Wytn.Sys.Model.Payload;

namespace Wytn.Sys.Model
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Person, ProfileDto>();
            CreateMap<FuncPayload, Func>()
                .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<RolePayload, Role>()
                .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<CodePayload, Code>()
                .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<PersonPayload, Person>()
                .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<CalendarPayload, Calendar>()
                .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
