using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Data;
using System.Data.Common;
using Learn.Bll.Repository;
using Learn.Dal.Entity.BaseManage;
using Learn.Dal.Model.Param.SystemManage;
using Learn.Util.Model;
using Learn.Dal.Service.Base;
using Learn.Dal.IService;
using Learn.Util.Extension;

namespace Learn.Dal.Service.SystemManage
{
    public class UserService : BaseServices<UserEntity>, IUserService
    {
        #region 获取数据
        public  Task<List<UserEntity>> GetList(UserListParam param)
        {
            var list = GetBaseList();
            return list;
        }

        public async Task<UserEntity> CheckLogin(string userName)
        {
            var expression = LinqExtensions.True<UserEntity>();
            expression = expression.And(t => t.user_account == userName); 
            expression = expression.Or(t => t.mobile == userName);
            expression = expression.Or(t => t.email == userName); 
            return await this.BaseRepository().FindEntity(expression);  
        }

        #endregion




    }
}
