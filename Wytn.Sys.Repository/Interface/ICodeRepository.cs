using System.Collections.Generic;

using Wytn.Sys.Model.Dto;
using Wytn.Sys.Model.Entity;

namespace Wytn.Sys.Repository.Interface
{
    /// <summary>
    /// 代碼Repository
    /// </summary>
    public interface ICodeRepository : IGenericRepository<Code>
    {
        /// <summary>
        /// 取代碼資料
        /// </summary>
        /// <param name="codePno">父代碼</param>
        /// <returns>List CodeDto</returns>
        List<CodeDto> findLikeCodePno(string codePno);
        /// <summary>
        /// 取代碼資料
        /// </summary>
        /// <param name="codePno">父代碼1,父代碼2,父代碼3</param>
        /// <returns>List CodeDto</returns>
        List<CodeDto> findInCodePno(List<string> codePno);
        /// <summary>
        /// 取代碼資料
        /// </summary>
        /// <param name="codePno">父代碼</param>
        /// <returns>List Code</returns>
        List<Code> findByCodePno(string codePno);
        /// <summary>
        /// 取代碼資料
        /// </summary>
        /// <param name="codePno">父代碼</param>
        /// <param name="codeNo">子代碼</param>
        /// <returns>Code</returns>
        Code getCode(string codePno, string codeNo);
        /// <summary>
        /// 取最大代碼NO
        /// </summary>
        /// <param name="codePno">父代碼</param>
        /// <returns>代碼</returns>
        string getMaxCodeNo(string codePno);
        /// <summary>
        /// 依父代碼刪除所有以下的代碼資料
        /// </summary>
        /// <param name="codePno">父代碼</param>
        void deleteByPno(string codePno);
    }
}
