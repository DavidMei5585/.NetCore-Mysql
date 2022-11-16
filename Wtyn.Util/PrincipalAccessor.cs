using System.Linq;
using System.Security.Claims;

using Microsoft.AspNetCore.Http;

namespace Wytn.Util
{
    /// <summary>
    /// 目前使用者存取器
    /// </summary>
    public class PrincipalAccessor
    {
        /// <summary>
        /// 人員id
        /// </summary>
        public string userId => httpContextAccessor.HttpContext?.User?.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
        /// <summary>
        /// 英文姓名(AD帳號)
        /// </summary>
        public string name => httpContextAccessor.HttpContext?.User?.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;
        /// <summary>
        /// 中文姓名
        /// </summary>
        public string cname => httpContextAccessor.HttpContext?.User?.Claims.FirstOrDefault(c => c.Type == "cname")?.Value;
        /// <summary>
        /// 組織Id
        /// </summary>
        public string orgId => httpContextAccessor.HttpContext?.User?.Claims.FirstOrDefault(c => c.Type == "orgId")?.Value;
        /// <summary>
        /// 單位Id
        /// </summary>
        public string deptId => httpContextAccessor.HttpContext?.User?.Claims.FirstOrDefault(c => c.Type == "deptId")?.Value;
        /// <summary>
        /// 科室Id
        /// </summary>
        public string subdeptId => httpContextAccessor.HttpContext?.User?.Claims.FirstOrDefault(c => c.Type == "subdeptId")?.Value;
        /// <summary>
        /// 角色Id
        /// </summary>
        public string roles => httpContextAccessor.HttpContext?.User?.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;

        private readonly IHttpContextAccessor httpContextAccessor;

        public PrincipalAccessor(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }
    }
}
