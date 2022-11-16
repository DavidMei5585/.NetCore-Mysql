using System.Linq;

using Wytn.Sys.Model.Entity;
using Wytn.Sys.Repository.Interface;
using Wytn.Util;

namespace Wytn.Sys.Repository
{
    /// <inheritdoc/>
    public class HelperRepository : GenericRepository<Helper>, IHelperRepository
    {
        public HelperRepository(IConnectionFactory connectionFactory, PrincipalAccessor principalAccessor)
            : base(connectionFactory, principalAccessor) { }

        public Helper getByName(string name)
        {
            return Query(c => c.name == name).ToList().FirstOrDefault();
        }
    }
}
