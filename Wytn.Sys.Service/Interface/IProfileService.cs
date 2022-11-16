
using Wytn.Sys.Model.Dto;
using Wytn.Sys.Model.Payload;

namespace Wytn.Sys.Service.Interface
{
    /// <summary>
    /// 個人資料Service
    /// </summary>
    public interface IProfileService
    {
        /// <summary>
        /// 取個人資料
        /// </summary>
        /// <returns>ProfileDto</returns>
        ProfileDto findOne();

        /// <summary>
        /// 儲存個人資料
        /// </summary>
        /// <param name="profilePayload">ProfilePayload</param>
        /// <returns>ProfileDto</returns>
        ProfileDto save(ProfilePayload profilePayload);
    }
}
