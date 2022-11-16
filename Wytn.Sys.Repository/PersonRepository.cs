
using System;
using System.Collections.Generic;
using System.Linq;

using Wytn.Sys.Model.Dto;
using Wytn.Sys.Model.Entity;
using Wytn.Sys.Repository.Interface;
using Wytn.Util;

namespace Wytn.Sys.Repository
{
    /// <inheritdoc/>
    public class PersonRepository : GenericRepository<Person>, IPersonRepository
    {
        public PersonRepository(IConnectionFactory connectionFactory, PrincipalAccessor principalAccessor)
            : base(connectionFactory, principalAccessor) { }

        public Person getPerson(string userId, string password)
        {
            return ExecuteQuery("select * from SYS_PERSON where user_id=@userId and password=@password",
                new
                {
                    userId = userId,
                    password = password
                }).FirstOrDefault();
        }
        public Person getByUserId(string userId)
        {
            return Query(c => c.userId == userId).FirstOrDefault();
        }

        public void deleteByUserId(string userId)
        {
            Delete(c => c.userId == userId);
        }

        public Person getByName(string name)
        {
            return Query(c => c.name == name).FirstOrDefault();
        }

        public List<PersonDto> getQuery(string orgId, string deptId, string userId, string name, string cname, string roleId)
        {
            string sql = " select a.id, a.name, a.cname, a.user_id, a.org_id, a.dept_id, a.email, a.arrive_date, b.role_id "
                    + " from SYS_PERSON a left join SYS_PERSON_ROLE b on a.user_id=b.user_id "
                    + " where 1=1 ";

            if (!string.IsNullOrEmpty(orgId))
                sql += " and a.org_id=@orgId ";

            if (!string.IsNullOrEmpty(deptId))
                sql += " and a.dept_id=@deptId ";

            if (!string.IsNullOrEmpty(userId))
                sql += " and a.user_id like '%'+@userId+'%' ";

            if (!string.IsNullOrEmpty(name))
                sql += " and a.name like '%'+@name+'%' ";

            if (!string.IsNullOrEmpty(cname))
                sql += " and a.cname like '%'+@cname+'%' ";

            if (!string.IsNullOrEmpty(roleId))
                sql += " and b.role_id=@roleId ";

            return ExecuteQuery<PersonDto>(sql, new
            {
                orgId = orgId,
                deptId = deptId,
                userId = userId,
                name = name,
                cname = cname,
                roleId = new Guid(roleId)
            }).ToList();
        }
    }
}
