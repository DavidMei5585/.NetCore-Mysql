
using Wytn.Sys.Model.Entity;
using Wytn.Sys.Repository.Interface;
using Wytn.Util;

namespace Wytn.Sys.Repository
{
    /// <inheritdoc/>
    public class RoleFuncRepository : GenericRepository<RoleFunc>, IRoleFuncRepository
    {
        public RoleFuncRepository(IConnectionFactory connectionFactory, PrincipalAccessor principalAccessor)
            : base(connectionFactory, principalAccessor) { }

        public void deletByFuncId(string funcId)
        {
            ExecuteNonQuery("delete from SYS_ROLE_FUNC where func_Id=@funcId", new { funcId = funcId });
        }

        public void deletByRoleId(string roleId)
        {
            ExecuteNonQuery("delete from SYS_ROLE_FUNC where role_Id=@roleId", new { roleId = roleId });
        }

    }
}
