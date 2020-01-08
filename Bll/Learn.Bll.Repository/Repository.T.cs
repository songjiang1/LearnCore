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
    public class Repository<T> : IRepository<T> where T : class, new()
    {
        #region 构造
        public IDatabase db;
        public Repository(IDatabase iDatabase)
        {
            this.db = iDatabase;
        }
        #endregion


        #region 事务提交
        public IRepository<T> BeginTrans()
        {
            db.BeginTrans();
            return this;
        }
        public async Task<int> Commit()
        {
            return await db.Commit();
        }
        public void Rollback()
        {
            db.Rollback();
        }
        public void Close()
        {
            db.Close();
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
        public async Task<T> FindEntity<T>(string id) where T : class
        {
            return await db.FindEntity<T>(id);
        }
        public async Task<T> FindEntity<T>(Expression<Func<T, bool>> condition) where T : class, new()
        {
            return await db.FindEntity<T>(condition);
        }

        public async Task<IEnumerable<T>> FindList<T>() where T : class, new()
        {
            return await db.FindList<T>();
        }
        public async Task<IEnumerable<T>> FindList<T>(Func<T, object> orderby) where T : class, new()
        {
            return await db.FindList<T>(orderby);
        }
        public async Task<IEnumerable<T>> FindList<T>(Expression<Func<T, bool>> condition) where T : class, new()
        {
            return await db.FindList<T>(condition);
        }
        public async Task<IEnumerable<T>> FindList<T>(Expression<Func<T, bool>> condition, Pagination pagination) where T : class, new()
        {
            var data = await db.FindList<T>(condition, pagination.Sort, pagination.SortType.ToLower() == "asc" ? true : false, pagination.PageSize, pagination.PageIndex);
            pagination.TotalCount = data.total;
            return data.list;
        }
        public async Task<IEnumerable<T>> FindList<T>(string strSql) where T : class
        {
            return await db.FindList<T>(strSql);
        }
        public async Task<IEnumerable<T>> FindList<T>(string strSql, DbParameter[] dbParameter) where T : class
        {
            return await db.FindList<T>(strSql, dbParameter);
        } 
        
        #endregion


        #region 数据源 查询
        public async Task<DataTable> FindTable(string strSql)
        {
            return await db.FindTable(strSql);
        }
        public async Task<DataTable> FindTable(string strSql, DbParameter[] dbParameter)
        {
            return await db.FindTable(strSql, dbParameter);
        }
        public async Task<DataTable> FindTable(string strSql, Pagination pagination)
        {
            var data = await db.FindTable(strSql, pagination.Sort, pagination.SortType.ToLower() == "asc" ? true : false, pagination.PageSize, pagination.PageIndex);
            pagination.TotalCount = data.total;
            return data.Item2;
        }
        public async Task<DataTable> FindTable(string strSql, DbParameter[] dbParameter, Pagination pagination)
        {
            var data = await db.FindTable(strSql, dbParameter, pagination.Sort, pagination.SortType.ToLower() == "asc" ? true : false, pagination.PageSize, pagination.PageIndex);
            pagination.TotalCount = data.total;
            return data.Item2;
        }

        public async Task<object> FindObject(string strSql)
        {
            return await db.FindObject(strSql);
        }
        public async Task<object> FindObject(string strSql, DbParameter[] dbParameter)
        {
            return await db.FindObject(strSql, dbParameter);
        }
        public async Task<T> FindObject<T>(string strSql) where T : class
        {
            return await db.FindObject<T>(strSql);
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
        /// <summary>扩展  更新方法  更新指定字段 
        ///  Update(o => true, new UserInfoEntity() { Name = DateTime.Now.ToString("yyyyMMddHHmmssfff"),  Mobile = "00000"  }, new string[] { "Name" }.ToList());
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="condition"></param>
        /// <param name="updateValue"></param>
        /// <param name="updateColumns"></param>
        /// <returns></returns>
        public async Task<int> Update<T>(Expression<Func<T, bool>> condition, T updateValue, List<string> updateColumns = null) where T : class, new()
        {
            return await db.Update(condition,updateValue, updateColumns);
        }
        /// <summary>
        /// 扩展  更新方法  更新所有字段 
        /// </summary>    Update(o => true, o => new UserInfoEntity()  { Id = o.Id, Mobile = o.Mobile,  Role = o.Role });
        /// <typeparam name="T"></typeparam>
        /// <param name="condition"></param>
        /// <param name="updateExpression"></param>
        /// <returns></returns>
        public async Task<int> Update<T>(Expression<Func<T, bool>> condition, Expression<Func<T, T>> updateExpression) where T : class, new()
        {
            return await db.Update(condition, updateExpression);
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
        public async Task<int> Delete<T>(string[] id) where T : class
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

        #region MyRegion 插入
        public async Task<int> Insert<T>(T entity) where T : class
        {
            return await db.Insert<T>(entity);
        }
        public async Task<int> Insert<T>(List<T> entity) where T : class
        {
            return await db.Insert<T>(entity);
        }

        #endregion

    }
}
