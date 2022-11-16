using System.Collections.Generic;

using Wytn.Sys.Model.Dto;
using Wytn.Sys.Model.Entity;
using Wytn.Sys.Model.Payload;

namespace Wytn.Sys.Service.Interface
{
    /// <summary>
    /// 代碼Service
    /// </summary>
    public interface ICodeService
    {
        /// <summary>
        /// 儲存代碼資料
        /// </summary>
        /// <param name="codePayload">CodePayload</param>
        /// <returns>Code</returns>
        Code save(CodePayload codePayload);
        /// <summary>
        /// 取代碼資料 code_pno = pno
        /// </summary>
        /// <param name="pno">父代碼</param>
        /// <returns>List Code</returns>
        List<Code> findByCodePno(string pno);
        /// <summary>
        /// 取代碼資料 code_pno like pno+'%'
        /// </summary>
        /// <param name="pno">父代碼</param>
        /// <returns>List CodeDto</returns>
        List<CodeDto> findLikeCodePno(string pno);
        /// <summary>
        /// 取代碼資料 code_pno in (pno1, pno2, pno3...)
        /// </summary>
        /// <param name="pno">父代碼1,父代碼2,父代碼3...</param>
        /// <returns>List CodeDto</returns>
        List<CodeDto> findInCodePno(List<string> pno);
        /// <summary>
        /// 取一筆代碼資料
        /// </summary>
        /// <param name="id">uuid</param>
        /// <returns>Code</returns>
        Code findById(string id);
        /// <summary>
        /// 刪除代碼資料
        /// </summary>
        /// <param name="id">uuid</param>
        void deleteById(string id);
    }
}
