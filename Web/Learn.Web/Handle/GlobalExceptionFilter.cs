using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks; 
using Microsoft.AspNetCore.Mvc;
using System.Web;
using Learn.Util.Model;
using Learn.Util.Extension; 

namespace Learn.Web.Controllers
{
    /// <summary>
    /// 全局异常过滤器
    /// </summary>
    public class GlobalExceptionFilter : IExceptionFilter, IAsyncExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            //LogHelper.WriteWithTime(context.Exception);
            if (context.HttpContext.Request.IsAjaxRequest())
            {
                TData obj = new TData();
                obj.Msg = context.Exception.GetOriginalException().Message;
                if (string.IsNullOrEmpty(obj.Msg))
                {
                    obj.Msg = "抱歉，系统错误，请联系管理员！";
                }
                context.Result = new CustomJsonResult { Value = obj };
                context.ExceptionHandled = true;
            }
            else
            {
                string errorMessage = context.Exception.GetOriginalException().Message;
                context.Result = new RedirectResult("~/Home/Error?message=" + HttpUtility.UrlEncode(errorMessage));
                context.ExceptionHandled = true;
            }
        }

        public Task OnExceptionAsync(ExceptionContext context)
        {
            OnException(context);
            return Task.CompletedTask;
        }
    }
}