using Learn.Bll.Repository;
using Learn.Dal.IService.Base;
using Learn.Util.Model;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Learn.Dal.Service.Base
{
    public class BaseServices<TEntity> : RepositoryFactory<TEntity>,IBaseServices<TEntity> where TEntity : class, new()
    { 

        public async Task<TEntity> GetBaseEntity(string KeyValue)
        {
            return await this.BaseRepository().FindEntity<TEntity>(KeyValue);
        }
        public async Task<List<TEntity>> GetBaseList()
        {
            var list = await this.BaseRepository().FindList<TEntity>();
            return list.ToList();
        }
        public async Task<List<TEntity>> GetBaseList(Expression<Func<TEntity, bool>> expression)
        {
            var list = await this.BaseRepository().FindList<TEntity>(expression);
            return list.ToList();
        }
        public async Task<List<TEntity>> GetBasePageList(Expression<Func<TEntity, bool>> expression, Pagination pagination)
        { 
            var list = await this.BaseRepository().FindList(expression, pagination);
            return list.ToList();

        }

        public async Task<int> BaseUpdate(TEntity entity)
        {
            return  await this.BaseRepository().Update(entity);
        }
        /// <summary>扩展  更新方法  更新指定字段 
        ///  Update(o => true, new UserInfoEntity() { Name = DateTime.Now.ToString("yyyyMMddHHmmssfff"),  Mobile = "00000"  }, new string[] { "Name" }.ToList());
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="condition"></param>
        /// <param name="updateValue"></param>
        /// <param name="updateColumns"></param>
        /// <returns></returns>
        public async Task<int> BaseUpdate(Expression<Func<TEntity, bool>> condition, TEntity updateValue, List<string> updateColumns = null)
        {
            return await this.BaseRepository().Update(condition, updateValue, updateColumns);
        }
        /// <summary>
        /// 扩展  更新方法  更新所有字段 
        /// </summary>    Update(o => true, o => new UserInfoEntity()  { Id = o.Id, Mobile = o.Mobile,  Role = o.Role });
        /// <typeparam name="T"></typeparam>
        /// <param name="condition"></param>
        /// <param name="updateExpression"></param>
        /// <returns></returns>
        public async Task<int> BaseUpdate(Expression<Func<TEntity, bool>> condition, Expression<Func<TEntity, TEntity>> updateExpression) 
        {
            return await this.BaseRepository().Update(condition, updateExpression);
        } 

        public async Task<int> BaseDeleteEntity(string KeyValue)
        {
            return  await this.BaseRepository().Delete(KeyValue);
        }

        public async Task<int> BaseInsert(TEntity entity)
        {
           return await this.BaseRepository().Insert<TEntity>(entity); 
        }
        public async Task<int> BaseInsert(List<TEntity> entity)
        {
            return await this.BaseRepository().Insert<TEntity>(entity);
        }
    }

}
