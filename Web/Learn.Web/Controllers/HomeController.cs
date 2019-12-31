using Learn.Dal.Busines.SystemManage;
using Learn.Util;
using Learn.Util.Enum;
using Learn.Util.Model;
using Microsoft.AspNetCore.Mvc;
using Learn.Dal.Entity.BaseManage;
using System;
using System.Threading.Tasks;

namespace Learn.Web.Controllers
{
    public class HomeController : BaseController
    {

        private UserBLL uerBLL = new UserBLL();
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
                TData<UserEntity> userObj = await uerBLL.CheckLogin(userName, password, (int)PlatformEnum.Web);
                if (userObj.Tag == RequestTypeEnum.Success)
                {
                    //await new UserBLL().UpdateUser(userObj.Result);
                    //await Operator.Instance.AddCurrent(userObj.Result.web_token);
                }

                string ip = NetHelper.Ip;
                string browser = NetHelper.Browser;
                string os = NetHelper.GetOSVersion();
                string userAgent = NetHelper.UserAgent;

                //Action taskAction = async () =>
                //{
                //    //LogLoginEntity logLoginEntity = new LogLoginEntity
                //    //{
                //    //    LogStatus = userObj.Tag == 1 ? OperateStatusEnum.Success.ParseToInt() : OperateStatusEnum.Fail.ParseToInt(),
                //    //    Remark = userObj.Message,
                //    //    IpAddress = ip,
                //    //    IpLocation = IpLocationHelper.GetIpLocation(ip),
                //    //    Browser = browser,
                //    //    OS = os,
                //    //    ExtraRemark = userAgent,
                //    //    BaseCreatorId = userObj.Result?.Id
                //    //};

                //    // 让底层不用获取HttpContext
                //    //logLoginEntity.BaseCreatorId = logLoginEntity.BaseCreatorId ?? 0;

                //    //await new LogLoginBLL().SaveForm(logLoginEntity);
                //};
                //AsyncTaskHelper.StartTask(taskAction);

                obj.Tag = userObj.Tag;
                obj.Msg = userObj.Msg;
                return Json(obj);
            }
            catch (Exception ex)
            {
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