using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;
using System.Linq;

using Wytn.Sys.Repository.Interface;
using Wytn.Util;
using MySqlConnector;
using RepoDb;

namespace Wytn.Sys.Repository
{
    /// <inheritdoc/>
    public class GenericRepository<T> : BaseRepository<T, MySqlConnection>, IGenericRepository<T>
        where T : class
    {
        private readonly IConnectionFactory connectionFactory;
        private readonly PrincipalAccessor principalAccessor;

        public GenericRepository(IConnectionFactory connectionFactory, PrincipalAccessor principalAccessor)
            : base(connectionFactory.getConnectionString(), trace: TraceFactory.CreateTracer())
        {
            this.connectionFactory = connectionFactory;
            this.principalAccessor = principalAccessor;
        }

        public int Delete(object id)
        {
            return base.Delete(id);
        }
        public int Delete(T entity)
        {
            return base.Delete(entity);
        }
        public int DeleteAll(object[] ids)
        {
            return base.DeleteAll(ids);
        }
        public IEnumerable<TEntity> ExecuteQuery<TEntity>(string sql, object param = null)
        {
            using var conn = connectionFactory.createConnection();
            return conn.ExecuteQuery<TEntity>(sql, param);
        }
        public T Insert(T entity)
        {
            Type t = entity.GetType();
            foreach (var propInfo in t.GetProperties())
            {
                if (propInfo.Name == "id" && propInfo.PropertyType == typeof(Guid) && (Guid)propInfo.GetValue(entity, null) == Guid.Empty)
                {
                    propInfo.SetValue(entity, Guid.NewGuid(), null);
                }
                else if (propInfo.Name == "creUser" && propInfo.GetValue(entity, null) == null)
                {
                    propInfo.SetValue(entity, principalAccessor.userId, null);
                }
                else if (propInfo.Name == "creDate" && propInfo.GetValue(entity, null) == null)
                {
                    propInfo.SetValue(entity, DateTime.Now, null);
                }
            }
            base.Insert(entity);
            return entity;
        }
        public List<T> InsertAll(List<T> entities)
        {
            foreach (T entity in entities)
            {
                Type t = entity.GetType();
                foreach (var propInfo in t.GetProperties())
                {
                    if (propInfo.Name == "id" && propInfo.PropertyType == typeof(Guid) && (Guid)propInfo.GetValue(entity, null) == Guid.Empty)
                    {
                        propInfo.SetValue(entity, Guid.NewGuid(), null);
                    }
                    else if (propInfo.Name == "creUser" && propInfo.GetValue(entity, null) == null)
                    {
                        propInfo.SetValue(entity, principalAccessor.userId, null);
                    }
                    else if (propInfo.Name == "creDate" && propInfo.GetValue(entity, null) == null)
                    {
                        propInfo.SetValue(entity, DateTime.Now, null);
                    }
                }
            }
            base.InsertAll(entities);
            return entities;
        }
        public T Query(string id)
        {
            return base.Query(id).FirstOrDefault();
        }
        public List<T> QueryAll()
        {
            return base.QueryAll()?.ToList();
        }
        public T Update(T entity)
        {
            List<string> columns = new List<string>();
            Type t = entity.GetType();
            foreach (var propInfo in t.GetProperties())
            {
                if (propInfo.Name == "updUser")
                {
                    propInfo.SetValue(entity, principalAccessor.userId, null);
                }
                else if (propInfo.Name == "updDate")
                {
                    propInfo.SetValue(entity, DateTime.Now, null);
                }
                //set update column
                var customAttributes = propInfo.GetCustomAttributes(typeof(ColumnAttribute), false);
                if (customAttributes.Length > 0)
                {
                    if (propInfo.Name != "creUser" && propInfo.Name != "creDate")
                        columns.Add((customAttributes.First() as ColumnAttribute).Name);
                }
            }
            base.Update(entity: entity, fields: Field.From(columns.ToArray()));
            return entity;
        }
        public List<T> UpdateAll(List<T> entities)
        {
            List<string> columns = new List<string>();
            bool setColumn = true;
            foreach (T entity in entities)
            {
                Type t = entity.GetType();
                foreach (var propInfo in t.GetProperties())
                {
                    if (propInfo.Name == "updUser")
                    {
                        propInfo.SetValue(entity, principalAccessor.userId, null);
                    }
                    else if (propInfo.Name == "updDate")
                    {
                        propInfo.SetValue(entity, DateTime.Now, null);
                    }
                    //set update column
                    if (setColumn)
                    {
                        var customAttributes = propInfo.GetCustomAttributes(typeof(ColumnAttribute), false);
                        if (customAttributes.Length > 0)
                        {
                            if (propInfo.Name != "creUser" && propInfo.Name != "creDate")
                                columns.Add((customAttributes.First() as ColumnAttribute).Name);
                        }
                    }
                }
                setColumn = false;
            }
            base.UpdateAll(entities, fields: Field.From(columns.ToArray()));
            return entities;
        }
    }
}
