using System.Collections.Generic;
using System.Linq;

using Wytn.Sys.Model.Dto;
using Wytn.Sys.Model.Entity;
using Wytn.Sys.Repository.Interface;
using Wytn.Util;

namespace Wytn.Sys.Repository
{
    /// <inheritdoc/>
    public class LoginRecordRepository : GenericRepository<LoginRecord>, ILoginRecordRepository
    {
        public LoginRecordRepository(IConnectionFactory connectionFactory, PrincipalAccessor principalAccessor)
            : base(connectionFactory, principalAccessor) { }

        public LoginRecord getActiveByUserId(string userId)
        {
            return ExecuteQuery<LoginRecord>("select * from login_record where flag=1 and user_id=@userId", new
            {
                userId = userId
            }).ToList()?.FirstOrDefault();
        }

        List<LoginRecordDto> ILoginRecordRepository.getActiveRecord()
        {
            return ExecuteQuery<LoginRecordDto>("select a.id, a.user_Id, b.cname, a.cre_Date from Login_Record a "
                + "	inner join Person b on a.user_Id=b.user_Id "
                + " where a.flag=1 and now()<=dateadd(hh, 1, a.cre_Date) ").ToList();
        }

        public int updateFlag(string userId, int oldFlag, int flag)
        {
            return ExecuteNonQuery("update SYS_Login_Record set flag=@flag, upd_User=@userId, upd_Date=now() where flag=@oldFlag and user_Id=@userId", new
            {
                userId = userId,
                oldFlag = oldFlag,
                flag = flag
            });
        }
    }
}
