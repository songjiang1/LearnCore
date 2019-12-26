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

        public async Task<TEntity> GetEntity(string KeyValue)
        {
            return await this.BaseRepository().FindEntity<TEntity>(KeyValue);
        }
        public async Task<List<TEntity>> GetList()
        {
            var list = await this.BaseRepository().FindList<TEntity>();
            return list.ToList();
        } 
        public async Task<int> Update(TEntity entity)
        {
            return  await this.BaseRepository().Update(entity);
        }
        public async Task<int> DeleteEntity(string KeyValue)
        {
            return  await this.BaseRepository().Delete(KeyValue);
        }

    }

}
