using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Learn.Util.Model;

namespace Learn.Dal.IService.Base
{
    public interface IBaseServices<TEntity> where TEntity : class
    {
        /// <summary>
        /// 根据主键获取实体
        /// </summary>
        /// <param name="KeyValue"></param>
        /// <returns></returns>
        Task<TEntity> GetBaseEntity(string KeyValue);
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<List<TEntity>> GetBaseList();
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<List<TEntity>> GetBaseList(Expression<Func<TEntity, bool>> expression);
        /// <summary>
        /// 分页获取
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="pagination"></param>
        /// <returns></returns>
        Task<List<TEntity>> GetBasePageList(Expression<Func<TEntity, bool>> expression, Pagination pagination);


        /// <summary>扩展  更新方法  更新指定字段 
        ///  Update(o => true, new UserInfoEntity() { Name = DateTime.Now.ToString("yyyyMMddHHmmssfff"),  Mobile = "00000"  }, new string[] { "Name" }.ToList());
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="condition"></param>
        /// <param name="updateValue"></param>
        /// <param name="updateColumns"></param>
        /// <returns></returns>
       Task<int> BaseUpdate(Expression<Func<TEntity, bool>> condition, TEntity updateValue, List<string> updateColumns = null);
        /// <summary>
        /// 扩展  更新方法  更新所有字段 
        /// </summary>    Update(o => true, o => new UserInfoEntity()  { Id = o.Id, Mobile = o.Mobile,  Role = o.Role });
        /// <typeparam name="T"></typeparam>
        /// <param name="condition"></param>
        /// <param name="updateExpression"></param>
        /// <returns></returns>
       Task<int> BaseUpdate(Expression<Func<TEntity, bool>> condition, Expression<Func<TEntity, TEntity>> updateExpression);
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        Task<int> BaseDeleteEntity(string keyValue);
        /// <summary>
        /// 插入实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<int> BaseInsert(TEntity entity);
        /// <summary>
        /// 批量插入
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<int> BaseInsert(List<TEntity> entity);

    }

}
