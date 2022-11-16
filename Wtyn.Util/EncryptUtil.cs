namespace Wytn.Util
{
    /// <summary>
    /// 加解密 Utility
    /// </summary>
    public static class EncryptUtil
    {
        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="text">原始文字</param>
        /// <param name="key">加解密key</param>
        /// <param name="iv">加解密iv</param>
        /// <returns></returns>
        public static string EncryptAES(string text, string key, string iv)
        {
            var sourceBytes = System.Text.Encoding.UTF8.GetBytes(text);
            var aes = System.Security.Cryptography.Aes.Create();
            aes.Mode = System.Security.Cryptography.CipherMode.CBC;
            aes.Padding = System.Security.Cryptography.PaddingMode.PKCS7;
            aes.Key = System.Text.Encoding.UTF8.GetBytes(key);
            aes.IV = System.Text.Encoding.UTF8.GetBytes(iv);
            var transform = aes.CreateEncryptor();
            return System.Convert.ToBase64String(transform.TransformFinalBlock(sourceBytes, 0, sourceBytes.Length));
        }

        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="text">加密文字</param>
        /// <param name="key">加解密key</param>
        /// <param name="iv">加解密iv</param>
        /// <returns></returns>
        public static string DecryptAES(string text, string key, string iv)
        {
            var encryptBytes = System.Convert.FromBase64String(text);
            var aes = System.Security.Cryptography.Aes.Create();
            aes.Mode = System.Security.Cryptography.CipherMode.CBC;
            aes.Padding = System.Security.Cryptography.PaddingMode.PKCS7;
            aes.Key = System.Text.Encoding.UTF8.GetBytes(key);
            aes.IV = System.Text.Encoding.UTF8.GetBytes(iv);
            var transform = aes.CreateDecryptor();
            return System.Text.Encoding.UTF8.GetString(transform.TransformFinalBlock(encryptBytes, 0, encryptBytes.Length));
        }
    }
}
