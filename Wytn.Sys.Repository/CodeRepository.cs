using System.Collections.Generic;
using System.Linq;

using Wytn.Sys.Model.Dto;
using Wytn.Sys.Model.Entity;
using Wytn.Sys.Repository.Interface;
using Wytn.Util;

namespace Wytn.Sys.Repository
{
    /// <inheritdoc/>
    public class CodeRepository : GenericRepository<Code>, ICodeRepository
    {
        public CodeRepository(IConnectionFactory connectionFactory, PrincipalAccessor principalAccessor)
            : base(connectionFactory, principalAccessor) { }

        public void deleteByPno(string codePno)
        {
            ExecuteNonQuery("delete from SYS_CODE where code_Pno like @codePno+'%'", new { codePno = codePno });
        }

        public List<Code> findByCodePno(string codePno)
        {
            string pno = string.IsNullOrEmpty(codePno) ? "" : codePno;
            return Query(c => c.codePno == pno)?.ToList();
        }

        public List<CodeDto> findInCodePno(List<string> codePno)
        {
            string sql = @"select a.code_Pno, a.code_No, a.code_Name, a.code_Desc, a.code_Note, a.sort 
                            from SYS_CODE a where a.code_Pno in (@codePno)";
            return ExecuteQuery<CodeDto>(sql, new { codePno = codePno })?.ToList();
        }

        public List<CodeDto> findLikeCodePno(string codePno)
        {
            string sql = @"select a.code_Pno, a.code_No, a.code_Name, a.code_Desc, a.code_Note, a.sort 
                            from SYS_CODE a where a.code_Pno in (@codePno)";
            return ExecuteQuery<CodeDto>(sql, new { codePno = codePno })?.ToList();
        }

        public Code getCode(string codePno, string codeNo)
        {
            return Query(c => c.codePno == codePno && c.codeNo == codeNo).FirstOrDefault();
        }

        public string getMaxCodeNo(string codePno)
        {
            return ExecuteScalar<string>("select Max(codeNo) from SYS_CODE where codePno=@codePno", new
            {
                codePno = codePno
            });
        }
    }
}
