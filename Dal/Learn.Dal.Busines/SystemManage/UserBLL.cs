using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 
namespace Learn.Dal.Busines.SystemManage
{
    public class UserBLL
    {
        private UserService userService = new UserService(); 

        #region 获取数据
        public async Task<TData<List<UserEntity>>> GetList(UserListParam param)
        {
            TData<List<UserEntity>> obj = new TData<List<UserEntity>>();
            obj.Result = await userService.GetList(param);
            obj.TotalCount = obj.TotalCount;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<List<UserEntity>>> GetPageList(UserListParam param, Pagination pagination)
        {
            TData<List<UserEntity>> obj = new TData<List<UserEntity>>();
            if (param != null)
            {
                if (param.DepartmentId != null)
                {
                    param.ChildrenDepartmentIdList = await departmentBLL.GetDepartmentIdList(param.DepartmentId.Value);
                }
            }
            obj.Result = await userService.GetPageList(param, pagination);
            List<UserBelongEntity> userBelongList = await userBelongService.GetList(new UserBelongEntity { UserIds = obj.Result.Select(p => p.Id.Value).ParseToStrings<long>() });
            List<DepartmentEntity> departmentList = await departmentService.GetList(new DepartmentListParam { Ids = userBelongList.Select(p => p.BelongId.Value).ParseToStrings<long>() });
            foreach (UserEntity user in obj.Result)
            {
                user.DepartmentName = departmentList.Where(p => p.Id == user.DepartmentId).Select(p => p.DepartmentName).FirstOrDefault();
            }
            obj.TotalCount = pagination.TotalCount;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<UserEntity>> GetEntity(long id)
        {
            TData<UserEntity> obj = new TData<UserEntity>();
            obj.Result = await userService.GetEntity(id);

            await GetUserBelong(obj.Result);

            if (obj.Result.DepartmentId > 0)
            {
                DepartmentEntity departmentEntity = await departmentService.GetEntity(obj.Result.DepartmentId.Value);
                if (departmentEntity != null)
                {
                    obj.Result.DepartmentName = departmentEntity.DepartmentName;
                }
            }

            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<UserEntity>> CheckLogin(string userName, string password, int platform)
        {
            TData<UserEntity> obj = new TData<UserEntity>();
            if (userName.IsEmpty() || password.IsEmpty())
            {
                obj.Message = "用户名或密码不能为空";
                return obj;
            }
            UserEntity user = await userService.CheckLogin(userName);
            if (user != null)
            {
                if (user.UserStatus == (int)StatusEnum.Yes)
                {
                    if (user.Password == EncryptUserPassword(password, user.Salt))
                    {
                        user.LoginCount++;
                        user.IsOnline = 1;

                        #region 设置日期
                        if (user.FirstVisit == GlobalConstant.DefaultTime)
                        {
                            user.FirstVisit = DateTime.Now;
                        }
                        if (user.PreviousVisit == GlobalConstant.DefaultTime)
                        {
                            user.PreviousVisit = DateTime.Now;
                        }
                        if (user.LastVisit != GlobalConstant.DefaultTime)
                        {
                            user.PreviousVisit = user.LastVisit;
                        }
                        user.LastVisit = DateTime.Now;
                        #endregion

                        switch (platform)
                        {
                            case (int)PlatformEnum.Web:
                                if (GlobalContext.SystemConfig.LoginMultiple)
                                {
                                    #region 多次登录用同一个token
                                    if (string.IsNullOrEmpty(user.WebToken))
                                    {
                                        user.WebToken = SecurityHelper.GetGuid();
                                    }
                                    #endregion
                                }
                                else
                                {
                                    user.WebToken = SecurityHelper.GetGuid();
                                }
                                break;

                            case (int)PlatformEnum.WebApi:
                                user.ApiToken = SecurityHelper.GetGuid();
                                break;
                        }
                        await GetUserBelong(user);

                        obj.Result = user;
                        obj.Message = "登录成功";
                        obj.Tag = 1;
                    }
                    else
                    {
                        obj.Message = "密码不正确，请重新输入";
                    }
                }
                else
                {
                    obj.Message = "账号被禁用，请联系管理员";
                }
            }
            else
            {
                obj.Message = "账号不存在，请重新输入";
            }
            return obj;
        }
        #endregion

        #region 提交数据
       
        #endregion

        #region 私有方法
         
        #endregion
    }
}
