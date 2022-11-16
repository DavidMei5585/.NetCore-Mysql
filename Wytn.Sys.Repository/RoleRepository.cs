using Wytn.Sys.Model.Entity;
using Wytn.Sys.Repository.Interface;
using Wytn.Util;

namespace Wytn.Sys.Repository
{
    /// <inheritdoc/>
    public class RoleRepository : GenericRepository<Role>, IRoleRepository
    {
        public RoleRepository(IConnectionFactory connectionFactory, PrincipalAccessor principalAccessor)
            : base(connectionFactory, principalAccessor) { }

    }
}
