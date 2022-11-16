using System.Collections.Generic;
using System.Linq;

using Wytn.Sys.Model.Entity;
using Wytn.Sys.Repository.Interface;
using Wytn.Util;

namespace Wytn.Sys.Repository
{
    /// <inheritdoc/>
    public class PersonRoleRepository : GenericRepository<PersonRole>, IPersonRoleRepository
    {
        public PersonRoleRepository(IConnectionFactory connectionFactory, PrincipalAccessor principalAccessor)
            : base(connectionFactory, principalAccessor) { }

        public void deleteByUserId(string userId)
        {
            Delete(c => c.userId == userId);
        }

        public List<PersonRole> findByUserId(string userId)
        {
            return Query(c => c.userId == userId)?.ToList();
        }

        public List<string> getRoles(string userId)
        {
            return ExecuteQuery<string>("select b.role_code from SYS_PERSON_ROLE a inner join SYS_ROLE b on a.role_id=b.id where user_id=@userId",
                new
                {
                    userId = userId
                })?.ToList();
        }
    }
}
