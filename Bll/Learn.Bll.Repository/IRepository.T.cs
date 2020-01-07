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
    /// Copyright (c) 2018 合肥一沙软件
    /// 创建人：刘括
    /// 日 期：2018.10.18
    /// 描 述：定义仓储模型中的数据标准操作接口
    /// </summary>
    public interface IRepository<T> where T : class, new()
    {


        #region 事务提交
        IRepository<T> BeginTrans();
        Task<int> Commit();
        void Rollback();
        void Close();
        #endregion 
        Task<int> ExecuteBySql(string strSql);
        Task<int> ExecuteBySql(string strSql, params DbParameter[] dbParameter);
        Task<int> ExecuteByProc(string procName);
        Task<int> ExecuteByProc(string procName, DbParameter[] dbParameter);

        Task<int> Insert<T>(T entity) where T : class;
        Task<int> Insert<T>(List<T> entities) where T : class;

        Task<int> Delete<T>() where T : class;
        Task<int> Delete<T>(T entity) where T : class;
        Task<int> Delete<T>(List<T> entities) where T : class;
        Task<int> Delete<T>(Expression<Func<T, bool>> condition) where T : class, new();
        Task<int> Delete<T>(long id) where T : class;
        Task<int> Delete<T>(string id) where T : class;
        Task<int> Delete<T>(long[] id) where T : class;
        Task<int> Delete<T>(string[] id) where T : class;
        Task<int> Delete<T>(string propertyName, long propertyValue) where T : class;

        Task<int> Update<T>(T entity) where T : class;
        Task<int> Update<T>(List<T> entities) where T : class;
        Task<int> UpdateAllField<T>(T entity) where T : class;
        Task<int> Update<T>(Expression<Func<T, bool>> condition) where T : class, new();
        /// <summary> 
        /// 扩展  更新方法  更新所有字段 
        /// </summary>    Update(o => true, o => new UserInfoEntity()  { Id = o.Id, Mobile = o.Mobile,  Role = o.Role });
        /// <typeparam name="T"></typeparam>
        /// <param name="condition"></param>
        /// <param name="updateExpression"></param>
        /// <returns></returns>  
        Task<int> Update<T>(Expression<Func<T, bool>> condition, Expression<Func<T, T>> updateExpression) where T : class, new();
        /// <summary>扩展  更新方法  更新指定字段 
        ///  Update(o => true, new UserInfoEntity() { Name = DateTime.Now.ToString("yyyyMMddHHmmssfff"),  Mobile = "00000"  }, new string[] { "Name" }.ToList());
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="condition"></param>
        /// <param name="updateValue"></param>
        /// <param name="updateColumns"></param>
        /// <returns></returns>
        Task<int> Update<T>(Expression<Func<T, bool>> condition, T updateValue, List<string> updateColumns = null) where T : class, new();

        IQueryable<T> IQueryable<T>(Expression<Func<T, bool>> condition) where T : class, new();

        Task<T> FindEntity<T>(string KeyValue) where T : class;
        Task<T> FindEntity<T>(Expression<Func<T, bool>> condition) where T : class, new();

        Task<IEnumerable<T>> FindList<T>() where T : class, new();
        Task<IEnumerable<T>> FindList<T>(Func<T, object> orderby) where T : class, new();
        Task<IEnumerable<T>> FindList<T>(Expression<Func<T, bool>> condition) where T : class, new();
        Task<IEnumerable<T>> FindList<T>(string strSql) where T : class;
        Task<IEnumerable<T>> FindList<T>(string strSql, DbParameter[] dbParameter) where T : class; 
         
        Task<DataTable> FindTable(string strSql);
        Task<DataTable> FindTable(string strSql, DbParameter[] dbParameter);
        Task<DataTable> FindTable(string strSql, Pagination pagination);
        Task<DataTable> FindTable(string strSql, DbParameter[] dbParameter, Pagination pagination);

        Task<object> FindObject(string strSql);
        Task<object> FindObject(string strSql, DbParameter[] dbParameter);
        Task<T> FindObject<T>(string strSql) where T : class;

    }
}
