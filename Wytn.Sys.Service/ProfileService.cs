
using AutoMapper;

using Wytn.Sys.Model.Dto;
using Wytn.Sys.Model.Entity;
using Wytn.Sys.Model.Payload;
using Wytn.Sys.Repository.Interface;
using Wytn.Sys.Service.Interface;
using Wytn.Util;
using Wytn.Util.Exception;

namespace Wytn.Service
{
    /// <inheritdoc/>
    public class ProfileService : IProfileService
    {
        /// <summary>
        /// 人員 Repository
        /// </summary>
        private readonly IPersonRepository personRepository;

        /// <summary>
        /// Model Mapper
        /// </summary>
        private readonly IMapper mapper;

        /// <summary>
        /// Principal Accessor (使用者物件)
        /// </summary>
        private readonly PrincipalAccessor principalAccessor;

        public ProfileService(
            IPersonRepository personRepository,
            IMapper mapper,
            PrincipalAccessor principalAccessor)
        {
            this.personRepository = personRepository;
            this.principalAccessor = principalAccessor;
            this.mapper = mapper;
        }
        public ProfileDto findOne()
        {
            Person person = personRepository.getByUserId(principalAccessor.userId);
            ProfileDto profileDto = mapper.Map<ProfileDto>(person);
            return profileDto;
        }

        public ProfileDto save(ProfilePayload profilePayload)
        {
            Person person = personRepository.getByUserId(profilePayload.userId);
            if (person == null)
                throw new BusinessException("無法取得人員資料");

            person = mapper.Map<Person>(profilePayload);
            personRepository.Update(person);

            ProfileDto profileDto = mapper.Map<ProfileDto>(person);

            return profileDto;
        }
    }
}
