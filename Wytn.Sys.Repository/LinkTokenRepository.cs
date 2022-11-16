
using Wytn.Sys.Model.Entity;
using Wytn.Sys.Repository.Interface;
using Wytn.Util;

namespace Wytn.Sys.Repository
{
    /// <inheritdoc/>
    public class LinkTokenRepository : GenericRepository<LinkToken>, ILinkTokenRepository
    {
        public LinkTokenRepository(IConnectionFactory connectionFactory, PrincipalAccessor principalAccessor)
            : base(connectionFactory, principalAccessor) { }
    }
}
