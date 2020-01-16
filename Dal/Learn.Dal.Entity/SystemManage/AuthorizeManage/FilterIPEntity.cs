
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learn.Dal.Entity.SystemManage
{
    /// <summary>
    /// 版 本 2.0
    /// Copyright (c)  
    /// 创建人：宋江
    /// 日 期：2015.11.20 13:32
    /// 描 述：过滤IP
    /// </summary>
    [Table("sys_filter_ip")]
    public class FilterIPEntity : BaseEntity
    {
        #region 实体成员 
        /// <summary>
        /// 对象类型
        /// </summary>		
        public string object_type { get; set; }
        /// <summary>
        /// 对象Id
        /// </summary>		
        public string object_id { get; set; }
        /// <summary>
        /// 访问
        /// </summary>		
        public int? visit_type { get; set; }
        /// <summary>
        /// 类型
        /// </summary>		
        public int? type { get; set; }
        /// <summary>
        /// IP访问
        /// </summary>		
        public string ip_limit { get; set; }
        /// <summary>
        /// 排序码
        /// </summary>		
        public int? sort_code { get; set; } 
        /// <summary>
        /// 备注
        /// </summary>		
        public string description { get; set; } 
        #endregion

         
    }
}