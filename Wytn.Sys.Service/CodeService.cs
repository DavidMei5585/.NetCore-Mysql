using System.Collections.Generic;

using AutoMapper;

using Wytn.Sys.Model.Dto;
using Wytn.Sys.Model.Entity;
using Wytn.Sys.Model.Payload;
using Wytn.Sys.Repository.Interface;
using Wytn.Sys.Service.Interface;
using Wytn.Util.Exception;

namespace Wytn.Service
{
    /// <inheritdoc/>
    public class CodeService : ICodeService
    {
        /// <summary>
        /// 代碼 Repository
        /// </summary>
        private readonly ICodeRepository codeRepository;

        /// <summary>
        /// Model Mapper
        /// </summary>
        private readonly IMapper mapper;

        public CodeService(
            ICodeRepository codeRepository,
            IMapper mapper)
        {
            this.codeRepository = codeRepository;
            this.mapper = mapper;
        }

        public void deleteById(string id)
        {
            Code code = codeRepository.Query(id);
            if (code != null)
            {
                string pno = code.codePno + code.codeNo;
                codeRepository.deleteByPno(pno);
                codeRepository.Delete(id);
            }
        }

        public List<Code> findByCodePno(string pno)
        {
            return codeRepository.findByCodePno(pno);
        }

        public Code findById(string id)
        {
            return codeRepository.Query(id);
        }

        public List<CodeDto> findInCodePno(List<string> pno)
        {
            return codeRepository.findInCodePno(pno);
        }

        public List<CodeDto> findLikeCodePno(string pno)
        {
            return codeRepository.findLikeCodePno(pno);
        }

        public Code save(CodePayload codePayload)
        {
            if (codePayload == null)
                throw new BusinessException("尚未設定代碼資料");

            Code code = new Code();
            if (!string.IsNullOrEmpty(codePayload.id))
            {
                code = codeRepository.Query(codePayload.id);
                if (code == null)
                    throw new BusinessException("無法取得代碼資料");

                mapper.Map(codePayload, code);
                codeRepository.Update(code);
            }
            else
            {
                Code code2 = codeRepository.getCode(codePayload.codePno, codePayload.codeNo);
                if (code2 != null)
                    throw new BusinessException("已有相同的代碼編號");

                mapper.Map(codePayload, code);
                codeRepository.Insert(code);
            }
            return code;
        }
    }
}
