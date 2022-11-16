using System.Collections.Generic;

using AutoMapper;

using Wytn.Sys.Model.Dto;
using Wytn.Sys.Model.Entity;
using Wytn.Sys.Model.Payload;
using Wytn.Sys.Repository.Interface;
using Wytn.Sys.Service.Interface;

namespace Wytn.Service
{
    /// <inheritdoc/>
    public class FuncService : IFuncService
    {
        /// <summary>
        /// 選單 Repository
        /// </summary>
        private readonly IFuncRepository funcRepository;

        /// <summary>
        /// Model Mapper
        /// </summary>
        private readonly IMapper mapper;

        public FuncService(
            IFuncRepository funcRepository,
            IMapper mapper)
        {
            this.funcRepository = funcRepository;
            this.mapper = mapper;
        }
        public void deleteById(string id)
        {
            funcRepository.Delete(id);
        }

        public List<Func> findAll(string[] sorts)
        {
            return funcRepository.findAll(sorts);
        }

        public Func findById(string id)
        {
            return funcRepository.Query(id);
        }

        public List<FuncDto> getByUserId(string userId)
        {
            return funcRepository.getByUserId(userId);
        }

        public Func saveFunc(FuncPayload funcPayload)
        {
            Func func = new Func();
            if (string.IsNullOrEmpty(funcPayload.id))
            {
                int maxSort = funcRepository.getMaxSortByParentId(funcPayload.parentId);
                funcPayload.sort = maxSort + 1;

                mapper.Map(funcPayload, func);
                funcRepository.Insert(func);
            }
            else
            {
                func = funcRepository.Query(funcPayload.id);
                mapper.Map(funcPayload, func);
                funcRepository.Update(func);
            }
            return func;
        }

        public List<Func> saveFuncs(List<Func> funcs)
        {
            funcRepository.UpdateAll(funcs);
            return funcs;
        }
    }
}
