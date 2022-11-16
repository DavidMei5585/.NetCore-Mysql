
using Wytn.Sys.Model.Entity;

namespace Wytn.Sys.Repository.Interface
{
    /// <summary>
    /// 使用教學Repository
    /// </summary>
    public interface IHelperRepository : IGenericRepository<Helper>
    {
        /// <summary>
        /// 依名稱(url)取使用教學
        /// </summary>
        /// <param name="name"></param>
        /// <returns>Helper</returns>
        Helper getByName(string name);
    }
}
