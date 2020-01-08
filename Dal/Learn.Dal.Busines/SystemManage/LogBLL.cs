using Learn.Dal.Service.SystemManage;
using Learn.Util;
using Learn.Util.Enum;
using Learn.Util.Extension;
using Learn.Util.Model;
using Learn.Dal.Entity.BaseManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 
namespace Learn.Dal.Busines.SystemManage
{
    public class LogBLL
    {
        private LogService _service = new LogService(); 

        #region 获取数据 

        public async Task<TData<LogEntity>> GetEntity(string id)
        {
            TData<LogEntity> obj = new TData<LogEntity>();
            obj.Result = await _service.GetBaseEntity(id);  
            obj.Tag = RequestTypeEnum.Success;
            return obj;
        }
        public async Task<TData<List<LogEntity>>> GetPageList(Pagination pagination,string queryJson)
        {
            #region MyRegion Extensions
            var expression = LinqExtensions.True<LogEntity>(); 
            expression = expression.And(t => t.is_enabled == true && t.is_delete == false);
            var queryParam = queryJson.ToJObject();
            //日志分类
            if (!queryParam["Category"].IsEmpty())
            {
                int categoryId = queryParam["CategoryId"].ParseToInt(); 
                expression = expression.And(t => t.category_id == (OperationTypeEnum)Enum.ToObject(typeof(OperationTypeEnum), categoryId));
            }
            //操作时间
            if (!queryParam["StartTime"].IsEmpty() && !queryParam["EndTime"].IsEmpty())
            {
                DateTime startTime = queryParam["StartTime"].ToDate();
                DateTime endTime = queryParam["EndTime"].ToDate().AddDays(1);
                expression = expression.And(t => t.operate_time >= startTime && t.operate_time <= endTime);
            }
            //操作用户Id
            if (!queryParam["OperateUserId"].IsEmpty())
            {
                string OperateUserId = queryParam["OperateUserId"].ToString();
                expression = expression.And(t => t.operate_user_id == OperateUserId);
            }
            //操作用户账户
            if (!queryParam["OperateAccount"].IsEmpty())
            {
                string OperateAccount = queryParam["OperateAccount"].ToString();
                expression = expression.And(t => t.operate_account.Contains(OperateAccount));
            }
            //操作类型
            if (!queryParam["OperateType"].IsEmpty())
            {
                string operateType = queryParam["OperateType"].ToString();
                expression = expression.And(t => t.operate_type == operateType);
            }
            //功能模块
            if (!queryParam["Module"].IsEmpty())
            {
                string module = queryParam["Module"].ToString();
                expression = expression.And(t => t.module.Contains(module));
            }
            #endregion

            TData<List<LogEntity>> obj = new TData<List<LogEntity>>();
            obj.Result = await _service.GetBasePageList(expression, pagination);
            obj.TotalCount = pagination.TotalCount;
            obj.Tag = RequestTypeEnum.Success;
            return obj;
        }

        #endregion

        #region MyRegion 更新数据
        public async Task<int> DeleteLog(OperationTypeEnum categoryId, int keepTime)
        {
            DateTime operateTime = DateTime.Now;
            if (keepTime == 1)//保留近一周
            {
                operateTime = DateTime.Now.AddDays(-7);
            }
            else if (keepTime == 2)//保留近一个月
            {
                operateTime = DateTime.Now.AddMonths(-1);
            }
            else if (keepTime == 3)//保留近三个月
            {
                operateTime = DateTime.Now.AddMonths(-3);
            }
            var expression = LinqExtensions.True<LogEntity>();
            expression = expression.And(t => t.is_enabled == true && t.is_delete == false); 
            expression = expression.And(t => t.operate_time <= operateTime && t.category_id == categoryId);
            LogEntity updateEntity = new LogEntity { is_delete = true , is_enabled = false }; 
            return await _service.BaseUpdate(expression,new LogEntity { is_delete =true}, new string[] { "is_delete" }.ToList());
        }
        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="logEntity">对象</param>
        public async Task<int> WriteLog(LogEntity logEntity)
        {
            logEntity.id = Guid.NewGuid().ToString();
            logEntity.operate_time = DateTime.Now;
            logEntity.is_delete = false;
            logEntity.is_enabled = true;
            logEntity.ip_address = NetHelper.Ip;
            logEntity.ip_address_name = IpLocationHelper.GetIpLocation(NetHelper.Ip);
            logEntity.browser = NetHelper.Browser;
            logEntity.operating_system = NetHelper.GetOSVersion();
            return await _service.BaseInsert(logEntity);
        }
        #endregion
    }
}
