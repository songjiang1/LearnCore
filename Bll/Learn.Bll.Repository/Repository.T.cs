using Learn.Util.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Learn.Bll.Repository
{
    /// <summary> 
    /// 日 期：2018.10.18
    /// 描 述：定义仓储模型中的数据标准操作接口
    /// </summary>
    public class Repository<T> 
    {
        #region 构造
        public IDatabase db;
        public Repository(IDatabase iDatabase)
        {
            this.db = iDatabase;
        }
        #endregion

         

        #region 执行 SQL 语句
        public async Task<int> ExecuteBySql(string strSql)
        {
            return await db.ExecuteBySql(strSql);
        }
        public async Task<int> ExecuteBySql(string strSql, params DbParameter[] dbParameter)
        {
            return await db.ExecuteBySql(strSql, dbParameter);
        }
        public async Task<int> ExecuteByProc(string procName)
        {
            return await db.ExecuteByProc(procName);
        }
        public async Task<int> ExecuteByProc(string procName, params DbParameter[] dbParameter)
        {
            return await db.ExecuteByProc(procName, dbParameter);
        }
        #endregion

        #region 查询 
        public async Task<T> FindEntity<T>(object keyValue) where T : class
        {
            return await db.FindEntity<T>(keyValue);
        }
        public async Task<T> FindEntity<T>(Expression<Func<T, bool>> condition) where T : class, new()
        {
            return await db.FindEntity<T>(condition);
        }

        public async Task<IEnumerable<T>> FindList<T>() where T : class, new()
        {
            return await db.FindList<T>();
        }
        public async Task<IEnumerable<T>> FindList<T>(Expression<Func<T, bool>> condition) where T : class, new()
        {
            return await db.FindList<T>(condition);
        }

        #endregion

        #region  更新
        public async Task<int> Update<T>(T entity) where T : class
        {
            return await db.Update<T>(entity);
        }
        public async Task<int> Update<T>(List<T> entity) where T : class
        {
            return await db.Update<T>(entity);
        }
        public async Task<int> UpdateAllField<T>(T entity) where T : class
        {
            return await db.UpdateAllField<T>(entity);
        }
        public async Task<int> Update<T>(Expression<Func<T, bool>> condition) where T : class, new()
        {
            return await db.Update<T>(condition);
        }

        public IQueryable<T> IQueryable<T>(Expression<Func<T, bool>> condition) where T : class, new()
        {
            return db.IQueryable<T>(condition);
        }
        #endregion

        #region  删除
        public async Task<int> Delete<T>() where T : class
        {
            return await db.Delete<T>();
        }
        public async Task<int> Delete<T>(T entity) where T : class
        {
            return await db.Delete<T>(entity);
        }
        public async Task<int> Delete<T>(List<T> entity) where T : class
        {
            return await db.Delete<T>(entity);
        }
        public async Task<int> Delete<T>(Expression<Func<T, bool>> condition) where T : class, new()
        {
            return await db.Delete<T>(condition);
        }
        public async Task<int> Delete<T>(long id) where T : class
        {
            return await db.Delete<T>(id);
        }
        public async Task<int> Delete<T>(long[] id) where T : class
        {
            return await db.Delete<T>(id);
        }
        public async Task<int> Delete<T>(string id) where T : class
        {
            return await db.Delete<T>(id);
        }
        public async Task<int> Delete<T>(string propertyName, long propertyValue) where T : class
        {
            return await db.Delete<T>(propertyName, propertyValue);
        }
        #endregion


    }
}
