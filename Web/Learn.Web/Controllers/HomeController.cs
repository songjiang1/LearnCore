using Learn.Dal.Busines.SystemManage;
using Learn.Util;
using Learn.Util.Enum;
using Learn.Util.Model;
using Microsoft.AspNetCore.Mvc;
using Learn.Dal.Entity.BaseManage;
using System;
using System.Threading.Tasks;
using Learn.Web.Code;

namespace Learn.Web.Controllers
{
    public class HomeController : BaseController
    {

        private UserBLL userBLL = new UserBLL();
        private LogBLL  logBLL = new LogBLL();
        #region MyRegion 视图
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AdminDesktop()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        #endregion

        #region 提交数据
        [HttpPost]
        public async Task<IActionResult> Login(string userName, string password)
        {
            LogEntity logEntity = new LogEntity
            {
                category_id = OperationTypeEnum.Login,
                operate_type_id = ((int)OperationTypeEnum.Login).ToString(),
                operate_type = EnumHelper.GetDescription(OperationTypeEnum.Login),
                operate_account = userName,
                operate_user_id = "",
                operate_time = DateTime.Now,
                module = GlobalContext.Configuration.GetSection("SystemConfig:SoftName").Value
            };
            try
            {
                TData obj = new TData();
                //if (string.IsNullOrEmpty(captchaCode))
                //{
                //    obj.Message = "验证码不能为空";
                //    return Json(obj);
                //}
                //if (captchaCode != new SessionHelper().GetSession("CaptchaCode").ParseToString())
                //{
                //    obj.Message = "验证码错误，请重新输入";
                //    return Json(obj);
                //}
                TData<UserEntity> userObj = await userBLL.CheckLogin(userName, password, (int)PlatformEnum.Web);
                if (userObj.Tag == RequestTypeEnum.Success)
                {
                    await new UserBLL().UpdateUser(userObj.Result);
                    await Operator.Instance.AddCurrent(userObj.Result.web_token);
                }
                Action taskAction = async () =>
                { 
                    logEntity.execute_result = RequestTypeEnum.Success;
                    logEntity.execute_resultJson = "登录成功";

                    // 让底层不用获取HttpContext  
                    await  logBLL.WriteLog(logEntity);
                }; 
                AsyncTaskHelper.StartTask(taskAction); 
                obj.Tag = userObj.Tag;
                obj.Msg = userObj.Msg;
                return Json(obj);
            }
            catch (Exception ex)
            {
                logEntity.execute_result = RequestTypeEnum.Fail;
                logEntity.execute_resultJson = ex.Message;
                await logBLL.WriteLog(logEntity);
                TData obj = new TData();
                obj.Tag = RequestTypeEnum.Error;
                obj.Msg = "用户不存在";
                return Json(obj);
                throw;
            }
            
        }
        #endregion
    }
}