using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace sys.Dal.Entity.BaseManage
{
    /// <summary>
    /// 
    /// </summary>
    /// 
    [Table("sys_log")]
    public class LogEntity
    {
       
        /// <summary>
        /// 日志主键
        /// </summary>
        public string log_id { get ; set  ; }

       
        /// <summary>
        /// 分类Id 1-登陆2-访问3-操作4-异常
        /// </summary>
        public int? category_id { get ; set ; }

       
        /// <summary>
        /// 来源对象主键
        /// </summary>
        public string source_object_id { get ; set ; }

       
        /// <summary>
        /// 来源日志内容
        /// </summary>
        public string source_content_json { get ; set ; }

       
        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime? operate_time { get ; set ; }

       
        /// <summary>
        /// 操作用户Id
        /// </summary>
        public string operate_user_id { get ; set ; }

       
        /// <summary>
        /// 操作用户
        /// </summary>
        public string operate_account { get ; set ; }

       
        /// <summary>
        /// 操作类型Id
        /// </summary>
        public string operate_type_id { get ; set ; }

       
        /// <summary>
        /// 操作类型
        /// </summary>
        public string operate_type { get ; set ; }

       
        /// <summary>
        /// 系统功能主键
        /// </summary>
        public string module_id { get ; set ; }

       
        /// <summary>
        /// 系统功能
        /// </summary>
        public string module { get ; set ; }

       
        /// <summary>
        /// IP地址
        /// </summary>
        public string ip_address { get ; set ; }

       
        /// <summary>
        /// IP地址所在城市
        /// </summary>
        public string ip_address_name { get ; set ; }

       
        /// <summary>
        /// 主机
        /// </summary>
        public string ip_host { get ; set ; }

       
        /// <summary>
        /// 浏览器
        /// </summary>
        public string browser { get ; set ; }

       
        /// <summary>
        /// 执行结果状态
        /// </summary>
        public int? execute_result { get ; set ; }

       
        /// <summary>
        /// 执行结果信息
        /// </summary>
        public string execute_resultJson { get ; set ; }

       
        /// <summary>
        /// 备注
        /// </summary>
        public string description { get ; set ; }

       
        /// <summary>
        /// 删除标记
        /// </summary>
        public Boolean? is_delete { get ; set ; }

       
        /// <summary>
        /// 有效标志
        /// </summary>
        public Boolean? is_enabled { get ; set ; }
    }
}