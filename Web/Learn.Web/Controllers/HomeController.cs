using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Learn.Web.Controllers
{
    public class HomeController : Controller
    {
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

        #region MyRegion 提交 
        [HttpPost]
        public async Task<IActionResult> LoginJson(string userName, string password)
        {
        //    TData obj = new TData();
        //    TData<UserEntity> userObj = await sysUserBLL.CheckLogin(userName, password, (int)PlatformEnum.Web);
        //    if (userObj.Tag == 1)
        //    {
        //        await new UserBLL().UpdateUser(userObj.Result);
        //        await Operator.Instance.AddCurrent(userObj.Result.WebToken);
        //    }

        //    string ip = NetHelper.Ip;
        //    string browser = NetHelper.Browser;
        //    string os = NetHelper.GetOSVersion();
        //    string userAgent = NetHelper.UserAgent;

        //    Action taskAction = async () =>
        //    {
        //        LogLoginEntity logLoginEntity = new LogLoginEntity
        //        {
        //            LogStatus = userObj.Tag == 1 ? OperateStatusEnum.Success.ParseToInt() : OperateStatusEnum.Fail.ParseToInt(),
        //            Remark = userObj.Message,
        //            IpAddress = ip,
        //            IpLocation = IpLocationHelper.GetIpLocation(ip),
        //            Browser = browser,
        //            OS = os,
        //            ExtraRemark = userAgent,
        //            BaseCreatorId = userObj.Result?.Id
        //        };

        //        // 让底层不用获取HttpContext
        //        logLoginEntity.BaseCreatorId = logLoginEntity.BaseCreatorId ?? 0;

        //        await new LogLoginBLL().SaveForm(logLoginEntity);
        //    };
        //    AsyncTaskHelper.StartTask(taskAction);

        //    obj.Tag = userObj.Tag;
        //    obj.Message = userObj.Message;
            return Json("");
        } 
        #endregion
    }
}