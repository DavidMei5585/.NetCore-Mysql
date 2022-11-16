using System;
using System.Collections.Generic;
using System.Transactions;

using AutoMapper;

using Wytn.Sys.Model.Dto;
using Wytn.Sys.Model.Entity;
using Wytn.Sys.Model.Payload;
using Wytn.Sys.Repository.Interface;
using Wytn.Sys.Service.Interface;
using Wytn.Util.Exception;

namespace Wytn.Sys.Service
{
    /// <inheritdoc/>
    public class PersonService : IPersonService
    {
        /// <summary>
        /// 人員 Repository
        /// </summary>
        private readonly IPersonRepository personRepository;

        /// <summary>
        /// 人員角色 Repository
        /// </summary>
        private readonly IPersonRoleRepository personRoleRepository;

        /// <summary>
        /// Model Mapper
        /// </summary>
        private readonly IMapper mapper;

        public PersonService(IPersonRepository personRepository,
            IPersonRoleRepository personRoleRepository,
            IMapper mapper)
        {
            this.personRepository = personRepository;
            this.personRoleRepository = personRoleRepository;
            this.mapper = mapper;
        }

        public void deleteByUserId(string userId)
        {
            personRepository.deleteByUserId(userId);
        }

        public Person getByUserId(string userId)
        {
            return personRepository.getByUserId(userId);
        }

        public List<PersonDto> getQuery(string orgId, string deptId, string userId, string name, string cname, string roleId)
        {
            return personRepository.getQuery(orgId, deptId, userId, name, cname, roleId);
        }

        public List<PersonRole> getRole(string userId)
        {
            return personRoleRepository.findByUserId(userId);
        }

        public Person save(PersonPayload personPayload)
        {
            if (string.IsNullOrEmpty(personPayload.userId))
                throw new BusinessException("尚未設定人員帳號");

            using var scope = new TransactionScope();
            Person person = new Person();
            if (string.IsNullOrEmpty(personPayload.id))
            {
                Person p = personRepository.getByUserId(personPayload.userId);
                if (p != null)
                    throw new BusinessException("員工編號重覆");

                person.password = SHA512("@aK>3TE?vz");
                mapper.Map(personPayload, person);
                personRepository.Insert(person);
            }
            else
            {
                person = personRepository.getByUserId(personPayload.userId);
                if (person == null)
                    throw new BusinessException("無法取得人員資料");
                mapper.Map(personPayload, person);
                personRepository.Update(person);
            }

            // save role
            personRoleRepository.deleteByUserId(personPayload.userId);
            List<PersonRole> roleList = new List<PersonRole>();
            string[] roleIds = personPayload.roleIds;
            if (roleIds != null && roleIds.Length > 0)
            {
                for (int i = 0; i < roleIds.Length; i++)
                {
                    PersonRole personRole = new PersonRole();
                    personRole.orgId = person.orgId;
                    personRole.userId = person.userId;
                    personRole.roleId = Guid.Parse(roleIds[i]);
                    roleList.Add(personRole);
                }
            }
            personRoleRepository.InsertAll(roleList);
            scope.Complete();
            return person;
        }

        private string SHA512(string input)
        {
            var bytes = System.Text.Encoding.UTF8.GetBytes(input);
            using (var hash = System.Security.Cryptography.SHA512.Create())
            {
                var hashedInputBytes = hash.ComputeHash(bytes);

                // Convert to text
                // StringBuilder Capacity is 128, because 512 bits / 8 bits in byte * 2 symbols for byte 
                var hashedInputStringBuilder = new System.Text.StringBuilder(128);
                foreach (var b in hashedInputBytes)
                    hashedInputStringBuilder.Append(b.ToString("X2"));
                return hashedInputStringBuilder.ToString();
            }
        }

        public List<PersonRole> saveRoles(PersonRolePayload personRolePayload)
        {
            using var scope = new TransactionScope();
            personRoleRepository.deleteByUserId(personRolePayload.userId);
            List<PersonRole> personRoles = new List<PersonRole>();
            foreach (string roleId in personRolePayload.roleIds)
            {
                PersonRole personRole = new PersonRole();
                personRole.userId = personRolePayload.userId;
                personRole.roleId = Guid.Parse(roleId);
                personRoles.Add(personRole);
            }
            personRoleRepository.InsertAll(personRoles);
            scope.Complete();
            return personRoles;
        }
    }
}
