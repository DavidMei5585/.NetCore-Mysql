using System.Collections.Generic;
using System.Linq;

using Wytn.Sys.Model.Dto;
using Wytn.Sys.Model.Entity;
using Wytn.Sys.Repository.Interface;
using Wytn.Util;

using RepoDb;

namespace Wytn.Sys.Repository
{
    /// <inheritdoc/>
    public class FuncRepository : GenericRepository<Func>, IFuncRepository
    {
        public FuncRepository(IConnectionFactory connectionFactory, PrincipalAccessor principalAccessor)
            : base(connectionFactory, principalAccessor) { }

        public List<FuncDto> getByUserId(string userId)
        {
            string sql = @"select distinct a.id, a.func_Cname, a.func_Ename, a.func_Url, a.parent_Id, a.sort
                from SYS_FUNC a 
                inner join SYS_ROLE_FUNC b on a.id=b.func_Id 
                inner join SYS_PERSON_ROLE c on b.role_Id=c.role_Id 
                left join SYS_FUNC d on a.id=d.Id 
                where c.user_Id=@userId order by a.sort ";

            return ExecuteQuery<FuncDto>(sql, new
            {
                userId = userId
            }).ToList();
        }

        public int getMaxSortByParentId(string parentId)
        {
            return ExecuteScalar<int>("select Max(sort) from SYS_FUNC a where parent_Id=@parentId", new
            {
                parentId = parentId
            });
        }

        public List<Func> findAll(string[] sorts)
        {
            List<OrderField> orders = new List<OrderField>();
            foreach (string sort in sorts)
            {
                orders.Add(new OrderField(sort, RepoDb.Enumerations.Order.Ascending));
            }
            return QueryAll(orderBy: orders).ToList();
        }

        public List<Func> getByRoleId(string roleId)
        {
            string sql = "select a.* from SYS_FUNC a "
                + " inner join SYS_ROLE_FUNC b on a.id=b.func_Id where b.role_Id=@roleId order by a.sort";
            return ExecuteQuery(sql, new { roleId = roleId }).ToList();
        }
    }
}
