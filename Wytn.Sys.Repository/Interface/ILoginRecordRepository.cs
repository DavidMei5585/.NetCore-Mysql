using System.Collections.Generic;

using Wytn.Sys.Model.Dto;
using Wytn.Sys.Model.Entity;

namespace Wytn.Sys.Repository.Interface
{
    /// <summary>
    /// 登入紀錄Repository
    /// </summary>
    public interface ILoginRecordRepository : IGenericRepository<LoginRecord>
    {
        /// <summary>
        /// 取有效的登入紀錄
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        LoginRecord getActiveByUserId(string userId);
        /// <summary>
        /// 取有效的登入紀錄
        /// </summary>
        /// <returns></returns>
        List<LoginRecordDto> getActiveRecord();
        /// <summary>
        /// 更新登入紀錄
        /// </summary>
        /// <param name="userId">人員Id</param>
        /// <param name="oldFlag">舊註記</param>
        /// <param name="flag">新註記</param>
        /// <returns></returns>
        int updateFlag(string userId, int oldFlag, int flag);
    }
}
