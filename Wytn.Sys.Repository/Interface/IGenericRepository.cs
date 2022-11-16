using System.Collections.Generic;

namespace Wytn.Sys.Repository.Interface
{
    /// <summary>
    /// 通用Repository
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IGenericRepository<T>
    {
        /// <summary>
        /// 刪除
        /// </summary>
        /// <param name="id">uuid</param>
        /// <returns></returns>
        int Delete(object id);

        /// <summary>
        /// 刪除
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns>影響筆數</returns>
        int Delete(T entity);

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns>影響筆數</returns>
        T Insert(T entity);

        /// <summary>
        /// 新增List
        /// </summary>
        /// <param name="entities">Entities</param>
        /// <returns>影響筆數</returns>
        List<T> InsertAll(List<T> entities);

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns>影響筆數</returns>
        T Update(T entity);

        /// <summary>
        /// 取Entity
        /// </summary>
        /// <param name="id">uuid</param>
        /// <returns>Entity</returns>
        T Query(string id);

        /// <summary>
        /// 取List Entity
        /// </summary>
        /// <returns>List Entity</returns>
        List<T> QueryAll();

        /// <summary>
        /// 更新List
        /// </summary>
        /// <param name="entities">Entities</param>
        /// <returns>影響筆數</returns>
        List<T> UpdateAll(List<T> entities);
    }
}
