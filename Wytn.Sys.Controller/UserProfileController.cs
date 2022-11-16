using Wytn.Sys.Model.Dto;
using Wytn.Sys.Model.Payload;
using Wytn.Sys.Service.Interface;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Wytn.Sys.Controller
{
    /// <summary>
    /// 個人資料相關API
    /// </summary>
    [Route("api/profiles")]
    [Authorize]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        private readonly IProfileService profileService;
        public UserProfileController(IProfileService profileService)
        {
            this.profileService = profileService;
        }

        /// <summary>
        /// 取個人資料
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<ProfileDto> findOne()
        {
            ProfileDto obj = profileService.findOne();
            return Ok(obj);
        }

        /// <summary>
        /// 儲存個人資料
        /// </summary>
        /// <param name="profilePayload">ProfilePayload</param>
        /// <returns>ProfileDto</returns>
        [HttpPost]
        public ActionResult<ProfileDto> save(ProfilePayload profilePayload)
        {
            ProfileDto obj = profileService.save(profilePayload);
            return Ok(obj);
        }
    }
}
