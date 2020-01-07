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
            expression = expression.And(t => t.is_enabled == true && t.is_delete == false && t.user_account == userName);
            expression = expression.Or(t => t.mobile == userName);
            expression = expression.Or(t => t.email == userName); 
            return await this.BaseRepository().FindEntity(expression);  
        }
        public bool ExistAccount(string account)
        {
            var expression = LinqExtensions.True<UserEntity>();
            expression = expression.And(t => t.is_enabled == true && t.is_delete == false);
            expression = expression.And(t => t.user_account == account);  
            return this.BaseRepository().IQueryable(expression).Count() > 0 ? true : false;
        }
        public bool ExistMobile(string mobile)
        {
            var expression = LinqExtensions.True<UserEntity>();
            expression = expression.And(t => t.is_enabled == true && t.is_delete == false);
            expression = expression.And(t => t.mobile == mobile);
            return this.BaseRepository().IQueryable(expression).Count() > 0 ? true : false;
        }
        public bool ExistEmail(string email)
        {
            var expression = LinqExtensions.True<UserEntity>();
            expression = expression.And(t => t.is_enabled == true && t.is_delete == false);
            expression = expression.And(t => t.email == email);
            return this.BaseRepository().IQueryable(expression).Count() > 0 ? true : false;
        }
        #endregion

        #region MyRegion 提交数据
        public async Task SaveForm(UserEntity entity)
        {
            var db = this.BaseRepository().BeginTrans();
            try
            {
                if (entity.id.IsEmpty())
                {
                    //await entity.Create();
                    //await db.Insert(entity);
                }
                else
                {
                    //await db.Delete<UserBelongEntity>(t => t.UserId == entity.Id);

                    //// 密码不进行更新，有单独的方法更新密码
                    //entity.Password = null;
                    //await entity.Modify();
                    //await db.Update(entity);
                }
                // 职位
                //if (!string.IsNullOrEmpty(entity.PositionIds))
                //{
                //    foreach (long positionId in TextHelper.SplitToArray<long>(entity.PositionIds, ','))
                //    {
                //        UserBelongEntity positionBelongEntity = new UserBelongEntity();
                //        positionBelongEntity.UserId = entity.Id;
                //        positionBelongEntity.BelongId = positionId;
                //        positionBelongEntity.BelongType = UserBelongTypeEnum.Position.ParseToInt();
                //        await positionBelongEntity.Create();
                //        await db.Insert(positionBelongEntity);
                //    }
                //}
                //// 角色
                //if (!string.IsNullOrEmpty(entity.RoleIds))
                //{
                //    foreach (long roleId in TextHelper.SplitToArray<long>(entity.RoleIds, ','))
                //    {
                //        UserBelongEntity departmentBelongEntity = new UserBelongEntity();
                //        departmentBelongEntity.UserId = entity.Id;
                //        departmentBelongEntity.BelongId = roleId;
                //        departmentBelongEntity.BelongType = UserBelongTypeEnum.Role.ParseToInt();
                //        await departmentBelongEntity.Create();
                //        await db.Insert(departmentBelongEntity);
                //    }
                //}
                await db.Commit();
            }
            catch
            {
                db.Rollback();
                throw;
            }
        }

        #endregion


    }
}
