
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learn.Dal.Entity.SystemManage
{
    /// <summary>
    /// 版 本 2.0
    /// Copyright (c)  
    /// 创建人：宋江
    /// 日 期：2015.10.29 15:13
    /// 描 述：系统视图
    /// </summary>
    [Table("sys_module_column")]
    public class ModuleColumnEntity : BaseEntity
    {
        #region 实体成员 
        /// <summary>
        /// 功能主键
        /// </summary>		
        public string module_id { get; set; }
        /// <summary>
        /// 父级主键
        /// </summary>		
        public string parent_id { get; set; }
        /// <summary>
        /// 编码
        /// </summary>		
        public string en_code { get; set; }
        /// <summary>
        /// 名称
        /// </summary>		
        public string full_name { get; set; }
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
