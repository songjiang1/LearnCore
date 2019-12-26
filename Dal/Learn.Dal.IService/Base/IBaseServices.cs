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
        Task<TEntity> GetEntity(string KeyValue);
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<List<TEntity>> GetList(); 
        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<int> Update(TEntity entity); 

        Task<int> DeleteEntity(string keyValue);
        


    }

}
