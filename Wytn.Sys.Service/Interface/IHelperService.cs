using System.Collections.Generic;

using Wytn.Sys.Model.Entity;

using Microsoft.AspNetCore.Http;

namespace Wytn.Sys.Service.Interface
{
    /// <summary>
    /// 使用教學Service
    /// </summary>
    public interface IHelperService
    {
        /// <summary>
        /// 依名稱(網址)取使用教學
        /// </summary>
        /// <param name="name">名稱(網址)</param>
        /// <returns>byte[]</returns>
        byte[] getPdfByName(string name);
        /// <summary>
        /// 依uuid取使用教學
        /// </summary>
        /// <param name="id">uuid</param>
        /// <returns>byte[]</returns>
        byte[] getPdfById(string id);
        /// <summary>
        /// 取使用教學
        /// </summary>
        /// <returns>List Helper</returns>
        List<Helper> findAll();
        /// <summary>
        /// 刪除使用教學
        /// </summary>
        /// <param name="id">uuid</param>
        void delete(string id);
        /// <summary>
        /// 儲存使用教學
        /// </summary>
        /// <param name="id">uuid</param>
        /// <param name="url">名稱(網址)</param>
        /// <param name="file">檔案</param>
        /// <returns>Helper</returns>
        Helper save(string id, string url, IFormFile file);
    }
}
