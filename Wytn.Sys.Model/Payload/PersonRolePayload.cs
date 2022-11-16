namespace Wytn.Sys.Model.Payload
{
    /// <summary>
    /// 人員角色Payload
    /// </summary>
    public class PersonRolePayload
    {
        /// <summary>
        /// 人員Id
        /// </summary>
        public string userId { get; set; }
        /// <summary>
        /// 角色Id
        /// </summary>
        public string[] roleIds { get; set; }
    }
}
