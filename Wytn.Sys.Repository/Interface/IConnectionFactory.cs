using System.Data;

namespace Wytn.Sys.Repository.Interface
{
    /// <summary>
    /// 資料庫連線 Factory
    /// </summary>
    public interface IConnectionFactory
    {
        /// <summary>
        /// 建立連線
        /// </summary>
        /// <returns></returns>
        IDbConnection createConnection();
        /// <summary>
        /// 取得連線
        /// </summary>
        /// <returns></returns>
        string getConnectionString();
    }
}
