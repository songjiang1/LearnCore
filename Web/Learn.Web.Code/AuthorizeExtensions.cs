using Learn.Util.Extension;
using System;
using System.Collections.Generic; 
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Learn.Web.Code
{
    /// <summary>
    /// 版 本
    /// Copyright (c)  
    /// 创建人：宋江
    /// 日 期：2016.03.29 22:35
    /// 描 述：授权认证
    /// </summary>
    public static class AuthorizeExtensions
    {
        #region 带权限的数据源查询
        /// <summary>
        /// 获取授权数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns> 
        public async static IAsyncEnumerable<T> ToAuthorizeData<T>(this IEnumerable<T> data)
        {
            if (data != null)
            {
                string dataAutor = null;
                OperatorInfo operatorInfo = await Operator.Instance.Current();
                if (operatorInfo != null && operatorInfo.IsSystem)
                {
                    yield return (T)data;
                }
                if (operatorInfo != null)
                {
                    dataAutor = operatorInfo.DataAuthorize.ReadAutorizeUserId;
                    var parameter = Expression.Parameter(typeof(T), "t");
                    var authorConditon = Expression.Constant(dataAutor).Call("Contains", parameter.Property("CreateUserId"));
                    var lambda = authorConditon.ToLambda<Func<T, bool>>(parameter);
                    yield return (T)data.Where(lambda.Compile());
                } 
            } 
            yield return default(T);

        }
        #endregion
    }
}
