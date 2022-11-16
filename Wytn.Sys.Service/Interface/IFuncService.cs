using System.Collections.Generic;

using Wytn.Sys.Model.Dto;
using Wytn.Sys.Model.Entity;
using Wytn.Sys.Model.Payload;

namespace Wytn.Sys.Service.Interface
{
    /// <summary>
    /// 選單Service
    /// </summary>
    public interface IFuncService
    {
        /// <summary>
        /// 取代碼資料
        /// </summary>
        /// <param name="sorts">排序</param>
        /// <returns>List Func</returns>
        List<Func> findAll(string[] sorts);
        /// <summary>
        /// 刪除代碼資料
        /// </summary>
        /// <param name="id">uuid</param>
        void deleteById(string id);
        /// <summary>
        /// 儲存代碼資料
        /// </summary>
        /// <param name="funcPayload">FuncPayload</param>
        /// <returns></returns>
        Func saveFunc(FuncPayload funcPayload);
        /// <summary>
        /// 儲存代碼資料
        /// </summary>
        /// <param name="funcs">List Func</param>
        /// <returns></returns>
        List<Func> saveFuncs(List<Func> funcs);
        /// <summary>
        /// 取代碼資料
        /// </summary>
        /// <param name="id">uuid</param>
        /// <returns></returns>
        Func findById(string id);
        /// <summary>
        /// 取選單資料
        /// </summary>
        /// <param name="userId">人員Id</param>
        /// <returns>List FuncDto</returns>
        List<FuncDto> getByUserId(string userId);
    }
}
