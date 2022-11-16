using System.Collections.Generic;
using System.Linq;
using System.Transactions;

using AutoMapper;

using Wytn.Sys.Model.Entity;
using Wytn.Sys.Model.Payload;
using Wytn.Sys.Repository.Interface;
using Wytn.Sys.Service.Interface;
using Wytn.Util;
using Wytn.Util.Exception;

namespace Wytn.Service
{
    /// <inheritdoc/>
    public class RoleService : IRoleService
    {
        /// <summary>
        /// 角色 Respository
        /// </summary>
        private readonly IRoleRepository roleRepository;

        /// <summary>
        /// 選單 Respository
        /// </summary>
        private readonly IFuncRepository funcRepository;

        /// <summary>
        /// 角色選單 Respository
        /// </summary>
        private readonly IRoleFuncRepository roleFuncRepository;

        /// <summary>
        /// Model Mapper
        /// </summary>
        private readonly IMapper mapper;

        /// <summary>
        /// 報表 Generator
        /// </summary>
        private readonly ReportGenerator reportGenerator;

        public RoleService(
            IRoleRepository roleRepository,
            IRoleFuncRepository roleFuncRepository,
            IFuncRepository funcRepository,
            IMapper mapper,
            ReportGenerator reportGenerator)
        {
            this.roleRepository = roleRepository;
            this.roleFuncRepository = roleFuncRepository;
            this.funcRepository = funcRepository;
            this.mapper = mapper;
            this.reportGenerator = reportGenerator;
        }

        public void deleteById(string id)
        {
            roleRepository.Delete(id);
        }

        public byte[] export()
        {
            List<Role> roles = roleRepository.QueryAll();
            Dictionary<string, object> datas = new Dictionary<string, object>();
            datas.Add("role", roles);
            return reportGenerator.generatePdf(null, datas, "sys\\role");
        }

        public List<Role> findAll()
        {
            return roleRepository.QueryAll();
        }

        public Role findById(string id)
        {
            return roleRepository.Query(id);
        }

        public List<Func> getFuncsByRoleId(string roleId)
        {
            return funcRepository.getByRoleId(roleId);
        }

        public Role save(RolePayload rolePayload)
        {
            Role role = new Role();
            if (!string.IsNullOrEmpty(rolePayload.id))
            {
                role = roleRepository.Query(rolePayload.id);
                if (role == null)
                    throw new BusinessException("無法取得角色資料");
                mapper.Map(rolePayload, role);
                roleRepository.Update(role);
            }
            else
            {
                mapper.Map(rolePayload, role);
                roleRepository.Insert(role);
            }
            return role;
        }

        public List<RoleFunc> saveRoleFuncs(List<RoleFunc> roleFuncs)
        {
            if (roleFuncs.Any())
            {
                using var scope = new TransactionScope();
                string roleId = roleFuncs[0].roleId.ToString();
                if (!string.IsNullOrEmpty(roleId))
                    roleFuncRepository.deletByRoleId(roleId);
                else
                    throw new BusinessException("尚未設定角色");
                roleFuncRepository.InsertAll(roleFuncs);
                scope.Complete();
            }
            return roleFuncs;
        }
    }
}
