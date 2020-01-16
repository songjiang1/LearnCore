
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learn.Dal.Entity.SystemManage
{
    /// <summary>
    /// 版 本 2.0
    /// Copyright (c)  
    /// 创建人：宋江
    /// 日 期：2015.11.20 13:32
    /// 描 述：过滤时段
    /// </summary>
    /// 
    [Table("sys_filter_time")] 
    public class FilterTimeEntity : BaseEntity
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
        /// 星期一
        /// </summary>		
        public string week_day1 { get; set; }
        /// <summary>
        /// 星期二
        /// </summary>		
        public string week_day2 { get; set; }
        /// <summary>
        /// 星期三
        /// </summary>		
        public string week_day3 { get; set; }
        /// <summary>
        /// 星期四
        /// </summary>		
        public string week_day4 { get; set; }
        /// <summary>
        /// 星期五
        /// </summary>		
        public string week_day5 { get; set; }
        /// <summary>
        /// 星期六
        /// </summary>		
        public string week_day6 { get; set; }
        /// <summary>
        /// 星期日
        /// </summary>		
        public string week_day7 { get; set; }
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
